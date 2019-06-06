using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job_DB_tryMVP
{
    public class BaseDepartment
    {
        private string dp;
        private int id;
        public virtual string DP { get => dp; set => dp = value; }
        public virtual int Id { get=>id; set=>id=value; }


    }
}
