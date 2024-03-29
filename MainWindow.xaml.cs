﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using Microsoft.Win32;
using System.Text.Json;
using System.Text.Encodings.Web;

namespace FELVETELI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<IFelvetelizo> felveteli = new ObservableCollection<IFelvetelizo>();
        public MainWindow()
        {
            InitializeComponent();
            dtgFelveteli.ItemsSource = felveteli;


        }

        private void btnFelvetel_Click(object sender, RoutedEventArgs e)
        {

            Diak ujdiak = new Diak();
            Felvétel ujablak = new Felvétel(ujdiak);
            ujablak.txtAzonosito.IsEnabled = true;
            ujablak.Title = "Adatok felvétele";
            ujablak.tbCim.Text = "Diák felvétele";
            ujablak.btnModosit.Visibility = Visibility.Hidden;
            ujablak.btnFelvesz.Visibility = Visibility.Visible;
            ujablak.ShowDialog();
            if (ujdiak.Neve != null)
            {
                felveteli.Add(ujdiak);
            }
        }

        private void btnTorol_Click(object sender, RoutedEventArgs e)
        {
            IEditableCollectionView items = dtgFelveteli.Items;
            List<Diak> Torolni = new List<Diak>();
            if (dtgFelveteli.SelectedItems.Count > 0)

            {
                if (MessageBox.Show("Biztosan eltávolítod a listából?", "Megerősítés", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    foreach (var item in dtgFelveteli.SelectedItems)
                    {
                        Torolni.Add((Diak)item);
                    }

                    foreach (Diak item in Torolni)
                    {
                        if (items.CanRemove)
                        {
                            items.Remove(dtgFelveteli.SelectedItem);
                        }
                    }
                    dtgFelveteli.ItemsSource = felveteli;

                }
               
            }
            else
            {
                MessageBox.Show("Nincs kiválasztott elem");
            }
          

        }

        private void btnImport_Click(object sender, RoutedEventArgs e)
        {
            if (dtgFelveteli.Items.Count > 0)
            {
                if (MessageBox.Show("Diákok felülírása?", "Megerősítés", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    felveteli.Clear();

                }

            }

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "csv fajl (*.csv)|*.csv";
            if (ofd.ShowDialog() == true)
            {
                foreach (String fajl in File.ReadAllLines(ofd.FileName).Skip(1))
                {
                    felveteli.Add(new Diak(fajl));
                }
            }

        }
        private void btnExport_Click(object sender, RoutedEventArgs e)
        {

            //var opciok = new JsonSerializerOptions();
            //opciok.Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping;
            //opciok.WriteIndented = true;
            //string adatokSorai = JsonSerializer.Serialize(felveteli, opciok);
            //var lista = new List<String>();
            //lista.Add(adatokSorai);

            try
            {

                StreamWriter sw = new StreamWriter("DiakUj.csv", false);
                foreach (Diak item in dtgFelveteli.Items)
                {
                    sw.WriteLine(item.CSVSortAdVissza());
                }
                sw.Close();
                MessageBox.Show("Sikeres exportálás");
            }
            catch (Exception error)
            {

                MessageBox.Show(error.Message);
            }

        }

        private void btnModosit_Click(object sender, RoutedEventArgs e)
        {
            if (dtgFelveteli.SelectedItems.Count < 2)
            {        
                if (dtgFelveteli.SelectedItem != null)
                {
                    Diak kivalasztottDiak = (Diak)dtgFelveteli.SelectedItem;
                    Felvétel ujablak = new Felvétel(kivalasztottDiak, true);
                    ujablak.txtAzonosito.IsEnabled = false;
                    ujablak.Title = "Adatok módosítása";
                    ujablak.tbCim.Text = "Diák modosítása";
                    ujablak.btnModosit.Visibility = Visibility.Visible;
                    ujablak.btnFelvesz.Visibility = Visibility.Hidden;
                    ujablak.ShowDialog();
                    dtgFelveteli.Items.Refresh();
                }
                else
                {
                    MessageBox.Show("Nincs kiválasztott elem a listában!");
                }  
            }
            else
            {
                MessageBox.Show("Túl sok a kiválasztott elem a listában!");
            }
        }
    }
}
