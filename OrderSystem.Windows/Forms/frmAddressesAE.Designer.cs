namespace Windows.Forms
{
    partial class frmAddressesAE
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddressesAE));
            label1 = new Label();
            cboCities = new ComboBox();
            cboStates = new ComboBox();
            label2 = new Label();
            cboCountries = new ComboBox();
            label3 = new Label();
            label6 = new Label();
            txtPostalCode = new TextBox();
            label11 = new Label();
            label10 = new Label();
            txtApart = new TextBox();
            txtFloor = new TextBox();
            label7 = new Label();
            label9 = new Label();
            label8 = new Label();
            label4 = new Label();
            txtBuildingNumber = new TextBox();
            txtBetweenStreet2 = new TextBox();
            txtBetweenStreet1 = new TextBox();
            txtStreet = new TextBox();
            cboAddressTypes = new ComboBox();
            label5 = new Label();
            btnCancel = new Button();
            btnOk = new Button();
            panel1 = new Panel();
            errorProvider1 = new ErrorProvider(components);
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(160, 381);
            label1.Name = "label1";
            label1.Size = new Size(60, 32);
            label1.TabIndex = 0;
            label1.Text = "City:";
            // 
            // cboCities
            // 
            cboCities.FormattingEnabled = true;
            cboCities.Location = new Point(254, 379);
            cboCities.Name = "cboCities";
            cboCities.Size = new Size(372, 40);
            cboCities.TabIndex = 1;
            cboCities.SelectedIndexChanged += cboCities_SelectedIndexChanged;
            // 
            // cboStates
            // 
            cboStates.FormattingEnabled = true;
            cboStates.Location = new Point(254, 270);
            cboStates.Name = "cboStates";
            cboStates.Size = new Size(372, 40);
            cboStates.TabIndex = 3;
            cboStates.SelectedIndexChanged += cboStatesProvinces_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(148, 273);
            label2.Name = "label2";
            label2.Size = new Size(72, 32);
            label2.TabIndex = 2;
            label2.Text = "State:";
            // 
            // cboCountries
            // 
            cboCountries.FormattingEnabled = true;
            cboCountries.Location = new Point(254, 168);
            cboCountries.Name = "cboCountries";
            cboCountries.Size = new Size(372, 40);
            cboCountries.TabIndex = 5;
            cboCountries.SelectedIndexChanged += cboCountries_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(116, 168);
            label3.Name = "label3";
            label3.Size = new Size(104, 32);
            label3.TabIndex = 4;
            label3.Text = "Country:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(756, 381);
            label6.Margin = new Padding(6, 0, 6, 0);
            label6.Name = "label6";
            label6.Size = new Size(144, 32);
            label6.TabIndex = 51;
            label6.Text = "Postal Code:";
            // 
            // txtPostalCode
            // 
            txtPostalCode.Location = new Point(921, 375);
            txtPostalCode.Margin = new Padding(6);
            txtPostalCode.MaxLength = 50;
            txtPostalCode.Name = "txtPostalCode";
            txtPostalCode.Size = new Size(253, 39);
            txtPostalCode.TabIndex = 50;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(599, 791);
            label11.Margin = new Padding(6, 0, 6, 0);
            label11.Name = "label11";
            label11.Size = new Size(144, 32);
            label11.TabIndex = 55;
            label11.Text = "Apartament:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(158, 788);
            label10.Margin = new Padding(6, 0, 6, 0);
            label10.Name = "label10";
            label10.Size = new Size(73, 32);
            label10.TabIndex = 56;
            label10.Text = "Floor:";
            // 
            // txtApart
            // 
            txtApart.Location = new Point(746, 750);
            txtApart.Margin = new Padding(6);
            txtApart.MaxLength = 50;
            txtApart.Name = "txtApart";
            txtApart.Size = new Size(236, 39);
            txtApart.TabIndex = 53;
            // 
            // txtFloor
            // 
            txtFloor.Location = new Point(254, 784);
            txtFloor.Margin = new Padding(6);
            txtFloor.MaxLength = 50;
            txtFloor.Name = "txtFloor";
            txtFloor.Size = new Size(236, 39);
            txtFloor.TabIndex = 54;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(1035, 513);
            label7.Margin = new Padding(6, 0, 6, 0);
            label7.Name = "label7";
            label7.Size = new Size(202, 32);
            label7.TabIndex = 65;
            label7.Text = "Building Number:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(303, 653);
            label9.Margin = new Padding(6, 0, 6, 0);
            label9.Name = "label9";
            label9.Size = new Size(54, 32);
            label9.TabIndex = 66;
            label9.Text = "and";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(40, 587);
            label8.Margin = new Padding(6, 0, 6, 0);
            label8.Name = "label8";
            label8.Size = new Size(180, 32);
            label8.TabIndex = 67;
            label8.Text = "Between Street:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(139, 517);
            label4.Margin = new Padding(6, 0, 6, 0);
            label4.Name = "label4";
            label4.Size = new Size(81, 32);
            label4.TabIndex = 68;
            label4.Text = "Street:";
            // 
            // txtBuildingNumber
            // 
            txtBuildingNumber.Location = new Point(1249, 510);
            txtBuildingNumber.Margin = new Padding(6);
            txtBuildingNumber.MaxLength = 50;
            txtBuildingNumber.Name = "txtBuildingNumber";
            txtBuildingNumber.Size = new Size(189, 39);
            txtBuildingNumber.TabIndex = 59;
            // 
            // txtBetweenStreet2
            // 
            txtBetweenStreet2.Location = new Point(386, 646);
            txtBetweenStreet2.Margin = new Padding(6);
            txtBetweenStreet2.MaxLength = 50;
            txtBetweenStreet2.Name = "txtBetweenStreet2";
            txtBetweenStreet2.Size = new Size(630, 39);
            txtBetweenStreet2.TabIndex = 60;
            // 
            // txtBetweenStreet1
            // 
            txtBetweenStreet1.Location = new Point(254, 580);
            txtBetweenStreet1.Margin = new Padding(6);
            txtBetweenStreet1.MaxLength = 50;
            txtBetweenStreet1.Name = "txtBetweenStreet1";
            txtBetweenStreet1.Size = new Size(762, 39);
            txtBetweenStreet1.TabIndex = 61;
            // 
            // txtStreet
            // 
            txtStreet.Location = new Point(254, 510);
            txtStreet.Margin = new Padding(6);
            txtStreet.MaxLength = 50;
            txtStreet.Name = "txtStreet";
            txtStreet.Size = new Size(762, 39);
            txtStreet.TabIndex = 62;
            // 
            // cboAddressTypes
            // 
            cboAddressTypes.DropDownStyle = ComboBoxStyle.DropDownList;
            cboAddressTypes.FormattingEnabled = true;
            cboAddressTypes.Location = new Point(254, 70);
            cboAddressTypes.Margin = new Padding(6);
            cboAddressTypes.Name = "cboAddressTypes";
            cboAddressTypes.Size = new Size(496, 40);
            cboAddressTypes.TabIndex = 63;
            cboAddressTypes.SelectedIndexChanged += cboAddressTypes_SelectedIndexChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(59, 76);
            label5.Margin = new Padding(6, 0, 6, 0);
            label5.Name = "label5";
            label5.Size = new Size(161, 32);
            label5.TabIndex = 64;
            label5.Text = "Address Type:";
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.IndianRed;
            btnCancel.ForeColor = SystemColors.ButtonFace;
            btnCancel.Location = new Point(1366, 902);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(163, 93);
            btnCancel.TabIndex = 70;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancelar_Click;
            // 
            // btnOk
            // 
            btnOk.BackgroundImage = (Image)resources.GetObject("btnOk.BackgroundImage");
            btnOk.Location = new Point(1140, 902);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(163, 93);
            btnOk.TabIndex = 69;
            btnOk.Text = "Save";
            btnOk.UseVisualStyleBackColor = false;
            btnOk.Click += btnOk_Click;
            // 
            // panel1
            // 
            panel1.BackgroundImage = Properties.Resources.Captura_de_pantalla_2025_08_02_005150;
            panel1.Controls.Add(txtApart);
            panel1.Location = new Point(25, 35);
            panel1.Name = "panel1";
            panel1.Size = new Size(1521, 826);
            panel1.TabIndex = 71;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // frmAddressesAE
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(1580, 1031);
            Controls.Add(btnCancel);
            Controls.Add(btnOk);
            Controls.Add(label7);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label4);
            Controls.Add(txtBuildingNumber);
            Controls.Add(txtBetweenStreet2);
            Controls.Add(txtBetweenStreet1);
            Controls.Add(txtStreet);
            Controls.Add(cboAddressTypes);
            Controls.Add(label5);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(txtFloor);
            Controls.Add(label6);
            Controls.Add(txtPostalCode);
            Controls.Add(cboCountries);
            Controls.Add(label3);
            Controls.Add(cboStates);
            Controls.Add(label2);
            Controls.Add(cboCities);
            Controls.Add(label1);
            Controls.Add(panel1);
            MaximumSize = new Size(1606, 1102);
            MinimumSize = new Size(1606, 1102);
            Name = "frmAddressesAE";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AddressesAE";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox cboCities;
        private ComboBox cboStates;
        private Label label2;
        private ComboBox cboCountries;
        private Label label3;
        private Label label6;
        private TextBox txtPostalCode;
        private Label label11;
        private Label label10;
        private TextBox txtApart;
        private TextBox txtFloor;
        private Label label7;
        private Label label9;
        private Label label8;
        private Label label4;
        private TextBox txtBuildingNumber;
        private TextBox txtBetweenStreet2;
        private TextBox txtBetweenStreet1;
        private TextBox txtStreet;
        private ComboBox cboAddressTypes;
        private Label label5;
        private Button btnCancel;
        private Button btnOk;
        private Panel panel1;
        private ErrorProvider errorProvider1;
    }
}