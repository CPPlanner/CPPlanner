using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPPlanner.Models
{
    public class CPPlannerRepository : ICPPlannerRepository
    {
        private CPPlannerContext _context;

        public CPPlannerRepository(CPPlannerContext context)
        {
            _context = context;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}
