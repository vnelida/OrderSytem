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
    public class SalesService : ISalesService
    {
        private readonly ISalesRepository _repository;
        private readonly ISaleDetailsRepository? _repositoryDetails;
        private readonly string? _cadena;
        public SalesService(ISalesRepository? repository, ISaleDetailsRepository repositoryDetails, string? cadena)
        {
            _repository = repository ?? throw new ApplicationException("Dependencies not loaded");
            _repositoryDetails = repositoryDetails ?? throw new ApplicationException("Dependencies not loaded");
            _cadena = cadena;
        }
        public int GetCount(Func<SalesListDto, bool>? filter)
        {
            using (var conn = new SqlConnection(_cadena))
            {
                conn.Open();
                return _repository!.GetCaount(conn, filter);
            }
        }

        public List<SalesListDto> GetList(int currentPage, int pageSize, Func<SalesListDto, bool>? filter = null)
        {
            using (var conn = new SqlConnection(_cadena))
            {
                conn.Open();
                return _repository!.GetList(conn, currentPage, pageSize, filter);
            }
        }

        public Sale? GetSaleById(int saleId)
        {
            using (var conn = new SqlConnection(_cadena))
            {
                conn.Open();
                return _repository!.GetSaleById(conn, saleId);
            }
        }

        public void Save(Sale? sale)
        {
            using (var conn = new SqlConnection(_cadena))
            {
                conn.Open();
                using (var tran = conn.BeginTransaction())
                {
                    try
                    {
                        if (sale.SaleId == 0)
                        {
                            _repository!.Add(sale, conn, tran);

                            foreach (var item in sale.Details)
                            {
                                item.SaleId = sale.SaleId;
                                _repositoryDetails!.Add(item, conn, tran);
                            }

                        }
                        else
                        {

                            _repository!.Edit(sale, conn, tran);
                            //TODO: Ver lo que quiere hacer Octavio
                            //foreach (var item in caja.Detalles)
                            //{
                            //    item.CajaId = caja.ProductoId;
                            //    _repositorioDetallesCajas.Agregar(item, conn, tran);
                            //}
                            //_repositorioDetallesCajas!.Borrar(caja.ProductoId, conn, tran);

                        }

                        tran.Commit();//guarda efectivamente
                    }
                    catch (Exception)
                    {
                        tran.Rollback();//tira todo pa tras!!!
                        throw;
                    }
                }
            }
        }
    }
}
