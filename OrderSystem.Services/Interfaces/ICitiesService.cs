﻿using Entities.Dtos;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface ICitiesService
    {
        void Delete(int cityId);
        bool IsRelated(int cityId);
        bool Exist(City city);
        int GetCount(Country? selectedCountry = null, StateProvince? selectedStateProvince = null);
        City? GetCityById(int cityId);
        List<CityListDto> GetList(int? currentPage, int? pageSize);
        List<City> GetListCombo(Country selectedCountry, StateProvince selectedStateProvince);
        int GetPageByRecord(string nombreCiudad, int pageSize);
        void Save(City city);
    }
}
