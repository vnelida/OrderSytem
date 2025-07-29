

namespace Windows.UsersControl
{
    partial class ucItem
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            btnOk = new Button();
            lblPrice = new Label();
            lblName = new Label();
            picImage = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)picImage).BeginInit();
            SuspendLayout();
            // 
            // btnOk
            // 
            btnOk.Location = new Point(27, 236);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(150, 46);
            btnOk.TabIndex = 0;
            btnOk.Text = "Add";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Location = new Point(64, 191);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(78, 32);
            lblPrice.TabIndex = 1;
            lblPrice.Text = "label1";
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(27, 143);
            lblName.Name = "lblName";
            lblName.Size = new Size(78, 32);
            lblName.TabIndex = 2;
            lblName.Text = "label2";
            // 
            // picImage
            // 
            picImage.Location = new Point(27, 19);
            picImage.Margin = new Padding(6);
            picImage.Name = "picImage";
            picImage.Size = new Size(150, 118);
            picImage.SizeMode = PictureBoxSizeMode.StretchImage;
            picImage.TabIndex = 3;
            picImage.TabStop = false;
            // 
            // ucItem
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(picImage);
            Controls.Add(lblName);
            Controls.Add(lblPrice);
            Controls.Add(btnOk);
            Name = "ucItem";
            Size = new Size(200, 300);
            MouseEnter += ucItem_MouseEnter;
            MouseLeave += ucItem_MouseLeave;
            ((System.ComponentModel.ISupportInitialize)picImage).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblPrice;
        private Label lblName;
        private PictureBox picImage;
        public Button btnOk;
    }
}
