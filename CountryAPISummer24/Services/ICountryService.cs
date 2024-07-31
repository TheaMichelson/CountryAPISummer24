using CountryAPISummer24.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountryAPISummer24.Services
{
    public interface ICountryService
    {
        Task<List<Country>> GetCountriesAsync();
    }
}
