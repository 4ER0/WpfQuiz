using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        private void signIn(object sender, RoutedEventArgs e)
        {
            DBMapper DBMapper = new DBMapper();
            User user = DBMapper.GetUser(signInUserName.Text, SHA.HashValue(signInUserPassword.Password));
            Debug.WriteLine(user.Id);
            if (user.Id != 666)
            {
                new Spiel(user).Show();
                Close(); 
            }
        }
        private void signUp(object sender, RoutedEventArgs e)
        {
            if (SHA.HashValue(signUpUserPassword1.Password) == SHA.HashValue(signUpUserPassword2.Password))
            {
                DBMapper dbMapper = new DBMapper();
                dbMapper.AddUser(new User
                {
                    Name = signUpUserName.Text,
                    Password = SHA.HashValue(signUpUserPassword1.Password),
                    Highscore = 0,
                    questionHistoryString = "-"
                });
            }
            else
            {
                //TODO: ERROR BEI UNTERSCHIEDLICHEN PASSWORT
            }
        }
    }
}
