using Proje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Web;
using System.Web.Mvc;
using Microsoft.SqlServer.Server;

namespace Proje.Controllers
{
    public class AccountController : Controller
    {
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;

        // GET: Account
        [HttpGet]
        public ActionResult Login()
        {

            return View();
        }

        void connectionString()
        {
            con.ConnectionString = "data source=DESKTOP-GP1APGD\\SQLEXPRESS; database=WPF; integrated security = SSPI;";
        }

        [HttpPost]
        public ActionResult Verify(Account acc)
        {
            connectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "select * from tbl_login where username='"+acc.Name+"' and password='"+acc.Password+"'";
            dr=com.ExecuteReader();
            if(dr.Read())
            {
                con.Close();
                return View("Create");
            }
            else
            {
                con.Close();
                return View("Error");
            }
            
            
        }
    }
}