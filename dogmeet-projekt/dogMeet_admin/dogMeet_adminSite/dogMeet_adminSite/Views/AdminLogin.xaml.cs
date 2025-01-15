using dogMeet_adminSite.DataManage;
using dogMeet_adminSite.Model;
using Flurl.Http;
using System.Text.Json;
using System.Windows;

namespace dogMeet_adminSite.Views
{
    /// <summary>
    /// Interaction logic for AdminLogin.xaml
    /// </summary>
    public partial class AdminLogin : Window
    {
        public AdminLogin()
        {
            InitializeComponent();
        }

        private async void Login_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string email = adminemail.Text;
                string password = adminpassword.Password;
                ApiCallRoute apiCallRoute = new ApiCallRoute();
                string route = apiCallRoute.Route;
                var modifyuserjson = await $"{route}login?email={email}&password={password}".GetStringAsync();
                LoginResponse getresponse = JsonSerializer.Deserialize<LoginResponse>(modifyuserjson);
                Token.token = getresponse.token;
                if (getresponse.token != "")
                {
                    MainWindow newLocationWindow = new();
                    GetWindow(newLocationWindow).Show();
                    Close();
                }
                else
                {
                    MessageBox.Show("Érvénytelen felhasználó!");
                }
            }
            catch
            {
                MessageBox.Show("Érvénytelen felhasználó!");
            }
        }
    }
}
