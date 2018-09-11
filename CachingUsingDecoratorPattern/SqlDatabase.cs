using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CachingUsingDecoratorPattern
{
    class SqlDatabase : IRepository
    {
        private SqlConnection conn;
        private void connection()
        {
            string connectionString ="Data Source=TAVDESK092\\SQLEXPRESS;Initial Catalog=Products;Integrated Security=True"; 
            conn = new SqlConnection(connectionString);
        }
        public List<Product> GetAllProducts()
        {
            connection();
            List<Product> productList = new List<Product>();
            string query = "SELECT * FROM Products";
            SqlCommand command = new SqlCommand(query, conn)
            {
                CommandType = CommandType.Text
            };
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            conn.Open();
            dataAdapter.Fill(dataTable);
            conn.Close();
            foreach (DataRow dr in dataTable.Rows)
            {
                productList.Add(
                    new Product
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        Name = Convert.ToString(dr["Name"]),
                        Price = (float)Convert.ToDouble(dr["Price"])
                    }
                );

            }
            return productList;
        }

        public Product GetProductById(int id)
        {
            connection();
            List<Product> productList = new List<Product>();
            string query = "SELECT * FROM Products where Id=" + id;
            SqlCommand command = new SqlCommand(query, conn)
            {
                CommandType = CommandType.Text
            };
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            conn.Open();
            dataAdapter.Fill(dataTable);
            conn.Close();
            foreach (DataRow dr in dataTable.Rows)
            {
                productList.Add(
                    new Product
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        Name = Convert.ToString(dr["Name"]),
                        Price = (float)Convert.ToDouble(dr["Price"])
                    }
                );

            }
            return productList[0];
        }
    }
}
