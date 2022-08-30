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

    public class ComputedCostController : Controller
    {

        // GET: ComputedCost
        public ActionResult Index()
        {
            List<ComputedCostModel> computedcosts = new List<ComputedCostModel>();
            ComputedCostDAO computedcostDAO = new ComputedCostDAO();
            computedcosts = computedcostDAO.FetchAll();

            return View("Index", computedcosts);
        }


        public ActionResult Details(int id)
        {
            ComputedCostDAO computedcostDAO = new ComputedCostDAO();
            ComputedCostModel computedcostModel = computedcostDAO.FetchOne(id);

            return View("Details", computedcostModel);
        }


        public ActionResult Edit(int id)
        {
            ComputedCostDAO computedcostDAO = new ComputedCostDAO();
            ComputedCostModel computedcost = computedcostDAO.FetchOne(id);

            return View("ComputedCostForm", computedcost);
        }


        public ActionResult Create()
        {
            return View("ComputedCostForm");
        }


        public ActionResult ProcessCreate(ComputedCostModel computedcostModel)
        {
            ComputedCostDAO computedcostDAO = new ComputedCostDAO();

            computedcostDAO.CreateOrUpdate(computedcostModel);

            return View("Details", computedcostModel);
        }
    }
}