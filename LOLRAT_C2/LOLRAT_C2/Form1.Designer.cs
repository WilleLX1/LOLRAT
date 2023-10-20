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
            gbConnection = new GroupBox();
            gbClientPanel = new GroupBox();
            gbSettings = new GroupBox();
            txtTitlePort = new TextBox();
            txtTitleIP1 = new TextBox();
            textBox1 = new TextBox();
            gbConnection.SuspendLayout();
            SuspendLayout();
            // 
            // gbConnection
            // 
            gbConnection.Controls.Add(textBox1);
            gbConnection.Controls.Add(txtTitleIP1);
            gbConnection.Controls.Add(txtTitlePort);
            gbConnection.Location = new Point(12, 12);
            gbConnection.Name = "gbConnection";
            gbConnection.Size = new Size(136, 426);
            gbConnection.TabIndex = 0;
            gbConnection.TabStop = false;
            gbConnection.Text = "Connection";
            // 
            // gbClientPanel
            // 
            gbClientPanel.Location = new Point(154, 12);
            gbClientPanel.Name = "gbClientPanel";
            gbClientPanel.Size = new Size(634, 304);
            gbClientPanel.TabIndex = 1;
            gbClientPanel.TabStop = false;
            gbClientPanel.Text = "Clients";
            // 
            // gbSettings
            // 
            gbSettings.Location = new Point(154, 322);
            gbSettings.Name = "gbSettings";
            gbSettings.Size = new Size(634, 116);
            gbSettings.TabIndex = 2;
            gbSettings.TabStop = false;
            gbSettings.Text = "Settings";
            // 
            // txtTitlePort
            // 
            txtTitlePort.BackColor = SystemColors.Control;
            txtTitlePort.BorderStyle = BorderStyle.None;
            txtTitlePort.Location = new Point(6, 22);
            txtTitlePort.Name = "txtTitlePort";
            txtTitlePort.Size = new Size(52, 16);
            txtTitlePort.TabIndex = 0;
            txtTitlePort.Text = "Port:";
            // 
            // txtTitleIP1
            // 
            txtTitleIP1.BackColor = SystemColors.Control;
            txtTitleIP1.BorderStyle = BorderStyle.None;
            txtTitleIP1.Location = new Point(6, 44);
            txtTitleIP1.Name = "txtTitleIP1";
            txtTitleIP1.Size = new Size(52, 16);
            txtTitleIP1.TabIndex = 1;
            txtTitleIP1.Text = "IP 1:";
            // 
            // textBox1
            // 
            textBox1.BackColor = SystemColors.Control;
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Location = new Point(6, 66);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(52, 16);
            textBox1.TabIndex = 2;
            textBox1.Text = "IP 1:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(gbSettings);
            Controls.Add(gbClientPanel);
            Controls.Add(gbConnection);
            Name = "Form1";
            Text = "Form1";
            gbConnection.ResumeLayout(false);
            gbConnection.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox gbConnection;
        private GroupBox gbClientPanel;
        private GroupBox gbSettings;
        private TextBox txtTitlePort;
        private TextBox textBox1;
        private TextBox txtTitleIP1;
    }
}