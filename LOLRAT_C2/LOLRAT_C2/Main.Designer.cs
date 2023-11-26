namespace LOLRAT_C2
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtOutput = new TextBox();
            dgvClients = new DataGridView();
            txtCommand = new TextBox();
            btnSend = new Button();
            btnSS = new Button();
            btnListen = new Button();
            txtActivePort = new TextBox();
            listBoxClients = new ListBox();
            txtFC2IP = new TextBox();
            gbFC2 = new GroupBox();
            txtFC2HostPort = new TextBox();
            btnStartFC2 = new Button();
            btnFC2Connect = new Button();
            txtFC2Port = new TextBox();
            gbTopBar = new GroupBox();
            textBox1 = new TextBox();
            gbClientBox = new GroupBox();
            txtOutputDebug = new TextBox();
            gbCommandSending = new GroupBox();
            gbLeftBar = new GroupBox();
            btnWebcam = new Button();
            btnShowTerminal = new Button();
            btnShowDebug = new Button();
            btnShowClients = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvClients).BeginInit();
            gbFC2.SuspendLayout();
            gbTopBar.SuspendLayout();
            gbClientBox.SuspendLayout();
            gbCommandSending.SuspendLayout();
            gbLeftBar.SuspendLayout();
            SuspendLayout();
            // 
            // txtOutput
            // 
            txtOutput.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtOutput.Location = new Point(5, 16);
            txtOutput.Multiline = true;
            txtOutput.Name = "txtOutput";
            txtOutput.ScrollBars = ScrollBars.Vertical;
            txtOutput.Size = new Size(643, 284);
            txtOutput.TabIndex = 0;
            // 
            // dgvClients
            // 
            dgvClients.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvClients.Dock = DockStyle.Fill;
            dgvClients.Location = new Point(3, 18);
            dgvClients.Name = "dgvClients";
            dgvClients.RowHeadersWidth = 51;
            dgvClients.RowTemplate.Height = 25;
            dgvClients.Size = new Size(642, 330);
            dgvClients.TabIndex = 1;
            dgvClients.Visible = false;
            // 
            // txtCommand
            // 
            txtCommand.Dock = DockStyle.Left;
            txtCommand.Location = new Point(3, 18);
            txtCommand.Name = "txtCommand";
            txtCommand.Size = new Size(441, 23);
            txtCommand.TabIndex = 2;
            txtCommand.Text = "exec$whoami";
            // 
            // btnSend
            // 
            btnSend.Dock = DockStyle.Right;
            btnSend.Location = new Point(447, 18);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(192, 28);
            btnSend.TabIndex = 3;
            btnSend.Text = "SEND";
            btnSend.UseVisualStyleBackColor = true;
            btnSend.Click += btnSend_Click;
            // 
            // btnSS
            // 
            btnSS.Location = new Point(10, 100);
            btnSS.Name = "btnSS";
            btnSS.Size = new Size(110, 22);
            btnSS.TabIndex = 4;
            btnSS.Text = "Sharescreen";
            btnSS.UseVisualStyleBackColor = true;
            btnSS.Click += btnSS_Click;
            // 
            // btnListen
            // 
            btnListen.Location = new Point(10, 330);
            btnListen.Name = "btnListen";
            btnListen.Size = new Size(110, 23);
            btnListen.TabIndex = 5;
            btnListen.Text = "Listen";
            btnListen.UseVisualStyleBackColor = true;
            btnListen.Click += btnListen_Click;
            // 
            // txtActivePort
            // 
            txtActivePort.Location = new Point(10, 304);
            txtActivePort.Name = "txtActivePort";
            txtActivePort.Size = new Size(111, 23);
            txtActivePort.TabIndex = 6;
            txtActivePort.Text = "12345";
            // 
            // listBoxClients
            // 
            listBoxClients.FormattingEnabled = true;
            listBoxClients.ItemHeight = 15;
            listBoxClients.Location = new Point(440, 13);
            listBoxClients.Name = "listBoxClients";
            listBoxClients.Size = new Size(120, 94);
            listBoxClients.TabIndex = 7;
            // 
            // txtFC2IP
            // 
            txtFC2IP.Location = new Point(6, 22);
            txtFC2IP.Name = "txtFC2IP";
            txtFC2IP.Size = new Size(100, 23);
            txtFC2IP.TabIndex = 8;
            txtFC2IP.Text = "127.0.0.1";
            // 
            // gbFC2
            // 
            gbFC2.Controls.Add(txtFC2HostPort);
            gbFC2.Controls.Add(btnStartFC2);
            gbFC2.Controls.Add(btnFC2Connect);
            gbFC2.Controls.Add(txtFC2Port);
            gbFC2.Controls.Add(txtFC2IP);
            gbFC2.Location = new Point(220, 9);
            gbFC2.Name = "gbFC2";
            gbFC2.Size = new Size(200, 124);
            gbFC2.TabIndex = 9;
            gbFC2.TabStop = false;
            gbFC2.Text = "FC2";
            // 
            // txtFC2HostPort
            // 
            txtFC2HostPort.Location = new Point(6, 92);
            txtFC2HostPort.Name = "txtFC2HostPort";
            txtFC2HostPort.Size = new Size(100, 23);
            txtFC2HostPort.TabIndex = 12;
            txtFC2HostPort.Text = "4321";
            // 
            // btnStartFC2
            // 
            btnStartFC2.Location = new Point(112, 91);
            btnStartFC2.Name = "btnStartFC2";
            btnStartFC2.Size = new Size(82, 23);
            btnStartFC2.TabIndex = 11;
            btnStartFC2.Text = "Start";
            btnStartFC2.UseVisualStyleBackColor = true;
            btnStartFC2.Click += btnStartFC2_Click;
            // 
            // btnFC2Connect
            // 
            btnFC2Connect.Location = new Point(112, 32);
            btnFC2Connect.Name = "btnFC2Connect";
            btnFC2Connect.Size = new Size(82, 26);
            btnFC2Connect.TabIndex = 10;
            btnFC2Connect.Text = "Connect";
            btnFC2Connect.UseVisualStyleBackColor = true;
            btnFC2Connect.Click += btnFC2Connect_Click;
            // 
            // txtFC2Port
            // 
            txtFC2Port.Location = new Point(6, 51);
            txtFC2Port.Name = "txtFC2Port";
            txtFC2Port.Size = new Size(100, 23);
            txtFC2Port.TabIndex = 9;
            txtFC2Port.Text = "4321";
            // 
            // gbTopBar
            // 
            gbTopBar.BackColor = Color.FromArgb(64, 64, 64);
            gbTopBar.Controls.Add(gbFC2);
            gbTopBar.Controls.Add(listBoxClients);
            gbTopBar.Controls.Add(textBox1);
            gbTopBar.Dock = DockStyle.Top;
            gbTopBar.Location = new Point(0, 0);
            gbTopBar.Margin = new Padding(3, 2, 3, 2);
            gbTopBar.Name = "gbTopBar";
            gbTopBar.Padding = new Padding(3, 2, 3, 2);
            gbTopBar.Size = new Size(805, 87);
            gbTopBar.TabIndex = 10;
            gbTopBar.TabStop = false;
            gbTopBar.Text = "TopBar";
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.FromArgb(64, 64, 64);
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Font = new Font("Segoe UI", 36F, FontStyle.Regular, GraphicsUnit.Point);
            textBox1.ForeColor = Color.White;
            textBox1.Location = new Point(10, 9);
            textBox1.Margin = new Padding(3, 2, 3, 2);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(192, 64);
            textBox1.TabIndex = 0;
            textBox1.Text = "LOLRAT";
            // 
            // gbClientBox
            // 
            gbClientBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gbClientBox.Controls.Add(txtOutputDebug);
            gbClientBox.Controls.Add(gbCommandSending);
            gbClientBox.Controls.Add(txtOutput);
            gbClientBox.Controls.Add(dgvClients);
            gbClientBox.Location = new Point(142, 92);
            gbClientBox.Margin = new Padding(3, 2, 3, 2);
            gbClientBox.Name = "gbClientBox";
            gbClientBox.Padding = new Padding(3, 2, 3, 2);
            gbClientBox.Size = new Size(648, 350);
            gbClientBox.TabIndex = 11;
            gbClientBox.TabStop = false;
            gbClientBox.Text = "ClientBox";
            // 
            // txtOutputDebug
            // 
            txtOutputDebug.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtOutputDebug.Location = new Point(0, 15);
            txtOutputDebug.Multiline = true;
            txtOutputDebug.Name = "txtOutputDebug";
            txtOutputDebug.ScrollBars = ScrollBars.Vertical;
            txtOutputDebug.Size = new Size(643, 284);
            txtOutputDebug.TabIndex = 5;
            // 
            // gbCommandSending
            // 
            gbCommandSending.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            gbCommandSending.Controls.Add(btnSend);
            gbCommandSending.Controls.Add(txtCommand);
            gbCommandSending.Dock = DockStyle.Bottom;
            gbCommandSending.Location = new Point(3, 300);
            gbCommandSending.Margin = new Padding(3, 2, 3, 2);
            gbCommandSending.Name = "gbCommandSending";
            gbCommandSending.Padding = new Padding(3, 2, 3, 2);
            gbCommandSending.Size = new Size(642, 48);
            gbCommandSending.TabIndex = 4;
            gbCommandSending.TabStop = false;
            // 
            // gbLeftBar
            // 
            gbLeftBar.Controls.Add(btnWebcam);
            gbLeftBar.Controls.Add(btnShowTerminal);
            gbLeftBar.Controls.Add(btnShowDebug);
            gbLeftBar.Controls.Add(btnSS);
            gbLeftBar.Controls.Add(btnShowClients);
            gbLeftBar.Controls.Add(txtActivePort);
            gbLeftBar.Controls.Add(btnListen);
            gbLeftBar.Dock = DockStyle.Left;
            gbLeftBar.Location = new Point(0, 87);
            gbLeftBar.Margin = new Padding(3, 2, 3, 2);
            gbLeftBar.Name = "gbLeftBar";
            gbLeftBar.Padding = new Padding(3, 2, 3, 2);
            gbLeftBar.Size = new Size(136, 363);
            gbLeftBar.TabIndex = 10;
            gbLeftBar.TabStop = false;
            gbLeftBar.Text = "LeftBar";
            // 
            // btnWebcam
            // 
            btnWebcam.Location = new Point(10, 127);
            btnWebcam.Margin = new Padding(3, 2, 3, 2);
            btnWebcam.Name = "btnWebcam";
            btnWebcam.Size = new Size(110, 22);
            btnWebcam.TabIndex = 10;
            btnWebcam.Text = "Webcam";
            btnWebcam.UseVisualStyleBackColor = true;
            btnWebcam.Click += btnWebcam_Click;
            // 
            // btnShowTerminal
            // 
            btnShowTerminal.Location = new Point(10, 73);
            btnShowTerminal.Margin = new Padding(3, 2, 3, 2);
            btnShowTerminal.Name = "btnShowTerminal";
            btnShowTerminal.Size = new Size(110, 22);
            btnShowTerminal.TabIndex = 9;
            btnShowTerminal.Text = "Terminal";
            btnShowTerminal.UseVisualStyleBackColor = true;
            btnShowTerminal.Click += btnShowTerminal_Click;
            // 
            // btnShowDebug
            // 
            btnShowDebug.Location = new Point(10, 46);
            btnShowDebug.Margin = new Padding(3, 2, 3, 2);
            btnShowDebug.Name = "btnShowDebug";
            btnShowDebug.Size = new Size(110, 22);
            btnShowDebug.TabIndex = 8;
            btnShowDebug.Text = "Debug";
            btnShowDebug.UseVisualStyleBackColor = true;
            btnShowDebug.Click += btnShowDebug_Click;
            // 
            // btnShowClients
            // 
            btnShowClients.Location = new Point(10, 20);
            btnShowClients.Margin = new Padding(3, 2, 3, 2);
            btnShowClients.Name = "btnShowClients";
            btnShowClients.Size = new Size(110, 22);
            btnShowClients.TabIndex = 7;
            btnShowClients.Text = "Clients";
            btnShowClients.UseVisualStyleBackColor = true;
            btnShowClients.Click += btnShowClients_Click;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(805, 450);
            Controls.Add(gbLeftBar);
            Controls.Add(gbClientBox);
            Controls.Add(gbTopBar);
            Name = "Main";
            Text = "Main";
            ((System.ComponentModel.ISupportInitialize)dgvClients).EndInit();
            gbFC2.ResumeLayout(false);
            gbFC2.PerformLayout();
            gbTopBar.ResumeLayout(false);
            gbTopBar.PerformLayout();
            gbClientBox.ResumeLayout(false);
            gbClientBox.PerformLayout();
            gbCommandSending.ResumeLayout(false);
            gbCommandSending.PerformLayout();
            gbLeftBar.ResumeLayout(false);
            gbLeftBar.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TextBox txtOutput;
        private DataGridView dgvClients;
        private TextBox txtCommand;
        private Button btnSend;
        private Button btnSS;
        private Button btnListen;
        private TextBox txtActivePort;
        private ListBox listBoxClients;
        private TextBox txtFC2IP;
        private GroupBox gbFC2;
        private Button btnFC2Connect;
        private TextBox txtFC2Port;
        private TextBox txtFC2HostPort;
        private Button btnStartFC2;
        private GroupBox gbTopBar;
        private GroupBox gbClientBox;
        private GroupBox gbLeftBar;
        private TextBox textBox1;
        private Button btnShowTerminal;
        private Button btnShowDebug;
        private Button btnShowClients;
        private GroupBox gbCommandSending;
        private Button btnWebcam;
        private TextBox txtOutputDebug;
    }
}