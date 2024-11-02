using Entities.Entities;
using Windows.Helpers;

namespace Windows.Forms
{
    public partial class frmProductsAE : Form
    {
        private readonly IServiceProvider? _serviceProvider;
        private Category? selectedCategory;
        private Product? product;

        public frmProductsAE(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            CombosHelper.CargarComboCategories(ref cboCategories, _serviceProvider);
            if (product != null)
            {
                txtProductName.Text = product.ProductName;
                txtDescription.Text = product.Description;
                numPrice.Value = product.Price;
                numStock.Value = product.Stock;
                cboCategories.SelectedValue = product.CategoryId;
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

                if (product == null)
                {
                    product = new Product();
                }
                product.ProductName = txtProductName.Text;
                product.Description = txtDescription.Text;
                product.Stock = ((int)numStock.Value);
                product.Price = numPrice.Value;
                if (cboCategories.SelectedValue is not null)
                {
                    product.CategoryId = (int)cboCategories.SelectedValue;
                    product.Category = selectedCategory;

                }

                DialogResult = DialogResult.OK;
            }
        }
        private void cboCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCategories.SelectedIndex == 0)
            {
                selectedCategory = null;
            }
            else
            {
                selectedCategory = (Category?)cboCategories.SelectedItem;
            }
        }
        internal Product? GetTipo()
        {
            return product;
        }
        private bool ValidateData()
        {
            bool valido = true;
            errorProvider1.Clear();

            if (string.IsNullOrEmpty(txtProductName.Text))
            {
                valido = false;
                errorProvider1.SetError(txtProductName, "You must enter a valid category.");

            }
            return valido;
        }

        public void SetTipo(Product product)
        {
            this.product = product;
        }
    }
}
