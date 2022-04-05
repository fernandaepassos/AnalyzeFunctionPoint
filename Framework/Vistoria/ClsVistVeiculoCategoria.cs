using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Database;

namespace Framework.Vistoria
{
    public class ClsVistVeiculoCategoria
    {
        #region [   GetCategoria   ]
        /// <summary>
        /// [   GetCategoria   ]
        /// </summary>
        public static System.Data.DataSet GetCategoria(string strIdEmpresa)
        {
            try
            {
                string strSql = " SELECT IdVeiculoCategoria, Nome ";
                strSql += " FROM VistVeiculoCategoria ";
                strSql += " WHERE 1=1 ";
                if (!string.IsNullOrEmpty(strIdEmpresa.Trim())) strSql += " AND IdEmpresa = " + strIdEmpresa + " ";
                strSql += " ORDER BY Nome";

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
    }
}
