using Entities.Entities;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Windows.Helpers;

namespace Windows.Forms
{
    public partial class frmUsersAE : Form
    {
        private readonly IServiceProvider? _serviceProvider;
        private Rol? selectedRole;
        private User? user;
        public frmUsersAE(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
        }

        internal User GetUser()
        {
            return user;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (user is null)
                {
                    user = new User();
                }
                user.UserName = txtUserName.Text;
                user.Password = txtPassword.Text;
                user.IsActive = checkBoxActive.Checked;
                if (cboRol.SelectedValue is not null)
                {
                    user.RoleId =(int)cboRol.SelectedIndex;
                    user.Rol = selectedRole;

                }
                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();

            if (string.IsNullOrEmpty(txtUserName.Text))
            {
                valido = false;
                errorProvider1.SetError(txtUserName, "User name is required.");
            }
            else if (txtUserName.Text.Length < 4 || txtUserName.Text.Length > 20)
            {
                valido = false;
                errorProvider1.SetError(txtUserName, "User name must be between 4 and 20 characters.");
            }
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                valido = false;
                errorProvider1.SetError(txtPassword, "Password is required.");
            }
            else if (txtPassword.Text.Length < 4 || txtPassword.Text.Length > 20)
            {
                valido = false;
                errorProvider1.SetError(txtPassword, "Password must be between 4 and 20 characters.");
            }
            else if (txtPassword.Text != txtConfirmPassword.Text)
            {
                valido = false;
                errorProvider1.SetError(txtConfirmPassword, "Passwords do not match.");
            }
            if (cboRol.SelectedIndex <= 0)
            {
                valido = false;
                errorProvider1.SetError(cboRol, "You must select a role.");
            }

            return valido;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            CombosHelper.LoadComboRoles(ref cboRol, _serviceProvider);
            if (user is not null)
            {
                txtUserName.Text = user.UserName;
                txtPassword.Text = user.Password;
                txtConfirmPassword.Text = user.Password;
                checkBoxActive.Checked = user.IsActive;
                cboRol.SelectedValue = user.RoleId;
            }
        }

        private void cboRol_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboRol.SelectedIndex == 0)
            {
                selectedRole = null;
            }
            else
            {
                selectedRole = (Rol?)cboRol.SelectedItem;
            }
        }

        public void SetProvEstado(User user)
        {
            this.user = user;
        }
    }
}
