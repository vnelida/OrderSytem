﻿using Data.Interfaces;
using Data.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Services.Interfaces;
using Services.Services;
using System.Configuration;

namespace IOC
{
    public static class DI
    {
        public static IServiceProvider ConfigurarServicios()
        {
            var service = new ServiceCollection();
            var cadena = ConfigurationManager.ConnectionStrings["MiConexion"].ToString();
            

            service.AddScoped<ICategoriesRepository, CategoriesRepository>();
            service.AddScoped<ICategoriesService>(sp =>
            {
                var repository = new CategoriesRepository();
                return new CategoriesService(repository, cadena);
            });


            service.AddScoped<IEmployeesRepository, EmployeesRepository>();
            service.AddScoped<IEmployeesService>(sp =>
            {
                var repository = new EmployeesRepository();
                return new EmployeesService(repository, cadena);
            });


            service.AddScoped<IProductsRepository, ProductsRepository>();
            service.AddScoped<IProductsService>(sp =>
            {
                var repository = new ProductsRepository();
                return new ProductsService(repository, cadena);
            });

            service.AddScoped<IGenreRepository, GenresRepository>();
            service.AddScoped<IGenresService>(sp =>
            {
                var repository = new GenresRepository();
                return new GenresService(repository, cadena);
            });

            service.AddScoped<ICitiesRepository, CitiesRepository>();
            service.AddScoped<ICitiesService>(sp =>
            {
                var repository = new CitiesRepository();
                return new CitiesService(repository, cadena);
            });

            service.AddScoped<IStatesProvincesRepository, StatesProvincesRepository>();
            service.AddScoped<IStatesProvincesService>(sp =>
            {
                var repository = new StatesProvincesRepository();
                return new StatesProvincesService(repository, cadena);
            });

            service.AddScoped<ICitiesRepository, CitiesRepository>();
            service.AddScoped<ICitiesService>(sp =>
            {
                var repository = new CitiesRepository();
                return new CitiesService(repository, cadena);
            });

            service.AddScoped<IAddressTypesRepository, AddressTypesRepository>();
            service.AddScoped<IAddressTypesService>(sp =>
            {
                var repository = new AddressTypesRepository();
                return new AddressTypeService(repository, cadena);
            });

            service.AddScoped<IPhoneTypesRepository, PhoneTypesRepository>();
            service.AddScoped<IPhoneTypesService>(sp =>
            {
                var repository = new PhoneTypesRepository();
                return new PhoneTypesService(repository, cadena);
            });

            service.AddScoped<ICustomerPhonesRepository, CustomerPhonesRepository>();
            service.AddScoped<ICustomerAddressesRepository, CustomerAddressesRepository>();
            service.AddScoped<IAddressesRepository, AddressesRepository>();
            service.AddScoped<IPhonesRepository, PhonesRepository>();

            service.AddScoped<ICustomersRepository, CustomersRepository>();
            service.AddScoped<ICustomersServices>(sp =>
            {
                var repository = new CustomersRepository();
                var repositoryAddress = new AddressesRepository();
                var repositoryPhones = new PhonesRepository();
                var repositoryCustomerAddress = new CustomerAddressesRepository();
                var repositoryCustomerPhone = new CustomerPhonesRepository();
                return new CustomersService(repository,
                    repositoryAddress,
                    repositoryPhones,
                    repositoryCustomerAddress,
                    repositoryCustomerPhone,
                    cadena);
            });

            service.AddScoped<IItemsRepository, ItemsRepository>();
            service.AddScoped<IItemsService>(sp =>
            {
                var repository = new ItemsRepository();
                var repositoryComboDetails= new ComboDetailsRepository();
                return new ItemsService(repository, repositoryComboDetails, cadena);
            });

            service.AddScoped<ISaleDetailsRepository, SaleDetailsRepository>();


            service.AddScoped<ISalesRepository, SalesRepository>();
            service.AddScoped<ISalesService>(sp =>
            {
                var repository = new SalesRepository();
                var repositoryDetails = new SaleDetailsRepository();
                return new SalesService(repository, repositoryDetails, cadena);
            });


            return service.BuildServiceProvider();
        }
       
    }
}
