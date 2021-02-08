using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StocksCourseworkWebapp.Models.DatabaseObjects
{
    public class AccountFave
    {
        public int id { get; set; }
        public string userName { get; set; }
        public string favorite { get; set; }
    }
}
