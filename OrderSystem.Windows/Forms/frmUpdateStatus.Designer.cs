namespace Windows
{
    partial class frmUpdateStatus
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUpdateStatus));
            btnNo = new Button();
            btnYes = new Button();
            splitContainer1 = new SplitContainer();
            lblMssg = new Label();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // btnNo
            // 
            btnNo.BackColor = Color.IndianRed;
            btnNo.ForeColor = SystemColors.ButtonFace;
            btnNo.Location = new Point(434, 18);
            btnNo.Name = "btnNo";
            btnNo.Size = new Size(121, 61);
            btnNo.TabIndex = 4;
            btnNo.Text = "No";
            btnNo.UseVisualStyleBackColor = false;
            btnNo.Click += btnNo_Click;
            // 
            // btnYes
            // 
            btnYes.BackgroundImage = (Image)resources.GetObject("btnYes.BackgroundImage");
            btnYes.Location = new Point(268, 18);
            btnYes.Name = "btnYes";
            btnYes.Size = new Size(121, 61);
            btnYes.TabIndex = 3;
            btnYes.Text = "Yes";
            btnYes.UseVisualStyleBackColor = false;
            btnYes.Click += btnYes_Click;
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
            splitContainer1.Panel1.Controls.Add(lblMssg);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.BackgroundImage = (Image)resources.GetObject("splitContainer1.Panel2.BackgroundImage");
            splitContainer1.Panel2.Controls.Add(btnNo);
            splitContainer1.Panel2.Controls.Add(btnYes);
            splitContainer1.Size = new Size(832, 348);
            splitContainer1.SplitterDistance = 253;
            splitContainer1.TabIndex = 5;
            // 
            // lblMssg
            // 
            lblMssg.AutoSize = true;
            lblMssg.BackColor = SystemColors.ButtonHighlight;
            lblMssg.Location = new Point(331, 118);
            lblMssg.Name = "lblMssg";
            lblMssg.Size = new Size(143, 32);
            lblMssg.TabIndex = 0;
            lblMssg.Text = "Mensajeeee";
            // 
            // frmUpdateStatus
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(832, 348);
            Controls.Add(splitContainer1);
            MaximumSize = new Size(858, 419);
            MinimumSize = new Size(858, 419);
            Name = "frmUpdateStatus";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmUpdateStatus";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button btnNo;
        private Button btnYes;
        private SplitContainer splitContainer1;
        private Label lblMssg;
    }
}