using Data.Interfaces;
using Entities.Entities;
using Services.Interfaces;
using System.Data.SqlClient;

namespace Services.Services
{
    public class CategoriesService : ICategoriesService
    {
        private readonly ICategoriesRepository? _repository;
        private readonly string? _cadena;

        public CategoriesService(ICategoriesRepository? repository, string? cadena)
        {
            _repository = repository;
            _cadena = cadena;
        }
        public void Delete(int categoryId)
        {
            using (var conn = new SqlConnection(_cadena))
            {
                conn.Open();
                using (var tran = conn.BeginTransaction())
                {
                    try
                    {
                        _repository!.Delete(categoryId, conn, tran);
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

        public bool Exist(Category category)
        {
            using (var conn = new SqlConnection(_cadena))
            {
                return _repository!.Exist(category, conn);

            }
        }

        public Category? GetCategoryByName(string categoryName)
        {
            using (var conn = new SqlConnection(_cadena))
            {
                conn.Open();
                var category = _repository!.GetCategoryByName(categoryName, conn);
                return category;
            }
        }

        public List<Category> GetList()
        {
            using (var conn = new SqlConnection(_cadena))
            {
                return _repository!.GetList(conn);

            }
        }

        public bool IsRelated(int categoryId)
        {
            using (var conn = new SqlConnection(_cadena))
            {
                conn.Open();
                return _repository!.IsRelated(categoryId, conn);
            }
        }

        public void Save(Category category)
        {
            using (var conn = new SqlConnection(_cadena))
            {
                conn.Open();
                using (var tran = conn.BeginTransaction())
                {
                    try
                    {
                        if (category.CategoryId == 0)
                        {
                            _repository!.Add(category, conn, tran);
                        }
                        else
                        {
                            _repository!.Edit(category, conn, tran);
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
