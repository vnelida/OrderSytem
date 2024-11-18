namespace Windows.Forms
{
    partial class frmAddToCombo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddToCombo));
            btnAdd = new Button();
            btnCancel = new Button();
            cboProducts = new ComboBox();
            label2 = new Label();
            numQuantity = new NumericUpDown();
            label1 = new Label();
            errorProvider1 = new ErrorProvider(components);
            splitContainer1 = new SplitContainer();
            ((System.ComponentModel.ISupportInitialize)numQuantity).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // btnAdd
            // 
            btnAdd.BackgroundImage = (Image)resources.GetObject("btnAdd.BackgroundImage");
            btnAdd.Location = new Point(424, 14);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(150, 46);
            btnAdd.TabIndex = 0;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.IndianRed;
            btnCancel.ForeColor = SystemColors.ButtonHighlight;
            btnCancel.Location = new Point(620, 14);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(150, 46);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // cboProducts
            // 
            cboProducts.DropDownStyle = ComboBoxStyle.DropDownList;
            cboProducts.FormattingEnabled = true;
            cboProducts.ItemHeight = 32;
            cboProducts.Location = new Point(269, 67);
            cboProducts.Margin = new Padding(6);
            cboProducts.Name = "cboProducts";
            cboProducts.Size = new Size(327, 40);
            cboProducts.TabIndex = 26;
            cboProducts.SelectedIndexChanged += cboProducts_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Location = new Point(143, 70);
            label2.Margin = new Padding(6, 0, 6, 0);
            label2.Name = "label2";
            label2.Size = new Size(111, 32);
            label2.TabIndex = 25;
            label2.Text = "Products:";
            // 
            // numQuantity
            // 
            numQuantity.Location = new Point(269, 150);
            numQuantity.Margin = new Padding(6);
            numQuantity.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numQuantity.Name = "numQuantity";
            numQuantity.Size = new Size(223, 39);
            numQuantity.TabIndex = 28;
            numQuantity.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Location = new Point(140, 152);
            label1.Margin = new Padding(6, 0, 6, 0);
            label1.Name = "label1";
            label1.Size = new Size(111, 32);
            label1.TabIndex = 27;
            label1.Text = "Quantity:";
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
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.BackgroundImage = (Image)resources.GetObject("splitContainer1.Panel1.BackgroundImage");
            splitContainer1.Panel1.Controls.Add(cboProducts);
            splitContainer1.Panel1.Controls.Add(numQuantity);
            splitContainer1.Panel1.Controls.Add(label2);
            splitContainer1.Panel1.Controls.Add(label1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.BackgroundImage = (Image)resources.GetObject("splitContainer1.Panel2.BackgroundImage");
            splitContainer1.Panel2.Controls.Add(btnCancel);
            splitContainer1.Panel2.Controls.Add(btnAdd);
            splitContainer1.Size = new Size(832, 348);
            splitContainer1.SplitterDistance = 263;
            splitContainer1.TabIndex = 29;
            // 
            // frmAddToCombo
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            ClientSize = new Size(832, 348);
            Controls.Add(splitContainer1);
            MaximumSize = new Size(858, 419);
            MinimumSize = new Size(858, 419);
            Name = "frmAddToCombo";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AddToCombo";
            ((System.ComponentModel.ISupportInitialize)numQuantity).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button btnAdd;
        private Button btnCancel;
        private ComboBox cboProducts;
        private Label label2;
        private NumericUpDown numQuantity;
        private Label label1;
        private ErrorProvider errorProvider1;
        private SplitContainer splitContainer1;
    }
}