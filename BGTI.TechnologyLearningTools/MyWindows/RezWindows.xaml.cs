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

namespace BGTI.TechnologyLearningTools.MyWindows
{
    /// <summary>
    /// Логика взаимодействия для RezWindows.xaml
    /// </summary>
    public partial class RezWindows : Window
    {
        public RezWindows()
        {
            InitializeComponent();
            this.Loaded += RezWindows_Loaded;
        }

        private void RezWindows_Loaded(object sender, RoutedEventArgs e)
        {
          dataGridRez.ItemsSource =    Service.ExemService.GetRezExament();
        }
    }
}
