using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job_DB_tryMVP
{
    public class BaseEmployee
    {
        private int id;
        private string firstname;
        private string lastname;
        private string department;
        private int salary;

        public virtual int Id { get => id; set => id = value; }
        public virtual string FirstName { get => firstname; set => firstname = value; }
        public virtual string LastName { get => lastname; set => lastname = value; }
        public virtual string Dep { get => department; set => department = value; }
        public virtual int Salary { get => salary; set => salary = value; }




    }
}
