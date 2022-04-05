
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
    /// OBJETIVO DA CLASSE: CLASSE PARA CONTROLE DA TABELA FUNCIONALIDADE
    /// DATA\HORA CRIAÇÃO :08/08/2012 12:30:35
    /// COMPUTADOR GERADOR:SERVIDOR
    /// </summary>
    public class ClsFUNCIONALIDADE
    {

        public static string CODIGOFUNC;
        public static string CODIGOFUNCSUP;
        public static string NOME;
        public static string DESCRICAO;
        public static string DATAHORAINCLUSAO;
        public static string DATAHORAALTERACAO;
        public static string CODIGOPESSOAINCLUSAO;
        public static string CODIGOPESSOAALTERACAO;
        public static string TEMPO_MAX;
        public static string CODIGOPRODUTO;
        public static string DATAEXCLUSAO;
        public static string CODIGOPESSOAEXCLUSAO;

        public static DataSet FUNCIONALIDADE;

        public ClsFUNCIONALIDADE()
        {

        }

        #region "MÉTODO - INCLUI E ALTERA REGISTRO NO BANCO DE DADOS
        /// <summary>
        /// OBJETIVO DO MÉTODO: MÉTODO PARA INSERÇÃO E ALTERAÇÃO DE REGISTROS NA TABELA FUNCIONALIDADE
        /// DATA\HORA CRIAÇÃO :08/08/2012 12:30:35
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
                    cn.AddParametros("CODIGOFUNC", CODIGOFUNC);
                    cn.AddParametros("CODIGOFUNCSUP", CODIGOFUNCSUP);
                    cn.AddParametros("NOME", NOME);
                    cn.AddParametros("DESCRICAO", DESCRICAO);
                    cn.AddParametros("DATAHORAINCLUSAO", DATAHORAINCLUSAO);
                    cn.AddParametros("DATAHORAALTERACAO", DATAHORAALTERACAO);
                    cn.AddParametros("CODIGOPESSOAINCLUSAO", CODIGOPESSOAINCLUSAO);
                    cn.AddParametros("CODIGOPESSOAALTERACAO", CODIGOPESSOAALTERACAO);
                    cn.AddParametros("TEMPO_MAX", TEMPO_MAX);
                    cn.AddParametros("CODIGOPRODUTO", CODIGOPRODUTO);
                    cn.AddParametros("DATAEXCLUSAO", DATAEXCLUSAO);
                    cn.AddParametros("CODIGOPESSOAEXCLUSAO", CODIGOPESSOAEXCLUSAO);


                    cn.CriarPedido("STP_FUNCIONALIDADE_IncAlt", false);

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

        #region "MÉTODO - EXCLUIR REGISTRO
        /// <summary>
        /// OBJETIVO DO MÉTODO: MÉTODO QUE TEM POR OBJETIVO EXCLUIR REGISTR POR PARAMENTRO DO CÓDIGO IDENTIFICADOR FUNCIONALIDADE
        /// DATA\HORA CRIAÇÃO :08/08/2012 12:30:35
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

                    cn.CriarPedido("STP_FUNCIONALIDADE_Exc", false);

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
        /// OBJETIVO DO MÉTODO: MÉTODO QUE TEM POR OBJETIVO PESQUISAR REGISTROSFUNCIONALIDADE
        /// DATA\HORA CRIAÇÃO :08/08/2012 12:30:35
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
                    cn.AddParametros("CODIGOFUNC", CODIGOFUNC);

                    cn.CriarPedido("STP_FUNCIONALIDADE_Pes", false);

                    CODIGOFUNC = cn.GetValor("CODIGOFUNC", 0, 0);
                    CODIGOFUNCSUP = cn.GetValor("CODIGOFUNCSUP", 0, 0);
                    NOME = cn.GetValor("NOME", 0, 0);
                    DESCRICAO = cn.GetValor("DESCRICAO", 0, 0);
                    DATAHORAINCLUSAO = cn.GetValor("DATAHORAINCLUSAO", 0, 0);
                    DATAHORAALTERACAO = cn.GetValor("DATAHORAALTERACAO", 0, 0);
                    CODIGOPESSOAINCLUSAO = cn.GetValor("CODIGOPESSOAINCLUSAO", 0, 0);
                    CODIGOPESSOAALTERACAO = cn.GetValor("CODIGOPESSOAALTERACAO", 0, 0);
                    TEMPO_MAX = cn.GetValor("TEMPO_MAX", 0, 0);
                    CODIGOPRODUTO = cn.GetValor("CODIGOPRODUTO", 0, 0);
                    DATAEXCLUSAO = cn.GetValor("DATAEXCLUSAO", 0, 0);
                    CODIGOPESSOAEXCLUSAO = cn.GetValor("CODIGOPESSOAEXCLUSAO", 0, 0);

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