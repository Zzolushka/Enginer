using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EnginerWebApplication.Data;
using Microsoft.AspNetCore.Identity;

namespace EnginerWebApplication.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
       public ICollection<Instruction> Instructions { get; set; }

        public ApplicationUser()
        {
            Instructions = new List<Instruction>();
        }
    }
}
