namespace Windows.Forms
{
    partial class frmEmployeesAE
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
            txtLastName = new TextBox();
            btnCancel = new Button();
            btnOk = new Button();
            label1 = new Label();
            txtFirstName = new TextBox();
            label3 = new Label();
            txtPhone = new TextBox();
            label2 = new Label();
            txtAddress = new TextBox();
            label4 = new Label();
            txtEmail = new TextBox();
            label5 = new Label();
            errorProvider1 = new ErrorProvider(components);
            txtDni = new TextBox();
            label6 = new Label();
            dtpBDate = new DateTimePicker();
            label7 = new Label();
            label8 = new Label();
            cboGenres = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // txtLastName
            // 
            txtLastName.Location = new Point(261, 180);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(330, 39);
            txtLastName.TabIndex = 2;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(653, 580);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(165, 73);
            btnCancel.TabIndex = 10;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnOk
            // 
            btnOk.Location = new Point(462, 580);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(165, 73);
            btnOk.TabIndex = 1;
            btnOk.Text = "Ok";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(101, 183);
            label1.Name = "label1";
            label1.Size = new Size(126, 32);
            label1.TabIndex = 8;
            label1.Text = "Last Name";
            // 
            // txtFirstName
            // 
            txtFirstName.Location = new Point(261, 97);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(330, 39);
            txtFirstName.TabIndex = 0;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(98, 100);
            label3.Name = "label3";
            label3.Size = new Size(129, 32);
            label3.TabIndex = 14;
            label3.Text = "First Name";
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(261, 251);
            txtPhone.MaxLength = 999999999;
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(330, 39);
            txtPhone.TabIndex = 3;
            txtPhone.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(145, 254);
            label2.Name = "label2";
            label2.Size = new Size(82, 32);
            label2.TabIndex = 18;
            label2.Text = "Phone";
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(261, 413);
            txtAddress.MaxLength = 999999999;
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(330, 39);
            txtAddress.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(129, 416);
            label4.Name = "label4";
            label4.Size = new Size(98, 32);
            label4.TabIndex = 16;
            label4.Text = "Address";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(261, 338);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(330, 39);
            txtEmail.TabIndex = 4;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(156, 341);
            label5.Name = "label5";
            label5.Size = new Size(71, 32);
            label5.TabIndex = 20;
            label5.Text = "Email";
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // txtDni
            // 
            txtDni.Location = new Point(261, 488);
            txtDni.MaxLength = 999999999;
            txtDni.Name = "txtDni";
            txtDni.Size = new Size(330, 39);
            txtDni.TabIndex = 6;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(172, 488);
            label6.Name = "label6";
            label6.Size = new Size(55, 32);
            label6.TabIndex = 22;
            label6.Text = "DNI";
            // 
            // dtpBDate
            // 
            dtpBDate.Format = DateTimePickerFormat.Short;
            dtpBDate.Location = new Point(759, 206);
            dtpBDate.Name = "dtpBDate";
            dtpBDate.Size = new Size(250, 39);
            dtpBDate.TabIndex = 7;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(759, 162);
            label7.Name = "label7";
            label7.Size = new Size(150, 32);
            label7.TabIndex = 25;
            label7.Text = "Date of birth";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(738, 300);
            label8.Name = "label8";
            label8.Size = new Size(78, 32);
            label8.TabIndex = 26;
            label8.Text = "Genre";
            // 
            // cboGenres
            // 
            cboGenres.FormattingEnabled = true;
            cboGenres.Location = new Point(851, 300);
            cboGenres.Name = "cboGenres";
            cboGenres.Size = new Size(242, 40);
            cboGenres.TabIndex = 8;
            cboGenres.SelectedIndexChanged += cboGenres_SelectedIndexChanged;
            // 
            // frmEmployeesAE
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1338, 720);
            Controls.Add(cboGenres);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(dtpBDate);
            Controls.Add(txtDni);
            Controls.Add(label6);
            Controls.Add(txtEmail);
            Controls.Add(label5);
            Controls.Add(txtPhone);
            Controls.Add(label2);
            Controls.Add(txtAddress);
            Controls.Add(label4);
            Controls.Add(txtFirstName);
            Controls.Add(label3);
            Controls.Add(txtLastName);
            Controls.Add(btnCancel);
            Controls.Add(btnOk);
            Controls.Add(label1);
            Name = "frmEmployeesAE";
            StartPosition = FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtLastName;
        private Button btnCancel;
        private Button btnOk;
        private Label label1;
        private TextBox txtFirstName;
        private Label label3;
        private TextBox txtPhone;
        private Label label2;
        private TextBox txtAddress;
        private Label label4;
        private TextBox txtEmail;
        private Label label5;
        private ErrorProvider errorProvider1;
        private TextBox txtDni;
        private Label label6;
        private Label label8;
        private Label label7;
        private DateTimePicker dtpBDate;
        private ComboBox cboGenres;
    }
}