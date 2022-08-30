using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CalculateWeightMVC.Models
{
    public class WeightTable
    {
        public int priorityId { get; set; }
        public string priority { get; set; }
        public string type { get; set; }
        public int minweight { get; set; }
        public int maxweight { get; set; }
        public decimal cost { get; set; }

    }
}