using Entities.Entities;
using Microsoft.Extensions.DependencyInjection;
using Services.Interfaces;
using Windows.Helpers;

namespace Windows.Forms
{
    public partial class frmPermissions : Form
    {
        private readonly IRoleService _roleService;
        private readonly IServiceProvider? _serviceProvider;
        public frmPermissions(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            _roleService = serviceProvider?.GetService<IRoleService>() ?? throw new ApplicationException("Unloaded dependencies"); ;

        }
        private void PermissionsForm_Load(object sender, EventArgs e)
        {
            CombosHelper.LoadComboRoles(ref cboRoles, _serviceProvider!);
        }


        private void cmbRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboRoles.SelectedIndex > 0) // O si el RoleId es mayor que 0
            {
                if (cboRoles.SelectedItem is Rol selectedRole)
                {
                    LoadPermissions(selectedRole.RoleId);
                }
            }
            else
            {
                // Limpia las grillas si se selecciona el item "Select"
                dgvAssigned.DataSource = null;
                dgvAvailable.DataSource = null;
            }
            //if (cboRoles.SelectedItem is Rol selectedRole)
            //{
            //    LoadPermissions(selectedRole.RoleId);
            //}
        }

        private void LoadPermissions(int roleId)
        {
            try
            {
                // Obtener los datos de forma normal
                var allPermissions = _roleService.GetAllPermissions().ToList();
                var assignedPermissions = _roleService.GetPermissionsByRoleId(roleId).ToList();

                var assignedIds = new HashSet<int>(assignedPermissions.Select(p => p.PermissionId));

                var availablePermissions = allPermissions
                    .Where(p => !assignedIds.Contains(p.PermissionId))
                    .ToList();

                // Simplemente asigna las listas al DataSource.
                // El DataGridView usará las columnas que configuraste en el diseñador.
                dgvAssigned.DataSource = assignedPermissions;
                dgvAvailable.DataSource = availablePermissions;

                if (dgvAssigned.Columns.Contains("PermissionId"))
                {
                    dgvAssigned.Columns["PermissionId"].Visible = false;
                }
                if (dgvAvailable.Columns.Contains("PermissionId"))
                {
                    dgvAvailable.Columns["PermissionId"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar permisos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAssign_Click(object sender, EventArgs e)
        {
            if (cboRoles.SelectedItem is Rol selectedRole && dgvAvailable.SelectedRows.Count > 0)
            {
                try
                {
                    var selectedPermissions = new List<Permission>();
                    foreach (DataGridViewRow row in dgvAvailable.SelectedRows)
                    {
                        if (row.DataBoundItem is Permission permission)
                        {
                            selectedPermissions.Add(permission);
                        }
                    }

                    foreach (var permission in selectedPermissions)
                    {
                        _roleService.AddPermissionToRole(selectedRole.RoleId, permission.PermissionId);
                    }
                    LoadPermissions(selectedRole.RoleId);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al asignar permisos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (cboRoles.SelectedItem is Rol selectedRole && dgvAssigned.SelectedRows.Count > 0)
            {
                try
                {
                    var selectedPermissions = new List<Permission>();
                    foreach (DataGridViewRow row in dgvAssigned.SelectedRows)
                    {
                        if (row.DataBoundItem is Permission permission)
                        {
                            selectedPermissions.Add(permission);
                        }
                    }

                    foreach (var permission in selectedPermissions)
                    {
                        _roleService.RemovePermissionFromRole(selectedRole.RoleId, permission.PermissionId);
                    }
                    LoadPermissions(selectedRole.RoleId);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al quitar permisos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Cambios guardados con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void splitContainer3_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }
    }
}
