using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace day4Homework.Models
{
    public class Group
    {
        public Group()
        {
            Users = new HashSet<User>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
