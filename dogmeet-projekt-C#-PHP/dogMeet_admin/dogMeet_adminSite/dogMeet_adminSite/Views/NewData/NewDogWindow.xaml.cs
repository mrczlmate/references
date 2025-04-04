using dogMeet_adminSite.DataManage;
using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace dogMeet_adminSite.Views.NewData
{
    /// <summary>
    /// Interaction logic for NewDogWindow.xaml
    /// </summary>
    public partial class NewDogWindow : Window
    {
        public NewDogWindow()
        {
            InitializeComponent();
            genderTB.Items.Add("kan");
            genderTB.Items.Add("szuka");           
        }

        private readonly int newUserData;

        public NewDogWindow(int newuserdata)
        {
            InitializeComponent();
            genderTB.Items.Add("kan");
            genderTB.Items.Add("szuka");
            newUserData = newuserdata;
        }

        private async void BreedHistory_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var newdogdata = await NewDatas.Newdog(nameTB.Text, Convert.ToInt32(ageTB.Text), typeTB.Text,
                                                        genderTB.Text, descriptionTB.Text, newUserData);

                NewBreedHistory newBreedHistory = new(newdogdata);
                GetWindow(newBreedHistory).Show();
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
