using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls; // Ezt a sort add hozzá
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace FELVETELI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
          ObservableCollection<IFelvetelizo> diakok = new ObservableCollection<IFelvetelizo> ();
        public MainWindow()
        {
            InitializeComponent();
            MainGrid.ItemsSource = diakok;
          

        }
        private static readonly Regex _regex = new Regex("[^0-9.-]+");
        private static bool IsTextAllowed(string text)
        {
            return !_regex.IsMatch(text);
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
         
            }
        }
        private void btnFelvetel_Click(object sender, RoutedEventArgs e)
        {
            var windowA = new MainWindow();
            windowA.Close();
            var windowB = new Felvétel();
            windowB.ShowDialog();

        }

        private void btnTorol_Click(object sender, RoutedEventArgs e)
        {
            if (MainGrid.SelectedIndex >= 0)
            {
                for (int i = 0; i <= MainGrid.SelectedItems.Count; i++)
                {
                    MainGrid.Items.Remove(MainGrid.SelectedItems[i]);
                };
            }
        }
    }
}
