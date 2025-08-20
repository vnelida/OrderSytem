using Entities.Entities;
using Entities.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Services.Interfaces;
using System.Data;
using System.Text.RegularExpressions;
using Windows.Helpers;

namespace Windows.Forms
{
    public partial class frmCustomersAE : Form
    {
        private readonly IServiceProvider? _serviceProvider;
        private List<AddressWithTypeVM> _addressVMs = new List<AddressWithTypeVM>();
        private List<PhonesWithTypeVM> _phoneVMs = new List<PhonesWithTypeVM>();
        private readonly ICustomersServices _customersService;
        private Customer? _customer;

        public frmCustomersAE(IServiceProvider? serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            _customersService = serviceProvider!.GetRequiredService<ICustomersServices>()
               ?? throw new ApplicationException("Dependencies for ICustomersServices not loaded");

        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (_customer == null)
            {
                _customer = new Customer();
                _customer.CustomerId = 0;
                _addressVMs = _customer.CustomerAdresses.Select(ca => new AddressWithTypeVM(ca)).ToList();
                _phoneVMs = _customer.CustomerPhones.Select(cp => new PhonesWithTypeVM(cp)).ToList();
            }
            else 
            {
                txtDocumentNum.Text = _customer.DocumentNumber.ToString();
                _addressVMs = _customer.CustomerAdresses.Select(ca => new AddressWithTypeVM(ca)).ToList();
                _phoneVMs = _customer.CustomerPhones.Select(cp => new PhonesWithTypeVM(cp)).ToList();
            }
            GridHelper.MostrarDatosEnGrilla<AddressWithTypeVM>(_addressVMs, dgv);
            GridHelper.MostrarDatosEnGrilla<PhonesWithTypeVM>(_phoneVMs, dgvPhones);
        }

        private void btnAddAddress_Click(object sender, EventArgs e)
        {
            CustomerAddress newCustomerAddressEntity = new CustomerAddress
            {
                CustomerId = _customer?.CustomerId ?? 0, 
                Address = new Address(),                 
                AddressType = new AddressType()          
            };
            frmAddressesAE frm = new frmAddressesAE(_serviceProvider!); 
            frm.Text = "Add Address";
            frm.SetCustomerAddress(newCustomerAddressEntity);

            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel) return; 

