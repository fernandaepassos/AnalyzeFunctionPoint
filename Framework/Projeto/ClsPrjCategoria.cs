using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Database;

namespace Framework.Projeto
{
    public class ClsPrjCategoria
    {

        #region [ Métodos ]

        #region [   Método - Retorna todas as categorias    ]
        /// <summary>
        /// Método - Retorna todas as categorias    
        /// </summary>
        /// <returns>Retorna um DataSet com todas as categorias</returns>
        public static System.Data.DataSet GetCategoria()
        {
            System.Data.DataSet objDataSet = new System.Data.DataSet();
            try
            {
                string strSql = " SELECT IdCategoria, NomeCategoria     ";
                strSql += " FROM PrjCategoria ";
                strSql += " ORDER BY IdCategoria ";

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
