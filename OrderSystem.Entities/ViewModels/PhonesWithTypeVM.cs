using Entities.Entities;

namespace Entities.ViewModels
{
    public class PhonesWithTypeVM
    {
        public Phone Phone { get; set; }
        public PhoneType? PhoneType { get; set; }

        public PhonesWithTypeVM(Phone phone, PhoneType? phoneType)
        {
            Phone = phone;
            PhoneType = phoneType;
        }
        public override string ToString()
        {
            return $"{Phone.ToString()} - {PhoneType?.Description}";
        }
    }
}
