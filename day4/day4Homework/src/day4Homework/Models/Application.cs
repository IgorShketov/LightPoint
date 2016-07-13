using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace day4Homework.Models
{
    public class Application
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
