namespace OrderSystem.Windows
{
    partial class MainMenu
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenu));
            btnCategories = new Button();
            btnEmployees = new Button();
            btnProduct = new Button();
            btnCombos = new Button();
            splitContainer1 = new SplitContainer();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // btnCategories
            // 
            btnCategories.AutoSize = true;
            btnCategories.Image = (Image)resources.GetObject("btnCategories.Image");
            btnCategories.Location = new Point(12, 12);
            btnCategories.Name = "btnCategories";
            btnCategories.Size = new Size(168, 142);
            btnCategories.TabIndex = 0;
            btnCategories.Text = "Categories";
            btnCategories.TextImageRelation = TextImageRelation.ImageAboveText;
            btnCategories.UseVisualStyleBackColor = true;
            btnCategories.Click += btnCategories_Click;
            // 
            // btnEmployees
            // 
            btnEmployees.AutoSize = true;
            btnEmployees.Image = (Image)resources.GetObject("btnEmployees.Image");
            btnEmployees.Location = new Point(12, 308);
            btnEmployees.Name = "btnEmployees";
            btnEmployees.Size = new Size(168, 142);
            btnEmployees.TabIndex = 1;
            btnEmployees.Text = "Employees";
            btnEmployees.TextImageRelation = TextImageRelation.ImageAboveText;
            btnEmployees.UseVisualStyleBackColor = true;
            btnEmployees.Click += btnEmployees_Click;
            // 
            // btnProduct
            // 
            btnProduct.AutoSize = true;
            btnProduct.Image = (Image)resources.GetObject("btnProduct.Image");
            btnProduct.Location = new Point(12, 160);
            btnProduct.Name = "btnProduct";
            btnProduct.Size = new Size(168, 142);
            btnProduct.TabIndex = 2;
            btnProduct.Text = "Products";
            btnProduct.TextImageRelation = TextImageRelation.ImageAboveText;
            btnProduct.UseVisualStyleBackColor = true;
            btnProduct.Click += btnProduct_Click;
            // 
            // btnCombos
            // 
            btnCombos.AutoSize = true;
            btnCombos.Image = (Image)resources.GetObject("btnCombos.Image");
            btnCombos.Location = new Point(12, 456);
            btnCombos.Name = "btnCombos";
            btnCombos.Size = new Size(168, 142);
            btnCombos.TabIndex = 3;
            btnCombos.Text = "Combos";
            btnCombos.TextImageRelation = TextImageRelation.ImageAboveText;
            btnCombos.UseVisualStyleBackColor = true;
            btnCombos.Click += btnCombos_Click;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(btnCombos);
            splitContainer1.Panel1.Controls.Add(btnEmployees);
            splitContainer1.Panel1.Controls.Add(btnProduct);
            splitContainer1.Panel1.Controls.Add(btnCategories);
            splitContainer1.Size = new Size(1774, 929);
            splitContainer1.SplitterDistance = 333;
            splitContainer1.TabIndex = 4;
            // 
            // MainMenu
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1774, 929);
            Controls.Add(splitContainer1);
            Name = "MainMenu";
            StartPosition = FormStartPosition.CenterScreen;
            WindowState = FormWindowState.Maximized;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button btnCategories;
        private Button btnEmployees;
        private Button btnProduct;
        private Button btnCombos;
        private SplitContainer splitContainer1;
    }
}
