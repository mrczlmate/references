using LegitarsasagT1.Entity;
using System.Collections.Generic;
using LegitarsasagT1.Service;

namespace LegitarsasagT1.Controller.Impl
{
    public class FlightControllerImpl : FlightControllerBase
    {
        private readonly IFlightService flightService;

        public FlightControllerImpl(IFlightService flightService)
        {
            this.flightService = flightService;
        }

        public override void Delete(int id)
        {
            flightService.Delete(id);
        }

        public override List<Flight> Way(int fromCityId, int toCityId)
        {
            return flightService.Way(fromCityId, toCityId);
        }

        public override List<Flight> FindAll()
        {
            return flightService.FindAll();
        }

        public override Flight FindById(int id)
        {
            return flightService.FindById(id);
        }

        public override Flight Save(Flight flight)
        {
            return flightService.Save(flight);
        }

        public override Flight Update(int id, Flight flight)
        {
            return flightService.Update(id, flight);
        }
    }
}
