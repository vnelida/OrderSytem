namespace Windows.Forms
{
    partial class frmCustomersDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCustomersDetails));
            splitContainer1 = new SplitContainer();
            btnClose = new Button();
            splitContainer2 = new SplitContainer();
            panel2 = new Panel();
            dgvPhones = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            colPhoneType = new DataGridViewTextBoxColumn();
            panel1 = new Panel();
            label3 = new Label();
            label6 = new Label();
            txtFirstName = new TextBox();
            label4 = new Label();
            txtLastName = new TextBox();
            txtDocumentNum = new TextBox();
            dgv = new DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colType = new DataGridViewTextBoxColumn();
            colStreet = new DataGridViewTextBoxColumn();
            colBuildingNum = new DataGridViewTextBoxColumn();
            colBS1 = new DataGridViewTextBoxColumn();
            colBT2 = new DataGridViewTextBoxColumn();
            colPostalCode = new DataGridViewTextBoxColumn();
            colCity = new DataGridViewTextBoxColumn();
            colState = new DataGridViewTextBoxColumn();
            colCountry = new DataGridViewTextBoxColumn();
            panel3 = new Panel();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPhones).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv).BeginInit();
            SuspendLayout();
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
            splitContainer1.Panel1.BackColor = SystemColors.ButtonHighlight;
            splitContainer1.Panel1.BackgroundImage = Properties.Resources.Green_Retro_Illustrative_Fast_Food_Logo__2_;
            splitContainer1.Panel1.Controls.Add(btnClose);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(splitContainer2);
            splitContainer1.Size = new Size(1974, 1329);
            splitContainer1.SplitterDistance = 131;
            splitContainer1.TabIndex = 0;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Top;
            btnClose.AutoSize = true;
            btnClose.BackgroundImage = (Image)resources.GetObject("btnClose.BackgroundImage");
            btnClose.Image = (Image)resources.GetObject("btnClose.Image");
            btnClose.Location = new Point(1833, 12);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(116, 106);
            btnClose.TabIndex = 8;
            btnClose.Text = "Close";
            btnClose.TextImageRelation = TextImageRelation.ImageAboveText;
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click_1;
            // 
            // splitContainer2
            // 
            splitContainer2.Dock = DockStyle.Fill;
            splitContainer2.Location = new Point(0, 0);
            splitContainer2.Name = "splitContainer2";
            splitContainer2.Orientation = Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.BackgroundImage = Properties.Resources.Green_Retro_Illustrative_Fast_Food_Logo__2_;
            splitContainer2.Panel1.Controls.Add(panel2);
            splitContainer2.Panel1.Controls.Add(panel1);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.BackgroundImage = Properties.Resources.Green_Retro_Illustrative_Fast_Food_Logo__2_;
            splitContainer2.Panel2.Controls.Add(dgv);
            splitContainer2.Panel2.Controls.Add(panel3);
            splitContainer2.Size = new Size(1974, 1194);
            splitContainer2.SplitterDistance = 596;
            splitContainer2.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Controls.Add(dgvPhones);
            panel2.Location = new Point(859, 48);
            panel2.Name = "panel2";
            panel2.Size = new Size(1090, 507);
            panel2.TabIndex = 55;
            // 
            // dgvPhones
            // 
            dgvPhones.AllowUserToAddRows = false;
            dgvPhones.AllowUserToDeleteRows = false;
            dgvPhones.BackgroundColor = Color.White;
            dgvPhones.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPhones.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, colPhoneType });
            dgvPhones.Location = new Point(54, 46);
            dgvPhones.MultiSelect = false;
            dgvPhones.Name = "dgvPhones";
            dgvPhones.ReadOnly = true;
            dgvPhones.RowHeadersVisible = false;
            dgvPhones.RowHeadersWidth = 82;
            dgvPhones.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPhones.Size = new Size(988, 401);
            dgvPhones.TabIndex = 5;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.HeaderText = "Id";
            dataGridViewTextBoxColumn1.MinimumWidth = 10;
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.ReadOnly = true;
            dataGridViewTextBoxColumn1.Visible = false;
            dataGridViewTextBoxColumn1.Width = 200;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn2.HeaderText = "Phones";
            dataGridViewTextBoxColumn2.MinimumWidth = 10;
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // colPhoneType
            // 
            colPhoneType.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colPhoneType.HeaderText = "Phone Type";
            colPhoneType.MinimumWidth = 10;
            colPhoneType.Name = "colPhoneType";
            colPhoneType.ReadOnly = true;
            // 
            // panel1
            // 
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(txtFirstName);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(txtLastName);
            panel1.Controls.Add(txtDocumentNum);
            panel1.Location = new Point(41, 48);
            panel1.Name = "panel1";
            panel1.Size = new Size(783, 507);
            panel1.TabIndex = 54;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(18, 308);
            label3.Margin = new Padding(6, 0, 6, 0);
            label3.Name = "label3";
            label3.Size = new Size(226, 32);
            label3.TabIndex = 53;
            label3.Text = "Document Number:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(110, 191);
            label6.Margin = new Padding(6, 0, 6, 0);
            label6.Name = "label6";
            label6.Size = new Size(134, 32);
            label6.TabIndex = 51;
            label6.Text = "First Name:";
            // 
            // txtFirstName
            // 
            txtFirstName.Location = new Point(286, 188);
            txtFirstName.Margin = new Padding(6);
            txtFirstName.MaxLength = 50;
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(351, 39);
            txtFirstName.TabIndex = 50;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(113, 81);
            label4.Margin = new Padding(6, 0, 6, 0);
            label4.Name = "label4";
            label4.Size = new Size(131, 32);
            label4.TabIndex = 52;
            label4.Text = "Last Name:";
            // 
            // txtLastName
            // 
            txtLastName.Location = new Point(286, 78);
            txtLastName.Margin = new Padding(6);
            txtLastName.MaxLength = 50;
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(351, 39);
            txtLastName.TabIndex = 49;
            // 
            // txtDocumentNum
            // 
            txtDocumentNum.Location = new Point(286, 305);
            txtDocumentNum.Margin = new Padding(6);
            txtDocumentNum.MaxLength = 8;
            txtDocumentNum.Name = "txtDocumentNum";
            txtDocumentNum.Size = new Size(351, 39);
            txtDocumentNum.TabIndex = 48;
            // 
            // dgv
            // 
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.BackgroundColor = Color.White;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv.Columns.AddRange(new DataGridViewColumn[] { colId, colType, colStreet, colBuildingNum, colBS1, colBT2, colPostalCode, colCity, colState, colCountry });
            dgv.Location = new Point(81, 71);
            dgv.MultiSelect = false;
            dgv.Name = "dgv";
            dgv.ReadOnly = true;
            dgv.RowHeadersVisible = false;
            dgv.RowHeadersWidth = 82;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.Size = new Size(1820, 443);
            dgv.TabIndex = 4;
            // 
            // colId
            // 
            colId.HeaderText = "Id";
            colId.MinimumWidth = 10;
            colId.Name = "colId";
            colId.ReadOnly = true;
            colId.Visible = false;
            colId.Width = 200;
            // 
            // colType
            // 
            colType.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colType.HeaderText = "Type";
            colType.MinimumWidth = 10;
            colType.Name = "colType";
            colType.ReadOnly = true;
            // 
            // colStreet
            // 
            colStreet.HeaderText = "Street";
            colStreet.MinimumWidth = 10;
            colStreet.Name = "colStreet";
            colStreet.ReadOnly = true;
            colStreet.Width = 200;
            // 
            // colBuildingNum
            // 
            colBuildingNum.HeaderText = "Building Number";
            colBuildingNum.MinimumWidth = 10;
            colBuildingNum.Name = "colBuildingNum";
            colBuildingNum.ReadOnly = true;
            colBuildingNum.Width = 200;
            // 
            // colBS1
            // 
            colBS1.HeaderText = "";
            colBS1.MinimumWidth = 10;
            colBS1.Name = "colBS1";
            colBS1.ReadOnly = true;
            colBS1.Width = 200;
            // 
            // colBT2
            // 
            colBT2.HeaderText = "";
            colBT2.MinimumWidth = 10;
            colBT2.Name = "colBT2";
            colBT2.ReadOnly = true;
            colBT2.Width = 200;
            // 
            // colPostalCode
            // 
            colPostalCode.HeaderText = "Postal Code";
            colPostalCode.MinimumWidth = 10;
            colPostalCode.Name = "colPostalCode";
            colPostalCode.ReadOnly = true;
            colPostalCode.Width = 200;
            // 
            // colCity
            // 
            colCity.HeaderText = "City";
            colCity.MinimumWidth = 10;
            colCity.Name = "colCity";
            colCity.ReadOnly = true;
            colCity.Width = 200;
            // 
            // colState
            // 
            colState.HeaderText = "State";
            colState.MinimumWidth = 10;
            colState.Name = "colState";
            colState.ReadOnly = true;
            colState.Width = 200;
            // 
            // colCountry
            // 
            colCountry.HeaderText = "Country";
            colCountry.MinimumWidth = 10;
            colCountry.Name = "colCountry";
            colCountry.ReadOnly = true;
            colCountry.Width = 200;
            // 
            // panel3
            // 
            panel3.Location = new Point(41, 37);
            panel3.Name = "panel3";
            panel3.Size = new Size(1908, 526);
            panel3.TabIndex = 5;
            // 
            // frmCustomersDetails
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            BackgroundImage = Properties.Resources.Green_Retro_Illustrative_Fast_Food_Logo__2_;
            ClientSize = new Size(1974, 1329);
            ControlBox = false;
            Controls.Add(splitContainer1);
            MaximumSize = new Size(2000, 1400);
            MinimizeBox = false;
            MinimumSize = new Size(2000, 1400);
            Name = "frmCustomersDetails";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmCustomersDetails";
            Load += frmCustomersDetails_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvPhones).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgv).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private SplitContainer splitContainer2;
        private Label label3;
        private Label label6;
        private Label label4;
        private TextBox txtDocumentNum;
        private TextBox txtLastName;
        private TextBox txtFirstName;
        private DataGridView dgv;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colType;
        private DataGridViewTextBoxColumn colStreet;
        private DataGridViewTextBoxColumn colBuildingNum;
        private DataGridViewTextBoxColumn colBS1;
        private DataGridViewTextBoxColumn colBT2;
        private DataGridViewTextBoxColumn colPostalCode;
        private DataGridViewTextBoxColumn colCity;
        private DataGridViewTextBoxColumn colState;
        private DataGridViewTextBoxColumn colCountry;
        private Button btnClose;
        private Panel panel1;
        private Panel panel2;
        private DataGridView dgvPhones;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn colPhoneType;
        private Panel panel3;
        private MaskedTextBox maskedTextBox1;
    }
}