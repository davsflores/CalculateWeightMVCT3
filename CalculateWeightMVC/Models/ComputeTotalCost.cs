using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CalculateWeightMVC.Models
{
    public class ComputeTotalCostModel
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Weight must be greater than 0")]

        public int itemweight { get; set; }

        public double itemcost { get; set; }

        public double itemtotalcost { get; set; }


        public ComputeTotalCostModel()
        {
            itemweight = -1;
            itemcost = 10.00;
            itemtotalcost = 10.00;
        }

        public ComputeTotalCostModel(int itemweight, double itemcost, double itemtotalcost)
        {
            this.itemweight = itemweight;
            this.itemcost = itemcost;
            this.itemtotalcost = itemtotalcost;

        }
    }
}