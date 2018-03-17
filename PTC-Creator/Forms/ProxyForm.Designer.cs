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
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cellMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setThreadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setDelayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetStatsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DataGrid = new System.Windows.Forms.DataGridView();
            this.gridMenu.SuspendLayout();
            this.cellMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // gridMenu
            // 
            this.gridMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addSingleToolStripMenuItem,
            this.addMultipleToolStripMenuItem,
            this.selectAllToolStripMenuItem});
            this.gridMenu.Name = "gridMenu";
            this.gridMenu.Size = new System.Drawing.Size(144, 70);
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
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.selectAllToolStripMenuItem.Text = "Select All";
            this.selectAllToolStripMenuItem.Click += new System.EventHandler(this.selectAllToolStripeMenuItem_Click);
            // 
            // cellMenu
            // 
            this.cellMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.settingsToolStripMenuItem});
            this.cellMenu.Name = "gridMenu";
            this.cellMenu.Size = new System.Drawing.Size(144, 92);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(143, 22);
            this.toolStripMenuItem1.Text = "Add Single";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(143, 22);
            this.toolStripMenuItem2.Text = "Add Multiple";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(143, 22);
            this.toolStripMenuItem3.Text = "Select All";
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
            this.resetStatsToolStripMenuItem.Click += new System.EventHandler(this.resetToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // DataGrid
            // 
            this.DataGrid.AllowUserToAddRows = false;
            this.DataGrid.AllowUserToDeleteRows = false;
            this.DataGrid.AllowUserToOrderColumns = true;
            this.DataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DataGrid.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.DataGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.DataGrid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
            this.DataGrid.Location = new System.Drawing.Point(0, 0);
            this.DataGrid.Name = "DataGrid";
            this.DataGrid.Size = new System.Drawing.Size(716, 435);
            this.DataGrid.TabIndex = 0;
            this.DataGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGrid_CellContentClick_1);
            this.DataGrid.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DataGrid_CellMouseDown);
            this.DataGrid.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DataGrid_MouseDown);
            // 
            // ProxyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(716, 435);
            this.Controls.Add(this.DataGrid);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "ProxyForm";
            this.Text = "ProxyForm";
            this.Load += new System.EventHandler(this.ProxyForm_Load);
            this.gridMenu.ResumeLayout(false);
            this.cellMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip gridMenu;
        private System.Windows.Forms.ToolStripMenuItem addSingleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addMultipleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip cellMenu;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setThreadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setDelayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetStatsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        internal System.Windows.Forms.DataGridView DataGrid;
    }
}