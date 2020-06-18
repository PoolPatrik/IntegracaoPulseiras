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
        public string Codigo { get; set; }
        public DateTime DateTime { get; set; }

        private string _status;
        public string Status
        {
            get => _status;
            set
            {
                if (value == "1") //Estado 1 na tabela externa indica livre
                    _status = "0"; //Estado 0 na tabela de integração do acesso.net indica livre
                else
                    _status = "1"; //Estado 1 representa bloqueado na tabela do Acesso.net
            }
        }

        public Pulseira()
        {

        }
        public Pulseira(string codigo, string estado)
        {
            Codigo = codigo;
            Status = estado;
        }

        //grava lista de pulseira na tabela de integracao_externa do Acesso.net
        public void GravarPulseiraSql(DataBase bancoSql)
        {

            string queryString = "insert into integracao_externa (n_folha, n_identificador, estado)values('" + this.Codigo + "','" + this.Codigo + "', '" + this.Status + "');";

            new DAL.ConexaoSQL(bancoSql.Servidor, bancoSql.Usuario, bancoSql.Senha, bancoSql.Banco).ExecutarComando(queryString);

        }
        //Limpa tabela de integração externa do banco do Acesso.net
        public static void LimparIntegracaoExterna(DataBase bancoSql)
        {

            string queryString = "delete integracao_externa where LEITURA_STATUS = 'true'";

            new DAL.ConexaoSQL(bancoSql.Servidor, bancoSql.Usuario, bancoSql.Senha, bancoSql.Banco).ExecutarComando(queryString);

        }

        //lê todos os cadastros existentes na base externa
        public static List<Pulseira> LerPulseirasMySql(DataBase bancoMySql, DateTime data)
        {

            string queryString = $"select * from pulseiras where data_alteracao >= '{data.ToString()}'";
            List<Pulseira> listaDePulseiras;

            var dataTable = new DAL.ConexaoMySql(bancoMySql.Servidor, bancoMySql.Usuario, bancoMySql.Senha, bancoMySql.Banco).ExecutarComando(queryString);

            listaDePulseiras = CriaListaDePulseiras(dataTable);

            return listaDePulseiras;

        }

        //Cria lista de pulseiras a partir do datatable recebido
        private static List<Pulseira> CriaListaDePulseiras(DataTable dt)
        {
            var list = new List<Pulseira>();

            {

                list = dt.AsEnumerable().Select(linha => new Pulseira
                {
                    Codigo = linha.Field<String>("descricao"),
                    DateTime = linha.Field<DateTime>("data_alteracao"),
                    Status = linha.Field<Int32>("status").ToString()
                }).ToList();

                return list;
            }

        }

    }
}