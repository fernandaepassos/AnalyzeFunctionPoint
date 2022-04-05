using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Database;

namespace Framework.Vistoria
{
    public class ClsVistMarca
    {
        #region [   GeMarcas   ]
        /// <summary>
        /// [   GeMarcas   ]
        /// </summary>
        public static System.Data.DataSet GeMarcas(string strIdEmpresa)
        {
            try
            {
                string strSql = " SELECT IdMarca, NomeFabricante ";
                strSql += " FROM VistMarca ";
                strSql += " WHERE 1=1 ";
                if (!string.IsNullOrEmpty(strIdEmpresa.Trim())) strSql += " AND IdEmpresa = " + strIdEmpresa  + "";
                strSql += " ORDER BY NomeFabricante ";

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
