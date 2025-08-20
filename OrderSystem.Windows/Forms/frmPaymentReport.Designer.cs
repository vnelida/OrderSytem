namespace Windows.Forms
{
    partial class frmPaymentReport
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
            dgv = new DataGridView();
            colSaleNro = new DataGridViewTextBoxColumn();
            colDate = new DataGridViewTextBoxColumn();
            colCash = new DataGridViewTextBoxColumn();
            colCard = new DataGridViewTextBoxColumn();
            colCoupon = new DataGridViewTextBoxColumn();
            colTransfer = new DataGridViewTextBoxColumn();
            splitContainer1 = new SplitContainer();
            txtCash = new TextBox();
            txtCoupon = new TextBox();
            txtCard = new TextBox();
            txtTransfer = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgv).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // dgv
            // 
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.BackgroundColor = SystemColors.ButtonHighlight;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv.Columns.AddRange(new DataGridViewColumn[] { colSaleNro, colDate, colCash, colCard, colCoupon, colTransfer });
            dgv.Dock = DockStyle.Fill;
            dgv.Location = new Point(0, 0);
            dgv.MultiSelect = false;
            dgv.Name = "dgv";
            dgv.ReadOnly = true;
            dgv.RowHeadersVisible = false;
            dgv.RowHeadersWidth = 82;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.Size = new Size(1443, 940);
            dgv.TabIndex = 1;
            // 
            // colSaleNro
            // 
            colSaleNro.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colSaleNro.HeaderText = "Sale Nro";
            colSaleNro.MinimumWidth = 10;
            colSaleNro.Name = "colSaleNro";
            colSaleNro.ReadOnly = true;
            // 
            // colDate
            // 
            colDate.HeaderText = "Date";
            colDate.MinimumWidth = 10;
            colDate.Name = "colDate";
            colDate.ReadOnly = true;
            colDate.Width = 200;
            // 
            // colCash
            // 
            colCash.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colCash.HeaderText = "Cash";
            colCash.MinimumWidth = 10;
            colCash.Name = "colCash";
            colCash.ReadOnly = true;
            // 
            // colCard
            // 
            colCard.HeaderText = "Card";
            colCard.MinimumWidth = 10;
            colCard.Name = "colCard";
            colCard.ReadOnly = true;
            colCard.Width = 200;
            // 
            // colCoupon
            // 
            colCoupon.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colCoupon.HeaderText = "Coupon";
            colCoupon.MinimumWidth = 10;
            colCoupon.Name = "colCoupon";
            colCoupon.ReadOnly = true;
            // 
            // colTransfer
            // 
            colTransfer.HeaderText = "Transfer";
            colTransfer.MinimumWidth = 10;
            colTransfer.Name = "colTransfer";
            colTransfer.ReadOnly = true;
            colTransfer.Width = 200;
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
            splitContainer1.Panel1.Controls.Add(dgv);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.BackgroundImage = Properties.Resources.Captura_de_pantalla_2025_08_02_005150;
            splitContainer1.Panel2.Controls.Add(txtCash);
            splitContainer1.Panel2.Controls.Add(txtCoupon);
            splitContainer1.Panel2.Controls.Add(txtCard);
            splitContainer1.Panel2.Controls.Add(txtTransfer);
            splitContainer1.Size = new Size(1443, 1070);
            splitContainer1.SplitterDistance = 940;
            splitContainer1.TabIndex = 2;
            // 
            // txtCash
            // 
            txtCash.BackColor = SystemColors.ButtonHighlight;
            txtCash.Location = new Point(528, 40);
            txtCash.Name = "txtCash";
            txtCash.ReadOnly = true;
            txtCash.Size = new Size(189, 39);
            txtCash.TabIndex = 3;
            // 
            // txtCoupon
            // 
            txtCoupon.BackColor = SystemColors.ButtonHighlight;
            txtCoupon.Location = new Point(1010, 40);
            txtCoupon.Name = "txtCoupon";
            txtCoupon.ReadOnly = true;
            txtCoupon.Size = new Size(189, 39);
            txtCoupon.TabIndex = 2;
            // 
            // txtCard
            // 
            txtCard.BackColor = SystemColors.ButtonHighlight;
            txtCard.Location = new Point(775, 40);
            txtCard.Name = "txtCard";
            txtCard.ReadOnly = true;
            txtCard.Size = new Size(189, 39);
            txtCard.TabIndex = 1;
            // 
            // txtTransfer
            // 
            txtTransfer.BackColor = SystemColors.ButtonHighlight;
            txtTransfer.Location = new Point(1242, 40);
            txtTransfer.Name = "txtTransfer";
            txtTransfer.ReadOnly = true;
            txtTransfer.Size = new Size(189, 39);
            txtTransfer.TabIndex = 0;
            // 
            // frmPaymentReport
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1443, 1070);
            Controls.Add(splitContainer1);
            Name = "frmPaymentReport";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmPaymentReport";
            Load += frmPaymentReport_Load;
            ((System.ComponentModel.ISupportInitialize)dgv).EndInit();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgv;
        private DataGridViewTextBoxColumn colId;
        private SplitContainer splitContainer1;
        private TextBox txtCash;
        private TextBox txtCoupon;
        private TextBox txtCard;
        private TextBox txtTransfer;
        private DataGridViewTextBoxColumn colSaleNro;
        private DataGridViewTextBoxColumn colDate;
        private DataGridViewTextBoxColumn colCash;
        private DataGridViewTextBoxColumn colCard;
        private DataGridViewTextBoxColumn colCoupon;
        private DataGridViewTextBoxColumn colTransfer;
    }
}