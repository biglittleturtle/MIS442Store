using MIS442Store.DataLayer.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace MIS442Store.Controllers
{
    public class NewsController : Controller
    {
        // GET: News
        public ActionResult Index()
        {
            ViewBag.Title = "MIS442 News";
            ViewBag.Header = "MIS442 News";

            List<News> myList = new List<News>();
            News items = new News();
            News items2 = new News();

            items.id = 1;
            items.title = "My Store";
            items.author = "Travis";
            items.body = "This is my 442 Store";
            items.date = "4/20/17";

            items2.id = 2;
            items2.title = "Thomas' Store";
            items2.author = "Thomas";
            items2.body = "This is Thomas' 442 Store";
            items2.date = "4/20/17";

            myList.Add(items);
            myList.Add(items2);

            return View(GetNews());
        }

        private List<News> GetNews()
        {
            List<News> myList = new List<News>();
                 
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DB_MIS442"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM News";
                    command.CommandType = CommandType.Text;

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            News items2 = new News();
                            items2.id = int.Parse(reader["ID"].ToString());
                            items2.title = reader["Title"].ToString();
                            items2.body = reader["Body"].ToString();
                            items2.author = reader["Author"].ToString();
                            items2.date = reader["DatePosted"].ToString();

                            myList.Add(items2);
                        }
                    }
                }
            }
            return myList;
        }
    }
}