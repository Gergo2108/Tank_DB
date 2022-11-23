using K9P4EG_HFT_2022231.Models;
using System.Collections.Generic;

namespace K9P4EG_HFT_2022231.Logic
{
    public interface ICountryLogic
    {
        void Create(Country item);
        void Delete(int id);
        Country Read(int id);
        IEnumerable<Country> ReadAll();
        void Update(Country item);
    }
}