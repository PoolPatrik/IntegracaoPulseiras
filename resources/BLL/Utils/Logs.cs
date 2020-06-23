using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    /// <summary>
    /// Responsavel por gravar logs de erros e de funcinamento
    /// </summary>
    public class Logs
    {
        public static void Gravar(string texto, bool erro)
        {
            string local;

            //determina o tipo de log de acordo com o paramentro recebido
            if (erro == false)
            {
                local = @"\log.txt";
            }
            else
            {
                local = @"\logErros.txt";
            }

            var caminho = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);//pega o diretorio de onde a aplicação foi executada
            using (StreamWriter outputFile = new StreamWriter(caminho + local, true))
            {
                String data = DateTime.Now.ToShortDateString();
                String hora = DateTime.Now.ToShortTimeString();
                outputFile.WriteLine(data + " " + hora + " : " + texto);

                Console.WriteLine(data + " " + hora + " : " + texto);
            }

        }
    }
}
