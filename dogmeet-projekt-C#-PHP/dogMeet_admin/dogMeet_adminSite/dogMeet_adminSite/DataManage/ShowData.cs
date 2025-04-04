using Flurl.Http;
using System;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;

namespace dogMeet_adminSite.DataManage
{
    internal class ShowData
    {
        public async void ShowDatas<T>(DataGrid grid, string table)
        {
            try
            {
                ApiCallRoute apiCallRoute = new ApiCallRoute();
                string route = apiCallRoute.Route;
                var profilesresponse = await $"{route}{table}?token={Token.token}".GetAsync();
                var valtozo = profilesresponse.GetStringAsync();
                JSonData<T> profiles = JsonSerializer.Deserialize<JSonData<T>>(valtozo.Result);
                profiles.AddToDataGrid(grid);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }
    }
}
