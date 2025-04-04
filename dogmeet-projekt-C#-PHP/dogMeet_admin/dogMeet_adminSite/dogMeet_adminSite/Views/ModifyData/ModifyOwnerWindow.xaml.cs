using dogMeet_adminSite.DataManage;
using dogMeet_adminSite.Model;
using System;
using System.Windows;
using System.Windows.Input;
using System.Text.RegularExpressions;
using Flurl.Http;
using System.Text.Json;

namespace dogMeet_adminSite.Views.ModifyData
{
    /// <summary>
    /// Interaction logic for ModifyOwnerWindow.xaml
    /// </summary>
    public partial class ModifyOwnerWindow : Window
    {
        public ModifyOwnerWindow()
        {
            InitializeComponent();
            ShowData showData = new();
            showData.ShowDatas<Profile>(ProfileDataDG, "profile");
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
                if (profileidTB.Text != "")
                {
                    IFlurlResponse modifyprofile = await ModifyDatas.Modifyprofile(firstnameTB.Text, lastnameTB.Text,
                                                                        phoneTB.Text, Convert.ToInt32(profileidTB.Text));
                }

                MainWindow mainWindow = new();
                GetWindow(mainWindow).Show();
                Close();
            }
            catch (Exception err)
            {
                MessageBox.Show("Hibás adatbevitel" + err.Message);
            }
        }

        private void NumberValidationTextbox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private async void LoadDataProfile_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ApiCallRoute apiCallRoute = new ApiCallRoute();
                string route = apiCallRoute.Route;
                var dataformodify = await $"{route}profile/{profileidTB.Text}?token={Token.token}".GetStringAsync();

                var getresponse = JsonSerializer.Deserialize<DataWrapper<Profile>>(dataformodify).data;
                firstnameTB.Text = getresponse.firstName;
                lastnameTB.Text = getresponse.lastName;
                phoneTB.Text = getresponse.phoneNumber;
                ModifyB.IsEnabled = true;
            }
            catch
            {
                MessageBox.Show("Hibás Id");
            }
        }
    }
}
