using CPPlanner.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CPPlanner.Models
{
    public interface ICPPlannerRepository
    {
        IEnumerable<Catalog> GetCatalogs(string username);
        Task<bool> SaveChangesAsync();
    }
}