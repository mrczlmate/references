using LegitarsasagT1.Entity;
using System.Collections.Generic;
using LegitarsasagT1.Service;

namespace LegitarsasagT1.Controller.Impl
{
    public class CityControllerImpl : CityControllerBase
    {
        private readonly ICityService cityService;

        public CityControllerImpl(ICityService cityService)
        {
            this.cityService = cityService;
        }
        public override void Delete(int id)
        {
            cityService.Delete(id);
        }

        public override List<City> FindAll()
        {
            return cityService.FindAll();
        }

        public override City FindById(int id)
        {
            return cityService.FindById(id);
        }

        public override City Save(City city)
        {
            return cityService.Save(city);
        }

        public override City Update(int id, City city)
        {
            return cityService.Update(id, city);
        }
    }
}
