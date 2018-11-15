using Microsoft.AspNetCore.Identity;

namespace XmasTreeApplication.Common.Entities
{
    public class StoreUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}