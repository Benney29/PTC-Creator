namespace PTC_Creator.Forms
{
    partial class LogForm
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
            this.WindowPanel = new System.Windows.Forms.Panel();
            this.ClostButton = new System.Windows.Forms.Button();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ContentPanel = new System.Windows.Forms.Panel();
            this.LogOlv = new BrightIdeasSoftware.FastObjectListView();
            this.time = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.message = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.WindowPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.ContentPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LogOlv)).BeginInit();
            this.SuspendLayout();
            // 
            // WindowPanel
            // 
            this.WindowPanel.BackColor = System.Drawing.Color.White;
            this.WindowPanel.Controls.Add(this.ClostButton);
            this.WindowPanel.Controls.Add(this.TitleLabel);
            this.WindowPanel.Controls.Add(this.pictureBox1);
            this.WindowPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.WindowPanel.ForeColor = System.Drawing.Color.Black;
            this.WindowPanel.Location = new System.Drawing.Point(0, 0);
            this.WindowPanel.Name = "WindowPanel";
            this.WindowPanel.Size = new System.Drawing.Size(919, 32);
            this.WindowPanel.TabIndex = 1;
            this.WindowPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.WindowPanel_MouseDown);
            this.WindowPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.WindowPanel_MouseMove);
            this.WindowPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.WindowPanel_MouseUp);
            // 
            // ClostButton
            // 
            this.ClostButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.ClostButton.FlatAppearance.BorderSize = 0;
            this.ClostButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ClostButton.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClostButton.Location = new System.Drawing.Point(887, 0);
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
            this.TitleLabel.Size = new System.Drawing.Size(0, 21);
            this.TitleLabel.TabIndex = 1;
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
            // ContentPanel
            // 
            this.ContentPanel.Controls.Add(this.LogOlv);
            this.ContentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ContentPanel.Location = new System.Drawing.Point(0, 32);
            this.ContentPanel.Name = "ContentPanel";
            this.ContentPanel.Size = new System.Drawing.Size(919, 403);
            this.ContentPanel.TabIndex = 2;
            // 
            // LogOlv
            // 
            this.LogOlv.AllColumns.Add(this.time);
            this.LogOlv.AllColumns.Add(this.message);
            this.LogOlv.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.LogOlv.CellEditUseWholeCell = false;
            this.LogOlv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.time,
            this.message});
            this.LogOlv.Cursor = System.Windows.Forms.Cursors.Default;
            this.LogOlv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LogOlv.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.LogOlv.FullRowSelect = true;
            this.LogOlv.GridLines = true;
            this.LogOlv.Location = new System.Drawing.Point(0, 0);
            this.LogOlv.Name = "LogOlv";
            this.LogOlv.ShowGroups = false;
            this.LogOlv.Size = new System.Drawing.Size(919, 403);
            this.LogOlv.TabIndex = 0;
            this.LogOlv.UseCellFormatEvents = true;
            this.LogOlv.UseCompatibleStateImageBehavior = false;
            this.LogOlv.View = System.Windows.Forms.View.Details;
            this.LogOlv.VirtualMode = true;
            this.LogOlv.FormatCell += new System.EventHandler<BrightIdeasSoftware.FormatCellEventArgs>(this.LogOlv_FormatCell);
            // 
            // time
            // 
            this.time.AspectName = "time";
            this.time.AspectToStringFormat = "";
            this.time.Text = "Time";
            this.time.Width = 302;
            // 
            // message
            // 
            this.message.AspectName = "message";
            this.message.Text = "Message";
            this.message.Width = 609;
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // LogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(919, 435);
            this.Controls.Add(this.ContentPanel);
            this.Controls.Add(this.WindowPanel);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "LogForm";
            this.Text = "LogForm";
            this.Load += new System.EventHandler(this.LogForm_Load);
            this.WindowPanel.ResumeLayout(false);
            this.WindowPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ContentPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LogOlv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel WindowPanel;
        private System.Windows.Forms.Button ClostButton;
        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel ContentPanel;
        private BrightIdeasSoftware.FastObjectListView LogOlv;
        private BrightIdeasSoftware.OLVColumn time;
        private BrightIdeasSoftware.OLVColumn message;
        private System.Windows.Forms.Timer timer;
    }
}