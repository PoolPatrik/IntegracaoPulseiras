using System.Data;
using MySql.Data.MySqlClient;

namespace DAL
{
    public class ConexaoMySql
    {
        private readonly string connectionString;

        //Construtor
        public ConexaoMySql(string servidor, string usuario, string senha, string banco)
        {
            connectionString = $"Server = {servidor}; Database = {banco}; Uid = {usuario}; Pwd = {senha}";
        }
        public DataTable ExecutarComando(string query)
        {
            DataTable dataTable = new DataTable();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataAdapter dataAdapt = new MySqlDataAdapter
                {
                    SelectCommand = command
                };

                command.Connection.Open();
                dataAdapt.Fill(dataTable);
            }
            return dataTable;
        }

        public void Testar()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
            }
        }
    }
}
