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
    /// Interaction logic for ModifyDogwindow.xaml
    /// </summary>
    public partial class ModifyDogwindow : Window
    {
        public ModifyDogwindow()
        {
            InitializeComponent();
            genderCB.Items.Add("kan");
            genderCB.Items.Add("szuka");
            ShowData showData = new();
            showData.ShowDatas<Dog>(DogDataDG, "dog");
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
                var modifydog = await ModifyDatas.Modifydog(nameTB.Text, Convert.ToInt32(ageTB.Text), typeTB.Text,
                                                      genderCB.Text, descriptionTB.Text, Convert.ToInt32(dogId.Text));

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
                string dataformodify = await $"{route}dog/{dogId.Text}?token={Token.token}".GetStringAsync();
                Dog getresponse = JsonSerializer.Deserialize<Dog>(dataformodify);
                nameTB.Text = getresponse.name;
                ageTB.Text = Convert.ToString(getresponse.age);
                typeTB.Text = getresponse.type;
                genderCB.Text = getresponse.gender;
                descriptionTB.Text = getresponse.description;
                nextB.IsEnabled = true;
            }
            catch
            {
                MessageBox.Show("Hibás Id");
            }
        }
    }
}
