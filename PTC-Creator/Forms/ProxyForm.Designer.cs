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
            this.last_used_time = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.inUse = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
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
            ((System.ComponentModel.ISupportInitialize)(this.proxyOlv)).BeginInit();
            this.gridMenu.SuspendLayout();
            this.cellMenu.SuspendLayout();
            this.SuspendLayout();
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
            this.proxyOlv.AllColumns.Add(this.last_used_time);
            this.proxyOlv.AllColumns.Add(this.inUse);
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
            this.usable,
            this.last_used_time,
            this.inUse});
            this.proxyOlv.Cursor = System.Windows.Forms.Cursors.Default;
            this.proxyOlv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.proxyOlv.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.proxyOlv.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
            this.proxyOlv.FullRowSelect = true;
            this.proxyOlv.Location = new System.Drawing.Point(0, 0);
            this.proxyOlv.Name = "proxyOlv";
            this.proxyOlv.ShowGroups = false;
            this.proxyOlv.Size = new System.Drawing.Size(1169, 576);
            this.proxyOlv.TabIndex = 0;
            this.proxyOlv.UseCompatibleStateImageBehavior = false;
            this.proxyOlv.View = System.Windows.Forms.View.Details;
            this.proxyOlv.VirtualMode = true;
            this.proxyOlv.CellRightClick += new System.EventHandler<BrightIdeasSoftware.CellRightClickEventArgs>(this.proxyOlv_CellRightClick);
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
            // last_used_time
            // 
            this.last_used_time.AspectName = "last_used_time";
            this.last_used_time.Text = "Last Used Time";
            this.last_used_time.Width = 144;
            // 
            // inUse
            // 
            this.inUse.AspectName = "inUse";
            this.inUse.Text = "In Use";
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
            this.cellMenu.Size = new System.Drawing.Size(181, 92);
            // 
            // addSingleToolStripMenuItem1
            // 
            this.addSingleToolStripMenuItem1.Name = "addSingleToolStripMenuItem1";
            this.addSingleToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.addSingleToolStripMenuItem1.Text = "Add Single";
            this.addSingleToolStripMenuItem1.Click += new System.EventHandler(this.addSingleToolStripMenuItem_Click);
            // 
            // addMultipleToolStripMenuItem1
            // 
            this.addMultipleToolStripMenuItem1.Name = "addMultipleToolStripMenuItem1";
            this.addMultipleToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
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
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // setThreadToolStripMenuItem
            // 
            this.setThreadToolStripMenuItem.Name = "setThreadToolStripMenuItem";
            this.setThreadToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.setThreadToolStripMenuItem.Text = "Set Thread";
            this.setThreadToolStripMenuItem.Click += new System.EventHandler(this.setThreadToolStripMenuItem_Click);
            // 
            // setDelayToolStripMenuItem
            // 
            this.setDelayToolStripMenuItem.Name = "setDelayToolStripMenuItem";
            this.setDelayToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.setDelayToolStripMenuItem.Text = "Set Delay";
            this.setDelayToolStripMenuItem.Click += new System.EventHandler(this.setDelayToolStripMenuItem_Click);
            // 
            // resetStatsToolStripMenuItem
            // 
            this.resetStatsToolStripMenuItem.Name = "resetStatsToolStripMenuItem";
            this.resetStatsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.resetStatsToolStripMenuItem.Text = "Reset Stats";
            this.resetStatsToolStripMenuItem.Click += new System.EventHandler(this.resetStatsToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // ProxyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1169, 576);
            this.Controls.Add(this.proxyOlv);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ProxyForm";
            this.Text = "ProxyForm";
            this.Load += new System.EventHandler(this.ProxyForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.proxyOlv)).EndInit();
            this.gridMenu.ResumeLayout(false);
            this.cellMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private BrightIdeasSoftware.OLVColumn proxy;
        private BrightIdeasSoftware.OLVColumn type;
        private BrightIdeasSoftware.OLVColumn username;
        private BrightIdeasSoftware.OLVColumn password;
        private BrightIdeasSoftware.OLVColumn thread_amount;
        private BrightIdeasSoftware.OLVColumn delay_sec;
        private BrightIdeasSoftware.OLVColumn create_count;
        private BrightIdeasSoftware.OLVColumn fail_count;
        private BrightIdeasSoftware.OLVColumn usable;
        private BrightIdeasSoftware.OLVColumn last_used_time;
        private BrightIdeasSoftware.OLVColumn inUse;
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
        internal BrightIdeasSoftware.FastObjectListView proxyOlv;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}