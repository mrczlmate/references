using Flurl.Http;
using System;
using System.Threading.Tasks;
using System.Text.Json;

namespace dogMeet_adminSite.DataManage
{
    public class NewDatas
    {
        private class Ids
        {
            public int id { get; set; }
        }

        public static async Task<int> Newuser(string username, string email, string password, string confirmpassword)
        {
            ApiCallRoute apiCallRoute = new ApiCallRoute();
            string route = apiCallRoute.Route;
            IFlurlResponse newuserjson = await $"{route}user?token={Token.token}".PostJsonAsync(new { username = username,
                                                                        email = email, password = password,
                                                                        password_confirmation = confirmpassword });

            var userresponse = newuserjson.GetStringAsync();
            Ids getresponse = JsonSerializer.Deserialize<Ids>(userresponse.Result);
            return getresponse.id;
        }

        public static async Task<int> Newprofile(string firstname, string lastname, string phone, int userid)
        {
            ApiCallRoute apiCallRoute = new ApiCallRoute();
            string route = apiCallRoute.Route;
            IFlurlResponse newprofilejson = await $"{route}profile?token={Token.token}".PostJsonAsync(
                                                                    new { user_id = userid, firstName = firstname,
                                                                    lastName = lastname, phoneNumber = phone});

            var profileresponse = await newprofilejson.GetStringAsync();
            Ids getresponse = JsonSerializer.Deserialize<Ids>(profileresponse);
            return getresponse.id;
        }

        public static async Task<IFlurlResponse> Newaddress(string country, string state, string city, int zip, string street, int housenumber, int profileid)
        {
            ApiCallRoute apiCallRoute = new ApiCallRoute();
            string route = apiCallRoute.Route;
            IFlurlResponse newaddressjson = await $"{route}address?token={Token.token}".PostJsonAsync(new {
                                                                        profile_id = profileid, country = country,
                                                                        state = state, city = city, zip = zip,
                                                                        street = street, houseNumber = housenumber
                                                                    });

            return newaddressjson;
        }

        public static async Task<int> Newdog(string name, int age, string type, string gender, string description, int ownerid)
        {
            ApiCallRoute apiCallRoute = new ApiCallRoute();
            string route = apiCallRoute.Route;
            IFlurlResponse newdogjson = await $"{route}dog?token={Token.token}".PostJsonAsync(new {
                                                                    name = name,
                                                                    age= age,
                                                                    type= type,
                                                                    gender= gender,
                                                                    description= description,
                                                                    owner_id = ownerid
                                                                });
            var dogresponse = await newdogjson.GetStringAsync();
            Ids getresponse = JsonSerializer.Deserialize<Ids>(dogresponse);
            return getresponse.id;
        }

        public static async Task<IFlurlResponse> Newdoghistory(string breededwithtype, int kidsborn, DateTime date, int dogid)
        {
            ApiCallRoute apiCallRoute = new ApiCallRoute();
            string route = apiCallRoute.Route;
            IFlurlResponse newdoghistoryjson = await $"{route}doghistory?token={Token.token}".PostJsonAsync(new {
                                                                        breededWith_Type = breededwithtype,
                                                                        kidsBorn = kidsborn, date = date,
                                                                        dog_id = dogid
                                                                    });

            return newdoghistoryjson;
        }
    }
}