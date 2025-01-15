using System.Collections.Generic;
using LegitarsasagT1.Entity;
using LegitarsasagT1.Service;
using Microsoft.AspNetCore.Http;

namespace LegitarsasagT1.Controller.Impl
{
    public class UploadControllerImpl : UploadControllerBase
    {
        private readonly IUploadService uploadService;

        public UploadControllerImpl(IUploadService uploadService)
        {
            this.uploadService = uploadService;
        }

        public override List<City> ReadCity(IFormFile file)
        {
            return uploadService.LoadCityData(file.OpenReadStream());
        }

        public override List<Flight> ReadFlight(IFormFile file)
        {
            return uploadService.LoadFlightData(file.OpenReadStream());
        }
    }
}