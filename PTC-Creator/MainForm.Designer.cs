﻿namespace PTC_Creator
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.WindowPanel = new System.Windows.Forms.Panel();
            this.MinimizeButton = new System.Windows.Forms.Button();
            this.MaximizeButton = new System.Windows.Forms.Button();
            this.ClostButton = new System.Windows.Forms.Button();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.StatusPanel = new System.Windows.Forms.Panel();
            this.RateLabel = new System.Windows.Forms.Label();
            this.PendingLabel = new System.Windows.Forms.Label();
            this.FailLabel = new System.Windows.Forms.Label();
            this.SuccessLabel = new System.Windows.Forms.Label();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.ContentPanel = new System.Windows.Forms.Panel();
            this.ButtonPanel = new System.Windows.Forms.Panel();
            this.WebProxyButton = new System.Windows.Forms.Button();
            this.CaptchaButton = new System.Windows.Forms.Button();
            this.ProxyButton = new System.Windows.Forms.Button();
            this.CreateAccountButton = new System.Windows.Forms.Button();
            this.StatusTimer = new System.Windows.Forms.Timer(this.components);
            this.WindowPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.StatusPanel.SuspendLayout();
            this.MainPanel.SuspendLayout();
            this.ButtonPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // WindowPanel
            // 
            this.WindowPanel.BackColor = System.Drawing.Color.White;
            this.WindowPanel.Controls.Add(this.MinimizeButton);
            this.WindowPanel.Controls.Add(this.MaximizeButton);
            this.WindowPanel.Controls.Add(this.ClostButton);
            this.WindowPanel.Controls.Add(this.TitleLabel);
            this.WindowPanel.Controls.Add(this.pictureBox1);
            this.WindowPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.WindowPanel.ForeColor = System.Drawing.Color.Black;
            this.WindowPanel.Location = new System.Drawing.Point(0, 0);
            this.WindowPanel.Name = "WindowPanel";
            this.WindowPanel.Size = new System.Drawing.Size(1250, 32);
            this.WindowPanel.TabIndex = 0;
            this.WindowPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.WindowPanel_MouseDown);
            this.WindowPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.WindowPanel_MouseMove);
            this.WindowPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.WindowPanel_MouseUp);
            // 
            // MinimizeButton
            // 
            this.MinimizeButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.MinimizeButton.FlatAppearance.BorderSize = 0;
            this.MinimizeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MinimizeButton.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimizeButton.Location = new System.Drawing.Point(1154, 0);
            this.MinimizeButton.Name = "MinimizeButton";
            this.MinimizeButton.Size = new System.Drawing.Size(32, 32);
            this.MinimizeButton.TabIndex = 3;
            this.MinimizeButton.Text = "-";
            this.MinimizeButton.UseVisualStyleBackColor = true;
            this.MinimizeButton.Click += new System.EventHandler(this.MinimizeButton_Click);
            // 
            // MaximizeButton
            // 
            this.MaximizeButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.MaximizeButton.FlatAppearance.BorderSize = 0;
            this.MaximizeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MaximizeButton.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeButton.Location = new System.Drawing.Point(1186, 0);
            this.MaximizeButton.Name = "MaximizeButton";
            this.MaximizeButton.Size = new System.Drawing.Size(32, 32);
            this.MaximizeButton.TabIndex = 2;
            this.MaximizeButton.Text = "口";
            this.MaximizeButton.UseVisualStyleBackColor = true;
            this.MaximizeButton.Click += new System.EventHandler(this.MaximizeButton_Click);
            // 
            // ClostButton
            // 
            this.ClostButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.ClostButton.FlatAppearance.BorderSize = 0;
            this.ClostButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ClostButton.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClostButton.Location = new System.Drawing.Point(1218, 0);
            this.ClostButton.Name = "ClostButton";
            this.ClostButton.Size = new System.Drawing.Size(32, 32);
            this.ClostButton.TabIndex = 1;
            this.ClostButton.Text = "X";
            this.ClostButton.UseVisualStyleBackColor = true;
            this.ClostButton.Click += new System.EventHandler(this.ClostButton_Click);
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.Location = new System.Drawing.Point(38, 6);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(160, 21);
            this.TitleLabel.TabIndex = 1;
            this.TitleLabel.Text = "Shuffle PTC Creator";
            this.TitleLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.WindowPanel_MouseDown);
            this.TitleLabel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.WindowPanel_MouseMove);
            this.TitleLabel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.WindowPanel_MouseUp);
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
            // StatusPanel
            // 
            this.StatusPanel.BackColor = System.Drawing.Color.SaddleBrown;
            this.StatusPanel.Controls.Add(this.RateLabel);
            this.StatusPanel.Controls.Add(this.PendingLabel);
            this.StatusPanel.Controls.Add(this.FailLabel);
            this.StatusPanel.Controls.Add(this.SuccessLabel);
            this.StatusPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.StatusPanel.ForeColor = System.Drawing.Color.White;
            this.StatusPanel.Location = new System.Drawing.Point(0, 752);
            this.StatusPanel.Name = "StatusPanel";
            this.StatusPanel.Size = new System.Drawing.Size(1250, 32);
            this.StatusPanel.TabIndex = 1;
            // 
            // RateLabel
            // 
            this.RateLabel.AutoSize = true;
            this.RateLabel.Location = new System.Drawing.Point(646, 6);
            this.RateLabel.Name = "RateLabel";
            this.RateLabel.Size = new System.Drawing.Size(163, 21);
            this.RateLabel.TabIndex = 3;
            this.RateLabel.Text = "Success Rate: 0.00%";
            // 
            // PendingLabel
            // 
            this.PendingLabel.AutoSize = true;
            this.PendingLabel.Location = new System.Drawing.Point(426, 6);
            this.PendingLabel.Name = "PendingLabel";
            this.PendingLabel.Size = new System.Drawing.Size(78, 21);
            this.PendingLabel.TabIndex = 2;
            this.PendingLabel.Text = "Pending:";
            // 
            // FailLabel
            // 
            this.FailLabel.AutoSize = true;
            this.FailLabel.ForeColor = System.Drawing.Color.White;
            this.FailLabel.Location = new System.Drawing.Point(241, 6);
            this.FailLabel.Name = "FailLabel";
            this.FailLabel.Size = new System.Drawing.Size(43, 21);
            this.FailLabel.TabIndex = 1;
            this.FailLabel.Text = "Fail: ";
            // 
            // SuccessLabel
            // 
            this.SuccessLabel.AutoSize = true;
            this.SuccessLabel.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SuccessLabel.ForeColor = System.Drawing.Color.White;
            this.SuccessLabel.Location = new System.Drawing.Point(21, 6);
            this.SuccessLabel.Name = "SuccessLabel";
            this.SuccessLabel.Size = new System.Drawing.Size(78, 21);
            this.SuccessLabel.TabIndex = 0;
            this.SuccessLabel.Text = "Success: ";
            // 
            // MainPanel
            // 
            this.MainPanel.Controls.Add(this.ContentPanel);
            this.MainPanel.Controls.Add(this.ButtonPanel);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(0, 32);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(1250, 720);
            this.MainPanel.TabIndex = 2;
            // 
            // ContentPanel
            // 
            this.ContentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ContentPanel.Location = new System.Drawing.Point(170, 0);
            this.ContentPanel.Name = "ContentPanel";
            this.ContentPanel.Size = new System.Drawing.Size(1080, 720);
            this.ContentPanel.TabIndex = 1;
            // 
            // ButtonPanel
            // 
            this.ButtonPanel.Controls.Add(this.WebProxyButton);
            this.ButtonPanel.Controls.Add(this.CaptchaButton);
            this.ButtonPanel.Controls.Add(this.ProxyButton);
            this.ButtonPanel.Controls.Add(this.CreateAccountButton);
            this.ButtonPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.ButtonPanel.Location = new System.Drawing.Point(0, 0);
            this.ButtonPanel.Name = "ButtonPanel";
            this.ButtonPanel.Size = new System.Drawing.Size(170, 720);
            this.ButtonPanel.TabIndex = 0;
            // 
            // WebProxyButton
            // 
            this.WebProxyButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.WebProxyButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.WebProxyButton.Location = new System.Drawing.Point(0, 94);
            this.WebProxyButton.Name = "WebProxyButton";
            this.WebProxyButton.Size = new System.Drawing.Size(170, 38);
            this.WebProxyButton.TabIndex = 3;
            this.WebProxyButton.Text = "Web Proxy";
            this.WebProxyButton.UseVisualStyleBackColor = true;
            this.WebProxyButton.Click += new System.EventHandler(this.WebProxyButton_Click);
            // 
            // CaptchaButton
            // 
            this.CaptchaButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CaptchaButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CaptchaButton.Location = new System.Drawing.Point(0, 138);
            this.CaptchaButton.Name = "CaptchaButton";
            this.CaptchaButton.Size = new System.Drawing.Size(170, 38);
            this.CaptchaButton.TabIndex = 2;
            this.CaptchaButton.Text = "Captcha Settings";
            this.CaptchaButton.UseVisualStyleBackColor = true;
            this.CaptchaButton.Click += new System.EventHandler(this.CaptchaButton_Click);
            // 
            // ProxyButton
            // 
            this.ProxyButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ProxyButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ProxyButton.Location = new System.Drawing.Point(0, 50);
            this.ProxyButton.Name = "ProxyButton";
            this.ProxyButton.Size = new System.Drawing.Size(170, 38);
            this.ProxyButton.TabIndex = 1;
            this.ProxyButton.Text = "Proxy Settings";
            this.ProxyButton.UseVisualStyleBackColor = true;
            this.ProxyButton.Click += new System.EventHandler(this.ProxyButton_Click);
            // 
            // CreateAccountButton
            // 
            this.CreateAccountButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CreateAccountButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CreateAccountButton.Location = new System.Drawing.Point(0, 6);
            this.CreateAccountButton.Name = "CreateAccountButton";
            this.CreateAccountButton.Size = new System.Drawing.Size(170, 38);
            this.CreateAccountButton.TabIndex = 0;
            this.CreateAccountButton.Text = "Create";
            this.CreateAccountButton.UseVisualStyleBackColor = true;
            this.CreateAccountButton.Click += new System.EventHandler(this.CreateAccountButton_Click);
            // 
            // StatusTimer
            // 
            this.StatusTimer.Enabled = true;
            this.StatusTimer.Interval = 1000;
            this.StatusTimer.Tick += new System.EventHandler(this.StatusTimer_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(1250, 784);
            this.Controls.Add(this.MainPanel);
            this.Controls.Add(this.StatusPanel);
            this.Controls.Add(this.WindowPanel);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PTC Creator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.WindowPanel.ResumeLayout(false);
            this.WindowPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.StatusPanel.ResumeLayout(false);
            this.StatusPanel.PerformLayout();
            this.MainPanel.ResumeLayout(false);
            this.ButtonPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel WindowPanel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.Button ClostButton;
        private System.Windows.Forms.Button MinimizeButton;
        private System.Windows.Forms.Button MaximizeButton;
        private System.Windows.Forms.Panel StatusPanel;
        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.Panel ContentPanel;
        private System.Windows.Forms.Panel ButtonPanel;
        private System.Windows.Forms.Button CaptchaButton;
        private System.Windows.Forms.Button ProxyButton;
        private System.Windows.Forms.Button CreateAccountButton;
        private System.Windows.Forms.Button WebProxyButton;
        private System.Windows.Forms.Label PendingLabel;
        private System.Windows.Forms.Label FailLabel;
        private System.Windows.Forms.Label SuccessLabel;
        private System.Windows.Forms.Label RateLabel;
        private System.Windows.Forms.Timer StatusTimer;
    }
}

