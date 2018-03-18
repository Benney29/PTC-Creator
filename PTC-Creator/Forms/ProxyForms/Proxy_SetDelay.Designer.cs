namespace PTC_Creator.Forms.ProxyForms
{
    partial class Proxy_SetDelay
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Proxy_SetDelay));
            this.WindowTitleLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.CancelButton = new System.Windows.Forms.Button();
            this.AddButton = new System.Windows.Forms.Button();
            this.DelayTextBox = new System.Windows.Forms.TextBox();
            this.DelayLabel = new System.Windows.Forms.Label();
            this.WindowPanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.WindowPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // WindowTitleLabel
            // 
            this.WindowTitleLabel.AutoSize = true;
            this.WindowTitleLabel.Location = new System.Drawing.Point(38, 6);
            this.WindowTitleLabel.Name = "WindowTitleLabel";
            this.WindowTitleLabel.Size = new System.Drawing.Size(119, 21);
            this.WindowTitleLabel.TabIndex = 1;
            this.WindowTitleLabel.Text = "Update Delay";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Image = global::PTC_Creator.Properties.Resources.big_logo;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // CancelButton
            // 
            this.CancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CancelButton.Location = new System.Drawing.Point(153, 92);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(94, 41);
            this.CancelButton.TabIndex = 14;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // AddButton
            // 
            this.AddButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddButton.Location = new System.Drawing.Point(44, 92);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(94, 41);
            this.AddButton.TabIndex = 13;
            this.AddButton.Text = "Update";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // DelayTextBox
            // 
            this.DelayTextBox.Location = new System.Drawing.Point(175, 39);
            this.DelayTextBox.Name = "DelayTextBox";
            this.DelayTextBox.Size = new System.Drawing.Size(63, 27);
            this.DelayTextBox.TabIndex = 12;
            this.DelayTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DelayTextBox_KeyPress);
            // 
            // DelayLabel
            // 
            this.DelayLabel.AutoSize = true;
            this.DelayLabel.Location = new System.Drawing.Point(31, 42);
            this.DelayLabel.Name = "DelayLabel";
            this.DelayLabel.Size = new System.Drawing.Size(129, 21);
            this.DelayLabel.TabIndex = 11;
            this.DelayLabel.Text = "Delay(Second):";
            // 
            // WindowPanel
            // 
            this.WindowPanel.BackColor = System.Drawing.Color.White;
            this.WindowPanel.Controls.Add(this.WindowTitleLabel);
            this.WindowPanel.Controls.Add(this.pictureBox1);
            this.WindowPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.WindowPanel.ForeColor = System.Drawing.Color.Black;
            this.WindowPanel.Location = new System.Drawing.Point(0, 0);
            this.WindowPanel.Name = "WindowPanel";
            this.WindowPanel.Size = new System.Drawing.Size(278, 32);
            this.WindowPanel.TabIndex = 10;
            // 
            // Proxy_SetDelay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.ClientSize = new System.Drawing.Size(278, 157);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.DelayTextBox);
            this.Controls.Add(this.DelayLabel);
            this.Controls.Add(this.WindowPanel);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "Proxy_SetDelay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Proxy_SetDelay";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.WindowPanel.ResumeLayout(false);
            this.WindowPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label WindowTitleLabel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.TextBox DelayTextBox;
        private System.Windows.Forms.Label DelayLabel;
        private System.Windows.Forms.Panel WindowPanel;
    }
}