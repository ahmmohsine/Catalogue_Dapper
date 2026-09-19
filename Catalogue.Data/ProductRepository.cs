namespace Catalogue.Data
{
    public class ProductRepository
    {
        private string ConnectionString = "Data Source=PC_AHLAM\\DB_LEARNING;Initial Catalog=catalogueDB;Trusted_Connection=True;" +
                               "TrustServerCertificate=True;";

        public IEnumerable<Product> GetProductss()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                return connection.Query<ToDo>("Select * From product");
            }
        }

    }
}
