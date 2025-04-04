using dogMeet_adminSite.DataManage;
using dogMeet_adminSite.Model;
using System;
using System.Windows;
using System.Windows.Input;
using System.Text.RegularExpressions;
using System.Text.Json;
using Flurl.Http;

namespace dogMeet_adminSite.Views.ModifyData
{
    /// <summary>
    /// Interaction logic for ModifyBreedHistory.xaml
    /// </summary>
    public partial class ModifyBreedHistory : Window
    {
        public ModifyBreedHistory()
        {
            InitializeComponent();
            ShowData showData = new();
            showData.ShowDatas<DogHistory>(DatasDG, "doghistory");
        }

        private async void Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var newdogdata = await NewDatas.Newdoghistory(newBreededwithtypeTB.Text, Convert.ToInt32(newKidsbornTB.Text),
                                                          Convert.ToDateTime(newDateDP.Text), Convert.ToInt32(newDogId.Text));
                ShowData showData = new();
                showData.ShowDatas<DogHistory>(DatasDG, "doghistory");
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void Finish_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new();
            GetWindow(mainWindow).Show();
            Close();
        }

        private async void Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                System.Net.Http.HttpResponseMessage responsemessage = await DeleteData.Delete(
                                                    Convert.ToInt32(DeleteByIdTB.Text), "doghistory");
                MessageBox.Show("Az adat sikeresen törölve");
                ShowData showData = new();
                showData.ShowDatas<DogHistory>(DatasDG, "doghistory");
            }
            catch
            {
                MessageBox.Show("Hibás adatbevitel");
            }
        }

        private async void Modify_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                IFlurlResponse modifyaddress = await ModifyDatas.Modifybreedhistory(modifyBreededwithtypeTB.Text,
                                                                         Convert.ToInt32(modifyKidsbornTB.Text),
                                                                         Convert.ToDateTime(modifyDateDP.Text),
                                                                         Convert.ToInt32(dogIdTB.Text));

                MessageBox.Show("Az adat sikeresen módosítva");
                ShowData showData = new();
                showData.ShowDatas<DogHistory>(DatasDG, "doghistory");
                modifyB.IsEnabled = false;
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
                string dataformodify = await $"{route}doghistory/{dogIdTB.Text}?token={Token.token}".GetStringAsync();
                DogHistory getresponse = JsonSerializer.Deserialize<DogHistory>(dataformodify);
                modifyDateDP.Text = Convert.ToString(getresponse.date);
                modifyBreededwithtypeTB.Text = getresponse.breededWith_Type;
                modifyKidsbornTB.Text = Convert.ToString(getresponse.kidsBorn);
                modifyB.IsEnabled = true;
            }
            catch
            {
                MessageBox.Show("Hibás Id");
            }
        }
    }
}
