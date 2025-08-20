using Entities.Entities;
using Entities.Enums;
using Microsoft.Extensions.DependencyInjection;
using Services.Interfaces;
using Windows.Helpers;

namespace Windows.Forms
{
    public partial class frmCategories : Form
    {
        private readonly ICategoriesService? _service;
        private List<Category>? list;
        int totalRecords = 0;
        int currentPage = 1;
        int totalPages = 0;
        int pageSize = 20;
        private Order order = Order.CategoryAZ;

        public frmCategories(IServiceProvider? serviceProvider)
        {
            InitializeComponent();
            _service = serviceProvider?.GetService<ICategoriesService>()
                ?? throw new ApplicationException("Unloaded dependencies");
        }

        private void frmCategories_Load(object sender, EventArgs e)
        {
            try
            {
                LoadData();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void LoadData()
        {
            totalRecords = _service!.GetCount();
            totalPages = (int)Math.Ceiling((decimal)totalRecords / pageSize);
            list = _service!.GetList(currentPage, pageSize, order);
            MostrarDatosEnGrilla();
            if (cboPages.Items.Count != totalPages)
            {
                CombosHelper.CargarComboPaginas(ref cboPages, totalPages);
            }
            txtPageCount.Text = totalPages.ToString();
            cboPages.SelectedIndexChanged -= cboPages_SelectedIndexChanged;
            if (totalPages > 0)
            {
                cboPages.SelectedIndex = currentPage - 1;
            }
            cboPages.SelectedIndexChanged += cboPages_SelectedIndexChanged;
        }

        private void MostrarDatosEnGrilla()
        {
            GridHelper.LimpiarGrilla(dgv);
            if (list is not null)
            {
                foreach (var category in list)
                {
                    var r = GridHelper.ConstruirFila(dgv);
                    GridHelper.SetearFila(r, category);
                    GridHelper.AgregarFila(r, dgv);
                }

            }
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            frmCategoriesAE frm = new frmCategoriesAE() { Text = "New category" };
            DialogResult dr = frm.ShowDialog(this);

            if (dr == DialogResult.Cancel)
            {
                return;
            }
            try
            {
                Category category = frm.GetTipo();

                if (!_service.Exist(category))
                {
                    _service.Save(category);
                    var r = GridHelper.ConstruirFila(dgv);
                    GridHelper.SetearFila(r, category);
                    GridHelper.AgregarFila(r, dgv);

                    int row = GridHelper.ObtenerRowIndex(dgv, category.CategoryId);
                    GridHelper.MarcarRow(dgv, row);
                    MessageBox.Show("The record has been successfully added",
                                    "Information",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"The record '{category.CategoryName}' already exists and cannot be added", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
                Category category;
                if (r.Tag != null)
                {
                    category = (Category)r.Tag;
                    frmCategoriesAE frm = new frmCategoriesAE() { Text = "Edit category" };
                    frm.SetTipo(category);
                    DialogResult dr = frm.ShowDialog(this);
                    if (dr == DialogResult.Cancel)
                    {
                        return;
                    }
                    category = frm.GetTipo();
                    if (!_service.Exist(category))
                    {
                        _service.Save(category);
                        GridHelper.SetearFila(r, category);
                        MessageBox.Show("Category edited successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Edit denied... record already exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            Category? category = null!;
            if (r.Tag != null)
            {
                category = (Category)r.Tag;
            }
            try
            {
                DialogResult dr = MessageBox.Show($"Are you sure you want to delete the record '{category.CategoryName}'?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (dr == DialogResult.No)
                {
                    return;
                }
                if (!_service.IsRelated(category.CategoryId))
                {
                    _service.Delete(category.CategoryId);
                    GridHelper.QuitarFila(r, dgv);
                    MessageBox.Show("Record deleted successfully", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Unable to delete: record is related to another entry", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            if (currentPage < totalPages)
            {
                currentPage++;
                LoadData();
            }
        }
        private void btnPrevious_Click(object sender, EventArgs e)
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
        private void btnFirst_Click(object sender, EventArgs e)
        {
            currentPage = 1;
            LoadData();
        }

        private void categoryNameAZ_Click(object sender, EventArgs e)
        {
            order = Order.CategoryAZ;
            LoadData();
        }

        private void categoryNameZA_Click(object sender, EventArgs e)
        {
            order = Order.CategoryZA;
            LoadData();
        }

        private void cboPages_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentPage = int.Parse(cboPages.Text);
            LoadData();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
