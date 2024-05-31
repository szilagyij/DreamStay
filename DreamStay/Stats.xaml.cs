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
    /// Interaction logic for Stats.xaml
    /// </summary>
    public partial class Stats : Window
    {
        Afterlogin afterlogin;
        public Stats()
        {
            InitializeComponent();
            int minimumar=0;
            int maximumar=0;
            double osszesar=0;
            for (int i = 0; i < Afterlogin.Szobalog.Count; i++)
            {
                osszesar += Afterlogin.Szobalog[i].Ar;

                if (Afterlogin.Szobalog[minimumar].Ar> Afterlogin.Szobalog[i].Ar)
                {
                    minimumar = i;
                }
                if (Afterlogin.Szobalog[maximumar].Ar < Afterlogin.Szobalog[i].Ar)
                {
                    maximumar = i;
                }
            }

            lblBevetel.Content = osszesar+"Ft";
            lbllegkisebb.Content = Afterlogin.Szobalog[minimumar].Ar+"Ft";
            lbllegnagy.Content = Afterlogin.Szobalog[maximumar].Ar+"Ft";



            Dictionary<string,int>szobakszama=new Dictionary<string,int>();

            foreach (var item in Afterlogin.Szobalog)
            {
                if (szobakszama.ContainsKey(item.Szobaszam.ToString()))
                {
                    szobakszama[item.Szobaszam.ToString()]++;
                }
                else
                {
                    szobakszama.Add(item.Szobaszam.ToString(), 1);
                }
            }
            var maxKiadasszam = szobakszama.Values.Max();
            var legtobbetKiadottSzoba = szobakszama.First(x => x.Value == maxKiadasszam).Key;

            lblSzobak.Content = $"Legtöbbet kiadott szoba: {legtobbetKiadottSzoba} számú szoba, összesen: {maxKiadasszam}x";


            Dictionary<string, double> szemelyekszama = new Dictionary<string, double>();
            foreach (var item in Afterlogin.szemelyek)
            {
                double osszeg = 0.0;

                foreach (var item1 in Afterlogin.Szobalog)
                {
                    if (item.Nev == item1.Nev)
                    {
                        osszeg += item1.Ar; 
                    }
                }
                szemelyekszama[item.Nev] = osszeg; 
            }

            string labelContent = "Személyek listája:\n";
            foreach (var kvp in szemelyekszama)
            {
                labelContent += $"\t{kvp.Key}: {kvp.Value}\n";
            }
            lblSzemelyek.Content = labelContent;
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            afterlogin = new Afterlogin();
            afterlogin.Show();
            this.Close();
        }
    }
}
