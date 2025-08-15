namespace Windows.Forms
{
    partial class frmSalesAE
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSalesAE));
            splitContainer1 = new SplitContainer();
            cboOrderType = new ComboBox();
            cboOrderStatus = new ComboBox();
            button2 = new Button();
            button1 = new Button();
            btnCombos = new Button();
            btnProducts = new Button();
            flp = new FlowLayoutPanel();
            dgv = new DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colCustomer = new DataGridViewTextBoxColumn();
            col = new DataGridViewTextBoxColumn();
            colUnitPrice = new DataGridViewTextBoxColumn();
            colTotal = new DataGridViewTextBoxColumn();
            colDelete = new DataGridViewImageColumn();
            colEdit = new DataGridViewImageColumn();
            lblTotal = new Label();
            label4 = new Label();
            lblCantidad = new Label();
            label3 = new Label();
            label2 = new Label();
            btnCancel = new Button();
            btnOk = new Button();
            splitter1 = new Splitter();
            errorProvider1 = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.BackColor = SystemColors.ControlLightLight;
            splitContainer1.Panel1.Controls.Add(cboOrderType);
            splitContainer1.Panel1.Controls.Add(cboOrderStatus);
            splitContainer1.Panel1.Controls.Add(button2);
            splitContainer1.Panel1.Controls.Add(button1);
            splitContainer1.Panel1.Controls.Add(btnCombos);
            splitContainer1.Panel1.Controls.Add(btnProducts);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.BackColor = SystemColors.ControlLightLight;
            splitContainer1.Panel2.Controls.Add(flp);
            splitContainer1.Panel2.Controls.Add(dgv);
            splitContainer1.Panel2.Controls.Add(lblTotal);
            splitContainer1.Panel2.Controls.Add(label4);
            splitContainer1.Panel2.Controls.Add(lblCantidad);
            splitContainer1.Panel2.Controls.Add(label3);
            splitContainer1.Panel2.Controls.Add(label2);
            splitContainer1.Panel2.Controls.Add(btnCancel);
            splitContainer1.Panel2.Controls.Add(btnOk);
            splitContainer1.Panel2.Controls.Add(splitter1);
            splitContainer1.Size = new Size(1974, 1329);
            splitContainer1.SplitterDistance = 176;
            splitContainer1.TabIndex = 0;
            // 
            // cboOrderType
            // 
            cboOrderType.FormattingEnabled = true;
            cboOrderType.Location = new Point(1558, 107);
            cboOrderType.Name = "cboOrderType";
            cboOrderType.Size = new Size(385, 40);
            cboOrderType.TabIndex = 12;
            cboOrderType.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            // 
            // cboOrderStatus
            // 
            cboOrderStatus.FormattingEnabled = true;
            cboOrderStatus.Location = new Point(1558, 30);
            cboOrderStatus.Name = "cboOrderStatus";
            cboOrderStatus.Size = new Size(385, 40);
            cboOrderStatus.TabIndex = 11;
            cboOrderStatus.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Top;
            button2.BackgroundImage = (Image)resources.GetObject("button2.BackgroundImage");
            button2.Image = (Image)resources.GetObject("button2.Image");
            button2.Location = new Point(1339, 12);
            button2.Name = "button2";
            button2.Size = new Size(213, 75);
            button2.TabIndex = 10;
            button2.Text = "Order Status:";
            button2.TextImageRelation = TextImageRelation.ImageBeforeText;
            button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top;
            button1.AutoSize = true;
            button1.BackgroundImage = (Image)resources.GetObject("button1.BackgroundImage");
            button1.Image = (Image)resources.GetObject("button1.Image");
            button1.Location = new Point(1339, 89);
            button1.Name = "button1";
            button1.Size = new Size(213, 75);
            button1.TabIndex = 9;
            button1.Text = "Order Type:";
            button1.TextImageRelation = TextImageRelation.ImageBeforeText;
            button1.UseVisualStyleBackColor = true;
            // 
            // btnCombos
            // 
            btnCombos.Anchor = AnchorStyles.Top;
            btnCombos.AutoSize = true;
            btnCombos.BackgroundImage = (Image)resources.GetObject("btnCombos.BackgroundImage");
            btnCombos.Image = (Image)resources.GetObject("btnCombos.Image");
            btnCombos.Location = new Point(42, 22);
            btnCombos.Name = "btnCombos";
            btnCombos.Size = new Size(168, 142);
            btnCombos.TabIndex = 8;
            btnCombos.Text = "Combos";
            btnCombos.TextImageRelation = TextImageRelation.ImageAboveText;
            btnCombos.UseVisualStyleBackColor = true;
            btnCombos.Click += btnCombos_Click;
            // 
            // btnProducts
            // 
            btnProducts.Anchor = AnchorStyles.Top;
            btnProducts.AutoSize = true;
            btnProducts.BackgroundImage = (Image)resources.GetObject("btnProducts.BackgroundImage");
            btnProducts.Image = (Image)resources.GetObject("btnProducts.Image");
            btnProducts.Location = new Point(248, 22);
            btnProducts.Name = "btnProducts";
            btnProducts.Size = new Size(168, 142);
            btnProducts.TabIndex = 7;
            btnProducts.Text = "Products";
            btnProducts.TextImageRelation = TextImageRelation.ImageAboveText;
            btnProducts.UseVisualStyleBackColor = true;
            btnProducts.Click += btnProducts_Click;
            // 
            // flp
            // 
            flp.AutoScroll = true;
            flp.Location = new Point(12, 19);
            flp.Name = "flp";
            flp.Size = new Size(1117, 1118);
            flp.TabIndex = 9;
            // 
            // dgv
            // 
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.BackgroundColor = Color.White;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv.Columns.AddRange(new DataGridViewColumn[] { colId, colCustomer, col, colUnitPrice, colTotal, colDelete, colEdit });
            dgv.Location = new Point(1167, 19);
            dgv.MultiSelect = false;
            dgv.Name = "dgv";
            dgv.ReadOnly = true;
            dgv.RowHeadersVisible = false;
            dgv.RowHeadersWidth = 82;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.Size = new Size(776, 752);
            dgv.TabIndex = 26;
            dgv.CellContentClick += dgvDatos_CellContentClick;
            // 
            // colId
            // 
            colId.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
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
            colCustomer.HeaderText = "Product";
            colCustomer.MinimumWidth = 10;
            colCustomer.Name = "colCustomer";
            colCustomer.ReadOnly = true;
            // 
            // col
            // 
            col.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            col.HeaderText = "Quantity";
            col.MinimumWidth = 10;
            col.Name = "col";
            col.ReadOnly = true;
            col.Width = 151;
            // 
            // colUnitPrice
            // 
            colUnitPrice.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colUnitPrice.HeaderText = "Unit Price";
            colUnitPrice.MinimumWidth = 10;
            colUnitPrice.Name = "colUnitPrice";
            colUnitPrice.ReadOnly = true;
            colUnitPrice.SortMode = DataGridViewColumnSortMode.NotSortable;
            colUnitPrice.Width = 122;
            // 
            // colTotal
            // 
            colTotal.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colTotal.FillWeight = 1F;
            colTotal.HeaderText = "Total";
            colTotal.MinimumWidth = 10;
            colTotal.Name = "colTotal";
            colTotal.ReadOnly = true;
            colTotal.Width = 110;
            // 
            // colDelete
            // 
            colDelete.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colDelete.HeaderText = "";
            colDelete.Image = (Image)resources.GetObject("colDelete.Image");
            colDelete.MinimumWidth = 10;
            colDelete.Name = "colDelete";
            colDelete.ReadOnly = true;
            colDelete.Resizable = DataGridViewTriState.True;
            colDelete.Width = 10;
            // 
            // colEdit
            // 
            colEdit.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            colEdit.HeaderText = "";
            colEdit.Image = (Image)resources.GetObject("colEdit.Image");
            colEdit.MinimumWidth = 10;
            colEdit.Name = "colEdit";
            colEdit.ReadOnly = true;
            colEdit.Resizable = DataGridViewTriState.True;
            colEdit.Width = 10;
            // 
            // lblTotal
            // 
            lblTotal.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTotal.Location = new Point(1860, 836);
            lblTotal.Margin = new Padding(6, 0, 6, 0);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(49, 32);
            lblTotal.TabIndex = 21;
            lblTotal.Text = "$ 0";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label4.Location = new Point(1780, 836);
            label4.Margin = new Padding(6, 0, 6, 0);
            label4.Name = "label4";
            label4.Size = new Size(77, 32);
            label4.TabIndex = 22;
            label4.Text = "Total:";
            // 
            // lblCantidad
            // 
            lblCantidad.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblCantidad.AutoSize = true;
            lblCantidad.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCantidad.Location = new Point(1662, 836);
            lblCantidad.Margin = new Padding(6, 0, 6, 0);
            lblCantidad.Name = "lblCantidad";
            lblCantidad.Size = new Size(28, 32);
            lblCantidad.TabIndex = 23;
            lblCantidad.Text = "0";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label3.Location = new Point(1571, 836);
            label3.Margin = new Padding(6, 0, 6, 0);
            label3.Name = "label3";
            label3.Size = new Size(80, 32);
            label3.TabIndex = 24;
            label3.Text = "Cant.:";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label2.Location = new Point(1370, 836);
            label2.Margin = new Padding(6, 0, 6, 0);
            label2.Name = "label2";
            label2.Size = new Size(101, 32);
            label2.TabIndex = 25;
            label2.Text = "Totales:";
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancel.Location = new Point(1692, 986);
            btnCancel.Margin = new Padding(6);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(148, 88);
            btnCancel.TabIndex = 20;
            btnCancel.Text = "Cancel";
            btnCancel.TextImageRelation = TextImageRelation.ImageAboveText;
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnOk
            // 
            btnOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnOk.Location = new Point(1501, 986);
            btnOk.Margin = new Padding(6);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(148, 88);
            btnOk.TabIndex = 19;
            btnOk.Text = "Ok";
            btnOk.TextImageRelation = TextImageRelation.ImageAboveText;
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click_1;
            // 
            // splitter1
            // 
            splitter1.Location = new Point(0, 0);
            splitter1.Name = "splitter1";
            splitter1.Size = new Size(1361, 1149);
            splitter1.TabIndex = 0;
            splitter1.TabStop = false;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // frmSalesAE
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1974, 1329);
            Controls.Add(splitContainer1);
            Name = "frmSalesAE";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmSalesAE";
            Load += frmSalesAE_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgv).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private Splitter splitter1;
        private Label lblTotal;
        private Label label4;
        private Label lblCantidad;
        private Label label3;
        private Label label2;
        private Button btnCancel;
        private Button btnOk;
        private DataGridView dgv;
        private Button btnCombos;
        private Button btnProducts;
        private FlowLayoutPanel flp;
        private ErrorProvider errorProvider1;
        private Button button2;
        private Button button1;
        private ComboBox cboOrderType;
        private ComboBox cboOrderStatus;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colCustomer;
        private DataGridViewTextBoxColumn col;
        private DataGridViewTextBoxColumn colUnitPrice;
        private DataGridViewTextBoxColumn colTotal;
        private DataGridViewImageColumn colDelete;
        private DataGridViewImageColumn colEdit;
    }
}