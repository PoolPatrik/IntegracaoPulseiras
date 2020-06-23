using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BLL
{
    /// <summary>
    /// Responsavel por controlar as pulseiras que seram salvas no banco do acesso.net
    /// </summary>
    public class Pulseira
    {
        public class EstruturaPulseira
        {
            public string Codigo { get; set; }
            public DateTime DateTime { get; set; }
            public Status Estado { get; set; }
        }

        public static Status DefinirEstado(int valor)
        {
            const int ESTADOLIVREINTEGRACAO = 1;

            if (valor == ESTADOLIVREINTEGRACAO)
            {
                return Status.Livre;
            }
            return Status.Bloqueado;
        }

        public enum Status
        {
            Livre = 0,
            Bloqueado = 1
        }
        public Pulseira()
        {

        }

        //grava lista de pulseira na tabela de integracao_externa do Acesso.net
        public void GravarPulseiraSql(ConexaoSQL bancoSql, EstruturaPulseira estruturaPulseira)
        {
            var queryString = $"insert into integracao_externa (n_folha, n_identificador, estado)values(" +
                $"'{estruturaPulseira.Codigo}','{estruturaPulseira.Codigo}', '{estruturaPulseira.Estado.GetHashCode()}');";

            bancoSql.ExecutarComando(queryString);
        }

        //Limpa tabela de integração externa do banco do Acesso.net 
        public void LimparIntegracaoExterna(ConexaoSQL conexao)
        {
            var queryString = "delete integracao_externa where LEITURA_STATUS = 'true'";
            conexao.ExecutarComando(queryString);
        }

        //lê todos os cadastros existentes na base externa
        public List<EstruturaPulseira> LerPulseirasMySql(ConexaoMySql conexao, DateTime data)
        {
            var queryString = $"select * from pulseiras where data_alteracao >= '{data}'";
            var dataTable = conexao.ExecutarComando(queryString);
            return CriaListaDePulseiras(dataTable);
        }

        //Cria lista de pulseiras a partir do datatable recebido
        private List<EstruturaPulseira> CriaListaDePulseiras(DataTable dt)
        {
            return dt.AsEnumerable().Select(linha => new EstruturaPulseira
            {
                Codigo = linha.Field<String>("descricao"),
                DateTime = linha.Field<DateTime>("data_alteracao"),
                Estado = DefinirEstado(Convert.ToInt32(linha.Field<int>("status")))
            }).ToList();
        }
    }
}