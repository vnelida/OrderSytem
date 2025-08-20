namespace Windows.Forms
{
    partial class frmPayment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPayment));
            cboPaymentMethod = new ComboBox();
            label1 = new Label();
            btnCash = new Button();
            btnOtherMethod = new Button();
            txtTotal = new TextBox();
            label2 = new Label();
            splitContainer1 = new SplitContainer();
            txtCash = new NumericUpDown();
            txtOtherPayment = new NumericUpDown();
            btnCancel = new Button();
            btnSave = new Button();
            errorProvider1 = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtCash).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtOtherPayment).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // cboPaymentMethod
            // 
            cboPaymentMethod.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPaymentMethod.FormattingEnabled = true;
            cboPaymentMethod.Location = new Point(493, 272);
            cboPaymentMethod.Name = "cboPaymentMethod";
            cboPaymentMethod.Size = new Size(246, 40);
            cboPaymentMethod.TabIndex = 3;
            cboPaymentMethod.SelectedIndexChanged += cboPaymentMethod_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.ButtonHighlight;
            label1.Font = new Font("Segoe UI", 10.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(493, 170);
            label1.Name = "label1";
            label1.Size = new Size(246, 40);
            label1.TabIndex = 4;
            label1.Text = "Cash                     ";
            // 
            // btnCash
            // 
            btnCash.BackgroundImage = Properties.Resources.Captura_de_pantalla_2025_08_02_005150;
            btnCash.Image = (Image)resources.GetObject("btnCash.Image");
            btnCash.Location = new Point(420, 155);
            btnCash.Name = "btnCash";
            btnCash.Size = new Size(67, 75);
            btnCash.TabIndex = 6;
            btnCash.TextImageRelation = TextImageRelation.ImageAboveText;
            btnCash.UseVisualStyleBackColor = true;
            btnCash.Click += btnCash_Click;
            // 
            // btnOtherMethod
            // 
            btnOtherMethod.BackgroundImage = Properties.Resources.Captura_de_pantalla_2025_08_02_005150;
            btnOtherMethod.Image = (Image)resources.GetObject("btnOtherMethod.Image");
            btnOtherMethod.Location = new Point(420, 254);
            btnOtherMethod.Name = "btnOtherMethod";
            btnOtherMethod.Size = new Size(67, 75);
            btnOtherMethod.TabIndex = 7;
            btnOtherMethod.UseVisualStyleBackColor = true;
            btnOtherMethod.Click += btnOtherMethod_Click;
            // 
            // txtTotal
            // 
            txtTotal.Location = new Point(351, 404);
            txtTotal.Name = "txtTotal";
            txtTotal.ReadOnly = true;
            txtTotal.Size = new Size(247, 39);
            txtTotal.TabIndex = 8;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = SystemColors.ButtonHighlight;
            label2.Location = new Point(268, 407);
            label2.Name = "label2";
            label2.Size = new Size(77, 32);
            label2.TabIndex = 9;
            label2.Text = "Total: ";
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
            splitContainer1.Panel1.Controls.Add(txtCash);
            splitContainer1.Panel1.Controls.Add(txtOtherPayment);
            splitContainer1.Panel1.Controls.Add(txtTotal);
            splitContainer1.Panel1.Controls.Add(btnOtherMethod);
            splitContainer1.Panel1.Controls.Add(label2);
            splitContainer1.Panel1.Controls.Add(btnCash);
            splitContainer1.Panel1.Controls.Add(label1);
            splitContainer1.Panel1.Controls.Add(cboPaymentMethod);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.BackgroundImage = Properties.Resources.Green_Retro_Illustrative_Fast_Food_Logo__1_;
            splitContainer1.Panel2.Controls.Add(btnCancel);
            splitContainer1.Panel2.Controls.Add(btnSave);
            splitContainer1.Size = new Size(874, 679);
            splitContainer1.SplitterDistance = 528;
            splitContainer1.TabIndex = 10;
            // 
            // txtCash
            // 
            txtCash.Location = new Point(122, 171);
            txtCash.Maximum = new decimal(new int[] { 99999, 0, 0, 0 });
            txtCash.Name = "txtCash";
            txtCash.Size = new Size(240, 39);
            txtCash.TabIndex = 11;
            // 
            // txtOtherPayment
            // 
            txtOtherPayment.Location = new Point(122, 273);
            txtOtherPayment.Maximum = new decimal(new int[] { 999999999, 0, 0, 0 });
            txtOtherPayment.Name = "txtOtherPayment";
            txtOtherPayment.Size = new Size(240, 39);
            txtOtherPayment.TabIndex = 10;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.IndianRed;
            btnCancel.ForeColor = SystemColors.ButtonFace;
            btnCancel.Location = new Point(596, 42);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(121, 61);
            btnCancel.TabIndex = 4;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnSave
            // 
            btnSave.BackgroundImage = (Image)resources.GetObject("btnSave.BackgroundImage");
            btnSave.Location = new Point(272, 42);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(304, 61);
            btnSave.TabIndex = 3;
            btnSave.Text = "Guardar comprobante";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // frmPayment
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Captura_de_pantalla_2025_08_02_005150;
            ClientSize = new Size(874, 679);
            Controls.Add(splitContainer1);
            MaximumSize = new Size(900, 750);
            MinimumSize = new Size(900, 750);
            Name = "frmPayment";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmPayment";
            Load += frmPayment_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)txtCash).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtOtherPayment).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private ComboBox cboPaymentMethod;
        private Label label1;
        private Button btnCash;
        private Button btnOtherMethod;
        private TextBox txtTotal;
        private Label label2;
        private SplitContainer splitContainer1;
        private Button btnCancel;
        private Button btnSave;
        private NumericUpDown txtOtherPayment;
        private NumericUpDown txtCash;
        private ErrorProvider errorProvider1;
    }
}