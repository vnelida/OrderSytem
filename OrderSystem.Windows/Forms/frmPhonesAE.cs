using Entities.Entities;
using Entities.ViewModels;
using Windows.Helpers;

namespace Windows.Forms
{
    public partial class frmPhonesAE : Form
    {
        private readonly IServiceProvider? _serviceProvider;
        //private PhonesWithTypeVM? phoneTypeVm;
        private Phone? _phoneToEdit;
        public frmPhonesAE(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            CombosHelper.LoadPhoneTypesComboBox(ref cboPhoneType, _serviceProvider);
            // ¡AJUSTAR ESTA CONDICIÓN PARA USAR _phoneToEdit!
            if (_phoneToEdit != null)
            {
                cboPhoneType.SelectedValue = _phoneToEdit.PhoneType?.PhoneTypeId;
                txtPhone.Text = _phoneToEdit.PhoneNumber;
            }
        }
        //public PhonesWithTypeVM? GetPhone1()
        //{
        //    return phoneTypeVm;
        //}
        public Phone? GetPhone() // Ahora devuelve la entidad Phone (con PhoneType dentro)
        {
            return _phoneToEdit;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (_phoneToEdit is null)
                {
                    _phoneToEdit = new Phone();
                }

                _phoneToEdit.PhoneNumber = txtPhone.Text;
                _phoneToEdit.PhoneType = cboPhoneType.SelectedItem as PhoneType;

                DialogResult = DialogResult.OK;
            }
            //if (ValidarDatos()) // Si los datos son válidos
            //{
            //    // ¡ELIMINA ESTA CONDICIÓN! No la necesitas.
            //    // if (phoneTypeVm is not null) 
            //    // {

            //    // Aquí el código que crea o actualiza phoneTypeVm SIEMPRE se ejecutará
            //    var phone = new Phone
            //    {
            //        PhoneNumber = txtPhone.Text,
            //    };

            //    var typePhone = (PhoneType?)cboPhoneType.SelectedItem;

            //    // Si es "Agregar", phoneTypeVm será null y se asignará una nueva instancia.
            //    // Si es "Editar", phoneTypeVm ya tendrá un valor y se actualizará.
            //    phoneTypeVm = new PhonesWithTypeVM(phone, typePhone);

            //    DialogResult = DialogResult.OK; // El formulario se cierra con OK
            //                                    // } // Cierra el 'if' que comentaste
            //}
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

        internal void SetPhone(Phone phone)
        {
            _phoneToEdit=phone;
        }
    }
}
