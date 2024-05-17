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
        private Button clicked;
        private string szam;
        public RoomDiary()
        {
            InitializeComponent();
            dgrSzobak.DataContext = Afterlogin.szobalista;



        }
        private void foglalas(object sender, RoutedEventArgs e)
        {
            textboxmail.Text = "";
            textBoxnev.Text = "";
            textboxszuldatum.Text = "";
            cboxvip.IsChecked = false;
            stck.Visibility = Visibility.Visible;
            szam = (sender as Button).Content.ToString();
            clicked = sender as Button;
            finalprice.Content = $"A végösszeg: {Afterlogin.szobalista[int.Parse(szam) - 1].Fizetedendo}";


        }
    }
}
