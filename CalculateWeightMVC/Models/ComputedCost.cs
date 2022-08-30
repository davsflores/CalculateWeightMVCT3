using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CalculateWeightMVC.Models
{
    public class ComputedCostModel
    {
        public int computedcostid { get; set; }
        public string priority { get; set; }
        public string type { get; set; }
        public double weight { get; set; }
        public double cost { get; set; }
        public double totalcost { get; set; }

        public ComputedCostModel()
        {
            computedcostid = -1;
            priority = "none";
            type = "none";
            weight = 10.00;
            cost = 10.00;
            totalcost = 10.00;
        }

        public ComputedCostModel(int computedcostid, string priority, string type, double weight, double cost, double totalcost)
        {
            this.computedcostid = computedcostid;
            this.priority = priority;
            this.type = type;
            this.weight = weight;
            this.cost = cost;
            this.totalcost = totalcost;
        }

    }
}