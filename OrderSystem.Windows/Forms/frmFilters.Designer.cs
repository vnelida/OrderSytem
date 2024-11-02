namespace Windows.Forms
{
    partial class frmFilters
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
            errorProvider1 = new ErrorProvider(components);
            label1 = new Label();
            cboCategories = new ComboBox();
            btnCancel = new Button();
            btnOk = new Button();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(124, 100);
            label1.Name = "label1";
            label1.Size = new Size(110, 32);
            label1.TabIndex = 0;
            label1.Text = "Category";
            // 
            // cboCategories
            // 
            cboCategories.FormattingEnabled = true;
            cboCategories.Location = new Point(240, 97);
            cboCategories.Name = "cboCategories";
            cboCategories.Size = new Size(348, 40);
            cboCategories.TabIndex = 1;
            cboCategories.SelectedIndexChanged += cboPaises_SelectedIndexChanged;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(705, 202);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(165, 73);
            btnCancel.TabIndex = 8;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnOk
            // 
            btnOk.Location = new Point(514, 202);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(165, 73);
            btnOk.TabIndex = 7;
            btnOk.Text = "Ok";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // frmFilters
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(947, 328);
            Controls.Add(btnCancel);
            Controls.Add(btnOk);
            Controls.Add(cboCategories);
            Controls.Add(label1);
            Name = "frmFilters";
            Text = "frmFilters";
            Load += frmFilters_Load;
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ErrorProvider errorProvider1;
        private ComboBox cboCategories;
        private Label label1;
        private Button btnCancel;
        private Button btnOk;
    }
}