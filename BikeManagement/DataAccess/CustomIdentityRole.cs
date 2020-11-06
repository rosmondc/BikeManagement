using Microsoft.AspNetCore.Identity;

namespace BikeManagement.DataAccess
{
    public class CustomIdentityRole : IdentityRole
    {
        public string Description { get; set; }
    }
}

