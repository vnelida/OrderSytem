using Entities.Dtos;
using Entities.Entities;
using Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IStatesProvincesService
    {
        void Delete(int stateProvinceId);
        bool IsRelated(int stateProvinceId);
        bool Exist(StateProvince sp);
        int GetCount(Country? country = null);
        List<StateProvinceListDto> GetLista(int? currentPage, int? pageSize, Order? orden = Order.None, Country? selectedCountry = null);
        List<StateProvince> GetListComboStates(Country country);
        int GetPageByRecord(string stateProvinceName, int pageSize);
        StateProvince? GetStateProvinceById(int stateProvinceId);
        void Save(StateProvince sp);
    }
}
