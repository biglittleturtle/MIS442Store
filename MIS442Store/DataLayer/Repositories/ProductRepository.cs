using MIS442Store.DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MIS442Store.DataLayer.DataModels;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace MIS442Store.DataLayer.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public string ProductID { get; private set; }

        public Product Get(int id)
        {
            Product p = null;
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["OW206_5034\\SQLEXPRESS_MIS"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "spProduct_Get";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ProductID", id);

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            p = new Product();
                            p.ProductID = int.Parse(reader["ProductID"].ToString());
                        }
                    }
                }
            }
            return p;
        }

        public List<Product> GetList()
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["OW206_5034\\SQLEXPRESS_MIS"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "spGet_List";
                    command.CommandType = CommandType.StoredProcedure;

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                    }
                }
            }
        }

        public void Save(Product product)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["OW206_5034\\SQLEXPRESS_MIS"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "spInsert_Update";
                    command.CommandType = CommandType.StoredProcedure;

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                    }
                }
            }
        }
    }
}