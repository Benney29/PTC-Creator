namespace PTC_Creator.Forms
{
    partial class Proxy_Add
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Proxy_Add));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.WindowTitleLabel = new System.Windows.Forms.Label();
            this.WindowPanel = new System.Windows.Forms.Panel();
            this.ProxyLabel = new System.Windows.Forms.Label();
            this.ProxyTextBox = new System.Windows.Forms.TextBox();
            this.AddButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.WindowPanel.SuspendLayout();
            this.SuspendLayout();
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
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.WindowPanel_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.WindowPanel_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.WindowPanel_MouseUp);
            // 
            // WindowTitleLabel
            // 
            this.WindowTitleLabel.AutoSize = true;
            this.WindowTitleLabel.Location = new System.Drawing.Point(38, 6);
            this.WindowTitleLabel.Name = "WindowTitleLabel";
            this.WindowTitleLabel.Size = new System.Drawing.Size(364, 21);
            this.WindowTitleLabel.TabIndex = 1;
            this.WindowTitleLabel.Text = "Add Single Proxy {Ip:Port:Username:Password}";
            this.WindowTitleLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.WindowPanel_MouseDown);
            this.WindowTitleLabel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.WindowPanel_MouseMove);
            this.WindowTitleLabel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.WindowPanel_MouseUp);
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
            this.WindowPanel.Size = new System.Drawing.Size(664, 32);
            this.WindowPanel.TabIndex = 0;
            this.WindowPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.WindowPanel_MouseDown);
            this.WindowPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.WindowPanel_MouseMove);
            this.WindowPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.WindowPanel_MouseUp);
            // 
            // ProxyLabel
            // 
            this.ProxyLabel.AutoSize = true;
            this.ProxyLabel.Location = new System.Drawing.Point(132, 59);
            this.ProxyLabel.Name = "ProxyLabel";
            this.ProxyLabel.Size = new System.Drawing.Size(50, 21);
            this.ProxyLabel.TabIndex = 1;
            this.ProxyLabel.Text = "Proxy";
            // 
            // ProxyTextBox
            // 
            this.ProxyTextBox.Location = new System.Drawing.Point(206, 56);
            this.ProxyTextBox.Name = "ProxyTextBox";
            this.ProxyTextBox.Size = new System.Drawing.Size(327, 27);
            this.ProxyTextBox.TabIndex = 2;
            // 
            // AddButton
            // 
            this.AddButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddButton.Location = new System.Drawing.Point(162, 122);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(94, 41);
            this.AddButton.TabIndex = 3;
            this.AddButton.Text = "Add";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CancelButton.Location = new System.Drawing.Point(408, 122);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(94, 41);
            this.CancelButton.TabIndex = 4;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // Proxy_Add
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.ClientSize = new System.Drawing.Size(664, 192);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.ProxyTextBox);
            this.Controls.Add(this.ProxyLabel);
            this.Controls.Add(this.WindowPanel);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "Proxy_Add";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Proxy_Add";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.WindowPanel.ResumeLayout(false);
            this.WindowPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label WindowTitleLabel;
        private System.Windows.Forms.Panel WindowPanel;
        private System.Windows.Forms.Label ProxyLabel;
        private System.Windows.Forms.TextBox ProxyTextBox;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button CancelButton;
    }
}