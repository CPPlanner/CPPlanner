using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPPlanner.Models
{
    public class Module
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Units { get; set; }

        public ICollection<Course> Courses { get; set; }
    }
}
