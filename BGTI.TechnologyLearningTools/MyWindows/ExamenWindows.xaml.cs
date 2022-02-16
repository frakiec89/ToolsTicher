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
    /// Логика взаимодействия для ExamenWindows.xaml
    /// </summary>
    public partial class ExamenWindows : Window
    {

        private Model.Exam _exam;



        public ExamenWindows( Model.Exam exam )
        {
            InitializeComponent();
            Title = exam.Name;
            _exam = exam;

            this.Loaded += ExamenWindows_Loaded;
        }

        private void ExamenWindows_Loaded(object sender, RoutedEventArgs e)
        {
            listboxQusestion.ItemsSource = Service.ExemService.GetQuestion(_exam.ExamId);
        }

        private void btAddQ_Click(object sender, RoutedEventArgs e)
        {
            MyWindows.WindowQuestion windowQuestion = new MyWindows.WindowQuestion(_exam);
            if( windowQuestion.ShowDialog()== true )
            {
                ExamenWindows_Loaded(sender, e);
            }
        }
    }
}
