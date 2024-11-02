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
    public partial class frmEmployeesAE : Form
    {
        public frmEmployeesAE()
        {
            InitializeComponent();
        }
        private Employee employee = null!;

        protected override void OnLoad(EventArgs e)
        {
            if (employee != null)
            {
                txtFirstName.Text = employee.FirstName;
                txtLastName.Text = employee.LastName;
                txtPhone.Text = employee.Phone.ToString();
                txtEmail.Text = employee.Email;
                txtAddress.Text = employee.Address;
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
                employee.Phone = int.Parse(txtPhone.Text);
                employee.Email = txtEmail.Text;
                employee.Address = txtAddress.Text;

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
                errorProvider1.SetError(txtFirstName, "First name is required.");

            }
            if (string.IsNullOrEmpty(txtLastName.Text))
            {
                valido = false;
                errorProvider1.SetError(txtLastName, "Last name is required.");

            }
            if (string.IsNullOrEmpty(txtPhone.Text))
            {
                valido = false;
                errorProvider1.SetError(txtPhone, "Enter a valid phone number.");

            }
            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                valido = false;
                errorProvider1.SetError(txtEmail, "Enter a valid email address.");

            }
            if (string.IsNullOrEmpty(txtAddress.Text))
            {
                valido = false;
                errorProvider1.SetError(txtAddress, "Enter a valid address.");

            }
            return valido;
        }

        public void SetTipo(Employee employee)
        {
            this.employee = employee;
        }
    }
}
