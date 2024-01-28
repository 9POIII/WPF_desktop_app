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
    internal class StudentViewModel : UserViewModel, INotifyPropertyChanged
    {
        private Student student;

        private ApplicationContext db;

        public event PropertyChangedEventHandler PropertyChanged;

        public StudentViewModel(User s) : base(s)
        {
            student = s as Student;
            CreateUserInDB();
        }
    }

}
