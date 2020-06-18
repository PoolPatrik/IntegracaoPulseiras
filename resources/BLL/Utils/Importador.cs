namespace BLL
{
    /// <summary>
    /// responsavel pela logica de importação dos registros
    /// </summary>
    public class Importador
    {
        public static void Importar(DataBase bancoMySql, DataBase bancoSql)
        {
            {
                var dataHora = new BLL.Datas();

                var pulseiras = BLL.Pulseira.LerPulseirasMySql(bancoMySql, dataHora.LerData());//Busca todas as pulseira do banco de acordo com a ultima data lida

                BLL.Pulseira.LimparIntegracaoExterna(bancoSql);//Limpa tabela de integração
                foreach (var pulseira in pulseiras)
                {
                    pulseira.GravarPulseiraSql(bancoSql);//salva no banco sql
                    dataHora.EscolherMaior(pulseira.DateTime);//verifica se é mais recente do que a data guardada 
                }
            }
        }
    }
}
