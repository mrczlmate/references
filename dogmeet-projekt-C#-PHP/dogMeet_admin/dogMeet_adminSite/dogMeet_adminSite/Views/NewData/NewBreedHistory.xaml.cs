using dogMeet_adminSite.DataManage;
using dogMeet_adminSite.Model;
using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace dogMeet_adminSite.Views.NewData
{
    /// <summary>
    /// Interaction logic for NewBreedHistory.xaml
    /// </summary>
    public partial class NewBreedHistory : Window
    {
        public NewBreedHistory()
        {
            InitializeComponent();
            ShowData showData = new();
            showData.ShowDatas<DogHistory>(DatasDG, "doghistory");
        }

        private readonly int dogId;

        public NewBreedHistory(int dogid)
        {
            InitializeComponent();
            ShowData showData = new();
            showData.ShowDatas<DogHistory>(DatasDG, "doghistory");
            dogId = dogid;
        }

        private void Finish_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new();
            GetWindow(mainWindow).Show();
            Close();
        }

        private async void Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Flurl.Http.IFlurlResponse newdogdata = await NewDatas.Newdoghistory(breededwithtypeTB.Text,
                                                          Convert.ToInt32(kidsbornTB.Text),
                                                          Convert.ToDateTime(dateDP.Text), dogId);
                ShowData showData = new();
                showData.ShowDatas<DogHistory>(DatasDG, "doghistory");
            }
            catch
            {
                MessageBox.Show("Hibás adatbevitel");
            }
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

        private void NumberValidationTextbox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
