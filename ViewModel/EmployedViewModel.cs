using FinanceApp2._0.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FinanceApp2._0.ViewModel
{
    internal class EmployedViewModel : INotifyPropertyChanged
    {
        private Employed employed;

        private ApplicationContext db;

        public event PropertyChangedEventHandler PropertyChanged;

        public EmployedViewModel(Employed s)
        {
            employed = s;
        }

        public void CreateUserInDB()
        {
            db = new ApplicationContext();
            db.Users.Add(employed);
            db.SaveChanges();
        }

        public void ToggleBanStatus(bool banStatus)
        {
            IsBanned = Convert.ToInt32(banStatus);
        }

        public string Login
        {
            get { return employed.Login; }
            set
            {
                employed.Login = value.Trim();
                OnPropertyChanged();
            }

        }
        public string Password
        {
            get { return employed.Password; }
            set
            {
                employed.Password = value.Trim();
                OnPropertyChanged();
            }
        }

        public string Email
        {
            get { return employed.Email; }
            set
            {
                employed.Email = value.Trim();
                OnPropertyChanged();
            }
        }

        public int Id
        {
            get { return employed.id; }
            set
            {
                employed.id = value;
                OnPropertyChanged();
            }
        }

        public int IsBanned
        {
            get { return employed.IsBanned; }
            set
            {
                if (value > 1 || value == 1)
                    employed.IsBanned = 1;
                else
                    employed.IsBanned = 0;

                OnPropertyChanged();
            }
        }

        public Statuses Status
        {
            get { return employed.Status; }
            set
            {
                employed.Status = value;
                OnPropertyChanged();
            }
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }

}

