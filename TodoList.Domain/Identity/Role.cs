using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace TodoList.Domain.Identity
{
    public class Role : IdentityRole<int>
    {
        public IEnumerable<UserRole> UserRoles { get; set; }
    }
}
