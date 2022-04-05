using System;
using Database;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.Projeto
{
    
    public class ClsPrjUrgencia
    {
        #region [Propriedades]
        #region [     IdUrgencia     ]
        
        public int IdUrgencia
        {
            get;
            set;
        }
        #endregion

        #region [    NomeUrgencia     ]
        
        public string NomeUrgencia
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
        
        public int DataInclusao
        {
            get;
            set;
        }
        #endregion

        #endregion

        #region [ Métodos ]

        #region Método - Retorna todas as urgências
        /// <summary>
        /// Método -  Retorna todas as urgências
        /// </summary>
        /// <param name="intIdUrgencia">Número inteiro com códido da urgência</param>
        /// <returns>Retorna um DataSet com as urgências ou nulo</returns>
        public static System.Data.DataSet GetUrgencia(int intIdUrgencia = 0)
        {
            System.Data.DataSet objDataSet = new System.Data.DataSet();
            try
            {
                string strSql = "SELECT IdUrgencia, NomeUrgencia ";
                strSql += " FROM PrjUrgencia ";
                strSql += " WHERE 1=1 ";

                if (intIdUrgencia != 0) strSql += " AND IdUrgencia = " + intIdUrgencia + " ";

                strSql += " ORDER BY IdUrgencia";


                using (Conexao cn = new Conexao())
                {
                    objDataSet = cn.ExecSQL (strSql);
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
