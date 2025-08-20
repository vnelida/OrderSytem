namespace Windows.Forms
{
    partial class frmUsersAE
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUsersAE));
            txtUserName = new TextBox();
            label6 = new Label();
            cboRol = new ComboBox();
            label8 = new Label();
            txtPassword = new TextBox();
            label3 = new Label();
            checkBoxActive = new CheckBox();
            label2 = new Label();
            txtConfirmPassword = new TextBox();
            splitContainer1 = new SplitContainer();
            btnOk = new Button();
            btnCancel = new Button();
            errorProvider1 = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // txtUserName
            // 
            txtUserName.Location = new Point(272, 124);
            txtUserName.Name = "txtUserName";
            txtUserName.Size = new Size(330, 39);
            txtUserName.TabIndex = 27;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Location = new Point(155, 222);
            label6.Name = "label6";
            label6.Size = new Size(111, 32);
            label6.TabIndex = 33;
            label6.Text = "Password";
            // 
            // cboRol
            // 
            cboRol.DropDownStyle = ComboBoxStyle.DropDownList;
            cboRol.FormattingEnabled = true;
            cboRol.Location = new Point(732, 119);
            cboRol.Name = "cboRol";
            cboRol.Size = new Size(330, 40);
            cboRol.TabIndex = 32;
            cboRol.SelectedIndexChanged += cboRol_SelectedIndexChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Location = new Point(641, 122);
            label8.Name = "label8";
            label8.Size = new Size(60, 32);
            label8.TabIndex = 34;
            label8.Text = "Role";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(272, 215);
            txtPassword.MaxLength = 999999999;
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(330, 39);
            txtPassword.TabIndex = 30;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Location = new Point(134, 124);
            label3.Name = "label3";
            label3.Size = new Size(132, 32);
            label3.TabIndex = 29;
            label3.Text = "User Name";
            // 
            // checkBoxActive
            // 
            checkBoxActive.AutoSize = true;
            checkBoxActive.BackColor = Color.Transparent;
            checkBoxActive.Location = new Point(732, 218);
            checkBoxActive.Name = "checkBoxActive";
            checkBoxActive.Size = new Size(111, 36);
            checkBoxActive.TabIndex = 35;
            checkBoxActive.Text = "Active";
            checkBoxActive.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Location = new Point(62, 295);
            label2.Name = "label2";
            label2.Size = new Size(204, 32);
            label2.TabIndex = 37;
            label2.Text = "Confirm Password";
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.Location = new Point(272, 292);
            txtConfirmPassword.MaxLength = 999999999;
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.PasswordChar = '*';
            txtConfirmPassword.Size = new Size(330, 39);
            txtConfirmPassword.TabIndex = 36;
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
            splitContainer1.Panel1.BackgroundImage = Properties.Resources.Captura_de_pantalla_2025_08_02_005150;
            splitContainer1.Panel1.Controls.Add(cboRol);
            splitContainer1.Panel1.Controls.Add(label2);
            splitContainer1.Panel1.Controls.Add(label3);
            splitContainer1.Panel1.Controls.Add(txtConfirmPassword);
            splitContainer1.Panel1.Controls.Add(txtPassword);
            splitContainer1.Panel1.Controls.Add(checkBoxActive);
            splitContainer1.Panel1.Controls.Add(label8);
            splitContainer1.Panel1.Controls.Add(txtUserName);
            splitContainer1.Panel1.Controls.Add(label6);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.BackgroundImage = Properties.Resources.Green_Retro_Illustrative_Fast_Food_Logo__1_1;
            splitContainer1.Panel2.Controls.Add(btnOk);
            splitContainer1.Panel2.Controls.Add(btnCancel);
            splitContainer1.Size = new Size(1174, 629);
            splitContainer1.SplitterDistance = 483;
            splitContainer1.TabIndex = 38;
            // 
            // btnOk
            // 
            btnOk.BackgroundImage = (Image)resources.GetObject("btnOk.BackgroundImage");
            btnOk.Location = new Point(569, 19);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(209, 96);
            btnOk.TabIndex = 4;
            btnOk.Text = "Save";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.IndianRed;
            btnCancel.ForeColor = SystemColors.ButtonHighlight;
            btnCancel.Location = new Point(853, 17);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(209, 96);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // frmUsersAE
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1174, 629);
            Controls.Add(splitContainer1);
            MaximumSize = new Size(1200, 700);
            MinimumSize = new Size(1200, 700);
            Name = "frmUsersAE";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmUsersAE";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private TextBox txtUserName;
        private Label label6;
        private ComboBox cboRol;
        private Label label8;
        private TextBox txtPassword;
        private Label label3;
        private CheckBox checkBoxActive;
        private Label label2;
        private TextBox txtConfirmPassword;
        private SplitContainer splitContainer1;
        private Button btnOk;
        private Button btnCancel;
        private ErrorProvider errorProvider1;
    }
}