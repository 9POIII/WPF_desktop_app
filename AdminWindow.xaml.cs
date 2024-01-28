using FinanceApp2._0.Models;
using FinanceApp2._0.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace FinanceApp2._0
{
    /// <summary>
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        ApplicationContext db = new ApplicationContext();

        public AdminWindow()
        {
            InitializeComponent();
            CreateListOfUsers();
        }


        private void CreateListOfUsers()
        {
            List<User> users = db.Users.ToList();
            List<UserViewModel> userViewModels = users.Select(u => new UserViewModel(u)).ToList();
            listOfUsers.ItemsSource = userViewModels;
        }

        private void ToggleBanButton_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;

            if (btn != null)
            {
                UserViewModel userVM = btn.DataContext as UserViewModel;

                if (userVM != null)
                {
                    bool banStatus = (btn.Name == "BanButton");
                    userVM.ToggleBanStatus(banStatus);
                    db.SaveChanges();
                }
            }
        }


        private void On_Window_Closing(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }


    }
}
