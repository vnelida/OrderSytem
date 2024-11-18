using Entities.Entities;
using Entities.Enums;
using Microsoft.Extensions.DependencyInjection;
using Services.Interfaces;

namespace Windows.Helpers
{
    public static class CombosHelper
    {
        private static IServiceProvider? _serviceProvider;
        public static void CargarTSBComboGenres(IServiceProvider serviceProvider, ref ToolStripComboBox cbo)
        {
            var service = serviceProvider.GetService<IGenresService>();
            var list = service?.GetListGenres();
            var defaultGenre = new Genre
            {
                GenreName = "Filter by:"
            };
            cbo.Items.Clear();
            list?.Insert(0, defaultGenre);
            if (list is not null)
            {
                foreach (Genre genre in list)
                {
                    cbo.Items.Add(genre.GenreName);
                }
            }
            if (list?.Count > 0)
            {
                cbo.SelectedIndex = 0;
            }
        }
        public static void CargarTSBComboCategory(IServiceProvider serviceProvider, ref ToolStripComboBox cbo)
        {
            var service = serviceProvider.GetService<ICategoriesService>();
            var list = service?.GetList();
            var defaultCategory = new Category
            {
                CategoryName = "Filter by:"
            };
            cbo.Items.Clear();
            list?.Insert(0, defaultCategory);
            if (list is not null)
            {
                foreach (Category category in list)
                {
                    cbo.Items.Add(category.CategoryName);
                }
            }
            if (list?.Count > 0)
            {
                cbo.SelectedIndex = 0;
            }
        }

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
        public static void CargarComboGenres(ref ComboBox cbo, IServiceProvider? serviceProvider)
        {
            _serviceProvider = serviceProvider;
            IGenresService? service = _serviceProvider?.GetService<IGenresService>();

            var listGenres = service?.GetListGenres();
            var defaultGenres = new Genre()
            {
                GenreId = 0,
                GenreName = "Seleccione"
            };
            listGenres?.Insert(0, defaultGenres);
            cbo.DataSource = listGenres;
            cbo.DisplayMember = "GenreName";
            cbo.ValueMember = "GenreId";
            cbo.SelectedIndex = 0;

        }
        public static void CargarComboProducts(ref ComboBox cbo, IServiceProvider? serviceProvider)
        {
            _serviceProvider = serviceProvider;
            IItemsService? service = _serviceProvider?.GetService<IItemsService>();

            var list = service?.GetItemList(ItemType.Product);
            var defaultProducts = new Product()
            {
                ItemId = 0,
                Name = "Seleccione"
            };
            list?.Insert(0, defaultProducts);
            cbo.DataSource = list;
            cbo.DisplayMember = "Name";
            cbo.ValueMember = "ItemId";
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

