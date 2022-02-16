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

namespace BGTI.TechnologyLearningTools
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

        private void btGoExem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MyWindows.TestStudentWindows testStudentWindows = new MyWindows.TestStudentWindows
                  (Convert.ToInt32(tbExam.Text), tbExemFIO.Text);
                testStudentWindows.Show();
                Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btGo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string name = string .Empty;
                if(Service.UserService.IsAdmin(tbName.Text , tbPasswor.Text ))
                {
                    MyWindows.ListExamWindows windows = new MyWindows.ListExamWindows();
                    windows.Show();
                    Close();
                }
                else
                {
                    Model.User user = new Model.User { Name = "admin", Password = "admin" };
                    Model.MySqlLiteContext mySqlLiteContext = new Model.MySqlLiteContext();
                    mySqlLiteContext.Users.Add(user);
                    mySqlLiteContext.SaveChanges();
                    MessageBox.Show("пользователь не  найден"); 
                }
            }
            catch (Exception ex)
            {
               
                MessageBox.Show(ex.Message);
            }
        }

        private void btGoRez_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MyWindows.RezWindows rezWindows = new MyWindows.RezWindows();
                rezWindows.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
