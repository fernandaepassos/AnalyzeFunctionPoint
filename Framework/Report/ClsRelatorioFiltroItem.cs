using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Database;

namespace Framework.Report
{
    public class ClsRelatorioFiltroItem
    {
        #region [   Propriedades    ]

        public string IdRelatorioFiltroItens;
        public string IdRelatorioFiltro;
        public string IdRelatorio;
        public string DesItemDoFiltro;

        #endregion

        #region [   Métodos ]

        #region [   Gravar  ]
        /// <summary>
        /// OBJETIVO DO MÉTODO: MÉTODO PARA INSERÇÃO E ALTERAÇÃO DE REGISTROS NA TABELA RelatorioFiltroItem
        /// DATA\HORA CRIAÇÃO :30/08/2013 10:18:07
        /// COMPUTADOR GERADOR:DEVELOPMENT04
        /// </summary>
        /// <returns>RETORNA TRUE OU FALSE. SE O PROCESSO FOI REALIZADO COM SUCESSO OU NÃO </returns>
        /// <param name="strMsgRetorno">Variável string com uma mensagem de retorno da operação no método.</param>
        public bool Gravar(out string strMsgRetorno)
        {
            strMsgRetorno = "";

            try
            {
                using (Conexao cn = new Conexao())
                {
                    cn.AddParametros("IdRelatorioFiltroItens", IdRelatorioFiltroItens);
                    cn.AddParametros("IdRelatorioFiltro", IdRelatorioFiltro);
                    cn.AddParametros("DesItemDoFiltro", DesItemDoFiltro);


                    cn.CriarPedido("STP_RelatorioFiltroItem_IncAlt", false);

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
        }
        #endregion

        #region [   Excluir ]
        /// <summary>
        /// OBJETIVO DO MÉTODO: MÉTODO QUE TEM POR OBJETIVO EXCLUIR REGISTR POR PARAMENTRO DO CÓDIGO IDENTIFICADOR RelatorioFiltroItem
        /// DATA\HORA CRIAÇÃO :30/08/2013 10:18:07
        /// COMPUTADOR GERADOR:DEVELOPMENT04
        /// </summary>
        /// <returns>RETORNA TRUE OU FALSE. SE FOI EXCLUÍDO OU NÃO.</returns>
        /// <param name="strMsgRetorno">Variável string com uma mensagem de retorno da operação no método.</param>
        /// <param name="strCodigoRegistro">Código identificador do registro á ser excluído.</param>
        public bool Excluir(out string strMsgRetorno, string strCodigoRegistro)
        {
            strMsgRetorno = "";

            try
            {
                using (Conexao cn = new Conexao())
                {

                    cn.CriarPedido("STP_RelatorioFiltroItem_Exc", false);

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
                throw ex;
            }
        }
        #endregion

        #region [   Excluir - Todos]
        /// <summary>
        /// OBJETIVO DO MÉTODO: MÉTODO QUE TEM POR OBJETIVO EXCLUIR REGISTR POR PARAMENTRO DO CÓDIGO IDENTIFICADOR RelatorioFiltroItem
        /// DATA\HORA CRIAÇÃO :30/08/2013 10:18:07
        /// COMPUTADOR GERADOR:DEVELOPMENT04
        /// </summary>
        /// <returns>RETORNA TRUE OU FALSE. SE FOI EXCLUÍDO OU NÃO.</returns>
        /// <param name="strMsgRetorno">Variável string com uma mensagem de retorno da operação no método.</param>
        /// <param name="strCodigoRegistro">Código identificador do registro á ser excluído.</param>
        public bool ExcluirTodos(out string strMsgRetorno)
        {
            strMsgRetorno = "";

            try
            {
                if (IdRelatorio.Trim() == "") return false;
                using (Conexao cn = new Conexao())
                {
                    cn.AddParametros("IDRELATORIO", IdRelatorio);
                    cn.CriarPedido("STP_RelatorioFiltroItem_Exc_All", false);

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
                throw ex;
            }
        }
        #endregion

        #region [   Pesquisar   ]
        /// <summary>
        /// OBJETIVO DO MÉTODO: MÉTODO QUE TEM POR OBJETIVO PESQUISAR REGISTROSRelatorioFiltroItem
        /// DATA\HORA CRIAÇÃO :30/08/2013 10:18:07
        /// COMPUTADOR GERADOR:DEVELOPMENT04
        /// </summary>
        /// <returns>RETORNA TRUE OU FALSE. SE A PESQUISA FOI REALIZADA COM SUCESSO OU NÃO.</returns>
        /// <param name="strMsgRetorno">Variável string com uma mensagem de retorno da operação no método.</param>
        public bool Pesquisar(out string strMsgRetorno, string strCodigoRegistro)
        {
            strMsgRetorno = "";

            try
            {
                using (Conexao cn = new Conexao())
                {
                    cn.AddParametros("IdRelatorioFiltroItens", IdRelatorioFiltroItens);

                    cn.CriarPedido("STP_RelatorioFiltroItem_Pes", false);

                    IdRelatorioFiltroItens = cn.GetValor("IdRelatorioFiltroItens", 0, 0);
                    IdRelatorioFiltro = cn.GetValor("IdRelatorioFiltro", 0, 0);
                    DesItemDoFiltro = cn.GetValor("DesItemDoFiltro", 0, 0);

                    strMsgRetorno = "Pesquisa realizada com sucesso.";

                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #endregion
    }
}
