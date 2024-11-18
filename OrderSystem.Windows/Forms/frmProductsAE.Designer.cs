namespace Windows.Forms
{
    partial class frmProductsAE
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProductsAE));
            cboCategories = new ComboBox();
            label2 = new Label();
            label1 = new Label();
            label3 = new Label();
            txtProductName = new TextBox();
            label4 = new Label();
            label5 = new Label();
            numPrice = new NumericUpDown();
            numStock = new NumericUpDown();
            btnCancel = new Button();
            btnOk = new Button();
            errorProvider1 = new ErrorProvider(components);
            numReorderLevel = new NumericUpDown();
            label6 = new Label();
            numSalePrice = new NumericUpDown();
            label7 = new Label();
            Suspended = new Label();
            checkBoxSuspended = new CheckBox();
            picImage = new PictureBox();
            openFileDialog1 = new OpenFileDialog();
            btnSearchImages = new Button();
            groupBox1 = new GroupBox();
            splitContainer1 = new SplitContainer();
            txtBoxDescription = new RichTextBox();
            ((System.ComponentModel.ISupportInitialize)numPrice).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numStock).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numReorderLevel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numSalePrice).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picImage).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // cboCategories
            // 
            cboCategories.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCategories.FormattingEnabled = true;
            cboCategories.ItemHeight = 32;
            cboCategories.Location = new Point(693, 134);
            cboCategories.Margin = new Padding(6);
            cboCategories.Name = "cboCategories";
            cboCategories.Size = new Size(327, 40);
            cboCategories.TabIndex = 2;
            cboCategories.SelectedIndexChanged += cboCategories_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Location = new Point(567, 137);
            label2.Margin = new Padding(6, 0, 6, 0);
            label2.Name = "label2";
            label2.Size = new Size(122, 32);
            label2.TabIndex = 23;
            label2.Text = "Category: ";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Location = new Point(53, 134);
            label1.Margin = new Padding(6, 0, 6, 0);
            label1.Name = "label1";
            label1.Size = new Size(147, 32);
            label1.TabIndex = 22;
            label1.Text = "Description: ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Location = new Point(37, 427);
            label3.Margin = new Padding(6, 0, 6, 0);
            label3.Name = "label3";
            label3.Size = new Size(131, 32);
            label3.TabIndex = 26;
            label3.Text = "Cost Price: ";
            // 
            // txtProductName
            // 
            txtProductName.Location = new Point(212, 52);
            txtProductName.Margin = new Padding(6);
            txtProductName.MaxLength = 50;
            txtProductName.Name = "txtProductName";
            txtProductName.Size = new Size(327, 39);
            txtProductName.TabIndex = 0;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Location = new Point(21, 55);
            label4.Margin = new Padding(6, 0, 6, 0);
            label4.Name = "label4";
            label4.Size = new Size(179, 32);
            label4.TabIndex = 28;
            label4.Text = "Prodcut Name: ";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Location = new Point(88, 358);
            label5.Margin = new Padding(6, 0, 6, 0);
            label5.Name = "label5";
            label5.Size = new Size(83, 32);
            label5.TabIndex = 30;
            label5.Text = "Stock: ";
            // 
            // numPrice
            // 
            numPrice.DecimalPlaces = 2;
            numPrice.Location = new Point(180, 427);
            numPrice.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numPrice.Name = "numPrice";
            numPrice.Size = new Size(240, 39);
            numPrice.TabIndex = 4;
            // 
            // numStock
            // 
            numStock.Location = new Point(180, 356);
            numStock.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numStock.Name = "numStock";
            numStock.Size = new Size(240, 39);
            numStock.TabIndex = 3;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.IndianRed;
            btnCancel.ForeColor = SystemColors.ButtonFace;
            btnCancel.Location = new Point(817, 16);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(165, 73);
            btnCancel.TabIndex = 8;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnOk
            // 
            btnOk.BackgroundImage = (Image)resources.GetObject("btnOk.BackgroundImage");
            btnOk.Location = new Point(626, 16);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(165, 73);
            btnOk.TabIndex = 7;
            btnOk.Text = "Save";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // numReorderLevel
            // 
            numReorderLevel.Location = new Point(693, 358);
            numReorderLevel.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numReorderLevel.Name = "numReorderLevel";
            numReorderLevel.Size = new Size(240, 39);
            numReorderLevel.TabIndex = 6;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Location = new Point(520, 360);
            label6.Margin = new Padding(6, 0, 6, 0);
            label6.Name = "label6";
            label6.Size = new Size(164, 32);
            label6.TabIndex = 35;
            label6.Text = "Reorder Level:";
            // 
            // numSalePrice
            // 
            numSalePrice.DecimalPlaces = 2;
            numSalePrice.Location = new Point(693, 431);
            numSalePrice.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numSalePrice.Name = "numSalePrice";
            numSalePrice.Size = new Size(240, 39);
            numSalePrice.TabIndex = 5;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Location = new Point(546, 431);
            label7.Margin = new Padding(6, 0, 6, 0);
            label7.Name = "label7";
            label7.Size = new Size(138, 32);
            label7.TabIndex = 37;
            label7.Text = "Sales Price: ";
            // 
            // Suspended
            // 
            Suspended.AutoSize = true;
            Suspended.Location = new Point(63, 484);
            Suspended.Name = "Suspended";
            Suspended.Size = new Size(0, 32);
            Suspended.TabIndex = 39;
            // 
            // checkBoxSuspended
            // 
            checkBoxSuspended.AutoSize = true;
            checkBoxSuspended.Location = new Point(729, 64);
            checkBoxSuspended.Name = "checkBoxSuspended";
            checkBoxSuspended.Size = new Size(165, 36);
            checkBoxSuspended.TabIndex = 40;
            checkBoxSuspended.Text = "Suspended";
            checkBoxSuspended.UseVisualStyleBackColor = true;
            // 
            // picImage
            // 
            picImage.BackColor = Color.White;
            picImage.Location = new Point(49, 36);
            picImage.Name = "picImage";
            picImage.Size = new Size(412, 334);
            picImage.SizeMode = PictureBoxSizeMode.CenterImage;
            picImage.TabIndex = 41;
            picImage.TabStop = false;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnSearchImages
            // 
            btnSearchImages.Location = new Point(158, 402);
            btnSearchImages.Name = "btnSearchImages";
            btnSearchImages.Size = new Size(215, 46);
            btnSearchImages.TabIndex = 9;
            btnSearchImages.Text = "Search Images";
            btnSearchImages.UseVisualStyleBackColor = true;
            btnSearchImages.Click += btnSearchImages_Click;
            // 
            // groupBox1
            // 
            groupBox1.BackgroundImage = (Image)resources.GetObject("groupBox1.BackgroundImage");
            groupBox1.Controls.Add(picImage);
            groupBox1.Controls.Add(btnSearchImages);
            groupBox1.Location = new Point(1039, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(509, 548);
            groupBox1.TabIndex = 43;
            groupBox1.TabStop = false;
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
            splitContainer1.Panel1.BackgroundImage = (Image)resources.GetObject("splitContainer1.Panel1.BackgroundImage");
            splitContainer1.Panel1.Controls.Add(txtBoxDescription);
            splitContainer1.Panel1.Controls.Add(numReorderLevel);
            splitContainer1.Panel1.Controls.Add(groupBox1);
            splitContainer1.Panel1.Controls.Add(label6);
            splitContainer1.Panel1.Controls.Add(label7);
            splitContainer1.Panel1.Controls.Add(checkBoxSuspended);
            splitContainer1.Panel1.Controls.Add(numStock);
            splitContainer1.Panel1.Controls.Add(numSalePrice);
            splitContainer1.Panel1.Controls.Add(numPrice);
            splitContainer1.Panel1.Controls.Add(label4);
            splitContainer1.Panel1.Controls.Add(label5);
            splitContainer1.Panel1.Controls.Add(label1);
            splitContainer1.Panel1.Controls.Add(txtProductName);
            splitContainer1.Panel1.Controls.Add(label2);
            splitContainer1.Panel1.Controls.Add(label3);
            splitContainer1.Panel1.Controls.Add(cboCategories);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.BackgroundImage = (Image)resources.GetObject("splitContainer1.Panel2.BackgroundImage");
            splitContainer1.Panel2.Controls.Add(btnCancel);
            splitContainer1.Panel2.Controls.Add(btnOk);
            splitContainer1.Size = new Size(1601, 733);
            splitContainer1.SplitterDistance = 628;
            splitContainer1.TabIndex = 44;
            // 
            // txtBoxDescription
            // 
            txtBoxDescription.Location = new Point(212, 134);
            txtBoxDescription.Name = "txtBoxDescription";
            txtBoxDescription.Size = new Size(327, 136);
            txtBoxDescription.TabIndex = 44;
            txtBoxDescription.Text = "";
            // 
            // frmProductsAE
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Snow;
            ClientSize = new Size(1601, 733);
            Controls.Add(splitContainer1);
            Controls.Add(Suspended);
            MaximumSize = new Size(1627, 804);
            MinimumSize = new Size(1627, 804);
            Name = "frmProductsAE";
            StartPosition = FormStartPosition.CenterScreen;
            Load += frmProductsAE_Load;
            ((System.ComponentModel.ISupportInitialize)numPrice).EndInit();
            ((System.ComponentModel.ISupportInitialize)numStock).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numReorderLevel).EndInit();
            ((System.ComponentModel.ISupportInitialize)numSalePrice).EndInit();
            ((System.ComponentModel.ISupportInitialize)picImage).EndInit();
            groupBox1.ResumeLayout(false);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cboCategories;
        private Label label2;
        private Label label1;
        private Label label3;
        private TextBox txtProductName;
        private Label label4;
        private Label label5;
        private NumericUpDown numPrice;
        private NumericUpDown numStock;
        private Button btnCancel;
        private Button btnOk;
        private ErrorProvider errorProvider1;
        private NumericUpDown numSalePrice;
        private Label label7;
        private NumericUpDown numReorderLevel;
        private Label label6;
        private CheckBox checkBoxSuspended;
        private Label Suspended;
        private PictureBox picImage;
        private Button btnSearchImages;
        private OpenFileDialog openFileDialog1;
        private GroupBox groupBox1;
        private SplitContainer splitContainer1;
        private RichTextBox txtBoxDescription;
    }
}