using FinanceApp2._0.Models;
using FinanceApp2._0.Utilits;
using FinanceApp2._0.ViewModel;
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

namespace FinanceApp2._0
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ApplicationContext db;

        public MainWindow()
        {
            InitializeComponent();

            db = new ApplicationContext();
        }

        private void Button_Registration_Click(object sender, RoutedEventArgs e)
        {
            CheckUserInput checkUserInput = new CheckUserInput(textBoxLogin, textBoxEmail, passwordBoxPassword, passwordBoxRetryPassword, comboBoxTypeOfStatus);
            bool isValid = checkUserInput.ValidateUserInput(isAuthWindow: false);

            if (isValid)
            {
                TextBoxesToDefault();
                CreateNewUser((Statuses)comboBoxTypeOfStatus.SelectedIndex);
                MessageBox.Show("Registration complete!");
            }
        }

        private void Button_Login_Click(object sender, RoutedEventArgs e)
        {
            CheckUserInput checkUserInput = new CheckUserInput(textBoxLoginAuth, passwordBoxPasswordAuth);
            bool isValid = checkUserInput.ValidateUserInput(isAuthWindow: true);

            if (isValid)
            {
                TextBoxesToDefault();
                LoginUser();
            }

        }

        private void Open_Auth_Window(object sender, RoutedEventArgs e)
        {
            AuthWindow.Visibility = Visibility.Visible;
            RegistrationWindow.Visibility = Visibility.Collapsed;
        }
        private void Open_Registration_Window(object sender, RoutedEventArgs e)
        {
            AuthWindow.Visibility = Visibility.Collapsed;
            RegistrationWindow.Visibility = Visibility.Visible;
        }

        private void CreateNewUser(Statuses status)
        {
            switch (status)
            {
                case Statuses.Unemployed:
                    StudentViewModel studentVM2 = new StudentViewModel(new Student());
                    studentVM2.Login = textBoxLogin.Text;
                    studentVM2.Email = textBoxEmail.Text;
                    studentVM2.Password = passwordBoxPassword.Password;
                    studentVM2.Status = Statuses.Unemployed;
                    //(Statuses)comboBoxTypeOfStatus.SelectedIndex;
                    studentVM2.CreateUserInDB();
                    break;
                case Statuses.Employed:
                    EmployedViewModel employedVM = new EmployedViewModel(new Employed());
                    employedVM.Login = textBoxLogin.Text;
                    employedVM.Email = textBoxEmail.Text;
                    employedVM.Password = passwordBoxPassword.Password;
                    employedVM.Status = Statuses.Employed;
                    //(Statuses)comboBoxTypeOfStatus.SelectedIndex;
                    employedVM.CreateUserInDB();
                    break;
                case Statuses.Student:
                    StudentViewModel studentVM = new StudentViewModel(new Student());
                    studentVM.Login = textBoxLogin.Text;
                    studentVM.Email = textBoxEmail.Text;
                    studentVM.Password = passwordBoxPassword.Password;
                    studentVM.Status = Statuses.Student;
                    //(Statuses)comboBoxTypeOfStatus.SelectedIndex;
                    studentVM.CreateUserInDB();
                    break;
                default:
                    break;
            }
        }
        private void LoginUser()
        {
            try
            {
                User authUser = null;
                authUser = db.Users.Where(b => b.Login == textBoxLoginAuth.Text && b.Password == passwordBoxPasswordAuth.Password).FirstOrDefault();

                if (authUser != null)
                {
                    if(authUser.Login == "admin" && authUser.Password == "admin")
                        OpenAdminWindow();
                    else
                    {
                        if (authUser.IsBanned == 1)
                        {
                            MessageBox.Show("You have Banned!");
                        }
                        else
                            OpenUserWindow();
                    }

                }
                else 
                    MessageBox.Show("Sosi");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void OpenAdminWindow()
        {
            AdminWindow adminWindow = new AdminWindow();
            adminWindow.Show();
            Close();
        }

        private void OpenUserWindow()
        {
            UserWindow userWindow = new UserWindow();
            userWindow.Show();
            Close();
        }


        private void TextBoxesToDefault()
        {
            Control[] textBoxes = { textBoxLogin, textBoxEmail, passwordBoxPassword, passwordBoxRetryPassword };

            foreach (var textBox in textBoxes)
            {
                textBox.ToolTip = null;
                textBox.Background = Brushes.Transparent;
            }
        }

    }
}
