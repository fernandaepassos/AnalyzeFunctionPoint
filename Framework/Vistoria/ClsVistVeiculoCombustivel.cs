using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Database;

namespace Framework.Vistoria
{
    public class ClsVistVeiculoCombustivel
    {
        #region [   GetTypeCombustivel   ]
        /// <summary>
        /// [   GetTypeCombustivel   ]
        /// </summary>
        public static System.Data.SqlClient.SqlDataReader GetTypeCombustivel(string strIdEmpresa)
        {
            try
            {
                string strSql = " SELECT IdCombustivel, NomeCombustivel FROM VistCombustivel ";
                strSql += " ORDER BY NomeCombustivel ASC ";

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
