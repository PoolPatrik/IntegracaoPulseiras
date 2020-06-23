using DAL;

namespace BLL
{
    /// <summary>
    /// responsavel pela logica de importação dos registros
    /// </summary>
    public class Importador
    {
        public void Importar(DataBase.DadosConexao bancoMySql, DataBase.DadosConexao bancoSql)
        {
            {
                var dataHora = new Datas();
                var conexaoSql = CriarConexaoSql(bancoSql);
                var conexaoMySql = CriarConexaoMysql(bancoMySql);
                var pulseira = new Pulseira();
                //Busca todas as pulseira do banco de acordo com a ultima data lida
                var listaPulseira = pulseira.LerPulseirasMySql(conexaoMySql, dataHora.LerData());

                //Limpa tabela de integração
                pulseira.LimparIntegracaoExterna(conexaoSql);

                foreach (var item in listaPulseira)
                {
                    pulseira.GravarPulseiraSql(conexaoSql, item);
                    dataHora.EscolherMaior(item.DateTime);//verifica se é mais recente do que a data guardada 
                }
            }
        }

        //Cria conexão com banco de dados MySQL
        private ConexaoMySql CriarConexaoMysql(DataBase.DadosConexao bancoMySql)
        {          
            return new ConexaoMySql(bancoMySql.Servidor, bancoMySql.Usuario, bancoMySql.Senha, bancoMySql.Banco);
        }

        //Cria conexão com banco de dados SQL
        private ConexaoSQL CriarConexaoSql(DataBase.DadosConexao bancoSql)
        {
            return new ConexaoSQL(bancoSql.Servidor, bancoSql.Usuario, bancoSql.Senha, bancoSql.Banco);
        }
    }
}
