using dogMeet_adminSite.DataManage;
using dogMeet_adminSite.Model;
using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace dogMeet_adminSite.Views.NewData
{
    /// <summary>
    /// Interaction logic for NewBreedHistoryForExistingUser.xaml
    /// </summary>
    public partial class NewBreedHistoryForExistingUser : Window
    {
        public NewBreedHistoryForExistingUser()
        {
            InitializeComponent();
            ShowData showData = new();
            showData.ShowDatas<DogHistory>(DatasDG, "doghistory");
        }

        private readonly int newDogData;

        public NewBreedHistoryForExistingUser(int newdogdata)
        {
            InitializeComponent();
            newDogData = newdogdata;
            ShowData showData = new();
            showData.ShowDatas<DogHistory>(DatasDG, "doghistory");
        }

        private async void Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var newdogdata = await NewDatas.Newdoghistory(breededwithtypeTB.Text, Convert.ToInt32(kidsbornTB.Text),
                                                          Convert.ToDateTime(dateDP.Text),newDogData);
                ShowData showData = new();
                showData.ShowDatas<DogHistory>(DatasDG, "doghistory");
            }
            catch
            {
                MessageBox.Show("Hibás adatbevitel");
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
                var responsemessage = await DeleteData.Delete(Convert.ToInt32(DeleteByIdTB.Text), "doghistory");
                MessageBox.Show("Az adat sikeresen törölve");
                ShowData showData = new();
                showData.ShowDatas<DogHistory>(DatasDG, "doghistory");
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
