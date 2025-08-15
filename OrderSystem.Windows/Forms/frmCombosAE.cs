using Entities.Entities;
using Microsoft.Extensions.DependencyInjection;
using Services.Interfaces;
using Windows.Helpers;

namespace Windows.Forms
{
    public partial class frmCombosAE : Form
    {
        private readonly IServiceProvider? _serviceProvider;
        private readonly IItemsService? _services;
        private Combo? combo;

        public frmCombosAE(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            _services = _serviceProvider!.GetRequiredService<IItemsService>() ??
        throw new ApplicationException("depencias no cargadas");
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (combo is null)
            {
                combo = new Combo();
            }
            else
            {
                ShowDataInCombo();
                GridHelper.MostrarDatosEnGrilla<ComboDetail>(combo.Details, dgv);
            }
        }

        private void ShowDataInCombo()
        {
            txtComboName.Text = combo.Name;
            txtDescription.Text = combo.Description;
            numStock.Value = combo.Stock;
            numReorderLevel.Value = combo.ReorderLevel;
            numPrice.Value = combo.CostPrice;
            numSalePrice.Value = combo.SalePrice;
            checkBoxSuspended.Checked = combo.Suspended;
            dtpStartDate.Value = combo.StartDate;
            dtpEndDate.Value = combo.EndDate;

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (ValidateData())
            {

                if (combo == null)
                {
                    combo = new Combo();
                }
                combo.Name = txtComboName.Text;
                combo.Description = txtDescription.Text;
                combo.Stock = (int)numStock.Value;
                combo.ReorderLevel = (int)numReorderLevel.Value;
                combo.Suspended = checkBoxSuspended.Checked;
                combo.CostPrice = numPrice.Value;
                combo.SalePrice = numSalePrice.Value;
                combo.StartDate = dtpStartDate.Value;
                combo.EndDate = dtpEndDate.Value;


                DialogResult = DialogResult.OK;
            }
        }

        internal Combo? GetTipo()
        {
            return combo;
        }
        private bool ValidateData()
        {
            bool valido = true;
            errorProvider1.Clear();

            if (string.IsNullOrEmpty(txtComboName.Text))
            {
                valido = false;
                errorProvider1.SetError(txtComboName, "The name is required.");
            }
            if (txtComboName.Text.Length > 40)
            {
                valido = false;
                errorProvider1.SetError(txtComboName, "The name must not exceed 40 characters.");
            }
            if (txtComboName.Text.Length < 3)
            {
                valido = false;
                errorProvider1.SetError(txtComboName, "The name must be at least 3 characters long.");
            }
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtComboName.Text, @"^[a-zA-Z\s]+$"))
            {
                valido = false;
                errorProvider1.SetError(txtComboName, "The name must contain only letters and spaces.");
            }


            if (string.IsNullOrEmpty(txtDescription.Text))
            {
                valido = false;
                errorProvider1.SetError(txtDescription, "A description is required.");
            }
            if (txtDescription.Text.Length > 600)
            {
                valido = false;
                errorProvider1.SetError(txtDescription, "The description must not exceed 600 characters.");
            }
            if (txtDescription.Text.Length < 3)
            {
                valido = false;
                errorProvider1.SetError(txtDescription, "The description must be at least 3 characters long.");
            }

            if (!decimal.TryParse(numPrice.Text, out decimal costPrice)
                || costPrice <= 0)
            {
                valido = false;
                errorProvider1.SetError(numPrice, "The cost price cannot be negative or null.");
            }
            if (!decimal.TryParse(numSalePrice.Text, out decimal salePrice) || salePrice <= numPrice.Value)
            {
                valido = false;
                errorProvider1.SetError(numSalePrice, "The sale price cannot be lower than the cost price.");
            }
            if (!int.TryParse(numStock.Text, out int stock) || stock < 0)
            {
                valido = false;
                errorProvider1.SetError(numStock, "Stock cannot be negative.");
            }
            if (dtpStartDate.Value > dtpEndDate.Value)
            {
                valido = false;
                errorProvider1.SetError(dtpEndDate, "The end date cannot be earlier than the start date.");
            }
            return valido;
        }

        public void SetTipo(Combo combo)
        {
            this.combo = combo;
        }

        private void frmCombosAE_Load(object sender, EventArgs e)
        {

        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            frmAddToCombo frm = new frmAddToCombo(_serviceProvider) { Text = "Add products" };
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel) { return; }
            ComboDetail? detail = frm.GetDetail();
            if (detail is null) return;

            if (combo!.Exist(detail))
            {
                DialogResult drDetalle = MessageBox.Show(
                    $"Do you want to increase the quantity of the product {detail.Product!.Name}?", "Existing Product",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (drDetalle == DialogResult.Yes)
                {
                    combo!.Add(detail);
                }
            }
            else
            {
                combo!.Add(detail);
            }
            GridHelper.MostrarDatosEnGrilla<ComboDetail>(combo.Details, dgv);
        }

        private void btnRemoveProduct_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count == 0)
            {
                return;
            }
            var r = dgv.SelectedRows[0];
            ComboDetail detail = (ComboDetail)r.Tag!;
            DialogResult dr = MessageBox.Show($"Do you want to remove the product?",
                "Verify",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.No) return;
            else
            {
                combo!.Delete(detail);
                GridHelper.QuitarFila(r, dgv);
                MessageBox.Show("Item removed from the combo.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void btnEditProduct_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count == 0) return;
            var r = dgv.SelectedRows[0];
            ComboDetail? detail = (ComboDetail)r.Tag!;
            frmAddToCombo frm = new frmAddToCombo(_serviceProvider) { Text = "Edit product" };
            frm.SetDetail(detail);
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel) return;
            detail = frm.GetDetail();
            GridHelper.SetearFila(r, detail!);
            MessageBox.Show("Item updated", "Success",
                 MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
