using Data.Interfaces;
using Entities.Dtos;
using Entities.Entities;
using Entities.Enums;
using Services.Interfaces;
using System.Data.SqlClient;

namespace Services.Services
{
    public class SalesService : ISalesService
    {
        private readonly ISalesRepository _repository;
        private readonly ISaleDetailsRepository? _repositoryDetails;
        private readonly IItemsService _itemsService;
        private readonly IPaymentRepository _paymentRepository;
        private readonly string? _cadena;
        public SalesService(ISalesRepository? repository, ISaleDetailsRepository repositoryDetails, IItemsService itemsService, IPaymentRepository paymentRepository, string? cadena)
        {
            _repository = repository ?? throw new ApplicationException("Dependencies not loaded");
            _repositoryDetails = repositoryDetails ?? throw new ApplicationException("Dependencies not loaded");
            _itemsService = itemsService ?? throw new ApplicationException("items");
            _paymentRepository = paymentRepository ?? throw new ApplicationException();
            _cadena = cadena;
        }
        public List<SalesListDto> GetListt(int currentPage, int pageSize, OrderTypes? orderType = null, OrderStatuses? status = null, Order? order = null)
        {
            using (var conn = new SqlConnection(_cadena))
            {
                conn.Open();
                return _repository.GetSalesListt(conn, currentPage, pageSize, orderType, status, order);
            }
        }

        public int GetCountt(OrderTypes? orderType = null, OrderStatuses? status = null)
        {
            using (var conn = new SqlConnection(_cadena))
            {
                conn.Open();
                return _repository.GetSalesCountt(conn, orderType, status);
            }
        }
        public void CancelSale(int saleId)
        {
            using (var conn = new SqlConnection(_cadena))
            {
                conn.Open();
                using (var tran = conn.BeginTransaction())
                {
                    try
                    {
                        var saleDetails = _repository.GetSaleDetailsBySaleId(saleId, conn, tran);

                        _itemsService.RevertStock(saleDetails, conn, tran);

                        _repository.UpdateSaleStatus(saleId, (int)OrderStatuses.Cancelled, conn, tran);

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

        public int GetCount(Func<SalesListDto, bool>? filter)
        {
            using (var conn = new SqlConnection(_cadena))
            {
                conn.Open();
                return _repository!.GetCaount(conn, filter);
            }
        }

        public List<SalesListDto> GetList(int currentPage, int pageSize, Func<SalesListDto, bool>? filter = null, Order? orderBy = null)
        {
            using (var conn = new SqlConnection(_cadena))
            {
                conn.Open();
                return _repository!.GetList(conn,
                currentPage,
                pageSize);
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
        public void UpdateOrderStatus(int saleId, OrderStatuses newStatus)
        {
            using (var conn = new SqlConnection(_cadena))
            {
                conn.Open();
                SqlTransaction? tran = conn.BeginTransaction();
                try
                {
                    Sale? saleToUpdate = _repository.GetSaleById(conn, saleId, tran);

                    if (saleToUpdate == null)
                    {
                        throw new ApplicationException("Sale not found.");
                    }
                    saleToUpdate.OrderStatusId = (int)newStatus;

                    _repository.Edit(saleToUpdate, conn, tran);

                    tran.Commit();
                }
                catch
                {
                    tran.Rollback();
                    throw;
                }
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
                                _itemsService!.DeductStock(item, conn, tran);
                                _repositoryDetails!.Add(item, conn, tran);
                            }
                            foreach (var payment in sale.Payments)
                            {
                                payment.SaleId = sale.SaleId;
                                _paymentRepository.Add(payment, conn, tran);
                            }
                        }

                        else
                        {

                            _repository!.Edit(sale, conn, tran);
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

        public void SavePayment(Payment payment)
        {
            using (var conn = new SqlConnection(_cadena))
            {
                conn.Open();
                using (var tran = conn.BeginTransaction())
                {
                    try
                    {
                        _repository.SavePayment(payment, conn, tran);

                        tran.Commit();
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        throw new Exception("Error", ex);
                    }
                }
            }
        }

        public List<PaymentReportDto> GetPaymentReport(DateTime firstDate, DateTime secDate)
        {
            using (var conn = new SqlConnection(_cadena))
            {
                conn.Open();
                return _repository.GetPaymentReport(conn, firstDate, secDate);
            }
        }
    }
}
