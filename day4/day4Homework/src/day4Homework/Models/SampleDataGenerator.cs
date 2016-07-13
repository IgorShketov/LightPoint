using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace day4Homework.Models
{
    public class SampleDataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetService<UsersContext>();

            if (!context.Groups.Any())
            {
                var Group1 = new Group
                {
                    Name = "Admins",
                    Description = "We are the law",
                };

                var User1 = new User { Name = "User1" };

                User1.UserApps.Add(new Application
                {
                    Name = "Application1"
                });

                User1.UserApps.Add(new Application
                {
                    Name = "Application2"
                });

                var User2 = new User { Name = "User2" };

                User1.UserApps.Add(new Application
                {
                    Name = "Application3"
                });

                Group1.Users.Add(User1);
                Group1.Users.Add(User2);

                context.Groups.Add(Group1);

                context.SaveChanges();
            }
        }
    }
}
