using dogMeet_adminSite.DataManage;
using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace dogMeet_adminSite.Views.NewData
{
    /// <summary>
    /// Interaction logic for NewLocationWindow.xaml
    /// </summary>
    public partial class NewLocationWindow : Window
    {
        public NewLocationWindow()
        {
            InitializeComponent();
        }

        private readonly int profileId;
        private readonly int newUserData;

        public NewLocationWindow(int profileid, int newuserdata)
        {
            InitializeComponent();
            profileId = profileid;
            newUserData = newuserdata;
        }

        private async void Next_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Flurl.Http.IFlurlResponse newaddressdata = await NewDatas.Newaddress(countryTB.Text, stateTB.Text,
                                                               cityTB.Text, Convert.ToInt32(zipTB.Text),
                                                               stateTB.Text, Convert.ToInt32(houseNumberTB.Text),
                                                               profileId);

                NewDogWindow newDogWindow = new(newUserData);
                GetWindow(newDogWindow).Show();
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
    }
}
