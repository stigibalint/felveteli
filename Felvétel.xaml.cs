using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace FELVETELI
{
    /// <summary>
    /// Interaction logic for Felvétel.xaml
    /// </summary>
    public partial class Felvétel : Window
    {

        public Felvétel()

        {
            InitializeComponent();
   
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void btnVissza_Click(object sender, RoutedEventArgs e)
        {

            this.Close();   
        }

        private void btnFelvesz_Click(object sender, RoutedEventArgs e)
        {
            try
            {
       

                Diak diak = new Diak 
                {
                    OM_Azonosito = txtAzonosito.Text,
                    Neve = txtNev.Text,
                    ErtesitesiCime = txtCim.Text,
                    Email = txtEmail.Text,
                    SzuletesiDatum = DateTime.Parse(txtSzuletesiIdo.Text),
                    Matematika = int.Parse(txtMatekPontok.Text),
                    Magyar = int.Parse(txtMagyarPontok.Text)
                };

                

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hiba történt a diák hozzáadása során: {ex.Message}", "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    
        private void txtRemoveWaterMark(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox box)
            {
                if (box.Text == "Gipsz Jakab" || box.Text == "example@gmail.com" || box.Text == "Debrecen, Széchenyi u. 58." || box.Text == "62519514862" || box.Text == "2008.10.01" || box.Text == "50")
                {
                    box.Text = null;
                }
             
            }
        }
    }
}
