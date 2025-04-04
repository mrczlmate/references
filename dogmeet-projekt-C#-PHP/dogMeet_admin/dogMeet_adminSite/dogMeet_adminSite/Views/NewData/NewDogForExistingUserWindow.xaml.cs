using dogMeet_adminSite.DataManage;
using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace dogMeet_adminSite.Views.NewData
{
    /// <summary>
    /// Interaction logic for NewDogForExistingUserWindow.xaml
    /// </summary>
    public partial class NewDogForExistingUserWindow : Window
    {
        public NewDogForExistingUserWindow()
        {
            InitializeComponent();
            genderTB.Items.Add("kan");
            genderTB.Items.Add("szuka");
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new();
            GetWindow(mainWindow).Show();
            Close();
        }

        private async void BreedHistory_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var newdogdata = await NewDatas.Newdog(nameTB.Text, Convert.ToInt32(ageTB.Text), typeTB.Text,
                                                       genderTB.Text, descriptionTB.Text,
                                                       Convert.ToInt32(ownerTB.Text));

                NewBreedHistoryForExistingUser newBreedHistoryForExistingUser = new(newdogdata);
                GetWindow(newBreedHistoryForExistingUser).Show();
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
