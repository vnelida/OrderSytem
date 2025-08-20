using Entities.Dtos;
using Entities.Entities;
using Entities.Enums;

namespace Services.Interfaces
{
    public interface ISalesService
    {
        List<SalesListDto> GetListt(int currentPage, int pageSize, OrderTypes? orderType = null, OrderStatuses? status = null, Order? order = null);
        int GetCountt(OrderTypes? orderType = null, OrderStatuses? status = null);
        void CancelSale(int saleId);
        int GetCount(Func<SalesListDto, bool>? filter);
        List<SalesListDto> GetList(int currentPage, int pageSize, Func<SalesListDto, bool>? filter = null,Order ? orderBy = null);
        Sale? GetSaleById(int saleId);
        void Save(Sale? sale);
        void UpdateOrderStatus(int saleId, OrderStatuses completed);
        void SavePayment(Payment payment);
        List<PaymentReportDto> GetPaymentReport(DateTime firstDate, DateTime secDate);
    }
}
