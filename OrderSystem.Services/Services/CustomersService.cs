using Data.Interfaces;
using Entities.Dtos;
using Entities.Entities;
using Services.Interfaces;
using System.Data.SqlClient;

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
            _repositoryCustomers = repositoryCustomers;
            _repositoryAddresses = repositoryAddresses;
            _repositoryPhones = repositoryPhones;
            _repositoryCustomerAddresses = repositoryCustomerAddresses;
            _repositoryCustomerPhones = repositoryCustomerPhones;
            _cadena = cadena;
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

        public Customer? GetCustomerFullDetails(int customerId)
        {
            using (var conn = new SqlConnection(_cadena))
            {
                conn.Open();
                // Llama a un nuevo método en tu CustomersRepository que usa QueryMultiple
                // Esto es mucho más simple que los Query<...>,... anidados.
                var customer = _repositoryCustomers.GetCustomerFullDetails(customerId, conn);
                return customer;
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

        public Phone? GetPhoneDetails(int phoneId)
        {
            using (var conn = new SqlConnection(_cadena))
            {
                conn.Open();
                // Llama al método del repositorio de Phones
                return _repositoryPhones.GetPhoneById(phoneId, conn);
            }
        }

        public bool IsRelated(int customerId)
        {
            using (var conn = new SqlConnection(_cadena))
            {
                conn.Open();
                return _repositoryCustomers!.IsRelated(customerId, conn);
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

        public void SaveCustomerFullDetails(Customer customer)
        {
            using (var conn = new SqlConnection(_cadena))
            {
                conn.Open();
                using (var tran = conn.BeginTransaction())
                {
                    try
                    {
                        // 1. Guardar el cliente principal (Add o Edit)
                        if (customer.CustomerId == 0) // Es un nuevo cliente
                        {
                            _repositoryCustomers.Add(customer, conn, tran); // Add asigna CustomerId a customer
                        }
                        else // Es un cliente existente
                        {
                            _repositoryCustomers.Edit(customer, conn, tran);
                            // 2. Borrar TODAS las relaciones existentes antes de re-insertar
                            _repositoryCustomerAddresses.DeleteByCustomerId(customer.CustomerId, conn, tran);
                            _repositoryCustomerPhones.DeleteCustomerById(customer.CustomerId, conn, tran);
                        }

                        // 3. Re-insertar todas las direcciones del cliente
                        // customer.CustomerAdresses es la lista List<CustomerAddress> con los objetos Address y AddressType anidados.
                        foreach (var customerAddress in customer.CustomerAdresses) // <--- ¡ITERAMOS SOBRE CustomerAdresses!
                        {
                            // Primero, añadir/actualizar el objeto Address puro (si es nuevo o no tiene ID)
                            // Este paso asume que customerAddress.Address está populado por el formulario.
                            int addressIdExists = _repositoryAddresses.GetAddressIdIfExists(customerAddress.Address, conn, tran); // <-- Necesitas este método
                            if (addressIdExists == 0)
                            {
                                _repositoryAddresses.Add(customerAddress.Address, conn, tran); // Add asigna AddressId a customerAddress.Address.AddressId
                            }
                            else
                            {
                                customerAddress.Address.AddressId = addressIdExists; // Asigna el ID existente a la Address anidada
                            }

                            // Luego, añadir la relación en CustomerAddresses (tabla de enlace)
                            // Las propiedades CustomerId, AddressId, AddressTypeId ya están en customerAddress.
                            // Asegurarse de que el CustomerId sea el del Customer principal
                            customerAddress.CustomerId = customer.CustomerId;
                            customerAddress.AddressId = customerAddress.Address.AddressId; // Asegurar que el AddressId en CustomerAddress es el correcto
                                                                                           // customerAddress.AddressTypeId ya viene del formulario

                            _repositoryCustomerAddresses.Add(customerAddress, conn, tran); // Agrega la entidad CustomerAddress
                        }

                        // 4. Re-insertar todos los teléfonos del cliente
                        // customer.CustomerPhones es la lista List<CustomerPhone> con los objetos Phone y PhoneType anidados.
                        foreach (var customerPhone in customer.CustomerPhones) // <--- ¡ITERAMOS SOBRE CustomerPhones!
                        {
                            // Primero, añadir/actualizar el objeto Phone puro (si es nuevo o no tiene ID)
                            // Este paso asume que customerPhone.Phone está populado.
                            int phoneIdExists = _repositoryPhones.GetPhoneIdIfExist(customerPhone.Phone, conn, tran); // <-- Necesitas este método
                            if (phoneIdExists == 0)
                            {
                                _repositoryPhones.Add(customerPhone.Phone, conn, tran); // Add asigna PhoneId a customerPhone.Phone.PhoneId
                            }
                            else
                            {
                                customerPhone.Phone.PhoneId = phoneIdExists; // Asigna el ID existente al Phone anidado
                            }

                            // Luego, añadir la relación en CustomerPhones (tabla de enlace)
                            // Las propiedades CustomerId, PhoneId, PhoneTypeId ya están en customerPhone.
                            customerPhone.CustomerId = customer.CustomerId; // Asegurarse de que el CustomerId sea el del Customer principal
                            customerPhone.PhoneId = customerPhone.Phone.PhoneId; // Asegurar que el PhoneId en CustomerPhone es el correcto
                                                                                 // customerPhone.PhoneTypeId ya viene del formulario

                            _repositoryCustomerPhones.Add(customerPhone, conn, tran); // Agrega la entidad CustomerPhone
                        }

                        tran.Commit(); // Confirma la transacción
                    }
                    catch (Exception)
                    {
                        tran.Rollback(); // Deshace todo
                        throw; // Vuelve a lanzar
                    }
                }
            }
        }

    }
}
