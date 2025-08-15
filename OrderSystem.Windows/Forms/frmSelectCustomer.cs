using Entities.Entities;
using Windows.Helpers;

namespace Windows.Forms
{
    public partial class frmSelectCustomer : Form
    {
        public frmSelectCustomer(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
        }
        private readonly IServiceProvider? _serviceProvider;
        private Customer? customer;


        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            CombosHelper.LoadCustomersComboBox(ref cboCustomers, _serviceProvider);
        }

        public Customer? GetCustomer()
        {
            return customer;
        }

        private void cboCustomers_SelectedIndexChanged(object sender, EventArgs e)
        {
            customer = (Customer?)cboCustomers.SelectedItem;
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
