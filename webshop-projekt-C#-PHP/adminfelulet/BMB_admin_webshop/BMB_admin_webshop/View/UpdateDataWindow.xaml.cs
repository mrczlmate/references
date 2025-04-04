using Admin_BMB_webshopProjekt.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
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

namespace Admin_BMB_webshopProjekt.View
{
    /// <summary>
    /// Interaction logic for UpdateDataWindowxaml.xaml
    /// </summary>
    public partial class UpdateDataWindow : Window
    {
        public UpdateDataWindow()
        {
            InitializeComponent();
        }

        private void termek_modosit_click(object sender, RoutedEventArgs e)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8881/");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                Termek termek = new Termek();
                termek.nev = tb_termeknev.Text;
                termek.ar = int.Parse(tb_ar.Text);
                termek.leiras = tb_leiras.Text;
                termek.mennyiseg = int.Parse(tb_mennyiseg.Text);
                termek.kategoria_id = int.Parse(tb_termek_katid.Text);
                int id = int.Parse(tb_melyiktermekid.Text);
                var res = client.PutAsJsonAsync($"api/termek/{id}", termek).Result;
                MessageBox.Show($"{res.StatusCode} || {res.RequestMessage}");
                if (res.IsSuccessStatusCode)
                {
                    tb_melyiktermekid.Text = "";
                    tb_termeknev.Text = "";
                    tb_ar.Text = "";
                    tb_leiras.Text = "";
                    tb_mennyiseg.Text = "";
                    tb_termek_katid.Text = "";
                    MessageBox.Show("Sikeresen frissítette a terméket!");
                }
            }
        }

        private void kategoria_modosit_click(object sender, RoutedEventArgs e)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8881/");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                Kategoria kategoria = new Kategoria();
                kategoria.megnevezes = tb_kat_megnevezes.Text;
                kategoria.szulokategoria_id = tb_szulokatid.Text == "" ? null : int.Parse(tb_szulokatid.Text);
                int id = int.Parse(tb_melyikkategoriaid.Text);
                var res = client.PutAsJsonAsync($"api/kategoria/{id}", kategoria).Result;
                if (res.IsSuccessStatusCode)
                {
                    tb_melyikkategoriaid.Text = "";
                    tb_kat_megnevezes.Text = "";
                    tb_szulokatid.Text = "";
                    MessageBox.Show("Sikeresen frissítette a kategóriát!");
                }
            }
        }

        private void kep_modosit_click(object sender, RoutedEventArgs e)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8881/");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                Kep kep = new Kep();
                kep.url = tb_url.Text;
                kep.termek_id = int.Parse(tb_termekid.Text);
                int id = int.Parse(tb_melyikkepid.Text);
                var res = client.PutAsJsonAsync($"api/kep/{id}", kep).Result;
                if (res.IsSuccessStatusCode)
                {
                    tb_melyikkepid.Text = "";
                    tb_termekid.Text = "";
                    tb_url.Text = "";
                    MessageBox.Show("Sikeresen frissítette a képet!");
                }
            }
        }

        private void vissza_click(object sender, RoutedEventArgs e)
        {
            AdminWindow adminWindow = new AdminWindow();
            adminWindow.Top = this.Top;
            adminWindow.Left = this.Left;
            AdminWindow.GetWindow(adminWindow).Show();
            this.Close();
        }
    }
}
