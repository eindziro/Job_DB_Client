using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data.Entity;

namespace Job_DB_tryMVP
{
    public class Employee : INotifyPropertyChanged, IEquatable<Employee>,IComparable<Employee>
    {
        private string firstname;
        private string lastname;
        private string department;
        private int salary;
        public static int MaxId = -1;




        public event PropertyChangedEventHandler PropertyChanged;

        public int Id { get; set; }

        /// <summary>
        /// Имя сотрудника
        /// </summary>
        public string FirstName
        {
            get => firstname;
            set
            {
                firstname = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FirstName)));
            }
        }

        /// <summary>
        /// Фамилия сотрудника
        /// </summary>
        public string LastName
        {
            get => lastname;
            set
            {
                lastname = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(LastName)));
            }
        }
        /// <summary>
        /// Департамент
        /// </summary>
        public string Dep
        {
            get => department;
            set
            {
                department = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Dep)));
            }

        }

        /// <summary>
        /// Зарплата сотрудника
        /// </summary>
        public int Salary
        {
            get => salary;
            set
            {
                salary = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Salary)));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="surname">Фамилия</param>
        /// <param name="dp">Департамент</param>
        /// <param name="salary">Зарплата</param>
        /// 

        private Employee()
        {
            if (this.Id > MaxId) MaxId = this.Id;


        }
        public Employee(string name, string surname, string dp, int salary) : this()
        {
            this.firstname = name;
            this.lastname = surname;
            this.salary = salary;
            this.department = dp;


        }

        public override string ToString()
        {
            return $"{lastname}   {firstname}   {department}   {salary}";
        }

        public bool Equals(Employee other)
        {
            return (other.FirstName == this.FirstName) && (other.LastName == this.LastName) && (other.Salary == this.Salary) && (other.Dep == this.Dep);
        }

        public int CompareTo(Employee other)
        {
            return this.Id > other.Id ? 1 : -1;
        }
    }
}
