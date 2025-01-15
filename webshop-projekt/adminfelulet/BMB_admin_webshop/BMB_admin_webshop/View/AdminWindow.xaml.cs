using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Net.Http.Headers;
using static Admin_BMB_webshopProjekt.Model.Kep;
using static Admin_BMB_webshopProjekt.Model.Kategoria;
using static Admin_BMB_webshopProjekt.Model.Termek;

namespace Admin_BMB_webshopProjekt.View
{
    /// <summary>
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();
            cb_tablamutat.Items.Add("Kép");
            cb_tablamutat.Items.Add("Kategória");
            cb_tablamutat.Items.Add("Termék");
            cb_tablatorles.Items.Add("Kép");
            cb_tablatorles.Items.Add("Kategória");
            cb_tablatorles.Items.Add("Termék");
        }

        private void torles_click(object sender, RoutedEventArgs e)
        {
            if (cb_tablatorles.SelectedItem.ToString() == "Kép")
            {
                DeleteKepek();
            }

            if (cb_tablatorles.SelectedItem.ToString() == "Kategória")
            {
                DeleteKategoriak();
            }

            if (cb_tablatorles.SelectedItem.ToString() == "Termék")
            {
                DeleteTermekek();
            }
        }

        private void modositas_click(object sender, RoutedEventArgs e)
        {
            UpdateDataWindow updateDataWindow = new UpdateDataWindow();
            updateDataWindow.Top = this.Top;
            updateDataWindow.Left = this.Left;
            UpdateDataWindow.GetWindow(updateDataWindow).Show();
            this.Close();
        }

        private void ujadat_click(object sender, RoutedEventArgs e)
        {
            NewDataWindow newDataWindow = new NewDataWindow();
            newDataWindow.Top = this.Top;
            newDataWindow.Left = this.Left;
            NewDataWindow.GetWindow(newDataWindow).Show();
            this.Close();
        }

        private void tablamegjelenit_click(object sender, RoutedEventArgs e)
        {
            if (cb_tablamutat.SelectedItem.ToString() == "Kép")
            {
                ShowKepek();
            }

            if (cb_tablamutat.SelectedItem.ToString() == "Kategória")
            {
                ShowKategoriak();
            }

            if (cb_tablamutat.SelectedItem.ToString() == "Termék")
            {
                ShowTermekek();
            }
        }

        // Adatok kilistázása
        private void ShowKepek()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8881/");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                dg_tables.ItemsSource = null;

                HttpResponseMessage res = client.GetAsync("api/kep").Result;
                if (res.IsSuccessStatusCode)
                {
                    var kepek = res.Content.ReadAsAsync<Kepek>().Result;
                    dg_tables.ItemsSource = kepek.data;
                }
                else
                {
                    MessageBox.Show($"{res.StatusCode} || {res.ReasonPhrase}");
                }
            }
        }

        private void ShowTermekek()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8881/");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                dg_tables.ItemsSource = null;

                HttpResponseMessage res = client.GetAsync("api/termek").Result;
                if (res.IsSuccessStatusCode)
                {
                    var termekek = res.Content.ReadAsAsync<Termekek>().Result;
                    dg_tables.ItemsSource = termekek.data;
                }
                else
                {
                    MessageBox.Show($"{res.StatusCode} || {res.ReasonPhrase}");
                }
            }
        }

        private void ShowKategoriak()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8881/");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                dg_tables.ItemsSource = null;

                HttpResponseMessage res = client.GetAsync("api/kategoria").Result;
                if (res.IsSuccessStatusCode)
                {
                    var kategoriak = res.Content.ReadAsAsync<Kategoriak>().Result;
                    dg_tables.ItemsSource = kategoriak.data;
                }
                else
                {
                    MessageBox.Show($"{res.StatusCode} || {res.ReasonPhrase}");
                }
            }
        }

        // Adatok törlése
        private void DeleteKepek()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8881/");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                int id = int.Parse(tb_idtorles.Text);

                HttpResponseMessage res = client.DeleteAsync("api/kep/" + id).Result;
                if (res.IsSuccessStatusCode)
                {
                    ShowKepek();
                    tb_idtorles.Text = "";
                    MessageBox.Show("A terméket töröltük!");
                }
                else
                {
                    MessageBox.Show($"{res.StatusCode} || {res.ReasonPhrase}");
                }
            }
        }

        private void DeleteTermekek()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8881/");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                int id = int.Parse(tb_idtorles.Text);

                HttpResponseMessage res = client.DeleteAsync("api/termek/" + id).Result;
                if (res.IsSuccessStatusCode)
                {
                    ShowTermekek();
                    tb_idtorles.Text = "";
                    MessageBox.Show("A terméket töröltük!");
                }
                else
                {
                    MessageBox.Show($"{res.StatusCode} || {res.ReasonPhrase}");
                }
            }
        }

        private void DeleteKategoriak()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8881/");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                int id = int.Parse(tb_idtorles.Text);

                HttpResponseMessage res = client.DeleteAsync("api/kategoria/" + id).Result;
                if (res.IsSuccessStatusCode)
                {
                    ShowKategoriak();
                    tb_idtorles.Text = "";
                    MessageBox.Show("A terméket töröltük!");
                }
                else
                {
                    MessageBox.Show($"{res.StatusCode} || {res.ReasonPhrase}");
                }
            }
        }
    }
}
