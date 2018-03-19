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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateForm));
            this.StartButtonPanel = new System.Windows.Forms.Panel();
            this.SaveSettingsButton = new System.Windows.Forms.Button();
            this.StartButton = new System.Windows.Forms.Button();
            this.ConfigPanel = new System.Windows.Forms.Panel();
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.StatusDataGrid = new System.Windows.Forms.DataGridView();
            this.StartButtonPanel.SuspendLayout();
            this.ConfigPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StatusDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // StartButtonPanel
            // 
            this.StartButtonPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.StartButtonPanel.Controls.Add(this.SaveSettingsButton);
            this.StartButtonPanel.Controls.Add(this.StartButton);
            this.StartButtonPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.StartButtonPanel.Location = new System.Drawing.Point(0, 623);
            this.StartButtonPanel.Name = "StartButtonPanel";
            this.StartButtonPanel.Size = new System.Drawing.Size(1094, 40);
            this.StartButtonPanel.TabIndex = 0;
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
            // CreateAmountTextBox
            // 
            this.CreateAmountTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CreateAmountTextBox.Location = new System.Drawing.Point(156, 408);
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
            this.ThreadAmountTextBox.Location = new System.Drawing.Point(156, 331);
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
            this.PasswordTextBox.Location = new System.Drawing.Point(156, 254);
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.Size = new System.Drawing.Size(176, 27);
            this.PasswordTextBox.TabIndex = 13;
            // 
            // UsernameTextBox
            // 
            this.UsernameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UsernameTextBox.Location = new System.Drawing.Point(156, 177);
            this.UsernameTextBox.Name = "UsernameTextBox";
            this.UsernameTextBox.Size = new System.Drawing.Size(176, 27);
            this.UsernameTextBox.TabIndex = 12;
            this.UsernameTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.UsernameTextBox_KeyPress);
            // 
            // DomainTextBox
            // 
            this.DomainTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DomainTextBox.Location = new System.Drawing.Point(116, 100);
            this.DomainTextBox.Name = "DomainTextBox";
            this.DomainTextBox.Size = new System.Drawing.Size(216, 27);
            this.DomainTextBox.TabIndex = 11;
            // 
            // ShuffleAPITextBox
            // 
            this.ShuffleAPITextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ShuffleAPITextBox.Location = new System.Drawing.Point(116, 23);
            this.ShuffleAPITextBox.Name = "ShuffleAPITextBox";
            this.ShuffleAPITextBox.Size = new System.Drawing.Size(216, 27);
            this.ShuffleAPITextBox.TabIndex = 10;
            // 
            // SaveInDBCheckBox
            // 
            this.SaveInDBCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveInDBCheckBox.AutoSize = true;
            this.SaveInDBCheckBox.Location = new System.Drawing.Point(167, 533);
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
            this.CreateAmountLabel.Location = new System.Drawing.Point(14, 411);
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
            this.RocketMapCheckBox.Location = new System.Drawing.Point(69, 472);
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
            this.ThreadLabel.Location = new System.Drawing.Point(14, 334);
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
            this.ShuffleAPILabel.Location = new System.Drawing.Point(14, 26);
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
            this.PasswordLabel.Location = new System.Drawing.Point(14, 257);
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
            this.UsernameLabel.Location = new System.Drawing.Point(14, 180);
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
            this.DomainLabel.Location = new System.Drawing.Point(14, 103);
            this.DomainLabel.Name = "DomainLabel";
            this.DomainLabel.Size = new System.Drawing.Size(81, 21);
            this.DomainLabel.TabIndex = 0;
            this.DomainLabel.Text = "*Domain:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.StatusDataGrid);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(355, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(739, 623);
            this.panel1.TabIndex = 2;
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
            this.Controls.Add(this.panel1);
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
            this.panel1.ResumeLayout(false);
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
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button SaveSettingsButton;
        public System.Windows.Forms.DataGridView StatusDataGrid;
    }
}