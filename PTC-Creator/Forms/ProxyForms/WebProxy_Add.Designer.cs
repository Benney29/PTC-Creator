namespace PTC_Creator.Forms.ProxyForms
{
    partial class WebProxy_Add
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
            this.WindowTitleLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.CancelButton = new System.Windows.Forms.Button();
            this.AddButton = new System.Windows.Forms.Button();
            this.UrlTextBox = new System.Windows.Forms.TextBox();
            this.ProxyLabel = new System.Windows.Forms.Label();
            this.WindowPanel = new System.Windows.Forms.Panel();
            this.ProxyTypeLabel = new System.Windows.Forms.Label();
            this.ProxyTypeComboBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.WindowPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // WindowTitleLabel
            // 
            this.WindowTitleLabel.AutoSize = true;
            this.WindowTitleLabel.Location = new System.Drawing.Point(38, 6);
            this.WindowTitleLabel.Name = "WindowTitleLabel";
            this.WindowTitleLabel.Size = new System.Drawing.Size(152, 21);
            this.WindowTitleLabel.TabIndex = 1;
            this.WindowTitleLabel.Text = "Add Web Proxy Url";
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
            this.CancelButton.Location = new System.Drawing.Point(386, 121);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(94, 41);
            this.CancelButton.TabIndex = 9;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // AddButton
            // 
            this.AddButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddButton.Location = new System.Drawing.Point(140, 121);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(94, 41);
            this.AddButton.TabIndex = 8;
            this.AddButton.Text = "Add";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // UrlTextBox
            // 
            this.UrlTextBox.Location = new System.Drawing.Point(74, 63);
            this.UrlTextBox.Name = "UrlTextBox";
            this.UrlTextBox.Size = new System.Drawing.Size(275, 27);
            this.UrlTextBox.TabIndex = 7;
            // 
            // ProxyLabel
            // 
            this.ProxyLabel.AutoSize = true;
            this.ProxyLabel.Location = new System.Drawing.Point(35, 66);
            this.ProxyLabel.Name = "ProxyLabel";
            this.ProxyLabel.Size = new System.Drawing.Size(33, 21);
            this.ProxyLabel.TabIndex = 6;
            this.ProxyLabel.Text = "Url:";
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
            this.WindowPanel.Size = new System.Drawing.Size(621, 32);
            this.WindowPanel.TabIndex = 5;
            // 
            // ProxyTypeLabel
            // 
            this.ProxyTypeLabel.AutoSize = true;
            this.ProxyTypeLabel.Location = new System.Drawing.Point(397, 66);
            this.ProxyTypeLabel.Name = "ProxyTypeLabel";
            this.ProxyTypeLabel.Size = new System.Drawing.Size(95, 21);
            this.ProxyTypeLabel.TabIndex = 10;
            this.ProxyTypeLabel.Text = "Proxy Type:";
            // 
            // ProxyTypeComboBox
            // 
            this.ProxyTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ProxyTypeComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ProxyTypeComboBox.FormattingEnabled = true;
            this.ProxyTypeComboBox.Location = new System.Drawing.Point(498, 63);
            this.ProxyTypeComboBox.Name = "ProxyTypeComboBox";
            this.ProxyTypeComboBox.Size = new System.Drawing.Size(87, 29);
            this.ProxyTypeComboBox.TabIndex = 11;
            // 
            // WebProxy_Add
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.ClientSize = new System.Drawing.Size(621, 192);
            this.Controls.Add(this.ProxyTypeComboBox);
            this.Controls.Add(this.ProxyTypeLabel);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.UrlTextBox);
            this.Controls.Add(this.ProxyLabel);
            this.Controls.Add(this.WindowPanel);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "WebProxy_Add";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WebProxy_Add";
            this.Load += new System.EventHandler(this.WebProxy_Add_Load);
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
        private System.Windows.Forms.TextBox UrlTextBox;
        private System.Windows.Forms.Label ProxyLabel;
        private System.Windows.Forms.Panel WindowPanel;
        private System.Windows.Forms.Label ProxyTypeLabel;
        private System.Windows.Forms.ComboBox ProxyTypeComboBox;
    }
}