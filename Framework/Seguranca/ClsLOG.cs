
using System;
using System.Data;
using System.Configuration;

using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;


using Database;

namespace Framework.Seguranca
{
    /// <summary>
    /// OBJETIVO DA CLASSE: CLASSE PARA CONTROLE DA TABELA LOG
    /// DATA\HORA CRIAÇÃO :08/08/2012 12:31:47
    /// COMPUTADOR GERADOR:SERVIDOR
    /// </summary>
    public class ClsLOG
    {

        public static string CODIGOLOG;
        public static string CODIGOFUNC;
        public static string DURACAO;
        public static string CODIGOERRO;
        public static string DESCRICAOERRO;
        public static string IP;
        public static string DATAEXCLUSAO;
        public static string CODIGOPESSOAEXCLUSAO;
        public static string DATAHORAINCLUSAO;
        public static string CODIGOPESSOAINCLUSAO;


        public static DataSet LOG;

        public ClsLOG()
        {

        }

        #region "MÉTODO - INCLUI E ALTERA REGISTRO NO BANCO DE DADOS
        /// <summary>
        /// OBJETIVO DO MÉTODO: MÉTODO PARA INSERÇÃO E ALTERAÇÃO DE REGISTROS NA TABELA LOG
        /// DATA\HORA CRIAÇÃO :08/08/2012 12:31:47
        /// COMPUTADOR GERADOR:SERVIDOR
        /// </summary>
        /// <returns>RETORNA TRUE OU FALSE. SE O PROCESSO FOI REALIZADO COM SUCESSO OU NÃO </returns>
        /// <param name="strMsgRetorno">Variável string com uma mensagem de retorno da operação no método.</param>
        public static bool Gravar(out string strMsgRetorno)
        {
            strMsgRetorno = "";

            try
            {
                using (Conexao cn = new Conexao())
                {
                    cn.AddParametros("CODIGOLOG", CODIGOLOG);
                    cn.AddParametros("CODIGOFUNC", CODIGOFUNC);
                    cn.AddParametros("DURACAO", DURACAO);
                    cn.AddParametros("CODIGOERRO", CODIGOERRO);
                    cn.AddParametros("DESCRICAOERRO", DESCRICAOERRO);
                    cn.AddParametros("IP", IP);
                    cn.AddParametros("DATAEXCLUSAO", DATAEXCLUSAO);
                    cn.AddParametros("CODIGOPESSOAEXCLUSAO", CODIGOPESSOAEXCLUSAO);
                    cn.AddParametros("DATAHORAINCLUSAO", DATAHORAINCLUSAO);
                    cn.AddParametros("CODIGOPESSOAINCLUSAO", CODIGOPESSOAINCLUSAO);


                    cn.CriarPedido("STP_LOG_IncAlt", false);

                    string valor = cn.GetValor("RESPOSTA", 0, 0);

                    switch (valor)
                    {
                        case "I":
                            strMsgRetorno = "Registro incluído com sucesso.";
                            break;
                        case "A":
                            strMsgRetorno = "Registro alterado com sucesso.";
                            break;
                        default:
                            strMsgRetorno = "Não foi possível incluir ou alterar o registro.";
                            break;
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (strMsgRetorno == "")
                {
                    strMsgRetorno = "Operação realizada com sucesso.";
                }

                // ADICIONE AQUI FECHAMENTO DE OBJETOS QUE OCUPAM ESPAÇO NA MM E QUE NÃO SERÃO
                // USADOS DEPOIS QUE EXCUTAR ESSE MÉTODO.
            }
        }
        #endregion

        #region "MÉTODO - GRAVA ERRO"
        /// <summary>
        /// Grava Erro
        /// </summary>
        /// <param name="strCODIGOFUNC">Código da funcionalidade do sistema</param>
        /// <param name="strCODIGOERRO">Código do erro</param>
        /// <param name="strDESCRICAOERRO">Descrição do erro</param>
        /// <param name="strIP">Número do IP de onde veio o erro</param>
        /// <param name="strDATAHORAINCLUSAO">Data e hora de inclusão</param>
        /// <param name="strCODIGOPESSOAINCLUSAO">Código da pessoa usuário de onde veio o erro</param>
        public static void GravaErro(string strCODIGOFUNC, string strCODIGOERRO, string strDESCRICAOERRO, string strIP, string strDATAHORAINCLUSAO, string strLogin)
        {
            string strMensagem = "";
            
            CODIGOFUNC = strCODIGOFUNC;
            CODIGOERRO = strCODIGOERRO;
            DESCRICAOERRO = strDESCRICAOERRO;
            DATAHORAINCLUSAO = strDATAHORAINCLUSAO;
            CODIGOPESSOAINCLUSAO = strLogin;
            DATAHORAINCLUSAO = strDATAHORAINCLUSAO;
            IP = strIP;

            //Grava o erro.
            Gravar(out strMensagem);

            System.Text.StringBuilder strBody = new System.Text.StringBuilder();
            strBody.Append(":: ERRO NO SITE INSTITUCIONAL ::");
            strBody.AppendLine();
            strBody.Append("Código do Erro: "+ strCODIGOERRO +"");
            strBody.Append("Descrição do Erro: " + strDESCRICAOERRO + "");
            strBody.Append("Data do erro: " + DateTime.Now.ToString("DD/MM/YYYY HH:MM") + "");
            //strBody.Append("Nome do Usuário: " + ClsUSUARIO.GetNomeUsuario(strLogin) + "");
            strBody.Append("Código funcionalidade: " + strCODIGOFUNC + "");
            strBody.AppendLine();



            //Envia email com a descrição do erro.
            //Framework.Seguranca.ClsREDE OBJREDE = new Seguranca.ClsREDE();
            //OBJREDE.SendMail("fernanda.passos.f@gmail.com", "fernanda.passos.f@gmail.com", "", "", strBody.ToString(), out strMensagem);

        }
        #endregion

        #region "MÉTODO - EXCLUIR REGISTRO
        /// <summary>
        /// OBJETIVO DO MÉTODO: MÉTODO QUE TEM POR OBJETIVO EXCLUIR REGISTR POR PARAMENTRO DO CÓDIGO IDENTIFICADOR LOG
        /// DATA\HORA CRIAÇÃO :08/08/2012 12:31:47
        /// COMPUTADOR GERADOR:SERVIDOR
        /// </summary>
        /// <returns>RETORNA TRUE OU FALSE. SE FOI EXCLUÍDO OU NÃO.</returns>
        /// <param name="strMsgRetorno">Variável string com uma mensagem de retorno da operação no método.</param>
        /// <param name="strCodigoRegistro">Código identificador do registro á ser excluído.</param>
        public static bool Excluir(out string strMsgRetorno, string strCodigoRegistro)
        {
            strMsgRetorno = "";

            try
            {
                using (Conexao cn = new Conexao())
                {

                    cn.CriarPedido("STP_LOG_Exc", false);

                    string valor = cn.GetValor("RESPOSTA", 0, 0);

                    switch (valor)
                    {
                        case "1":
                            strMsgRetorno = "Registro excluído com sucesso.";
                            break;
                        case "2":
                            strMsgRetorno = "Não foi possível excluir o registro.";
                            break;
                        default:
                            strMsgRetorno = "Não foi possível incluir ou alterar o registro.";
                            break;
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                strMsgRetorno = ex.Message;
                throw ex;
            }
            finally
            {
                if (strMsgRetorno == "")
                {
                    strMsgRetorno = "Operação realizada com sucesso.";
                }

                // ADICIONE AQUI FECHAMENTO DE OBJETOS QUE OCUPAM ESPAÇO NA MM E QUE NÃO SERÃO
                // USADOS DEPOIS QUE EXCUTAR ESSE MÉTODO.
            }
        }
        #endregion

        #region "MÉTODO - PESQUISAR REGISTRO
        /// <summary>
        /// OBJETIVO DO MÉTODO: MÉTODO QUE TEM POR OBJETIVO PESQUISAR REGISTROSLOG
        /// DATA\HORA CRIAÇÃO :08/08/2012 12:31:47
        /// COMPUTADOR GERADOR:SERVIDOR
        /// </summary>
        /// <returns>RETORNA TRUE OU FALSE. SE A PESQUISA FOI REALIZADA COM SUCESSO OU NÃO.</returns>
        /// <param name="strMsgRetorno">Variável string com uma mensagem de retorno da operação no método.</param>
        public static bool Pesquisar(out string strMsgRetorno, string strCodigoRegistro)
        {
            strMsgRetorno = "";

            try
            {
                using (Conexao cn = new Conexao())
                {
                    cn.AddParametros("CODIGOLOG", CODIGOLOG);

                    cn.CriarPedido("STP_LOG_Pes", false);

                    CODIGOLOG = cn.GetValor("CODIGOLOG", 0, 0);
                    CODIGOFUNC = cn.GetValor("CODIGOFUNC", 0, 0);
                    DURACAO = cn.GetValor("DURACAO", 0, 0);
                    CODIGOERRO = cn.GetValor("CODIGOERRO", 0, 0);
                    DESCRICAOERRO = cn.GetValor("DESCRICAOERRO", 0, 0);
                    IP = cn.GetValor("IP", 0, 0);
                    DATAEXCLUSAO = cn.GetValor("DATAEXCLUSAO", 0, 0);
                    CODIGOPESSOAEXCLUSAO = cn.GetValor("CODIGOPESSOAEXCLUSAO", 0, 0);
                    DATAHORAINCLUSAO = cn.GetValor("DATAHORAINCLUSAO", 0, 0);
                    CODIGOPESSOAINCLUSAO = cn.GetValor("CODIGOPESSOAINCLUSAO", 0, 0);

                    strMsgRetorno = "Pesquisa realizada com sucesso.";

                    return true;
                }
            }
            catch (Exception ex)
            {
                strMsgRetorno = ex.Message;
                throw ex;
            }
            finally
            {
                if (strMsgRetorno == "")
                {
                    strMsgRetorno = "Operação realizada com sucesso.";
                }

                // ADICIONE AQUI FECHAMENTO DE OBJETOS QUE OCUPAM ESPAÇO NA MM E QUE NÃO SERÃO
                // USADOS DEPOIS QUE EXCUTAR ESSE MÉTODO.
            }
        }
        #endregion
    }


}