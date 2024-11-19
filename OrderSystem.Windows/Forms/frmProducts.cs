using Entities.Dtos;
using Entities.Entities;
using Entities.Enums;
using Microsoft.Extensions.DependencyInjection;
using Services.Interfaces;
using System.Globalization;
using Windows.Helpers;

namespace Windows.Forms
{
    public partial class frmProducts : Form
    {
        private readonly IServiceProvider? _serviceProvider;
        private readonly IItemsService? _service;
        private List<ItemListDto>? list;
        private Func<ItemListDto, bool>? filter = null;

        private int currentPage = 1;
        private int pageSize = 10;
        private int totalPages = 0;
        private int totalRecords = 0;
        private Order order = Order.ProductAZ;
        private Category? categoryFilter = null;
        private bool filterOn = false;

        private ItemType itemType = ItemType.Product;


        public frmProducts(IServiceProvider? serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            _service = serviceProvider?.GetService<IItemsService>() ?? throw new ApplicationException("Unloaded dependencies"); ;
        }

        private void frmProducts_Load(object sender, EventArgs e)
        {
            try
            {
                CombosHelper.CargarTSBComboCategory(_serviceProvider, ref btnFilter);
                LoadData();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void LoadData()
        {
            totalRecords = _service?.GetCount(itemType, categoryFilter) ?? 0;
            if (totalRecords < 1)
            {
                MessageBox.Show("No products found in this category", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                categoryFilter = null;
                totalRecords = _service?.GetCount(itemType, categoryFilter) ?? 0;
            }
            totalPages = (int)Math.Ceiling((decimal)totalRecords / pageSize);
            if (currentPage > totalPages)
            {
                currentPage = 1;
            }
            list = _service!.GetList(currentPage, pageSize, itemType, order, categoryFilter);
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
            frmProductsAE frm = new frmProductsAE(_serviceProvider) { Text = "New employee" };
            DialogResult dr = frm.ShowDialog(this);

            if (dr == DialogResult.Cancel)
            {
                return;
            }
            try
            {
                Product? product = frm.GetTipo();

                if (!_service.Exist(product))
                {
                    _service.Save(product);
                    totalRecords = _service?.GetCount(itemType) ?? 0;
                    totalPages = (int)Math.Ceiling((decimal)totalRecords / pageSize);
                    currentPage = _service?.GetPageByRecord(itemType, product.Name, pageSize) ?? 0;
                    LoadData();
                    int row = GridHelper.ObtenerRowIndex(dgv, product.ItemId);
                    GridHelper.MarcarRow(dgv, row);
                    MessageBox.Show("The record has been successfully added", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"The record '{product.Name} already exists and cannot be added", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
            try
            {
                var r = dgv.SelectedRows[0];

                if (r.Tag != null)
                {
                    var productDto = (ProductListDto)r.Tag;
                    var product = _service?.GetItemById(itemType, productDto.ItemId);
                    frmProductsAE frm = new frmProductsAE(_serviceProvider) { Text = "Update product details" };
                    frm.SetTipo((Product)product);
                    DialogResult dr = frm.ShowDialog(this);
                    if (dr == DialogResult.Cancel)
                    {
                        return;
                    }
                    product = frm.GetTipo();
                    if (!_service.Exist(product))
                    {
                        _service.Save(product);
                        currentPage = _service?.GetPageByRecord(itemType, product.Name, pageSize) ?? 0;
                        LoadData();
                        int row = GridHelper.ObtenerRowIndex(dgv, product.ItemId);
                        GridHelper.MarcarRow(dgv, row);
                        MessageBox.Show("Product details updated successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Edit denied. An product with this information already exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception)
            {
                throw;
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
            var productDto = (ProductListDto)r.Tag;

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


        private void btnRefresh_Click(object sender, EventArgs e)
        {
            currentPage = 1;
            categoryFilter = null;
            totalRecords = _service!?.GetCount(itemType) ?? 0;
            totalPages = (int)Math.Ceiling((decimal)totalRecords / pageSize);
            LoadData();
            filterOn = false;
            btnFilter.SelectedIndex = 0;

        }

        private void productAZToolStripMenuItem_Click(object sender, EventArgs e)
        {
            order = Order.ProductAZ;
            LoadData();
        }

        private void productZAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            order = Order.ProductZA;
            LoadData();
        }

        private void salePriceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            order = Order.SalePrice;
            LoadData();
        }

        private void salePriceDescToolStripMenuItem_Click(object sender, EventArgs e)
        {
            order = Order.SalePriceDesc;
            LoadData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (btnFilter.SelectedIndex > 0)
            {
                var _serviceProduct = _serviceProvider.GetService<ICategoriesService>();
                categoryFilter = _serviceProduct?.GetCategoryByName(btnFilter.Text);
                LoadData();
            }
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void btnFilter_Click(object sender, EventArgs e)
        {

        }
    }
}
