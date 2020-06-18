using System.Data.SqlClient;

namespace DAL
{
    public class ConexaoSQL
    {
        private string connectionString;

        //Construtor
        public ConexaoSQL(string servidor, string usuario, string senha, string banco)
        {
            connectionString = $"Server = {servidor}; Database = {banco}; User = {usuario}; Password = {senha}";

        }
        public void ExecutarComando(string query)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }
         public void Testar()
         {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {             
                connection.Open();
            }
        }
    }
}
