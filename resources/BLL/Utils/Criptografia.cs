using System;

namespace BLL
{
    /// <summary>
    /// criptografa ou decriptografa as senhas de conexão
    /// </summary>
    public class Criptografia
    {
        public static string Crypt(string senha)
        {
            //limpar a box de decrypt
            var senhaEncriptada = string.Empty;
            //Intera todas as letra do texto puro
            for (int i = 0; i < senha.Length; i++)

            {
                //Devolve o código ASCII da letra
                int ASCII = (int)senha[i];
                //Coloca a chave fixa de 10 posições a mais no número da tabela ASCII
                int ASCIIC = ASCII + 10;             
                //Concatena o texto 
                senhaEncriptada += Char.ConvertFromUtf32(ASCIIC);                
            }
            return (senhaEncriptada);
        }
        public static string Decrypt(string senhaEncriptada)
        {
            //limpar a box de decrypt
            var senhaDecriptada = string.Empty;
            //Intera todas as letra do texto puro
            for (int i = 0; i < senhaEncriptada.Length; i++)
            {
                //Devolve o código ASCII da letra
                int ASCII = (int)senhaEncriptada[i];
                //Coloca a chave fixa de 10 posições a mais no número da tabela ASCII
                int ASCIIC = ASCII - 10;
                //Concatena o texto
                senhaDecriptada += Char.ConvertFromUtf32(ASCIIC);
            }
            return (senhaDecriptada);
        }
    }
}
