namespace PTC_Creator.Forms
{
    partial class CreateForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateForm));
            this.StartButtonPanel = new System.Windows.Forms.Panel();
            this.StopButton = new System.Windows.Forms.Button();
            this.SaveSettingsButton = new System.Windows.Forms.Button();
            this.StartButton = new System.Windows.Forms.Button();
            this.ConfigPanel = new System.Windows.Forms.Panel();
            this.ThreadCreationSpeedTipLabel = new System.Windows.Forms.Label();
            this.ThreadCreationSpeedTextBox = new System.Windows.Forms.TextBox();
            this.ThreadCreationSpeedLabel = new System.Windows.Forms.Label();
            this.CreateAmountTextBox = new System.Windows.Forms.TextBox();
            this.ThreadAmountTextBox = new System.Windows.Forms.TextBox();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.UsernameTextBox = new System.Windows.Forms.TextBox();
            this.DomainTextBox = new System.Windows.Forms.TextBox();
            this.ShuffleAPITextBox = new System.Windows.Forms.TextBox();
            this.SaveInDBCheckBox = new System.Windows.Forms.CheckBox();
            this.CreateAmountLabel = new System.Windows.Forms.Label();
            this.RocketMapCheckBox = new System.Windows.Forms.CheckBox();
            this.ThreadLabel = new System.Windows.Forms.Label();
            this.ShuffleAPILabel = new System.Windows.Forms.Label();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.UsernameLabel = new System.Windows.Forms.Label();
            this.DomainLabel = new System.Windows.Forms.Label();
            this.ContentPanel = new System.Windows.Forms.Panel();
            this.createOlv = new BrightIdeasSoftware.FastObjectListView();
            this.username = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.password = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.dob = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.email = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.status = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.log = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.createOlvContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateStatusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StatusDataGrid = new System.Windows.Forms.DataGridView();
            this.StartButtonPanel.SuspendLayout();
            this.ConfigPanel.SuspendLayout();
            this.ContentPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.createOlv)).BeginInit();
            this.createOlvContextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StatusDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // StartButtonPanel
            // 
            this.StartButtonPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.StartButtonPanel.Controls.Add(this.StopButton);
            this.StartButtonPanel.Controls.Add(this.SaveSettingsButton);
            this.StartButtonPanel.Controls.Add(this.StartButton);
            this.StartButtonPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.StartButtonPanel.Location = new System.Drawing.Point(0, 623);
            this.StartButtonPanel.Name = "StartButtonPanel";
            this.StartButtonPanel.Size = new System.Drawing.Size(1094, 40);
            this.StartButtonPanel.TabIndex = 0;
            // 
            // StopButton
            // 
            this.StopButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.StopButton.BackColor = System.Drawing.Color.DeepPink;
            this.StopButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StopButton.ForeColor = System.Drawing.Color.Black;
            this.StopButton.Location = new System.Drawing.Point(269, -1);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(138, 40);
            this.StopButton.TabIndex = 2;
            this.StopButton.Text = "Stop";
            this.StopButton.UseVisualStyleBackColor = false;
            this.StopButton.Visible = false;
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // SaveSettingsButton
            // 
            this.SaveSettingsButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveSettingsButton.BackColor = System.Drawing.Color.LimeGreen;
            this.SaveSettingsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveSettingsButton.ForeColor = System.Drawing.Color.Black;
            this.SaveSettingsButton.Location = new System.Drawing.Point(685, -1);
            this.SaveSettingsButton.Name = "SaveSettingsButton";
            this.SaveSettingsButton.Size = new System.Drawing.Size(138, 40);
            this.SaveSettingsButton.TabIndex = 1;
            this.SaveSettingsButton.Text = "Save Settings";
            this.SaveSettingsButton.UseVisualStyleBackColor = false;
            this.SaveSettingsButton.Click += new System.EventHandler(this.SaveSettingsButton_Click);
            // 
            // StartButton
            // 
            this.StartButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.StartButton.BackColor = System.Drawing.Color.LimeGreen;
            this.StartButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StartButton.ForeColor = System.Drawing.Color.Black;
            this.StartButton.Location = new System.Drawing.Point(269, -1);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(138, 40);
            this.StartButton.TabIndex = 0;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = false;
            this.StartButton.Click += new System.EventHandler(this.StartButton_ClickAsync);
            // 
            // ConfigPanel
            // 
            this.ConfigPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.ConfigPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ConfigPanel.Controls.Add(this.ThreadCreationSpeedTipLabel);
            this.ConfigPanel.Controls.Add(this.ThreadCreationSpeedTextBox);
            this.ConfigPanel.Controls.Add(this.ThreadCreationSpeedLabel);
            this.ConfigPanel.Controls.Add(this.CreateAmountTextBox);
            this.ConfigPanel.Controls.Add(this.ThreadAmountTextBox);
            this.ConfigPanel.Controls.Add(this.PasswordTextBox);
            this.ConfigPanel.Controls.Add(this.UsernameTextBox);
            this.ConfigPanel.Controls.Add(this.DomainTextBox);
            this.ConfigPanel.Controls.Add(this.ShuffleAPITextBox);
            this.ConfigPanel.Controls.Add(this.SaveInDBCheckBox);
            this.ConfigPanel.Controls.Add(this.CreateAmountLabel);
            this.ConfigPanel.Controls.Add(this.RocketMapCheckBox);
            this.ConfigPanel.Controls.Add(this.ThreadLabel);
            this.ConfigPanel.Controls.Add(this.ShuffleAPILabel);
            this.ConfigPanel.Controls.Add(this.PasswordLabel);
            this.ConfigPanel.Controls.Add(this.UsernameLabel);
            this.ConfigPanel.Controls.Add(this.DomainLabel);
            this.ConfigPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.ConfigPanel.ForeColor = System.Drawing.Color.White;
            this.ConfigPanel.Location = new System.Drawing.Point(0, 0);
            this.ConfigPanel.Name = "ConfigPanel";
            this.ConfigPanel.Size = new System.Drawing.Size(355, 623);
            this.ConfigPanel.TabIndex = 1;
            // 
            // ThreadCreationSpeedTipLabel
            // 
            this.ThreadCreationSpeedTipLabel.AutoSize = true;
            this.ThreadCreationSpeedTipLabel.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ThreadCreationSpeedTipLabel.Location = new System.Drawing.Point(132, 461);
            this.ThreadCreationSpeedTipLabel.Name = "ThreadCreationSpeedTipLabel";
            this.ThreadCreationSpeedTipLabel.Size = new System.Drawing.Size(104, 17);
            this.ThreadCreationSpeedTipLabel.TabIndex = 18;
            this.ThreadCreationSpeedTipLabel.Text = "Recommand: 10";
            // 
            // ThreadCreationSpeedTextBox
            // 
            this.ThreadCreationSpeedTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ThreadCreationSpeedTextBox.Location = new System.Drawing.Point(242, 437);
            this.ThreadCreationSpeedTextBox.Name = "ThreadCreationSpeedTextBox";
            this.ThreadCreationSpeedTextBox.Size = new System.Drawing.Size(49, 27);
            this.ThreadCreationSpeedTextBox.TabIndex = 17;
            this.ThreadCreationSpeedTextBox.Text = "10";
            this.ThreadCreationSpeedTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumOnly_KeyPress);
            // 
            // ThreadCreationSpeedLabel
            // 
            this.ThreadCreationSpeedLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ThreadCreationSpeedLabel.AutoSize = true;
            this.ThreadCreationSpeedLabel.Location = new System.Drawing.Point(11, 440);
            this.ThreadCreationSpeedLabel.Name = "ThreadCreationSpeedLabel";
            this.ThreadCreationSpeedLabel.Size = new System.Drawing.Size(225, 21);
            this.ThreadCreationSpeedLabel.TabIndex = 16;
            this.ThreadCreationSpeedLabel.Text = "Thread Creation Speed (/s):";
            // 
            // CreateAmountTextBox
            // 
            this.CreateAmountTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CreateAmountTextBox.Location = new System.Drawing.Point(153, 299);
            this.CreateAmountTextBox.Name = "CreateAmountTextBox";
            this.CreateAmountTextBox.Size = new System.Drawing.Size(98, 27);
            this.CreateAmountTextBox.TabIndex = 15;
            this.CreateAmountTextBox.Text = "1000";
            this.CreateAmountTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumOnly_KeyPress);
            // 
            // ThreadAmountTextBox
            // 
            this.ThreadAmountTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ThreadAmountTextBox.Location = new System.Drawing.Point(155, 368);
            this.ThreadAmountTextBox.Name = "ThreadAmountTextBox";
            this.ThreadAmountTextBox.Size = new System.Drawing.Size(98, 27);
            this.ThreadAmountTextBox.TabIndex = 14;
            this.ThreadAmountTextBox.Text = "10";
            this.ThreadAmountTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumOnly_KeyPress);
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PasswordTextBox.Location = new System.Drawing.Point(153, 230);
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.Size = new System.Drawing.Size(176, 27);
            this.PasswordTextBox.TabIndex = 13;
            // 
            // UsernameTextBox
            // 
            this.UsernameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UsernameTextBox.Location = new System.Drawing.Point(153, 161);
            this.UsernameTextBox.Name = "UsernameTextBox";
            this.UsernameTextBox.Size = new System.Drawing.Size(176, 27);
            this.UsernameTextBox.TabIndex = 12;
            this.UsernameTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.UsernameTextBox_KeyPress);
            // 
            // DomainTextBox
            // 
            this.DomainTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DomainTextBox.Location = new System.Drawing.Point(113, 92);
            this.DomainTextBox.Name = "DomainTextBox";
            this.DomainTextBox.Size = new System.Drawing.Size(216, 27);
            this.DomainTextBox.TabIndex = 11;
            // 
            // ShuffleAPITextBox
            // 
            this.ShuffleAPITextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ShuffleAPITextBox.Location = new System.Drawing.Point(113, 23);
            this.ShuffleAPITextBox.Name = "ShuffleAPITextBox";
            this.ShuffleAPITextBox.Size = new System.Drawing.Size(216, 27);
            this.ShuffleAPITextBox.TabIndex = 10;
            // 
            // SaveInDBCheckBox
            // 
            this.SaveInDBCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveInDBCheckBox.AutoSize = true;
            this.SaveInDBCheckBox.Location = new System.Drawing.Point(165, 562);
            this.SaveInDBCheckBox.Name = "SaveInDBCheckBox";
            this.SaveInDBCheckBox.Size = new System.Drawing.Size(167, 25);
            this.SaveInDBCheckBox.TabIndex = 9;
            this.SaveInDBCheckBox.Text = "Save In Shuffle DB";
            this.SaveInDBCheckBox.UseVisualStyleBackColor = true;
            this.SaveInDBCheckBox.Click += new System.EventHandler(this.SaveInDBCheckBox_Click);
            // 
            // CreateAmountLabel
            // 
            this.CreateAmountLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CreateAmountLabel.AutoSize = true;
            this.CreateAmountLabel.Location = new System.Drawing.Point(11, 302);
            this.CreateAmountLabel.Name = "CreateAmountLabel";
            this.CreateAmountLabel.Size = new System.Drawing.Size(139, 21);
            this.CreateAmountLabel.TabIndex = 8;
            this.CreateAmountLabel.Text = "Create Amount:";
            // 
            // RocketMapCheckBox
            // 
            this.RocketMapCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RocketMapCheckBox.AutoSize = true;
            this.RocketMapCheckBox.Location = new System.Drawing.Point(67, 509);
            this.RocketMapCheckBox.Name = "RocketMapCheckBox";
            this.RocketMapCheckBox.Size = new System.Drawing.Size(265, 25);
            this.RocketMapCheckBox.TabIndex = 7;
            this.RocketMapCheckBox.Text = "Output in Rocket Map Format";
            this.RocketMapCheckBox.UseVisualStyleBackColor = true;
            this.RocketMapCheckBox.Click += new System.EventHandler(this.RocketMapCheckBox_Click);
            // 
            // ThreadLabel
            // 
            this.ThreadLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ThreadLabel.AutoSize = true;
            this.ThreadLabel.Location = new System.Drawing.Point(11, 371);
            this.ThreadLabel.Name = "ThreadLabel";
            this.ThreadLabel.Size = new System.Drawing.Size(138, 21);
            this.ThreadLabel.TabIndex = 6;
            this.ThreadLabel.Text = "Thread Amount:";
            // 
            // ShuffleAPILabel
            // 
            this.ShuffleAPILabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ShuffleAPILabel.AutoSize = true;
            this.ShuffleAPILabel.Location = new System.Drawing.Point(11, 26);
            this.ShuffleAPILabel.Name = "ShuffleAPILabel";
            this.ShuffleAPILabel.Size = new System.Drawing.Size(96, 21);
            this.ShuffleAPILabel.TabIndex = 5;
            this.ShuffleAPILabel.Text = "Shuffle API:";
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.Location = new System.Drawing.Point(11, 233);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(86, 21);
            this.PasswordLabel.TabIndex = 4;
            this.PasswordLabel.Text = "Password:";
            // 
            // UsernameLabel
            // 
            this.UsernameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UsernameLabel.AutoSize = true;
            this.UsernameLabel.Location = new System.Drawing.Point(11, 164);
            this.UsernameLabel.Name = "UsernameLabel";
            this.UsernameLabel.Size = new System.Drawing.Size(136, 21);
            this.UsernameLabel.TabIndex = 2;
            this.UsernameLabel.Text = "Username Prefix:";
            // 
            // DomainLabel
            // 
            this.DomainLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DomainLabel.AutoSize = true;
            this.DomainLabel.Location = new System.Drawing.Point(11, 95);
            this.DomainLabel.Name = "DomainLabel";
            this.DomainLabel.Size = new System.Drawing.Size(81, 21);
            this.DomainLabel.TabIndex = 0;
            this.DomainLabel.Text = "*Domain:";
            // 
            // ContentPanel
            // 
            this.ContentPanel.Controls.Add(this.createOlv);
            this.ContentPanel.Controls.Add(this.StatusDataGrid);
            this.ContentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ContentPanel.Location = new System.Drawing.Point(355, 0);
            this.ContentPanel.Name = "ContentPanel";
            this.ContentPanel.Size = new System.Drawing.Size(739, 623);
            this.ContentPanel.TabIndex = 2;
            // 
            // createOlv
            // 
            this.createOlv.AllColumns.Add(this.username);
            this.createOlv.AllColumns.Add(this.password);
            this.createOlv.AllColumns.Add(this.dob);
            this.createOlv.AllColumns.Add(this.email);
            this.createOlv.AllColumns.Add(this.status);
            this.createOlv.AllColumns.Add(this.log);
            this.createOlv.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.createOlv.CellEditUseWholeCell = false;
            this.createOlv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.username,
            this.password,
            this.dob,
            this.email,
            this.status,
            this.log});
            this.createOlv.Cursor = System.Windows.Forms.Cursors.Default;
            this.createOlv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.createOlv.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.createOlv.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
            this.createOlv.FullRowSelect = true;
            this.createOlv.Location = new System.Drawing.Point(0, 0);
            this.createOlv.Name = "createOlv";
            this.createOlv.ShowGroups = false;
            this.createOlv.Size = new System.Drawing.Size(739, 623);
            this.createOlv.TabIndex = 3;
            this.createOlv.UseCellFormatEvents = true;
            this.createOlv.UseCompatibleStateImageBehavior = false;
            this.createOlv.View = System.Windows.Forms.View.Details;
            this.createOlv.VirtualMode = true;
            this.createOlv.CellRightClick += new System.EventHandler<BrightIdeasSoftware.CellRightClickEventArgs>(this.createOlv_CellRightClick);
            this.createOlv.FormatCell += new System.EventHandler<BrightIdeasSoftware.FormatCellEventArgs>(this.createOlv_FormatCell);
            // 
            // username
            // 
            this.username.AspectName = "username";
            this.username.Text = "Username";
            this.username.Width = 96;
            // 
            // password
            // 
            this.password.AspectName = "password";
            this.password.Text = "Password";
            this.password.Width = 99;
            // 
            // dob
            // 
            this.dob.AspectName = "dob";
            this.dob.Text = "Date of Birth";
            this.dob.Width = 115;
            // 
            // email
            // 
            this.email.AspectName = "email";
            this.email.Text = "Email";
            this.email.Width = 148;
            // 
            // status
            // 
            this.status.AspectName = "status";
            this.status.Text = "Status";
            this.status.Width = 81;
            // 
            // log
            // 
            this.log.AspectName = "_log";
            this.log.Text = "Log";
            this.log.Width = 169;
            // 
            // createOlvContextMenu
            // 
            this.createOlvContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showLogToolStripMenuItem,
            this.updateStatusToolStripMenuItem});
            this.createOlvContextMenu.Name = "createOlvContextMenu";
            this.createOlvContextMenu.Size = new System.Drawing.Size(148, 48);
            // 
            // showLogToolStripMenuItem
            // 
            this.showLogToolStripMenuItem.Name = "showLogToolStripMenuItem";
            this.showLogToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.showLogToolStripMenuItem.Text = "Show Log";
            this.showLogToolStripMenuItem.Click += new System.EventHandler(this.showLogToolStripMenuItem_Click);
            // 
            // updateStatusToolStripMenuItem
            // 
            this.updateStatusToolStripMenuItem.Name = "updateStatusToolStripMenuItem";
            this.updateStatusToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.updateStatusToolStripMenuItem.Text = "Update Status";
            this.updateStatusToolStripMenuItem.Click += new System.EventHandler(this.updateStatusToolStripMenuItem_Click);
            // 
            // StatusDataGrid
            // 
            this.StatusDataGrid.AllowUserToAddRows = false;
            this.StatusDataGrid.AllowUserToDeleteRows = false;
            this.StatusDataGrid.AllowUserToOrderColumns = true;
            this.StatusDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.StatusDataGrid.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.StatusDataGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.StatusDataGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.StatusDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.StatusDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StatusDataGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.StatusDataGrid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
            this.StatusDataGrid.Location = new System.Drawing.Point(0, 0);
            this.StatusDataGrid.Name = "StatusDataGrid";
            this.StatusDataGrid.Size = new System.Drawing.Size(739, 623);
            this.StatusDataGrid.TabIndex = 2;
            this.StatusDataGrid.VirtualMode = true;
            // 
            // CreateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(1094, 663);
            this.Controls.Add(this.ContentPanel);
            this.Controls.Add(this.ConfigPanel);
            this.Controls.Add(this.StartButtonPanel);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "CreateForm";
            this.Text = "CreateForm";
            this.Load += new System.EventHandler(this.CreateForm_Load);
            this.StartButtonPanel.ResumeLayout(false);
            this.ConfigPanel.ResumeLayout(false);
            this.ConfigPanel.PerformLayout();
            this.ContentPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.createOlv)).EndInit();
            this.createOlvContextMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.StatusDataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel StartButtonPanel;
        private System.Windows.Forms.Panel ConfigPanel;
        private System.Windows.Forms.TextBox CreateAmountTextBox;
        private System.Windows.Forms.TextBox ThreadAmountTextBox;
        private System.Windows.Forms.TextBox PasswordTextBox;
        private System.Windows.Forms.TextBox UsernameTextBox;
        private System.Windows.Forms.TextBox DomainTextBox;
        private System.Windows.Forms.TextBox ShuffleAPITextBox;
        private System.Windows.Forms.CheckBox SaveInDBCheckBox;
        private System.Windows.Forms.Label CreateAmountLabel;
        private System.Windows.Forms.CheckBox RocketMapCheckBox;
        private System.Windows.Forms.Label ThreadLabel;
        private System.Windows.Forms.Label ShuffleAPILabel;
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.Label UsernameLabel;
        private System.Windows.Forms.Label DomainLabel;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Panel ContentPanel;
        private System.Windows.Forms.Button SaveSettingsButton;
        public System.Windows.Forms.DataGridView StatusDataGrid;
        private BrightIdeasSoftware.OLVColumn username;
        private BrightIdeasSoftware.OLVColumn password;
        private BrightIdeasSoftware.OLVColumn dob;
        private BrightIdeasSoftware.OLVColumn email;
        private BrightIdeasSoftware.OLVColumn status;
        private BrightIdeasSoftware.OLVColumn log;
        private System.Windows.Forms.Button StopButton;
        private BrightIdeasSoftware.FastObjectListView createOlv;
        private System.Windows.Forms.TextBox ThreadCreationSpeedTextBox;
        private System.Windows.Forms.Label ThreadCreationSpeedLabel;
        private System.Windows.Forms.Label ThreadCreationSpeedTipLabel;
        private System.Windows.Forms.ContextMenuStrip createOlvContextMenu;
        private System.Windows.Forms.ToolStripMenuItem showLogToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateStatusToolStripMenuItem;
    }
}