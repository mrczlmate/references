using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LegitarsasagT1.Entity;

namespace LegitarsasagT1.Service
{
    public interface ICityService
    {
        City FindById(int id);
        List<City> FindAll();
        City Save(City city);
        City Update(int id, City city);
        void Delete(int id);
    }
}
