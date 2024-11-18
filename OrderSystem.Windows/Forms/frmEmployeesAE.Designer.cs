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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEmployeesAE));
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
            groupBox2 = new GroupBox();
            splitContainer1 = new SplitContainer();
            groupBox3 = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // txtLastName
            // 
            txtLastName.Location = new Point(747, 38);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(330, 39);
            txtLastName.TabIndex = 2;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.Chocolate;
            btnCancel.ForeColor = SystemColors.ButtonFace;
            btnCancel.Location = new Point(634, 24);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(165, 73);
            btnCancel.TabIndex = 10;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnOk
            // 
            btnOk.BackgroundImage = (Image)resources.GetObject("btnOk.BackgroundImage");
            btnOk.Location = new Point(443, 24);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(165, 73);
            btnOk.TabIndex = 1;
            btnOk.Text = "Save";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Location = new Point(587, 41);
            label1.Name = "label1";
            label1.Size = new Size(126, 32);
            label1.TabIndex = 8;
            label1.Text = "Last Name";
            // 
            // txtFirstName
            // 
            txtFirstName.Location = new Point(197, 38);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(330, 39);
            txtFirstName.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Location = new Point(34, 41);
            label3.Name = "label3";
            label3.Size = new Size(129, 32);
            label3.TabIndex = 3;
            label3.Text = "First Name";
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(184, 54);
            txtPhone.MaxLength = 999999999;
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(330, 39);
            txtPhone.TabIndex = 3;
            txtPhone.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Location = new Point(68, 57);
            label2.Name = "label2";
            label2.Size = new Size(82, 32);
            label2.TabIndex = 18;
            label2.Text = "Phone";
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(772, 57);
            txtAddress.MaxLength = 999999999;
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(330, 39);
            txtAddress.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Location = new Point(640, 60);
            label4.Name = "label4";
            label4.Size = new Size(98, 32);
            label4.TabIndex = 16;
            label4.Text = "Address";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(184, 141);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(330, 39);
            txtEmail.TabIndex = 4;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Location = new Point(79, 144);
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
            txtDni.Location = new Point(197, 153);
            txtDni.MaxLength = 999999999;
            txtDni.Name = "txtDni";
            txtDni.Size = new Size(330, 39);
            txtDni.TabIndex = 6;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Location = new Point(108, 153);
            label6.Name = "label6";
            label6.Size = new Size(55, 32);
            label6.TabIndex = 22;
            label6.Text = "DNI";
            // 
            // dtpBDate
            // 
            dtpBDate.Format = DateTimePickerFormat.Short;
            dtpBDate.Location = new Point(603, 298);
            dtpBDate.Name = "dtpBDate";
            dtpBDate.Size = new Size(250, 39);
            dtpBDate.TabIndex = 7;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(422, 298);
            label7.Name = "label7";
            label7.Size = new Size(150, 32);
            label7.TabIndex = 25;
            label7.Text = "Date of birth";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Location = new Point(634, 145);
            label8.Name = "label8";
            label8.Size = new Size(78, 32);
            label8.TabIndex = 26;
            label8.Text = "Genre";
            // 
            // cboGenres
            // 
            cboGenres.FormattingEnabled = true;
            cboGenres.Location = new Point(747, 145);
            cboGenres.Name = "cboGenres";
            cboGenres.Size = new Size(330, 40);
            cboGenres.TabIndex = 8;
            cboGenres.SelectedIndexChanged += cboGenres_SelectedIndexChanged;
            // 
            // groupBox2
            // 
            groupBox2.BackgroundImage = (Image)resources.GetObject("groupBox2.BackgroundImage");
            groupBox2.Controls.Add(txtEmail);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(txtPhone);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(txtAddress);
            groupBox2.Controls.Add(label4);
            groupBox2.Location = new Point(48, 369);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1174, 212);
            groupBox2.TabIndex = 28;
            groupBox2.TabStop = false;
            groupBox2.Text = "Contact Information";
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
            splitContainer1.Panel1.BackColor = Color.Transparent;
            splitContainer1.Panel1.BackgroundImage = (Image)resources.GetObject("splitContainer1.Panel1.BackgroundImage");
            splitContainer1.Panel1.Controls.Add(groupBox3);
            splitContainer1.Panel1.Controls.Add(groupBox2);
            splitContainer1.Panel1.Controls.Add(label7);
            splitContainer1.Panel1.Controls.Add(dtpBDate);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.BackgroundImage = (Image)resources.GetObject("splitContainer1.Panel2.BackgroundImage");
            splitContainer1.Panel2.Controls.Add(btnCancel);
            splitContainer1.Panel2.Controls.Add(btnOk);
            splitContainer1.Size = new Size(1264, 773);
            splitContainer1.SplitterDistance = 644;
            splitContainer1.TabIndex = 0;
            // 
            // groupBox3
            // 
            groupBox3.BackgroundImage = (Image)resources.GetObject("groupBox3.BackgroundImage");
            groupBox3.Controls.Add(txtLastName);
            groupBox3.Controls.Add(txtFirstName);
            groupBox3.Controls.Add(label1);
            groupBox3.Controls.Add(label6);
            groupBox3.Controls.Add(cboGenres);
            groupBox3.Controls.Add(label8);
            groupBox3.Controls.Add(txtDni);
            groupBox3.Controls.Add(label3);
            groupBox3.Location = new Point(48, 27);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(1174, 212);
            groupBox3.TabIndex = 1;
            groupBox3.TabStop = false;
            groupBox3.Enter += groupBox3_Enter;
            // 
            // frmEmployeesAE
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            ClientSize = new Size(1264, 773);
            Controls.Add(splitContainer1);
            MaximumSize = new Size(1290, 844);
            MinimumSize = new Size(1290, 844);
            Name = "frmEmployeesAE";
            StartPosition = FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ResumeLayout(false);
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
        private GroupBox groupBox2;
        private SplitContainer splitContainer1;
        private GroupBox groupBox3;
    }
}