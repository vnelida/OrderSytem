using Entities.Entities;

namespace Services.Interfaces
{
    public interface IPaymentMethodService
    {
        List<PaymentMethod> GetList();
    }
}
