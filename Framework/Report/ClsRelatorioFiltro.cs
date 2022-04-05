using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Database;

namespace Framework.Report
{
    public class ClsRelatorioFiltro
    {
        #region [   Propriedades    ]
        public string IdRelatorioFiltro;
        public string IdRelatorio;
        public string DescFiltro;
        #endregion

        #region [   GetFiltros   ]
        /// <summary>
        /// [   GetFiltros  ]
        public System.Data.DataSet GetFiltrosItems(string strIdrelatoriofiltro)
        {

            try
            {
                using (Conexao cn = new Conexao())
                {
                    return cn.ExecSQL("select * , (select idrelatorio from  relatoriofiltro where idrelatoriofiltro = relatoriofiltroitem.idrelatoriofiltro) as idrelatorio from  relatoriofiltroitem where idrelatoriofiltro = " + strIdrelatoriofiltro + "");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region [   GetFiltrosItemsByIdReport   ]
        /// <summary>
        /// [   GetFiltrosItemsByIdReport  ]
        public System.Data.DataSet GetFiltrosItemsByIdReport(string strIdRelatorio)
        {
            System.Data.DataSet objDataSet = new System.Data.DataSet();
            try
            {
                if (string.IsNullOrEmpty(strIdRelatorio)) return null;

                using (Conexao cn = new Conexao())
                {
                    string strSql = " select * ";
                    strSql += " , relatoriofiltro.idrelatorio as idrelatorio  ";
                    strSql += " from  relatoriofiltroitem left outer join relatoriofiltro on relatoriofiltroitem.IdRelatorioFiltro = relatoriofiltro.IdRelatorioFiltro";
                    strSql += " where 1=1 ";
                    strSql += " and relatoriofiltro.IdRelatorio = " + strIdRelatorio.Trim() + " ";

                    objDataSet = cn.ExecSQL(strSql.Trim());

                    return objDataSet;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (objDataSet != null) objDataSet.Dispose();
            }
        }
        #endregion



        #region [   Gravar  ]
        /// <summary>
        /// OBJETIVO DO MÉTODO: MÉTODO PARA INSERÇÃO E ALTERAÇÃO DE REGISTROS NA TABELA RelatorioFiltro
        /// DATA\HORA CRIAÇÃO :30/08/2013 07:03:09
        /// COMPUTADOR GERADOR:DESKTOP
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
                    cn.AddParametros("IdRelatorioFiltro", IdRelatorioFiltro);
                    cn.AddParametros("IdRelatorio", IdRelatorio);
                    cn.AddParametros("DescFiltro", DescFiltro);


                    cn.CriarPedido("STP_RelatorioFiltro_IncAlt", false);

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
        /// OBJETIVO DO MÉTODO: MÉTODO QUE TEM POR OBJETIVO EXCLUIR REGISTR POR PARAMENTRO DO CÓDIGO IDENTIFICADOR RelatorioFiltro
        /// DATA\HORA CRIAÇÃO :30/08/2013 07:03:09
        /// COMPUTADOR GERADOR:DESKTOP
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
                    cn.AddParametros("IdRelatorioFiltro", strCodigoRegistro);
                    cn.CriarPedido("STP_RelatorioFiltro_Exc", false);

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
        /// OBJETIVO DO MÉTODO: MÉTODO QUE TEM POR OBJETIVO PESQUISAR REGISTROSRelatorioFiltro
        /// DATA\HORA CRIAÇÃO :30/08/2013 07:03:09
        /// COMPUTADOR GERADOR:DESKTOP
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
                    cn.AddParametros("IdRelatorioFiltro", IdRelatorioFiltro);
                    cn.CriarPedido("STP_RelatorioFiltro_Pes", false);

                    IdRelatorioFiltro = cn.GetValor("IdRelatorioFiltro", 0, 0);
                    IdRelatorio = cn.GetValor("IdRelatorio", 0, 0);
                    DescFiltro = cn.GetValor("DescFiltro", 0, 0);

                    strMsgRetorno = "Pesquisa realizada com sucesso.";

                    return true;
                }
            }
            catch (Exception ex)
            {
                strMsgRetorno = ex.Message;
                throw ex;
            }
        }
        #endregion

        #region [   GetFiltros   ]
        /// <summary>
        /// [   GetFiltros  ]
        public System.Data.DataSet GetFiltros()
        {

            try
            {
                using (Conexao cn = new Conexao())
                {
                    return cn.ExecSQL("SELECT * FROM RELATORIOFILTRO");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
