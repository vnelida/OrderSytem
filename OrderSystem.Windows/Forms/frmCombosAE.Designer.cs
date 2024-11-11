namespace Windows.Forms
{
    partial class frmCombosAE
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCombosAE));
            checkBoxSuspended = new CheckBox();
            numSalePrice = new NumericUpDown();
            label7 = new Label();
            numReorderLevel = new NumericUpDown();
            label6 = new Label();
            btnCancel = new Button();
            btnOk = new Button();
            numStock = new NumericUpDown();
            numPrice = new NumericUpDown();
            label5 = new Label();
            txtComboName = new TextBox();
            label4 = new Label();
            label3 = new Label();
            txtDescription = new TextBox();
            label1 = new Label();
            dtpStartDate = new DateTimePicker();
            label8 = new Label();
            label9 = new Label();
            dtpEndDate = new DateTimePicker();
            errorProvider1 = new ErrorProvider(components);
            splitContainer1 = new SplitContainer();
            splitContainer2 = new SplitContainer();
            dgv = new DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colProductName = new DataGridViewTextBoxColumn();
            colQuantity = new DataGridViewTextBoxColumn();
            toolStrip1 = new ToolStrip();
            btnAddProduct = new ToolStripButton();
            btnRemoveProduct = new ToolStripButton();
            btnEditProduct = new ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)numSalePrice).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numReorderLevel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numStock).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numPrice).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv).BeginInit();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // checkBoxSuspended
            // 
            checkBoxSuspended.AutoSize = true;
            checkBoxSuspended.Location = new Point(540, 472);
            checkBoxSuspended.Name = "checkBoxSuspended";
            checkBoxSuspended.Size = new Size(165, 36);
            checkBoxSuspended.TabIndex = 8;
            checkBoxSuspended.Text = "Suspended";
            checkBoxSuspended.UseVisualStyleBackColor = true;
            // 
            // numSalePrice
            // 
            numSalePrice.DecimalPlaces = 2;
            numSalePrice.Location = new Point(212, 473);
            numSalePrice.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numSalePrice.Name = "numSalePrice";
            numSalePrice.Size = new Size(240, 39);
            numSalePrice.TabIndex = 5;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(65, 473);
            label7.Margin = new Padding(6, 0, 6, 0);
            label7.Name = "label7";
            label7.Size = new Size(138, 32);
            label7.TabIndex = 55;
            label7.Text = "Sales Price: ";
            // 
            // numReorderLevel
            // 
            numReorderLevel.Location = new Point(212, 400);
            numReorderLevel.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numReorderLevel.Name = "numReorderLevel";
            numReorderLevel.Size = new Size(240, 39);
            numReorderLevel.TabIndex = 4;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(39, 402);
            label6.Margin = new Padding(6, 0, 6, 0);
            label6.Name = "label6";
            label6.Size = new Size(164, 32);
            label6.TabIndex = 53;
            label6.Text = "Reorder Level:";
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(940, 112);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(209, 96);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnOk
            // 
            btnOk.Location = new Point(656, 114);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(209, 96);
            btnOk.TabIndex = 1;
            btnOk.Text = "Ok";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // numStock
            // 
            numStock.Location = new Point(212, 236);
            numStock.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numStock.Name = "numStock";
            numStock.Size = new Size(240, 39);
            numStock.TabIndex = 2;
            // 
            // numPrice
            // 
            numPrice.DecimalPlaces = 2;
            numPrice.Location = new Point(212, 307);
            numPrice.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numPrice.Name = "numPrice";
            numPrice.Size = new Size(240, 39);
            numPrice.TabIndex = 3;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(120, 238);
            label5.Margin = new Padding(6, 0, 6, 0);
            label5.Name = "label5";
            label5.Size = new Size(83, 32);
            label5.TabIndex = 48;
            label5.Text = "Stock: ";
            // 
            // txtComboName
            // 
            txtComboName.Location = new Point(212, 45);
            txtComboName.Margin = new Padding(6);
            txtComboName.MaxLength = 50;
            txtComboName.Name = "txtComboName";
            txtComboName.Size = new Size(396, 39);
            txtComboName.TabIndex = 0;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(21, 48);
            label4.Margin = new Padding(6, 0, 6, 0);
            label4.Name = "label4";
            label4.Size = new Size(175, 32);
            label4.TabIndex = 16;
            label4.Text = "Combo Name: ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(69, 307);
            label3.Margin = new Padding(6, 0, 6, 0);
            label3.Name = "label3";
            label3.Size = new Size(131, 32);
            label3.TabIndex = 45;
            label3.Text = "Cost Price: ";
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(212, 124);
            txtDescription.Margin = new Padding(6);
            txtDescription.MaxLength = 50;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(396, 39);
            txtDescription.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(53, 127);
            label1.Margin = new Padding(6, 0, 6, 0);
            label1.Name = "label1";
            label1.Size = new Size(147, 32);
            label1.TabIndex = 42;
            label1.Text = "Description: ";
            // 
            // dtpStartDate
            // 
            dtpStartDate.Format = DateTimePickerFormat.Short;
            dtpStartDate.Location = new Point(212, 594);
            dtpStartDate.Name = "dtpStartDate";
            dtpStartDate.Size = new Size(240, 39);
            dtpStartDate.TabIndex = 6;
            dtpStartDate.Value = new DateTime(2024, 11, 6, 0, 0, 0, 0);
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(69, 599);
            label8.Name = "label8";
            label8.Size = new Size(131, 32);
            label8.TabIndex = 59;
            label8.Text = "Start Date: ";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(69, 690);
            label9.Name = "label9";
            label9.Size = new Size(116, 32);
            label9.TabIndex = 61;
            label9.Text = "End Date:";
            // 
            // dtpEndDate
            // 
            dtpEndDate.Format = DateTimePickerFormat.Short;
            dtpEndDate.Location = new Point(212, 685);
            dtpEndDate.Name = "dtpEndDate";
            dtpEndDate.Size = new Size(240, 39);
            dtpEndDate.TabIndex = 7;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(label4);
            splitContainer1.Panel1.Controls.Add(checkBoxSuspended);
            splitContainer1.Panel1.Controls.Add(label9);
            splitContainer1.Panel1.Controls.Add(label1);
            splitContainer1.Panel1.Controls.Add(dtpEndDate);
            splitContainer1.Panel1.Controls.Add(txtDescription);
            splitContainer1.Panel1.Controls.Add(label8);
            splitContainer1.Panel1.Controls.Add(label3);
            splitContainer1.Panel1.Controls.Add(dtpStartDate);
            splitContainer1.Panel1.Controls.Add(txtComboName);
            splitContainer1.Panel1.Controls.Add(label5);
            splitContainer1.Panel1.Controls.Add(numSalePrice);
            splitContainer1.Panel1.Controls.Add(numPrice);
            splitContainer1.Panel1.Controls.Add(label7);
            splitContainer1.Panel1.Controls.Add(numStock);
            splitContainer1.Panel1.Controls.Add(numReorderLevel);
            splitContainer1.Panel1.Controls.Add(label6);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(splitContainer2);
            splitContainer1.Size = new Size(1935, 912);
            splitContainer1.SplitterDistance = 770;
            splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            splitContainer2.Dock = DockStyle.Fill;
            splitContainer2.Location = new Point(0, 0);
            splitContainer2.Name = "splitContainer2";
            splitContainer2.Orientation = Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(dgv);
            splitContainer2.Panel1.Controls.Add(toolStrip1);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(btnOk);
            splitContainer2.Panel2.Controls.Add(btnCancel);
            splitContainer2.Size = new Size(1161, 912);
            splitContainer2.SplitterDistance = 688;
            splitContainer2.TabIndex = 9;
            // 
            // dgv
            // 
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv.Columns.AddRange(new DataGridViewColumn[] { colId, colProductName, colQuantity });
            dgv.Dock = DockStyle.Fill;
            dgv.Location = new Point(0, 42);
            dgv.Name = "dgv";
            dgv.ReadOnly = true;
            dgv.RowHeadersVisible = false;
            dgv.RowHeadersWidth = 82;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.Size = new Size(1161, 646);
            dgv.TabIndex = 1;
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
            // colProductName
            // 
            colProductName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colProductName.HeaderText = "Product Name";
            colProductName.MinimumWidth = 10;
            colProductName.Name = "colProductName";
            colProductName.ReadOnly = true;
            // 
            // colQuantity
            // 
            colQuantity.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colQuantity.HeaderText = "Quantity";
            colQuantity.MinimumWidth = 10;
            colQuantity.Name = "colQuantity";
            colQuantity.ReadOnly = true;
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(32, 32);
            toolStrip1.Items.AddRange(new ToolStripItem[] { btnAddProduct, btnRemoveProduct, btnEditProduct });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1161, 42);
            toolStrip1.TabIndex = 1;
            toolStrip1.Text = "toolStrip1";
            // 
            // btnAddProduct
            // 
            btnAddProduct.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btnAddProduct.Image = (Image)resources.GetObject("btnAddProduct.Image");
            btnAddProduct.ImageTransparentColor = Color.Magenta;
            btnAddProduct.Name = "btnAddProduct";
            btnAddProduct.Size = new Size(61, 36);
            btnAddProduct.Text = "Add";
            btnAddProduct.Click += btnAddProduct_Click;
            // 
            // btnRemoveProduct
            // 
            btnRemoveProduct.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btnRemoveProduct.Image = (Image)resources.GetObject("btnRemoveProduct.Image");
            btnRemoveProduct.ImageTransparentColor = Color.Magenta;
            btnRemoveProduct.Name = "btnRemoveProduct";
            btnRemoveProduct.Size = new Size(88, 36);
            btnRemoveProduct.Text = "Delete";
            btnRemoveProduct.Click += btnRemoveProduct_Click;
            // 
            // btnEditProduct
            // 
            btnEditProduct.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btnEditProduct.Image = (Image)resources.GetObject("btnEditProduct.Image");
            btnEditProduct.ImageTransparentColor = Color.Magenta;
            btnEditProduct.Name = "btnEditProduct";
            btnEditProduct.Size = new Size(58, 36);
            btnEditProduct.Text = "Edit";
            btnEditProduct.Click += btnEditProduct_Click;
            // 
            // frmCombosAE
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1935, 912);
            Controls.Add(splitContainer1);
            MaximumSize = new Size(1961, 983);
            MinimumSize = new Size(1961, 983);
            Name = "frmCombosAE";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmCombosAE";
            Load += frmCombosAE_Load;
            ((System.ComponentModel.ISupportInitialize)numSalePrice).EndInit();
            ((System.ComponentModel.ISupportInitialize)numReorderLevel).EndInit();
            ((System.ComponentModel.ISupportInitialize)numStock).EndInit();
            ((System.ComponentModel.ISupportInitialize)numPrice).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel1.PerformLayout();
            splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgv).EndInit();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private CheckBox checkBoxSuspended;
        private NumericUpDown numSalePrice;
        private Label label7;
        private NumericUpDown numReorderLevel;
        private Label label6;
        private Button btnCancel;
        private Button btnOk;
        private NumericUpDown numStock;
        private NumericUpDown numPrice;
        private Label label5;
        private TextBox txtComboName;
        private Label label4;
        private Label label3;
        private TextBox txtDescription;
        private Label label1;
        private DateTimePicker dtpStartDate;
        private Label label8;
        private Label label9;
        private DateTimePicker dtpEndDate;
        private ErrorProvider errorProvider1;
        private SplitContainer splitContainer1;
        private SplitContainer splitContainer2;
        private DataGridView dgv;
        private ToolStrip toolStrip1;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colProductName;
        private DataGridViewTextBoxColumn colQuantity;
        private ToolStripButton btnAddProduct;
        private ToolStripButton btnRemoveProduct;
        private ToolStripButton btnEditProduct;
    }
}