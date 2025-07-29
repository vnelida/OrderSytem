namespace Windows.Forms
{
    partial class frmSelectCustomer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSelectCustomer));
            label1 = new Label();
            cboCustomers = new ComboBox();
            splitContainer1 = new SplitContainer();
            button2 = new Button();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Image = Properties.Resources.Green_Retro_Illustrative_Fast_Food_Logo__2_;
            label1.Location = new Point(128, 109);
            label1.Margin = new Padding(6, 0, 6, 0);
            label1.Name = "label1";
            label1.Size = new Size(122, 32);
            label1.TabIndex = 15;
            label1.Text = "Customer:";
            // 
            // cboCustomers
            // 
            cboCustomers.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCustomers.FormattingEnabled = true;
            cboCustomers.Location = new Point(262, 106);
            cboCustomers.Margin = new Padding(6);
            cboCustomers.Name = "cboCustomers";
            cboCustomers.Size = new Size(439, 40);
            cboCustomers.TabIndex = 16;
            cboCustomers.SelectedIndexChanged += cboCustomers_SelectedIndexChanged;
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
            splitContainer1.Panel1.BackgroundImage = Properties.Resources.Green_Retro_Illustrative_Fast_Food_Logo__2_;
            splitContainer1.Panel1.Controls.Add(cboCustomers);
            splitContainer1.Panel1.Controls.Add(label1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.BackColor = Color.DarkSeaGreen;
            splitContainer1.Panel2.BackgroundImage = (Image)resources.GetObject("splitContainer1.Panel2.BackgroundImage");
            splitContainer1.Panel2.Controls.Add(button2);
            splitContainer1.Panel2.Controls.Add(button1);
            splitContainer1.Panel2.ForeColor = Color.FromArgb(0, 192, 0);
            splitContainer1.Size = new Size(832, 348);
            splitContainer1.SplitterDistance = 257;
            splitContainer1.TabIndex = 19;
            // 
            // button2
            // 
            button2.BackgroundImage = (Image)resources.GetObject("button2.BackgroundImage");
            button2.ForeColor = Color.Black;
            button2.Location = new Point(520, 14);
            button2.Name = "button2";
            button2.Size = new Size(121, 61);
            button2.TabIndex = 20;
            button2.Text = "Save";
            button2.UseVisualStyleBackColor = false;
            button2.Click += btnOk_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.IndianRed;
            button1.ForeColor = SystemColors.ButtonFace;
            button1.Location = new Point(679, 14);
            button1.Name = "button1";
            button1.Size = new Size(121, 61);
            button1.TabIndex = 19;
            button1.Text = "Cancel";
            button1.UseVisualStyleBackColor = false;
            button1.Click += btnCancel_Click;
            // 
            // frmSelectCustomer
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(832, 348);
            Controls.Add(splitContainer1);
            MaximumSize = new Size(858, 419);
            MinimumSize = new Size(858, 419);
            Name = "frmSelectCustomer";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SelectCustomer";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private ComboBox cboCustomers;
        private SplitContainer splitContainer1;
        private Button button1;
        private Button button2;
    }
}