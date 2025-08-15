using Data.Interfaces;
using Entities.Entities;
using Microsoft.Extensions.DependencyInjection;
using Services.Interfaces;
using Windows.Helpers;

namespace Windows.Forms
{
    public partial class frmPhonesAE : Form
    {
        private readonly IServiceProvider? _serviceProvider;
        private CustomerPhone? _customerPhone;
        private ICustomersServices? _customersService;
        private readonly IPhoneService _phoneService;


        public frmPhonesAE(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            _phoneService = serviceProvider.GetRequiredService<IPhoneService>();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            CombosHelper.LoadPhoneTypesComboBox(ref cboPhoneType, _serviceProvider!);

            if (_customerPhone == null)
            {
                _customerPhone = new CustomerPhone { Phone = new Phone(), PhoneType = new PhoneType() };
                txtPhone.Text = string.Empty;
                cboPhoneType.SelectedIndex = -1;
            }
            else
            {
                txtPhone.Text = _customerPhone.Phone?.PhoneNumber;

                if (_customerPhone.PhoneType?.PhoneTypeId > 0)
                {
                    cboPhoneType.SelectedValue = _customerPhone.PhoneType.PhoneTypeId;
                }
                else
                {
                    cboPhoneType.SelectedIndex = -1;
                }
            }
            txtPhone.Focus();
        }
        public CustomerPhone? GetCustomerPhone()
        {
            return _customerPhone;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (_customerPhone.Phone != null)
                {
                    _customerPhone.Phone.PhoneNumber = txtPhone.Text;
                }
                else
                {
                    _customerPhone.Phone = new Phone { PhoneNumber = txtPhone.Text };
                }

                if (_customerPhone.Phone.PhoneId == 0)
                {
                    if (_phoneService.Exist(txtPhone.Text))
                    {
                        MessageBox.Show("This phone number is already associated with another customer.", "Error", MessageBoxButtons.OK);
                        errorProvider1.SetError(txtPhone, "Error");
                        return;
                    }
                }

                PhoneType selectedPhoneType = (PhoneType)cboPhoneType.SelectedItem;
                _customerPhone.PhoneType = selectedPhoneType;
                _customerPhone.PhoneTypeId = selectedPhoneType.PhoneTypeId;

                DialogResult = DialogResult.OK;
            }
        }


        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();

            if (cboPhoneType.SelectedIndex <= 0)
            {
                valido = false;
                errorProvider1.SetError(cboPhoneType, "You must select a phone type.");
            }

            string phoneNumber = txtPhone.Text.Trim();

            if (string.IsNullOrEmpty(phoneNumber))
            {
                valido = false;
                errorProvider1.SetError(txtPhone, "Phone number is required.");
            }
            else
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(phoneNumber, @"^\d+$"))
                {
                    valido = false;
                    errorProvider1.SetError(txtPhone, "Phone number must contain only digits (0-9).");
                }
                else if (phoneNumber.Length > 12)
                {
                    valido = false;
                    errorProvider1.SetError(txtPhone, "Phone number cannot exceed 12 digits.");
                }
            }

            return valido;
        }

        internal void SetCustomerPhone(CustomerPhone customerPhone)
        {
            _customerPhone = customerPhone;

            if (_customerPhone.Phone == null)
            {
                _customerPhone.Phone = new Phone();
            }

            txtPhone.Text = _customerPhone.Phone.PhoneNumber;

        }

        private void frmPhonesAE_Load(object sender, EventArgs e)
        {

        }
    }
}
