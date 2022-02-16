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
    /// Логика взаимодействия для TestStudentWindows.xaml
    /// </summary>
    public partial class TestStudentWindows : Window
    {
        int step = 0;
        List<Model.QuestionOption> questions = new List<Model.QuestionOption>();
        List<Model.Question>  question = new List<Model.Question>();
        Model.UserTest UserTest = null;
        public int idEx;

        public TestStudentWindows( int  idEx , string name)
        {
            InitializeComponent();
            this.idEx = idEx;   
            questions = Service.ExemService.GetQuestionToStudent(idEx );
            question = Service.ExemService.GetQuestionId(idEx);
            this.Loaded += TestStudentWindows_Loaded;
            Title = "Привет " + name + " в экзамене вопросов -  " + question.Count;

            UserTest =  Service.UserTestService.Adduser(name, idEx);

         }

        private void TestStudentWindows_Loaded(object sender, RoutedEventArgs e)
        {
            
            if(step >= question.Count)
            {
                string rez = Service.ExemService.GetRezCoutn(UserTest, idEx);
                MessageBox.Show($"Тест  Окончен \n результат {rez}");
                return;
            }

            stackContent.Children.Add(new TextBlock()
            {
                Margin = new Thickness(5),
                Text = "Вопрос " + (step + 1) + ". " + questions.Where(x => x.QuestionId == question[step].QuestionId).FirstOrDefault().Question.Title
            }); ;

            int x = 1;
            foreach (var item in questions.Where(x =>  x.QuestionId == question[step].QuestionId))
            {
                StackPanel panel = new StackPanel();
                panel.Orientation = Orientation.Horizontal;
                panel.Margin = new Thickness(5);

                panel.Children.Add(new TextBlock()
                {
                    Margin = new Thickness(5),
                    Text = $"{x}. {item.Title}.\t" 
                    });
                panel.Children.Add(new CheckBox() { Margin = new Thickness(5)  });
                panel.Children.Add(new CheckBox() { Visibility=Visibility.Collapsed  , IsChecked = item.IsChecked });
                stackContent.Children.Add(panel);
                x++;
            }
        }

        private void btGO_Click(object sender, RoutedEventArgs e)
        {
            int count = 0;
            string otvet = string.Empty; 
            
            bool flag = false;
            string q = (stackContent.Children[0] as TextBlock).Text; // вопрос
            foreach (var item in stackContent.Children)
            {
               

                if (flag == true )
                { break; }

                if (item is StackPanel)
                {
                    var stack = (StackPanel)item;
                                       
                        var child = stack.Children[1] as CheckBox;
                        if (child != null)
                        {
                             if (  child.IsChecked == true)
                             {
                                var child2 = stack.Children[2] as CheckBox;
                                if (child2 != null)
                                {
                                    otvet += q + " - " + (stack.Children[0] as TextBlock).Text + " ";
                                    if (child2.IsChecked == true)
                                    {
                                        count++;
                                    }
                                    else
                                    {
                                        flag = true;
                                    }   
                                }
                             }
                             else
                             { continue; }
                        }
                   Service.UserTestService.AddOtvet(UserTest,  otvet , count );
                }
            }

            step++;
            if(step== question.Count -1)
            {
               
                btGO.Content = $"Завершить тест";
            }
            stackContent.Children.Clear();
            TestStudentWindows_Loaded(null, e);
        }
    }
}
