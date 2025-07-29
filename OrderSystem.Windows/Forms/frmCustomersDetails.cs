using Entities.Dtos;
using Windows.Helpers;

namespace Windows.Forms
{
    public partial class frmCustomersDetails : Form
    {
        private CustomerDetailsDto? customerDetailsDto;
        public frmCustomersDetails()
        {
            InitializeComponent();
        }

        internal void SetCustomer(CustomerDetailsDto? customerDetailsDto)
        {
            this.customerDetailsDto = customerDetailsDto;
        }
        private void frmCustomersDetails_Load(object sender, EventArgs e)
        {
            ShowCustomers(customerDetailsDto);
            ShowPhones(customerDetailsDto!.Phones);
            ShowAddress(customerDetailsDto!.Addresses);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void ShowAddress(List<AddressListDto> addresses)
        {
            GridHelper.LimpiarGrilla(dgv);
            if (addresses is not null)
            {
                foreach (var d in addresses)
                {
                    var r = GridHelper.ConstruirFila(dgv);
                    GridHelper.SetearFila(r, d);
                    GridHelper.AgregarFila(r, dgv);
                }

            }

        }

        private void ShowPhones(List<PhoneListDto> phones)
        {
            GridHelper.LimpiarGrilla(dgvPhones);
            if (phones is not null)
            {
                foreach (var t in phones)
                {
                    var r = GridHelper.ConstruirFila(dgvPhones);
                    GridHelper.SetearFila(r, t);
                    GridHelper.AgregarFila(r, dgvPhones);
                }

            }

        }

        private void ShowCustomers(CustomerDetailsDto? customerDetailsDto)
        {
            txtFirstName.Text = customerDetailsDto.FirstName;
            txtLastName.Text = customerDetailsDto.LastName;
            txtDocumentNum.Text = customerDetailsDto.DocumentNumber.ToString();
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            Close();
        }
    }
}
