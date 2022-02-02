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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WydawanieReszty
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Reszta r;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void txtKosztProduktu_TextChanged(object sender, TextChangedEventArgs e)
        {




        }

        private void txtZaplacono_TextChanged(object sender, TextChangedEventArgs e)
        {


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            decimal koszt, zaplacono;

            if (decimal.TryParse(txtKosztProduktu.Text, out koszt) && decimal.TryParse(txtZaplacono.Text, out zaplacono))
            {
                if (zaplacono >= koszt)
                {
                    decimal roznica = zaplacono - koszt;

                    txtRoznicaCen.Text = roznica.ToString();

                    r = new Reszta(roznica);

                    txtReszta.Text = string.Join(" ", r.WydanaResztaStr());
                }
                else
                {
                    txtRoznicaCen.Text = "Koszt musi być mniejszy od kwoty zapłaconej";
                    txtReszta.Text = "Koszt musi być mniejszy od kwoty zapłaconej";
                }
            }
            else
            {
                txtRoznicaCen.Text = "";
                txtReszta.Text = "";
            }
        }
    }
}
