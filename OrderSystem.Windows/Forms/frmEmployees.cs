using Entities.Entities;
using Microsoft.Extensions.DependencyInjection;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Windows.Helpers;

namespace Windows.Forms
{
    public partial class frmEmployees : Form
    {
        private readonly IEmployeesService? _service;
        private List<Employee>? list;
        public frmEmployees(IServiceProvider? serviceProvider)
        {
            InitializeComponent();
            _service = serviceProvider?.GetService<IEmployeesService>() ?? throw new ApplicationException("Unloaded dependencies");
        }

        private void frmEmployees_Load(object sender, EventArgs e)
        {
            try
            {
                list = _service!.GetList();
                MostrarDatosEnGrilla();
            }
            catch (Exception)
            {

                throw;
            }
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
            frmEmployeesAE frm = new frmEmployeesAE() { Text = "New employee" };
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
                    var r = GridHelper.ConstruirFila(dgv);
                    GridHelper.SetearFila(r, employee);
                    GridHelper.AgregarFila(r, dgv);
                    MessageBox.Show("The record has been successfully added","Information",
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
                Employee employee;
                if (r.Tag != null)
                {
                    employee = (Employee)r.Tag;
                    frmEmployeesAE frm = new frmEmployeesAE() { Text = "Update employee information" };
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
            Employee? employee = null!;
            if (r.Tag != null)
            {
                employee = (Employee)r.Tag;
            }
            try
            {
                DialogResult dr = MessageBox.Show($"Are you sure you want to delete the employee information for '{employee.FirstName} {employee.LastName}'?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (dr == DialogResult.No)
                {
                    return;
                }
                if (!_service.IsRelated(employee.EmployeeId))
                {
                    _service.Delete(employee.EmployeeId);
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
    }
}
