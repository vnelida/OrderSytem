using Entities.Entities;

namespace Entities.ViewModels
{
    public class PhonesWithTypeVM
    {
        public int PhoneId { get; set; } 
        public string PhoneNumber { get; set; } = null!;
        public int PhoneTypeId { get; set; } 
        public string PhoneTypeDescription { get; set; } = null!; 
        public CustomerPhone? CustomerPhoneEntity { get; set; }
        public PhonesWithTypeVM(CustomerPhone customerPhone)
        {
            PhoneId = customerPhone.Phone?.PhoneId ?? 0;
            PhoneNumber = customerPhone.Phone?.PhoneNumber ?? string.Empty;
            PhoneTypeId = customerPhone.PhoneType?.PhoneTypeId ?? 0;
            PhoneTypeDescription = customerPhone.PhoneType?.Description ?? "N/A";
            CustomerPhoneEntity = customerPhone; 
        }
        public PhonesWithTypeVM() { }
    }
}
