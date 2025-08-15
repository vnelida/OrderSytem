using Data.Interfaces;
using Entities.Dtos;
using Entities.Entities;
using Entities.Enums;
using Services.Interfaces;
using System.Data.SqlClient;

namespace Services.Services
{
    public class ProductsService : IProductsService
    {
        private readonly IProductsRepository? _repository;
        private readonly string? _cadena;
        public ProductsService(IProductsRepository repository, string cadena)
        {
            _repository = repository;
            _cadena = cadena;

        }

        public void Delete(int productId)
        {
            using (var conn = new SqlConnection(_cadena))
            {
                conn.Open();
                using (var tran = conn.BeginTransaction())
                {
                    try
                    {
                        _repository!.Delete(productId, conn, tran);
                        tran.Commit();
                    }
                    catch (Exception)
                    {
                        tran.Rollback();
                        throw;
                    }

                }
            }
        }

        public bool Exist(Product product)
        {
            using (var conn = new SqlConnection(_cadena))
            {
                return _repository!.Exist(product, conn);

            }
        }

        public int GetCount(Category? category = null)
        {
            using (var conn = new SqlConnection(_cadena))
            {
                conn.Open();
                return _repository!.GetCount(conn, category);
            }
        }

        public List<ProductListDto> GetList(int currentPage, int pageSize, Order? order = Order.None, Category? category = null)
        {
            using (var conn = new SqlConnection(_cadena))
            {
                return _repository!.GetList(conn, currentPage, pageSize, order, category);

            }
        }

        public int GetPageByRecord(string productName, int pageSize)
        {
            using (var conn = new SqlConnection(_cadena))
            {
                conn.Open();
                return _repository!.GetPageByRecord(conn, productName, pageSize);
            }
        }

        public Product GetProductById(int productId)
        {
            using (var conn = new SqlConnection(_cadena))
            {
                conn.Open();
                var product = _repository.GetProductById(productId, conn);

                return product;
            }
        }

        public bool IsRelated(int productId)
        {
            using (var conn = new SqlConnection(_cadena))
            {
                conn.Open();
                return _repository!.IsRelated(productId, conn);
            }
        }

        public void Save(Product product)
        {
            using (var conn = new SqlConnection(_cadena))
            {
                conn.Open();
                using (var tran = conn.BeginTransaction())
                {
                    try
                    {
                        if (product.ItemId == 0)
                        {
                            _repository!.Add(product, conn, tran);
                        }
                        else
                        {
                            _repository!.Edit(product, conn, tran);
                        }
                        tran.Commit();
                    }
                    catch (Exception)
                    {
                        tran.Rollback();
                        throw;
                    }
                }
            }
        }
    }
}
