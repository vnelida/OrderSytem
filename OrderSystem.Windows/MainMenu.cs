using Windows.Forms;

namespace OrderSystem.Windows
{
    public partial class MainMenu : Form
    {
        private readonly IServiceProvider? _serviceProvider;
        public MainMenu(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
        }

        private void btnCategories_Click(object sender, EventArgs e)
        {
            frmCategories frm = new frmCategories(_serviceProvider);
            frm.ShowDialog();
        }

        private void btnEmployees_Click(object sender, EventArgs e)
        {
            frmEmployees frm = new frmEmployees(_serviceProvider);
            frm.ShowDialog();
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            frmProducts frm = new frmProducts(_serviceProvider);
            frm.ShowDialog();
        }

        private void btnCombos_Click(object sender, EventArgs e)
        {
            frmCombos frm = new frmCombos(_serviceProvider);
            frm.ShowDialog();
        }

        private void btnExist_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnCustomers_Click(object sender, EventArgs e)
        {
            frmCustomers frm = new frmCustomers(_serviceProvider);
            frm.ShowDialog();
        }

        private void btnOrders_Click(object sender, EventArgs e)
        {
            frmSales frm = new frmSales(_serviceProvider);
            frm.ShowDialog();
        }
    }
}
