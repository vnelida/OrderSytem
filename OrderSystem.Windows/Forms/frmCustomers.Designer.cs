namespace Windows.Forms
{
    partial class frmCustomers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCustomers));
            toolStrip1 = new ToolStrip();
            btnNew = new ToolStripButton();
            btnDelete = new ToolStripButton();
            btnEdit = new ToolStripButton();
            btnOrder = new ToolStripDropDownButton();
            NameAZ = new ToolStripMenuItem();
            NameZA = new ToolStripMenuItem();
            btnRefresh = new ToolStripButton();
            btnClose = new ToolStripButton();
            splitContainer1 = new SplitContainer();
            dgvDatos = new DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colDocument = new DataGridViewTextBoxColumn();
            colCostumer = new DataGridViewTextBoxColumn();
            colAddress = new DataGridViewTextBoxColumn();
            colPhone = new DataGridViewTextBoxColumn();
            btnLast = new Button();
            btnNext = new Button();
            btnPrevious = new Button();
            btnFirst = new Button();
            txtPageCount = new TextBox();
            cboPages = new ComboBox();
            label2 = new Label();
            label1 = new Label();
            toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDatos).BeginInit();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.BackColor = SystemColors.ButtonHighlight;
            toolStrip1.ImageScalingSize = new Size(32, 32);
            toolStrip1.Items.AddRange(new ToolStripItem[] { btnNew, btnDelete, btnEdit, btnOrder, btnRefresh, btnClose });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1974, 106);
            toolStrip1.TabIndex = 1;
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
            // 
            // btnOrder
            // 
            btnOrder.DropDownItems.AddRange(new ToolStripItem[] { NameAZ, NameZA });
            btnOrder.Image = (Image)resources.GetObject("btnOrder.Image");
            btnOrder.ImageScaling = ToolStripItemImageScaling.None;
            btnOrder.Name = "btnOrder";
            btnOrder.Size = new Size(97, 100);
            btnOrder.Text = "Order";
            btnOrder.TextImageRelation = TextImageRelation.ImageAboveText;
            // 
            // NameAZ
            // 
            NameAZ.Name = "NameAZ";
            NameAZ.Size = new Size(360, 44);
            NameAZ.Text = "Category Name A-Z";
            // 
            // NameZA
            // 
            NameZA.Name = "NameZA";
            NameZA.Size = new Size(360, 44);
            NameZA.Text = "Category Name Z-A";
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
            splitContainer1.Panel1.Controls.Add(dgvDatos);
            // 
            // splitContainer1.Panel2
            // 
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
            splitContainer1.SplitterDistance = 1101;
            splitContainer1.TabIndex = 2;
            // 
            // dgvDatos
            // 
            dgvDatos.AllowUserToAddRows = false;
            dgvDatos.AllowUserToDeleteRows = false;
            dgvDatos.BackgroundColor = Color.White;
            dgvDatos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDatos.Columns.AddRange(new DataGridViewColumn[] { colId, colDocument, colCostumer, colAddress, colPhone });
            dgvDatos.Dock = DockStyle.Fill;
            dgvDatos.Location = new Point(0, 0);
            dgvDatos.MultiSelect = false;
            dgvDatos.Name = "dgvDatos";
            dgvDatos.ReadOnly = true;
            dgvDatos.RowHeadersVisible = false;
            dgvDatos.RowHeadersWidth = 82;
            dgvDatos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDatos.Size = new Size(1974, 1101);
            dgvDatos.TabIndex = 8;
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
            // colDocument
            // 
            colDocument.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colDocument.HeaderText = "Document";
            colDocument.MinimumWidth = 10;
            colDocument.Name = "colDocument";
            colDocument.ReadOnly = true;
            // 
            // colCostumer
            // 
            colCostumer.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colCostumer.HeaderText = "Costumer";
            colCostumer.MinimumWidth = 10;
            colCostumer.Name = "colCostumer";
            colCostumer.ReadOnly = true;
            // 
            // colAddress
            // 
            colAddress.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colAddress.HeaderText = "Address";
            colAddress.MinimumWidth = 10;
            colAddress.Name = "colAddress";
            colAddress.ReadOnly = true;
            // 
            // colPhone
            // 
            colPhone.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colPhone.HeaderText = "Phone";
            colPhone.MinimumWidth = 10;
            colPhone.Name = "colPhone";
            colPhone.ReadOnly = true;
            // 
            // btnLast
            // 
            btnLast.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLast.Image = (Image)resources.GetObject("btnLast.Image");
            btnLast.Location = new Point(1847, 31);
            btnLast.Margin = new Padding(6);
            btnLast.Name = "btnLast";
            btnLast.Size = new Size(74, 58);
            btnLast.TabIndex = 19;
            btnLast.UseVisualStyleBackColor = true;
            btnLast.Click += btnLast_Click;
            // 
            // btnNext
            // 
            btnNext.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnNext.Image = (Image)resources.GetObject("btnNext.Image");
            btnNext.Location = new Point(1718, 31);
            btnNext.Margin = new Padding(6);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(74, 58);
            btnNext.TabIndex = 18;
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += btnNext_Click;
            // 
            // btnPrevious
            // 
            btnPrevious.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnPrevious.Image = (Image)resources.GetObject("btnPrevious.Image");
            btnPrevious.Location = new Point(1577, 31);
            btnPrevious.Margin = new Padding(6);
            btnPrevious.Name = "btnPrevious";
            btnPrevious.Size = new Size(74, 58);
            btnPrevious.TabIndex = 17;
            btnPrevious.UseVisualStyleBackColor = true;
            btnPrevious.Click += btnPrevious_Click;
            // 
            // btnFirst
            // 
            btnFirst.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnFirst.Image = (Image)resources.GetObject("btnFirst.Image");
            btnFirst.Location = new Point(1457, 31);
            btnFirst.Margin = new Padding(6);
            btnFirst.Name = "btnFirst";
            btnFirst.Size = new Size(74, 58);
            btnFirst.TabIndex = 16;
            btnFirst.UseVisualStyleBackColor = true;
            btnFirst.Click += btnFirst_Click;
            // 
            // txtPageCount
            // 
            txtPageCount.Location = new Point(329, 30);
            txtPageCount.Margin = new Padding(6);
            txtPageCount.Name = "txtPageCount";
            txtPageCount.ReadOnly = true;
            txtPageCount.Size = new Size(123, 39);
            txtPageCount.TabIndex = 23;
            // 
            // cboPages
            // 
            cboPages.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPages.FormattingEnabled = true;
            cboPages.Location = new Point(136, 31);
            cboPages.Margin = new Padding(6);
            cboPages.Name = "cboPages";
            cboPages.Size = new Size(123, 40);
            cboPages.TabIndex = 21;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(281, 37);
            label2.Margin = new Padding(6, 0, 6, 0);
            label2.Name = "label2";
            label2.Size = new Size(36, 32);
            label2.TabIndex = 22;
            label2.Text = "of";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(54, 37);
            label1.Margin = new Padding(6, 0, 6, 0);
            label1.Name = "label1";
            label1.Size = new Size(65, 32);
            label1.TabIndex = 20;
            label1.Text = "Page";
            // 
            // frmCustomers
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1974, 1329);
            Controls.Add(splitContainer1);
            Controls.Add(toolStrip1);
            MaximumSize = new Size(2000, 1400);
            MinimumSize = new Size(2000, 1400);
            Name = "frmCustomers";
            Text = "frmCustomers";
            Load += frmCustomers_Load;
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvDatos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip toolStrip1;
        private ToolStripButton btnNew;
        private ToolStripButton btnDelete;
        private ToolStripButton btnEdit;
        private ToolStripDropDownButton btnOrder;
        private ToolStripMenuItem NameAZ;
        private ToolStripMenuItem NameZA;
        private ToolStripButton btnRefresh;
        private ToolStripButton btnClose;
        private SplitContainer splitContainer1;
        private Button btnLast;
        private Button btnNext;
        private Button btnPrevious;
        private Button btnFirst;
        private TextBox txtPageCount;
        private ComboBox cboPages;
        private Label label2;
        private Label label1;
        private DataGridView dgvDatos;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colDocument;
        private DataGridViewTextBoxColumn colCostumer;
        private DataGridViewTextBoxColumn colAddress;
        private DataGridViewTextBoxColumn colPhone;
    }
}