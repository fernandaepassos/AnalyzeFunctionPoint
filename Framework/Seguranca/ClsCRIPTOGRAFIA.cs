
using System.Text;
using System;

namespace Framework.Seguranca
{
    /// <summary>
    /// OBJETIVO DA CLASSE: CLASSE DE TODOS OS RECURSOS DE SEGURANÇA
    /// DATA\HORA CRIAÇÃO :09/08/2012 12:30:55
    /// COMPUTADOR GERADOR:SERVIDOR
    /// </summary>
    public class ClsCRIPTOGRAFIA
    {
        public ClsCRIPTOGRAFIA()
        {
        }

        #region Descriptografa uma string
        /// <summary>
        /// OBJETIVO DO MÉTODO: Descriptografa uma string.
        /// DATA\HORA CRIAÇÃO :09/08/2012 12:30:55
        /// COMPUTADOR GERADOR:SERVIDOR
        /// </summary>
        /// <returns>Retorna uma string descriptografada.</returns>
        /// <param name="strStringConexao">String criptografada para descriptografar</param>
        public static string Descriptografa(string strStringConexao)
        {
            try
            {
                //PEGA A STRING DE CONEXÃO
                Byte[] objByte = Convert.FromBase64String(strStringConexao);

                //DESCRIPTOGRAFA
                string strDecryConnectionString = System.Text.ASCIIEncoding.ASCII.GetString(objByte);

                //RETORNA DESCRIPITOGRAFADA
                return strDecryConnectionString;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region MÉTODO - CRIPTOGRAFA UMA STRING
        /// <summary>
        /// OBJETIVO DO MÉTODO: MÉTODO - CRIPTOGRAFA UMA STRING
        /// DATA\HORA CRIAÇÃO :09/08/2012 12:30:55
        /// COMPUTADOR GERADOR:SERVIDOR
        /// </summary>
        /// <returns>Retorna uma string com o conteúdo criptografado</returns>
        /// <param name="strStringConexao">String descriptografada para criptografar</param>
        public static string Criptografa(string strStringConexao)
        {
            try
            {
                //CONVERT A STRING DE CONEXÃO PARA BY
                Byte[] objByte = System.Text.ASCIIEncoding.ASCII.GetBytes(strStringConexao);

                //CRIPTOGRAFA
                string strStringConexaoCripitografada = Convert.ToBase64String(objByte);

                //RETORNA A STRING CRIPTOGRAFADA
                return strStringConexaoCripitografada;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }

}
