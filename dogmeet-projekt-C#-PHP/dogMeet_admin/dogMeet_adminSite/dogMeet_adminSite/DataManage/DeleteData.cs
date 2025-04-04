using Flurl.Http;
using System.Net.Http;
using System.Threading.Tasks;

namespace dogMeet_adminSite.DataManage
{
    public class DeleteData
    {
        public static async Task<HttpResponseMessage> Delete(int id, string table)
        {
            ApiCallRoute apiCallRoute = new ApiCallRoute();
            string route = apiCallRoute.Route;
            string deleteurl = $"{route}{table}/{id}?token={Token.token}";
            IFlurlResponse responsemassage = await deleteurl.DeleteAsync();
            return responsemassage.ResponseMessage;
        }
    }
}
