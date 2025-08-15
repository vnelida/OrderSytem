using Entities.Dtos;
using Entities.Entities;
using Entities.Enums;
using Microsoft.Extensions.DependencyInjection;
using Services.Interfaces;
using Windows.Helpers;

namespace Windows.Forms
{
    public partial class frmCombos : Form
    {
        private readonly IServiceProvider? _serviceProvider;
        private readonly IItemsService? _service;
        private List<ItemListDto>? list;

        private int currentPage = 1;
        private int pageSize = 20;
        private int totalPages = 0;
        private int totalRecords = 0;
        private Order order = Order.ProductZA;
        private Product? productFilter = null;
        private bool filterOn = false;
        private Func<ItemListDto, bool>? filter = null;
        private DateTime? currentDate = null;
        private Category? categoryFilter = null;

        private ItemType itemType = ItemType.Combo;
        public frmCombos(IServiceProvider? serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            _service = serviceProvider?.GetService<IItemsService>() ?? throw new ApplicationException("Unloaded dependencies");
        }
        private void frmCombos_Load(object sender, EventArgs e)
        {
            try
            {
                totalRecords = _service?.GetCount(itemType) ?? 0;
                totalPages = (int)Math.Ceiling((decimal)totalRecords / pageSize);
                LoadData();
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void LoadData()
        {
            list = _service!.GetList(currentPage, pageSize, itemType, order, categoryFilter, currentDate);
            MostrarDatosEnGrilla();
            if (cboPages.Items.Count != totalPages)
            {
                CombosHelper.CargarComboPaginas(ref cboPages, totalPages);
            }
            txtPageCount.Text = totalPages.ToString();
            cboPages.SelectedIndexChanged -= cboPages_SelectedIndexChanged;
            cboPages.SelectedIndex = currentPage == 1 ? 0 : currentPage - 1;
            cboPages.SelectedIndexChanged += cboPages_SelectedIndexChanged;
        }

        private void MostrarDatosEnGrilla()
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
        private void btnNew_Click(object sender, EventArgs e)
        {
            frmCombosAE frm = new frmCombosAE(_serviceProvider) { Text = "New combo" };
            DialogResult dr = frm.ShowDialog(this);

            if (dr == DialogResult.Cancel)
            {
                return;
            }
            try
            {
                Combo? combo = frm.GetTipo();

                if (!_service.Exist(combo))
                {
                    _service.Save(combo);
                    totalRecords = _service?.GetCount(itemType) ?? 0;
                    totalPages = (int)Math.Ceiling((decimal)totalRecords / pageSize);
                    currentPage = _service?.GetPageByRecord(itemType, combo.Name, pageSize) ?? 0;
                    LoadData();
                    int row = GridHelper.ObtenerRowIndex(dgv, combo.ItemId);
                    GridHelper.MarcarRow(dgv, row);
                    MessageBox.Show("The record has been successfully added", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"The record '{combo.Name} already exists and cannot be added", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count == 0)
            {
                return;
            }
            var r = dgv.SelectedRows[0];
            if (r.Tag == null) return;
            ComboListDto comboDto = (ComboListDto)r.Tag;
            Item? combo = _service!.GetItemById(itemType, comboDto.ItemId);
            if (combo is null) return;
            frmCombosAE frm = new frmCombosAE(_serviceProvider);
            frm.SetTipo((Combo)combo!);
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel) return;
            combo = frm.GetTipo();

            if (combo == null) return;
            try
            {

                if (!_service!.Exist(combo))
                {
                    _service!.Save(combo);


                    currentPage = _service!.GetPageByRecord(itemType, combo.Name, pageSize);
                    LoadData();
                    int row = GridHelper.ObtenerRowIndex(dgv, combo.ItemId);
                    GridHelper.MarcarRow(dgv, row);
                    MessageBox.Show("Combo details updated successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("Edit denied. An combo with this information already exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count == 0)
            {
                return;
            }
            var r = dgv.SelectedRows[0];
            if (r.Tag == null) { return; }
            var productDto = (ComboListDto)r.Tag;

            DialogResult dr = MessageBox.Show($"Are you sure you want to delete the product '{productDto.Name}'?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (dr == DialogResult.No)
            {
                return;
            }
            if (!_service.IsRelated(itemType, productDto.ItemId))
            {
                _service.Delete(itemType, productDto.ItemId);
                totalRecords = _service?.GetCount(itemType) ?? 0;
                totalPages = (int)Math.Ceiling((decimal)totalRecords / pageSize);
                if (currentPage > totalPages) currentPage = totalPages;
                LoadData();
                MessageBox.Show("Product deleted successfully", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Unable to delete: this product is related to another entry", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            currentPage = 1;
            LoadData();
        }

        private void btnPreviousr_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                LoadData();
            }
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            currentPage = totalPages;
            LoadData();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (currentPage < totalPages)
            {
                currentPage++;
                LoadData();
            }
        }

        private void cboPages_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentPage = int.Parse(cboPages.Text);
            LoadData();
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            currentDate = DateTime.Today;
            LoadData();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            currentPage = 1;
            productFilter = null;
            totalRecords = _service!?.GetCount(itemType) ?? 0;
            totalPages = (int)Math.Ceiling((decimal)totalRecords / pageSize);
            order = Order.None;
            currentDate = null;
            LoadData();
            filterOn = false;
            btnFilter.Enabled = true;

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void salePrice_Click(object sender, EventArgs e)
        {
            order = Order.SalePrice;
            LoadData();
        }

        private void priceDesc_Click(object sender, EventArgs e)
        {
            order = Order.SalePriceDesc;
            LoadData();
        }

        private void comboNameDesc_Click(object sender, EventArgs e)
        {
            order = Order.NameZA;
            LoadData();
        }
    }
}
