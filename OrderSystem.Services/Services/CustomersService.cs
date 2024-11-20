using Data.Interfaces;
using Entities.Dtos;
using Entities.Entities;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class CustomersService : ICustomersServices
    {
        private readonly ICustomersRepository _repositoryCustomers;
        private readonly IAddressesRepository _repositoryAddresses;
        private readonly IPhonesRepository _repositoryPhones;
        private readonly ICustomerAddressesRepository _repositoryCustomerAddresses;
        private readonly ICustomerPhonesRepository _repositoryCustomerPhones;
        private readonly string _cadena;
        public CustomersService(ICustomersRepository repositoryCustomers, IAddressesRepository repositoryAddresses, IPhonesRepository repositoryPhones, ICustomerAddressesRepository repositoryCustomerAddresses, ICustomerPhonesRepository repositoryCustomerPhones, string cadena)
        {
            _repositoryCustomers=  repositoryCustomers;
            _repositoryAddresses= repositoryAddresses;
            _repositoryPhones= repositoryPhones;
            _repositoryCustomerAddresses= repositoryCustomerAddresses;
            _repositoryCustomerPhones=repositoryCustomerPhones;
            _cadena= cadena;
        }
        public void Delete(int customerId)
        {
            using (var conn = new SqlConnection(_cadena))
            {
                conn.Open();
                using (var tran = conn.BeginTransaction())
                {
                    try
                    {
                        _repositoryCustomerAddresses.DeleteByCustomerId(customerId, conn, tran);
                        _repositoryCustomerPhones.DeleteCustomerById(customerId, conn, tran);
                        _repositoryCustomers.Delete(customerId, conn, tran);

                        tran.Commit();
                    }
                    catch
                    {
                        tran.Rollback();
                        throw;
                    }
                }
            }
        }

        public bool Exist(Customer customer)
        {
            using (var conn = new SqlConnection(_cadena))
            {
                conn.Open();
                return _repositoryCustomers.Exist(customer, conn);
            }
        }

        public int GetCount()
        {
            using (var conn = new SqlConnection(_cadena))
            {
                return _repositoryCustomers.GetCount(conn);
            }
        }

        public Customer? GetCustomerById(int customerId)
        {
            using (var conn = new SqlConnection(_cadena))
            {
                conn.Open();
                var customer = _repositoryCustomers.GetCustomerById(customerId, conn);
                if (customer != null)
                {
                    customer.CustomerAdresses = _repositoryCustomerAddresses.GetAddressByCustomerId(customerId, conn);
                    customer.CustomerPhones = _repositoryCustomerPhones.GetPhonesByCustomerId(customerId, conn);
                }
                return customer;
            }
        }

        public CustomerDetailsDto? GetCustomerDetails(int customerId)
        {
            using (var conn = new SqlConnection(_cadena))
            {
                conn.Open();
                return _repositoryCustomers.GetCustomerDetails(customerId, conn);
            }
        }

        public List<Customer> GetCustomers()
        {
            using (var conn = new SqlConnection(_cadena))
            {
                conn.Open();
                return _repositoryCustomers.GetCustomers(conn);
            }
        }

        public List<CustomerListDto> GetList(int? currentPage, int? pageSize)
        {
            using (var conn = new SqlConnection(_cadena))
            {
                conn.Open();
                return _repositoryCustomers.GetList(conn, currentPage, pageSize);
            }
        }

        public void Save(Customer customer)
        {
            using (var conn = new SqlConnection(_cadena))
            {
                conn.Open();
                using (var tran = conn.BeginTransaction())
                {
                    try
                    {
                        if (customer.CustomerId == 0)
                        {
                            _repositoryCustomers.Add(customer, conn, tran);
                        }
                        else
                        {
                            _repositoryCustomers.Edit(customer, conn, tran);
                            _repositoryCustomerAddresses.DeleteByCustomerId(customer.CustomerId, conn, tran);
                            _repositoryCustomerPhones.DeleteCustomerById(customer.CustomerId, conn, tran);
                        }

                        foreach (var customerAddress in customer.CustomerAdresses)
                        {
                            int addressIdExists = _repositoryAddresses.GetAddressIdIfExists(customerAddress.Address, conn, tran);
                            if (addressIdExists == 0)
                            {
                                _repositoryAddresses.Add(customerAddress.Address, conn, tran);
                                customerAddress.AddressId = customerAddress.Address.AddressId;
                            }
                            else
                            {
                                customerAddress.AddressId = addressIdExists;
                            }

                            customerAddress.CustomerId = customer.CustomerId;
                            _repositoryCustomerAddresses.Add(customerAddress, conn, tran);
                        }

                        foreach (var customerPhone in customer.CustomerPhones)
                        {
                            int phoneIdExists = _repositoryPhones.GetPhoneIdIfExist(customerPhone.Phone, conn, tran);
                            if (customerPhone.Phone.PhoneId == 0)
                            {
                                _repositoryPhones.Add(customerPhone.Phone, conn, tran);
                            }
                            customerPhone.CustomerId = customer.CustomerId;
                            customerPhone.PhoneId = customerPhone.Phone.PhoneId;
                            _repositoryCustomerPhones.Add(customerPhone, conn, tran);
                        }

                        tran.Commit();
                    }
                    catch
                    {
                        tran.Rollback();
                        throw;
                    }
                }
            }
        }
    }
}
