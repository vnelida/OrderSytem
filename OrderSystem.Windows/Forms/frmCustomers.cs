using Entities.Dtos;
using Microsoft.Extensions.DependencyInjection;
using Services.Interfaces;
using Windows.Helpers;

namespace Windows.Forms
{
    public partial class frmCustomers : Form
    {
        public frmCustomers(IServiceProvider? serviceProvider)
        {
            InitializeComponent();
            if (serviceProvider == null)
            {
                throw new ApplicationException("Dependencies not loaded");
            }
            _serviceProvider = serviceProvider;
            _service = serviceProvider?.GetService<ICustomersServices>()
                ?? throw new ApplicationException("Dependencies not loaded"); ;
        }
        private readonly IServiceProvider? _serviceProvider;
        private readonly ICustomersServices? _service;
        private List<CustomerListDto>? lista;

        private int currentPage = 1;
        private int totalPages = 0;
        private int pageSize = 30;
        private int totalRecords = 0;
        private void frmCustomers_Load(object sender, EventArgs e)
        {
            try
            {
                totalRecords = _service!.GetCount();
                totalPages = (int)Math.Ceiling((decimal)totalRecords / pageSize);
                LoadData();
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            //frmClientesAE frm = new frmClientesAE(_serviceProvider) { Text = "Add Customer" };
            //DialogResult dr = frm.ShowDialog(this);
            //if (dr == DialogResult.Cancel) return;
            //Cliente? cliente = frm.GetCliente();
            //if (cliente is null) return;
            //try
            //{
            //    if (_servicio is null)
            //    {
            //        throw new ApplicationException("Dependencias no cargadas");
            //    }
            //    _servicio.Guardar(cliente);
            //}
            //catch (Exception)
            //{

            //    throw;
            //}
        }

        private void LoadData()
        {
            try
            {
                lista = _service!.GetList(currentPage, pageSize);
                MostrarDatosEnGrilla(lista);
                if (cboPages.Items.Count != totalPages)
                {
                    CombosHelper.CargarComboPaginas(ref cboPages, totalPages);
                }
                txtPageCount.Text = totalPages.ToString();
                cboPages.SelectedIndex = currentPage == 1 ? 0 : currentPage - 1;
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void btnFirst_Click(object sender, EventArgs e)
        {
            currentPage = 1;
            LoadData();
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

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (currentPage < totalPages)
            {
                currentPage++;
                LoadData();
            }
        }

        private void cboPaginas_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentPage = int.Parse(cboPages.Text);
            LoadData();
        }

        private void MostrarDatosEnGrilla(List<CustomerListDto> lista)
        {
            GridHelper.LimpiarGrilla(dgvDatos);
            if (lista is not null)
            {
                foreach (var c in lista)
                {
                    var r = GridHelper.ConstruirFila(dgvDatos);
                    GridHelper.SetearFila(r, c);
                    GridHelper.AgregarFila(r, dgvDatos);
                }

            }
        }
        private void tsbBorrar_Click(object sender, EventArgs e)
        {
            //if (dgvDatos.SelectedRows.Count == 0)
            //{
            //    return;
            //}
            //var r = dgvDatos.SelectedRows[0];
            //if (r.Tag is null) return;

            //var clienteDto = (ClienteListDto)r.Tag;

            //try
            //{
            //    DialogResult dr = MessageBox.Show($@"¿Desea dar de baja al cliente {clienteDto.Nombres}?",
            //            "Confirmar Baja",
            //            MessageBoxButtons.YesNo,
            //            MessageBoxIcon.Question,
            //            MessageBoxDefaultButton.Button2);
            //    if (dr == DialogResult.No)
            //    {
            //        return;
            //    }

            //    if (dr == DialogResult.Yes)
            //    {
            //        _servicio!.Borrar(clienteDto.ClienteId);
            //        GridHelper.QuitarFila(r, dgvDatos);
            //        MessageBox.Show("Registro eliminado",
            //            "Mensaje",
            //            MessageBoxButtons.OK,
            //            MessageBoxIcon.Information);
            //    }



            //    else
            //    {
            //        MessageBox.Show("Baja Denegada",
            //            "Error",
            //            MessageBoxButtons.OK,
            //            MessageBoxIcon.Error);

            //    }
            //}
            //catch (Exception ex)
            //{

            //    MessageBox.Show(ex.Message,
            //                "Error",
            //                MessageBoxButtons.OK,
            //                MessageBoxIcon.Error);

            //}
        }

        //private void tsbEditar_Click(object sender, EventArgs e)
        //{
        //    if (dgvDatos.SelectedRows.Count == 0)
        //    {
        //        return;
        //    }
        //    var r = dgvDatos.SelectedRows[0];
        //    if (r.Tag == null) return;
        //    ClienteListDto clienteDto = (ClienteListDto)r.Tag;
        //    Cliente? cliente = _servicio!?.GetClientePorId(clienteDto.ClienteId);
        //    if (cliente is null) return;
        //    frmClientesAE frm = new frmClientesAE(_serviceProvider) { Text = "Editar Cliente" };
        //    frm.SetCliente(cliente);
        //    DialogResult dr = frm.ShowDialog(this);
        //    if (dr == DialogResult.Cancel) return;
        //    cliente = frm.GetCliente();

        //    if (cliente == null) return;
        //    try
        //    {
        //        if (!_servicio!.Existe(cliente))
        //        {
        //            _servicio!.Guardar(cliente);
        //            //TODO:Hacer manejo de la edición
        //            MessageBox.Show("Registro editado",
        //                            "Mensaje",
        //                            MessageBoxButtons.OK,
        //                            MessageBoxIcon.Information);
        //        }
        //        else
        //        {
        //            MessageBox.Show("Registro existente\nEdición denegada",
        //            "Error",
        //            MessageBoxButtons.OK,
        //            MessageBoxIcon.Error);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message,
        //        "Error",
        //        MessageBoxButtons.OK,
        //        MessageBoxIcon.Error);
        //    }
        //}

        private void tsbActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                lista = _service!?.GetList(currentPage, pageSize);
                if (lista is not null)
                {
                    MostrarDatosEnGrilla(lista);

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        //private void tsbDetalle_Click(object sender, EventArgs e)
        //{
        //    if (dgvDatos.SelectedRows.Count == 0) { return; }

        //    var r = dgvDatos.SelectedRows[0];
        //    var customerListDto = (CustomerListDto)r.Tag;
        //    try
        //    {
        //        var clienteDetalleDto = _service!.GetCustomerDetails(customerListDto.CustomerId);

        //        frmDetalleCliente frm = new frmDetalleCliente() { Text = "Detalles del Cliente" };
        //        frm.SetCliente(clienteDetalleDto);
        //        DialogResult dr = frm.ShowDialog(this);
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}


    }
}
