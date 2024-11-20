using Data.Interfaces;
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
    public class CountriesService : ICountriesService
    {
        private readonly ICountriesRepository? _repository;
        private readonly string _cadena;
        public CountriesService(ICountriesRepository? repository, string cadena)
        {
            _repository = repository ?? throw new ApplicationException("Dependencies not loaded"); ;
            _cadena = cadena;
        }

        public void Delete(int countryId)
        {
            using (var conn = new SqlConnection(_cadena))
            {
                conn.Open();
                using (var tran = conn.BeginTransaction())
                {
                    try
                    {
                        _repository!.Delete(countryId, conn, tran);
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

        public bool Exist(Country country)
        {
            using (var conn = new SqlConnection(_cadena))
            {
                conn.Open();
                return _repository!.Exist(country, conn);
            }
        }

        public int GetCount()
        {
            using (var conn = new SqlConnection(_cadena))
            {
                conn.Open();
                return _repository!.GetCount(conn);
            }
        }

        public Country? GetCountryById(int countryId)
        {
            using (var conn = new SqlConnection(_cadena))
            {
                return _repository!.GetCountryById(countryId, conn);
            }
        }

        public List<Country>? GetList(int? currentPage, int? pageSize)
        {
            using (var conn = new SqlConnection(_cadena))
            {
                conn.Open();
                return _repository!.GetList(conn, currentPage, pageSize);
            }
        }

        public int GetPageByRecord(string countryName, int pageSize)
        {
            using (var conn = new SqlConnection(_cadena))
            {
                conn.Open();
                return _repository!.GetPageByRecord(conn, countryName, pageSize);
            }
        }

        public bool IsRelated(int countryId)
        {
            using (var conn = new SqlConnection(_cadena))
            {
                conn.Open();
                return _repository!.IsRelated(countryId, conn);
            }
        }

        public void Save(Country country)
        {
            using (var conn = new SqlConnection(_cadena))
            {
                conn.Open();
                using (var tran = conn.BeginTransaction())
                {
                    try
                    {
                        if (country.CountryId == 0)
                        {
                            _repository!.Add(country, conn, tran);
                        }
                        else
                        {
                            _repository!.Edit(country, conn, tran);
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
