using System.Collections.Generic;
using System.IO;
using LegitarsasagT1.Entity;

namespace LegitarsasagT1.Service
{
    public interface IUploadService
    {
        List<City> LoadCityData(Stream inputStream);

        List<Flight> LoadFlightData(Stream inputStream);
    }
}
