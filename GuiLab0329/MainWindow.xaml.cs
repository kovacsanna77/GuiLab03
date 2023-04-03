using GuiLab0329.ViewModel;
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

namespace GuiLab0329
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        

        private void ListBox_MouseDoubleClick_1(object sender, MouseButtonEventArgs e)
        {
            EditWindow ed = new EditWindow((this.DataContext as MainWindowViewModel).SelectedFromLeft);
            ed.ShowDialog();
        }

        private void ComboBox_Selected(object sender, RoutedEventArgs e)
        {

        }
    }
}
