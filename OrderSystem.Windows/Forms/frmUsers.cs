using Entities.Dtos;
using Entities.Entities;
using Microsoft.Extensions.DependencyInjection;
using Services.Interfaces;
using Windows.Helpers;

namespace Windows.Forms
{
    public partial class frmUsers : Form
    {
        private readonly IServiceProvider? _serviceProvider;
        private List<UserListDto> list = null!;
        private readonly IUsersService? _service;
        public frmUsers(IServiceProvider? serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            _service = serviceProvider?.GetService<IUsersService>()
                ?? throw new ApplicationException("Dependencies not loaded");
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void frmUsers_Load(object sender, EventArgs e)
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
            try
            {

                list = _service!.GetList();
                MostrarDatosEnGrilla(list);

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void MostrarDatosEnGrilla(List<UserListDto>? list)
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

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            frmUsersAE frm = new frmUsersAE(_serviceProvider)
            { Text = "Add User" };
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel) { return; }
            try
            {
                User user = frm.GetUser();

                if (!_service!.Exist(user))
                {
                    _service!.Save(user);
                    LoadData();
                    

                    MessageBox.Show("User added",
                        "Info",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("User duplicate",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        private void tsbBorrar_Click(object sender, EventArgs e)
        {

            if (dgv.SelectedRows.Count == 0)
            {
                return;
            }
            var r = dgv.SelectedRows[0];
            if (r.Tag is null) return;
            var userDto = (UserListDto)r.Tag;
            DialogResult dr = MessageBox.Show($"¿Desea dar de baja el/la estado/pcia. {userDto.UserName}?",
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.No) return;
            try
            {
                
                    _service!.Delete(userDto.UserId);
                    LoadData();
                    MessageBox.Show("Registro eliminado",
                        "Mensaje",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count == 0)
            {
                return;
            }
            var r = dgv.SelectedRows[0];
            if (r.Tag is null) return;
            var userDto = (UserListDto)r.Tag;

            var user = _service!.GetUserById(userDto.UserId); ;
            if (user is null) return;
            frmUsersAE frm = new frmUsersAE(_serviceProvider) { Text = "Edit user" };
            frm.SetProvEstado(user);
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel) return;
            try
            {
                user = frm.GetUser();
                if (user is null) return;
                if (!_service!.Exist(user))
                {
                    _service!.Save(user);
                    LoadData();
                    int row = GridHelper.ObtenerRowIndex(dgv, user.UserId);
                    GridHelper.MarcarRow(dgv, row);

                    MessageBox.Show("User edited", "Info",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Existing user", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dgvUsers_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Reemplaza "IsActive" con el nombre real de tu columna
            if (dgv.Columns[e.ColumnIndex].Name == "colActive")
            {
                // Verifica si el valor de la celda es un booleano
                if (e.Value is bool isActive)
                {
                    // Asigna un tilde o una cruz según el valor
                    e.Value = isActive ? "✓" : "✗";
                    // Si quieres que el texto se muestre centrado
                    e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    e.FormattingApplied = true;
                }
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }



    }
}
