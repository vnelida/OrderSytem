using Entities.Entities;
using Microsoft.Extensions.DependencyInjection;
using Services.Interfaces;
using Windows.Helpers;

namespace Windows.Forms
{
    public partial class frmPayment : Form
    {
        private IServiceProvider _serviceProvider;
        private Sale _sale;
        private ISalesService? _saleService;
        public frmPayment(Sale sale, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            _saleService = _serviceProvider.GetService<ISalesService>();
            _sale = sale;
        }

        private void frmPayment_Load(object sender, EventArgs e)
        {
            CombosHelper.LoadComboPaymentMethods(ref cboPaymentMethod, _serviceProvider);
            txtTotal.Text = _sale.TotalAmount.ToString("C");
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                decimal cashAmount = txtCash.Value;
                decimal cardAmount = txtOtherPayment.Value;

                _sale.Payments.Clear();

                if (cashAmount > 0)
                {
                    var cashPayment = new Payment
                    {
                        PaymentMethodID = 1,
                        Amount = cashAmount,
                        PaymentDate = DateTime.Now
                    };
                    _sale.Payments.Add(cashPayment);
                }

                if (cardAmount > 0)
                {
                    var cardPayment = new Payment
                    {
                        PaymentMethodID = cboPaymentMethod.SelectedIndex,
                        Amount = cardAmount,
                        PaymentDate = DateTime.Now
                    };
                    _sale.Payments.Add(cardPayment);
                }

                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();

            decimal cashAmount = txtCash.Value;
            decimal otherPaymentAmount = txtOtherPayment.Value;

            decimal totalPaidAmount = cashAmount + otherPaymentAmount;

            if (totalPaidAmount <= 0)
            {
                errorProvider1.SetError(txtCash, "Debe ingresar un monto en al menos un método de pago.");
                errorProvider1.SetError(cboPaymentMethod, "Debe ingresar un monto en al menos un método de pago.");
                valido = false;
            }

            if (totalPaidAmount < _sale.TotalAmount)
            {
                errorProvider1.SetError(txtTotal, "El monto total pagado es menor al total de la venta.");
                valido = false;
            }

            if (otherPaymentAmount > 0 && cboPaymentMethod.SelectedIndex <= 0)
            {
                errorProvider1.SetError(cboPaymentMethod, "Debe seleccionar un tipo de pago.");
                valido = false;
            }
            if (totalPaidAmount > _sale.TotalAmount)
            {
                errorProvider1.SetError(txtTotal, "El monto pagado es mayor que el total de la venta.");
                valido = false;
            }

            return valido;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnCash_Click(object sender, EventArgs e)
        {
            txtCash.Value = _sale.TotalAmount;
            txtOtherPayment.Value = 0;

        }

        private void btnOtherMethod_Click(object sender, EventArgs e)
        {
            txtOtherPayment.Value = _sale.TotalAmount;
            txtCash.Value = 0;
        }

        private void cboPaymentMethod_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
