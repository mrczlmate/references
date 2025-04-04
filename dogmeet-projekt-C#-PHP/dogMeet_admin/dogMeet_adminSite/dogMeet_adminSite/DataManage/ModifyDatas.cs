using dogMeet_adminSite.Model;
using Flurl.Http;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace dogMeet_adminSite.DataManage
{
    public class ModifyDatas
    {
        private class Ids
        {
            public int id { get; set; }
        }

        public static async Task<IFlurlResponse> Modifyuser(string username, string email, string password,
                                                            string confirmpassword, int id)
        {
            ApiCallRoute apiCallRoute = new ApiCallRoute();
            string route = apiCallRoute.Route;
            IFlurlResponse modifyuserjson = await $"{route}user/{id}?token={Token.token}".PutJsonAsync(new {
                username = username,
                email = email,
                password = password,
                password_confirmation = confirmpassword
            });
            return modifyuserjson;
        }

        public static async Task<IFlurlResponse> Modifyprofile(string firstname, string lastname,
                                                               string phone, int id)
        {
            ApiCallRoute apiCallRoute = new ApiCallRoute();
            string route = apiCallRoute.Route;
            string response = await $"{route}profile/{id}?token={Token.token}".GetStringAsync();
            var getresponse = JsonSerializer.Deserialize<DataWrapper<Profile>>(response).data;
            IFlurlResponse modifyprofilejson = await $"{route}profile/{id}?token={Token.token}".PutJsonAsync(new {
                                                                      firstName = firstname,
                                                                      lastName = lastname, phoneNumber = phone,
                                                                      user_id = getresponse.user_id
                                                                    });
            return modifyprofilejson;
        }

        public static async Task<IFlurlResponse> Modifyaddress(string country, string state, string city, int zip,
                                                               string street, int housenumber, int id)
        {
            ApiCallRoute apiCallRoute = new ApiCallRoute();
            string route = apiCallRoute.Route;
            string response = await $"{route}address/{id}?token={Token.token}".GetStringAsync();
            Address getresponse = JsonSerializer.Deserialize<Address>(response);
            IFlurlResponse modifyaddressjson = await $"{route}address/{id}?token={Token.token}".PutJsonAsync(new {
                                                                        country = country,
                                                                        state = state, city = city, zip = zip,
                                                                        street = street, houseNumber = housenumber,
                                                                        profile_id = getresponse.profile_id
                                                                    });
            return modifyaddressjson;
        }

        public static async Task<int> Modifydog(string name, int age, string type, string gender,
                                                               string description, int id)
        {
            ApiCallRoute apiCallRoute = new ApiCallRoute();
            string route = apiCallRoute.Route;
            string response = await $"{route}dog/{id}?token={Token.token}".GetStringAsync();
            Dog getresponse = JsonSerializer.Deserialize<Dog>(response);
            IFlurlResponse modifydogjson = await $"{route}dog/{id}?token={Token.token}".PutJsonAsync(new {
                                                                        name = name, age = age, type = type,
                                                                        gender = gender, description = description,
                                                                        owner_id = getresponse.owner_id
                                                                    });
            Ids getstringrespone = JsonSerializer.Deserialize<Ids>(response);
            return getstringrespone.id;
        }

        public static async Task<IFlurlResponse> Modifybreedhistory(string breededwith, int kidsborn, DateTime date,
                                                                    int id)
        {
            ApiCallRoute apiCallRoute = new ApiCallRoute();
            string route = apiCallRoute.Route;
            string response = await $"{route}doghistory/{id}?token={Token.token}".GetStringAsync();
            DogHistory getresponse = JsonSerializer.Deserialize<DogHistory>(response);
            IFlurlResponse modifybreedhistoryjson = await $"{route}doghistory/{id}?token={Token.token}".PutJsonAsync(new {
                                                                    breededWith_Type = breededwith,
                                                                    kidsBorn = kidsborn,
                                                                    date = date, dog_id = getresponse.dog_id
                                                                });
            return modifybreedhistoryjson;
        }
    }
}
