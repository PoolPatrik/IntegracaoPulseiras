using System;

namespace BLL
{
    /// <summary>
    /// faz a comparação de qual a data e horario do ultimo registro importado
    /// </summary>
    public class Datas
    {
        private DateTime dataHora;
        public Datas()
        {
            this.dataHora = LerData();
        }

        //salva data no arquivo texto
        private void SalvarData()
        {
            new Arquivos().SalvarUltData(this.dataHora);
        }

        //busca data no arquivo texto
        public DateTime LerData()
        {
            DateTime data = DateTime.Parse(new Arquivos().LerUltimaData("UltimaLeitura.txt").ToString());
            return data;
        }

        //campara as datas para saber qual a mais recente, guarda a mais recente no no arquivo txt
        public void EscolherMaior(DateTime data)
        {
            if (data > this.dataHora)
            {
                this.dataHora = data;
                SalvarData();
            }
        }
    }
}
