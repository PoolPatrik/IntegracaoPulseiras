using System;

namespace BLL
{
    /// <summary>
    /// faz a comparação de qual a data e horario do ultimo registro importado
    /// 
    /// </summary>
    public class Datas
    {
        DateTime dataHora;

        public Datas()
        {
            this.dataHora = LerData();
        }
        public void SalvarData()//salva data no arquivo texto
        {

            new DAL.Arquivos().SalvarUltData(this.dataHora);
        }

        public DateTime LerData()//busca data no arquivo texto
        {
            DateTime data = DateTime.Parse(new DAL.Arquivos().LerUltimaData("UltimaLeitura.txt").ToString());

            return data;
        }

        public void EscolherMaior(DateTime data)//campara as datas para saber qual a mais recente, guarda a mais recente no no arquivo txt
        {

            if (data > this.dataHora)
            {
                this.dataHora = data;
                SalvarData();
            }

        }
    }
}
