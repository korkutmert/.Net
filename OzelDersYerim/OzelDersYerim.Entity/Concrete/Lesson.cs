using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OzelDersYerim.Entity.Concrete.Identity;

namespace OzelDersYerim.Entity.Concrete
{
    public class Lesson
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal PricePerHour { get; set; }
        public string Url { get; set; }
        public int BranchId { get; set; }
        public Branch Branch { get; set; }
        
    }
}