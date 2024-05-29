using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Interaction logic for Afterlogin.xaml
    /// </summary>
    public partial class Afterlogin : Window
    {
       public static List<Szemely> szemelyek=new List<Szemely>();
       public static List<Szoba> szobalista=new List<Szoba>();
       public static List<RoomLog>Szobalog=new List<RoomLog>();
       private Button clicked;
       private string szam;
       RoomDiary ujablak;
       Stats stats;

        public Afterlogin()
        {
            InitializeComponent();

            Random rnd = new Random();


            for (int i = 0; i < 9; i++)
            {
                string def = "Előjegyzett";
                int szobaara=rnd.Next(6000,12000);
                szobalista.Add(new Szoba(i,rnd.Next(2,4),szobaara,false,szobaara,def));
            }

            ProcessButtons(stckbtns);
            ProcessButtons(stckbtns1);
           



            stck.Visibility = Visibility.Hidden;
        }

        private void ProcessButtons(Panel panel)
        {
            foreach (UIElement element in panel.Children)
            {
                if (element is Button button)
                {
                    foreach (var szoba in Szobalog)
                    {
                        if (szoba.Allapot == "Előjegyzett" && button.Name == $"btn{szoba.Szobaszam}")
                        {
                            button.IsEnabled = false;
                        }
                    }
                }
            }
        }

        //előjegyzett, teljesült, lemondott
        private void foglalas(object sender, RoutedEventArgs e)
        {
            textboxmail.Text = "";
            textBoxnev.Text = "";
            textboxszuldatum.Text = "";
            cboxvip.IsChecked= false;
            stck.Visibility = Visibility.Visible;
            szam = (sender as Button).Content.ToString();
            clicked = sender as Button;
            finalprice.Content = $"A végösszeg: {szobalista[int.Parse(szam) - 1].Fizetedendo}";


        }
        

        private void Finishfoglalas(object sender, RoutedEventArgs e)
        {
            if (textBoxnev.Text!="" && textboxmail.Text!="" && textboxszuldatum.Text!="")
            {
                bool isVipChecked = cboxvip.IsChecked == true ? true : false;
                szemelyek.Add(new Szemely(textBoxnev.Text+textboxmail.Text,textBoxnev.Text,textboxszuldatum.SelectedDate.Value,textboxmail.Text,isVipChecked));
                

                if (isVipChecked)
                {
                    szobalista[int.Parse(szam) - 1].Fizetedendo = szobalista[int.Parse(szam) - 1].Ar * 0.97;
                    if (int.Parse(txbfok.Text) <= szobalista[int.Parse(szam) - 1].Ferohelyekszama)
                    {
                        finalprice.Content = $"A végösszeg: {(szobalista[int.Parse(szam) - 1].Fizetedendo) * int.Parse(txbfok.Text)} Ft";
                        szobalista[int.Parse(szam) - 1].Foglalte = true;

                        Szobalog.Add(new RoomLog(textBoxnev.Text, textBoxnev.Text + textboxmail.Text, szobalista[int.Parse(szam)].Szobaszam, double.Parse(finalprice.Content.ToString().Split(' ')[2]), int.Parse(txbfok.Text),DateTime.Parse(txberkz.Text), DateTime.Parse(txbtavozas.Text), "Előjegyzett"));
                        clicked.IsEnabled = false;
                        MessageBox.Show("Sikeres foglalás");
                    }
                    else
                    {
                        MessageBox.Show("Ez a szoba túl kicsi.");
                    }
                }
                else
                {
                    if (int.Parse(txbfok.Text) <= szobalista[int.Parse(szam) - 1].Ferohelyekszama)
                    {
                        finalprice.Content = $"A végösszeg: {(szobalista[int.Parse(szam) - 1].Fizetedendo) * int.Parse(txbfok.Text)} Ft";
                        szobalista[int.Parse(szam) - 1].Foglalte = true;
                        clicked.IsEnabled = false;

                        Szobalog.Add(new RoomLog(textBoxnev.Text, textBoxnev.Text + textboxmail.Text, szobalista[int.Parse(szam)].Szobaszam, double.Parse(finalprice.Content.ToString().Split(' ')[2]), int.Parse(txbfok.Text), DateTime.Parse(txberkz.Text), DateTime.Parse(txbtavozas.Text), "Előjegyzett"));
                        MessageBox.Show("Sikeres foglalás");
                    }
                    else
                    {
                        MessageBox.Show("Ez a szoba túl kicsi.");
                    }
                }

            }
            else
            {
                MessageBox.Show("Mindent ki kell tölteni.");
            }

        }

        private void roomdiary_Click(object sender, RoutedEventArgs e)
        {
            
            ujablak = new RoomDiary();
            ujablak.Show();
            this.Close();
        }

        private void Statisztika_Click(object sender, RoutedEventArgs e)
        {
            if (Szobalog.Count<=0)
            {
                MessageBox.Show("Nincsenek foglalások még.");
            }
            else
            {
                stats = new Stats();
                stats.Show();
                this.Close();
            }
        }
    }
}
// ügyfél azonosítója, neve, születési dátuma, e-mail címe, VIP ügyfél-e