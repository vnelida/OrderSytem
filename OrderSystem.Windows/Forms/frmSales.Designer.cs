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
            SaleId = new DataGridViewTextBoxColumn();
            colCustomer = new DataGridViewTextBoxColumn();
            colDate = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewTextBoxColumn();
            colOrderType = new DataGridViewTextBoxColumn();
            colTotal = new DataGridViewTextBoxColumn();
            toolStrip1 = new ToolStrip();
            btnClose = new ToolStripButton();
            btnNew = new ToolStripButton();
            btnDelete = new ToolStripButton();
            btnUpdate = new ToolStripButton();
            toolStripButton1 = new ToolStripButton();
            btnDetails = new ToolStripButton();
            toolStripButton3 = new ToolStripButton();
            btnOrder = new ToolStripDropDownButton();
            totalAsc = new ToolStripMenuItem();
            totalDesc = new ToolStripMenuItem();
            dateAcs = new ToolStripMenuItem();
            dateDesc = new ToolStripMenuItem();
            customerACSToolStripMenuItem = new ToolStripMenuItem();
            customerDESCToolStripMenuItem = new ToolStripMenuItem();
            toolStripButton2 = new ToolStripButton();
            btnFilterStatus = new ToolStripDropDownButton();
            filterCompleted = new ToolStripMenuItem();
            filterPending = new ToolStripMenuItem();
            filterPreparing = new ToolStripMenuItem();
            filterSent = new ToolStripMenuItem();
            filterCancelled = new ToolStripMenuItem();
            filterOrderType = new ToolStripDropDownButton();
            InStoreFilter = new ToolStripMenuItem();
            TakeAwayFilter = new ToolStripMenuItem();
            DeliveryFilter = new ToolStripMenuItem();
            btnRefresh = new ToolStripButton();
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
            dgv.Columns.AddRange(new DataGridViewColumn[] { SaleId, colCustomer, colDate, colStatus, colOrderType, colTotal });
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
            // SaleId
            // 
            SaleId.HeaderText = "SaleId";
            SaleId.MinimumWidth = 10;
            SaleId.Name = "SaleId";
            SaleId.ReadOnly = true;
            SaleId.Visible = false;
            SaleId.Width = 200;
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
            toolStrip1.Items.AddRange(new ToolStripItem[] { btnClose, btnNew, btnDelete, btnUpdate, toolStripButton1, btnDetails, toolStripButton3, btnOrder, toolStripButton2, btnFilterStatus, filterOrderType, btnRefresh });
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
            btnNew.Image = Properties.Resources.icons8_add_64;
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
            btnDelete.Image = Properties.Resources.icons8_cancel_64;
            btnDelete.ImageScaling = ToolStripItemImageScaling.None;
            btnDelete.ImageTransparentColor = Color.Magenta;
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(89, 100);
            btnDelete.Text = "Cancel";
            btnDelete.TextImageRelation = TextImageRelation.ImageAboveText;
            btnDelete.Click += btnCancel_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Image = Properties.Resources.icons8_edit_64;
            btnUpdate.ImageScaling = ToolStripItemImageScaling.None;
            btnUpdate.ImageTransparentColor = Color.Magenta;
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(95, 100);
            btnUpdate.Text = "Update";
            btnUpdate.TextImageRelation = TextImageRelation.ImageAboveText;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // toolStripButton1
            // 
            toolStripButton1.DisplayStyle = ToolStripItemDisplayStyle.None;
            toolStripButton1.Image = (Image)resources.GetObject("toolStripButton1.Image");
            toolStripButton1.ImageTransparentColor = Color.Magenta;
            toolStripButton1.Name = "toolStripButton1";
            toolStripButton1.Size = new Size(46, 100);
            toolStripButton1.Text = "toolStripButton1";
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
            // toolStripButton3
            // 
            toolStripButton3.DisplayStyle = ToolStripItemDisplayStyle.None;
            toolStripButton3.Image = (Image)resources.GetObject("toolStripButton3.Image");
            toolStripButton3.ImageTransparentColor = Color.Magenta;
            toolStripButton3.Name = "toolStripButton3";
            toolStripButton3.Size = new Size(46, 100);
            toolStripButton3.Text = "toolStripButton1";
            // 
            // btnOrder
            // 
            btnOrder.DropDownItems.AddRange(new ToolStripItem[] { totalAsc, totalDesc, dateAcs, dateDesc, customerACSToolStripMenuItem, customerDESCToolStripMenuItem });
            btnOrder.Image = Properties.Resources.icons8_sorting_64;
            btnOrder.ImageScaling = ToolStripItemImageScaling.None;
            btnOrder.Name = "btnOrder";
            btnOrder.Size = new Size(97, 100);
            btnOrder.Text = "Order";
            btnOrder.TextImageRelation = TextImageRelation.ImageAboveText;
            // 
            // totalAsc
            // 
            totalAsc.Name = "totalAsc";
            totalAsc.Size = new Size(314, 44);
            totalAsc.Text = "Total ";
            totalAsc.Click += totalAsc_Click;
            // 
            // totalDesc
            // 
            totalDesc.Name = "totalDesc";
            totalDesc.Size = new Size(314, 44);
            totalDesc.Text = "Total DESC";
            totalDesc.Click += totalDesc_Click;
            // 
            // dateAcs
            // 
            dateAcs.Name = "dateAcs";
            dateAcs.Size = new Size(314, 44);
            dateAcs.Text = "Date ";
            dateAcs.Click += dateAcs_Click;
            // 
            // dateDesc
            // 
            dateDesc.Name = "dateDesc";
            dateDesc.Size = new Size(314, 44);
            dateDesc.Text = "Date Decs";
            dateDesc.Click += dateDesc_Click;
            // 
            // customerACSToolStripMenuItem
            // 
            customerACSToolStripMenuItem.Name = "customerACSToolStripMenuItem";
            customerACSToolStripMenuItem.Size = new Size(314, 44);
            customerACSToolStripMenuItem.Text = "Customer ";
            customerACSToolStripMenuItem.Click += customerACSToolStripMenuItem_Click;
            // 
            // customerDESCToolStripMenuItem
            // 
            customerDESCToolStripMenuItem.Name = "customerDESCToolStripMenuItem";
            customerDESCToolStripMenuItem.Size = new Size(314, 44);
            customerDESCToolStripMenuItem.Text = "Customer DESC";
            customerDESCToolStripMenuItem.Click += customerDESCToolStripMenuItem_Click;
            // 
            // toolStripButton2
            // 
            toolStripButton2.DisplayStyle = ToolStripItemDisplayStyle.None;
            toolStripButton2.Image = (Image)resources.GetObject("toolStripButton2.Image");
            toolStripButton2.ImageTransparentColor = Color.Magenta;
            toolStripButton2.Name = "toolStripButton2";
            toolStripButton2.Size = new Size(46, 100);
            toolStripButton2.Text = "toolStripButton1";
            // 
            // btnFilterStatus
            // 
            btnFilterStatus.DropDownItems.AddRange(new ToolStripItem[] { filterCompleted, filterPending, filterPreparing, filterSent, filterCancelled });
            btnFilterStatus.Image = (Image)resources.GetObject("btnFilterStatus.Image");
            btnFilterStatus.ImageScaling = ToolStripItemImageScaling.None;
            btnFilterStatus.Name = "btnFilterStatus";
            btnFilterStatus.Size = new Size(168, 100);
            btnFilterStatus.Text = "Order Status";
            btnFilterStatus.TextImageRelation = TextImageRelation.ImageAboveText;
            // 
            // filterCompleted
            // 
            filterCompleted.Name = "filterCompleted";
            filterCompleted.Size = new Size(265, 44);
            filterCompleted.Text = "Completed";
            filterCompleted.Click += filterCompleted_Click;
            // 
            // filterPending
            // 
            filterPending.Name = "filterPending";
            filterPending.Size = new Size(265, 44);
            filterPending.Text = "Pending";
            filterPending.Click += filterPending_Click;
            // 
            // filterPreparing
            // 
            filterPreparing.Name = "filterPreparing";
            filterPreparing.Size = new Size(265, 44);
            filterPreparing.Text = "Preparing";
            filterPreparing.Click += filterPreparing_Click;
            // 
            // filterSent
            // 
            filterSent.Name = "filterSent";
            filterSent.Size = new Size(265, 44);
            filterSent.Text = "Sent";
            filterSent.Click += filterSent_Click;
            // 
            // filterCancelled
            // 
            filterCancelled.Name = "filterCancelled";
            filterCancelled.Size = new Size(265, 44);
            filterCancelled.Text = "Cancelled";
            filterCancelled.Click += filterCancelled_Click;
            // 
            // filterOrderType
            // 
            filterOrderType.DropDownItems.AddRange(new ToolStripItem[] { InStoreFilter, TakeAwayFilter, DeliveryFilter });
            filterOrderType.Image = (Image)resources.GetObject("filterOrderType.Image");
            filterOrderType.ImageScaling = ToolStripItemImageScaling.None;
            filterOrderType.Name = "filterOrderType";
            filterOrderType.Size = new Size(155, 100);
            filterOrderType.Text = "Order Type";
            filterOrderType.TextImageRelation = TextImageRelation.ImageAboveText;
            // 
            // InStoreFilter
            // 
            InStoreFilter.Name = "InStoreFilter";
            InStoreFilter.Size = new Size(257, 44);
            InStoreFilter.Text = "In Store";
            InStoreFilter.Click += InStoreFilter_Click;
            // 
            // TakeAwayFilter
            // 
            TakeAwayFilter.Name = "TakeAwayFilter";
            TakeAwayFilter.Size = new Size(257, 44);
            TakeAwayFilter.Text = "Take Away";
            TakeAwayFilter.Click += TakeAwayFilter_Click;
            // 
            // DeliveryFilter
            // 
            DeliveryFilter.Name = "DeliveryFilter";
            DeliveryFilter.Size = new Size(257, 44);
            DeliveryFilter.Text = "Delivery";
            DeliveryFilter.Click += DeliveryFilter_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.Image = Properties.Resources.aiconreset;
            btnRefresh.ImageScaling = ToolStripItemImageScaling.None;
            btnRefresh.ImageTransparentColor = Color.Magenta;
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(109, 100);
            btnRefresh.Text = "Reset All";
            btnRefresh.TextImageRelation = TextImageRelation.ImageAboveText;
            btnRefresh.Click += btnRefresh_Click;
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
        private ToolStripButton btnUpdate;
        private ToolStripDropDownButton btnOrder;
        private ToolStripMenuItem totalAsc;
        private ToolStripMenuItem totalDesc;
        private ToolStripMenuItem dateAcs;
        private ToolStripMenuItem dateDesc;
        private ToolStripButton btnRefresh;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private TextBox txtPageCount;
        private ComboBox cboPages;
        private Label label2;
        private Label label1;
        private ToolStripButton btnDetails;
        private ToolStripButton toolStripButton1;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colCustomer;
        private DataGridViewTextBoxColumn colDate;
        private DataGridViewTextBoxColumn colStatus;
        private DataGridViewTextBoxColumn colOrderType;
        private DataGridViewTextBoxColumn colTotal;
        private DataGridViewTextBoxColumn SaleId;
        private ToolStripMenuItem customerACSToolStripMenuItem;
        private ToolStripMenuItem customerDESCToolStripMenuItem;
        private ToolStripDropDownButton btnFilterStatus;
        private ToolStripMenuItem filterCompleted;
        private ToolStripMenuItem filterPending;
        private ToolStripMenuItem filterPreparing;
        private ToolStripMenuItem filterSent;
        private ToolStripMenuItem filterCancelled;
        private ToolStripDropDownButton filterOrderType;
        private ToolStripMenuItem InStoreFilter;
        private ToolStripMenuItem TakeAwayFilter;
        private ToolStripMenuItem DeliveryFilter;
        private ToolStripButton toolStripButton3;
        private ToolStripButton toolStripButton2;
    }
}