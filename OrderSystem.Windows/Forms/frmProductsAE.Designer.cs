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
            cboCategories = new ComboBox();
            label2 = new Label();
            txtDescription = new TextBox();
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
            ((System.ComponentModel.ISupportInitialize)numPrice).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numStock).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // cboCategories
            // 
            cboCategories.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCategories.FormattingEnabled = true;
            cboCategories.ItemHeight = 32;
            cboCategories.Location = new Point(220, 224);
            cboCategories.Margin = new Padding(6);
            cboCategories.Name = "cboCategories";
            cboCategories.Size = new Size(327, 40);
            cboCategories.TabIndex = 24;
            cboCategories.SelectedIndexChanged += cboCategories_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(94, 227);
            label2.Margin = new Padding(6, 0, 6, 0);
            label2.Name = "label2";
            label2.Size = new Size(122, 32);
            label2.TabIndex = 23;
            label2.Text = "Category: ";
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(220, 155);
            txtDescription.Margin = new Padding(6);
            txtDescription.MaxLength = 50;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(610, 39);
            txtDescription.TabIndex = 21;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(61, 158);
            label1.Margin = new Padding(6, 0, 6, 0);
            label1.Name = "label1";
            label1.Size = new Size(147, 32);
            label1.TabIndex = 22;
            label1.Text = "Description: ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(134, 379);
            label3.Margin = new Padding(6, 0, 6, 0);
            label3.Name = "label3";
            label3.Size = new Size(77, 32);
            label3.TabIndex = 26;
            label3.Text = "Price: ";
            // 
            // txtProductName
            // 
            txtProductName.Location = new Point(220, 76);
            txtProductName.Margin = new Padding(6);
            txtProductName.MaxLength = 50;
            txtProductName.Name = "txtProductName";
            txtProductName.Size = new Size(327, 39);
            txtProductName.TabIndex = 27;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(29, 79);
            label4.Margin = new Padding(6, 0, 6, 0);
            label4.Name = "label4";
            label4.Size = new Size(179, 32);
            label4.TabIndex = 28;
            label4.Text = "Prodcut Name: ";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(128, 308);
            label5.Margin = new Padding(6, 0, 6, 0);
            label5.Name = "label5";
            label5.Size = new Size(83, 32);
            label5.TabIndex = 30;
            label5.Text = "Stock: ";
            // 
            // numPrice
            // 
            numPrice.DecimalPlaces = 2;
            numPrice.Location = new Point(220, 379);
            numPrice.Name = "numPrice";
            numPrice.Size = new Size(240, 39);
            numPrice.TabIndex = 31;
            // 
            // numStock
            // 
            numStock.Location = new Point(220, 306);
            numStock.Name = "numStock";
            numStock.Size = new Size(240, 39);
            numStock.TabIndex = 32;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(665, 484);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(165, 73);
            btnCancel.TabIndex = 34;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnOk
            // 
            btnOk.Location = new Point(474, 484);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(165, 73);
            btnOk.TabIndex = 33;
            btnOk.Text = "Ok";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // frmProductsAE
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(908, 597);
            Controls.Add(btnCancel);
            Controls.Add(btnOk);
            Controls.Add(numStock);
            Controls.Add(numPrice);
            Controls.Add(label5);
            Controls.Add(txtProductName);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(cboCategories);
            Controls.Add(label2);
            Controls.Add(txtDescription);
            Controls.Add(label1);
            Name = "frmProductsAE";
            ((System.ComponentModel.ISupportInitialize)numPrice).EndInit();
            ((System.ComponentModel.ISupportInitialize)numStock).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cboCategories;
        private Label label2;
        private TextBox txtDescription;
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
    }
}