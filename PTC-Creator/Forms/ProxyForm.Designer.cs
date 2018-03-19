namespace PTC_Creator.Forms
{
    partial class ProxyForm
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
            this.gridMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addSingleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addMultipleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cellMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addSingleToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.addMultipleToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setThreadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setDelayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetStatsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.WebProxyPanel = new System.Windows.Forms.Panel();
            this.ContentPanel = new System.Windows.Forms.Panel();
            this.proxyOlv = new BrightIdeasSoftware.FastObjectListView();
            this.proxy = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.type = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.username = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.password = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.thread_amount = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.delay_sec = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.create_count = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.fail_count = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.usable = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.AddPanel = new System.Windows.Forms.Panel();
            this.AddButton = new System.Windows.Forms.Button();
            this.TestPanel = new System.Windows.Forms.Panel();
            this.TestButton = new System.Windows.Forms.Button();
            this.InfoPanel = new System.Windows.Forms.Panel();
            this.ProxyUrlTextBox = new System.Windows.Forms.TextBox();
            this.ProxyTypePanel = new System.Windows.Forms.Panel();
            this.ProxyTypeComboBox = new System.Windows.Forms.ComboBox();
            this.gridMenu.SuspendLayout();
            this.cellMenu.SuspendLayout();
            this.WebProxyPanel.SuspendLayout();
            this.ContentPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.proxyOlv)).BeginInit();
            this.AddPanel.SuspendLayout();
            this.TestPanel.SuspendLayout();
            this.InfoPanel.SuspendLayout();
            this.ProxyTypePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridMenu
            // 
            this.gridMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addSingleToolStripMenuItem,
            this.addMultipleToolStripMenuItem});
            this.gridMenu.Name = "gridMenu";
            this.gridMenu.Size = new System.Drawing.Size(144, 48);
            // 
            // addSingleToolStripMenuItem
            // 
            this.addSingleToolStripMenuItem.Name = "addSingleToolStripMenuItem";
            this.addSingleToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.addSingleToolStripMenuItem.Text = "Add Single";
            this.addSingleToolStripMenuItem.Click += new System.EventHandler(this.addSingleToolStripMenuItem_Click);
            // 
            // addMultipleToolStripMenuItem
            // 
            this.addMultipleToolStripMenuItem.Name = "addMultipleToolStripMenuItem";
            this.addMultipleToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.addMultipleToolStripMenuItem.Text = "Add Multiple";
            this.addMultipleToolStripMenuItem.Click += new System.EventHandler(this.addMultipleToolStripMenuItem_Click);
            // 
            // cellMenu
            // 
            this.cellMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addSingleToolStripMenuItem1,
            this.addMultipleToolStripMenuItem1,
            this.settingsToolStripMenuItem});
            this.cellMenu.Name = "cellMenu";
            this.cellMenu.Size = new System.Drawing.Size(144, 70);
            // 
            // addSingleToolStripMenuItem1
            // 
            this.addSingleToolStripMenuItem1.Name = "addSingleToolStripMenuItem1";
            this.addSingleToolStripMenuItem1.Size = new System.Drawing.Size(143, 22);
            this.addSingleToolStripMenuItem1.Text = "Add Single";
            this.addSingleToolStripMenuItem1.Click += new System.EventHandler(this.addSingleToolStripMenuItem_Click);
            // 
            // addMultipleToolStripMenuItem1
            // 
            this.addMultipleToolStripMenuItem1.Name = "addMultipleToolStripMenuItem1";
            this.addMultipleToolStripMenuItem1.Size = new System.Drawing.Size(143, 22);
            this.addMultipleToolStripMenuItem1.Text = "Add Multiple";
            this.addMultipleToolStripMenuItem1.Click += new System.EventHandler(this.addMultipleToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setThreadToolStripMenuItem,
            this.setDelayToolStripMenuItem,
            this.resetStatsToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // setThreadToolStripMenuItem
            // 
            this.setThreadToolStripMenuItem.Name = "setThreadToolStripMenuItem";
            this.setThreadToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.setThreadToolStripMenuItem.Text = "Set Thread";
            this.setThreadToolStripMenuItem.Click += new System.EventHandler(this.setThreadToolStripMenuItem_Click);
            // 
            // setDelayToolStripMenuItem
            // 
            this.setDelayToolStripMenuItem.Name = "setDelayToolStripMenuItem";
            this.setDelayToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.setDelayToolStripMenuItem.Text = "Set Delay";
            this.setDelayToolStripMenuItem.Click += new System.EventHandler(this.setDelayToolStripMenuItem_Click);
            // 
            // resetStatsToolStripMenuItem
            // 
            this.resetStatsToolStripMenuItem.Name = "resetStatsToolStripMenuItem";
            this.resetStatsToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.resetStatsToolStripMenuItem.Text = "Reset Stats";
            this.resetStatsToolStripMenuItem.Click += new System.EventHandler(this.resetStatsToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // WebProxyPanel
            // 
            this.WebProxyPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.WebProxyPanel.Controls.Add(this.InfoPanel);
            this.WebProxyPanel.Controls.Add(this.TestPanel);
            this.WebProxyPanel.Controls.Add(this.AddPanel);
            this.WebProxyPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.WebProxyPanel.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WebProxyPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.WebProxyPanel.Location = new System.Drawing.Point(0, 691);
            this.WebProxyPanel.Name = "WebProxyPanel";
            this.WebProxyPanel.Size = new System.Drawing.Size(1080, 29);
            this.WebProxyPanel.TabIndex = 2;
            // 
            // ContentPanel
            // 
            this.ContentPanel.Controls.Add(this.proxyOlv);
            this.ContentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ContentPanel.Location = new System.Drawing.Point(0, 0);
            this.ContentPanel.Name = "ContentPanel";
            this.ContentPanel.Size = new System.Drawing.Size(1080, 691);
            this.ContentPanel.TabIndex = 3;
            // 
            // proxyOlv
            // 
            this.proxyOlv.AllColumns.Add(this.proxy);
            this.proxyOlv.AllColumns.Add(this.type);
            this.proxyOlv.AllColumns.Add(this.username);
            this.proxyOlv.AllColumns.Add(this.password);
            this.proxyOlv.AllColumns.Add(this.thread_amount);
            this.proxyOlv.AllColumns.Add(this.delay_sec);
            this.proxyOlv.AllColumns.Add(this.create_count);
            this.proxyOlv.AllColumns.Add(this.fail_count);
            this.proxyOlv.AllColumns.Add(this.usable);
            this.proxyOlv.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.proxyOlv.CellEditUseWholeCell = false;
            this.proxyOlv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.proxy,
            this.type,
            this.username,
            this.password,
            this.thread_amount,
            this.delay_sec,
            this.create_count,
            this.fail_count,
            this.usable});
            this.proxyOlv.Cursor = System.Windows.Forms.Cursors.Default;
            this.proxyOlv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.proxyOlv.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.proxyOlv.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.proxyOlv.FullRowSelect = true;
            this.proxyOlv.Location = new System.Drawing.Point(0, 0);
            this.proxyOlv.Name = "proxyOlv";
            this.proxyOlv.ShowGroups = false;
            this.proxyOlv.Size = new System.Drawing.Size(1080, 691);
            this.proxyOlv.TabIndex = 1;
            this.proxyOlv.UseCompatibleStateImageBehavior = false;
            this.proxyOlv.View = System.Windows.Forms.View.Details;
            this.proxyOlv.VirtualMode = true;
            // 
            // proxy
            // 
            this.proxy.AspectName = "proxy";
            this.proxy.Text = "Proxy";
            this.proxy.Width = 84;
            // 
            // type
            // 
            this.type.AspectName = "type";
            this.type.Text = "Type";
            // 
            // username
            // 
            this.username.AspectName = "username";
            this.username.Text = "Username";
            this.username.Width = 85;
            // 
            // password
            // 
            this.password.AspectName = "password";
            this.password.Text = "Password";
            this.password.Width = 75;
            // 
            // thread_amount
            // 
            this.thread_amount.AspectName = "thread_amount";
            this.thread_amount.Text = "Thread Amount";
            this.thread_amount.Width = 116;
            // 
            // delay_sec
            // 
            this.delay_sec.AspectName = "delay_sec";
            this.delay_sec.Text = "Delay(Sec)";
            this.delay_sec.Width = 84;
            // 
            // create_count
            // 
            this.create_count.AspectName = "create_count";
            this.create_count.Text = "Create Amount";
            this.create_count.Width = 123;
            // 
            // fail_count
            // 
            this.fail_count.AspectName = "fail_count";
            this.fail_count.Text = "Fail Count";
            this.fail_count.Width = 80;
            // 
            // usable
            // 
            this.usable.AspectName = "usable";
            this.usable.Text = "Usable";
            // 
            // AddPanel
            // 
            this.AddPanel.Controls.Add(this.AddButton);
            this.AddPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.AddPanel.Location = new System.Drawing.Point(930, 0);
            this.AddPanel.Name = "AddPanel";
            this.AddPanel.Size = new System.Drawing.Size(150, 29);
            this.AddPanel.TabIndex = 0;
            // 
            // AddButton
            // 
            this.AddButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AddButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddButton.Location = new System.Drawing.Point(0, 0);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(150, 29);
            this.AddButton.TabIndex = 0;
            this.AddButton.Text = "Add";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // TestPanel
            // 
            this.TestPanel.Controls.Add(this.TestButton);
            this.TestPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.TestPanel.Location = new System.Drawing.Point(0, 0);
            this.TestPanel.Name = "TestPanel";
            this.TestPanel.Size = new System.Drawing.Size(150, 29);
            this.TestPanel.TabIndex = 1;
            // 
            // TestButton
            // 
            this.TestButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TestButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TestButton.Location = new System.Drawing.Point(0, 0);
            this.TestButton.Name = "TestButton";
            this.TestButton.Size = new System.Drawing.Size(150, 29);
            this.TestButton.TabIndex = 0;
            this.TestButton.Text = "Test";
            this.TestButton.UseVisualStyleBackColor = true;
            this.TestButton.Click += new System.EventHandler(this.TestButton_Click);
            // 
            // InfoPanel
            // 
            this.InfoPanel.Controls.Add(this.ProxyUrlTextBox);
            this.InfoPanel.Controls.Add(this.ProxyTypePanel);
            this.InfoPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InfoPanel.Location = new System.Drawing.Point(150, 0);
            this.InfoPanel.Name = "InfoPanel";
            this.InfoPanel.Size = new System.Drawing.Size(780, 29);
            this.InfoPanel.TabIndex = 2;
            // 
            // ProxyUrlTextBox
            // 
            this.ProxyUrlTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProxyUrlTextBox.Location = new System.Drawing.Point(200, 0);
            this.ProxyUrlTextBox.Name = "ProxyUrlTextBox";
            this.ProxyUrlTextBox.Size = new System.Drawing.Size(580, 27);
            this.ProxyUrlTextBox.TabIndex = 1;
            // 
            // ProxyTypePanel
            // 
            this.ProxyTypePanel.Controls.Add(this.ProxyTypeComboBox);
            this.ProxyTypePanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.ProxyTypePanel.Location = new System.Drawing.Point(0, 0);
            this.ProxyTypePanel.Name = "ProxyTypePanel";
            this.ProxyTypePanel.Size = new System.Drawing.Size(200, 29);
            this.ProxyTypePanel.TabIndex = 0;
            // 
            // ProxyTypeComboBox
            // 
            this.ProxyTypeComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProxyTypeComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ProxyTypeComboBox.FormattingEnabled = true;
            this.ProxyTypeComboBox.Location = new System.Drawing.Point(0, 0);
            this.ProxyTypeComboBox.Name = "ProxyTypeComboBox";
            this.ProxyTypeComboBox.Size = new System.Drawing.Size(200, 29);
            this.ProxyTypeComboBox.TabIndex = 0;
            // 
            // ProxyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1080, 720);
            this.Controls.Add(this.ContentPanel);
            this.Controls.Add(this.WebProxyPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ProxyForm";
            this.Text = "ProxyForm";
            this.Load += new System.EventHandler(this.ProxyForm_Load);
            this.gridMenu.ResumeLayout(false);
            this.cellMenu.ResumeLayout(false);
            this.WebProxyPanel.ResumeLayout(false);
            this.ContentPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.proxyOlv)).EndInit();
            this.AddPanel.ResumeLayout(false);
            this.TestPanel.ResumeLayout(false);
            this.InfoPanel.ResumeLayout(false);
            this.InfoPanel.PerformLayout();
            this.ProxyTypePanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip gridMenu;
        private System.Windows.Forms.ToolStripMenuItem addSingleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addMultipleToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip cellMenu;
        private System.Windows.Forms.ToolStripMenuItem addSingleToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem addMultipleToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setThreadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setDelayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetStatsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Panel WebProxyPanel;
        private System.Windows.Forms.Panel ContentPanel;
        internal BrightIdeasSoftware.FastObjectListView proxyOlv;
        private BrightIdeasSoftware.OLVColumn proxy;
        private BrightIdeasSoftware.OLVColumn type;
        private BrightIdeasSoftware.OLVColumn username;
        private BrightIdeasSoftware.OLVColumn password;
        private BrightIdeasSoftware.OLVColumn thread_amount;
        private BrightIdeasSoftware.OLVColumn delay_sec;
        private BrightIdeasSoftware.OLVColumn create_count;
        private BrightIdeasSoftware.OLVColumn fail_count;
        private BrightIdeasSoftware.OLVColumn usable;
        private System.Windows.Forms.Panel AddPanel;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Panel InfoPanel;
        private System.Windows.Forms.Panel TestPanel;
        private System.Windows.Forms.Button TestButton;
        private System.Windows.Forms.TextBox ProxyUrlTextBox;
        private System.Windows.Forms.Panel ProxyTypePanel;
        private System.Windows.Forms.ComboBox ProxyTypeComboBox;
    }
}