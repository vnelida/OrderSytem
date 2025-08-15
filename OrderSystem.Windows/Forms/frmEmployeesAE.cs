using Entities.Entities;
using Windows.Helpers;

namespace Windows.Forms
{
    public partial class frmEmployeesAE : Form
    {
        private readonly IServiceProvider? _serviceProvider;

        public frmEmployeesAE(IServiceProvider? serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
        }
        private Employee? employee;
        private Genre? selectedGenre;

        protected override void OnLoad(EventArgs e)
        {
            CombosHelper.CargarComboGenres(ref cboGenres, _serviceProvider);

            if (employee != null)
            {
                txtFirstName.Text = employee.FirstName;
                txtLastName.Text = employee.LastName;
                txtPhone.Text = employee.Phone.ToString();
                txtEmail.Text = employee.Email;
                txtAddress.Text = employee.Address;
                txtDni.Text = employee.Dni;
                cboGenres.SelectedValue = employee.GenreId;
                dtpBDate.Value = employee.DateOfBirth;
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

                if (employee == null)
                {
                    employee = new Employee();
                }
                employee.FirstName = txtFirstName.Text;
                employee.LastName = txtLastName.Text;
                employee.Phone = txtPhone.Text;
                employee.Email = txtEmail.Text;
                employee.Address = txtAddress.Text;
                employee.Dni = txtDni.Text;
                if (cboGenres.SelectedValue is not null)
                {
                    employee.GenreId = (int)cboGenres.SelectedValue;
                    employee.Genre = selectedGenre;

                }
                employee.DateOfBirth = dtpBDate.Value;

                DialogResult = DialogResult.OK;
            }
        }
        internal Employee GetTipo()
        {
            return employee;
        }
        private bool ValidateData()
        {
            bool valido = true;
            errorProvider1.Clear();

            if (string.IsNullOrEmpty(txtFirstName.Text))
            {
                valido = false;
                errorProvider1.SetError(txtFirstName, "The fisrt name is required.");
            }
            if (txtFirstName.Text.Length > 40)
            {
                valido = false;
                errorProvider1.SetError(txtFirstName, "The first name must not exceed 40 characters.");
            }
            if (txtFirstName.Text.Length < 3)
            {
                valido = false;
                errorProvider1.SetError(txtFirstName, "The fisrt name must be at least 3 characters long.");
            }
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtFirstName.Text, @"^[a-zA-Z\s]+$"))
            {
                valido = false;
                errorProvider1.SetError(txtFirstName, "The first name must contain only letters and spaces.");
            }


            if (string.IsNullOrEmpty(txtLastName.Text) || txtLastName.Text.Length > 40 || txtLastName.Text.Length < 3 || !System.Text.RegularExpressions.Regex.IsMatch(txtLastName.Text, @"^[a-zA-Z\s]+$"))
            {
                valido = false;
                errorProvider1.SetError(txtLastName, "Last name is required and must contain only letters.");
            }
            if (string.IsNullOrEmpty(txtPhone.Text) || txtPhone.Text.Length < 4 || txtPhone.Text.Length > 10 || !System.Text.RegularExpressions.Regex.IsMatch(txtPhone.Text, @"^[\d-]+$"))
            {
                valido = false;
                errorProvider1.SetError(txtPhone, "Enter a valid phone number.");
            }
            if (string.IsNullOrEmpty(txtEmail.Text) || txtEmail.Text.Length > 40)
            {
                valido = false;
                errorProvider1.SetError(txtEmail, "Enter a valid email address.");
            }
            if (string.IsNullOrEmpty(txtAddress.Text) || txtAddress.Text.Length > 70)
            {
                valido = false;
                errorProvider1.SetError(txtAddress, "Enter a valid address.");
            }
            if (string.IsNullOrEmpty(txtDni.Text) || txtDni.Text.Length > 8 || !System.Text.RegularExpressions.Regex.IsMatch(txtDni.Text, @"^\d+$"))
            {
                valido = false;
                errorProvider1.SetError(txtDni, "Enter a valid DNI with up to 8 digits, no letters, spaces, or symbols.");
            }
            int age = DateTime.Now.Year - dtpBDate.Value.Year;
            if (age < 18)
            {
                valido = false;
                errorProvider1.SetError(dtpBDate, "The employee must be over 18 years old.");
            }
            if (cboGenres.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(cboGenres, "You must select a genre.");
            }
            return valido;
        }

        public void SetTipo(Employee employee)
        {
            this.employee = employee;
        }

        private void cboGenres_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }
    }
}
