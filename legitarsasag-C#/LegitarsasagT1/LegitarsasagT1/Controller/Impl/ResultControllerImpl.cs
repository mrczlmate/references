using System.Collections.Generic;
using LegitarsasagT1.Service;
using LegitarsasagT1.Entity;

namespace LegitarsasagT1.Controller.Impl
{
    public class ResultControllerImpl : ResultControllerBase
    {
        private readonly IResultService resultService;

        public ResultControllerImpl(IResultService resultService)
        {
            this.resultService = resultService;
        }

        public override List<Flight> AllFlight()
        {
            return resultService.AllFlight();
        }

        public override List<Flight> AllFlightByAirline(int id)
        {
            return resultService.AllFlightByAirline(id);
        }
    }
}