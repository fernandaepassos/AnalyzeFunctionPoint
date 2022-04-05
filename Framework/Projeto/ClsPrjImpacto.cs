using System;
using Database;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.Projeto
{
     public class ClsPrjImpacto
    {
        #region [prorpiedades]
        #region [     IdImpacto     ]
        
        public int IdImpacto
        {
            get;
            set;
        }
        #endregion

        #region [    NomeImpacto     ]
        
        public string NomeImpacto
        {
            get;
            set;
        }
        #endregion

        #region [    IdUltimoUsuario     ]
        
        public int IdUltimoUsuario
        {
            get;
            set;
        }
        #endregion

        #region [    IdInclusorUsuario     ]
        
        public int IdInclusorUsuario
        {
            get;
            set;
        }
        #endregion

        #region [    UltimaAtualizacao     ]
        
        public DateTime UltimaAtualizacao
        {
            get;
            set;
        }
        #endregion

        #region [    DataInclusao     ]
        
        public DateTime DataInclusao
        {
            get;
            set;
        }
        #endregion

        #endregion

        #region [ Métodos ]

        #region Método - Retorna todos os impactos
        /// <summary>
        /// Método - Retorna todos os impactos
        /// </summary>
        /// <param name="intIdImpacto">Número inteiro com códido do impacto</param>
        /// <returns>Retorna um DataSet com os impactos ou nulo</returns>
        public static System.Data.DataSet GetImpacto(int intIdImpacto = 0)
        {
            System.Data.DataSet objDataSet = new System.Data.DataSet();
            try
            {
                string strSql = "SELECT IdImpacto, NomeImpacto ";
                strSql += " FROM PRJIMPACTO ";
                strSql += " WHERE 1=1 ";

                if (intIdImpacto != 0) strSql += " AND IdImpacto = " + intIdImpacto + " ";

                strSql += " ORDER BY IdImpacto";

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
