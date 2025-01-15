using dogMeet_adminSite.DataManage;
using System;
using System.Text.RegularExpressions;
using System.Windows;

namespace dogMeet_adminSite.Views.NewData
{
    /// <summary>
    /// Interaction logic for NewOwnerWindow.xaml
    /// </summary>
    public partial class NewOwnerWindow : Window
    {
        public NewOwnerWindow()
        {
            InitializeComponent();
        }

        private async void Next_Click(object sender, RoutedEventArgs e)
        {
            int newuserdata = 0;
            int newprofiledata = 0;

            try
            {
                Regex emailregex = new(@"^([A-Za-z\.\-]+)@([A-Za-z\-]+)((\.(\w){2,3})+)$");
                Match emailmatch = emailregex.Match(EmailTB.Text);
                if (emailmatch.Success && PasswordTB.Password == confirmPasswordTB.Password && PasswordTB.Password.Length >= 8)
                {
                    newuserdata = await NewDatas.Newuser(UserNameTB.Text, EmailTB.Text,
                                                                PasswordTB.Password, confirmPasswordTB.Password);
                    newprofiledata = await NewDatas.Newprofile(FirstNameTB.Text, LastNameTB.Text, PhoneTB.Text, newuserdata);

                    NewLocationWindow newLocationWindow = new(newprofiledata, newuserdata);
                    GetWindow(newLocationWindow).Show();
                    Close();
                }
                else
                {
                    MessageBox.Show("Hibás adatbevitel");
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("Hibás adatbevitel" + err.Message);
            }

            if (newprofiledata == 0)
            {
                System.Net.Http.HttpResponseMessage responsemessage = await DeleteData.Delete(newuserdata, "user");
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new();
            GetWindow(mainWindow).Show();
            Close();
        }
    }
}