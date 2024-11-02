using Entities.Entities;
using Microsoft.Extensions.DependencyInjection;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Windows.Helpers
{
    public static class CombosHelper
    {
        private static IServiceProvider? _serviceProvider;

        public static void CargarComboCategories(ref ComboBox cbo, IServiceProvider? serviceProvider)
        {
            _serviceProvider = serviceProvider;
            ICategoriesService? service = _serviceProvider?.GetService<ICategoriesService>();

            var listCategories = service?.GetList();
            var defaultCategory = new Category()
            {
                CategoryId = 0,
                CategoryName = "Seleccione"
            };
            listCategories?.Insert(0, defaultCategory);
            cbo.DataSource = listCategories;
            cbo.DisplayMember = "CategoryName";
            cbo.ValueMember = "CategoryId";
            cbo.SelectedIndex = 0;

        }

        public static void CargarComboPaginas(ref ComboBox cbo, int totalPages)
        {
            cbo.Items.Clear();
            for (int i = 1; i <= totalPages; i++)
            {
                cbo.Items.Add(i.ToString());
            }

        }
    }
}

