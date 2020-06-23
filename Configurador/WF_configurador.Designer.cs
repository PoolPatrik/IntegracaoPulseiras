namespace Configurador
{
    partial class WF_configurador
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_carregar = new System.Windows.Forms.Button();
            this.btn_salvarMySql = new System.Windows.Forms.Button();
            this.btn_importar = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lbl_testeSql = new System.Windows.Forms.Label();
            this.txt_bancoSql = new System.Windows.Forms.TextBox();
            this.link_testeSql = new System.Windows.Forms.LinkLabel();
            this.txt_senhaSql = new System.Windows.Forms.TextBox();
            this.txt_serverSql = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_userSql = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbl_testeMySql = new System.Windows.Forms.Label();
            this.link_testeMySql = new System.Windows.Forms.LinkLabel();
            this.txt_serverMySql = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_userMySql = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_senhaMySql = new System.Windows.Forms.TextBox();
            this.txt_bancoMySql = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_carregar
            // 
            this.btn_carregar.Location = new System.Drawing.Point(345, 73);
            this.btn_carregar.Name = "btn_carregar";
            this.btn_carregar.Size = new System.Drawing.Size(120, 23);
            this.btn_carregar.TabIndex = 25;
            this.btn_carregar.Text = "Carregar Conexões";
            this.btn_carregar.UseVisualStyleBackColor = true;
            this.btn_carregar.Click += new System.EventHandler(this.Btn_carregar_Click);
            // 
            // btn_salvarMySql
            // 
            this.btn_salvarMySql.Location = new System.Drawing.Point(345, 108);
            this.btn_salvarMySql.Name = "btn_salvarMySql";
            this.btn_salvarMySql.Size = new System.Drawing.Size(120, 23);
            this.btn_salvarMySql.TabIndex = 1;
            this.btn_salvarMySql.Text = "Salvar Conexao";
            this.btn_salvarMySql.UseVisualStyleBackColor = true;
            this.btn_salvarMySql.Click += new System.EventHandler(this.Btn_salvarConfig_Click);
            // 
            // btn_importar
            // 
            this.btn_importar.Location = new System.Drawing.Point(365, 146);
            this.btn_importar.Name = "btn_importar";
            this.btn_importar.Size = new System.Drawing.Size(75, 23);
            this.btn_importar.TabIndex = 0;
            this.btn_importar.Text = "Importar";
            this.btn_importar.UseVisualStyleBackColor = true;
            this.btn_importar.Click += new System.EventHandler(this.Btn_importar_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.lbl_testeSql);
            this.groupBox2.Controls.Add(this.txt_bancoSql);
            this.groupBox2.Controls.Add(this.link_testeSql);
            this.groupBox2.Controls.Add(this.txt_senhaSql);
            this.groupBox2.Controls.Add(this.txt_serverSql);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txt_userSql);
            this.groupBox2.Location = new System.Drawing.Point(471, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(326, 216);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Config. SQL Server";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 143);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "Banco de Dados";
            // 
            // lbl_testeSql
            // 
            this.lbl_testeSql.AutoSize = true;
            this.lbl_testeSql.Location = new System.Drawing.Point(147, 224);
            this.lbl_testeSql.Name = "lbl_testeSql";
            this.lbl_testeSql.Size = new System.Drawing.Size(0, 13);
            this.lbl_testeSql.TabIndex = 25;
            // 
            // txt_bancoSql
            // 
            this.txt_bancoSql.Location = new System.Drawing.Point(98, 136);
            this.txt_bancoSql.Name = "txt_bancoSql";
            this.txt_bancoSql.Size = new System.Drawing.Size(213, 20);
            this.txt_bancoSql.TabIndex = 19;
            // 
            // link_testeSql
            // 
            this.link_testeSql.AutoSize = true;
            this.link_testeSql.Location = new System.Drawing.Point(123, 181);
            this.link_testeSql.Name = "link_testeSql";
            this.link_testeSql.Size = new System.Drawing.Size(82, 13);
            this.link_testeSql.TabIndex = 21;
            this.link_testeSql.TabStop = true;
            this.link_testeSql.Text = "Testar Conexao";
            this.link_testeSql.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Link_testeSql_LinkClicked);
            // 
            // txt_senhaSql
            // 
            this.txt_senhaSql.Location = new System.Drawing.Point(98, 99);
            this.txt_senhaSql.Name = "txt_senhaSql";
            this.txt_senhaSql.Size = new System.Drawing.Size(213, 20);
            this.txt_senhaSql.TabIndex = 18;
            // 
            // txt_serverSql
            // 
            this.txt_serverSql.Location = new System.Drawing.Point(98, 29);
            this.txt_serverSql.Name = "txt_serverSql";
            this.txt_serverSql.Size = new System.Drawing.Size(213, 20);
            this.txt_serverSql.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 106);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Senha";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 32);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(93, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Servidor\\instancia";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 71);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Usuario";
            // 
            // txt_userSql
            // 
            this.txt_userSql.Location = new System.Drawing.Point(98, 64);
            this.txt_userSql.Name = "txt_userSql";
            this.txt_userSql.Size = new System.Drawing.Size(213, 20);
            this.txt_userSql.TabIndex = 15;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbl_testeMySql);
            this.groupBox1.Controls.Add(this.link_testeMySql);
            this.groupBox1.Location = new System.Drawing.Point(5, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(334, 216);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Config. MySQL";
            // 
            // lbl_testeMySql
            // 
            this.lbl_testeMySql.AutoSize = true;
            this.lbl_testeMySql.Location = new System.Drawing.Point(142, 224);
            this.lbl_testeMySql.Name = "lbl_testeMySql";
            this.lbl_testeMySql.Size = new System.Drawing.Size(0, 13);
            this.lbl_testeMySql.TabIndex = 24;
            // 
            // link_testeMySql
            // 
            this.link_testeMySql.AutoSize = true;
            this.link_testeMySql.Location = new System.Drawing.Point(142, 181);
            this.link_testeMySql.Name = "link_testeMySql";
            this.link_testeMySql.Size = new System.Drawing.Size(82, 13);
            this.link_testeMySql.TabIndex = 11;
            this.link_testeMySql.TabStop = true;
            this.link_testeMySql.Text = "Testar Conexao";
            this.link_testeMySql.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Link_testeMySql_LinkClicked);
            // 
            // txt_serverMySql
            // 
            this.txt_serverMySql.Location = new System.Drawing.Point(112, 41);
            this.txt_serverMySql.Name = "txt_serverMySql";
            this.txt_serverMySql.Size = new System.Drawing.Size(213, 20);
            this.txt_serverMySql.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Servidor\\instancia";
            // 
            // txt_userMySql
            // 
            this.txt_userMySql.Location = new System.Drawing.Point(112, 76);
            this.txt_userMySql.Name = "txt_userMySql";
            this.txt_userMySql.Size = new System.Drawing.Size(213, 20);
            this.txt_userMySql.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Usuario";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Senha";
            // 
            // txt_senhaMySql
            // 
            this.txt_senhaMySql.Location = new System.Drawing.Point(112, 111);
            this.txt_senhaMySql.Name = "txt_senhaMySql";
            this.txt_senhaMySql.PasswordChar = '*';
            this.txt_senhaMySql.Size = new System.Drawing.Size(213, 20);
            this.txt_senhaMySql.TabIndex = 8;
            // 
            // txt_bancoMySql
            // 
            this.txt_bancoMySql.Location = new System.Drawing.Point(112, 148);
            this.txt_bancoMySql.Name = "txt_bancoMySql";
            this.txt_bancoMySql.Size = new System.Drawing.Size(213, 20);
            this.txt_bancoMySql.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 155);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Banco de Dados";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(58, 252);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(695, 23);
            this.progressBar1.TabIndex = 25;
            // 
            // WF_configurador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 308);
            this.Controls.Add(this.btn_carregar);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_bancoMySql);
            this.Controls.Add(this.btn_salvarMySql);
            this.Controls.Add(this.txt_senhaMySql);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_userMySql);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_serverMySql);
            this.Controls.Add(this.btn_importar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "WF_configurador";
            this.Text = "Form1";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_carregar;
        private System.Windows.Forms.Button btn_salvarMySql;
        private System.Windows.Forms.Button btn_importar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_bancoSql;
        private System.Windows.Forms.TextBox txt_senhaSql;
        private System.Windows.Forms.TextBox txt_serverSql;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_userSql;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txt_serverMySql;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_userMySql;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_senhaMySql;
        private System.Windows.Forms.TextBox txt_bancoMySql;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbl_testeSql;
        private System.Windows.Forms.LinkLabel link_testeSql;
        private System.Windows.Forms.Label lbl_testeMySql;
        private System.Windows.Forms.LinkLabel link_testeMySql;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}

