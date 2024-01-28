using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace FinanceApp2._0.Models
{
    public enum Statuses
    {
        Unknown,
        Unemployed,
        Employed,
        Student,
    }

    internal class User
    {
        private string login;
        private string password;
        private string email;
        private int isBanned;
        private Statuses status;

        public int id { get; set; }
        public int IsBanned { get { return isBanned; } set { isBanned = value; } }
        public string Login { get { return login; } set { login = value; } }
        public string Password { get { return password; } set { password = value; } }
        public string Email { get { return email; } set { email = value; } }
        public Statuses Status { get { return status; } set { status = value; } }

        public User() { }
    }
}
