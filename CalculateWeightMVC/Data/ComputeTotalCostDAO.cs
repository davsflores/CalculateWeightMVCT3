using CalculateWeightMVC.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CalculateWeightMVC.Data
{
    internal class ComputeTotalCostDAO
    {

        private string connectionString = @"Data Source=DESKTOP-9M2TMUQ;Initial Catalog=ComputeWeightMVCDb; Integrated Security=true";

        public int ProcessCompute(ComputeTotalCostModel computetotalcostModel)
        {

            string newpriority, newtype;
            decimal newcost;

            //Get the database
            using (SqlConnection sqlConn = new SqlConnection(connectionString))
            {
                SqlCommand sqlcom = new SqlCommand("Select priority, type, cost From Weight where minweight <= '" + computetotalcostModel.itemweight + "' And maxweight >= '" + computetotalcostModel.itemweight + "'", sqlConn);
                sqlConn.Open();
                SqlDataAdapter sda = new SqlDataAdapter(sqlcom);
                using (DataTable dt = new DataTable())
                {
                    sda.Fill(dt);
                    newpriority = (string)dt.Rows[0][0];
                    newtype = (string)dt.Rows[0][1];
                    newcost = (decimal)dt.Rows[0][2];
                }
                sqlConn.Close();
            }


            decimal newtotalcost;
            int itemw = (int)computetotalcostModel.itemweight;
            newtotalcost = (itemw * newcost);

            //insert record to database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "Insert Into ComputedCost Values(@priority, @type, @weight, @cost, @totalcost)";

                SqlCommand command = new SqlCommand(sqlQuery, connection);
                //command.Parameters.Add("@computedcostid", System.Data.SqlDbType.Int, 1000).Value = computedcostModel.computedcostid;
                command.Parameters.Add("@priority", System.Data.SqlDbType.VarChar, 1000).Value = newpriority;
                command.Parameters.Add("@type", System.Data.SqlDbType.VarChar, 1000).Value = newtype;
                command.Parameters.Add("@weight", System.Data.SqlDbType.Int, 1000).Value = computetotalcostModel.itemweight;
                command.Parameters.Add("@cost", System.Data.SqlDbType.Decimal, 2).Value = newcost;
                command.Parameters.Add("@totalcost", System.Data.SqlDbType.Decimal, 2).Value = newtotalcost;
                connection.Open();
                int newID = command.ExecuteNonQuery();
                computetotalcostModel.itemweight = 0;
                return newID;
            }

        }
    }
}