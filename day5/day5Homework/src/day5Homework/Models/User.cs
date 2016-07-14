using day5Homework.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace day5Homework.Models
{
    public class User : IdentityUser
    {
        public User()
        {
            UserApps = new HashSet<Application>();
        }
        public virtual ICollection<Application> UserApps { get; set; }
    }
}
