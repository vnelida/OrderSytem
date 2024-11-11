namespace Windows.Forms
{
    partial class frmCombos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCombos));
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
            dgv = new DataGridView();
            colComboName = new DataGridViewTextBoxColumn();
            colDescription = new DataGridViewTextBoxColumn();
            colSize = new DataGridViewTextBoxColumn();
            colCostPrice = new DataGridViewTextBoxColumn();
            colSalePrice = new DataGridViewTextBoxColumn();
            colStock = new DataGridViewTextBoxColumn();
            colReorderLevel = new DataGridViewTextBoxColumn();
            colSuspended = new DataGridViewTextBoxColumn();
            colStartDate = new DataGridViewTextBoxColumn();
            colEndDate = new DataGridViewTextBoxColumn();
            colId = new DataGridViewTextBoxColumn();
            toolStrip1 = new ToolStrip();
            btnNew = new ToolStripButton();
            btnDelete = new ToolStripButton();
            btnEdit = new ToolStripButton();
            btnOrder = new ToolStripDropDownButton();
            productAZToolStripMenuItem = new ToolStripMenuItem();
            productZAToolStripMenuItem = new ToolStripMenuItem();
            categoryAZToolStripMenuItem = new ToolStripMenuItem();
            categoryZAToolStripMenuItem = new ToolStripMenuItem();
            btnFilter = new ToolStripButton();
            btnClose = new ToolStripButton();
            btnRefresh = new ToolStripButton();
            panelNavegacion.SuspendLayout();
            panelGrilla.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv).BeginInit();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // panelNavegacion
            // 
            panelNavegacion.Controls.Add(btnLast);
            panelNavegacion.Controls.Add(btnNext);
            panelNavegacion.Controls.Add(btnPrevious);
            panelNavegacion.Controls.Add(btnFirst);
            panelNavegacion.Controls.Add(txtPageCount);
            panelNavegacion.Controls.Add(cboPages);
            panelNavegacion.Controls.Add(label2);
            panelNavegacion.Controls.Add(label1);
            panelNavegacion.Dock = DockStyle.Bottom;
            panelNavegacion.Location = new Point(0, 1194);
            panelNavegacion.Margin = new Padding(6);
            panelNavegacion.Name = "panelNavegacion";
            panelNavegacion.Size = new Size(1974, 135);
            panelNavegacion.TabIndex = 0;
            panelNavegacion.Paint += panelNavegacion_Paint;
            // 
            // btnLast
            // 
            btnLast.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLast.Location = new Point(1829, 44);
            btnLast.Margin = new Padding(6);
            btnLast.Name = "btnLast";
            btnLast.Size = new Size(74, 58);
            btnLast.TabIndex = 3;
            btnLast.UseVisualStyleBackColor = true;
            btnLast.Click += btnLast_Click;
            // 
            // btnNext
            // 
            btnNext.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnNext.Location = new Point(1700, 44);
            btnNext.Margin = new Padding(6);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(74, 58);
            btnNext.TabIndex = 2;
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += btnNext_Click;
            // 
            // btnPrevious
            // 
            btnPrevious.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnPrevious.Location = new Point(1559, 44);
            btnPrevious.Margin = new Padding(6);
            btnPrevious.Name = "btnPrevious";
            btnPrevious.Size = new Size(74, 58);
            btnPrevious.TabIndex = 1;
            btnPrevious.UseVisualStyleBackColor = true;
            btnPrevious.Click += btnPreviousr_Click;
            // 
            // btnFirst
            // 
            btnFirst.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnFirst.Location = new Point(1439, 44);
            btnFirst.Margin = new Padding(6);
            btnFirst.Name = "btnFirst";
            btnFirst.Size = new Size(74, 58);
            btnFirst.TabIndex = 0;
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
            txtPageCount.TabIndex = 7;
            // 
            // cboPages
            // 
            cboPages.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPages.FormattingEnabled = true;
            cboPages.Location = new Point(118, 44);
            cboPages.Margin = new Padding(6);
            cboPages.Name = "cboPages";
            cboPages.Size = new Size(123, 40);
            cboPages.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(263, 50);
            label2.Margin = new Padding(6, 0, 6, 0);
            label2.Name = "label2";
            label2.Size = new Size(36, 32);
            label2.TabIndex = 6;
            label2.Text = "of";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(36, 50);
            label1.Margin = new Padding(6, 0, 6, 0);
            label1.Name = "label1";
            label1.Size = new Size(65, 32);
            label1.TabIndex = 4;
            label1.Text = "Page";
            // 
            // panelGrilla
            // 
            panelGrilla.Controls.Add(dgv);
            panelGrilla.Dock = DockStyle.Fill;
            panelGrilla.Location = new Point(0, 42);
            panelGrilla.Margin = new Padding(6);
            panelGrilla.Name = "panelGrilla";
            panelGrilla.Size = new Size(1974, 1287);
            panelGrilla.TabIndex = 14;
            // 
            // dgv
            // 
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv.Columns.AddRange(new DataGridViewColumn[] { colComboName, colDescription, colSize, colCostPrice, colSalePrice, colStock, colReorderLevel, colSuspended, colStartDate, colEndDate, colId });
            dgv.Dock = DockStyle.Fill;
            dgv.Location = new Point(0, 0);
            dgv.Name = "dgv";
            dgv.ReadOnly = true;
            dgv.RowHeadersVisible = false;
            dgv.RowHeadersWidth = 82;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.Size = new Size(1974, 1287);
            dgv.TabIndex = 0;
            // 
            // colComboName
            // 
            colComboName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colComboName.HeaderText = "Combo Name";
            colComboName.MinimumWidth = 10;
            colComboName.Name = "colComboName";
            colComboName.ReadOnly = true;
            // 
            // colDescription
            // 
            colDescription.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colDescription.HeaderText = "Description";
            colDescription.MinimumWidth = 10;
            colDescription.Name = "colDescription";
            colDescription.ReadOnly = true;
            // 
            // colSize
            // 
            colSize.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colSize.HeaderText = "Sise";
            colSize.MinimumWidth = 10;
            colSize.Name = "colSize";
            colSize.ReadOnly = true;
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
            // colStartDate
            // 
            colStartDate.HeaderText = "Start Date";
            colStartDate.MinimumWidth = 10;
            colStartDate.Name = "colStartDate";
            colStartDate.ReadOnly = true;
            colStartDate.Width = 200;
            // 
            // colEndDate
            // 
            colEndDate.HeaderText = "End Date";
            colEndDate.MinimumWidth = 10;
            colEndDate.Name = "colEndDate";
            colEndDate.ReadOnly = true;
            colEndDate.Width = 200;
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
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(32, 32);
            toolStrip1.Items.AddRange(new ToolStripItem[] { btnNew, btnDelete, btnEdit, btnOrder, btnFilter, btnClose, btnRefresh });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1974, 42);
            toolStrip1.TabIndex = 0;
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
            // btnOrder
            // 
            btnOrder.DropDownItems.AddRange(new ToolStripItem[] { productAZToolStripMenuItem, productZAToolStripMenuItem, categoryAZToolStripMenuItem, categoryZAToolStripMenuItem });
            btnOrder.Name = "btnOrder";
            btnOrder.Size = new Size(97, 36);
            btnOrder.Text = "Order";
            // 
            // productAZToolStripMenuItem
            // 
            productAZToolStripMenuItem.Name = "productAZToolStripMenuItem";
            productAZToolStripMenuItem.Size = new Size(289, 44);
            productAZToolStripMenuItem.Text = "Product A-Z";
            // 
            // productZAToolStripMenuItem
            // 
            productZAToolStripMenuItem.Name = "productZAToolStripMenuItem";
            productZAToolStripMenuItem.Size = new Size(289, 44);
            productZAToolStripMenuItem.Text = "Product Z-A";
            // 
            // categoryAZToolStripMenuItem
            // 
            categoryAZToolStripMenuItem.Name = "categoryAZToolStripMenuItem";
            categoryAZToolStripMenuItem.Size = new Size(289, 44);
            categoryAZToolStripMenuItem.Text = "Category A-Z";
            // 
            // categoryZAToolStripMenuItem
            // 
            categoryZAToolStripMenuItem.Name = "categoryZAToolStripMenuItem";
            categoryZAToolStripMenuItem.Size = new Size(289, 44);
            categoryZAToolStripMenuItem.Text = "Category Z-A";
            // 
            // btnFilter
            // 
            btnFilter.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btnFilter.Image = (Image)resources.GetObject("btnFilter.Image");
            btnFilter.ImageTransparentColor = Color.Magenta;
            btnFilter.Name = "btnFilter";
            btnFilter.Size = new Size(71, 36);
            btnFilter.Text = "Filter";
            // 
            // btnClose
            // 
            btnClose.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btnClose.Image = (Image)resources.GetObject("btnClose.Image");
            btnClose.ImageTransparentColor = Color.Magenta;
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(76, 36);
            btnClose.Text = "Close";
            btnClose.Click += btnClose_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btnRefresh.Image = (Image)resources.GetObject("btnRefresh.Image");
            btnRefresh.ImageTransparentColor = Color.Magenta;
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(97, 36);
            btnRefresh.Text = "Refresh";
            btnRefresh.Click += btnRefresh_Click;
            // 
            // frmCombos
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1974, 1329);
            Controls.Add(panelNavegacion);
            Controls.Add(panelGrilla);
            Controls.Add(toolStrip1);
            MaximumSize = new Size(2000, 1400);
            MinimumSize = new Size(2000, 1400);
            Name = "frmCombos";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmCombos";
            Load += frmCombos_Load;
            panelNavegacion.ResumeLayout(false);
            panelNavegacion.PerformLayout();
            panelGrilla.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgv).EndInit();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelNavegacion;
        private Button btnLast;
        private Button btnNext;
        private Button btnPrevious;
        private Button btnFirst;
        private TextBox txtPageCount;
        private ComboBox cboPages;
        private Label label2;
        private Label label1;
        private Panel panelGrilla;
        private DataGridView dgv;
        private DataGridViewTextBoxColumn colComboName;
        private DataGridViewTextBoxColumn colDescription;
        private DataGridViewTextBoxColumn colSize;
        private DataGridViewTextBoxColumn colCostPrice;
        private DataGridViewTextBoxColumn colSalePrice;
        private DataGridViewTextBoxColumn colStock;
        private DataGridViewTextBoxColumn colReorderLevel;
        private DataGridViewTextBoxColumn colSuspended;
        private DataGridViewTextBoxColumn colStartDate;
        private DataGridViewTextBoxColumn colEndDate;
        private DataGridViewTextBoxColumn colId;
        private ToolStrip toolStrip1;
        private ToolStripButton btnNew;
        private ToolStripButton btnDelete;
        private ToolStripButton btnEdit;
        private ToolStripDropDownButton btnOrder;
        private ToolStripMenuItem productAZToolStripMenuItem;
        private ToolStripMenuItem productZAToolStripMenuItem;
        private ToolStripMenuItem categoryAZToolStripMenuItem;
        private ToolStripMenuItem categoryZAToolStripMenuItem;
        private ToolStripButton btnFilter;
        private ToolStripButton btnClose;
        private ToolStripButton btnRefresh;
    }
}