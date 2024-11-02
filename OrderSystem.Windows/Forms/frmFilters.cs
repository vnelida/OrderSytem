using Entities.Entities;
using Entities.Enums;
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
    public partial class frmFilters : Form
    {
        private readonly IServiceProvider? _serviceProvider;
        private readonly FiltroContexto _filtroContexto;
        private Category? selectedCategory;
        public frmFilters(IServiceProvider? service, FiltroContexto filtroContexto)
        {
            InitializeComponent();
            _serviceProvider = service;
            _filtroContexto = filtroContexto;
        }
        private void frmFilters_Load(object sender, EventArgs e)
        {
            CombosHelper.CargarComboCategories(ref cboCategories, _serviceProvider);
        }
        public Category? GetCategory()
        {
            return selectedCategory;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (cboCategories.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(cboCategories, "You must select a category.");
            }
            return valido;
        }

        private void cboPaises_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedCategory = (Category?)cboCategories.SelectedItem ?? null;
        }

    }
}
