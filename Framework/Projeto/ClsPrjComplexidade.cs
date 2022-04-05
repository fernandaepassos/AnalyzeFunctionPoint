using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Database;

namespace Framework.Projeto
{
    public class ClsPrjComplexidade
    {

        #region [ Métodos ]

        #region Método - Retorna todas as complexidades
        /// <summary>
        /// Método - Retorna todas as complexidades
        /// </summary>
        /// <returns>Retorna um objeto DataSet</returns>
        public static System.Data.DataSet GetComplexidade()
        {
            System.Data.DataSet objDataSet = new System.Data.DataSet();
            try
            {

                string strSql = " SELECT IdComplexidade, NomeComplexidade ";
                strSql += " FROM PrjComplexidade ";
                strSql += " order by IdComplexidade ";

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

        #endregion
    }
}
