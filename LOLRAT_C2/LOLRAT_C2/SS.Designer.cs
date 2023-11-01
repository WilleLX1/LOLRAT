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
            // SS
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(pbSS);
            Name = "SS";
            Text = "SS";
            ((System.ComponentModel.ISupportInitialize)pbSS).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pbSS;
    }
}