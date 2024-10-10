using Dapper;
using System.Data.SqlClient;

namespace DapperLearn
{
    public class ProductRepository
    {
        private readonly string _connectionString = "Server = DESKTOP-OBCSS28;Database = Northwind;User Id = sa;Password=1234;";
        public List<Product> GetAllProducts()
        {
            List<Product> products = new List<Product>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string sql = "select * from products";
                products = connection.Query<Product>(sql).ToList();
            }
            return products;
        }
        public Product GetProductById(int id)
        {
            Product product = new Product();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "select * from products where ProductId=@productId";
                product = connection.QueryFirstOrDefault<Product>(query, new { productId = id });
            }
            return product;
        }
        public Product GetProductById2(int id)
        {
            Product product = new Product();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "select * from products where ProductId=@productId";
                DynamicParameters parameters = new();
                parameters.Add("@productId",id);
                parameters.Add("", "asdasf");
                parameters.AddDynamicParams(new {ProductId = id });
                product = connection.QueryFirstOrDefault<Product>(query,parameters);
            }
            return product;
        }
        public void AddUser()
        {
            using (SqlConnection connection = new SqlConnection("Server=DESKTOP-OBCSS28;Database = CourseAppDb;User Id=sa;Password=1234;"))
            {
                string sql = "insert into Users (Fullname,Role,Password) values (@fullName,@role,@password)";
                string fullname = "mert";
                string role = "admin";
                string password = "1234";
                //connection.Execute(sql, new {fullname,role,password});
                connection.Execute(sql, new { fullName = fullname, role = role, password = password });
            }
        }
    }
}
