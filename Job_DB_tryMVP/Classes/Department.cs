using System;
using System.ComponentModel;
using System.Data.Entity;


namespace Job_DB_tryMVP
{
    public class Department : IComparable<Department>, IEquatable<Department>
    {
        private string dp;
        private int id;
        public static int MaxId = -1;

        public string DP
        {
            get => dp;
            set
            {
                dp = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(DP)));
            }
        }
        public int Id { get => id; set => id = value; }

        public event PropertyChangedEventHandler PropertyChanged;

        private Department()
        {

        }

        public Department(string s)
        {
            this.dp = s;

        }


        public override string ToString()
        {
            return $"{dp}";
        }

       

        public bool Equals(Department other)
        {
            return other.DP == this.DP;
        }

        public int CompareTo(Department other)
        {
            return (this.id > other.Id) ? 1 : -1;
        }
    }
}
