﻿using Entities.Dtos;
using Entities.Entities;
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

        private int currentPage = 1;//pagina actual
        private int totalPages = 0;//total de paginas
        private int pageSize = 10;//registros por página
        private int totalRecords = 0;//cantidad de registros

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
                totalRecords = _service!.GetCount(filter);
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
                list = _service!.GetList(currentPage, pageSize, filter);
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
                    MessageBox.Show("No se encontraron registros!!!", "Mensaje",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    MessageBox.Show("No hay registros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    currentPage = 1;
                    filter = null;
                    btnFilter.Enabled = true;
                    btnFilter.BackColor = SystemColors.Control;
                    RecargarGrilla();
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




        private void tsbActualizar_Click(object sender, EventArgs e)
        {
            filter = null;
            currentPage = 1;
            btnFilter.Enabled = true;
            btnFilter.BackColor = SystemColors.Control;
            RecargarGrilla();
        }


        private void tsbDetalles_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count == 0) return;
            var r = dgv.SelectedRows[0];
            SalesListDto saleDto = (SalesListDto)r.Tag!;
            Sale? sale = _service!.GetSaleById(saleDto.SaleId);
            //frmDetalleVenta frm = new frmDetalleVenta();
            //frm.SetVenta(sale);
            //frm.ShowDialog(this);
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            //frmVentasAE frm = new frmVentasAE(_serviceProvider) { Text = "Nueva Venta" };
            //DialogResult dr = frm.ShowDialog(this);
            //if (dr == DialogResult.Cancel) return;
            //try
            //{
            //    Venta? venta = frm.GetVenta();
            //    if (venta is null) return;
            //    _servicio.Guardar(venta);
            //    totalRecords = _servicio!.GetCantidad(null);
            //    totalPages = (int)Math.Ceiling((decimal)totalRecords / pageSize);
            //    currentPage = totalPages;
            //    LoadData();
            //    int row = GridHelper.ObtenerRowIndex(dgvDatos, venta.VentaId);
            //    GridHelper.MarcarRow(dgvDatos, row);

            //    MessageBox.Show("Registro agregado",
            //        "Mensaje",
            //        MessageBoxButtons.OK,
            //        MessageBoxIcon.Information);

            //}
            //catch (Exception ex)
            //{

            //    MessageBox.Show(ex.Message,
            //        "Mensaje",
            //        MessageBoxButtons.OK,
            //        MessageBoxIcon.Error);
            //}

        }

        private void frmSales_Load(object sender, EventArgs e)
        {
            RecargarGrilla();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
