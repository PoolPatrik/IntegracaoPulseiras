using BLL;
using MySql.Data.MySqlClient;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Configurador
{
    public partial class WF_configurador : Form
    {
        public WF_configurador()
        {
            InitializeComponent();
            CarregarDados();
        }

        private DataBase.DadosConexao bancoMySql;
        private DataBase.DadosConexao bancoSql;

        private void Btn_importar_Click(object sender, EventArgs e)
        {
            CarregarDados();//Carrega dados de conexão que estão salvos em um arquivo txt

            try
            {
                new Importador().Importar(bancoMySql, bancoSql);
                MessageBox.Show("Importação Concluida!");
                Logs.Gravar("Importação manual concluida", false); //log funcionamento
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Houve um erro ao conectar com o banco {bancoSql.Banco} \n\n {ex.Message}");
                Logs.Gravar(ex.Message, true); //log erros
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Houve um erro ao conectar com o banco {bancoMySql.Banco} \n\n {ex.Message}");
                Logs.Gravar(ex.Message, true); //log erros
            }
            catch (Exception ex)
            {
                MessageBox.Show("Falha na importação!!! \n\n" + ex.Message);
                Logs.Gravar(ex.Message, true); //log erros
            }
        }
        private void Btn_salvarConfig_Click(object sender, EventArgs e)
        {
            try
            {
                SalvarConexao();
                CarregarDados();
                MessageBox.Show("Configurações salvas");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Houve um erro ao tentar salvar os arquivos configurações!!! \n\n" + ex.Message);
                Logs.Gravar(ex.Message, true); //log erros
            }
        }
        private void Link_testeSql_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            TestarConexao(bancoSql);
        }
        private void Link_testeMySql_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            TestarConexao(bancoMySql);
        }
        private void Btn_carregar_Click(object sender, EventArgs e)
        {
            CarregarDados();
        }
        private void TestarConexao(DataBase.DadosConexao banco)
        {
            try
            {
                SalvarConexao();//salva os dados de conexão que estiverem na tela antes de testar
                CarregarDados();
                new DataBase().TestarConexao(banco);
                MessageBox.Show("Conectado com exito");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Falha na conexão: " + ex.Message);
            }
        }
        private void CarregarDados()//carrega dados mySql
        {
            //preenche os dados de conexão na tela
            try
            {
                bancoMySql = new DataBase.DadosConexao("MySql");
                bancoSql = new DataBase.DadosConexao("Sql");

                txt_serverMySql.Text = bancoMySql.Servidor;
                txt_userMySql.Text = bancoMySql.Usuario;
                txt_senhaMySql.Text = bancoMySql.Senha;
                txt_bancoMySql.Text = bancoMySql.Banco;

                txt_serverSql.Text = bancoSql.Servidor;
                txt_userSql.Text = bancoSql.Usuario;
                txt_senhaSql.Text = bancoSql.Senha;
                txt_bancoSql.Text = bancoSql.Banco;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Houve um erro ao tentar abrir arquivos de configuração!!! \n\n" + ex.Message);
                Logs.Gravar(ex.Message, true); //log erros
            }
        }
        private void LoadBar()
        {
            progressBar1.Increment(1);
        }
        enum TipoBanco
        {
            MySql,
            Sql
        }
        private void SalvarConexao()
        {
            bancoMySql = new DataBase.DadosConexao(txt_serverMySql.Text, txt_userMySql.Text, txt_senhaMySql.Text, txt_bancoMySql.Text, "MySql");
            new DataBase().Salvar(bancoMySql);

            bancoSql = new DataBase.DadosConexao(txt_serverSql.Text, txt_userSql.Text, txt_senhaSql.Text, txt_bancoSql.Text, "Sql");
            new DataBase().Salvar(bancoSql);

            CarregarDados();
        }
    }
}
