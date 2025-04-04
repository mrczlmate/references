
namespace dogMeet_adminSite
{
    class ApiCallRoute
    {
        public string Route { get; set; }
        public ApiCallRoute()
        {
            Route = "http://localhost:8881/api/admin/";
          //Route = "https://dogmeet.duckdns.org/api/admin/";
        }
    }
}
