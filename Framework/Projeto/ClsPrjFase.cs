using System;
using Database;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.Projeto
{
    public class ClsPrjFase
    {
        #region [ Métodos ]

        #region [   Método - Retorna todas as fases     ]
        /// <summary>
        /// Método - Retorna todas as fases
        /// </summary>
        /// <returns>Retorna um DataSet com todas as fases</returns>
        public static System.Data.DataSet GetFase()
        {
            System.Data.DataSet objDataSet = new System.Data.DataSet();
            try
            {
                string strSql = " select IdFase, NomeFase";
                strSql += " from PrjFase ";
                strSql += " order by IdFase ";

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


        #region [   Método - Retorna todas as fases     ]
        /// <summary>
        /// Método - Retorna todas as fases
        /// </summary>
        /// <returns>Retorna um DataSet com todas as fases</returns>
        public static System.Data.DataSet GetFaseAll()
        {
            System.Data.DataSet objDataSet = new System.Data.DataSet();
            try
            {
                string strSql = " SELECT PrjFase.IdFase, PrjFase.NomeFase, PrjFase.QtdTarefaFase, PrjTarefas.IdTarefa, PrjTarefas.NumTarefa, PrjTarefas.TituloTarefa, ";
                strSql += " (SELECT NomePessoa FROM SigePessoa WHERE IdPessoa =  PrjTarefas.IdPessoa) Pessoa ";
                strSql += " FROM PrjFase, PrjTarefas ";
                strSql += " WHERE PrjFase.IdFase = PrjTarefas.IdFase ";

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
