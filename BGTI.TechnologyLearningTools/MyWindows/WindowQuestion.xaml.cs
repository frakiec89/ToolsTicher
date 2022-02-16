using BGTI.TechnologyLearningTools.Model;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace BGTI.TechnologyLearningTools.MyWindows
{
    /// <summary>
    /// Логика взаимодействия для WindowQuestion.xaml
    /// </summary>
    public partial class WindowQuestion : Window
    {
        Exam _exam;
        public WindowQuestion(Exam exam)
        {
            InitializeComponent();
            _exam = exam;
            tbChena.Text = "1"; 
        }

        

        private void btAdd_Click(object sender, RoutedEventArgs e)
        {
            int i = stackQ.Children.Count -1;
            StackPanel stackPanel = new StackPanel();
            stackPanel.Orientation = Orientation.Horizontal;
            stackPanel.Children.Add(new Label() { Content = $"Вариант {i}", Margin = new Thickness(5) });
            stackPanel.Children.Add(new TextBox() { MinWidth=150 , Margin = Margin = new Thickness(5) });
            stackPanel.Children.Add(new ComboBox { MinWidth = 150, Margin = Margin = new Thickness(5), 
                ItemsSource = new string[] {"Верно" , "Не Верно" } , SelectedIndex =1 }) ;

            var b = new Button
            {
                Name =  String.Format("bt{0}" ,i),
                Content = $"удалить",
                Margin = new Thickness(5)
            };
            b.Click += B_Click;
            stackPanel.Children.Add(b );
            stackQ.Children.Add(stackPanel);
        }

        private void B_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var bt = e.OriginalSource as Button;
                var t = Convert.ToInt32(bt.Name.Substring(2, 1)) + 1;
                stackQ.Children.RemoveAt(t);
            }
            catch
            {
                return;
            }
        }

        /// <summary>
        /// Добавляет вопрос  в  экзамен
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_QGoToDb(object sender, RoutedEventArgs e)
        {
            try
            {
                Model.Question question = new Model.Question()
                {
                    Title = tbQ.Text,
                    Exam = _exam,
                    ExamId = _exam.ExamId,
                    QuestionWeight = Convert.ToInt32( tbChena.Text)
                };
                List<Model.QuestionOption> options = new List<Model.QuestionOption>();
                options.AddRange(GetQP(question));
                Service.ExemService.AddQuestion(question, options);
                MessageBox.Show("Вопрос добавлен");
                this.DialogResult= true;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        /// <summary>
        /// получает  список  вариантов  в вопросе 
        /// </summary>
        /// <param name="question"></param>
        /// <returns></returns>
        private IEnumerable<QuestionOption> GetQP(Question question)
        {
            List<Model.QuestionOption> options = new List<Model.QuestionOption>();

            var content = stackQ.Children;
            foreach (var item in content)
            {
               if (item is  StackPanel )
               {
                    var stackPanel = (StackPanel)item;
                    if (stackPanel.Name == "sHider")
                        continue;

                    var op = new Model.QuestionOption();
                    op.Question = question;

                    foreach (var q in stackPanel.Children)
                    {
                       if (q is TextBox)
                       {
                           var textBox = (TextBox)q;
                           op.Title = textBox.Text;
                       }

                       if (q is ComboBox)
                       {
                            var  cb = (ComboBox)q;
                            if ( cb.SelectedIndex != 0)
                            {
                                op.IsChecked = false;
                            }
                            else
                            {
                                op.IsChecked = true;
                            }
                       }
                    }
                    options.Add(op);
                }
            }
            return options;
        }
    }
}
