using Entities.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Windows.Forms
{
    public partial class frmCategoriesAE : Form
    {
        public frmCategoriesAE()
        {
            InitializeComponent();
        }

        private Category category = null!;

        protected override void OnLoad(EventArgs e)
        {
            if (category != null)
            {
                txtCategory.Text = category.CategoryName;
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (ValidateData())
            {

                if (category == null)
                {
                    category = new Category();
                }
                category.CategoryName = txtCategory.Text;

                DialogResult = DialogResult.OK;
            }
        }
        internal Category GetTipo()
        {
            return category;
        }
        private bool ValidateData()
        {
            bool valido = true;
            errorProvider1.Clear();

            if (string.IsNullOrEmpty(txtCategory.Text))
            {
                valido = false;
                errorProvider1.SetError(txtCategory, "You must enter a valid category.");

            }
            return valido;
        }

        public void SetTipo(Category category)
        {
            this.category = category;
        }
    }
}
