namespace Windows.Forms
{
    partial class frmEmployees
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEmployees));
            dgv = new DataGridView();
            colFirstName = new DataGridViewTextBoxColumn();
            colLastName = new DataGridViewTextBoxColumn();
            colPhone = new DataGridViewTextBoxColumn();
            colEmail = new DataGridViewTextBoxColumn();
            colAddress = new DataGridViewTextBoxColumn();
            toolStrip1 = new ToolStrip();
            btnNew = new ToolStripButton();
            btnDelete = new ToolStripButton();
            btnEdit = new ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)dgv).BeginInit();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // dgv
            // 
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv.Columns.AddRange(new DataGridViewColumn[] { colFirstName, colLastName, colPhone, colEmail, colAddress });
            dgv.Dock = DockStyle.Fill;
            dgv.Location = new Point(0, 42);
            dgv.MultiSelect = false;
            dgv.Name = "dgv";
            dgv.ReadOnly = true;
            dgv.RowHeadersVisible = false;
            dgv.RowHeadersWidth = 82;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.Size = new Size(1168, 451);
            dgv.TabIndex = 3;
            // 
            // colFirstName
            // 
            colFirstName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colFirstName.HeaderText = "First Name";
            colFirstName.MinimumWidth = 10;
            colFirstName.Name = "colFirstName";
            colFirstName.ReadOnly = true;
            // 
            // colLastName
            // 
            colLastName.HeaderText = "Last Name";
            colLastName.MinimumWidth = 10;
            colLastName.Name = "colLastName";
            colLastName.ReadOnly = true;
            colLastName.Width = 200;
            // 
            // colPhone
            // 
            colPhone.HeaderText = "Phone";
            colPhone.MinimumWidth = 10;
            colPhone.Name = "colPhone";
            colPhone.ReadOnly = true;
            colPhone.Width = 200;
            // 
            // colEmail
            // 
            colEmail.HeaderText = "Email";
            colEmail.MinimumWidth = 10;
            colEmail.Name = "colEmail";
            colEmail.ReadOnly = true;
            colEmail.Width = 200;
            // 
            // colAddress
            // 
            colAddress.HeaderText = "Address";
            colAddress.MinimumWidth = 10;
            colAddress.Name = "colAddress";
            colAddress.ReadOnly = true;
            colAddress.Width = 200;
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(32, 32);
            toolStrip1.Items.AddRange(new ToolStripItem[] { btnNew, btnDelete, btnEdit });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1168, 42);
            toolStrip1.TabIndex = 2;
            toolStrip1.Text = "toolStrip1";
            // 
            // btnNew
            // 
            btnNew.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btnNew.Image = (Image)resources.GetObject("btnNew.Image");
            btnNew.ImageTransparentColor = Color.Magenta;
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(66, 36);
            btnNew.Text = "New";
            btnNew.Click += btnNew_Click;
            // 
            // btnDelete
            // 
            btnDelete.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btnDelete.Image = (Image)resources.GetObject("btnDelete.Image");
            btnDelete.ImageTransparentColor = Color.Magenta;
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(88, 36);
            btnDelete.Text = "Delete";
            btnDelete.Click += btnDelete_Click;
            // 
            // btnEdit
            // 
            btnEdit.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btnEdit.Image = (Image)resources.GetObject("btnEdit.Image");
            btnEdit.ImageTransparentColor = Color.Magenta;
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(58, 36);
            btnEdit.Text = "Edit";
            btnEdit.Click += btnEdit_Click;
            // 
            // frmEmployees
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1168, 493);
            Controls.Add(dgv);
            Controls.Add(toolStrip1);
            Name = "frmEmployees";
            Text = "frmEmployees";
            Load += frmEmployees_Load;
            ((System.ComponentModel.ISupportInitialize)dgv).EndInit();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgv;
        private DataGridViewTextBoxColumn colFirstName;
        private DataGridViewTextBoxColumn colLastName;
        private DataGridViewTextBoxColumn colPhone;
        private DataGridViewTextBoxColumn colEmail;
        private DataGridViewTextBoxColumn colAddress;
        private ToolStrip toolStrip1;
        private ToolStripButton btnNew;
        private ToolStripButton btnDelete;
        private ToolStripButton btnEdit;
    }
}