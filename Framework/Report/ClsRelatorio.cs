using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Database;

namespace Framework.Report
{
    public class ClsRelatorio
    {
        #region [   GetRelatorio    ]
        /// <summary>
        /// [   GetRelatorio    ]
        /// </summary>
        /// <returns></returns>
        public System.Data.DataSet GetRelatorio()
        {
            try
            {
                string strSql = "SELECT * FROM RELATORIO";
                using (Conexao cn = new Conexao())
                {
                    return cn.ExecSQL(strSql);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region [   GetColunasRelatorio    ]
        /// <summary>
        /// [   GetColunasRelatorio    ]
        /// </summary>
        /// <returns></returns>
        public System.Data.DataSet GetColunasRelatorio(string strIdRelatorio)
        {
            System.Data.DataSet objDataSet = new System.Data.DataSet();
            try
            {
                string strSql = "SELECT NOMEVIEW FROM RELATORIO where IDRELATORIO = " + strIdRelatorio.Trim() + "";
                using (Conexao cn = new Conexao())
                {
                    objDataSet = cn.ExecSQL(strSql);

                    if (objDataSet != null && objDataSet.Tables.Count > 0 && objDataSet.Tables[0].Rows.Count > 0)
                    {
                        objDataSet = cn.ExecSQL("sp_help " + objDataSet.Tables[0].Rows[0][0].ToString().Trim() + "");
                    }
                }

                return objDataSet;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objDataSet.Dispose();
            }
        }
        #endregion

        #region [   GetColunasPorObjetoDoBanco    ]
        /// <summary>
        /// [   GetColunasPorObjetoDoBanco    ]
        /// </summary>
        /// <returns>Retorna um DataSet </returns>
        /// <param name="strNomeObjeto">Nome do objeto: tabela, view, procedure, funcition</param>
        public System.Data.DataSet GetColunasPorObjetoDoBanco(string strNomeObjeto)
        {
            System.Data.DataSet objDataSet = new System.Data.DataSet();
            try
            {
                string strSql = " select syscolumns.name as Campo";
                strSql += " from sysobjects , syscolumns ";
                strSql += " where sysobjects.id = syscolumns.id ";
                strSql += " and sysobjects.name = '" + strNomeObjeto.Trim() + "' ";
                strSql += " order by syscolumns.name ";

                using (Conexao cn = new Conexao())
                {
                    objDataSet = cn.ExecSQL(strSql);
                }

                return objDataSet;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objDataSet.Dispose();
            }
        }
        #endregion

        #region [   GetRelatorios    ]
        /// <summary>
        /// [   GetRelatorios    ]
        /// </summary>
        /// <returns></returns>
        public System.Data.DataSet GetRelatorios(string strIdRelatorio)
        {
            System.Data.DataSet objDataSet = new System.Data.DataSet();
            try
            {
                string strSql = "SELECT NOMEVIEW FROM RELATORIO where IDRELATORIO = " + strIdRelatorio.Trim() + "";
                using (Conexao cn = new Conexao())
                {
                    objDataSet = cn.ExecSQL(strSql);

                    if (objDataSet != null && objDataSet.Tables.Count > 0 && objDataSet.Tables[0].Rows.Count > 0)
                    {
                        objDataSet = cn.ExecSQL("sp_help " + objDataSet.Tables[0].Rows[0][0].ToString().Trim() + "");
                    }
                }

                return objDataSet;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objDataSet.Dispose();
            }
        }
        #endregion

    }
}
