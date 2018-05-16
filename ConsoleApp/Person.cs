using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ConsoleApp
{
    public class Person
    {
        public string name { get; set; }

        [Key]
        public virtual string Document { get; set; }
    }
}
