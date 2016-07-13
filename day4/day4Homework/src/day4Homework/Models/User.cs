using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace day4Homework.Models
{
    public class User
    {
        public User()
        {
            UserApps = new HashSet<Application>();  
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int GroupId { get; set; }
        public virtual Group Group { get; set; }
        public virtual ICollection<Application> UserApps { get; set; }
    }
}
