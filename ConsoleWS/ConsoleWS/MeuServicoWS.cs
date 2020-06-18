using System;
using System.Timers;

namespace ConsoleWS
{
   /// <summary>
   /// Esta classe é responsavel por definir o que acontece quando os serviço é iniciado ou parado, assim como o que ocorre durante a execução
   /// 
   /// </summary>
    public class MeuServicoWS
    {
        private BLL.DataBase bancoMySql;
        private BLL.DataBase bancoSql;

        //código que executa quando o Serviço do Windows Iniciar
        public void Start()
        {
            
            try
            {
                bancoMySql = new BLL.DataBase("MySql", "ler");//cria objeto com os parametros para conexar com MySql
                bancoSql = new BLL.DataBase("Sql", "ler");//cria objeto com os parametros para conexar com SqlServer

                var timer1 = new Timer();
                timer1.Interval = 10000; //a cada 10 segundos
                timer1.Elapsed += new System.Timers.ElapsedEventHandler(timer1_Tick);
                timer1.Enabled = true;

                BLL.Logs.Gravar("Serviço iniciado", false); //log funcionamento
                Console.WriteLine("Serviço do Windows foi inicado");
            }
            catch (Exception ex)
            {
                BLL.Logs.Gravar(ex.Message, true); //log erros
            }
        }

        private void timer1_Tick(object sender, ElapsedEventArgs e)
        {
            try
            {
                BLL.Importador.Importar(bancoMySql, bancoSql);//chama o metodo importar passando os dois banco como paramentro
                Console.WriteLine("Importação realizada");

            }
            catch (Exception ex)
            {
                BLL.Logs.Gravar("Houve uma falha na importação, verifique o log de erros", false); //log funcionamento
                Console.WriteLine("Houve uma falha na importação, verifique o log de erros");
                BLL.Logs.Gravar(ex.Message, true); //log erros
            }          
        }

        //código que executa quando o Serviço do Windows Parar
        public void Stop()
        {            
            try
            {
                BLL.Logs.Gravar("Serviço parado", false); //log funcionamento
                Console.WriteLine("Serviço foi parado");
            }
            catch (Exception ex)
            {
                BLL.Logs.Gravar(ex.Message, true); //log erros
            }
        }
    }
}
