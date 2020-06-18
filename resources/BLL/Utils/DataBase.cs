
namespace BLL
{
    /// <summary>
    /// gerencia os dados de conexão de cada base e dados
    /// </summary>
    public class DataBase
    {
        public string Servidor { get; set; }
        public string Usuario { get; set; }
        public string Senha { get; set; }
        public string Banco { get; set; }
        public string TipoBanco { get; set; }

        public DataBase(string tipo, string operacao)
        {
            TipoBanco = tipo;
            Operacao(operacao);
        }
        public DataBase(string text1, string text2, string text3, string text4, string text5)
        {
            Servidor = text1;
            Usuario = text2;
            Senha = text3;
            Banco = text4;
            TipoBanco = text5;
        }

        public void Operacao(string operacao)
        {
            var nomeArquivo = string.Empty;


            if (TipoBanco == "MySql")
            {
                nomeArquivo = @"\ConfigMySql.txt";

            }
            else if (TipoBanco == "Sql")
            {
                nomeArquivo = @"\ConfigSql.txt";
            }

            if (operacao == "salvar")
            {

                Salvar(nomeArquivo);
            }

            else if (operacao == "ler")
            {
                Ler(nomeArquivo);
            }

        }
        private void Salvar(string nomeArquivo)
        {
            new DAL.Arquivos().SalvarConfigs(Servidor, Usuario, Criptografia.Crypt(Senha), Banco, nomeArquivo);
        }

        private void Ler(string nomeArquivo)
        {
            var dadosArquivo = new DAL.Arquivos().LerDados(nomeArquivo);

            Servidor = dadosArquivo[0];
            Usuario = dadosArquivo[1];
            Senha = Criptografia.Decrypt(dadosArquivo[2]);
            Banco = dadosArquivo[3];

        }

        public void TestarConexao()
        {
            if (TipoBanco == "MySql")
            {
                new DAL.ConexaoMySql(Servidor, Usuario, Senha, Banco).Testar();

            }
            else if (TipoBanco == "Sql")
            {
                new DAL.ConexaoSQL(Servidor, Usuario, Senha, Banco).Testar();
            }
            
        }


    }
}
