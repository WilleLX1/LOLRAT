using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;

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

        private void StartListener(int port)
        {
            server = new TcpListener(IPAddress.Any, port);
            server.Start();
            isListening = true;
            UpdateStatus("Server is listening on port " + port);

            // Start accepting client connections in a separate thread.
            Thread acceptThread = new Thread(AcceptClients);
            acceptThread.Start();
        }

        private void AcceptClients()
        {
            while (isListening)
            {
                try
                {
                    TcpClient client = server.AcceptTcpClient();
                    connectedClients.Add(client);
                    UpdateStatus("Client connected: " + client.Client.RemoteEndPoint);

                    // Handle client in a separate thread.
                    Thread clientThread = new Thread(() => HandleClient(client));
                    clientThread.Start();
                }
                catch (SocketException)
                {
                    // Handle exceptions when stopping the listener.
                    break;
                }
            }
        }

        private void HandleClient(TcpClient client)
        {
            NetworkStream stream = client.GetStream();
            byte[] buffer = new byte[1024];
            int bytesRead;

            while (isListening)
            {
                try
                {
                    bytesRead = stream.Read(buffer, 0, buffer.Length);

                    if (bytesRead > 0)
                    {
                        string message = System.Text.Encoding.ASCII.GetString(buffer, 0, bytesRead);
                        UpdateStatus("Received: " + message);

                        // Handle the message received from the client

                        // You can broadcast the message to all connected clients
                        foreach (TcpClient connectedClient in connectedClients)
                        {
                            NetworkStream clientStream = connectedClient.GetStream();
                            clientStream.Write(buffer, 0, bytesRead);
                            clientStream.Flush();
                        }
                    }
                }
                catch (Exception)
                {
                    // Handle client disconnection or other errors.
                    break;
                }
            }

            // Remove the client from the connectedClients list when the client disconnects.
            connectedClients.Remove(client);
            UpdateStatus("Client disconnected: " + client.Client.RemoteEndPoint);
            client.Close();
        }

        private void UpdateStatus(string message)
        {
            // Update the UI with status messages.
            if (InvokeRequired)
            {
                Invoke(new Action(() => UpdateStatus(message)));
            }
            else
            {
                // Update your UI controls here
            }
        }

        private void StopListener()
        {
            isListening = false;
            server.Stop();
            UpdateStatus("Server stopped.");
        }
    }
}
