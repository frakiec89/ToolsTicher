using System.Windows;

namespace BGTI.TechnologyLearningTools.MyWindows
{
    /// <summary>
    /// Логика взаимодействия для MessageWindows.xaml
    /// </summary>
    public partial class MessageWindows : Window
    {
        public string content = string.Empty;

        public MessageWindows( string message)
        {
            InitializeComponent();
            this.Title = "Ввод данных";
            labelMassege.Content = message;
        }

        private void tbGoContent_Click(object sender, RoutedEventArgs e)
        {
            content = tbContent.Text;
            DialogResult = true;
            Close();
        }
    }
}