            if (_customer!.CustomerAdresses.Any(ca => ca.Address?.Equals(newCustomerAddressEntity.Address) ?? false))
            {
                MessageBox.Show("This address is already on file for this client.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            newCustomerAddressEntity.Address!.AddressId = 0; 
            newCustomerAddressEntity.AddressId = 0;          

            _customer.CustomerAdresses.Add(newCustomerAddressEntity);

            AddressWithTypeVM newAddressVm = new AddressWithTypeVM(newCustomerAddressEntity);
            _addressVMs.Add(newAddressVm); 

            GridHelper.MostrarDatosEnGrilla<AddressWithTypeVM>(_addressVMs, dgv);

            MessageBox.Show("Address added successfully. Don't forget to save the client's changes.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        private void btnEditAddresses_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count == 0) return;

            var r = dgv.SelectedRows[0];
            AddressWithTypeVM? addressToEditVm = r.Tag as AddressWithTypeVM;
            if (addressToEditVm?.CustomerAddressEntity is null)
            {
                MessageBox.Show("Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            CustomerAddress originalCustomerAddressEntity = addressToEditVm.CustomerAddressEntity;

            frmAddressesAE frm = new frmAddressesAE(_serviceProvider!);
            frm.Text = "Edit Address";
            frm.SetCustomerAddress(originalCustomerAddressEntity); 

            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                AddressWithTypeVM updatedVmForGrid = new AddressWithTypeVM(originalCustomerAddressEntity);
                int index = _addressVMs.IndexOf(addressToEditVm); 
                if (index != -1)
                {
                    _addressVMs[index] = updatedVmForGrid; 
                    GridHelper.MostrarDatosEnGrilla<AddressWithTypeVM>(_addressVMs, dgv); 
                    MessageBox.Show("Address updated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnDeleteAddress_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count == 0) return;

            var r = dgv.SelectedRows[0];
            AddressWithTypeVM? addressToDeleteVm = r.Tag as AddressWithTypeVM;
            if (addressToDeleteVm?.CustomerAddressEntity is null)
            {
                MessageBox.Show("Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show("Are you sure you want to delete this address?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _customer?.CustomerAdresses.Remove(addressToDeleteVm.CustomerAddressEntity); 
                _addressVMs.Remove(addressToDeleteVm); 
                GridHelper.MostrarDatosEnGrilla<AddressWithTypeVM>(_addressVMs, dgv);
                MessageBox.Show("The address has been removed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }



        private void btnAddPhone_Click(object sender, EventArgs e)
        {
            CustomerPhone newCustomerPhoneEntity = new CustomerPhone
            {
                CustomerId = _customer?.CustomerId ?? 0,
                Phone = new Phone(), 
                PhoneType = new PhoneType() 
            };

            frmPhonesAE frm = new frmPhonesAE(_serviceProvider!); 
            frm.Text = "Add Phone";
            frm.SetCustomerPhone(newCustomerPhoneEntity);

            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                

                if (_customer?.CustomerPhones.Any(cp => cp.Phone?.PhoneNumber == newCustomerPhoneEntity.Phone?.PhoneNumber) ?? false)
                {
                    MessageBox.Show("The phone number already exists in the list for this customer.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; 
                }
                newCustomerPhoneEntity.Phone!.PhoneId = 0;
                newCustomerPhoneEntity.PhoneId = 0;       

                _customer?.CustomerPhones.Add(newCustomerPhoneEntity);
                _phoneVMs.Add(new PhonesWithTypeVM(newCustomerPhoneEntity));
                GridHelper.MostrarDatosEnGrilla<PhonesWithTypeVM>(_phoneVMs, dgvPhones);
                MessageBox.Show("Phone number added successfully.", "Notification ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btnOk_Click_1(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (_customer is null)
                {
                    _customer = new Customer();
                }

                _customer.DocumentNumber = int.Parse(txtDocumentNum.Text); 
                _customer.LastName = txtLastName.Text;
                _customer.FirstName = txtFirstName.Text;

                _customer.CustomerAdresses = _addressVMs.Select(vm => vm.CustomerAddressEntity)
                                                        .Where(entity => entity != null) 
                                                        .ToList()!; 

                _customer.CustomerPhones = _phoneVMs.Select(vm => vm.CustomerPhoneEntity)
                                                      .Where(entity => entity != null) 
                                                      .ToList()!; 

                DialogResult = DialogResult.OK;
            }
        }
        private void btnEditPhones_Click(object sender, EventArgs e)
        {
            if (dgvPhones.SelectedRows.Count == 0) return;

            var r = dgvPhones.SelectedRows[0];
            PhonesWithTypeVM? phoneToEditVm = r.Tag as PhonesWithTypeVM;
            if (phoneToEditVm?.CustomerPhoneEntity is null) return;

            CustomerPhone originalCustomerPhoneEntity = phoneToEditVm.CustomerPhoneEntity;

            frmPhonesAE frm = new frmPhonesAE(_serviceProvider!);
            frm.Text = "Edit Phone";
            frm.SetCustomerPhone(originalCustomerPhoneEntity);

            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                PhonesWithTypeVM updatedVmForGrid = new PhonesWithTypeVM(originalCustomerPhoneEntity);
                
                int index = _phoneVMs.IndexOf(phoneToEditVm);
                if (index != -1)
                {
                    _phoneVMs[index] = updatedVmForGrid;
                    GridHelper.MostrarDatosEnGrilla<PhonesWithTypeVM>(_phoneVMs, dgvPhones);
                    MessageBox.Show("Phone updated.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btnDeletePhone_Click(object sender, EventArgs e)
        {
            if (dgvPhones.SelectedRows.Count == 0) return;

            var r = dgvPhones.SelectedRows[0];
            PhonesWithTypeVM? phoneToDeleteVm = r.Tag as PhonesWithTypeVM;
            if (phoneToDeleteVm?.CustomerPhoneEntity is null) return;

            if (MessageBox.Show("Are you sure you want to delete this phone number?","Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _customer?.CustomerPhones.Remove(phoneToDeleteVm.CustomerPhoneEntity);
                _phoneVMs.Remove(phoneToDeleteVm);
                GridHelper.MostrarDatosEnGrilla<PhonesWithTypeVM>(_phoneVMs, dgvPhones);
                MessageBox.Show("Phone number removed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        internal void SetCustomer(Customer customer)
        {
            _customer = customer;           
            txtFirstName.Text = _customer.FirstName;
            txtLastName.Text = _customer.LastName;

            _addressVMs = _customer.CustomerAdresses.Select(ca => new AddressWithTypeVM(ca)).ToList();
            GridHelper.MostrarDatosEnGrilla<AddressWithTypeVM>(_addressVMs, dgv); 

            _phoneVMs = _customer.CustomerPhones.Select(cp => new PhonesWithTypeVM(cp)).ToList();
            GridHelper.MostrarDatosEnGrilla<PhonesWithTypeVM>(_phoneVMs, dgvPhones); 

        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        public Customer? GetCustomer()
        {
            if (_customer == null) return null; 

            _customer.DocumentNumber = int.Parse(txtDocumentNum.Text);
            _customer.FirstName = txtFirstName.Text;
            _customer.LastName = txtLastName.Text;

            return _customer;
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (!Regex.IsMatch(txtDocumentNum.Text, @"^\d{8}$"))
            {
                valido = false;
                errorProvider1.SetError(txtDocumentNum, "Document must have exactly 8 numeric characters.");
            }
            if (string.IsNullOrEmpty(txtLastName.Text.Trim()))
            {
                valido = false;
                errorProvider1.SetError(txtLastName, "Last name is required");
            }
            if (string.IsNullOrEmpty(txtFirstName.Text.Trim()))
            {
                valido = false;
                errorProvider1.SetError(txtFirstName, "First name is required");
            }
            if (_addressVMs.Count == 0)
            {
                valido = false;
                errorProvider1.SetError(lblAddresses, "You must enter at least one address");
            }

            return valido;
        }
    }
}
