using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPPlanner.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string Title { get; set; }
        public int Units { get; set; }
        public bool IsGE { get; set; }
        public string GEEquivalent { get; set; }
    }
}
