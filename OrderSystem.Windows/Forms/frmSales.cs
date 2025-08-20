using Entities.Dtos;
using Entities.Entities;
using Entities.Enums;
using Microsoft.Extensions.DependencyInjection;
using Services.Interfaces;
using Windows.Helpers;

namespace Windows.Forms
{
    public partial class frmSales : Form
    {
        private List<SalesListDto> list = null!;
        private readonly ISalesService? _service;
        private readonly IServiceProvider? _serviceProvider;

        private int currentPage = 1;
        private int totalPages = 0;
        private int pageSize = 20;
        private int totalRecords = 0;

        private OrderStatuses selectedOrderStatus = OrderStatuses.None;
        private OrderTypes selectedOrderType = OrderTypes.None;
        private Order? selectedOrder = Order.None;

        private Func<SalesListDto, bool>? filter = null;
        public frmSales(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            _service = serviceProvider?.GetService<ISalesService>() ?? throw new ApplicationException("Dependencies not loaded");
        }


        private void RecargarGrilla()
        {
            try
            {
                totalRecords = _service!.GetCountt(selectedOrderType, selectedOrderStatus);
                totalPages = (int)Math.Ceiling((decimal)totalRecords / pageSize);
                LoadData(filter);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void LoadData(Func<SalesListDto, bool>? filter = null)
        {
            try
            {

                list = _service!.GetListt(currentPage, pageSize, selectedOrderType, selectedOrderStatus, selectedOrder);
                if (list.Count > 0)
                {
                    GridHelper.MostrarDatosEnGrilla<SalesListDto>(list, dgv);
                    if (cboPages.Items.Count != totalPages)
                    {
                        CombosHelper.CargarComboPaginas(ref cboPages, totalPages);
                    }
                    txtPageCount.Text = totalPages.ToString();
                    cboPages.SelectedIndexChanged -= cboPages_SelectedIndexChanged;
                    cboPages.SelectedIndex = currentPage == 1 ? 0 : currentPage - 1;
                    cboPages.SelectedIndexChanged += cboPages_SelectedIndexChanged;

                }
                else
                {
                    MessageBox.Show("No records were found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    currentPage = 1;
                    filter = null;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void btnFirst_Click(object sender, EventArgs e)
        {
            currentPage = 1;
            LoadData(filter);
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                LoadData(filter);
            }
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            currentPage = totalPages;
            LoadData(filter);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (currentPage < totalPages)
            {
                currentPage++;
                LoadData(filter);
            }
        }

        private void cboPages_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentPage = int.Parse(cboPages.Text);
            LoadData(filter);
        }
        private void frmSales_Load(object sender, EventArgs e)
        {
            RecargarGrilla();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            frmSalesAE frm = new frmSalesAE(_serviceProvider) { Text = "New Order" };
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel) return;
            try
            {
                Sale? sale = frm.GetSale();
                if (sale is null) return;
                _service?.Save(sale);
                totalRecords = _service!.GetCount(null);
                totalPages = (int)Math.Ceiling((decimal)totalRecords / pageSize);
                currentPage = totalPages;
                LoadData();
                int row = GridHelper.ObtenerRowIndex(dgv, sale.SaleId);
                GridHelper.MarcarRow(dgv, row);

                MessageBox.Show("Combo meal added",
                    "Notification",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count == 0) return;
            var r = dgv.SelectedRows[0];
            SalesListDto saleDto = (SalesListDto)r.Tag!;
            Sale? sale = _service!.GetSaleById(saleDto.SaleId);
            frmSaleDetails frm = new frmSaleDetails();
            frm.SetSale(sale);
            frm.ShowDialog(this);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count == 0) return;

            var r = dgv.SelectedRows[0];
            int saleId = (int)r.Cells["SaleId"].Value;

            string currentStatus = r.Cells["colStatus"].Value.ToString();

            if (currentStatus == "Cancelled")
            {
                MessageBox.Show("This order has already been canceled and cannot be canceled again.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult dr = MessageBox.Show("Are you sure you want to cancel this order?", "Confirm Cancellation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                try
                {
                    _service.CancelSale(saleId);

                    MessageBox.Show("Order canceled successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void totalDesc_Click(object sender, EventArgs e)
        {
            selectedOrder = Order.TotalDesc;
            LoadData();
        }

        private void totalAsc_Click(object sender, EventArgs e)
        {
            selectedOrder = Order.Total;
            RecargarGrilla();
        }

        private void dateAcs_Click(object sender, EventArgs e)
        {
            selectedOrder = Order.SaleDate;
            RecargarGrilla();
        }

        private void dateDesc_Click(object sender, EventArgs e)
        {
            selectedOrder = Order.SaleDateDesc;
            RecargarGrilla();
        }

        private void customerACSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selectedOrder = Order.CustomerName;
            RecargarGrilla();
        }

        private void customerDESCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selectedOrder = Order.CustomerNameDesc;
            RecargarGrilla();
        }

        private void filterCompleted_Click(object sender, EventArgs e)
        {
            selectedOrderStatus = OrderStatuses.Completed;
            RecargarGrilla();
        }

        private void filterPending_Click(object sender, EventArgs e)
        {
            selectedOrderStatus = OrderStatuses.Pending;
            RecargarGrilla();
        }

        private void filterPreparing_Click(object sender, EventArgs e)
        {
            selectedOrderStatus = OrderStatuses.Preparing;
            RecargarGrilla();
        }

        private void filterSent_Click(object sender, EventArgs e)
        {
            selectedOrderStatus = OrderStatuses.Sent;
            RecargarGrilla();
        }

        private void filterCancelled_Click(object sender, EventArgs e)
        {
            selectedOrderStatus = OrderStatuses.Cancelled;
            RecargarGrilla();
        }

        private void InStoreFilter_Click(object sender, EventArgs e)
        {
            selectedOrderType = OrderTypes.InStore;
            RecargarGrilla();
        }

        private void TakeAwayFilter_Click(object sender, EventArgs e)
        {
            selectedOrderType = OrderTypes.TakeAway;
            RecargarGrilla();
        }

        private void DeliveryFilter_Click(object sender, EventArgs e)
        {
            selectedOrderType = OrderTypes.Delivery;
            RecargarGrilla();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            selectedOrder = null;
            selectedOrderStatus = OrderStatuses.None;
            selectedOrderType = OrderTypes.None;
            currentPage = 1;
            RecargarGrilla();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count == 0) return;

            var r = dgv.SelectedRows[0];
            SalesListDto saleDto = (SalesListDto)r.Tag!;
            int saleId = saleDto.SaleId;

            string currentStatus = r.Cells["colStatus"].Value.ToString();

            if (currentStatus != "Pending" && currentStatus != "Preparing")
            {
                MessageBox.Show("The selected order cannot be updated.'.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult dr = MessageBox.Show("Update to Completed?", "Confirm Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                try
                {
                    _service.UpdateOrderStatus(saleId, OrderStatuses.Completed);

                    MessageBox.Show("Update completed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    RecargarGrilla();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            frmFilterDateReport frm = new frmFilterDateReport(_serviceProvider);
            frm.ShowDialog();
        }
    }
}
