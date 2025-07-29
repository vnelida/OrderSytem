using Entities.Entities;
using Windows.Helpers;

namespace Windows.Forms
{
    public partial class frmSaleDetails : Form
    {
        private Sale? sale;
        public frmSaleDetails()
        {
            InitializeComponent();
        }
        public void SetSale(Sale? sale)
        {
            this.sale = sale;
        }
        private void frmSaleDetails_Load(object sender, EventArgs e)
        {
            ShowSale();
            GridHelper.MostrarDatosEnGrilla<SaleDetail>(sale!.Details, dgv);
            dgv.ClearSelection();
        }

        private void ShowSale()
        {
            txtCustomer.Text = $"{sale.Customer!.FirstName} {sale.Customer.LastName}";
            txtDate.Text = $"{sale.SaleDate.ToShortDateString()}";
            txtSaleNum.Text = $"{sale.SaleId}";
            txtTotalAmount.Text = $"{sale.TotalAmount}";
            txtStatus.Text = $"{sale.OrderStatus.StatusName}";
            txtType.Text = $"{sale.OrderType.TypeName}";

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
