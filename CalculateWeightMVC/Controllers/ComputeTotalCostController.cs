using CalculateWeightMVC.Data;
using CalculateWeightMVC.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CalculateWeightMVC.Controllers
{
    public class ComputeTotalCostController : Controller
    {

        public ActionResult ProcessCompute()
        {
            return View("ComputeForm");
        }

        [HttpPost]
        public ActionResult ProcessCompute(ComputeTotalCostModel computetotalcostModel)
        {
            ComputeTotalCostDAO computetotalcostDAO = new ComputeTotalCostDAO();

            computetotalcostDAO.ProcessCompute(computetotalcostModel);

            return View("ComputeForm");
        }

    }
}