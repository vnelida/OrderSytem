﻿namespace Windows.Forms
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
            toolStrip1 = new ToolStrip();
            btnNew = new ToolStripButton();
            btnDelete = new ToolStripButton();
            btnEdit = new ToolStripButton();
            btnClose = new ToolStripButton();
            btnOrder = new ToolStripDropDownButton();
            firstNameAZ = new ToolStripMenuItem();
            firstNameZA = new ToolStripMenuItem();
            lastNameAZ = new ToolStripMenuItem();
            lastNameZA = new ToolStripMenuItem();
            btnFilter = new ToolStripComboBox();
            btnRefresh = new ToolStripButton();
            splitContainer1 = new SplitContainer();
            btnLast = new Button();
            btnNext = new Button();
            btnPrevious = new Button();
            btnFirst = new Button();
            txtPageCount = new TextBox();
            cboPages = new ComboBox();
            label2 = new Label();
            label1 = new Label();
            colEmployeeId = new DataGridViewTextBoxColumn();
            colFirstName = new DataGridViewTextBoxColumn();
            colLastName = new DataGridViewTextBoxColumn();
            colPhone = new DataGridViewTextBoxColumn();
            colEmail = new DataGridViewTextBoxColumn();
            colAddress = new DataGridViewTextBoxColumn();
            colDNI = new DataGridViewTextBoxColumn();
            colDate = new DataGridViewTextBoxColumn();
            colGenre = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgv).BeginInit();
            toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // dgv
            // 
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.BackgroundColor = SystemColors.ButtonHighlight;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv.Columns.AddRange(new DataGridViewColumn[] { colEmployeeId, colFirstName, colLastName, colPhone, colEmail, colAddress, colDNI, colDate, colGenre });
            dgv.Dock = DockStyle.Fill;
            dgv.Location = new Point(0, 0);
            dgv.MultiSelect = false;
            dgv.Name = "dgv";
            dgv.ReadOnly = true;
            dgv.RowHeadersVisible = false;
            dgv.RowHeadersWidth = 82;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.Size = new Size(1974, 1119);
            dgv.TabIndex = 3;
            // 
            // toolStrip1
            // 
            toolStrip1.BackColor = SystemColors.ButtonHighlight;
            toolStrip1.ImageScalingSize = new Size(32, 32);
            toolStrip1.Items.AddRange(new ToolStripItem[] { btnNew, btnDelete, btnEdit, btnClose, btnOrder, btnFilter, btnRefresh });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1974, 106);
            toolStrip1.TabIndex = 2;
            toolStrip1.Text = "toolStrip1";
            // 
            // btnNew
            // 
            btnNew.Image = (Image)resources.GetObject("btnNew.Image");
            btnNew.ImageScaling = ToolStripItemImageScaling.None;
            btnNew.ImageTransparentColor = Color.Magenta;
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(68, 100);
            btnNew.Text = "New";
            btnNew.TextImageRelation = TextImageRelation.ImageAboveText;
            btnNew.Click += btnNew_Click;
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
            btnDelete.Click += btnDelete_Click;
            // 
            // btnEdit
            // 
            btnEdit.Image = (Image)resources.GetObject("btnEdit.Image");
            btnEdit.ImageScaling = ToolStripItemImageScaling.None;
            btnEdit.ImageTransparentColor = Color.Magenta;
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(68, 100);
            btnEdit.Text = "Edit";
            btnEdit.TextImageRelation = TextImageRelation.ImageAboveText;
            btnEdit.Click += btnEdit_Click;
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
            // btnOrder
            // 
            btnOrder.DropDownItems.AddRange(new ToolStripItem[] { firstNameAZ, firstNameZA, lastNameAZ, lastNameZA });
            btnOrder.Image = (Image)resources.GetObject("btnOrder.Image");
            btnOrder.ImageScaling = ToolStripItemImageScaling.None;
            btnOrder.Name = "btnOrder";
            btnOrder.Size = new Size(97, 100);
            btnOrder.Text = "Order";
            btnOrder.TextImageRelation = TextImageRelation.ImageAboveText;
            // 
            // firstNameAZ
            // 
            firstNameAZ.Name = "firstNameAZ";
            firstNameAZ.Size = new Size(308, 44);
            firstNameAZ.Text = "Fisrt Name A-Z";
            firstNameAZ.Click += firstNameAZ_Click;
            // 
            // firstNameZA
            // 
            firstNameZA.Name = "firstNameZA";
            firstNameZA.Size = new Size(308, 44);
            firstNameZA.Text = "First Name Z-A";
            firstNameZA.Click += firstNameZA_Click;
            // 
            // lastNameAZ
            // 
            lastNameAZ.Name = "lastNameAZ";
            lastNameAZ.Size = new Size(308, 44);
            lastNameAZ.Text = "Last Name A-Z";
            lastNameAZ.Click += lastNameAZ_Click;
            // 
            // lastNameZA
            // 
            lastNameZA.Name = "lastNameZA";
            lastNameZA.Size = new Size(308, 44);
            lastNameZA.Text = "Last Name Z-A";
            lastNameZA.Click += lastNameZA_Click;
            // 
            // btnFilter
            // 
            btnFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            btnFilter.Name = "btnFilter";
            btnFilter.Size = new Size(130, 106);
            btnFilter.SelectedIndexChanged += btnFilter_SelectedIndexChanged;
            btnFilter.Click += btnFilter_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.Image = (Image)resources.GetObject("btnRefresh.Image");
            btnRefresh.ImageScaling = ToolStripItemImageScaling.None;
            btnRefresh.ImageTransparentColor = Color.Magenta;
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(97, 100);
            btnRefresh.Text = "Refresh";
            btnRefresh.TextImageRelation = TextImageRelation.ImageAboveText;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 106);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(dgv);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.BackColor = SystemColors.ButtonHighlight;
            splitContainer1.Panel2.BackgroundImage = (Image)resources.GetObject("splitContainer1.Panel2.BackgroundImage");
            splitContainer1.Panel2.Controls.Add(btnLast);
            splitContainer1.Panel2.Controls.Add(btnNext);
            splitContainer1.Panel2.Controls.Add(btnPrevious);
            splitContainer1.Panel2.Controls.Add(btnFirst);
            splitContainer1.Panel2.Controls.Add(txtPageCount);
            splitContainer1.Panel2.Controls.Add(cboPages);
            splitContainer1.Panel2.Controls.Add(label2);
            splitContainer1.Panel2.Controls.Add(label1);
            splitContainer1.Size = new Size(1974, 1223);
            splitContainer1.SplitterDistance = 1119;
            splitContainer1.TabIndex = 4;
            // 
            // btnLast
            // 
            btnLast.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLast.Image = (Image)resources.GetObject("btnLast.Image");
            btnLast.Location = new Point(1846, 23);
            btnLast.Margin = new Padding(6);
            btnLast.Name = "btnLast";
            btnLast.Size = new Size(74, 58);
            btnLast.TabIndex = 36;
            btnLast.UseVisualStyleBackColor = true;
            btnLast.Click += btnLast_Click;
            // 
            // btnNext
            // 
            btnNext.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnNext.Image = (Image)resources.GetObject("btnNext.Image");
            btnNext.Location = new Point(1696, 23);
            btnNext.Margin = new Padding(6);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(74, 58);
            btnNext.TabIndex = 37;
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += btnNext_Click;
            // 
            // btnPrevious
            // 
            btnPrevious.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnPrevious.Image = (Image)resources.GetObject("btnPrevious.Image");
            btnPrevious.Location = new Point(1545, 23);
            btnPrevious.Margin = new Padding(6);
            btnPrevious.Name = "btnPrevious";
            btnPrevious.Size = new Size(74, 58);
            btnPrevious.TabIndex = 38;
            btnPrevious.UseVisualStyleBackColor = true;
            btnPrevious.Click += btnPrevious_Click;
            // 
            // btnFirst
            // 
            btnFirst.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnFirst.Image = (Image)resources.GetObject("btnFirst.Image");
            btnFirst.Location = new Point(1395, 23);
            btnFirst.Margin = new Padding(6);
            btnFirst.Name = "btnFirst";
            btnFirst.Size = new Size(74, 58);
            btnFirst.TabIndex = 39;
            btnFirst.UseVisualStyleBackColor = true;
            btnFirst.Click += btnFirst_Click;
            // 
            // txtPageCount
            // 
            txtPageCount.Location = new Point(324, 32);
            txtPageCount.Margin = new Padding(6);
            txtPageCount.Name = "txtPageCount";
            txtPageCount.ReadOnly = true;
            txtPageCount.Size = new Size(123, 39);
            txtPageCount.TabIndex = 35;
            // 
            // cboPages
            // 
            cboPages.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPages.FormattingEnabled = true;
            cboPages.Location = new Point(131, 33);
            cboPages.Margin = new Padding(6);
            cboPages.Name = "cboPages";
            cboPages.Size = new Size(123, 40);
            cboPages.TabIndex = 34;
            cboPages.SelectedIndexChanged += cboPages_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(276, 39);
            label2.Margin = new Padding(6, 0, 6, 0);
            label2.Name = "label2";
            label2.Size = new Size(36, 32);
            label2.TabIndex = 32;
            label2.Text = "of";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(54, 39);
            label1.Margin = new Padding(6, 0, 6, 0);
            label1.Name = "label1";
            label1.Size = new Size(65, 32);
            label1.TabIndex = 33;
            label1.Text = "Page";
            // 
            // colEmployeeId
            // 
            colEmployeeId.HeaderText = "EmployeeId";
            colEmployeeId.MinimumWidth = 10;
            colEmployeeId.Name = "colEmployeeId";
            colEmployeeId.ReadOnly = true;
            colEmployeeId.Visible = false;
            colEmployeeId.Width = 200;
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
            // colDNI
            // 
            colDNI.HeaderText = "DNI";
            colDNI.MinimumWidth = 10;
            colDNI.Name = "colDNI";
            colDNI.ReadOnly = true;
            colDNI.Width = 200;
            // 
            // colDate
            // 
            colDate.HeaderText = "Date of Birth";
            colDate.MinimumWidth = 10;
            colDate.Name = "colDate";
            colDate.ReadOnly = true;
            colDate.Width = 200;
            // 
            // colGenre
            // 
            colGenre.HeaderText = "Genre";
            colGenre.MinimumWidth = 10;
            colGenre.Name = "colGenre";
            colGenre.ReadOnly = true;
            colGenre.Width = 200;
            // 
            // frmEmployees
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1974, 1329);
            ControlBox = false;
            Controls.Add(splitContainer1);
            Controls.Add(toolStrip1);
            MaximumSize = new Size(2000, 1400);
            MinimumSize = new Size(2000, 1400);
            Name = "frmEmployees";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmEmployees";
            Load += frmEmployees_Load;
            ((System.ComponentModel.ISupportInitialize)dgv).EndInit();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgv;
        private ToolStrip toolStrip1;
        private SplitContainer splitContainer1;
        private Button btnLast;
        private Button btnNext;
        private Button btnPrevious;
        private Button btnFirst;
        private TextBox txtPageCount;
        private ComboBox cboPages;
        private Label label2;
        private Label label1;
        private ToolStripDropDownButton btnOrder;
        private ToolStripMenuItem firstNameAZ;
        private ToolStripMenuItem firstNameZA;
        private ToolStripMenuItem lastNameAZ;
        private ToolStripMenuItem lastNameZA;
        private ToolStripComboBox btnFilter;
        private ToolStripButton btnNew;
        private ToolStripButton btnDelete;
        private ToolStripButton btnEdit;
        private ToolStripButton btnClose;
        private ToolStripButton btnRefresh;
        private DataGridViewTextBoxColumn colEmployeeId;
        private DataGridViewTextBoxColumn colFirstName;
        private DataGridViewTextBoxColumn colLastName;
        private DataGridViewTextBoxColumn colPhone;
        private DataGridViewTextBoxColumn colEmail;
        private DataGridViewTextBoxColumn colAddress;
        private DataGridViewTextBoxColumn colDNI;
        private DataGridViewTextBoxColumn colDate;
        private DataGridViewTextBoxColumn colGenre;
    }
}