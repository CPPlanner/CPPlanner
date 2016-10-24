using CPPlanner.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassTrack.Models
{
    public class CPPlannerContextSeedData
    {
        private CPPlannerContext _context;
        private UserManager<CPPlannerUser> _userManager;

        public CPPlannerContextSeedData(CPPlannerContext context, UserManager<CPPlannerUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task EnsureSeedData()
        {
            if (await _userManager.FindByEmailAsync("test@email.com") == null)
            {
                var user = new CPPlannerUser()
                {
                    UserName = "username",
                    Email = "test@email.com"
                };

                await _userManager.CreateAsync(user, "P@ssw0rd");
            }

            await _context.SaveChangesAsync();  // push changes into database
        }

    }
}
