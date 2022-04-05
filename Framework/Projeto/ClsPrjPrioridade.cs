using System;
using Database;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.Projeto
{
    public class ClsPrjPrioridade
    {
        #region [Propriedades]
        #region [     IdPrioridade     ]

        public int IdPrioridade
        {
            get;
            set;
        }
        #endregion

        #region [    NomePrioridade     ]
        
        public string NomePrioridade
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

        #region Método - Retorna todas as prioridades
        /// <summary>
        /// Método -  Retorna todas as prioridades
        /// </summary>
        /// <param name="intIdPrioridade">Número inteiro com o código da prioridade</param>
        /// <returns>Retorna um DataSet com as prioridades ou nulo</returns>
        public static System.Data.DataSet GetPrioridade(int intIdPrioridade = 0)
        {
            System.Data.DataSet objDataSet = new System.Data.DataSet();
            try
            {
                string strSql = "SELECT IdPrioridade, NomePrioridade ";
                strSql += " FROM PrjPrioridade ";
                strSql += " WHERE 1=1 ";

                if (intIdPrioridade != 0) strSql += " AND IdPrioridade = " + intIdPrioridade + " ";

                strSql += " ORDER BY IdPrioridade";

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

        #region [   GetIdNamePrioridade     ]
        /// <summary>
        /// Método - GetIdNamePrioridade
        /// </summary>
        /// <param name="intIdImpacto">Número inteiro com o id do impacto.</param>
        /// <param name="intIdUrgencia">Número inteiro com o id da urgência.</param>
        /// <param name="strIdPrioridade">Variável que irá retornar o id da prioridade.</param>
        /// <param name="strNomePrioridade">Variável que irá retornar o nome da prioridade</param>
        /// <param name="strMsgRetornoOperacao">Mensagem de retorno da operação</param>
        /// <returns>Retorna true ou false. Se foi identificado a prioridade ou não.</returns>
        public static bool GetIdNamePrioridade(out string strIdPrioridade, out string strNomePrioridade, out string strMsgRetornoOperacao, int intIdImpacto = 0, int intIdUrgencia = 0)
        {
            bool bolRetorno = true;
            strIdPrioridade = "";
            strNomePrioridade = "";
            System.Data.DataSet objDataSet = new System.Data.DataSet ();
            strMsgRetornoOperacao = "";

            try
            {
                //Valida as informações
                if(intIdImpacto == 0 || intIdUrgencia == 0)
                {
                    strMsgRetornoOperacao = "O código do impacto e/ou urgência não foram informados";
                    return false;
                }

                string strSql = "SELECT PrjPriorizacao.IdPrioridade, PrjPrioridade.NomePrioridade";
                strSql+= " FROM PrjPriorizacao, PrjPrioridade ";
                strSql+= " WHERE  PrjPriorizacao.IdPrioridade = PrjPrioridade.IdPrioridade";
                strSql+= " AND PrjPriorizacao.IdImpacto = "+ intIdImpacto +" ";
                strSql+= " AND PrjPriorizacao.IdUrgencia = "+ intIdUrgencia +"  ";

                using (Conexao cn = new Conexao())
                {
                    objDataSet = cn.ExecSQL(strSql);
                }

                if (objDataSet.Tables.Count > 0 && objDataSet.Tables[0].Rows.Count > 0)
                {
                    strIdPrioridade = objDataSet.Tables[0].Rows[0][0].ToString().Trim();
                    strNomePrioridade = objDataSet.Tables[0].Rows[0][1].ToString().Trim();
                    strMsgRetornoOperacao = "Prioridade definida com base na urgência e impacto.";
                    bolRetorno = true;
                }
                else
                {
                    strMsgRetornoOperacao = "Prioridade não configura para o impacto e urgência informada.";
                    bolRetorno = false;
                }

                return bolRetorno;

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
