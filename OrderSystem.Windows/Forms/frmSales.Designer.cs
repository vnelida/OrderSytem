namespace Windows.Forms
{
    partial class frmSales
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSales));
            panelNavegacion = new Panel();
            txtPageCount = new TextBox();
            cboPages = new ComboBox();
            label2 = new Label();
            label1 = new Label();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            panelGrilla = new Panel();
            dgv = new DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colCustomer = new DataGridViewTextBoxColumn();
            colDate = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewTextBoxColumn();
            colOrderType = new DataGridViewTextBoxColumn();
            colTotal = new DataGridViewTextBoxColumn();
            toolStrip1 = new ToolStrip();
            btnClose = new ToolStripButton();
            btnNew = new ToolStripButton();
            btnDelete = new ToolStripButton();
            btnEdit = new ToolStripButton();
            btnOrder = new ToolStripDropDownButton();
            productAZToolStripMenuItem = new ToolStripMenuItem();
            productZAToolStripMenuItem = new ToolStripMenuItem();
            categoryAZToolStripMenuItem = new ToolStripMenuItem();
            categoryZAToolStripMenuItem = new ToolStripMenuItem();
            btnFilter = new ToolStripComboBox();
            btnRefresh = new ToolStripButton();
            btnDetails = new ToolStripButton();
            panelNavegacion.SuspendLayout();
            panelGrilla.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv).BeginInit();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // panelNavegacion
            // 
            panelNavegacion.BackColor = Color.DarkSeaGreen;
            panelNavegacion.BackgroundImage = (Image)resources.GetObject("panelNavegacion.BackgroundImage");
            panelNavegacion.Controls.Add(txtPageCount);
            panelNavegacion.Controls.Add(cboPages);
            panelNavegacion.Controls.Add(label2);
            panelNavegacion.Controls.Add(label1);
            panelNavegacion.Controls.Add(button1);
            panelNavegacion.Controls.Add(button2);
            panelNavegacion.Controls.Add(button3);
            panelNavegacion.Controls.Add(button4);
            panelNavegacion.Dock = DockStyle.Bottom;
            panelNavegacion.Location = new Point(0, 1207);
            panelNavegacion.Margin = new Padding(6);
            panelNavegacion.Name = "panelNavegacion";
            panelNavegacion.Size = new Size(1974, 122);
            panelNavegacion.TabIndex = 15;
            // 
            // txtPageCount
            // 
            txtPageCount.Location = new Point(304, 42);
            txtPageCount.Margin = new Padding(6);
            txtPageCount.Name = "txtPageCount";
            txtPageCount.ReadOnly = true;
            txtPageCount.Size = new Size(123, 39);
            txtPageCount.TabIndex = 39;
            // 
            // cboPages
            // 
            cboPages.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPages.FormattingEnabled = true;
            cboPages.Location = new Point(111, 43);
            cboPages.Margin = new Padding(6);
            cboPages.Name = "cboPages";
            cboPages.Size = new Size(123, 40);
            cboPages.TabIndex = 37;
            cboPages.SelectedIndexChanged += cboPages_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(256, 49);
            label2.Margin = new Padding(6, 0, 6, 0);
            label2.Name = "label2";
            label2.Size = new Size(36, 32);
            label2.TabIndex = 38;
            label2.Text = "of";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(29, 49);
            label1.Margin = new Padding(6, 0, 6, 0);
            label1.Name = "label1";
            label1.Size = new Size(65, 32);
            label1.TabIndex = 36;
            label1.Text = "Page";
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button1.BackgroundImage = (Image)resources.GetObject("button1.BackgroundImage");
            button1.BackgroundImageLayout = ImageLayout.Center;
            button1.Location = new Point(1844, 33);
            button1.Margin = new Padding(6);
            button1.Name = "button1";
            button1.Size = new Size(74, 58);
            button1.TabIndex = 32;
            button1.UseVisualStyleBackColor = true;
            button1.Click += btnLast_Click;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button2.BackgroundImage = (Image)resources.GetObject("button2.BackgroundImage");
            button2.BackgroundImageLayout = ImageLayout.Center;
            button2.Location = new Point(1694, 33);
            button2.Margin = new Padding(6);
            button2.Name = "button2";
            button2.Size = new Size(74, 58);
            button2.TabIndex = 33;
            button2.UseVisualStyleBackColor = true;
            button2.Click += btnNext_Click;
            // 
            // button3
            // 
            button3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button3.BackgroundImage = (Image)resources.GetObject("button3.BackgroundImage");
            button3.BackgroundImageLayout = ImageLayout.Center;
            button3.Location = new Point(1543, 33);
            button3.Margin = new Padding(6);
            button3.Name = "button3";
            button3.Size = new Size(74, 58);
            button3.TabIndex = 34;
            button3.UseVisualStyleBackColor = true;
            button3.Click += btnPrevious_Click;
            // 
            // button4
            // 
            button4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button4.BackgroundImage = (Image)resources.GetObject("button4.BackgroundImage");
            button4.BackgroundImageLayout = ImageLayout.Center;
            button4.Location = new Point(1393, 33);
            button4.Margin = new Padding(6);
            button4.Name = "button4";
            button4.Size = new Size(74, 58);
            button4.TabIndex = 35;
            button4.UseVisualStyleBackColor = true;
            button4.Click += btnFirst_Click;
            // 
            // panelGrilla
            // 
            panelGrilla.Controls.Add(dgv);
            panelGrilla.Dock = DockStyle.Fill;
            panelGrilla.Location = new Point(0, 106);
            panelGrilla.Margin = new Padding(6);
            panelGrilla.Name = "panelGrilla";
            panelGrilla.Size = new Size(1974, 1223);
            panelGrilla.TabIndex = 14;
            // 
            // dgv
            // 
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.BackgroundColor = Color.White;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv.Columns.AddRange(new DataGridViewColumn[] { colId, colCustomer, colDate, colStatus, colOrderType, colTotal });
            dgv.Dock = DockStyle.Fill;
            dgv.Location = new Point(0, 0);
            dgv.MultiSelect = false;
            dgv.Name = "dgv";
            dgv.ReadOnly = true;
            dgv.RowHeadersVisible = false;
            dgv.RowHeadersWidth = 82;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.Size = new Size(1974, 1223);
            dgv.TabIndex = 7;
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
            // colCustomer
            // 
            colCustomer.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colCustomer.HeaderText = "Customer";
            colCustomer.MinimumWidth = 10;
            colCustomer.Name = "colCustomer";
            colCustomer.ReadOnly = true;
            // 
            // colDate
            // 
            colDate.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colDate.HeaderText = "Date";
            colDate.MinimumWidth = 10;
            colDate.Name = "colDate";
            colDate.ReadOnly = true;
            // 
            // colStatus
            // 
            colStatus.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colStatus.HeaderText = "Order Status";
            colStatus.MinimumWidth = 10;
            colStatus.Name = "colStatus";
            colStatus.ReadOnly = true;
            // 
            // colOrderType
            // 
            colOrderType.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colOrderType.HeaderText = "Order Type";
            colOrderType.MinimumWidth = 10;
            colOrderType.Name = "colOrderType";
            colOrderType.ReadOnly = true;
            // 
            // colTotal
            // 
            colTotal.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colTotal.HeaderText = "Total";
            colTotal.MinimumWidth = 10;
            colTotal.Name = "colTotal";
            colTotal.ReadOnly = true;
            // 
            // toolStrip1
            // 
            toolStrip1.BackColor = Color.White;
            toolStrip1.ImageScalingSize = new Size(32, 32);
            toolStrip1.Items.AddRange(new ToolStripItem[] { btnClose, btnNew, btnDelete, btnEdit, btnOrder, btnFilter, btnRefresh, btnDetails });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1974, 106);
            toolStrip1.TabIndex = 13;
            toolStrip1.Text = "toolStrip1";
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
            productAZToolStripMenuItem.Size = new Size(313, 44);
            productAZToolStripMenuItem.Text = "Product A-Z";
            // 
            // productZAToolStripMenuItem
            // 
            productZAToolStripMenuItem.Name = "productZAToolStripMenuItem";
            productZAToolStripMenuItem.Size = new Size(313, 44);
            productZAToolStripMenuItem.Text = "Product Z-A";
            // 
            // categoryAZToolStripMenuItem
            // 
            categoryAZToolStripMenuItem.Name = "categoryAZToolStripMenuItem";
            categoryAZToolStripMenuItem.Size = new Size(313, 44);
            categoryAZToolStripMenuItem.Text = "Sale Price";
            // 
            // categoryZAToolStripMenuItem
            // 
            categoryZAToolStripMenuItem.Name = "categoryZAToolStripMenuItem";
            categoryZAToolStripMenuItem.Size = new Size(313, 44);
            categoryZAToolStripMenuItem.Text = "Sale Price DESC";
            // 
            // btnFilter
            // 
            btnFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            btnFilter.Name = "btnFilter";
            btnFilter.Size = new Size(130, 106);
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
            // btnDetails
            // 
            btnDetails.Image = (Image)resources.GetObject("btnDetails.Image");
            btnDetails.ImageScaling = ToolStripItemImageScaling.None;
            btnDetails.ImageTransparentColor = Color.Magenta;
            btnDetails.Name = "btnDetails";
            btnDetails.Size = new Size(90, 100);
            btnDetails.Text = "Details";
            btnDetails.TextImageRelation = TextImageRelation.ImageAboveText;
            btnDetails.Click += btnDetails_Click;
            // 
            // frmSales
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1974, 1329);
            ControlBox = false;
            Controls.Add(panelNavegacion);
            Controls.Add(panelGrilla);
            Controls.Add(toolStrip1);
            MaximumSize = new Size(2000, 1400);
            MinimumSize = new Size(2000, 1400);
            Name = "frmSales";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmSales";
            Load += frmSales_Load;
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
        private Panel panelGrilla;
        private DataGridView dgv;
        private ToolStrip toolStrip1;
        private ToolStripButton btnClose;
        private ToolStripButton btnNew;
        private ToolStripButton btnDelete;
        private ToolStripButton btnEdit;
        private ToolStripDropDownButton btnOrder;
        private ToolStripMenuItem productAZToolStripMenuItem;
        private ToolStripMenuItem productZAToolStripMenuItem;
        private ToolStripMenuItem categoryAZToolStripMenuItem;
        private ToolStripMenuItem categoryZAToolStripMenuItem;
        private ToolStripComboBox btnFilter;
        private ToolStripButton btnRefresh;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private TextBox txtPageCount;
        private ComboBox cboPages;
        private Label label2;
        private Label label1;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colCustomer;
        private DataGridViewTextBoxColumn colDate;
        private DataGridViewTextBoxColumn colStatus;
        private DataGridViewTextBoxColumn colOrderType;
        private DataGridViewTextBoxColumn colTotal;
        private ToolStripButton btnDetails;
    }
}