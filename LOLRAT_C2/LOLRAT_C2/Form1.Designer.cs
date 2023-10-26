namespace LOLRAT_C2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            gbBuild = new GroupBox();
            btnCompile = new Button();
            checkBox4 = new CheckBox();
            checkBox3 = new CheckBox();
            checkBox2 = new CheckBox();
            checkBox1 = new CheckBox();
            txtIP2 = new TextBox();
            txtPort = new TextBox();
            txtIP1 = new TextBox();
            txtTitleIP2 = new TextBox();
            txtTitleIP1 = new TextBox();
            txtTitlePort = new TextBox();
            gbClientPanel = new GroupBox();
            pbSS = new PictureBox();
            txtOutput = new TextBox();
            btnSend = new Button();
            txtCommand = new TextBox();
            listBoxClients = new ListBox();
            gbConnection = new GroupBox();
            btnListen = new Button();
            txtActivePort = new TextBox();
            textBox2 = new TextBox();
            gbBuild.SuspendLayout();
            gbClientPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbSS).BeginInit();
            gbConnection.SuspendLayout();
            SuspendLayout();
            // 
            // gbBuild
            // 
            gbBuild.Controls.Add(btnCompile);
            gbBuild.Controls.Add(checkBox4);
            gbBuild.Controls.Add(checkBox3);
            gbBuild.Controls.Add(checkBox2);
            gbBuild.Controls.Add(checkBox1);
            gbBuild.Controls.Add(txtIP2);
            gbBuild.Controls.Add(txtPort);
            gbBuild.Controls.Add(txtIP1);
            gbBuild.Controls.Add(txtTitleIP2);
            gbBuild.Controls.Add(txtTitleIP1);
            gbBuild.Controls.Add(txtTitlePort);
            gbBuild.Location = new Point(14, 16);
            gbBuild.Margin = new Padding(3, 4, 3, 4);
            gbBuild.Name = "gbBuild";
            gbBuild.Padding = new Padding(3, 4, 3, 4);
            gbBuild.Size = new Size(198, 568);
            gbBuild.TabIndex = 0;
            gbBuild.TabStop = false;
            gbBuild.Text = "Build";
            // 
            // btnCompile
            // 
            btnCompile.Location = new Point(7, 501);
            btnCompile.Margin = new Padding(3, 4, 3, 4);
            btnCompile.Name = "btnCompile";
            btnCompile.Size = new Size(184, 59);
            btnCompile.TabIndex = 8;
            btnCompile.Text = "Compile...";
            btnCompile.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            checkBox4.AutoSize = true;
            checkBox4.Location = new Point(7, 339);
            checkBox4.Margin = new Padding(3, 4, 3, 4);
            checkBox4.Name = "checkBox4";
            checkBox4.Size = new Size(166, 24);
            checkBox4.TabIndex = 7;
            checkBox4.Text = "Enable debug mode";
            checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            checkBox3.AutoSize = true;
            checkBox3.Location = new Point(7, 239);
            checkBox3.Margin = new Padding(3, 4, 3, 4);
            checkBox3.Name = "checkBox3";
            checkBox3.Size = new Size(117, 24);
            checkBox3.TabIndex = 6;
            checkBox3.Text = "Request UAC";
            checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(7, 305);
            checkBox2.Margin = new Padding(3, 4, 3, 4);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(148, 24);
            checkBox2.TabIndex = 5;
            checkBox2.Text = "Auto disable UAC";
            checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(7, 272);
            checkBox1.Margin = new Padding(3, 4, 3, 4);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(171, 24);
            checkBox1.TabIndex = 0;
            checkBox1.Text = "Auto add persistence";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // txtIP2
            // 
            txtIP2.Location = new Point(7, 195);
            txtIP2.Margin = new Padding(3, 4, 3, 4);
            txtIP2.Name = "txtIP2";
            txtIP2.Size = new Size(183, 27);
            txtIP2.TabIndex = 4;
            // 
            // txtPort
            // 
            txtPort.Location = new Point(7, 59);
            txtPort.Margin = new Padding(3, 4, 3, 4);
            txtPort.Name = "txtPort";
            txtPort.Size = new Size(183, 27);
            txtPort.TabIndex = 3;
            txtPort.Text = "1234";
            // 
            // txtIP1
            // 
            txtIP1.Location = new Point(7, 127);
            txtIP1.Margin = new Padding(3, 4, 3, 4);
            txtIP1.Name = "txtIP1";
            txtIP1.Size = new Size(183, 27);
            txtIP1.TabIndex = 0;
            txtIP1.Text = "127.0.0.1";
            // 
            // txtTitleIP2
            // 
            txtTitleIP2.BackColor = SystemColors.Control;
            txtTitleIP2.BorderStyle = BorderStyle.None;
            txtTitleIP2.Location = new Point(7, 165);
            txtTitleIP2.Margin = new Padding(3, 4, 3, 4);
            txtTitleIP2.Name = "txtTitleIP2";
            txtTitleIP2.Size = new Size(184, 20);
            txtTitleIP2.TabIndex = 2;
            txtTitleIP2.Text = "IP 2:";
            // 
            // txtTitleIP1
            // 
            txtTitleIP1.BackColor = SystemColors.Control;
            txtTitleIP1.BorderStyle = BorderStyle.None;
            txtTitleIP1.Location = new Point(7, 97);
            txtTitleIP1.Margin = new Padding(3, 4, 3, 4);
            txtTitleIP1.Name = "txtTitleIP1";
            txtTitleIP1.Size = new Size(184, 20);
            txtTitleIP1.TabIndex = 1;
            txtTitleIP1.Text = "IP 1:";
            // 
            // txtTitlePort
            // 
            txtTitlePort.BackColor = SystemColors.Control;
            txtTitlePort.BorderStyle = BorderStyle.None;
            txtTitlePort.Location = new Point(7, 29);
            txtTitlePort.Margin = new Padding(3, 4, 3, 4);
            txtTitlePort.Name = "txtTitlePort";
            txtTitlePort.Size = new Size(184, 20);
            txtTitlePort.TabIndex = 0;
            txtTitlePort.Text = "Port:";
            // 
            // gbClientPanel
            // 
            gbClientPanel.Controls.Add(pbSS);
            gbClientPanel.Controls.Add(txtOutput);
            gbClientPanel.Controls.Add(btnSend);
            gbClientPanel.Controls.Add(txtCommand);
            gbClientPanel.Controls.Add(listBoxClients);
            gbClientPanel.Location = new Point(218, 16);
            gbClientPanel.Margin = new Padding(3, 4, 3, 4);
            gbClientPanel.Name = "gbClientPanel";
            gbClientPanel.Padding = new Padding(3, 4, 3, 4);
            gbClientPanel.Size = new Size(682, 405);
            gbClientPanel.TabIndex = 1;
            gbClientPanel.TabStop = false;
            gbClientPanel.Text = "Clients";
            // 
            // pbSS
            // 
            pbSS.Location = new Point(281, 139);
            pbSS.Name = "pbSS";
            pbSS.Size = new Size(395, 259);
            pbSS.SizeMode = PictureBoxSizeMode.Zoom;
            pbSS.TabIndex = 3;
            pbSS.TabStop = false;
            // 
            // txtOutput
            // 
            txtOutput.Location = new Point(31, 145);
            txtOutput.Multiline = true;
            txtOutput.Name = "txtOutput";
            txtOutput.ScrollBars = ScrollBars.Horizontal;
            txtOutput.Size = new Size(244, 251);
            txtOutput.TabIndex = 4;
            // 
            // btnSend
            // 
            btnSend.Location = new Point(171, 29);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(67, 29);
            btnSend.TabIndex = 3;
            btnSend.Text = "Send";
            btnSend.UseVisualStyleBackColor = true;
            btnSend.Click += btnSend_Click;
            // 
            // txtCommand
            // 
            txtCommand.Location = new Point(31, 29);
            txtCommand.Name = "txtCommand";
            txtCommand.Size = new Size(125, 27);
            txtCommand.TabIndex = 2;
            txtCommand.Text = "exec$whoami";
            // 
            // listBoxClients
            // 
            listBoxClients.FormattingEnabled = true;
            listBoxClients.ItemHeight = 20;
            listBoxClients.Location = new Point(539, 28);
            listBoxClients.Margin = new Padding(3, 4, 3, 4);
            listBoxClients.Name = "listBoxClients";
            listBoxClients.Size = new Size(137, 104);
            listBoxClients.TabIndex = 0;
            // 
            // gbConnection
            // 
            gbConnection.Controls.Add(btnListen);
            gbConnection.Controls.Add(txtActivePort);
            gbConnection.Controls.Add(textBox2);
            gbConnection.Location = new Point(218, 429);
            gbConnection.Margin = new Padding(3, 4, 3, 4);
            gbConnection.Name = "gbConnection";
            gbConnection.Padding = new Padding(3, 4, 3, 4);
            gbConnection.Size = new Size(682, 155);
            gbConnection.TabIndex = 2;
            gbConnection.TabStop = false;
            gbConnection.Text = "Connection";
            // 
            // btnListen
            // 
            btnListen.Location = new Point(7, 103);
            btnListen.Margin = new Padding(3, 4, 3, 4);
            btnListen.Name = "btnListen";
            btnListen.Size = new Size(115, 31);
            btnListen.TabIndex = 9;
            btnListen.Text = "Listen";
            btnListen.UseVisualStyleBackColor = true;
            btnListen.Click += btnListen_Click;
            // 
            // txtActivePort
            // 
            txtActivePort.Location = new Point(7, 59);
            txtActivePort.Margin = new Padding(3, 4, 3, 4);
            txtActivePort.Name = "txtActivePort";
            txtActivePort.Size = new Size(115, 27);
            txtActivePort.TabIndex = 10;
            txtActivePort.Text = "1234";
            // 
            // textBox2
            // 
            textBox2.BackColor = SystemColors.Control;
            textBox2.BorderStyle = BorderStyle.None;
            textBox2.Location = new Point(7, 29);
            textBox2.Margin = new Padding(3, 4, 3, 4);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(115, 20);
            textBox2.TabIndex = 9;
            textBox2.Text = "Port:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(gbConnection);
            Controls.Add(gbClientPanel);
            Controls.Add(gbBuild);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "Form1";
            gbBuild.ResumeLayout(false);
            gbBuild.PerformLayout();
            gbClientPanel.ResumeLayout(false);
            gbClientPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbSS).EndInit();
            gbConnection.ResumeLayout(false);
            gbConnection.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox gbBuild;
        private GroupBox gbClientPanel;
        private GroupBox gbConnection;
        private TextBox txtTitlePort;
        private TextBox txtTitleIP2;
        private TextBox txtTitleIP1;
        private TextBox txtIP1;
        private TextBox txtIP2;
        private TextBox txtPort;
        private CheckBox checkBox1;
        private CheckBox checkBox2;
        private Button btnCompile;
        private CheckBox checkBox4;
        private CheckBox checkBox3;
        private Button btnListen;
        private TextBox txtActivePort;
        private TextBox textBox2;
        private ListBox listBoxClients;
        private TextBox txtCommand;
        private TextBox txtOutput;
        private Button btnSend;
        private PictureBox pbSS;
    }
}