using System.Collections.Generic;
using LegitarsasagT1.Entity;

namespace LegitarsasagT1.Service
{
    public interface IAirlineService
    {
        Airline FindById(int id);
        List<Airline> FindAll();
        Airline Save(Airline airline);
        Airline Update(int id, Airline airline);
        void Delete(int id);
        List<Flight> FlightsByAirline(int id);
    }
}
