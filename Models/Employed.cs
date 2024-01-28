using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceApp2._0.Models
{
    internal class Employed : User
    {
        private float salary = 15000;

        public float Salary { get { return salary; } set { salary = value; } }
        public Employed() 
        {
        }
    }
}
