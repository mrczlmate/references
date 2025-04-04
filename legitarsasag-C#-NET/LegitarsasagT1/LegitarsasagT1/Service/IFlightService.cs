using System.Collections.Generic;
using LegitarsasagT1.Entity;

namespace LegitarsasagT1.Service
{
    public interface IFlightService
    {
        Flight FindById(int id);
        List<Flight> FindAll();
        Flight Save(Flight flight);
        Flight Update(int id, Flight flight);
        void Delete(int id);
        List<Flight> Way(int fromCityId, int toCityId);
    }
}
