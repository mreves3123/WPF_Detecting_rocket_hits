using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Reporter
    {
        [Key]
        public string user { get; set; }
        public string password { get; set; }

        public Reporter(string user, string password)
        {
            this.user = user;
            this.password = password;
        }
        public Reporter()
        {
            this.user = "";
            this.password = "";
        }
    }
}
