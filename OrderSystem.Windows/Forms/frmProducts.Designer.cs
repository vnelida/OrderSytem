namespace Windows.Forms
{
    partial class frmProducts
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProducts));
            BottomToolStripPanel = new ToolStripPanel();
            TopToolStripPanel = new ToolStripPanel();
            RightToolStripPanel = new ToolStripPanel();
            LeftToolStripPanel = new ToolStripPanel();
            ContentPanel = new ToolStripContentPanel();
            toolStrip1 = new ToolStrip();
            btnOrder = new ToolStripDropDownButton();
            productAZToolStripMenuItem = new ToolStripMenuItem();
            productZAToolStripMenuItem = new ToolStripMenuItem();
            categoryAZToolStripMenuItem = new ToolStripMenuItem();
            categoryZAToolStripMenuItem = new ToolStripMenuItem();
            btnFilter = new ToolStripComboBox();
            dgv = new DataGridView();
            colProductName = new DataGridViewTextBoxColumn();
            colDescription = new DataGridViewTextBoxColumn();
            colCategory = new DataGridViewTextBoxColumn();
            colCostPrice = new DataGridViewTextBoxColumn();
            colSalePrice = new DataGridViewTextBoxColumn();
            colStock = new DataGridViewTextBoxColumn();
            colReorderLevel = new DataGridViewTextBoxColumn();
            colSuspended = new DataGridViewTextBoxColumn();
            colId = new DataGridViewTextBoxColumn();
            panelNavegacion = new Panel();
            btnLast = new Button();
            btnNext = new Button();
            btnPrevious = new Button();
            btnFirst = new Button();
            txtPageCount = new TextBox();
            cboPages = new ComboBox();
            label2 = new Label();
            label1 = new Label();
            panelGrilla = new Panel();
            btnNew = new ToolStripButton();
            btnDelete = new ToolStripButton();
            btnEdit = new ToolStripButton();
            btnRefresh = new ToolStripButton();
            btnClose = new ToolStripButton();
            toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv).BeginInit();
            panelNavegacion.SuspendLayout();
            panelGrilla.SuspendLayout();
            SuspendLayout();
            // 
            // BottomToolStripPanel
            // 
            BottomToolStripPanel.Location = new Point(0, 0);
            BottomToolStripPanel.Name = "BottomToolStripPanel";
            BottomToolStripPanel.Orientation = Orientation.Horizontal;
            BottomToolStripPanel.RowMargin = new Padding(6, 0, 0, 0);
            BottomToolStripPanel.Size = new Size(0, 0);
            // 
            // TopToolStripPanel
            // 
            TopToolStripPanel.Location = new Point(0, 0);
            TopToolStripPanel.Name = "TopToolStripPanel";
            TopToolStripPanel.Orientation = Orientation.Horizontal;
            TopToolStripPanel.RowMargin = new Padding(6, 0, 0, 0);
            TopToolStripPanel.Size = new Size(0, 0);
            // 
            // RightToolStripPanel
            // 
            RightToolStripPanel.Location = new Point(0, 0);
            RightToolStripPanel.Name = "RightToolStripPanel";
            RightToolStripPanel.Orientation = Orientation.Horizontal;
            RightToolStripPanel.RowMargin = new Padding(6, 0, 0, 0);
            RightToolStripPanel.Size = new Size(0, 0);
            // 
            // LeftToolStripPanel
            // 
            LeftToolStripPanel.Location = new Point(0, 0);
            LeftToolStripPanel.Name = "LeftToolStripPanel";
            LeftToolStripPanel.Orientation = Orientation.Horizontal;
            LeftToolStripPanel.RowMargin = new Padding(6, 0, 0, 0);
            LeftToolStripPanel.Size = new Size(0, 0);
            // 
            // ContentPanel
            // 
            ContentPanel.Size = new Size(1322, 608);
            // 
            // toolStrip1
            // 
            toolStrip1.BackColor = Color.White;
            toolStrip1.ImageScalingSize = new Size(32, 32);
            toolStrip1.Items.AddRange(new ToolStripItem[] { btnClose, btnNew, btnDelete, btnEdit, btnOrder, btnFilter, btnRefresh });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1974, 106);
            toolStrip1.TabIndex = 6;
            toolStrip1.Text = "toolStrip1";
            // 
            // btnOrder
            // 
            btnOrder.DropDownItems.AddRange(new ToolStripItem[] { productAZToolStripMenuItem, productZAToolStripMenuItem, categoryAZToolStripMenuItem, categoryZAToolStripMenuItem });
            btnOrder.Image = (Image)resources.GetObject("btnOrder.Image");
            btnOrder.ImageScaling = ToolStripItemImageScaling.None;
            btnOrder.Name = "btnOrder";
            btnOrder.Size = new Size(97, 100);
            btnOrder.Text = "Order";
            btnOrder.TextImageRelation = TextImageRelation.ImageAboveText;
            // 
            // productAZToolStripMenuItem
            // 
            productAZToolStripMenuItem.Name = "productAZToolStripMenuItem";
            productAZToolStripMenuItem.Size = new Size(359, 44);
            productAZToolStripMenuItem.Text = "Product A-Z";
            productAZToolStripMenuItem.Click += productAZToolStripMenuItem_Click;
            // 
            // productZAToolStripMenuItem
            // 
            productZAToolStripMenuItem.Name = "productZAToolStripMenuItem";
            productZAToolStripMenuItem.Size = new Size(359, 44);
            productZAToolStripMenuItem.Text = "Product Z-A";
            productZAToolStripMenuItem.Click += productZAToolStripMenuItem_Click;
            // 
            // categoryAZToolStripMenuItem
            // 
            categoryAZToolStripMenuItem.Name = "categoryAZToolStripMenuItem";
            categoryAZToolStripMenuItem.Size = new Size(359, 44);
            categoryAZToolStripMenuItem.Text = "Sale Price";
            categoryAZToolStripMenuItem.Click += salePriceToolStripMenuItem_Click;
            // 
            // categoryZAToolStripMenuItem
            // 
            categoryZAToolStripMenuItem.Name = "categoryZAToolStripMenuItem";
            categoryZAToolStripMenuItem.Size = new Size(359, 44);
            categoryZAToolStripMenuItem.Text = "Sale Price DESC";
            categoryZAToolStripMenuItem.Click += salePriceDescToolStripMenuItem_Click;
            // 
            // btnFilter
            // 
            btnFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            btnFilter.Name = "btnFilter";
            btnFilter.Size = new Size(130, 106);
            btnFilter.SelectedIndexChanged += btnFilter_SelectedIndexChanged;
            // 
            // dgv
            // 
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.BackgroundColor = Color.White;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv.Columns.AddRange(new DataGridViewColumn[] { colProductName, colDescription, colCategory, colCostPrice, colSalePrice, colStock, colReorderLevel, colSuspended, colId });
            dgv.Dock = DockStyle.Fill;
            dgv.Location = new Point(0, 0);
            dgv.Name = "dgv";
            dgv.ReadOnly = true;
            dgv.RowHeadersVisible = false;
            dgv.RowHeadersWidth = 82;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.Size = new Size(1974, 1223);
            dgv.TabIndex = 7;
            // 
            // colProductName
            // 
            colProductName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colProductName.HeaderText = "Product Name";
            colProductName.MinimumWidth = 10;
            colProductName.Name = "colProductName";
            colProductName.ReadOnly = true;
            // 
            // colDescription
            // 
            colDescription.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colDescription.HeaderText = "Description";
            colDescription.MinimumWidth = 10;
            colDescription.Name = "colDescription";
            colDescription.ReadOnly = true;
            // 
            // colCategory
            // 
            colCategory.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colCategory.HeaderText = "Category";
            colCategory.MinimumWidth = 10;
            colCategory.Name = "colCategory";
            colCategory.ReadOnly = true;
            // 
            // colCostPrice
            // 
            colCostPrice.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colCostPrice.HeaderText = "Cost Price";
            colCostPrice.MinimumWidth = 10;
            colCostPrice.Name = "colCostPrice";
            colCostPrice.ReadOnly = true;
            // 
            // colSalePrice
            // 
            colSalePrice.HeaderText = "Sale Price";
            colSalePrice.MinimumWidth = 10;
            colSalePrice.Name = "colSalePrice";
            colSalePrice.ReadOnly = true;
            colSalePrice.Width = 200;
            // 
            // colStock
            // 
            colStock.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colStock.HeaderText = "Stock";
            colStock.MinimumWidth = 10;
            colStock.Name = "colStock";
            colStock.ReadOnly = true;
            // 
            // colReorderLevel
            // 
            colReorderLevel.HeaderText = "Reorder Level";
            colReorderLevel.MinimumWidth = 10;
            colReorderLevel.Name = "colReorderLevel";
            colReorderLevel.ReadOnly = true;
            colReorderLevel.Width = 200;
            // 
            // colSuspended
            // 
            colSuspended.HeaderText = "Suspended";
            colSuspended.MinimumWidth = 10;
            colSuspended.Name = "colSuspended";
            colSuspended.ReadOnly = true;
            colSuspended.Width = 200;
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
            // panelNavegacion
            // 
            panelNavegacion.BackColor = Color.DarkSeaGreen;
            panelNavegacion.BackgroundImage = (Image)resources.GetObject("panelNavegacion.BackgroundImage");
            panelNavegacion.Controls.Add(btnLast);
            panelNavegacion.Controls.Add(btnNext);
            panelNavegacion.Controls.Add(btnPrevious);
            panelNavegacion.Controls.Add(btnFirst);
            panelNavegacion.Controls.Add(txtPageCount);
            panelNavegacion.Controls.Add(cboPages);
            panelNavegacion.Controls.Add(label2);
            panelNavegacion.Controls.Add(label1);
            panelNavegacion.Dock = DockStyle.Bottom;
            panelNavegacion.Location = new Point(0, 1207);
            panelNavegacion.Margin = new Padding(6);
            panelNavegacion.Name = "panelNavegacion";
            panelNavegacion.Size = new Size(1974, 122);
            panelNavegacion.TabIndex = 12;
            // 
            // btnLast
            // 
            btnLast.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLast.BackgroundImage = (Image)resources.GetObject("btnLast.BackgroundImage");
            btnLast.BackgroundImageLayout = ImageLayout.Center;
            btnLast.Location = new Point(1833, 34);
            btnLast.Margin = new Padding(6);
            btnLast.Name = "btnLast";
            btnLast.Size = new Size(74, 58);
            btnLast.TabIndex = 28;
            btnLast.UseVisualStyleBackColor = true;
            btnLast.Click += btnLast_Click;
            // 
            // btnNext
            // 
            btnNext.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnNext.BackgroundImage = (Image)resources.GetObject("btnNext.BackgroundImage");
            btnNext.BackgroundImageLayout = ImageLayout.Center;
            btnNext.Location = new Point(1683, 34);
            btnNext.Margin = new Padding(6);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(74, 58);
            btnNext.TabIndex = 29;
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += btnNext_Click;
            // 
            // btnPrevious
            // 
            btnPrevious.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnPrevious.BackgroundImage = (Image)resources.GetObject("btnPrevious.BackgroundImage");
            btnPrevious.BackgroundImageLayout = ImageLayout.Center;
            btnPrevious.Location = new Point(1532, 34);
            btnPrevious.Margin = new Padding(6);
            btnPrevious.Name = "btnPrevious";
            btnPrevious.Size = new Size(74, 58);
            btnPrevious.TabIndex = 30;
            btnPrevious.UseVisualStyleBackColor = true;
            btnPrevious.Click += btnPreviousr_Click;
            // 
            // btnFirst
            // 
            btnFirst.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnFirst.BackgroundImage = (Image)resources.GetObject("btnFirst.BackgroundImage");
            btnFirst.BackgroundImageLayout = ImageLayout.Center;
            btnFirst.Location = new Point(1382, 34);
            btnFirst.Margin = new Padding(6);
            btnFirst.Name = "btnFirst";
            btnFirst.Size = new Size(74, 58);
            btnFirst.TabIndex = 31;
            btnFirst.UseVisualStyleBackColor = true;
            btnFirst.Click += btnFirst_Click;
            // 
            // txtPageCount
            // 
            txtPageCount.Location = new Point(311, 43);
            txtPageCount.Margin = new Padding(6);
            txtPageCount.Name = "txtPageCount";
            txtPageCount.ReadOnly = true;
            txtPageCount.Size = new Size(123, 39);
            txtPageCount.TabIndex = 27;
            // 
            // cboPages
            // 
            cboPages.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPages.FormattingEnabled = true;
            cboPages.Location = new Point(118, 44);
            cboPages.Margin = new Padding(6);
            cboPages.Name = "cboPages";
            cboPages.Size = new Size(123, 40);
            cboPages.TabIndex = 26;
            cboPages.SelectedIndexChanged += cboPages_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(263, 50);
            label2.Margin = new Padding(6, 0, 6, 0);
            label2.Name = "label2";
            label2.Size = new Size(36, 32);
            label2.TabIndex = 24;
            label2.Text = "of";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(41, 50);
            label1.Margin = new Padding(6, 0, 6, 0);
            label1.Name = "label1";
            label1.Size = new Size(65, 32);
            label1.TabIndex = 25;
            label1.Text = "Page";
            // 
            // panelGrilla
            // 
            panelGrilla.Controls.Add(dgv);
            panelGrilla.Dock = DockStyle.Fill;
            panelGrilla.Location = new Point(0, 106);
            panelGrilla.Margin = new Padding(6);
            panelGrilla.Name = "panelGrilla";
            panelGrilla.Size = new Size(1974, 1223);
            panelGrilla.TabIndex = 11;
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
            // frmProducts
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Ivory;
            ClientSize = new Size(1974, 1329);
            ControlBox = false;
            Controls.Add(panelNavegacion);
            Controls.Add(panelGrilla);
            Controls.Add(toolStrip1);
            MaximumSize = new Size(2000, 1400);
            MinimizeBox = false;
            MinimumSize = new Size(2000, 1400);
            Name = "frmProducts";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmProducts";
            Load += frmProducts_Load;
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgv).EndInit();
            panelNavegacion.ResumeLayout(false);
            panelNavegacion.PerformLayout();
            panelGrilla.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStripPanel BottomToolStripPanel;
        private ToolStripPanel TopToolStripPanel;
        private ToolStripPanel RightToolStripPanel;
        private ToolStripPanel LeftToolStripPanel;
        private ToolStripContentPanel ContentPanel;
        private ToolStrip toolStrip1;
        private DataGridView dgv;
        private Panel panelNavegacion;
        private TextBox txtPageCount;
        private ComboBox cboPages;
        private Label label2;
        private Label label1;
        private Panel panelGrilla;
        private Button btnLast;
        private Button btnNext;
        private Button btnPrevious;
        private Button btnFirst;
        private ToolStripDropDownButton btnOrder;
        private ToolStripMenuItem productAZToolStripMenuItem;
        private ToolStripMenuItem productZAToolStripMenuItem;
        private ToolStripMenuItem categoryAZToolStripMenuItem;
        private ToolStripMenuItem categoryZAToolStripMenuItem;
        private DataGridViewTextBoxColumn colProductName;
        private DataGridViewTextBoxColumn colDescription;
        private DataGridViewTextBoxColumn colCategory;
        private DataGridViewTextBoxColumn colCostPrice;
        private DataGridViewTextBoxColumn colSalePrice;
        private DataGridViewTextBoxColumn colStock;
        private DataGridViewTextBoxColumn colReorderLevel;
        private DataGridViewTextBoxColumn colSuspended;
        private DataGridViewTextBoxColumn colId;
        private ToolStripComboBox btnFilter;
        private ToolStripButton btnClose;
        private ToolStripButton btnNew;
        private ToolStripButton btnDelete;
        private ToolStripButton btnEdit;
        private ToolStripButton btnRefresh;
    }
}