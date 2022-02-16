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
    /// Логика взаимодействия для ListExamWindows.xaml
    /// </summary>
    public partial class ListExamWindows : Window
    {
        public ListExamWindows()
        {
            InitializeComponent();
            this.Loaded += ListExamWindows_Loaded;
        }

        private void ListExamWindows_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                var content = Service.ExemService.Exams();
                listBoxExem.ItemsSource = content;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btAddEx_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MyWindows.MessageWindows message = new MessageWindows("Укажите  название  экзамена");
                if ( message.ShowDialog() == true)
                {
                    var name = message.content;
                    Service.ExemService.Add(name);
                    MessageBox.Show("Экзамен добавлен");
                    ListExamWindows_Loaded(this, e);
                }
                else
                {
                    return;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void listBoxExem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Model.Exam exam =  listBoxExem.SelectedItem as Model.Exam;   
            if (exam != null)
            {
                MyWindows.ExamenWindows examenWindows = new ExamenWindows(exam);
                examenWindows.Show();
                Close();
            }
        }
    }
}
