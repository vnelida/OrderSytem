namespace Windows.Forms
{
    partial class frmCustomersAE
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCustomersAE));
            tabAddresses = new TabControl();
            tabPage1 = new TabPage();
            lblAddresses = new Label();
            lblPhones = new Label();
            label3 = new Label();
            label6 = new Label();
            label4 = new Label();
            txtDocumentNum = new TextBox();
            txtLastName = new TextBox();
            txtFirstName = new TextBox();
            tabPage2 = new TabPage();
            dgv = new DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colType = new DataGridViewTextBoxColumn();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            Column5 = new DataGridViewTextBoxColumn();
            Column6 = new DataGridViewTextBoxColumn();
            btnEditAddresses = new ToolStrip();
            btnAdd = new ToolStripButton();
            btnDelete = new ToolStripButton();
            btnEdit = new ToolStripButton();
            btnClose = new ToolStripButton();
            tabPage3 = new TabPage();
            toolStrip2 = new ToolStrip();
            btnAddPhone = new ToolStripButton();
            toolStripButton2 = new ToolStripButton();
            btnEditPhones = new ToolStripButton();
            toolStripButton4 = new ToolStripButton();
            dgvPhones = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            Column10 = new DataGridViewTextBoxColumn();
            PhoneTypeId = new DataGridViewTextBoxColumn();
            btnOk = new Button();
            btnCancel = new Button();
            errorProvider1 = new ErrorProvider(components);
            tabAddresses.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv).BeginInit();
            btnEditAddresses.SuspendLayout();
            tabPage3.SuspendLayout();
            toolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPhones).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // tabAddresses
            // 
            tabAddresses.Controls.Add(tabPage1);
            tabAddresses.Controls.Add(tabPage2);
            tabAddresses.Controls.Add(tabPage3);
            tabAddresses.Location = new Point(28, 30);
            tabAddresses.Name = "tabAddresses";
            tabAddresses.SelectedIndex = 0;
            tabAddresses.Size = new Size(1466, 716);
            tabAddresses.TabIndex = 0;
            tabAddresses.Tag = "";
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(lblAddresses);
            tabPage1.Controls.Add(lblPhones);
            tabPage1.Controls.Add(label3);
            tabPage1.Controls.Add(label6);
            tabPage1.Controls.Add(label4);
            tabPage1.Controls.Add(txtDocumentNum);
            tabPage1.Controls.Add(txtLastName);
            tabPage1.Controls.Add(txtFirstName);
            tabPage1.Location = new Point(8, 46);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1450, 662);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Customer Data";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // lblAddresses
            // 
            lblAddresses.AutoSize = true;
            lblAddresses.Location = new Point(553, 510);
            lblAddresses.Name = "lblAddresses";
            lblAddresses.Size = new Size(78, 32);
            lblAddresses.TabIndex = 49;
            lblAddresses.Text = "label2";
            // 
            // lblPhones
            // 
            lblPhones.AutoSize = true;
            lblPhones.Location = new Point(778, 510);
            lblPhones.Name = "lblPhones";
            lblPhones.Size = new Size(78, 32);
            lblPhones.TabIndex = 48;
            lblPhones.Text = "label1";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(172, 228);
            label3.Margin = new Padding(6, 0, 6, 0);
            label3.Name = "label3";
            label3.Size = new Size(226, 32);
            label3.TabIndex = 47;
            label3.Text = "Document Number:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(264, 412);
            label6.Margin = new Padding(6, 0, 6, 0);
            label6.Name = "label6";
            label6.Size = new Size(134, 32);
            label6.TabIndex = 45;
            label6.Text = "First Name:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(267, 324);
            label4.Margin = new Padding(6, 0, 6, 0);
            label4.Name = "label4";
            label4.Size = new Size(131, 32);
            label4.TabIndex = 46;
            label4.Text = "Last Name:";
            // 
            // txtDocumentNum
            // 
            txtDocumentNum.Location = new Point(435, 225);
            txtDocumentNum.Margin = new Padding(6);
            txtDocumentNum.MaxLength = 8;
            txtDocumentNum.Name = "txtDocumentNum";
            txtDocumentNum.Size = new Size(271, 39);
            txtDocumentNum.TabIndex = 42;
            // 
            // txtLastName
            // 
            txtLastName.Location = new Point(435, 317);
            txtLastName.Margin = new Padding(6);
            txtLastName.MaxLength = 50;
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(762, 39);
            txtLastName.TabIndex = 43;
            // 
            // txtFirstName
            // 
            txtFirstName.Location = new Point(435, 409);
            txtFirstName.Margin = new Padding(6);
            txtFirstName.MaxLength = 50;
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(762, 39);
            txtFirstName.TabIndex = 44;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(dgv);
            tabPage2.Controls.Add(btnEditAddresses);
            tabPage2.Location = new Point(8, 46);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1450, 662);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Addresses";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgv
            // 
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.BackgroundColor = Color.White;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv.Columns.AddRange(new DataGridViewColumn[] { colId, colType, Column1, Column2, Column3, Column4, Column5, Column6 });
            dgv.Location = new Point(6, 143);
            dgv.MultiSelect = false;
            dgv.Name = "dgv";
            dgv.ReadOnly = true;
            dgv.RowHeadersVisible = false;
            dgv.RowHeadersWidth = 82;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.Size = new Size(1438, 486);
            dgv.TabIndex = 5;
            // 
            // colId
            // 
            colId.HeaderText = "Id";
            colId.MinimumWidth = 10;
            colId.Name = "colId";
            colId.ReadOnly = true;
            colId.Visible = false;
            colId.Width = 200;
            // 
            // colType
            // 
            colType.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colType.HeaderText = "AddressType";
            colType.MinimumWidth = 10;
            colType.Name = "colType";
            colType.ReadOnly = true;
            // 
            // Column1
            // 
            Column1.HeaderText = "Street";
            Column1.MinimumWidth = 10;
            Column1.Name = "Column1";
            Column1.ReadOnly = true;
            Column1.Width = 200;
            // 
            // Column2
            // 
            Column2.HeaderText = "Building Number";
            Column2.MinimumWidth = 10;
            Column2.Name = "Column2";
            Column2.ReadOnly = true;
            Column2.Width = 200;
            // 
            // Column3
            // 
            Column3.HeaderText = "City";
            Column3.MinimumWidth = 10;
            Column3.Name = "Column3";
            Column3.ReadOnly = true;
            Column3.Width = 200;
            // 
            // Column4
            // 
            Column4.HeaderText = "Postal Code";
            Column4.MinimumWidth = 10;
            Column4.Name = "Column4";
            Column4.ReadOnly = true;
            Column4.Width = 200;
            // 
            // Column5
            // 
            Column5.HeaderText = "State";
            Column5.MinimumWidth = 10;
            Column5.Name = "Column5";
            Column5.ReadOnly = true;
            Column5.Width = 200;
            // 
            // Column6
            // 
            Column6.HeaderText = "Country";
            Column6.MinimumWidth = 10;
            Column6.Name = "Column6";
            Column6.ReadOnly = true;
            Column6.Width = 200;
            // 
            // btnEditAddresses
            // 
            btnEditAddresses.BackColor = SystemColors.ButtonHighlight;
            btnEditAddresses.ImageScalingSize = new Size(32, 32);
            btnEditAddresses.Items.AddRange(new ToolStripItem[] { btnAdd, btnDelete, btnEdit, btnClose });
            btnEditAddresses.Location = new Point(3, 3);
            btnEditAddresses.Name = "btnEditAddresses";
            btnEditAddresses.Size = new Size(1444, 106);
            btnEditAddresses.TabIndex = 3;
            btnEditAddresses.Text = "toolStrip1";
            // 
            // btnAdd
            // 
            btnAdd.Image = (Image)resources.GetObject("btnAdd.Image");
            btnAdd.ImageScaling = ToolStripItemImageScaling.None;
            btnAdd.ImageTransparentColor = Color.Magenta;
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(61, 100);
            btnAdd.Text = "Add";
            btnAdd.TextImageRelation = TextImageRelation.ImageAboveText;
            btnAdd.Click += btnAddAddress_Click;
            // 
            // btnDelete
            // 
            btnDelete.Image = (Image)resources.GetObject("btnDelete.Image");
            btnDelete.ImageScaling = ToolStripItemImageScaling.None;
            btnDelete.ImageTransparentColor = Color.Magenta;
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(88, 100);
            btnDelete.Text = "Delete";
            btnDelete.TextImageRelation = TextImageRelation.ImageAboveText;
            btnDelete.Click += btnDeleteAddress_Click;
            // 
            // btnEdit
            // 
            btnEdit.Image = (Image)resources.GetObject("btnEdit.Image");
            btnEdit.ImageScaling = ToolStripItemImageScaling.None;
            btnEdit.ImageTransparentColor = Color.Magenta;
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(58, 100);
            btnEdit.Text = "Edit";
            btnEdit.TextImageRelation = TextImageRelation.ImageAboveText;
            btnEdit.Click += btnEditAddresses_Click;
            // 
            // btnClose
            // 
            btnClose.Alignment = ToolStripItemAlignment.Right;
            btnClose.Image = (Image)resources.GetObject("btnClose.Image");
            btnClose.ImageScaling = ToolStripItemImageScaling.None;
            btnClose.ImageTransparentColor = Color.Magenta;
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(76, 100);
            btnClose.Text = "Close";
            btnClose.TextImageRelation = TextImageRelation.ImageAboveText;
            btnClose.Click += btnClose_Click;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(toolStrip2);
            tabPage3.Controls.Add(dgvPhones);
            tabPage3.Location = new Point(8, 46);
            tabPage3.Name = "tabPage3";
            tabPage3.Size = new Size(1450, 662);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Phones";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // toolStrip2
            // 
            toolStrip2.BackColor = SystemColors.ButtonHighlight;
            toolStrip2.ImageScalingSize = new Size(32, 32);
            toolStrip2.Items.AddRange(new ToolStripItem[] { btnAddPhone, toolStripButton2, btnEditPhones, toolStripButton4 });
            toolStrip2.Location = new Point(0, 0);
            toolStrip2.Name = "toolStrip2";
            toolStrip2.Size = new Size(1450, 106);
            toolStrip2.TabIndex = 5;
            toolStrip2.Text = "toolStrip2";
            // 
            // btnAddPhone
            // 
            btnAddPhone.Image = (Image)resources.GetObject("btnAddPhone.Image");
            btnAddPhone.ImageScaling = ToolStripItemImageScaling.None;
            btnAddPhone.ImageTransparentColor = Color.Magenta;
            btnAddPhone.Name = "btnAddPhone";
            btnAddPhone.Size = new Size(61, 100);
            btnAddPhone.Text = "Add";
            btnAddPhone.TextImageRelation = TextImageRelation.ImageAboveText;
            btnAddPhone.Click += btnAddPhone_Click;
            // 
            // toolStripButton2
            // 
            toolStripButton2.Image = (Image)resources.GetObject("toolStripButton2.Image");
            toolStripButton2.ImageScaling = ToolStripItemImageScaling.None;
            toolStripButton2.ImageTransparentColor = Color.Magenta;
            toolStripButton2.Name = "toolStripButton2";
            toolStripButton2.Size = new Size(88, 100);
            toolStripButton2.Text = "Delete";
            toolStripButton2.TextImageRelation = TextImageRelation.ImageAboveText;
            toolStripButton2.Click += btnDeletePhone_Click;
            // 
            // btnEditPhones
            // 
            btnEditPhones.Image = (Image)resources.GetObject("btnEditPhones.Image");
            btnEditPhones.ImageScaling = ToolStripItemImageScaling.None;
            btnEditPhones.ImageTransparentColor = Color.Magenta;
            btnEditPhones.Name = "btnEditPhones";
            btnEditPhones.Size = new Size(58, 100);
            btnEditPhones.Text = "Edit";
            btnEditPhones.TextImageRelation = TextImageRelation.ImageAboveText;
            btnEditPhones.Click += btnEditPhones_Click;
            // 
            // toolStripButton4
            // 
            toolStripButton4.Alignment = ToolStripItemAlignment.Right;
            toolStripButton4.Image = (Image)resources.GetObject("toolStripButton4.Image");
            toolStripButton4.ImageScaling = ToolStripItemImageScaling.None;
            toolStripButton4.ImageTransparentColor = Color.Magenta;
            toolStripButton4.Name = "toolStripButton4";
            toolStripButton4.Size = new Size(76, 100);
            toolStripButton4.Text = "Close";
            toolStripButton4.TextImageRelation = TextImageRelation.ImageAboveText;
            toolStripButton4.Click += btnClose_Click;
            // 
            // dgvPhones
            // 
            dgvPhones.AllowUserToAddRows = false;
            dgvPhones.AllowUserToDeleteRows = false;
            dgvPhones.BackgroundColor = Color.White;
            dgvPhones.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPhones.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, Column10, PhoneTypeId });
            dgvPhones.Location = new Point(12, 139);
            dgvPhones.MultiSelect = false;
            dgvPhones.Name = "dgvPhones";
            dgvPhones.ReadOnly = true;
            dgvPhones.RowHeadersVisible = false;
            dgvPhones.RowHeadersWidth = 82;
            dgvPhones.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPhones.Size = new Size(1421, 394);
            dgvPhones.TabIndex = 4;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.HeaderText = "Id";
            dataGridViewTextBoxColumn1.MinimumWidth = 10;
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.ReadOnly = true;
            dataGridViewTextBoxColumn1.Visible = false;
            dataGridViewTextBoxColumn1.Width = 200;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn2.HeaderText = "Phone Type";
            dataGridViewTextBoxColumn2.MinimumWidth = 10;
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // Column10
            // 
            Column10.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Column10.HeaderText = "Phone";
            Column10.MinimumWidth = 10;
            Column10.Name = "Column10";
            Column10.ReadOnly = true;
            // 
            // PhoneTypeId
            // 
            PhoneTypeId.HeaderText = "PhoneTypeId";
            PhoneTypeId.MinimumWidth = 10;
            PhoneTypeId.Name = "PhoneTypeId";
            PhoneTypeId.ReadOnly = true;
            PhoneTypeId.Visible = false;
            PhoneTypeId.Width = 200;
            // 
            // btnOk
            // 
            btnOk.BackgroundImage = (Image)resources.GetObject("btnOk.BackgroundImage");
            btnOk.Location = new Point(993, 781);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(209, 96);
            btnOk.TabIndex = 2;
            btnOk.Text = "Save";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click_1;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.IndianRed;
            btnCancel.ForeColor = SystemColors.ButtonHighlight;
            btnCancel.Location = new Point(1277, 779);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(209, 96);
            btnCancel.TabIndex = 3;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // frmCustomersAE
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(1520, 918);
            Controls.Add(btnOk);
            Controls.Add(btnCancel);
            Controls.Add(tabAddresses);
            Name = "frmCustomersAE";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmCustomersAE";
            tabAddresses.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgv).EndInit();
            btnEditAddresses.ResumeLayout(false);
            btnEditAddresses.PerformLayout();
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
            toolStrip2.ResumeLayout(false);
            toolStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPhones).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabAddresses;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Button btnOk;
        private Button btnCancel;
        private TabPage tabPage3;
        private ToolStrip btnEditAddresses;
        private ToolStripButton btnAdd;
        private ToolStripButton btnDelete;
        private ToolStripButton btnEdit;
        private ToolStripButton btnClose;
        private ErrorProvider errorProvider1;
        private Label label3;
        private Label label6;
        private Label label4;
        private TextBox txtDocumentNum;
        private TextBox txtLastName;
        private TextBox txtFirstName;
        private ToolStrip toolStrip2;
        private ToolStripButton btnAddPhone;
        private ToolStripButton toolStripButton2;
        private ToolStripButton btnEditPhones;
        private ToolStripButton toolStripButton4;
        private DataGridView dgvPhones;
        private Label lblAddresses;
        private Label lblPhones;
        private DataGridView dgv;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colType;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn Column6;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn Column10;
        private DataGridViewTextBoxColumn PhoneTypeId;
    }
}