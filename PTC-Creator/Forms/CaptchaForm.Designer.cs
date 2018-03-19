namespace PTC_Creator.Forms
{
    partial class CaptchaForm
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
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cellMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.changeOrderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveToFirstToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveUPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveDownToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveToLastToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetStatsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CaptchaDataGrid = new System.Windows.Forms.DataGridView();
            this.gridMenu.SuspendLayout();
            this.cellMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CaptchaDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // gridMenu
            // 
            this.gridMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectAllToolStripMenuItem});
            this.gridMenu.Name = "gridMenu";
            this.gridMenu.Size = new System.Drawing.Size(123, 26);
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.selectAllToolStripMenuItem.Text = "Select All";
            this.selectAllToolStripMenuItem.Click += new System.EventHandler(this.selectAllToolStripMenuItem_Click);
            // 
            // cellMenu
            // 
            this.cellMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changeOrderToolStripMenuItem,
            this.resetStatsToolStripMenuItem});
            this.cellMenu.Name = "cellMenu";
            this.cellMenu.Size = new System.Drawing.Size(149, 48);
            // 
            // changeOrderToolStripMenuItem
            // 
            this.changeOrderToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.moveToFirstToolStripMenuItem,
            this.moveUPToolStripMenuItem,
            this.moveDownToolStripMenuItem,
            this.moveToLastToolStripMenuItem});
            this.changeOrderToolStripMenuItem.Name = "changeOrderToolStripMenuItem";
            this.changeOrderToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.changeOrderToolStripMenuItem.Text = "Change Order";
            // 
            // moveToFirstToolStripMenuItem
            // 
            this.moveToFirstToolStripMenuItem.Name = "moveToFirstToolStripMenuItem";
            this.moveToFirstToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.moveToFirstToolStripMenuItem.Text = "Move to First";
            this.moveToFirstToolStripMenuItem.Click += new System.EventHandler(this.moveToFirstToolStripMenuItem_Click);
            // 
            // moveUPToolStripMenuItem
            // 
            this.moveUPToolStripMenuItem.Name = "moveUPToolStripMenuItem";
            this.moveUPToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.moveUPToolStripMenuItem.Text = "Move UP";
            this.moveUPToolStripMenuItem.Click += new System.EventHandler(this.moveUPToolStripMenuItem_Click);
            // 
            // moveDownToolStripMenuItem
            // 
            this.moveDownToolStripMenuItem.Name = "moveDownToolStripMenuItem";
            this.moveDownToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.moveDownToolStripMenuItem.Text = "Move Down";
            this.moveDownToolStripMenuItem.Click += new System.EventHandler(this.moveDownToolStripMenuItem_Click);
            // 
            // moveToLastToolStripMenuItem
            // 
            this.moveToLastToolStripMenuItem.Name = "moveToLastToolStripMenuItem";
            this.moveToLastToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.moveToLastToolStripMenuItem.Text = "Move to Last";
            this.moveToLastToolStripMenuItem.Click += new System.EventHandler(this.moveToLastToolStripMenuItem_Click);
            // 
            // resetStatsToolStripMenuItem
            // 
            this.resetStatsToolStripMenuItem.Name = "resetStatsToolStripMenuItem";
            this.resetStatsToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.resetStatsToolStripMenuItem.Text = "Reset Stats";
            this.resetStatsToolStripMenuItem.Click += new System.EventHandler(this.resetStatsToolStripMenuItem_Click);
            // 
            // CaptchaDataGrid
            // 
            this.CaptchaDataGrid.AllowUserToAddRows = false;
            this.CaptchaDataGrid.AllowUserToDeleteRows = false;
            this.CaptchaDataGrid.AllowUserToOrderColumns = true;
            this.CaptchaDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.CaptchaDataGrid.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.CaptchaDataGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.CaptchaDataGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.CaptchaDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CaptchaDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CaptchaDataGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.CaptchaDataGrid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
            this.CaptchaDataGrid.Location = new System.Drawing.Point(0, 0);
            this.CaptchaDataGrid.Name = "CaptchaDataGrid";
            this.CaptchaDataGrid.Size = new System.Drawing.Size(700, 396);
            this.CaptchaDataGrid.TabIndex = 1;
            this.CaptchaDataGrid.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DataGrid_CellMouseDown);
            this.CaptchaDataGrid.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DataGrid_MouseDown);
            // 
            // CaptchaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(700, 396);
            this.Controls.Add(this.CaptchaDataGrid);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "CaptchaForm";
            this.Text = "CaptchaForm";
            this.Load += new System.EventHandler(this.CaptchaForm_Load);
            this.gridMenu.ResumeLayout(false);
            this.cellMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CaptchaDataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip gridMenu;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip cellMenu;
        private System.Windows.Forms.ToolStripMenuItem resetStatsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeOrderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveToFirstToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveUPToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveDownToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveToLastToolStripMenuItem;
        internal System.Windows.Forms.DataGridView CaptchaDataGrid;
    }
}