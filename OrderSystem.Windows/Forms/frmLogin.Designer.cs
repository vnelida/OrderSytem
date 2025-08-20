namespace Windows.Forms
{
    partial class frmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            txtPassword = new TextBox();
            label1 = new Label();
            btnExit = new Button();
            btnLoginn = new Button();
            txtUser = new TextBox();
            label2 = new Label();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // txtPassword
            // 
            txtPassword.ForeColor = SystemColors.WindowText;
            txtPassword.Location = new Point(795, 450);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(357, 39);
            txtPassword.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Location = new Point(664, 453);
            label1.Name = "label1";
            label1.Size = new Size(111, 32);
            label1.TabIndex = 8;
            label1.Text = "Password";
            // 
            // btnExit
            // 
            btnExit.BackColor = Color.IndianRed;
            btnExit.ForeColor = SystemColors.ButtonHighlight;
            btnExit.Location = new Point(955, 558);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(213, 80);
            btnExit.TabIndex = 7;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = false;
            btnExit.Click += btnExit_Click;
            // 
            // btnLoginn
            // 
            btnLoginn.BackColor = Color.DarkSeaGreen;
            btnLoginn.ForeColor = SystemColors.ButtonHighlight;
            btnLoginn.Location = new Point(717, 558);
            btnLoginn.Name = "btnLoginn";
            btnLoginn.Size = new Size(213, 80);
            btnLoginn.TabIndex = 6;
            btnLoginn.Text = "Login";
            btnLoginn.UseVisualStyleBackColor = false;
            btnLoginn.Click += btnLoginn_Click;
            // 
            // txtUser
            // 
            txtUser.ForeColor = SystemColors.WindowText;
            txtUser.Location = new Point(795, 384);
            txtUser.Name = "txtUser";
            txtUser.Size = new Size(357, 39);
            txtUser.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Location = new Point(664, 387);
            label2.Name = "label2";
            label2.Size = new Size(61, 32);
            label2.TabIndex = 10;
            label2.Text = "User";
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = SystemColors.ControlLightLight;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(877, 233);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(100, 100);
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox1.TabIndex = 11;
            pictureBox1.TabStop = false;
            // 
            // frmLogin
            // 
            AcceptButton = btnLoginn;
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1870, 1037);
            Controls.Add(pictureBox1);
            Controls.Add(txtUser);
            Controls.Add(label2);
            Controls.Add(txtPassword);
            Controls.Add(label1);
            Controls.Add(btnExit);
            Controls.Add(btnLoginn);
            MaximizeBox = false;
            MaximumSize = new Size(1896, 1108);
            MinimumSize = new Size(1896, 1108);
            Name = "frmLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmLogin";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtPassword;
        private Label label1;
        private Button btnExit;
        private Button btnLoginn;
        private TextBox txtUser;
        private Label label2;
        private PictureBox pictureBox1;
    }
}