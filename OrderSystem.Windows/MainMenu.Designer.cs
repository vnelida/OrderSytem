﻿namespace OrderSystem.Windows
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
            btnCustomers = new Button();
            btnExist = new Button();
            btnOrders = new Button();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // btnCategories
            // 
            btnCategories.Anchor = AnchorStyles.Top;
            btnCategories.AutoSize = true;
            btnCategories.BackColor = SystemColors.ControlLightLight;
            btnCategories.BackgroundImage = (Image)resources.GetObject("btnCategories.BackgroundImage");
            btnCategories.ForeColor = SystemColors.ActiveCaptionText;
            btnCategories.Image = (Image)resources.GetObject("btnCategories.Image");
            btnCategories.Location = new Point(69, 12);
            btnCategories.Name = "btnCategories";
            btnCategories.Size = new Size(168, 142);
            btnCategories.TabIndex = 0;
            btnCategories.Text = "Categories";
            btnCategories.TextImageRelation = TextImageRelation.ImageAboveText;
            btnCategories.UseVisualStyleBackColor = false;
            btnCategories.Click += btnCategories_Click;
            // 
            // btnEmployees
            // 
            btnEmployees.Anchor = AnchorStyles.Top;
            btnEmployees.AutoSize = true;
            btnEmployees.BackgroundImage = (Image)resources.GetObject("btnEmployees.BackgroundImage");
            btnEmployees.Image = (Image)resources.GetObject("btnEmployees.Image");
            btnEmployees.Location = new Point(69, 308);
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
            btnProduct.Anchor = AnchorStyles.Top;
            btnProduct.AutoSize = true;
            btnProduct.BackgroundImage = (Image)resources.GetObject("btnProduct.BackgroundImage");
            btnProduct.Image = (Image)resources.GetObject("btnProduct.Image");
            btnProduct.Location = new Point(69, 160);
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
            btnCombos.Anchor = AnchorStyles.Top;
            btnCombos.AutoSize = true;
            btnCombos.BackgroundImage = (Image)resources.GetObject("btnCombos.BackgroundImage");
            btnCombos.Image = (Image)resources.GetObject("btnCombos.Image");
            btnCombos.Location = new Point(69, 456);
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
            splitContainer1.Panel1.BackColor = SystemColors.ButtonHighlight;
            splitContainer1.Panel1.BackgroundImage = (Image)resources.GetObject("splitContainer1.Panel1.BackgroundImage");
            splitContainer1.Panel1.Controls.Add(btnOrders);
            splitContainer1.Panel1.Controls.Add(btnCustomers);
            splitContainer1.Panel1.Controls.Add(btnExist);
            splitContainer1.Panel1.Controls.Add(btnCombos);
            splitContainer1.Panel1.Controls.Add(btnEmployees);
            splitContainer1.Panel1.Controls.Add(btnProduct);
            splitContainer1.Panel1.Controls.Add(btnCategories);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.BackgroundImage = (Image)resources.GetObject("splitContainer1.Panel2.BackgroundImage");
            splitContainer1.Panel2.BackgroundImageLayout = ImageLayout.Stretch;
            splitContainer1.Size = new Size(2236, 1107);
            splitContainer1.SplitterDistance = 249;
            splitContainer1.TabIndex = 4;
            // 
            // btnCustomers
            // 
            btnCustomers.Anchor = AnchorStyles.Top;
            btnCustomers.AutoSize = true;
            btnCustomers.BackgroundImage = (Image)resources.GetObject("btnCustomers.BackgroundImage");
            btnCustomers.Image = (Image)resources.GetObject("btnCustomers.Image");
            btnCustomers.Location = new Point(69, 604);
            btnCustomers.Name = "btnCustomers";
            btnCustomers.Size = new Size(168, 142);
            btnCustomers.TabIndex = 5;
            btnCustomers.Text = "Customers";
            btnCustomers.TextImageRelation = TextImageRelation.ImageAboveText;
            btnCustomers.UseVisualStyleBackColor = true;
            btnCustomers.Click += btnCustomers_Click;
            // 
            // btnExist
            // 
            btnExist.Anchor = AnchorStyles.Bottom;
            btnExist.BackgroundImage = (Image)resources.GetObject("btnExist.BackgroundImage");
            btnExist.Image = (Image)resources.GetObject("btnExist.Image");
            btnExist.Location = new Point(69, 953);
            btnExist.Name = "btnExist";
            btnExist.Size = new Size(168, 142);
            btnExist.TabIndex = 4;
            btnExist.Text = "Exist";
            btnExist.TextImageRelation = TextImageRelation.ImageAboveText;
            btnExist.UseVisualStyleBackColor = true;
            btnExist.Click += btnExist_Click;
            // 
            // btnOrders
            // 
            btnOrders.Anchor = AnchorStyles.Top;
            btnOrders.AutoSize = true;
            btnOrders.BackgroundImage = (Image)resources.GetObject("btnOrders.BackgroundImage");
            btnOrders.Image = (Image)resources.GetObject("btnOrders.Image");
            btnOrders.Location = new Point(69, 752);
            btnOrders.Name = "btnOrders";
            btnOrders.Size = new Size(168, 142);
            btnOrders.TabIndex = 6;
            btnOrders.Text = "Orders";
            btnOrders.TextImageRelation = TextImageRelation.ImageAboveText;
            btnOrders.UseVisualStyleBackColor = true;
            btnOrders.Click += btnOrders_Click;
            // 
            // MainMenu
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2236, 1107);
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
        private Button btnExist;
        private Button btnCustomers;
        private Button btnOrders;
    }
}
