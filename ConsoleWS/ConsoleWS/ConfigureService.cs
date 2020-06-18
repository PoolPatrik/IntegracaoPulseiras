using Topshelf;

namespace ConsoleWS
{
    /// <summary>
    /// Esta classe é responsavel pela configuração de inicialização, execução e parada do serviço
    /// utiliza bibliotec  TopShelf para realizar a configuração do serviço
    /// </summary>
    /// 
    public class ConfigureService
    {
        internal static void Configure()
        {
            HostFactory.Run(configure =>
            {
                configure.Service<MeuServicoWS>(service =>
                {
                    service.ConstructUsing(s => new MeuServicoWS());
                    service.WhenStarted(s => s.Start());
                    service.WhenStopped(s => s.Stop());
                });
               
                configure.RunAsLocalSystem(); //Conta que o serviço do Windows usa para rodar
                configure.SetServiceName("SecullumImportador");
                configure.SetDisplayName("SecullumImportador");
                configure.SetDescription("Serviço para importação de pulseiras.");
            });
        }
    }
}
