namespace Windows.Forms
{
    partial class frmCategoriesAE
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCategoriesAE));
            txtCategory = new TextBox();
            btnCancel = new Button();
            btnOk = new Button();
            label1 = new Label();
            errorProvider1 = new ErrorProvider(components);
            splitContainer1 = new SplitContainer();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // txtCategory
            // 
            txtCategory.ForeColor = SystemColors.WindowText;
            txtCategory.Location = new Point(300, 105);
            txtCategory.Name = "txtCategory";
            txtCategory.Size = new Size(330, 39);
            txtCategory.TabIndex = 0;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.IndianRed;
            btnCancel.ForeColor = SystemColors.ButtonFace;
            btnCancel.Location = new Point(675, 10);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(121, 61);
            btnCancel.TabIndex = 2;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnOk
            // 
            btnOk.BackgroundImage = (Image)resources.GetObject("btnOk.BackgroundImage");
            btnOk.Location = new Point(509, 10);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(121, 61);
            btnOk.TabIndex = 1;
            btnOk.Text = "Save";
            btnOk.UseVisualStyleBackColor = false;
            btnOk.Click += btnOk_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Location = new Point(169, 108);
            label1.Name = "label1";
            label1.Size = new Size(110, 32);
            label1.TabIndex = 4;
            label1.Text = "Category";
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
            splitContainer1.Panel1.Controls.Add(txtCategory);
            splitContainer1.Panel1.Controls.Add(label1);
            splitContainer1.Panel1.Paint += splitContainer1_Panel1_Paint;
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.BackgroundImage = (Image)resources.GetObject("splitContainer1.Panel2.BackgroundImage");
            splitContainer1.Panel2.Controls.Add(btnCancel);
            splitContainer1.Panel2.Controls.Add(btnOk);
            splitContainer1.Size = new Size(832, 348);
            splitContainer1.SplitterDistance = 261;
            splitContainer1.TabIndex = 5;
            // 
            // frmCategoriesAE
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            ClientSize = new Size(832, 348);
            Controls.Add(splitContainer1);
            MaximumSize = new Size(858, 419);
            MinimumSize = new Size(858, 419);
            Name = "frmCategoriesAE";
            StartPosition = FormStartPosition.CenterScreen;
            Text = " ";
            Load += frmCategoriesAE_Load;
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TextBox txtCategory;
        private Button btnCancel;
        private Button btnOk;
        private Label label1;
        private ErrorProvider errorProvider1;
        private SplitContainer splitContainer1;
    }
}