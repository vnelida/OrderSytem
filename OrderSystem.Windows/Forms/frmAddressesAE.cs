using Entities.Entities;
using Windows.Helpers;

namespace Windows.Forms
{
    public partial class frmAddressesAE : Form
    {
        private readonly IServiceProvider? _serviceProvider;
        private CustomerAddress? _customerAddress;
        private Country? country;
        private StateProvince? stateProvince;
        private City? city;
        private AddressType? addressType;
        public frmAddressesAE(IServiceProvider? serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            CombosHelper.LaodAddressTypesComboBox(ref cboAddressTypes, _serviceProvider!);
            CombosHelper.LoadCountriesComboBox(ref cboCountries, _serviceProvider!);

            if (_customerAddress == null)
            {
                _customerAddress = new CustomerAddress
                {
                    Address = new Address(),     
                    AddressType = new AddressType()
                };
                cboAddressTypes.SelectedIndex = 0;
                cboCountries.SelectedIndex = 0;
               
            }
            else 
            {                
                txtStreet.Text = _customerAddress.Address?.Street;
                txtBuildingNumber.Text = _customerAddress.Address?.BuildingNumber;
                txtBetweenStreet1.Text = _customerAddress.Address?.BetweenStreet1;
                txtBetweenStreet2.Text = _customerAddress.Address?.BetweenStreet2;
                txtFloor.Text = _customerAddress.Address?.FloorNumber?.ToString();
                txtApart.Text = _customerAddress.Address?.ApartmentUnit;
                txtPostalCode.Text = _customerAddress.Address?.PostalCode;

                if (_customerAddress.AddressType?.AddressTypeId > 0)
                {
                    cboAddressTypes.SelectedValue = _customerAddress.AddressType.AddressTypeId;
                }
                else
                {
                    cboAddressTypes.SelectedIndex = 0;
                }

                if (_customerAddress.Address?.Country?.CountryId > 0)
                {
                    cboCountries.SelectedValue = _customerAddress.Address.Country.CountryId;
                    cboStates.SelectedValue = _customerAddress.Address.StateProvince.StateProvinceId;
                    cboCities.SelectedValue = _customerAddress.Address.City.CityId;
                }
                else
                {
                    cboCountries.SelectedIndex = 0;
                }
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (_customerAddress == null)
                {
                    return;
                }
                if (_customerAddress.Address == null)
                {
                    _customerAddress.Address = new Address(); 
                }

               
                _customerAddress.Address.Street = txtStreet.Text;
                _customerAddress.Address.BuildingNumber = txtBuildingNumber.Text;
                _customerAddress.Address.BetweenStreet1 = txtBetweenStreet1.Text;
                _customerAddress.Address.BetweenStreet2 = txtBetweenStreet2.Text;
                _customerAddress.Address.FloorNumber = string.IsNullOrEmpty(txtFloor.Text) ? null : int.Parse(txtFloor.Text);
                _customerAddress.Address.ApartmentUnit = txtApart.Text;
                _customerAddress.Address.PostalCode = txtPostalCode.Text;

                
                _customerAddress.Address.Country = (Country)cboCountries.SelectedItem;
                _customerAddress.Address.CountryId = _customerAddress.Address.Country.CountryId; 

                _customerAddress.Address.StateProvince = (StateProvince)cboStates.SelectedItem;
                _customerAddress.Address.StateProvinceId = _customerAddress.Address.StateProvince.StateProvinceId; 

                _customerAddress.Address.City = (City)cboCities.SelectedItem;
                _customerAddress.Address.CityId = _customerAddress.Address.City.CityId; 

                AddressType selectedAddressType = (AddressType)cboAddressTypes.SelectedItem;
                _customerAddress.AddressType = selectedAddressType;
                _customerAddress.AddressTypeId = selectedAddressType.AddressTypeId;

                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void cboCountries_SelectedIndexChanged(object sender, EventArgs e)
        {
            country = cboCountries.SelectedIndex > 0 ?
                (Country?)cboCountries.SelectedItem : null;
            if (country is not null)
            {
                CombosHelper.LoadStatesComboBox(ref cboStates, country, _serviceProvider);
            }
            else
            {
                cboStates.DataSource = null;
            }
        }

        private void cboStatesProvinces_SelectedIndexChanged(object sender, EventArgs e)
        {
            stateProvince = cboStates.SelectedIndex > 0 ?
                (StateProvince?)cboStates.SelectedItem : null;
            if (stateProvince is not null)
            {
                CombosHelper.LoadCitiesComboBox(ref cboCities, country, stateProvince, _serviceProvider);
            }
            else
            {
                cboCities.DataSource = null;
            }
        }
        private void cboCities_SelectedIndexChanged(object sender, EventArgs e)
        {
            city = cboCities.SelectedIndex > 0 ?
                (City?)cboCities.SelectedItem : null;
        }

        private void cboAddressTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            addressType = cboAddressTypes.SelectedIndex > 0 ?
                (AddressType?)cboAddressTypes.SelectedItem : null;
        }

        public CustomerAddress? GetCustomerAddress()
        {
            return _customerAddress;
        }

        internal void SetCustomerAddress(CustomerAddress customerAddress)
        {
            _customerAddress = customerAddress;
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();

            if (cboAddressTypes.SelectedIndex <= 0)
            {
                valido = false;
                errorProvider1.SetError(cboAddressTypes, "You must select an address type.");
            }

            if (cboCountries.SelectedIndex <= 0)
            {
                valido = false;
                errorProvider1.SetError(cboCountries, "You must select a country.");
            }

            if (cboStates.SelectedIndex <= 0)
            {
                valido = false;
                errorProvider1.SetError(cboStates, "You must select a state.");
            }

            if (cboCities.SelectedIndex <= 0)
            {
                valido = false;
                errorProvider1.SetError(cboCities, "You must select a city.");
            }

            string postalCode = txtPostalCode.Text.Trim();
            if (string.IsNullOrEmpty(postalCode))
            {
                valido = false;
                errorProvider1.SetError(txtPostalCode, "Postal Code is required.");
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(postalCode, @"^[a-zA-Z0-9\s-]+$"))
            {
                valido = false;
                errorProvider1.SetError(txtPostalCode, "Postal Code contains invalid characters. Only letters, numbers, spaces, and hyphens are allowed.");
            }
            else if (postalCode.Length > 20)
            {
                valido = false;
                errorProvider1.SetError(txtPostalCode, "Postal Code cannot exceed 20 characters.");
            }

            string street = txtStreet.Text.Trim();
            if (string.IsNullOrEmpty(street))
            {
                valido = false;
                errorProvider1.SetError(txtStreet, "Street name is required.");
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(street, @"^[\p{L}0-9\s.,-]+$"))
            {
                valido = false;
                errorProvider1.SetError(txtStreet, "Street name contains invalid characters. Only letters, numbers, spaces, periods, commas, and hyphens are allowed.");
            }
            else if (street.Length > 100)
            {
                valido = false;
                errorProvider1.SetError(txtStreet, "Street name cannot exceed 100 characters.");
            }

            string buildingNumber = txtBuildingNumber.Text.Trim();
            if (string.IsNullOrEmpty(buildingNumber))
            {
                valido = false;
                errorProvider1.SetError(txtBuildingNumber, "Building Number is required.");
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(buildingNumber, @"^[a-zA-Z0-9]+$"))
            {
                valido = false;
                errorProvider1.SetError(txtBuildingNumber, "Building Number contains invalid characters. Only letters and numbers are allowed.");
            }
            else if (buildingNumber.Length > 10)
            {
                valido = false;
                errorProvider1.SetError(txtBuildingNumber, "Building Number cannot exceed 10 characters.");
            }

            string betweenStreet1 = txtBetweenStreet1.Text.Trim();
            if (!string.IsNullOrEmpty(betweenStreet1))
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(betweenStreet1, @"^[\p{L}0-9\s.,-]+$"))
                {
                    valido = false;
                    errorProvider1.SetError(txtBetweenStreet1, "Between Street contains invalid characters. Only letters, numbers, spaces, periods, commas, and hyphens are allowed.");
                }
                else if (betweenStreet1.Length > 100)
                {
                    valido = false;
                    errorProvider1.SetError(txtBetweenStreet1, "Between Street cannot exceed 100 characters.");
                }
            }

