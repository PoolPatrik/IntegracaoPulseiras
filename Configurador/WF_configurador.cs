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

            txt_senhaMySql.PasswordChar = '*';
            txt_senhaSql.PasswordChar = '*';

        }

        BLL.DataBase bancoMySql;
        BLL.DataBase bancoSql;

        private void btn_importar_Click(object sender, EventArgs e)
        {
            CarregarDados();//garrega dados de conexão que estão salvos em um arquivo txt

            try
            {
                BLL.Importador.Importar(bancoMySql, bancoSql);

                MessageBox.Show("Importação Concluida!");
                BLL.Logs.Gravar("Importação manual concluida", false); //log funcionamento

            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Houve um erro ao conectar com o banco {bancoSql.Banco} \n\n {ex.Message}");
                BLL.Logs.Gravar(ex.Message, true); //log erros
            }

            catch (MySqlException ex)
            {
                MessageBox.Show($"Houve um erro ao conectar com o banco {bancoMySql.Banco} \n\n {ex.Message}");
                BLL.Logs.Gravar(ex.Message, true); //log erros

            }
            catch (Exception ex)
            {
                MessageBox.Show("Falha na importação!!! \n\n" + ex.Message);
                BLL.Logs.Gravar(ex.Message, true); //log erros
            }

        }

        private void btn_salvarConfig_Click(object sender, EventArgs e)
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
                BLL.Logs.Gravar(ex.Message, true); //log erros
            }

        }

        private void link_testeSql_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            TestarConexao(bancoSql);
        }

        private void link_testeMySql_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            TestarConexao(bancoMySql);
        }


        private void btn_carregar_Click(object sender, EventArgs e)
        {
            CarregarDados();
        }

        private void TestarConexao(DataBase banco)
        {
            try
            {
                SalvarConexao();//salva os dados de conexão que estiverem na tela antes de testar
                CarregarDados();
                banco.TestarConexao();
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
                bancoMySql = new BLL.DataBase("MySql", "ler");
                bancoSql = new BLL.DataBase("Sql", "ler");

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
                BLL.Logs.Gravar(ex.Message, true); //log erros
            }
        }

        private void LoadBar()
        {
            progressBar1.Increment(1);
        }

        private void SalvarConexao()
        {
            var bancoMySql = new BLL.DataBase(txt_serverMySql.Text, txt_userMySql.Text, txt_senhaMySql.Text, txt_bancoMySql.Text, "MySql");
            bancoMySql.Operacao("salvar");

            var bancoSql = new BLL.DataBase(txt_serverSql.Text, txt_userSql.Text, txt_senhaSql.Text, txt_bancoSql.Text, "Sql");
            bancoSql.Operacao("salvar");
        }

    }
}
