namespace Windows.Forms
{
    partial class frmCategories
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCategories));
            toolStrip1 = new ToolStrip();
            dgv = new DataGridView();
            colCategories = new DataGridViewTextBoxColumn();
            btnEdit = new ToolStripButton();
            btnDelete = new ToolStripButton();
            btnNew = new ToolStripButton();
            btnRefresh = new ToolStripButton();
            btnClose = new ToolStripButton();
            toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv).BeginInit();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.BackColor = SystemColors.ButtonHighlight;
            toolStrip1.ImageScalingSize = new Size(32, 32);
            toolStrip1.Items.AddRange(new ToolStripItem[] { btnNew, btnDelete, btnEdit, btnRefresh, btnClose });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1974, 106);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            // 
            // dgv
            // 
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.BackgroundColor = Color.White;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv.Columns.AddRange(new DataGridViewColumn[] { colCategories });
            dgv.Dock = DockStyle.Fill;
            dgv.Location = new Point(0, 106);
            dgv.MultiSelect = false;
            dgv.Name = "dgv";
            dgv.ReadOnly = true;
            dgv.RowHeadersWidth = 82;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.Size = new Size(1974, 1223);
            dgv.TabIndex = 1;
            // 
            // colCategories
            // 
            colCategories.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colCategories.HeaderText = "Categories";
            colCategories.MinimumWidth = 10;
            colCategories.Name = "colCategories";
            colCategories.ReadOnly = true;
            // 
            // btnEdit
            // 
            btnEdit.Image = (Image)resources.GetObject("btnEdit.Image");
            btnEdit.ImageScaling = ToolStripItemImageScaling.None;
            btnEdit.ImageTransparentColor = Color.Magenta;
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(68, 100);
            btnEdit.Text = "Edit";
            btnEdit.TextImageRelation = TextImageRelation.ImageAboveText;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnDelete
            // 
            btnDelete.Image = (Image)resources.GetObject("btnDelete.Image");
            btnDelete.ImageScaling = ToolStripItemImageScaling.None;
            btnDelete.ImageTransparentColor = Color.Magenta;
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(88, 100);
            btnDelete.Text = "Delete";
            btnDelete.TextImageRelation = TextImageRelation.ImageAboveText;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnNew
            // 
            btnNew.Image = (Image)resources.GetObject("btnNew.Image");
            btnNew.ImageScaling = ToolStripItemImageScaling.None;
            btnNew.ImageTransparentColor = Color.Magenta;
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(68, 100);
            btnNew.Text = "New";
            btnNew.TextImageRelation = TextImageRelation.ImageAboveText;
            btnNew.Click += btnNew_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.Image = (Image)resources.GetObject("btnRefresh.Image");
            btnRefresh.ImageScaling = ToolStripItemImageScaling.None;
            btnRefresh.ImageTransparentColor = Color.Magenta;
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(97, 100);
            btnRefresh.Text = "Refresh";
            btnRefresh.TextImageRelation = TextImageRelation.ImageAboveText;
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
            // frmCategories
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1974, 1329);
            ControlBox = false;
            Controls.Add(dgv);
            Controls.Add(toolStrip1);
            MaximumSize = new Size(2000, 1400);
            MinimumSize = new Size(2000, 1400);
            Name = "frmCategories";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmCategories";
            Load += frmCategories_Load;
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgv).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip toolStrip1;
        private DataGridView dgv;
        private DataGridViewTextBoxColumn colCategories;
        private ToolStripButton btnEdit;
        private ToolStripButton btnDelete;
        private ToolStripButton btnNew;
        private ToolStripButton btnRefresh;
        private ToolStripButton btnClose;
    }
}