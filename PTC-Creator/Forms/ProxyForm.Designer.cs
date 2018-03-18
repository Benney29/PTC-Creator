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
            this.ProxyGridMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addSingleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addMultipleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ProxyCellMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setThreadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setDelayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetStatsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.ProxyPanel = new System.Windows.Forms.Panel();
            this.ProxyDataGrid = new System.Windows.Forms.DataGridView();
            this.WebProxySettingPanel = new System.Windows.Forms.Panel();
            this.AddButton = new System.Windows.Forms.Button();
            this.ProxyTypeComboBox = new System.Windows.Forms.ComboBox();
            this.ProxyTypeLabel = new System.Windows.Forms.Label();
            this.WebProxyUrlTextBox = new System.Windows.Forms.TextBox();
            this.WebProxyLabel = new System.Windows.Forms.Label();
            this.TestButton = new System.Windows.Forms.Button();
            this.ProxyGridMenu.SuspendLayout();
            this.ProxyCellMenu.SuspendLayout();
            this.ProxyPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProxyDataGrid)).BeginInit();
            this.WebProxySettingPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ProxyGridMenu
            // 
            this.ProxyGridMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addSingleToolStripMenuItem,
            this.addMultipleToolStripMenuItem,
            this.selectAllToolStripMenuItem});
            this.ProxyGridMenu.Name = "gridMenu";
            this.ProxyGridMenu.Size = new System.Drawing.Size(144, 70);
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
            // ProxyCellMenu
            // 
            this.ProxyCellMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.settingsToolStripMenuItem});
            this.ProxyCellMenu.Name = "gridMenu";
            this.ProxyCellMenu.Size = new System.Drawing.Size(144, 92);
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
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Text|*.txt|All|*.*";
            this.openFileDialog.Title = "Select Proxy File";
            // 
            // ProxyPanel
            // 
            this.ProxyPanel.Controls.Add(this.ProxyDataGrid);
            this.ProxyPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProxyPanel.Location = new System.Drawing.Point(0, 0);
            this.ProxyPanel.Name = "ProxyPanel";
            this.ProxyPanel.Size = new System.Drawing.Size(1064, 581);
            this.ProxyPanel.TabIndex = 3;
            // 
            // ProxyDataGrid
            // 
            this.ProxyDataGrid.AllowUserToAddRows = false;
            this.ProxyDataGrid.AllowUserToDeleteRows = false;
            this.ProxyDataGrid.AllowUserToOrderColumns = true;
            this.ProxyDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.ProxyDataGrid.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.ProxyDataGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ProxyDataGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.ProxyDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ProxyDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProxyDataGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.ProxyDataGrid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
            this.ProxyDataGrid.Location = new System.Drawing.Point(0, 0);
            this.ProxyDataGrid.Name = "ProxyDataGrid";
            this.ProxyDataGrid.Size = new System.Drawing.Size(1064, 581);
            this.ProxyDataGrid.TabIndex = 1;
            this.ProxyDataGrid.VirtualMode = true;
            this.ProxyDataGrid.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DataGrid_CellMouseDown);
            this.ProxyDataGrid.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DataGrid_MouseDown);
            // 
            // WebProxySettingPanel
            // 
            this.WebProxySettingPanel.Controls.Add(this.TestButton);
            this.WebProxySettingPanel.Controls.Add(this.AddButton);
            this.WebProxySettingPanel.Controls.Add(this.ProxyTypeComboBox);
            this.WebProxySettingPanel.Controls.Add(this.ProxyTypeLabel);
            this.WebProxySettingPanel.Controls.Add(this.WebProxyUrlTextBox);
            this.WebProxySettingPanel.Controls.Add(this.WebProxyLabel);
            this.WebProxySettingPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.WebProxySettingPanel.Location = new System.Drawing.Point(0, 581);
            this.WebProxySettingPanel.Name = "WebProxySettingPanel";
            this.WebProxySettingPanel.Size = new System.Drawing.Size(1064, 55);
            this.WebProxySettingPanel.TabIndex = 2;
            // 
            // AddButton
            // 
            this.AddButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddButton.Location = new System.Drawing.Point(942, 0);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(58, 55);
            this.AddButton.TabIndex = 4;
            this.AddButton.Text = "Add";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // ProxyTypeComboBox
            // 
            this.ProxyTypeComboBox.FormattingEnabled = true;
            this.ProxyTypeComboBox.Location = new System.Drawing.Point(801, 14);
            this.ProxyTypeComboBox.Name = "ProxyTypeComboBox";
            this.ProxyTypeComboBox.Size = new System.Drawing.Size(121, 29);
            this.ProxyTypeComboBox.TabIndex = 3;
            // 
            // ProxyTypeLabel
            // 
            this.ProxyTypeLabel.AutoSize = true;
            this.ProxyTypeLabel.Location = new System.Drawing.Point(700, 17);
            this.ProxyTypeLabel.Name = "ProxyTypeLabel";
            this.ProxyTypeLabel.Size = new System.Drawing.Size(95, 21);
            this.ProxyTypeLabel.TabIndex = 2;
            this.ProxyTypeLabel.Text = "Proxy Type:";
            // 
            // WebProxyUrlTextBox
            // 
            this.WebProxyUrlTextBox.Location = new System.Drawing.Point(168, 14);
            this.WebProxyUrlTextBox.Name = "WebProxyUrlTextBox";
            this.WebProxyUrlTextBox.Size = new System.Drawing.Size(512, 27);
            this.WebProxyUrlTextBox.TabIndex = 1;
            // 
            // WebProxyLabel
            // 
            this.WebProxyLabel.AutoSize = true;
            this.WebProxyLabel.Location = new System.Drawing.Point(36, 17);
            this.WebProxyLabel.Name = "WebProxyLabel";
            this.WebProxyLabel.Size = new System.Drawing.Size(126, 21);
            this.WebProxyLabel.TabIndex = 0;
            this.WebProxyLabel.Text = "Web Proxy URL:";
            // 
            // TestButton
            // 
            this.TestButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TestButton.Location = new System.Drawing.Point(1003, 0);
            this.TestButton.Name = "TestButton";
            this.TestButton.Size = new System.Drawing.Size(58, 55);
            this.TestButton.TabIndex = 5;
            this.TestButton.Text = "Test";
            this.TestButton.UseVisualStyleBackColor = true;
            this.TestButton.Click += new System.EventHandler(this.TestButton_Click);
            // 
            // ProxyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(1064, 636);
            this.Controls.Add(this.ProxyPanel);
            this.Controls.Add(this.WebProxySettingPanel);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "ProxyForm";
            this.Text = "ProxyForm";
            this.Load += new System.EventHandler(this.ProxyForm_Load);
            this.ProxyGridMenu.ResumeLayout(false);
            this.ProxyCellMenu.ResumeLayout(false);
            this.ProxyPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ProxyDataGrid)).EndInit();
            this.WebProxySettingPanel.ResumeLayout(false);
            this.WebProxySettingPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip ProxyGridMenu;
        private System.Windows.Forms.ToolStripMenuItem addSingleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addMultipleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip ProxyCellMenu;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setThreadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setDelayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetStatsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Panel ProxyPanel;
        internal System.Windows.Forms.DataGridView ProxyDataGrid;
        private System.Windows.Forms.Panel WebProxySettingPanel;
        private System.Windows.Forms.TextBox WebProxyUrlTextBox;
        private System.Windows.Forms.Label WebProxyLabel;
        private System.Windows.Forms.ComboBox ProxyTypeComboBox;
        private System.Windows.Forms.Label ProxyTypeLabel;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button TestButton;
    }
}