            string betweenStreet2 = txtBetweenStreet2.Text.Trim();
            if (!string.IsNullOrEmpty(betweenStreet2))
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(betweenStreet2, @"^[\p{L}0-9\s.,-]+$"))
                {
                    valido = false;
                    errorProvider1.SetError(txtBetweenStreet2, "Between Street contains invalid characters. Only letters, numbers, spaces, periods, commas, and hyphens are allowed.");
                }
                else if (betweenStreet2.Length > 100)
                {
                    valido = false;
                    errorProvider1.SetError(txtBetweenStreet2, "Between Street cannot exceed 100 characters.");
                }
            }

            string floor = txtFloor.Text.Trim();
            if (!string.IsNullOrEmpty(floor))
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(floor, @"^[a-zA-Z0-9]+$"))
                {
                    valido = false;
                    errorProvider1.SetError(txtFloor, "Floor contains invalid characters. Only letters and numbers are allowed.");
                }
                else if (floor.Length > 10)
                {
                    valido = false;
                    errorProvider1.SetError(txtFloor, "Floor cannot exceed 10 characters.");
                }
            }

            string apartment = txtApart.Text.Trim();
            if (!string.IsNullOrEmpty(apartment))
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(apartment, @"^[a-zA-Z0-9-]+$"))
                {
                    valido = false;
                    errorProvider1.SetError(txtApart, "Apartment contains invalid characters. Only letters, numbers, and hyphens are allowed.");
                }
                else if (apartment.Length > 10)
                {
                    valido = false;
                    errorProvider1.SetError(txtApart, "Apartment cannot exceed 10 characters.");
                }
            }

            return valido;
        }
    }
}
