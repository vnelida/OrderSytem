using Data.Interfaces;
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


            return service.BuildServiceProvider();
        }
       
    }
}
