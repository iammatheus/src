using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace TodoList.Domain.Identity
{
    public class User : IdentityUser<int>
    {
        public string FullName { get; set; }
        public string ImagemURL { get; set; }
        public IEnumerable<UserRole> UserRoles { get; set; }
    }
}