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
            btnCategories = new Button();
            btnEmployees = new Button();
            btnProduct = new Button();
            SuspendLayout();
            // 
            // btnCategories
            // 
            btnCategories.Location = new Point(280, 144);
            btnCategories.Name = "btnCategories";
            btnCategories.Size = new Size(168, 57);
            btnCategories.TabIndex = 0;
            btnCategories.Text = "Categories";
            btnCategories.UseVisualStyleBackColor = true;
            btnCategories.Click += btnCategories_Click;
            // 
            // btnEmployees
            // 
            btnEmployees.Location = new Point(471, 144);
            btnEmployees.Name = "btnEmployees";
            btnEmployees.Size = new Size(168, 57);
            btnEmployees.TabIndex = 1;
            btnEmployees.Text = "Employees";
            btnEmployees.UseVisualStyleBackColor = true;
            btnEmployees.Click += btnEmployees_Click;
            // 
            // btnProduct
            // 
            btnProduct.Location = new Point(90, 144);
            btnProduct.Name = "btnProduct";
            btnProduct.Size = new Size(168, 57);
            btnProduct.TabIndex = 2;
            btnProduct.Text = "Products";
            btnProduct.UseVisualStyleBackColor = true;
            btnProduct.Click += btnProduct_Click;
            // 
            // MainMenu
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnProduct);
            Controls.Add(btnEmployees);
            Controls.Add(btnCategories);
            Name = "MainMenu";
            ResumeLayout(false);
        }

        #endregion

        private Button btnCategories;
        private Button btnEmployees;
        private Button btnProduct;
    }
}
