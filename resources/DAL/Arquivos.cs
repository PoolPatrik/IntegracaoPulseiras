using System;
using System.IO;

namespace DAL
{
    /// <summary>
    /// Gerencia a leitura e gravação dos arquivos de texto que armazenam os dados de conexão e data do ultimo registro importado
    /// </summary>
    public class Arquivos
    {
        public void SalvarConfigs(string servidor, string usuario, string senha, string banco, string nomeArquivo)
        {

            try
            {
                string[] lines = { "servidor:" + servidor, "usuario:" + usuario, "senha:" + senha, "banco:" + banco };
                string caminho = System.AppDomain.CurrentDomain.BaseDirectory.ToString();


                System.IO.File.WriteAllLines(caminho + nomeArquivo, lines);

            }
            catch (FileNotFoundException e)
            {

                Console.WriteLine($"The file was not found: '{e}'");
                Console.WriteLine();
            }
            catch (DirectoryNotFoundException e)
            {

                Console.WriteLine($"The directory was not found: '{e}'");
                Console.WriteLine();
            }
            catch (IOException e)
            {

                Console.WriteLine($"The file could not be opened: '{e}'");
                Console.WriteLine();
            }

        }

        //lê arquivo de conexão de acordo com o parametro recebido
        public string[] LerDados(string nomeArquivo)
        {
            string caminho = System.AppDomain.CurrentDomain.BaseDirectory.ToString();
            using (StreamReader file = File.OpenText(caminho + nomeArquivo))
            {
                string[] linhaDoArquivo = new string[4];
                string line;
                int i = 0;
                while ((line = file.ReadLine()) != null)
                {
                    var a = line.Split(':');
                    linhaDoArquivo[i] = a[1];
                    i++;
                }

                return linhaDoArquivo;
            }
        }


        public string LerUltimaData(string nomeArquivo)
        {
            string caminho = System.AppDomain.CurrentDomain.BaseDirectory.ToString();
            using (StreamReader file = File.OpenText(caminho + nomeArquivo))
            {
                var data = file.ReadToEnd();

                return data;
            }
        }

        public void SalvarUltData(DateTime data)
        {
            try
            {
                string caminho = System.AppDomain.CurrentDomain.BaseDirectory.ToString();
                System.IO.File.WriteAllText(caminho + @"\UltimaLeitura.txt", data.ToString());

            }
            catch (FileNotFoundException e)
            {

                Console.WriteLine($"The file was not found: '{e}'");
                Console.WriteLine();
            }
            catch (DirectoryNotFoundException e)
            {

                Console.WriteLine($"The directory was not found: '{e}'");
                Console.WriteLine();
            }
            catch (IOException e)
            {

                Console.WriteLine($"The file could not be opened: '{e}'");
                Console.WriteLine();
            }

        }
    }


}

