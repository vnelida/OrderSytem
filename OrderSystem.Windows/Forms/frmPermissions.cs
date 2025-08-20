using Entities.Entities;
using Microsoft.Extensions.DependencyInjection;
using Services.Interfaces;
using Services.Services;
using Windows.Helpers;

namespace Windows.Forms
{
    public partial class frmPermissions : Form
    {
        private List<Permission>? lista;
        private List<Permission>? listaB;
        private Rol? selectedRole;
        private IPermissionService _permissionService;
        private readonly IRoleService _roleService;
        private readonly IServiceProvider? _serviceProvider;
        public frmPermissions(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            _roleService = serviceProvider?.GetService<IRoleService>() ?? throw new ApplicationException("Unloaded dependencies");
            _permissionService = serviceProvider?.GetService<IPermissionService>() ?? throw new ApplicationException("Unloaded dependencies");
        }

        private void PermissionsForm_Load(object sender, EventArgs e)
        {
            CombosHelper.LoadComboRoles(ref cboRoles, _serviceProvider!);


        }

        private void LoadData(int roleId)
        {
            try
            {
                lista = _permissionService!.GetListAssigned(roleId);
                listaB = _permissionService!.GetListUnassigned(roleId);
                MostrarDatosEnGrilla(lista);
                MostrarDatosEnGrillaUnassigned(listaB);

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void MostrarDatosEnGrillaUnassigned(List<Permission>? listaB)
        {
            GridHelper.LimpiarGrilla(dgvUnassigned);
            if (lista is not null)
            {
                foreach (var c in listaB!)
                {
                    var r = GridHelper.ConstruirFila(dgvUnassigned);
                    GridHelper.SetearFila(r, c);
                    GridHelper.AgregarFila(r, dgvUnassigned);
                }
            }
        }

        private void MostrarDatosEnGrilla(List<Permission>? lista)
        {
            GridHelper.LimpiarGrilla(dgvAssigned);
            if (lista is not null)
            {
                foreach (var c in lista)
                {
                    var r = GridHelper.ConstruirFila(dgvAssigned);
                    GridHelper.SetearFila(r, c);
                    GridHelper.AgregarFila(r, dgvAssigned);
                }
            }
        }

        private void cmbRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboRoles.SelectedValue is int roleId && roleId > 0)
            {
                selectedRole = (Rol)cboRoles.SelectedItem;
                LoadData(roleId);
            }
            else
            {
                GridHelper.LimpiarGrilla(dgvAssigned);
                GridHelper.LimpiarGrilla(dgvUnassigned);
            }
        }

        private void btnAssign_Click(object sender, EventArgs e)
        {
            if (dgvUnassigned.SelectedRows.Count == 0)
            {
                return;
            }
            var r = dgvUnassigned.SelectedRows[0];
            if (r.Tag is null) return;

            var permission = (Permission)r.Tag;

            try
            {
                DialogResult dr = MessageBox.Show($@"Do you want to assign this permission?",
                        "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (dr == DialogResult.No)
                {
                    return;
                }

                if (dr == DialogResult.Yes)
                {
                    _permissionService.AddPermissionToRol(selectedRole.RoleId, permission.PermissionId);

                    GridHelper.QuitarFila(r, dgvUnassigned);
                    MessageBox.Show("Permission assigned", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    r = GridHelper.ConstruirFila(dgvAssigned);
                    GridHelper.SetearFila(r, permission);
                    GridHelper.AgregarFila(r, dgvAssigned);
                }

                else
                {
                    MessageBox.Show("Request Denied", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dgvAssigned.SelectedRows.Count == 0)
            {
                return;
            }
            var r = dgvAssigned.SelectedRows[0];
            if (r.Tag is null) return;

            var permission = (Permission)r.Tag;

            try
            {
                DialogResult dr = MessageBox.Show($@"Do you want to remove this permission?",
                        "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (dr == DialogResult.No)
                {
                    return;
                }

                if (dr == DialogResult.Yes)
                {
                    _permissionService.RemovePermissionFromRol(selectedRole.RoleId, permission.PermissionId);

                    GridHelper.QuitarFila(r, dgvAssigned);
                    MessageBox.Show("Permission removed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    r = GridHelper.ConstruirFila(dgvUnassigned);
                    GridHelper.SetearFila(r, permission);
                    GridHelper.AgregarFila(r, dgvUnassigned);
 }

                else
                {
                    MessageBox.Show("Request Denied", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
