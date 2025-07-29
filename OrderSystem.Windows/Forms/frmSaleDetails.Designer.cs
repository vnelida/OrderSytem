namespace Windows.Forms
{
    partial class frmSaleDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSaleDetails));
            splitContainer1 = new SplitContainer();
            toolStrip1 = new ToolStrip();
            btnClose = new ToolStripButton();
            txtType = new TextBox();
            label6 = new Label();
            txtStatus = new TextBox();
            label4 = new Label();
            txtDate = new TextBox();
            label2 = new Label();
            txtCustomer = new TextBox();
            label3 = new Label();
            txtSaleNum = new TextBox();
            label1 = new Label();
            txtTotalAmount = new TextBox();
            label5 = new Label();
            dgv = new DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colCustomer = new DataGridViewTextBoxColumn();
            col = new DataGridViewTextBoxColumn();
            colUnitPrice = new DataGridViewTextBoxColumn();
            colTotal = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            toolStrip1.SuspendLayout();
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
            splitContainer1.Panel1.Controls.Add(toolStrip1);
            splitContainer1.Panel1.Controls.Add(txtType);
            splitContainer1.Panel1.Controls.Add(label6);
            splitContainer1.Panel1.Controls.Add(txtStatus);
            splitContainer1.Panel1.Controls.Add(label4);
            splitContainer1.Panel1.Controls.Add(txtDate);
            splitContainer1.Panel1.Controls.Add(label2);
            splitContainer1.Panel1.Controls.Add(txtCustomer);
            splitContainer1.Panel1.Controls.Add(label3);
            splitContainer1.Panel1.Controls.Add(txtSaleNum);
            splitContainer1.Panel1.Controls.Add(label1);
            splitContainer1.Panel1.Paint += splitContainer1_Panel1_Paint;
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(txtTotalAmount);
            splitContainer1.Panel2.Controls.Add(label5);
            splitContainer1.Panel2.Controls.Add(dgv);
            splitContainer1.Size = new Size(1421, 901);
            splitContainer1.SplitterDistance = 403;
            splitContainer1.TabIndex = 0;
            // 
            // toolStrip1
            // 
            toolStrip1.BackColor = Color.White;
            toolStrip1.ImageScalingSize = new Size(32, 32);
            toolStrip1.Items.AddRange(new ToolStripItem[] { btnClose });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1421, 106);
            toolStrip1.TabIndex = 3;
            toolStrip1.Text = "toolStrip1";
            // 
            // btnClose
            // 
            btnClose.Alignment = ToolStripItemAlignment.Right;
            btnClose.Image = (Image)resources.GetObject("btnClose.Image");
            btnClose.ImageScaling = ToolStripItemImageScaling.None;
            btnClose.ImageTransparentColor = Color.Magenta;
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(76, 100);
            btnClose.Text = "Close";
            btnClose.TextImageRelation = TextImageRelation.ImageAboveText;
            btnClose.Click += btnClose_Click;
            // 
            // txtType
            // 
            txtType.Enabled = false;
            txtType.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            txtType.Location = new Point(1161, 315);
            txtType.Margin = new Padding(6);
            txtType.Name = "txtType";
            txtType.ReadOnly = true;
            txtType.Size = new Size(182, 39);
            txtType.TabIndex = 10;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(1030, 321);
            label6.Margin = new Padding(6, 0, 6, 0);
            label6.Name = "label6";
            label6.Size = new Size(70, 32);
            label6.TabIndex = 19;
            label6.Text = "Type:";
            // 
            // txtStatus
            // 
            txtStatus.Enabled = false;
            txtStatus.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            txtStatus.Location = new Point(1161, 243);
            txtStatus.Margin = new Padding(6);
            txtStatus.Name = "txtStatus";
            txtStatus.ReadOnly = true;
            txtStatus.Size = new Size(182, 39);
            txtStatus.TabIndex = 0;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(1030, 249);
            label4.Margin = new Padding(6, 0, 6, 0);
            label4.Name = "label4";
            label4.Size = new Size(83, 32);
            label4.TabIndex = 11;
            label4.Text = "Status:";
            // 
            // txtDate
            // 
            txtDate.Enabled = false;
            txtDate.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            txtDate.Location = new Point(1161, 181);
            txtDate.Margin = new Padding(6);
            txtDate.Name = "txtDate";
            txtDate.ReadOnly = true;
            txtDate.Size = new Size(182, 39);
            txtDate.TabIndex = 16;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(1030, 188);
            label2.Margin = new Padding(6, 0, 6, 0);
            label2.Name = "label2";
            label2.Size = new Size(69, 32);
            label2.TabIndex = 12;
            label2.Text = "Date:";
            // 
            // txtCustomer
            // 
            txtCustomer.Enabled = false;
            txtCustomer.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            txtCustomer.Location = new Point(149, 237);
            txtCustomer.Margin = new Padding(6);
            txtCustomer.Name = "txtCustomer";
            txtCustomer.ReadOnly = true;
            txtCustomer.Size = new Size(694, 39);
            txtCustomer.TabIndex = 17;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(18, 243);
            label3.Margin = new Padding(6, 0, 6, 0);
            label3.Name = "label3";
            label3.Size = new Size(122, 32);
            label3.TabIndex = 13;
            label3.Text = "Customer:";
            // 
            // txtSaleNum
            // 
            txtSaleNum.Enabled = false;
            txtSaleNum.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            txtSaleNum.Location = new Point(149, 175);
            txtSaleNum.Margin = new Padding(6);
            txtSaleNum.Name = "txtSaleNum";
            txtSaleNum.ReadOnly = true;
            txtSaleNum.Size = new Size(182, 39);
            txtSaleNum.TabIndex = 18;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(18, 181);
            label1.Margin = new Padding(6, 0, 6, 0);
            label1.Name = "label1";
            label1.Size = new Size(123, 32);
            label1.TabIndex = 1;
            label1.Text = "Sale Num:";
            // 
            // txtTotalAmount
            // 
            txtTotalAmount.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            txtTotalAmount.Location = new Point(1227, 406);
            txtTotalAmount.Margin = new Padding(6);
            txtTotalAmount.Name = "txtTotalAmount";
            txtTotalAmount.ReadOnly = true;
            txtTotalAmount.Size = new Size(182, 39);
            txtTotalAmount.TabIndex = 17;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(1096, 412);
            label5.Margin = new Padding(6, 0, 6, 0);
            label5.Name = "label5";
            label5.Size = new Size(70, 32);
            label5.TabIndex = 16;
            label5.Text = "Total:";
            // 
            // dgv
            // 
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.BackgroundColor = Color.White;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv.Columns.AddRange(new DataGridViewColumn[] { colId, colCustomer, col, colUnitPrice, colTotal });
            dgv.Location = new Point(0, 3);
            dgv.MultiSelect = false;
            dgv.Name = "dgv";
            dgv.ReadOnly = true;
            dgv.RowHeadersVisible = false;
            dgv.RowHeadersWidth = 82;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.Size = new Size(1421, 394);
            dgv.TabIndex = 1;
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
            // colCustomer
            // 
            colCustomer.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colCustomer.HeaderText = "Product";
            colCustomer.MinimumWidth = 10;
            colCustomer.Name = "colCustomer";
            colCustomer.ReadOnly = true;
            // 
            // col
            // 
            col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            col.HeaderText = "Quantity";
            col.MinimumWidth = 10;
            col.Name = "col";
            col.ReadOnly = true;
            col.Width = 151;
            // 
            // colUnitPrice
            // 
            colUnitPrice.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            colUnitPrice.HeaderText = "Unit Price";
            colUnitPrice.MinimumWidth = 10;
            colUnitPrice.Name = "colUnitPrice";
            colUnitPrice.ReadOnly = true;
            colUnitPrice.Width = 161;
            // 
            // colTotal
            // 
            colTotal.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            colTotal.HeaderText = "Total";
            colTotal.MinimumWidth = 10;
            colTotal.Name = "colTotal";
            colTotal.ReadOnly = true;
            colTotal.Width = 110;
            // 
            // frmSaleDetails
            // 
            ClientSize = new Size(1421, 901);
            ControlBox = false;
            Controls.Add(splitContainer1);
            Name = "frmSaleDetails";
            StartPosition = FormStartPosition.CenterScreen;
            Load += frmSaleDetails_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgv).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private CheckBox chkRegalo;
        private TextBox txtStatus;
        private Label label4;
        private TextBox txtDate;
        private Label label2;
        private TextBox txtCustomer;
        private Label label3;
        private TextBox txtSaleNum;
        private Label label1;
        private TextBox txtTotalAmount;
        private Label label5;
        private DataGridView dgv;
        private DataGridViewTextBoxColumn colProductName;
        private DataGridViewTextBoxColumn colQuantity;
        private DataGridViewTextBoxColumn colCategory;
        private SplitContainer splitContainer1;
        private TextBox txtType;
        private Label label6;
        private ToolStrip toolStrip1;
        private ToolStripButton btnClose;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colCustomer;
        private DataGridViewTextBoxColumn col;
        private DataGridViewTextBoxColumn colUnitPrice;
        private DataGridViewTextBoxColumn colTotal;
    }
}