using Entities.Dtos;
using Entities.Entities;

namespace Services.Interfaces
{
    public interface ICustomersServices
    {
        void Delete(int customerId);
        bool Exist(Customer customer);
        List<CustomerListDto> GetList(int? currentPage, int? pageSize);
        void Save(Customer customer);
        Customer? GetCustomerById(int customerId);
        int GetCount();
        CustomerDetailsDto? GetCustomerDetails(int customerId);
        List<Customer> GetCustomers();
        bool IsRelated(int customerId);
        Customer? GetCustomerFullDetails(int customerId);
        Phone? GetPhoneDetails(int phoneId);
        void SaveCustomerFullDetails(Customer customerToSave);
    }
}
