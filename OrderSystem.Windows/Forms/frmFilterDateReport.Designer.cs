namespace Windows.Forms
{
    partial class frmFilterDateReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFilterDateReport));
            label9 = new Label();
            dtpEndDate = new DateTimePicker();
            label8 = new Label();
            dtpStartDate = new DateTimePicker();
            splitContainer1 = new SplitContainer();
            btnCancel = new Button();
            btnOk = new Button();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.Transparent;
            label9.Location = new Point(443, 115);
            label9.Name = "label9";
            label9.Size = new Size(116, 32);
            label9.TabIndex = 65;
            label9.Text = "End Date:";
            // 
            // dtpEndDate
            // 
            dtpEndDate.Format = DateTimePickerFormat.Short;
            dtpEndDate.Location = new Point(565, 108);
            dtpEndDate.Name = "dtpEndDate";
            dtpEndDate.Size = new Size(240, 39);
            dtpEndDate.TabIndex = 63;
            dtpEndDate.Value = new DateTime(2025, 8, 20, 14, 24, 42, 0);
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Location = new Point(27, 115);
            label8.Name = "label8";
            label8.Size = new Size(131, 32);
            label8.TabIndex = 64;
            label8.Text = "Start Date: ";
            // 
            // dtpStartDate
            // 
            dtpStartDate.Format = DateTimePickerFormat.Short;
            dtpStartDate.Location = new Point(164, 108);
            dtpStartDate.MinDate = new DateTime(2024, 1, 1, 0, 0, 0, 0);
            dtpStartDate.Name = "dtpStartDate";
            dtpStartDate.Size = new Size(240, 39);
            dtpStartDate.TabIndex = 62;
            dtpStartDate.Value = new DateTime(2025, 8, 20, 0, 0, 0, 0);
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
            splitContainer1.Panel1.Controls.Add(dtpEndDate);
            splitContainer1.Panel1.Controls.Add(label9);
            splitContainer1.Panel1.Controls.Add(dtpStartDate);
            splitContainer1.Panel1.Controls.Add(label8);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.BackgroundImage = Properties.Resources.Green_Retro_Illustrative_Fast_Food_Logo__1_;
            splitContainer1.Panel2.Controls.Add(btnCancel);
            splitContainer1.Panel2.Controls.Add(btnOk);
            splitContainer1.Size = new Size(832, 348);
            splitContainer1.SplitterDistance = 246;
            splitContainer1.TabIndex = 66;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.IndianRed;
            btnCancel.ForeColor = SystemColors.ButtonFace;
            btnCancel.Location = new Point(684, 15);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(121, 61);
            btnCancel.TabIndex = 4;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnOk
            // 
            btnOk.BackgroundImage = (Image)resources.GetObject("btnOk.BackgroundImage");
            btnOk.Location = new Point(518, 15);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(121, 61);
            btnOk.TabIndex = 3;
            btnOk.Text = "Ok";
            btnOk.UseVisualStyleBackColor = false;
            btnOk.Click += btnOk_Click;
            // 
            // frmFilterDateReport
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(832, 348);
            Controls.Add(splitContainer1);
            MaximumSize = new Size(858, 419);
            MinimumSize = new Size(858, 419);
            Name = "frmFilterDateReport";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmFilterDateReport";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label label9;
        private DateTimePicker dtpEndDate;
        private Label label8;
        private DateTimePicker dtpStartDate;
        private SplitContainer splitContainer1;
        private Button btnCancel;
        private Button btnOk;
    }
}