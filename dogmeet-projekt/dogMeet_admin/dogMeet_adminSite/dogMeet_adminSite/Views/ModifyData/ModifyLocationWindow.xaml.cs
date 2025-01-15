using dogMeet_adminSite.DataManage;
using dogMeet_adminSite.Model;
using Flurl.Http;
using System;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace dogMeet_adminSite.Views.ModifyData
{
    /// <summary>
    /// Interaction logic for ModifyLocationWindow.xaml
    /// </summary>
    public partial class ModifyLocationWindow : Window
    {
        public ModifyLocationWindow()
        {
            InitializeComponent();
            ShowData showData = new();
            showData.ShowDatas<Address>(locationDataDG, "address");
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new();
            GetWindow(mainWindow).Show();
            Close();
        }

        private async void Finish_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                IFlurlResponse modifyaddress = await ModifyDatas.Modifyaddress(countryTB.Text, stateTB.Text, cityTB.Text,
                                                                    Convert.ToInt32(zipTB.Text), streetTB.Text,
                                                                    Convert.ToInt32(housenumberTB.Text),
                                                                    Convert.ToInt32(addressidTB.Text));
                MainWindow mainWindow = new();
                GetWindow(mainWindow).Show();
                Close();
            }
            catch
            {
                MessageBox.Show("Hibás adatbevitel");
            }
        }

        private void NumberValidationTextbox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private async void LoadData_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ApiCallRoute apiCallRoute = new ApiCallRoute();
                string route = apiCallRoute.Route;
                string dataformodify = await $"{route}address/{addressidTB.Text}?token={Token.token}".GetStringAsync();
                Address getresponse = JsonSerializer.Deserialize<Address>(dataformodify);
                countryTB.Text = getresponse.country;
                stateTB.Text = getresponse.state;
                cityTB.Text = getresponse.city;
                zipTB.Text = Convert.ToString(getresponse.zip);
                streetTB.Text = getresponse.street;
                housenumberTB.Text = Convert.ToString(getresponse.houseNumber);
                ModifyB.IsEnabled = true;
            }
            catch
            {
                MessageBox.Show("Hibás Id");
            }
        }
    }
}
