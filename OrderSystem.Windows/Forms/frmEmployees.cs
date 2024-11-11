using Entities.Dtos;
using Entities.Entities;
using Entities.Enums;
using Microsoft.Extensions.DependencyInjection;
using Services.Interfaces;
using Windows.Helpers;

namespace Windows.Forms
{
    public partial class frmEmployees : Form
    {
        IServiceProvider? _serviceProvider;
        private readonly IEmployeesService? _service;
        private List<EmployeeListDto>? list;
        private int currentPage = 1;
        private int totalPages = 0;
        private int pageSize = 10;
        private int totalRecords = 0;
        private Genre? genreFiltro = null;
        private bool filterOn = false;
        private Order order = Order.None;

        public frmEmployees(IServiceProvider? serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            _service = serviceProvider?.GetService<IEmployeesService>() ?? throw new ApplicationException("Unloaded dependencies");
        }

        private void frmEmployees_Load(object sender, EventArgs e)
        {
            try
            {
                //totalRecords = _service!.GetCount(genreFiltro);
                //totalPages = (int)Math.Ceiling((decimal)totalRecords / pageSize);
                LoadData();
                CombosHelper.CargarTSBComboGenres(_serviceProvider, ref btnFilter);

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void LoadData()
        {    // Obtener el conteo de registros en base al filtro actual
            totalRecords = _service!.GetCount(genreFiltro);
            totalPages = (int)Math.Ceiling((decimal)totalRecords / pageSize);

            // Ajustar la página actual si excede el total de páginas
            if (currentPage > totalPages)
            {
                currentPage = 1; // Reiniciar a la primera página si está fuera del rango
            }

            // Obtener la lista de empleados en base al filtro, página actual, y orden
            list = _service.GetList(currentPage, pageSize, order, genreFiltro);

            // Mostrar los datos en la grilla
            MostrarDatosEnGrilla();

            // Actualizar el combo de páginas y la visualización del conteo total de páginas
            if (cboPages.Items.Count != totalPages)
            {
                CombosHelper.CargarComboPaginas(ref cboPages, totalPages);
            }
            txtPageCount.Text = totalPages.ToString();

            // Establecer el índice seleccionado solo si hay páginas disponibles
            cboPages.SelectedIndexChanged -= cboPages_SelectedIndexChanged;
            if (totalPages > 0) // Asegurar que hay páginas
            {
                cboPages.SelectedIndex = currentPage - 1;
            }
            cboPages.SelectedIndexChanged += cboPages_SelectedIndexChanged;
            //totalRecords = _service!.GetCount(genreFiltro);
            //totalPages = (int)Math.Ceiling((decimal)totalRecords / pageSize);

            //list = _service!.GetList(currentPage, pageSize, order, genreFiltro);
            //MostrarDatosEnGrilla();
            //if (cboPages.Items.Count != totalPages)
            //{
            //    CombosHelper.CargarComboPaginas(ref cboPages, totalPages);
            //}
            //txtPageCount.Text = totalPages.ToString();
            //cboPages.SelectedIndexChanged -= cboPages_SelectedIndexChanged;
            //cboPages.SelectedIndex = currentPage == 1 ? 0 : currentPage -1;
            //cboPages.SelectedIndexChanged += cboPages_SelectedIndexChanged;
        }
        private void cboPages_SelectedIndexChanged(object? sender, EventArgs e)
        {
            currentPage = int.Parse(cboPages.Text);
            LoadData();
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
            frmEmployeesAE frm = new frmEmployeesAE(_serviceProvider) { Text = "New employee" };
            DialogResult dr = frm.ShowDialog(this);

            if (dr == DialogResult.Cancel)
            {
                return;
            }
            try
            {
                Employee employee = frm.GetTipo();

                if (!_service.Exist(employee))
                {
                    _service.Save(employee);
                    LoadData();
                    MessageBox.Show("The record has been successfully added", "Information",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"The record '{employee.FirstName} {employee.LastName}' already exists and cannot be added", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
                    var employeeDto = (EmployeeListDto)r.Tag;
                    var employee = _service.GetEmployeeById(employeeDto.EmployeeId);
                    frmEmployeesAE frm = new frmEmployeesAE(_serviceProvider) { Text = "Update employee information" };
                    frm.SetTipo(employee);
                    DialogResult dr = frm.ShowDialog(this);
                    if (dr == DialogResult.Cancel)
                    {
                        return;
                    }
                    employee = frm.GetTipo();
                    if (!_service.Exist(employee))
                    {
                        _service.Save(employee);
                        GridHelper.SetearFila(r, employee);
                        MessageBox.Show("Employee details updated successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Edit denied. An employee with this information already exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            EmployeeListDto? employeeDto = null!;
            if (r.Tag != null)
            {
                employeeDto = (EmployeeListDto)r.Tag;
            }
            try
            {
                DialogResult dr = MessageBox.Show($"Are you sure you want to delete the employee information for '{employeeDto.FirstName} {employeeDto.LastName}'?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (dr == DialogResult.No)
                {
                    return;
                }
                if (true/*!_service.IsRelated(employee.EmployeeId)*/)
                {
                    _service.Delete(employeeDto.EmployeeId);
                    GridHelper.QuitarFila(r, dgv);
                    MessageBox.Show("Employee record deleted successfully", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Unable to delete: this employee record is related to another entry", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {

                throw;
            }
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

        private void firstNameAZ_Click(object sender, EventArgs e)
        {
            order = Order.FirstNameAZ;
            LoadData();
        }

        private void firstNameZA_Click(object sender, EventArgs e)
        {
            order = Order.FirstNameZA;
            LoadData();
        }

        private void lastNameAZ_Click(object sender, EventArgs e)
        {
            order = Order.LastNameAZ;
            LoadData();
        }

        private void lastNameZA_Click(object sender, EventArgs e)
        {
            order = Order.LastNameZA;
            LoadData();
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {

        }

        private void btnFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (btnFilter.SelectedIndex > 0)
            {
                filterOn = true;
                var _serviceGenre = _serviceProvider.GetService<IGenresService>();
                genreFiltro = _serviceGenre?.GetGenreByName(btnFilter.Text);
                LoadData();

            }

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            genreFiltro = null;
            order = Order.None;
            btnFilter.SelectedIndex = 0;
            LoadData() ;
        }
    }
}
