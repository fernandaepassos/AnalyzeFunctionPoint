using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Database;

namespace Framework.Vistoria
{
    public class ClsVistEspecie
    {
        #region [   GetEspecie   ]
        /// <summary>
        /// [   GetEspecie   ]
        /// </summary>
        /// <param name="strIdEmpresa">Código da empresa</param>
        /// <returns>Retorna uma coleção (SqlDataReader) de dados com a espécie</returns>
        public static System.Data.DataSet GetEspecie(string strIdEmpresa)
        {
            try
            {
                string strSql = " SELECT IdEspecie, NomeEspecie ";
                strSql += " FROM VistEspecie ";
                strSql += " WHERE 1=1 ";
                if(!string.IsNullOrEmpty(strIdEmpresa.Trim())) strSql += " AND IdEmpresa = " + strIdEmpresa  + " ";
                strSql += " ORDER BY NomeEspecie ";

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
