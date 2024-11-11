using Entities.Entities;
using Microsoft.Extensions.DependencyInjection;
using System.Windows.Forms;
using Windows.Helpers;

namespace Windows.Forms
{
    public partial class frmAddToCombo : Form
    {
        private readonly IServiceProvider? _serviceProvider;
        private ComboDetail? comboDetail;
        private Product? selectedProduct;
        public frmAddToCombo(IServiceProvider? serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            CombosHelper.CargarComboProducts(ref cboProducts, _serviceProvider);
            if (comboDetail is not null)
            {
                cboProducts.SelectedValue = comboDetail.ComboId;
                numQuantity.Value = comboDetail.Quantity;
            }
        }

        public ComboDetail? GetDetail()
        {
            return comboDetail;
        }

        public void SetDetail(ComboDetail comboDetail)
        {
            this.comboDetail = comboDetail;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (ValidateData())
            {
                if (comboDetail is null)
                {
                    comboDetail = new ComboDetail();
                }
                comboDetail.ProductId = selectedProduct!.ItemId;
                comboDetail.Quantity = (int)numQuantity.Value;
                comboDetail.Product = selectedProduct;
                selectedProduct = comboDetail.Product;
                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidateData()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (cboProducts.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(cboProducts, "You must select a product.");
            }
            return valido;
        }

        private void cboProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedProduct = cboProducts.SelectedIndex > 0 ? (Product)cboProducts.SelectedItem! : null;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
