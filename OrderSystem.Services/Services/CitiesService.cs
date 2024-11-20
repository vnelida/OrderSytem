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
    public class CitiesService : ICitiesService
    {
        private readonly ICitiesRepository? _repository;
        private readonly string? _cadena;
        public CitiesService(ICitiesRepository? repository, string? cadena)
        {
            _repository = repository ?? throw new ApplicationException("Dependencies not loaded."); ;
            _cadena = cadena;
        }
        public void Delete(int cityId)
        {
            using (var conn = new SqlConnection(_cadena))
            {
                conn.Open();
                using (var tran = conn.BeginTransaction())
                {
                    try
                    {
                        _repository!.Delete(cityId, conn, tran);
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

        public bool Exist(City city)
        {
            using (var conn = new SqlConnection(_cadena))
            {
                conn.Open();
                return _repository!.Exist(city, conn);
            }
        }

        public City? GetCityById(int cityId)
        {
            using (var conn = new SqlConnection(_cadena))
            {
                return _repository!.GetCityById(cityId, conn);
            }

        }

        public int GetCount(Country? selectedCountry = null, StateProvince? selectedStateProvince = null)
        {
            using (var conn = new SqlConnection(_cadena))
            {
                conn.Open();
                return _repository!.GetCount(conn, selectedCountry, selectedStateProvince);
            }
        }

        public List<CityListDto> GetList(int? currentPage, int? pageSize)
        {
            using (var conn = new SqlConnection(_cadena))
            {
                conn.Open();
                return _repository!.GetList(conn, currentPage, pageSize);
            }
        }

        public List<City> GetListCombo(Country selectedCountry, StateProvince selectedStateProvince)
        {
            using (var conn = new SqlConnection(_cadena))
            {
                conn.Open();
                return _repository!.GetListCombo(conn, selectedCountry, selectedStateProvince);
            }
        }

        public int GetPageByRecord(string nombreCiudad, int pageSize)
        {
            using (var conn = new SqlConnection(_cadena))
            {
                conn.Open();
                return _repository!.GetPageByRecord(conn, nombreCiudad, pageSize);
            }
        }

        public bool IsRelated(int cityId)
        {
            using (var conn = new SqlConnection(_cadena))
            {
                conn.Open();
                return _repository!.IsRelated(cityId, conn);
            }
        }

        public void Save(City city)
        {
            using (var conn = new SqlConnection(_cadena))
            {
                conn.Open();
                using (var tran = conn.BeginTransaction())
                {
                    try
                    {
                        if (city.CityId == 0)
                        {
                            _repository!.Add(city, conn, tran);
                        }
                        else
                        {
                            _repository!.Add(city, conn, tran);
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
