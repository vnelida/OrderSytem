using Data.Interfaces;
using Entities.Dtos;
using Entities.Entities;
using Entities.Enums;
using Services.Interfaces;
using System.Data.SqlClient;

namespace Services.Services
{
    public class StatesProvincesService : IStatesProvincesService
    {
        private readonly IStatesProvincesRepository? _repository;
        private readonly string? _cadena;
        public StatesProvincesService(IStatesProvincesRepository repository, string cadena)
        {
            _repository = repository ?? throw new ApplicationException("Dependencies not loaded."); ;
            _cadena = cadena;
        }
        public void Delete(int stateProvinceId)
        {
            using (var conn = new SqlConnection(_cadena))
            {
                conn.Open();

                using (var tran = conn.BeginTransaction())
                {
                    try
                    {
                        _repository!.Delete(stateProvinceId, conn, tran);
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

        public bool Exist(StateProvince sp)
        {
            using (var conn = new SqlConnection(_cadena))
            {
                conn.Open();
                return _repository!.Exist(sp, conn);
            }
        }

        public int GetCount(Country? country)
        {
            using (var conn = new SqlConnection(_cadena))
            {
                conn.Open();
                return _repository!.GetCount(conn, country);

            }
        }

        public List<StateProvinceListDto> GetLista(int? currentPage, int? pageSize, Order? orden = Order.None, Country? selectedCountry = null)
        {
            using (var conn = new SqlConnection(_cadena))
            {
                conn.Open();
                return _repository!.GetList(conn, currentPage, pageSize, orden, selectedCountry);
            }
        }

        public List<StateProvince> GetListComboStates(Country country)
        {
            using (var conn = new SqlConnection(_cadena))
            {
                conn.Open();
                return _repository!.GetListComboStates(country, conn);

            }
        }

        public int GetPageByRecord(string stateProvinceName, int pageSize)
        {
            using (var conn = new SqlConnection(_cadena))
            {
                conn.Open();
                return _repository!.GetPageByRecord(conn, stateProvinceName, pageSize);
            }
        }

        public StateProvince? GetStateProvinceById(int stateProvinceId)
        {
            using (var conn = new SqlConnection(_cadena))
            {
                conn.Open();
                return _repository!.GetStateProvinceById(stateProvinceId, conn);
            }
        }

        public bool IsRelated(int stateProvinceId)
        {
            using (var conn = new SqlConnection(_cadena))
            {
                conn.Open();
                return _repository!.IsRelated(stateProvinceId, conn);
            }
        }

        public void Save(StateProvince sp)
        {
            using (var conn = new SqlConnection(_cadena))
            {
                conn.Open();
                using (var tran = conn.BeginTransaction())
                {
                    try
                    {
                        if (sp.StateProvinceId == 0)
                        {
                            _repository!.Add(sp, conn, tran);
                        }
                        else
                        {
                            _repository!.Edit(sp, conn, tran);
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
