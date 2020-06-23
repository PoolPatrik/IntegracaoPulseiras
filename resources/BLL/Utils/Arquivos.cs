using System;
using System.IO;

namespace BLL
{
    /// <summary>
    /// Gerencia a leitura e gravação dos arquivos de texto que armazenam os dados de conexão e data do ultimo registro importado
    /// </summary>
    public class Arquivos
    {
        public void SalvarConfigs(DataBase.DadosConexao dadosConexao, string nomeArquivo)
        {

            try
            {
                string[] lines = { "servidor: " + dadosConexao.Servidor, "usuario: " + dadosConexao.Usuario, "senha: " + dadosConexao.Senha, "banco: " + dadosConexao.Banco };
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
                String[] spearator = { ": "};
                while ((line = file.ReadLine()) != null)
                {
                    String[] str = line.Split(spearator, 2, StringSplitOptions.RemoveEmptyEntries);
                    linhaDoArquivo[i] = str[1];
                    i++;
                }
               return linhaDoArquivo;
            }
        }

        //lê arquivo que guarda ultima data lida 
        public string LerUltimaData(string nomeArquivo)
        {
            string caminho = AppDomain.CurrentDomain.BaseDirectory.ToString();
            using (StreamReader file = File.OpenText(caminho + nomeArquivo))
            {
                var data = file.ReadToEnd();
                return data;
            }
        }

        //salva data lida mais recente
        public void SalvarUltData(DateTime data)
        {
            try
            {
                string caminho = AppDomain.CurrentDomain.BaseDirectory.ToString();
                File.WriteAllText(caminho + @"\UltimaLeitura.txt", data.ToString());
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

