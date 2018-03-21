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
            this.testAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toggleAllUsableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cellMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addSingleToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.addMultipleToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toggleSelectedUsableToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toggleRotatingProxyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setThreadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setDelayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetStatsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testSelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.ContentPanel = new System.Windows.Forms.Panel();
            this.proxyOlv = new BrightIdeasSoftware.FastObjectListView();
            this.proxy = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.type = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.rotating = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.username = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.password = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.thread_amount = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.delay_sec = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.create_count = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.fail_count = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.usable = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.Log = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.gridMenu.SuspendLayout();
            this.cellMenu.SuspendLayout();
            this.ContentPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.proxyOlv)).BeginInit();
            this.SuspendLayout();
            // 
            // gridMenu
            // 
            this.gridMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addSingleToolStripMenuItem,
            this.addMultipleToolStripMenuItem,
            this.testAllToolStripMenuItem,
            this.toggleAllUsableToolStripMenuItem});
            this.gridMenu.Name = "gridMenu";
            this.gridMenu.Size = new System.Drawing.Size(166, 92);
            // 
            // addSingleToolStripMenuItem
            // 
            this.addSingleToolStripMenuItem.Name = "addSingleToolStripMenuItem";
            this.addSingleToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.addSingleToolStripMenuItem.Text = "Add Single";
            this.addSingleToolStripMenuItem.Click += new System.EventHandler(this.addSingleToolStripMenuItem_Click);
            // 
            // addMultipleToolStripMenuItem
            // 
            this.addMultipleToolStripMenuItem.Name = "addMultipleToolStripMenuItem";
            this.addMultipleToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.addMultipleToolStripMenuItem.Text = "Add Multiple";
            this.addMultipleToolStripMenuItem.Click += new System.EventHandler(this.addMultipleToolStripMenuItem_Click);
            // 
            // testAllToolStripMenuItem
            // 
            this.testAllToolStripMenuItem.Name = "testAllToolStripMenuItem";
            this.testAllToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.testAllToolStripMenuItem.Text = "Test All";
            this.testAllToolStripMenuItem.Click += new System.EventHandler(this.testAllToolStripMenuItem_Click);
            // 
            // toggleAllUsableToolStripMenuItem
            // 
            this.toggleAllUsableToolStripMenuItem.Name = "toggleAllUsableToolStripMenuItem";
            this.toggleAllUsableToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.toggleAllUsableToolStripMenuItem.Text = "Toggle All Usable";
            this.toggleAllUsableToolStripMenuItem.Click += new System.EventHandler(this.toggleAllUsableToolStripMenuItem_Click);
            // 
            // cellMenu
            // 
            this.cellMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addSingleToolStripMenuItem1,
            this.addMultipleToolStripMenuItem1,
            this.settingsToolStripMenuItem,
            this.testSelectedToolStripMenuItem});
            this.cellMenu.Name = "cellMenu";
            this.cellMenu.Size = new System.Drawing.Size(144, 92);
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
            this.toggleSelectedUsableToolStripMenuItem1,
            this.toggleRotatingProxyToolStripMenuItem,
            this.setThreadToolStripMenuItem,
            this.setDelayToolStripMenuItem,
            this.resetStatsToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // toggleSelectedUsableToolStripMenuItem1
            // 
            this.toggleSelectedUsableToolStripMenuItem1.Name = "toggleSelectedUsableToolStripMenuItem1";
            this.toggleSelectedUsableToolStripMenuItem1.Size = new System.Drawing.Size(195, 22);
            this.toggleSelectedUsableToolStripMenuItem1.Text = "Toggle Selected Usable";
            this.toggleSelectedUsableToolStripMenuItem1.Click += new System.EventHandler(this.toggleSelectedUsableToolStripMenuItem_Click);
            // 
            // toggleRotatingProxyToolStripMenuItem
            // 
            this.toggleRotatingProxyToolStripMenuItem.Name = "toggleRotatingProxyToolStripMenuItem";
            this.toggleRotatingProxyToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.toggleRotatingProxyToolStripMenuItem.Text = "Toggle Rotating Proxy";
            this.toggleRotatingProxyToolStripMenuItem.Click += new System.EventHandler(this.toggleRotatingProxyToolStripMenuItem_Click);
            // 
            // setThreadToolStripMenuItem
            // 
            this.setThreadToolStripMenuItem.Name = "setThreadToolStripMenuItem";
            this.setThreadToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.setThreadToolStripMenuItem.Text = "Set Thread";
            this.setThreadToolStripMenuItem.Click += new System.EventHandler(this.setThreadToolStripMenuItem_Click);
            // 
            // setDelayToolStripMenuItem
            // 
            this.setDelayToolStripMenuItem.Name = "setDelayToolStripMenuItem";
            this.setDelayToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.setDelayToolStripMenuItem.Text = "Set Delay";
            this.setDelayToolStripMenuItem.Click += new System.EventHandler(this.setDelayToolStripMenuItem_Click);
            // 
            // resetStatsToolStripMenuItem
            // 
            this.resetStatsToolStripMenuItem.Name = "resetStatsToolStripMenuItem";
            this.resetStatsToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.resetStatsToolStripMenuItem.Text = "Reset Stats";
            this.resetStatsToolStripMenuItem.Click += new System.EventHandler(this.resetStatsToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // testSelectedToolStripMenuItem
            // 
            this.testSelectedToolStripMenuItem.Name = "testSelectedToolStripMenuItem";
            this.testSelectedToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.testSelectedToolStripMenuItem.Text = "Test Selected";
            this.testSelectedToolStripMenuItem.Click += new System.EventHandler(this.testSelectedToolStripMenuItem_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // ContentPanel
            // 
            this.ContentPanel.Controls.Add(this.proxyOlv);
            this.ContentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ContentPanel.Location = new System.Drawing.Point(0, 0);
            this.ContentPanel.Name = "ContentPanel";
            this.ContentPanel.Size = new System.Drawing.Size(1080, 720);
            this.ContentPanel.TabIndex = 3;
            // 
            // proxyOlv
            // 
            this.proxyOlv.AllColumns.Add(this.proxy);
            this.proxyOlv.AllColumns.Add(this.type);
            this.proxyOlv.AllColumns.Add(this.rotating);
            this.proxyOlv.AllColumns.Add(this.username);
            this.proxyOlv.AllColumns.Add(this.password);
            this.proxyOlv.AllColumns.Add(this.thread_amount);
            this.proxyOlv.AllColumns.Add(this.delay_sec);
            this.proxyOlv.AllColumns.Add(this.create_count);
            this.proxyOlv.AllColumns.Add(this.fail_count);
            this.proxyOlv.AllColumns.Add(this.usable);
            this.proxyOlv.AllColumns.Add(this.Log);
            this.proxyOlv.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.proxyOlv.CellEditUseWholeCell = false;
            this.proxyOlv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.proxy,
            this.type,
            this.rotating,
            this.username,
            this.password,
            this.thread_amount,
            this.delay_sec,
            this.create_count,
            this.fail_count,
            this.usable,
            this.Log});
            this.proxyOlv.Cursor = System.Windows.Forms.Cursors.Default;
            this.proxyOlv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.proxyOlv.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.proxyOlv.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.proxyOlv.FullRowSelect = true;
            this.proxyOlv.Location = new System.Drawing.Point(0, 0);
            this.proxyOlv.Name = "proxyOlv";
            this.proxyOlv.ShowGroups = false;
            this.proxyOlv.Size = new System.Drawing.Size(1080, 720);
            this.proxyOlv.TabIndex = 3;
            this.proxyOlv.UseCellFormatEvents = true;
            this.proxyOlv.UseCompatibleStateImageBehavior = false;
            this.proxyOlv.View = System.Windows.Forms.View.Details;
            this.proxyOlv.VirtualMode = true;
            this.proxyOlv.CellRightClick += new System.EventHandler<BrightIdeasSoftware.CellRightClickEventArgs>(this.proxyOlv_CellRightClick);
            this.proxyOlv.FormatCell += new System.EventHandler<BrightIdeasSoftware.FormatCellEventArgs>(this.proxyOlv_FormatCell);
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
            // rotating
            // 
            this.rotating.AspectName = "rotating";
            this.rotating.Text = "Rotating";
            this.rotating.Width = 77;
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
            // Log
            // 
            this.Log.AspectName = "test_log";
            this.Log.Text = "Log";
            this.Log.Width = 192;
            // 
            // ProxyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1080, 720);
            this.Controls.Add(this.ContentPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ProxyForm";
            this.Text = "ProxyForm";
            this.Load += new System.EventHandler(this.ProxyForm_Load);
            this.gridMenu.ResumeLayout(false);
            this.cellMenu.ResumeLayout(false);
            this.ContentPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.proxyOlv)).EndInit();
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
        private System.Windows.Forms.Panel ContentPanel;
        private System.Windows.Forms.ToolStripMenuItem toggleRotatingProxyToolStripMenuItem;
        private BrightIdeasSoftware.OLVColumn proxy;
        private BrightIdeasSoftware.OLVColumn type;
        private BrightIdeasSoftware.OLVColumn rotating;
        private BrightIdeasSoftware.OLVColumn username;
        private BrightIdeasSoftware.OLVColumn password;
        private BrightIdeasSoftware.OLVColumn thread_amount;
        private BrightIdeasSoftware.OLVColumn delay_sec;
        private BrightIdeasSoftware.OLVColumn create_count;
        private BrightIdeasSoftware.OLVColumn fail_count;
        private BrightIdeasSoftware.OLVColumn usable;
        private System.Windows.Forms.ToolStripMenuItem testAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testSelectedToolStripMenuItem;
        private BrightIdeasSoftware.OLVColumn Log;
        private System.Windows.Forms.ToolStripMenuItem toggleAllUsableToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toggleSelectedUsableToolStripMenuItem1;
        private BrightIdeasSoftware.FastObjectListView proxyOlv;
    }
}