using Entities.Dtos;
using Microsoft.Extensions.DependencyInjection;
using Services.Interfaces;
using Windows.Helpers;

namespace Windows.Forms
{
    public partial class frmPaymentReport : Form
    {
        private readonly IServiceProvider? _serviceProvider;
        private readonly ISalesService? _service;
        public DateTime firstDate;
        public DateTime secdDate;
        public frmPaymentReport(IServiceProvider? serviceProvider)
        {
            InitializeComponent();
            _service = serviceProvider?.GetService<ISalesService>()?? throw new ApplicationException("Dependencies not loaded");
        }

        internal void SetDate(DateTime firstDate, DateTime secdDate)
        {
            this.firstDate = firstDate;
            this.secdDate = secdDate;
        }

        private void frmPaymentReport_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {

                var list = _service!.GetPaymentReport(firstDate, secdDate);
                MostrarDatosEnGrilla(list);
                CalcularTotales();

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void MostrarDatosEnGrilla(List<PaymentReportDto> list)
        {
            GridHelper.LimpiarGrilla(dgv);
            if (list is not null)
            {
                foreach (var item in list)
                {
                    var r = GridHelper.ConstruirFila(dgv);
                    GridHelper.SetearFila(r, item);
                    GridHelper.AgregarFila(r, dgv);
                }

            }
        }
        private void CalcularTotales()
        {
            if (dgv.Rows.Count > 0)
            {
                decimal cashTotal = 0;
                decimal cardTotal = 0;
                decimal couponTotal = 0;
                decimal transferTotal = 0;

                foreach (DataGridViewRow row in dgv.Rows)
                {
                    cashTotal += Convert.ToDecimal(row.Cells["colCash"].Value);
                    cardTotal += Convert.ToDecimal(row.Cells["colCard"].Value);
                    couponTotal += Convert.ToDecimal(row.Cells["colCoupon"].Value);
                    transferTotal += Convert.ToDecimal(row.Cells["colTransfer"].Value);
                }

                txtCash.Text = cashTotal.ToString("C"); 
                txtCard.Text = cardTotal.ToString("C");
                txtCoupon.Text = couponTotal.ToString("C");
                txtTransfer.Text = transferTotal.ToString("C");
            }
        }
    }
}
