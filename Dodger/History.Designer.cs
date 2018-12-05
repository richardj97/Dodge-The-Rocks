namespace Dodger
{
    partial class History
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
            this.HiscoresLb = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // HiscoresLb
            // 
            this.HiscoresLb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HiscoresLb.FormattingEnabled = true;
            this.HiscoresLb.Location = new System.Drawing.Point(0, 0);
            this.HiscoresLb.Name = "HiscoresLb";
            this.HiscoresLb.Size = new System.Drawing.Size(283, 612);
            this.HiscoresLb.TabIndex = 0;
            // 
            // Hiscores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(283, 612);
            this.Controls.Add(this.HiscoresLb);
            this.Name = "Hiscores";
            this.ShowIcon = false;
            this.Text = "Hiscore history";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox HiscoresLb;
    }
}