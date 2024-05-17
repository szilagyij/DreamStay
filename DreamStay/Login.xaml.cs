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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        Afterlogin afterlogin;
        MainWindow main;
        public Login()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string jelszo = "admin";
            string felhasznalo = "admin";
            if (txbFelhaszn.Text==felhasznalo && txbJelszo.Text==jelszo)
            {
                afterlogin=new Afterlogin();
                afterlogin.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Hibás adatok");
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            main=new MainWindow();
            main.Show();
            this.Close();
        }
    }
}
