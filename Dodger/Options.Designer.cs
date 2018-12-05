namespace Dodger.Components
{
    partial class Options
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.NameTb = new System.Windows.Forms.TextBox();
            this.NameLabel = new System.Windows.Forms.Label();
            this.ContinueBtn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.MouseBtn = new System.Windows.Forms.Button();
            this.KeyboardBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Dodger.Properties.Resources.Logo;
            this.pictureBox1.Location = new System.Drawing.Point(101, 24);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(235, 55);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // NameTb
            // 
            this.NameTb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameTb.Location = new System.Drawing.Point(88, 142);
            this.NameTb.Name = "NameTb";
            this.NameTb.Size = new System.Drawing.Size(253, 26);
            this.NameTb.TabIndex = 0;
            // 
            // NameLabel
            // 
            this.NameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.NameLabel.Location = new System.Drawing.Point(0, 0);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(253, 50);
            this.NameLabel.TabIndex = 20;
            this.NameLabel.Text = "What\'s your name?";
            this.NameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ContinueBtn
            // 
            this.ContinueBtn.Location = new System.Drawing.Point(88, 182);
            this.ContinueBtn.Name = "ContinueBtn";
            this.ContinueBtn.Size = new System.Drawing.Size(253, 39);
            this.ContinueBtn.TabIndex = 21;
            this.ContinueBtn.Text = "Continue";
            this.ContinueBtn.UseVisualStyleBackColor = true;
            this.ContinueBtn.Click += new System.EventHandler(this.Button_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.NameLabel);
            this.panel1.Location = new System.Drawing.Point(88, 86);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(253, 50);
            this.panel1.TabIndex = 22;
            // 
            // MouseBtn
            // 
            this.MouseBtn.Location = new System.Drawing.Point(117, 153);
            this.MouseBtn.Name = "MouseBtn";
            this.MouseBtn.Size = new System.Drawing.Size(97, 50);
            this.MouseBtn.TabIndex = 24;
            this.MouseBtn.Text = "Mouse";
            this.MouseBtn.UseVisualStyleBackColor = true;
            this.MouseBtn.Visible = false;
            this.MouseBtn.Click += new System.EventHandler(this.Button_Click);
            // 
            // KeyboardBtn
            // 
            this.KeyboardBtn.Location = new System.Drawing.Point(220, 153);
            this.KeyboardBtn.Name = "KeyboardBtn";
            this.KeyboardBtn.Size = new System.Drawing.Size(97, 50);
            this.KeyboardBtn.TabIndex = 25;
            this.KeyboardBtn.Text = "Keyboard";
            this.KeyboardBtn.UseVisualStyleBackColor = true;
            this.KeyboardBtn.Visible = false;
            this.KeyboardBtn.Click += new System.EventHandler(this.Button_Click);
            // 
            // Options
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 233);
            this.Controls.Add(this.KeyboardBtn);
            this.Controls.Add(this.MouseBtn);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ContinueBtn);
            this.Controls.Add(this.NameTb);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Options";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Select an option";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Options_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox NameTb;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Button ContinueBtn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button MouseBtn;
        private System.Windows.Forms.Button KeyboardBtn;
    }
}