using az_2041.Models;
using Microsoft.Data.SqlClient;

namespace az_2041.Services
{
    public class ProductService
    {
        private static string db_source = "az2042.database.windows.net";
        private static string db_user = "AZ204vm";
        private static string db_password = "YS0pWZgEF1o5";
        private static string db_database = "az-2042";
        private SqlConnection GetConnection()
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            sqlConnectionStringBuilder.DataSource = db_source;
            sqlConnectionStringBuilder.UserID = db_user;
            sqlConnectionStringBuilder.Password = db_password;
            sqlConnectionStringBuilder.InitialCatalog=db_database;
            return new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
        }

        public List<Product> GetProducts()
        {
            SqlConnection conn = GetConnection();

            List<Product> products = new List<Product>();
            conn.Open();

            SqlCommand sqlCommand = new SqlCommand("Select * from Products", conn);

            using (SqlDataReader reader = sqlCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    Product product = new Product()
                    {
                        ProductID = reader.GetInt32(0),
                        ProductName = reader.GetString(1),
                        Quantity = reader.GetInt32(2),
                    };
                    products.Add(product);
                }
            }
            conn.Close();
            return products;
        }
    }
}
