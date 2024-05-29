using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Reflection;
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

namespace DreamStay
{
    /// <summary>
    /// Interaction logic for RoomDiary.xaml
    /// </summary>
    public partial class RoomDiary : Window
    {
        Button clicked;
        private string szam;
        private int current;
        Afterlogin afterlogin;
        public RoomDiary()
        {
            InitializeComponent();
            dgrSzobak.ItemsSource = Afterlogin.Szobalog;
            dgrSzobak.Items.Refresh();



        }
        private void foglalas(object sender, RoutedEventArgs e)
        {
            textBoxazon.Text = "";
            textboxszobaszam.Text = "";
            stckgombok.Children.Clear();


            Button btn=new Button();
            btn.Content = "Fizetve";
            btn.Click += fizetve_Click;
            btn.Height = 30;
            btn.Width = 120;
            btn.Margin = new Thickness(10);
            stckgombok.Children.Add(btn);

            Button torles = new Button();
            torles.Content = "Törlés";
            torles.Click += Torles_Click;
            torles.Height = 30;
            torles.Width = 120;
            torles.Margin = new Thickness(10);
            stckgombok.Children.Add(torles);

            Button lemond = new Button();
            lemond.Content = "Lemondás";
            lemond.Click += Lemond_Click;
            lemond.Height = 30;
            lemond.Width = 120;
            lemond.Margin = new Thickness(10);
            stckgombok.Children.Add(lemond);


            stck.Visibility = Visibility.Visible;
            szam = (sender as Button).Content.ToString();
            clicked = sender as Button;
            finalprice.Content = $"A szoba ára egy főre: {Afterlogin.szobalista[int.Parse(szam) - 1].Fizetedendo} Ft";
            txballapot.Content = "Állapot: Nem foglalt";
            for (int i = 0; i < Afterlogin.Szobalog.Count; i++)
            {

                if (Afterlogin.Szobalog[i].Szobaszam == int.Parse(szam) && Afterlogin.Szobalog[i].Allapot == "Előjegyzett")
                {
                    lbldatumok.Content = $"{Afterlogin.Szobalog[int.Parse(szam)-1].Erkezes} - {Afterlogin.Szobalog[int.Parse(szam) - 1].Tavozas}";
                    double vegosszeg = Afterlogin.szobalista[int.Parse(szam) - 1].Fizetedendo * Afterlogin.Szobalog[int.Parse(szam) - 1].Hanyfo;
                    textBoxazon.Text = Afterlogin.Szobalog[i].Azon;
                    textboxszobaszam.Text = Afterlogin.Szobalog[i].Szobaszam.ToString();
                    txballapot.Content = $"Állapot: {Afterlogin.Szobalog[i].Allapot.ToString()}";
                    finalprice.Content = $"A fizetendő összeg a szobáért: {vegosszeg} Ft";
                    current = i;
                }

            }




        }

        private void fizetve_Click(object sender, RoutedEventArgs e)
        {
            if (dgrSzobak.SelectedIndex!=-1)
            {
                Afterlogin.Szobalog[dgrSzobak.SelectedIndex].Allapot = "Teljesült";
                dgrSzobak.Items.Refresh();
            }
            else
            {
                Afterlogin.Szobalog[current].Allapot = "Teljesült";
                dgrSzobak.Items.Refresh();
            }

        }
        private void Torles_Click(object sender, RoutedEventArgs e)
        {
            Afterlogin.Szobalog.RemoveAt(current);
            current = -1;
            dgrSzobak.Items.Refresh();
        }
        private void Lemond_Click(object sender, RoutedEventArgs e)
        {
            if (dgrSzobak.SelectedIndex!=-1)
            {
                Afterlogin.Szobalog[dgrSzobak.SelectedIndex].Allapot = "Lemondott";
                dgrSzobak.Items.Refresh();
            }
            else 
            {
                Afterlogin.Szobalog[current].Allapot = "Lemondott";
                dgrSzobak.Items.Refresh();
            }

            

        }

        private void btnVissza_Click(object sender, RoutedEventArgs e)
        {
            afterlogin = new Afterlogin();
            afterlogin.Show();
            this.Close();
        }

        private void dgrSzobak_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lbldatumok.Content = $"{Afterlogin.Szobalog[dgrSzobak.SelectedIndex].Erkezes} - {Afterlogin.Szobalog[dgrSzobak.SelectedIndex].Tavozas}";
            double vegosszeg = Afterlogin.szobalista[dgrSzobak.SelectedIndex].Fizetedendo * Afterlogin.Szobalog[dgrSzobak.SelectedIndex].Hanyfo;
            textBoxazon.Text = Afterlogin.Szobalog[dgrSzobak.SelectedIndex].Azon;
            textboxszobaszam.Text = Afterlogin.Szobalog[dgrSzobak.SelectedIndex].Szobaszam.ToString();
            txballapot.Content = $"Állapot: {Afterlogin.Szobalog[dgrSzobak.SelectedIndex].Allapot.ToString()}";
            finalprice.Content = $"A fizetendő összeg a szobáért: {vegosszeg} Ft";
        }
    }
}
