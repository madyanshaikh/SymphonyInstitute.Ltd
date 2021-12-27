using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using SymphonyInstitute.Ltd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SymphonyInstitute.Ltd.Services
{
    public class ApplicationUserClaimsPricipalFactory : UserClaimsPrincipalFactory<ApplicationUser, IdentityRole>
    {

        public StudentDbContext _context;
        public ApplicationUserClaimsPricipalFactory(UserManager<ApplicationUser> userManager,
             RoleManager<IdentityRole> roleManager, IOptions<IdentityOptions> options, StudentDbContext context) : base(userManager, roleManager, options)
        {
            _context = context;
        }

        protected async override Task<ClaimsIdentity> GenerateClaimsAsync(ApplicationUser user)
        {
            var _user = _context.Student.FirstOrDefault(x => x.AspNetUsersId == user.Id);
            var identity = await base.GenerateClaimsAsync(user);
            identity.AddClaim(new Claim("UserFirstName", _user.Fname ?? ""));
            identity.AddClaim(new Claim("UserLastName", _user.Lname ?? ""));
            identity.AddClaim(new Claim("UserId", _user.AspNetUsersId ?? ""));
            return identity;
        }
    }
}
