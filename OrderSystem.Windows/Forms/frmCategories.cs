using Entities.Entities;
using Microsoft.Extensions.DependencyInjection;
using Services.Interfaces;
using System;
using System.Collections;
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
    public partial class frmCategories : Form
    {
        private readonly ICategoriesService? _service;
        private List<Category>? list;
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
    }
}
