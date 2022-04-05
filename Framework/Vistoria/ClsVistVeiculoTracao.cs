using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Database;

namespace Framework.Vistoria
{
    public class ClsVistVeiculoTracao
    {
        #region [   GetTracao   ]
        /// <summary>
        /// [   GetTracao   ]
        /// </summary>
        public static System.Data.DataSet GetTracao(string strIdEmpresa)
        {
            try
            {
                string strSql = " SELECT IdVeiculoTracao, Nome  ";
                strSql += " FROM VistVeiculoTracao  ";
                if (!string.IsNullOrEmpty(strIdEmpresa)) strSql += " WHERE IDEMPRESA  = "+ strIdEmpresa +"  ";
                strSql += " ORDER BY Nome  ";

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
