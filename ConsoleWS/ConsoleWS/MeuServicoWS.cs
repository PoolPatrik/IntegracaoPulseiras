using System;
using System.Diagnostics;
using System.Timers;
using BLL;

namespace ConsoleWS
{
    /// <summary>
    /// Esta classe é responsavel por definir o que acontece quando os serviço é iniciado ou parado, assim como o que ocorre durante a execução
    /// 
    /// </summary>
    public class MeuServicoWS
    {
        private DataBase.DadosConexao bancoMySql;
        private DataBase.DadosConexao bancoSql;

        //código que executa quando o Serviço do Windows Iniciar
        public void Start()
        {
            try
            {               
                bancoMySql = new DataBase.DadosConexao("MySql");//cria objeto com os parametros para conexar com MySql
                bancoSql = new DataBase.DadosConexao("Sql");//cria objeto com os parametros para conexar com SqlServer

                var timer1 = new Timer
                {
                    Interval = 10000 //a cada 10 segundos, a pulseiras podem ser atualizadas a qualquer momento
                };
                timer1.Elapsed += new ElapsedEventHandler(Timer1_Tick);
                timer1.Enabled = true;

                Logs.Gravar("Serviço iniciado", false); //log funcionamento
                Console.WriteLine("Serviço do Windows foi inicado");
            }
            catch (Exception ex)
            {
                Logs.Gravar(ex.Message, true); //log erros
            }
        }

        private void Timer1_Tick(object sender, ElapsedEventArgs e)
        {
            try
            {
                //Debugger.Launch();
                new Importador().Importar(bancoMySql, bancoSql);//chama o metodo importar passando os dois banco como paramentro
                Console.WriteLine("Importação realizada");
            }
            catch (Exception ex)
            {
                Logs.Gravar("Houve uma falha na importação, verifique o log de erros", false); //log funcionamento
                Console.WriteLine("Houve uma falha na importação, verifique o log de erros");
                Logs.Gravar(ex.Message, true); //log erros
            }
        }
        //código que executa quando o Serviço do Windows Parar
        public void Stop()
        {
            try
            {
                Logs.Gravar("Serviço parado", false); //log funcionamento
                Console.WriteLine("Serviço foi parado");
            }
            catch (Exception ex)
            {
                Logs.Gravar(ex.Message, true); //log erros
            }
        }
    }
}
