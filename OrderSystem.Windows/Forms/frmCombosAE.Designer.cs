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
            label1 = new Label();
            dtpStartDate = new DateTimePicker();
            label8 = new Label();
            label9 = new Label();
            dtpEndDate = new DateTimePicker();
            errorProvider1 = new ErrorProvider(components);
            splitContainer1 = new SplitContainer();
            txtDescription = new RichTextBox();
            splitContainer2 = new SplitContainer();
            dgv = new DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colProductName = new DataGridViewTextBoxColumn();
            colQuantity = new DataGridViewTextBoxColumn();
            toolStrip1 = new ToolStrip();
            btnNew = new ToolStripButton();
            btnDelete = new ToolStripButton();
            btnEdit = new ToolStripButton();
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
            checkBoxSuspended.BackColor = Color.Transparent;
            checkBoxSuspended.Location = new Point(307, 823);
            checkBoxSuspended.Name = "checkBoxSuspended";
            checkBoxSuspended.Size = new Size(165, 36);
            checkBoxSuspended.TabIndex = 8;
            checkBoxSuspended.Text = "Suspended";
            checkBoxSuspended.UseVisualStyleBackColor = false;
            // 
            // numSalePrice
            // 
            numSalePrice.DecimalPlaces = 2;
            numSalePrice.Location = new Point(307, 715);
            numSalePrice.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numSalePrice.Name = "numSalePrice";
            numSalePrice.Size = new Size(240, 39);
            numSalePrice.TabIndex = 5;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Location = new Point(160, 715);
            label7.Margin = new Padding(6, 0, 6, 0);
            label7.Name = "label7";
            label7.Size = new Size(131, 32);
            label7.TabIndex = 55;
            label7.Text = "Sales Price:";
            // 
            // numReorderLevel
            // 
            numReorderLevel.Location = new Point(307, 642);
            numReorderLevel.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numReorderLevel.Name = "numReorderLevel";
            numReorderLevel.Size = new Size(240, 39);
            numReorderLevel.TabIndex = 4;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Location = new Point(134, 644);
            label6.Margin = new Padding(6, 0, 6, 0);
            label6.Name = "label6";
            label6.Size = new Size(164, 32);
            label6.TabIndex = 53;
            label6.Text = "Reorder Level:";
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.IndianRed;
            btnCancel.ForeColor = SystemColors.ButtonHighlight;
            btnCancel.Location = new Point(903, 31);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(209, 96);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnOk
            // 
            btnOk.BackgroundImage = (Image)resources.GetObject("btnOk.BackgroundImage");
            btnOk.Location = new Point(619, 33);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(209, 96);
            btnOk.TabIndex = 1;
            btnOk.Text = "Save";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // numStock
            // 
            numStock.Location = new Point(307, 456);
            numStock.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numStock.Name = "numStock";
            numStock.Size = new Size(240, 39);
            numStock.TabIndex = 2;
            // 
            // numPrice
            // 
            numPrice.DecimalPlaces = 2;
            numPrice.Location = new Point(307, 527);
            numPrice.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numPrice.Name = "numPrice";
            numPrice.Size = new Size(240, 39);
            numPrice.TabIndex = 3;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Location = new Point(222, 463);
            label5.Margin = new Padding(6, 0, 6, 0);
            label5.Name = "label5";
            label5.Size = new Size(76, 32);
            label5.TabIndex = 48;
            label5.Text = "Stock:";
            // 
            // txtComboName
            // 
            txtComboName.Location = new Point(212, 45);
            txtComboName.Margin = new Padding(6);
            txtComboName.MaxLength = 50;
            txtComboName.Name = "txtComboName";
            txtComboName.Size = new Size(409, 39);
            txtComboName.TabIndex = 0;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Location = new Point(25, 52);
            label4.Margin = new Padding(6, 0, 6, 0);
            label4.Name = "label4";
            label4.Size = new Size(175, 32);
            label4.TabIndex = 16;
            label4.Text = "Combo Name: ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Location = new Point(171, 532);
            label3.Margin = new Padding(6, 0, 6, 0);
            label3.Name = "label3";
            label3.Size = new Size(124, 32);
            label3.TabIndex = 45;
            label3.Text = "Cost Price:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Location = new Point(56, 127);
            label1.Margin = new Padding(6, 0, 6, 0);
            label1.Name = "label1";
            label1.Size = new Size(147, 32);
            label1.TabIndex = 42;
            label1.Text = "Description: ";
            // 
            // dtpStartDate
            // 
            dtpStartDate.Format = DateTimePickerFormat.Short;
            dtpStartDate.Location = new Point(149, 328);
            dtpStartDate.Name = "dtpStartDate";
            dtpStartDate.Size = new Size(240, 39);
            dtpStartDate.TabIndex = 6;
            dtpStartDate.Value = new DateTime(2024, 11, 6, 0, 0, 0, 0);
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Location = new Point(12, 335);
            label8.Name = "label8";
            label8.Size = new Size(131, 32);
            label8.TabIndex = 59;
            label8.Text = "Start Date: ";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.Transparent;
            label9.Location = new Point(428, 335);
            label9.Name = "label9";
            label9.Size = new Size(116, 32);
            label9.TabIndex = 61;
            label9.Text = "End Date:";
            // 
            // dtpEndDate
            // 
            dtpEndDate.Format = DateTimePickerFormat.Short;
            dtpEndDate.Location = new Point(550, 328);
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
            splitContainer1.Panel1.BackColor = SystemColors.ButtonHighlight;
            splitContainer1.Panel1.BackgroundImage = Properties.Resources.Captura_de_pantalla_2025_08_02_005150;
            splitContainer1.Panel1.Controls.Add(txtDescription);
            splitContainer1.Panel1.Controls.Add(label4);
            splitContainer1.Panel1.Controls.Add(checkBoxSuspended);
            splitContainer1.Panel1.Controls.Add(label9);
            splitContainer1.Panel1.Controls.Add(label1);
            splitContainer1.Panel1.Controls.Add(dtpEndDate);
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
            splitContainer1.SplitterDistance = 807;
            splitContainer1.TabIndex = 0;
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(212, 124);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(409, 139);
            txtDescription.TabIndex = 62;
            txtDescription.Text = "";
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
            splitContainer2.Panel2.BackgroundImage = (Image)resources.GetObject("splitContainer2.Panel2.BackgroundImage");
            splitContainer2.Panel2.Controls.Add(btnOk);
            splitContainer2.Panel2.Controls.Add(btnCancel);
            splitContainer2.Size = new Size(1124, 912);
            splitContainer2.SplitterDistance = 757;
            splitContainer2.TabIndex = 9;
            // 
            // dgv
            // 
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.BackgroundColor = SystemColors.ButtonHighlight;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv.Columns.AddRange(new DataGridViewColumn[] { colId, colProductName, colQuantity });
            dgv.Dock = DockStyle.Fill;
            dgv.Location = new Point(0, 106);
            dgv.Name = "dgv";
            dgv.ReadOnly = true;
            dgv.RowHeadersVisible = false;
            dgv.RowHeadersWidth = 82;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.Size = new Size(1124, 651);
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
            toolStrip1.BackColor = SystemColors.ButtonHighlight;
            toolStrip1.ImageScalingSize = new Size(32, 32);
            toolStrip1.Items.AddRange(new ToolStripItem[] { btnNew, btnDelete, btnEdit });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1124, 106);
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
            btnNew.Click += btnAddProduct_Click;
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
            btnDelete.Click += btnRemoveProduct_Click;
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
            btnEdit.Click += btnEditProduct_Click;
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
        private ToolStripButton btnNew;
        private ToolStripButton btnDelete;
        private ToolStripButton btnEdit;
        private RichTextBox txtDescription;
    }
}