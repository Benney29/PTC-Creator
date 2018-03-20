namespace PTC_Creator.Forms
{
    partial class WebProxyForm
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
            this.ContentPanel = new System.Windows.Forms.Panel();
            this.WebProxyOlv = new BrightIdeasSoftware.FastObjectListView();
            this.url = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.type = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.total = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.amount = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.last_check_date = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.gridMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cellMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ContentPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WebProxyOlv)).BeginInit();
            this.gridMenu.SuspendLayout();
            this.cellMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // ContentPanel
            // 
            this.ContentPanel.Controls.Add(this.WebProxyOlv);
            this.ContentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ContentPanel.Location = new System.Drawing.Point(0, 0);
            this.ContentPanel.Name = "ContentPanel";
            this.ContentPanel.Size = new System.Drawing.Size(1064, 681);
            this.ContentPanel.TabIndex = 2;
            // 
            // WebProxyOlv
            // 
            this.WebProxyOlv.AllColumns.Add(this.url);
            this.WebProxyOlv.AllColumns.Add(this.type);
            this.WebProxyOlv.AllColumns.Add(this.total);
            this.WebProxyOlv.AllColumns.Add(this.amount);
            this.WebProxyOlv.AllColumns.Add(this.last_check_date);
            this.WebProxyOlv.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.WebProxyOlv.CellEditUseWholeCell = false;
            this.WebProxyOlv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.url,
            this.type,
            this.total,
            this.amount,
            this.last_check_date});
            this.WebProxyOlv.Cursor = System.Windows.Forms.Cursors.Default;
            this.WebProxyOlv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WebProxyOlv.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.WebProxyOlv.Location = new System.Drawing.Point(0, 0);
            this.WebProxyOlv.Name = "WebProxyOlv";
            this.WebProxyOlv.ShowGroups = false;
            this.WebProxyOlv.Size = new System.Drawing.Size(1064, 681);
            this.WebProxyOlv.TabIndex = 0;
            this.WebProxyOlv.UseCompatibleStateImageBehavior = false;
            this.WebProxyOlv.View = System.Windows.Forms.View.Details;
            this.WebProxyOlv.VirtualMode = true;
            this.WebProxyOlv.CellRightClick += new System.EventHandler<BrightIdeasSoftware.CellRightClickEventArgs>(this.WebProxyOlv_CellRightClick);
            // 
            // url
            // 
            this.url.AspectName = "url";
            this.url.Text = "API Url";
            this.url.Width = 507;
            // 
            // type
            // 
            this.type.AspectName = "type";
            this.type.Text = "Proxy Type";
            this.type.Width = 98;
            // 
            // total
            // 
            this.total.AspectName = "total";
            this.total.Text = "Total Get";
            this.total.Width = 101;
            // 
            // amount
            // 
            this.amount.AspectName = "amount";
            this.amount.Text = "Lastest Get";
            this.amount.Width = 104;
            // 
            // last_check_date
            // 
            this.last_check_date.AspectName = "last_check_date";
            this.last_check_date.Text = "Last Time Check";
            this.last_check_date.Width = 143;
            // 
            // gridMenu
            // 
            this.gridMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem});
            this.gridMenu.Name = "gridMenu";
            this.gridMenu.Size = new System.Drawing.Size(97, 26);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(96, 22);
            this.addToolStripMenuItem.Text = "Add";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.addToolStripMenuItem1_Click);
            // 
            // cellMenu
            // 
            this.cellMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem1,
            this.deleteToolStripMenuItem});
            this.cellMenu.Name = "cellMenu";
            this.cellMenu.Size = new System.Drawing.Size(108, 48);
            // 
            // addToolStripMenuItem1
            // 
            this.addToolStripMenuItem1.Name = "addToolStripMenuItem1";
            this.addToolStripMenuItem1.Size = new System.Drawing.Size(107, 22);
            this.addToolStripMenuItem1.Text = "Add";
            this.addToolStripMenuItem1.Click += new System.EventHandler(this.addToolStripMenuItem1_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // WebProxyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(1064, 681);
            this.Controls.Add(this.ContentPanel);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "WebProxyForm";
            this.Text = "WebProxyForm";
            this.Load += new System.EventHandler(this.WebProxyForm_Load);
            this.ContentPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.WebProxyOlv)).EndInit();
            this.gridMenu.ResumeLayout(false);
            this.cellMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel ContentPanel;
        private BrightIdeasSoftware.OLVColumn url;
        private BrightIdeasSoftware.OLVColumn type;
        private BrightIdeasSoftware.OLVColumn total;
        private BrightIdeasSoftware.OLVColumn amount;
        private BrightIdeasSoftware.OLVColumn last_check_date;
        private System.Windows.Forms.ContextMenuStrip gridMenu;
        private System.Windows.Forms.ContextMenuStrip cellMenu;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        internal BrightIdeasSoftware.FastObjectListView WebProxyOlv;
    }
}