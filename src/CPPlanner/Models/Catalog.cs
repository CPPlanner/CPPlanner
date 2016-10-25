using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPPlanner.Models
{
    public class Catalog
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public int Year { get; set; }
        public string Major { get; set; }
        public string Subplan { get; set; }
        public int MinUnitsReq { get; set; }        

        public ICollection<Module> Modules { get; set; }
    }
}
