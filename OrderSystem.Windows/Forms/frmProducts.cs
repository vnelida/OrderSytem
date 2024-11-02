using Entities.Dtos;
using Entities.Entities;
using Entities.Enums;
using Microsoft.Extensions.DependencyInjection;
using Services.Interfaces;
using Windows.Helpers;

namespace Windows.Forms
{
    public partial class frmProducts : Form
    {
        private readonly IServiceProvider? _serviceProvider;
        private readonly IProductsService? _service;
        private List<ProductDto>? list;

        private int currentPage = 1;
        private int pageSize = 4;
        private int totalPages = 0;
        private int totalRecords = 0;
        private Order order = Order.ProductZA;
        private FiltroContexto filtroContexto = FiltroContexto.Category;
        private Category? categoryFilter = null;
        private bool filterOn = false;
        private Func<ProductDto, bool>? filter = null;

        public frmProducts(IServiceProvider? serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            _service = serviceProvider?.GetService<IProductsService>() ?? throw new ApplicationException("Unloaded dependencies"); ;
        }

        private void frmProducts_Load(object sender, EventArgs e)
        {
            try
            {
                totalRecords = _service?.GetCount() ?? 0;
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
            list = _service!.GetList(currentPage, pageSize, order, categoryFilter);
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
                Product product = frm.GetTipo();

                if (!_service.Exist(product))
                {
                    _service.Save(product);
                    totalRecords = _service?.GetCount() ?? 0;
                    totalPages = (int)Math.Ceiling((decimal)totalRecords / pageSize);
                    currentPage = _service?.GetPageByRecord(product.ProductName, pageSize) ?? 0;
                    LoadData();
                    int row = GridHelper.ObtenerRowIndex(dgv, product.ProductId);
                    GridHelper.MarcarRow(dgv, row);
                    MessageBox.Show("The record has been successfully added",
                                    "Information",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"The record '{product.ProductName} already exists and cannot be added", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
                    var productDto = (ProductDto)r.Tag;
                    var product = _service?.GetProductById(productDto.ProductId);
                    frmProductsAE frm = new frmProductsAE(_serviceProvider) { Text = "Update product details" };
                    frm.SetTipo(product);
                    DialogResult dr = frm.ShowDialog(this);
                    if (dr == DialogResult.Cancel)
                    {
                        return;
                    }
                    product = frm.GetTipo();
                    if (!_service.Exist(product))
                    {
                        _service.Save(product);
                        currentPage = _service?.GetPageByRecord(product.ProductName, pageSize) ?? 0;
                        LoadData();
                        int row = GridHelper.ObtenerRowIndex(dgv, product.ProductId);
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
            var productDto = (ProductDto)r.Tag;

            DialogResult dr = MessageBox.Show($"Are you sure you want to delete the product '{productDto.ProductName}'?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (dr == DialogResult.No)
            {
                return;
            }
            if (!_service.IsRelated(productDto.ProductId))
            {
                _service.Delete(productDto.ProductId);
                totalRecords = _service?.GetCount() ?? 0;
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
            frmFilters frm = new frmFilters(_serviceProvider, filtroContexto) { Text = "Select category to filter" };
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel) return;
            categoryFilter = frm.GetCategory();
            if (categoryFilter is null) return;

            list = _service!.GetList(currentPage, pageSize, order, categoryFilter);
            totalRecords = _service!?.GetCount(categoryFilter) ?? 0;
            if (totalRecords > 0)
            {
                totalPages = (int)Math.Ceiling((decimal)totalRecords / pageSize);
                LoadData();
                filterOn = true;
                btnFilter.Enabled = false;
            }
            else
            {

                MessageBox.Show("No records found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                filter = null;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            currentPage = 1;
            categoryFilter = null;
            totalRecords = _service!?.GetCount() ?? 0;
            totalPages = (int)Math.Ceiling((decimal)totalRecords / pageSize);
            LoadData();
            filterOn = false;
            btnFilter.Enabled = true;

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

        private void categoryAZToolStripMenuItem_Click(object sender, EventArgs e)
        {
            order = Order.CategoryAZ;
            LoadData();
        }

        private void categoryZAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            order = Order.CategoryZA;
            LoadData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
