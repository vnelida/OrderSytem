namespace Windows.Forms
{
    partial class frmPermissions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPermissions));
            btnAssign = new Button();
            btnRemove = new Button();
            dgvAvailable = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dgvAssigned = new DataGridView();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            splitContainer3 = new SplitContainer();
            panel1 = new Panel();
            cboRoles = new ComboBox();
            label1 = new Label();
            btnCancel = new Button();
            btnSave = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvAvailable).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvAssigned).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer3).BeginInit();
            splitContainer3.Panel1.SuspendLayout();
            splitContainer3.Panel2.SuspendLayout();
            splitContainer3.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // btnAssign
            // 
            btnAssign.Image = (Image)resources.GetObject("btnAssign.Image");
            btnAssign.Location = new Point(805, 446);
            btnAssign.Margin = new Padding(6);
            btnAssign.Name = "btnAssign";
            btnAssign.Size = new Size(139, 100);
            btnAssign.TabIndex = 3;
            btnAssign.Text = "Assign";
            btnAssign.TextImageRelation = TextImageRelation.ImageAboveText;
            btnAssign.UseVisualStyleBackColor = true;
            btnAssign.Click += btnAssign_Click;
            // 
            // btnRemove
            // 
            btnRemove.Image = (Image)resources.GetObject("btnRemove.Image");
            btnRemove.Location = new Point(805, 591);
            btnRemove.Margin = new Padding(6);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(139, 100);
            btnRemove.TabIndex = 2;
            btnRemove.Text = "Remove";
            btnRemove.TextImageRelation = TextImageRelation.ImageAboveText;
            btnRemove.UseVisualStyleBackColor = true;
            btnRemove.Click += btnRemove_Click;
            // 
            // dgvAvailable
            // 
            dgvAvailable.AllowUserToAddRows = false;
            dgvAvailable.AllowUserToDeleteRows = false;
            dgvAvailable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAvailable.BackgroundColor = Color.White;
            dgvAvailable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAvailable.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1 });
            dgvAvailable.Location = new Point(37, 249);
            dgvAvailable.MultiSelect = false;
            dgvAvailable.Name = "dgvAvailable";
            dgvAvailable.ReadOnly = true;
            dgvAvailable.RowHeadersVisible = false;
            dgvAvailable.RowHeadersWidth = 82;
            dgvAvailable.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAvailable.Size = new Size(680, 590);
            dgvAvailable.TabIndex = 6;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.HeaderText = "Id";
            dataGridViewTextBoxColumn1.MinimumWidth = 10;
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.ReadOnly = true;
            dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dgvAssigned
            // 
            dgvAssigned.AllowUserToAddRows = false;
            dgvAssigned.AllowUserToDeleteRows = false;
            dgvAssigned.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAssigned.BackgroundColor = Color.White;
            dgvAssigned.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAssigned.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn2 });
            dgvAssigned.Location = new Point(1060, 261);
            dgvAssigned.MultiSelect = false;
            dgvAssigned.Name = "dgvAssigned";
            dgvAssigned.ReadOnly = true;
            dgvAssigned.RowHeadersVisible = false;
            dgvAssigned.RowHeadersWidth = 82;
            dgvAssigned.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAssigned.Size = new Size(680, 590);
            dgvAssigned.TabIndex = 7;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.HeaderText = "Id";
            dataGridViewTextBoxColumn2.MinimumWidth = 10;
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.ReadOnly = true;
            dataGridViewTextBoxColumn2.Visible = false;
            // 
            // splitContainer3
            // 
            splitContainer3.Dock = DockStyle.Fill;
            splitContainer3.Location = new Point(0, 0);
            splitContainer3.Name = "splitContainer3";
            splitContainer3.Orientation = Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            splitContainer3.Panel1.BackgroundImage = Properties.Resources.Captura_de_pantalla_2025_08_02_005150;
            splitContainer3.Panel1.Controls.Add(panel1);
            splitContainer3.Panel1.Controls.Add(dgvAssigned);
            splitContainer3.Panel1.Controls.Add(dgvAvailable);
            splitContainer3.Panel1.Controls.Add(btnRemove);
            splitContainer3.Panel1.Controls.Add(btnAssign);
            // 
            // splitContainer3.Panel2
            // 
            splitContainer3.Panel2.BackgroundImage = Properties.Resources.Green_Retro_Illustrative_Fast_Food_Logo__1_;
            splitContainer3.Panel2.Controls.Add(btnCancel);
            splitContainer3.Panel2.Controls.Add(btnSave);
            splitContainer3.Size = new Size(1752, 1018);
            splitContainer3.SplitterDistance = 851;
            splitContainer3.TabIndex = 1;
            splitContainer3.SplitterMoved += splitContainer3_SplitterMoved;
            // 
            // panel1
            // 
            panel1.BackgroundImage = Properties.Resources.Captura_de_pantalla_2025_08_02_005150;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(cboRoles);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(37, 31);
            panel1.Name = "panel1";
            panel1.Size = new Size(1703, 200);
            panel1.TabIndex = 8;
            // 
            // cboRoles
            // 
            cboRoles.DropDownStyle = ComboBoxStyle.DropDownList;
            cboRoles.FormattingEnabled = true;
            cboRoles.Location = new Point(75, 78);
            cboRoles.Margin = new Padding(6);
            cboRoles.Name = "cboRoles";
            cboRoles.Size = new Size(450, 40);
            cboRoles.TabIndex = 5;
            cboRoles.SelectedIndexChanged += cmbRoles_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.ButtonHighlight;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(1, 73);
            label1.Margin = new Padding(6, 0, 6, 0);
            label1.Name = "label1";
            label1.Size = new Size(72, 45);
            label1.TabIndex = 4;
            label1.Text = "Rol:";
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.IndianRed;
            btnCancel.ForeColor = SystemColors.ButtonHighlight;
            btnCancel.Location = new Point(1558, 29);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(182, 95);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnSave
            // 
            btnSave.BackgroundImage = (Image)resources.GetObject("btnSave.BackgroundImage");
            btnSave.Location = new Point(1362, 29);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(182, 95);
            btnSave.TabIndex = 4;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // frmPermissions
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1752, 1018);
            Controls.Add(splitContainer3);
            MaximumSize = new Size(1778, 1089);
            MinimumSize = new Size(1778, 1089);
            Name = "frmPermissions";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmPermissions";
            Load += PermissionsForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvAvailable).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvAssigned).EndInit();
            splitContainer3.Panel1.ResumeLayout(false);
            splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer3).EndInit();
            splitContainer3.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private DataGridView dgvAssigned;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridView dgvAvailable;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private Button btnRemove;
        private Button btnAssign;
        private SplitContainer splitContainer3;
        private ComboBox cboRoles;
        private Label label1;
        private Button btnCancel;
        private Button btnSave;
        private Panel panel1;
    }
}