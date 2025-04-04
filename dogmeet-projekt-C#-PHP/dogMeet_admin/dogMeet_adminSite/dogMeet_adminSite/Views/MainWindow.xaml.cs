using dogMeet_adminSite.Views.ModifyData;
using dogMeet_adminSite.Views.NewData;
using System;
using System.Windows;
using dogMeet_adminSite.Model;
using dogMeet_adminSite.DataManage;

namespace dogMeet_adminSite.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();

            TablesCB.Items.Add("profile");
            TablesCB.Items.Add("user");
            TablesCB.Items.Add("address");
            TablesCB.Items.Add("dog");
            TablesCB.Items.Add("doghistory");
            TablesCB.Items.Add("dogpicture");
        }

        private void NewOwner_Click(object sender, RoutedEventArgs e)
        {
            NewOwnerWindow newOwnerWindow = new();
            GetWindow(newOwnerWindow).Show();
            Close();
        }

        private void ModifyOwner_Click(object sender, RoutedEventArgs e)
        {
            ModifyOwnerWindow modifyOwnerWindow = new();
            GetWindow(modifyOwnerWindow).Show();
            Close();
        }

        private void ModifyLocation_Click(object sender, RoutedEventArgs e)
        {
            ModifyLocationWindow modifyLocationWindow = new();
            GetWindow(modifyLocationWindow).Show();
            Close();
        }

        private void ModifyDog_Click(object sender, RoutedEventArgs e)
        {
            ModifyDogwindow modifyDogwindow = new();
            GetWindow(modifyDogwindow).Show();
            Close();
        }

        private void NewDogForExistingUser_Click(object sender, RoutedEventArgs e)
        {
            NewDogForExistingUserWindow newDogForExistingUserWindow = new();
            GetWindow(newDogForExistingUserWindow).Show();
            Close();
        }

        private void ShowDatas_Click(object sender, RoutedEventArgs e)
        {
            ShowData showData = new();

            switch (TablesCB.Text)
            {
                case "profile":
                    showData.ShowDatas<Profile>(DatasDG, TablesCB.Text);
                    break;
                case "user":
                    showData.ShowDatas<User>(DatasDG, TablesCB.Text);
                    break;
                case "address":
                    showData.ShowDatas<Address>(DatasDG, TablesCB.Text);
                    break;
                case "dog":
                    showData.ShowDatas<Dog>(DatasDG, TablesCB.Text);
                    break;
                case "doghistory":
                    showData.ShowDatas<DogHistory>(DatasDG, TablesCB.Text);
                    break;
                case "dogpicture":
                    showData.ShowDatas<DogPictures>(DatasDG, TablesCB.Text);
                    break;
            }
        }

        private async void DeleteByIdB_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                System.Net.Http.HttpResponseMessage responsemessage = await DeleteData.Delete(
                                            Convert.ToInt32(DeleteByIdTB.Text), TablesCB.Text);
                MessageBox.Show("Elem sikeresen törölve.");

                ShowDatas_Click(sender, e);
            }
            catch
            {
                MessageBox.Show("Az elem törlése nem sikerült!");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ModifyBreedHistory modifyBreedHistory = new();
            GetWindow(modifyBreedHistory).Show();
            Close();
        }
    }
}
