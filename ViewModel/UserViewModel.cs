using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO.Pipes;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using FinanceApp2._0.Models;

namespace FinanceApp2._0.ViewModel
{
    internal class UserViewModel : INotifyPropertyChanged
    {
        private User user;

        private ApplicationContext db;

        public event PropertyChangedEventHandler PropertyChanged;

        public UserViewModel(User s)
        {
            user = s;
        }

        public void CreateUserInDB()
        {
            db = new ApplicationContext();
            db.Users.Add(user);
            db.SaveChanges();
        }

        public void ToggleBanStatus(bool banStatus)
        {
            IsBanned = Convert.ToInt32(banStatus);
        }

        public string Login
        {
            get { return user.Login; }
            set
            {
                user.Login = value.Trim();
                OnPropertyChanged();
            }

        }
        public string Password
        {
            get { return user.Password; }
            set
            {
                user.Password = value.Trim();
                OnPropertyChanged();
            }
        }

        public string Email
        {
            get { return user.Email; }
            set
            {
                user.Email = value.Trim();
                OnPropertyChanged();
            }
        }

        public int Id
        {
            get { return user.id; }
            set
            { 
                user.id = value;
                OnPropertyChanged(); 
            }
        }

        public int IsBanned
        {
            get { return user.IsBanned; }
            set
            {
                if (value > 1 || value == 1)
                    user.IsBanned = 1;
                else
                    user.IsBanned = 0;

                OnPropertyChanged();
            }
        }

        public Statuses Status
        {
            get { return user.Status; }
            set
            {
                user.Status = value;
                OnPropertyChanged();
            }
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
