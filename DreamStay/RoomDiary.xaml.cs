using System;
using System.Collections.Generic;
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


            stck.Visibility = Visibility.Visible;
            szam = (sender as Button).Content.ToString();
            clicked = sender as Button;
            finalprice.Content = $"A végösszeg: {Afterlogin.szobalista[int.Parse(szam) - 1].Fizetedendo} Ft";

            for (int i = 0; i < Afterlogin.Szobalog.Count; i++)
            {

                if (Afterlogin.Szobalog[i].Szobaszam == int.Parse(szam) && Afterlogin.Szobalog[i].Allapot == "foglalt")
                {
                    textBoxazon.Text = Afterlogin.Szobalog[i].Azon;
                    textboxszobaszam.Text = Afterlogin.Szobalog[i].Szobaszam.ToString();
                    txballapot.Content = $"Állapot: {Afterlogin.Szobalog[i].Allapot.ToString()}";
                    current = i;
                }

            }




        }

        private void fizetve_Click(object sender, RoutedEventArgs e)
        {
            Afterlogin.Szobalog[current].Allapot="Fizetve";
            dgrSzobak.Items.Refresh();
        }
        private void Torles_Click(object sender, RoutedEventArgs e)
        {
            Afterlogin.Szobalog.RemoveAt(current);
            dgrSzobak.Items.Refresh();
        }

        private void btnVissza_Click(object sender, RoutedEventArgs e)
        {
            afterlogin = new Afterlogin();
            afterlogin.Show();
            this.Close();
        }
    }
}
