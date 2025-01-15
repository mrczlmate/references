using System.Collections.Generic;
using LegitarsasagT1.Service;
using LegitarsasagT1.Entity;

namespace LegitarsasagT1.Controller.Impl
{
    public class AirlineControllerImpl : AirlineControllerBase
    {
        private readonly IAirlineService airlineService;

        public AirlineControllerImpl(IAirlineService airlineService)
        {
            this.airlineService = airlineService;
        }
        public override void Delete(int id)
        {
            airlineService.Delete(id);
        }

        public override List<Airline> FindAll()
        {
            return airlineService.FindAll();
        }

        public override Airline FindById(int id)
        {
            return airlineService.FindById(id);
        }

        public override Airline Save(Airline airline)
        {
            return airlineService.Save(airline);
        }

        public override Airline Update(int id, Airline airline)
        {
            return airlineService.Update(id, airline);
        }

        public override List<Flight> GetFlightsByAirline(int airlineId)
        {
            return airlineService.FlightsByAirline(airlineId);
        }
    }
}
