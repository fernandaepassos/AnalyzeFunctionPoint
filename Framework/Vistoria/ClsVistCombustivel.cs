using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Database;

namespace Framework.Vistoria
{
    public class ClsVistCombustivel
    {
        #region [   GetCombustivel   ]
        /// <summary>
        /// [   GetCombustivel   ]
        /// </summary>
        /// <param name="strIdEmpresa">Código da empresa</param>
        /// <returns>Retorna uma coleção (SqlDataReader) de dados </returns>
        public static System.Data.SqlClient.SqlDataReader GetCombustivel(string strIdEmpresa)
        {
            try
            {
                string strSql = " SELECT IdCombustivel, NomeCombustivel "; 
                strSql += " FROM VistCombustivel ";
                if (!string.IsNullOrEmpty(strIdEmpresa)) strSql += " WHERE IdEmpresa = " + strIdEmpresa + " ";
                strSql +=  " ORDER BY NomeCombustivel ASC ";

                using (Conexao cn = new Conexao())
                {
                    return cn.GetSqlDataReader(strSql);
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
