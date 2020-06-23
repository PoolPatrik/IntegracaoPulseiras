namespace BLL
{
    /// <summary>
    /// gerencia os dados de conexão de cada base e dados
    /// </summary>
    public class DataBase
    {
        const string ARQUIVOMYSQL = @"\ConfigMySql.txt";
        const string ARQUIVOSQL = @"\ConfigSql.txt";

        //estrutura de dads para conexao
        public class DadosConexao
        {
            public string Servidor { get; set; }
            public string Usuario { get; set; }
            public string Senha { get; set; }
            public string Banco { get; set; }
            public TipoBanco TipoBanco { get; set; }

            //contrutor recebe apenas o tipo de banco, então busca lê as configurações salvas em arquivo txt
            public DadosConexao(string tipobanco)
            {
                var dadosArquivo = new DataBase().Ler(DefinirTipoBanco(tipobanco));

                Servidor = dadosArquivo[0];
                Usuario = dadosArquivo[1];
                Senha = Criptografia.Decrypt(dadosArquivo[2]);
                Banco = dadosArquivo[3];
                TipoBanco = DefinirTipoBanco(tipobanco);
            }

            //contrutor recebe 5 parametros para criar um novo elemento na estrutura de Dados Conexão
            public DadosConexao(string server, string user, string senha, string banco, string tipobanco)
            {
                Servidor = server;
                Usuario = user;
                Senha = Criptografia.Crypt(senha);
                Banco = banco;
                TipoBanco = DefinirTipoBanco(tipobanco);
            }
        }

        //Define os tipo de banco de dados possiveis
        public static TipoBanco DefinirTipoBanco(string valor)
        {
            const string MYSQL = "MySql";
            if (valor == MYSQL)
            {
                return TipoBanco.MySql;
            }
            return TipoBanco.Sql;
        }
        public enum TipoBanco
        {
            MySql = 0,
            Sql = 1
        }

        public DataBase()
        {

        }

        //salva configurações de conexão em arquivo txt de acordo com o atributo TipoBanco da conexao
        //o nome do arquivo é definidi de acordo com o TipoBanco
        public void Salvar(DadosConexao dadosConexao)
        {
            if (dadosConexao.TipoBanco == TipoBanco.MySql)
            {
                new Arquivos().SalvarConfigs(dadosConexao, ARQUIVOMYSQL);
            }
            else
            {
                new Arquivos().SalvarConfigs(dadosConexao, ARQUIVOSQL);
            }
        }

        //lê arquivo de conexão de acordo com to TipoBanco
        public string[] Ler(TipoBanco tipoBanco)
        {
            if (tipoBanco == TipoBanco.MySql)
            {
                return new Arquivos().LerDados(ARQUIVOMYSQL);
            }
            else
            {
                return new Arquivos().LerDados(ARQUIVOSQL);
            }
        } 
        
        //testa a conexaop com o banco
        public void TestarConexao(DadosConexao banco)
        {
            if (banco.TipoBanco == TipoBanco.MySql)
            {
                new DAL.ConexaoMySql(banco.Servidor, banco.Usuario, banco.Senha, banco.Banco).Testar();
            }
            else 
            {
                new DAL.ConexaoSQL(banco.Servidor, banco.Usuario, banco.Senha, banco.Banco).Testar();
            }
        }
    }
}
