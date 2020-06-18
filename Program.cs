using MySql.Data.MySqlClient;
using System;
using System.Data.SqlClient;


namespace IntegracaoConsole
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                BLL.DataBase bancoMySql = new BLL.DataBase("MySql", "ler");//cria objeto com os parametros para conexar com MySql
                BLL.DataBase bancoSql = new BLL.DataBase("Sql", "ler");//cria objeto com os parametros para conexar com SqlServer
                BLL.Importador.Importar(bancoMySql, bancoSql);

                BLL.Logs.Gravar("Importação console realizada", false); //log funcionamento
            }
            catch(Exception ex)
            {
                BLL.Logs.Gravar(ex.Message, true); //log erros

            }
        }
        
    }
}
