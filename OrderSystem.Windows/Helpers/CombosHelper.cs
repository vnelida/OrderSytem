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

        internal static void LoadCustomersComboBox(ref ComboBox cboCustomers, IServiceProvider? serviceProvider)
        {
            _serviceProvider = serviceProvider;
            ICustomersServices? service = _serviceProvider?.GetService<ICustomersServices>();
            var list = service?.GetCustomers();
            var defaultCustomer = new Customer()
            {
                CustomerId = 99999,
                LastName = "Consumidor",
                FirstName = "Final"
            };
            list?.Insert(0, defaultCustomer);
            cboCustomers.DataSource = list;
            cboCustomers.DisplayMember = "FullName";
            cboCustomers.ValueMember = "CustomerId";
            cboCustomers.SelectedIndex = 0;
        }

        internal static void LoadOrderStatusComboBx(ref ComboBox cbo, IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            IOrderStatusService? service = _serviceProvider?.GetService<IOrderStatusService>();

            var list = service?.GetListOrderStatus();
            var defaultStatus = new OrderStatus()
            {
                OrderStatusId = 0,
                StatusName = "Seleccione"
            };
            list?.Insert(0, defaultStatus);
            cbo.DataSource = list;
            cbo.DisplayMember = "StatusName";
            cbo.ValueMember = "OrderStatusId";
            cbo.SelectedIndex = 0;
        }

        internal static void LoadOrderTypesComboBx(ref ComboBox cbo, IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            IOrderTypeServices? service = _serviceProvider?.GetService<IOrderTypeServices>();

            var list = service?.GetListOrderType();
            var defaultTypes = new OrderType()
            {
                OrderTypeId = 0,
                TypeName = "Seleccione"
            };
            list?.Insert(0, defaultTypes);
            cbo.DataSource = list;
            cbo.DisplayMember = "TypeName";
            cbo.ValueMember = "OrderTypeId";
            cbo.SelectedIndex = 0;
        }

       
        internal static void LaodAddressTypesComboBox(ref ComboBox cbo, IServiceProvider? serviceProvider)
        {
            _serviceProvider = serviceProvider;
            IAddressTypesService? service = _serviceProvider?.GetService<IAddressTypesService>();
            var list = service?.GetList();
            var defaultType = new AddressType()
            {
                AddressTypeId = 0,
                Description = "Select"
            };
            list?.Insert(0, defaultType);
            cbo.DataSource = list;
            cbo.DisplayMember = "Description";
            cbo.ValueMember = "AddressTypeId";
            cbo.SelectedIndex = 0;
        }

        internal static void LoadCountriesComboBox(ref ComboBox cbo, IServiceProvider? serviceProvider)
        {
            _serviceProvider = serviceProvider;
            ICountriesService? service = _serviceProvider?.GetService<ICountriesService>();
            var list = service?.GetList(null, null);
            var defaultCountry = new Country()
            {
                CountryId = 0,
                CountryName = "Select"
            };
            list?.Insert(0, defaultCountry);
            cbo.DataSource = list;
            cbo.DisplayMember = "CountryName";
            cbo.ValueMember = "CountryId";
            cbo.SelectedIndex = 0;
        }

        internal static void LoadStatesComboBox(ref ComboBox cbo, Country country, IServiceProvider? serviceProvider)
        {
            _serviceProvider = serviceProvider;
            IStatesProvincesService? service = _serviceProvider?.GetService<IStatesProvincesService>();
            var list = service?.GetListComboStates(country);
            var defaultState = new StateProvince()
            {
                CountryId = 0,
                StateProvinceName = "Select"
            };
            list?.Insert(0, defaultState);
            cbo.DataSource = list;
            cbo.DisplayMember = "StateProvinceName";
            cbo.ValueMember = "StateProvinceId";
            cbo.SelectedIndex = 0;
        }

        internal static void LoadCitiesComboBox(ref ComboBox cbo, Country? country, StateProvince stateProvince, IServiceProvider? serviceProvider)
        {
            _serviceProvider = serviceProvider;
            ICitiesService? service = _serviceProvider?.GetService<ICitiesService>();
            var list = service?.GetListCombo(country, stateProvince);
            var defaultCity = new City()
            {
                CityId = 0,
                CityName = "Select"
            };
            list?.Insert(0, defaultCity);
            cbo.DataSource = list;
            cbo.DisplayMember = "CityName";
            cbo.ValueMember = "CityId";
            cbo.SelectedIndex = 0;
        }

        internal static void LoadPhoneTypesComboBox(ref ComboBox cbo, IServiceProvider? serviceProvider)
        {
            _serviceProvider = serviceProvider;
            IPhoneTypesService? service = _serviceProvider?.GetService<IPhoneTypesService>();
            var list = service?.GetList();
            var defaultType = new PhoneType()
            {
                PhoneTypeId = 0,
                Description = "Select"
            };
            list?.Insert(0, defaultType);
            cbo.DataSource = list;
            cbo.DisplayMember = "Description";
            cbo.ValueMember = "PhoneTypeId";
            cbo.SelectedIndex = 0;
        }
    }
}

