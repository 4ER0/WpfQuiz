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

namespace WpfQuiz
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void testButton_Click(object sender, RoutedEventArgs e)
        {
            DBMapper test1 = new DBMapper();
            var someUser = test1.GetUserByID(0);
            MessageBox.Show(someUser.Id + " " + someUser.Name + " " + someUser.Highscore);

            var frage = test1.GetQuestionByID(0);
            MessageBox.Show(frage.fragenText);



        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
