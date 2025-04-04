using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LegitarsasagT1.Entity;

namespace LegitarsasagT1.Service
{
    public interface IResultService
    {
        List<Flight> AllFlight();
        List<Flight> AllFlightByAirline(int id);
    }
}
