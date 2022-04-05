using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Database;

namespace Framework.Projeto
{
    public class ClsPrjTarefaAndamento
    {
        #region [   Prorpiedades    ]

        private static int IdintTarefaAndamento;

        #region [     IdTarefaAndamento     ]
        
        public int IdTarefaAndamento
        {
            get
            {
                return IdintTarefaAndamento;
            }
            set
            {
                IdintTarefaAndamento = value;
            }
        }
        #endregion

        #region [    IdTarefa     ]
        
        public int IdTarefa
        {
            get;
            set;
        }
        #endregion

        #region [    IdPessoa     ]
        
        public int IdPessoa
        {
            get;
            set;
        }
        #endregion

        #region [    DescAndamento     ]
        
        public string DescAndamento
        {
            get;
            set;
        }
        #endregion

        #region [    DataHoraInicio     ]
        
        public string DataHoraInicio
        {
            get;
            set;
        }
        #endregion

        #region [    DataHoraFim     ]
        
        public string DataHoraFim
        {
            get;
            set;
        }
        #endregion

        #region [    Duracao     ]
        
        public string Duracao
        {
            get;
            set;
        }
        #endregion

        #region [    PerConcluidoRefTarefa     ]
        
        public int PerConcluidoRefTarefa
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

        #region [    DataInclusao     ]
        
        public string DataInclusao
        {
            get;
            set;
        }
        #endregion

        #endregion
        
        #region [ Métodos ]

        #region [   GetAndamentoTarefa  ]
        /// <summary>
        /// Método - Retorna os andamentos por tarefa
        /// </summary>
        /// <param name="intIdImpacto">Número inteiro com códido da tarefa</param>
        /// <returns> Retorna um objeto DataSet</returns>
        public static System.Data.DataSet GetAndamentoTarefa(int intIdTarefa, int intIdTarefaAndamento = 0)
        {
            System.Data.DataSet objDataSet = new System.Data.DataSet();
            try
            {
                string strSql = " SELECT IdTarefaAndamento, DescAndamento ,SigePessoa.NomePessoa as NomePessoa, (CONVERT(nvarchar,DataHoraInicio,103)+' '+ CONVERT(nvarchar,DataHoraInicio,108)) as DataHoraInicio, (CONVERT(nvarchar,DataHoraFim,103)+' '+ CONVERT(nvarchar,DataHoraFim,108)) as DataHoraFim, Duracao, PerConcluidoRefTarefa , PrjTarefaAndamento.IdPessoa";
                strSql += "  FROM PrjTarefaAndamento, SigePessoa ";
                strSql += "  WHERE PrjTarefaAndamento.IdPessoa = SigePessoa.IdPessoa ";
                if (intIdTarefaAndamento > 0) strSql += "   AND IdTarefaAndamento = " + intIdTarefaAndamento + " ";
                if (intIdTarefa > 0) strSql += "   AND IdTarefa = " + intIdTarefa + " ";

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

        #region [   Valida o Andamento ]
        /// <summary>
        /// Método - Valida o Andamento
        /// Data: 15/07/2013 | Autora: Fernanda Passos
        /// </summary>
        /// <param name="strMensagemValida">String com mensagem de retorno de como foi a operação no método</param>
        /// <returns>Retorna true ou false. Se foi ou não validado.</returns>
        private bool Validacao(out string strMensagemValida)
        {
            strMensagemValida = "";
            bool bolRetorno = true;
            try
            {
                if (IdTarefa <= 0)
                {
                    strMensagemValida += "Informe a tarefa.";
                    bolRetorno = false;
                }

                if (IdPessoa <= 0)
                {
                    strMensagemValida += "Informe a pessoa.";
                    bolRetorno = false;
                }

                if (PerConcluidoRefTarefa <= 0)
                {
                    strMensagemValida += "Informe o % de andamento.";
                    bolRetorno = false;
                }

                if (DataHoraInicio == null || DataHoraInicio.ToString() == "01/01/0001 00:00:00" || DataHoraInicio.ToString().Trim() == "")
                {
                    strMensagemValida += "Informe a data/hora de início.";
                    bolRetorno = false;
                }

                if (DataHoraFim == null || DataHoraFim.ToString() == "01/01/0001 00:00:00" || DataHoraFim.ToString().Trim() == "")
                {
                    strMensagemValida += "Informe a data/hora do término.";
                    bolRetorno = false;
                }

                if (Duracao.Trim() == "")
                {
                    strMensagemValida += "Informe a duração.";
                    bolRetorno = false;
                }

                if (string.IsNullOrEmpty(DescAndamento))
                {
                    strMensagemValida += "Informe a descrição.";
                    bolRetorno = false;
                }


                //if ((DataHoraFim != null && DataHoraInicio != null) && (DataHoraFim.ToString() != "01/01/0001 00:00:00" && DataHoraInicio.ToString() != "01/01/0001 00:00:00"))
                //{
                //    if (DataHoraFim < DataHoraInicio)
                //    {
                //        strMensagemValida += "A data de término não pode ser menor que a de início.";
                //        bolRetorno = false;
                //    }
                //}


                return bolRetorno;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region [   DefineDuracaoes ]
        /// <summary>
        /// [   DefineDuracaoes ]
        /// </summary>
        private void DefineDuracaoes()
        {
            try
            {
                //Duração Prevista (Em dias)

                //if ((DataHoraInicio != null && DataHoraInicio.ToString().Trim() != "" && DataHoraInicio.ToString().Trim() != "01/01/0001 00:00:00") && (DataHoraFim != null && DataHoraFim.ToString().Trim() != "" && DataHoraFim.ToString().Trim() != "01/01/0001 00:00:00"))
                //{
                //    Duracao = (DataHoraFim - DataHoraInicio).TotalDays.ToString();
                //}
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region [   SetDuracaoCorrenteProjeto    ]
        /// <summary>
        /// [   SetDuracaoCorrenteProjeto    ]
        /// </summary>
        /// <param name="intIdProjeto"></param>
        /// <returns></returns>
        private void SetDuracaoCorrenteProjeto(int intIdProjeto)
        {
            System.Data.DataSet objDataSet = objDataSet = new System.Data.DataSet();
            try
            {
                if (intIdProjeto > 0)
                {
                    //Identifica a soma da duração das tarefas
                    string strSql = "SELECT SUM((DATEDIFF(DAY, DataHoraInicio, DataHoraFim))) AS TOT_DIA , SUM((DATEDIFF(HOUR, DataHoraInicio, DataHoraFim)))  AS TOT_HORA ";
                    strSql += " FROM PrjTarefaAndamento  ";
                    strSql += " WHERE DataHoraInicio IS NOT NULL AND DataHoraFim IS NOT NULL ";
                    strSql += " AND IdTarefa IN (SELECT IdTarefa FROM PrjTarefas WHERE IdProjeto = " + intIdProjeto + ")";

                    using (Conexao cn = new Conexao())
                    {
                        objDataSet = objDataSet = cn.ExecSQL(strSql);
                    }

                    if (objDataSet != null && objDataSet.Tables.Count > 0 && objDataSet.Tables[0].Rows.Count > 0)
                    {
                        //Concatena os campos
                        string strDuracaoCorrenteProjeto = objDataSet.Tables[0].Rows[0]["TOT_DIA"].ToString().Trim() + ":" + objDataSet.Tables[0].Rows[0]["TOT_HORA"].ToString().Trim();

                        //Insere a duração corrente dentro do projeto
                        strSql = "UPDATE PrjProjeto SET DuracaoCorrente  = '" + strDuracaoCorrenteProjeto + "' WHERE IdProjeto = " + intIdProjeto + "";
                        using (Conexao cn = new Conexao())
                        {
                            cn.ExecSQL(strSql);
                        }
                    }
                }
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

        #region [   Método - Excluir ]
        /// <summary>
        /// Método - Excluir 
        /// Data da criação: 09/07/2013 | Autora: Fernanda Passos
        /// </summary>
        /// <param name="intIdProjeto">Número inteiro com o código identificador do registro</param>
        /// <param name="strMensagem">Mensagem com retorno da operação</param>
        /// <returns>Retorna true ou false, se foi ou não excluído.</returns>
        public bool Excluir(out string strMensagem)
        {
            strMensagem = "";
            bool boleRetorno = true;

            try
            {
                //Valida a exclusão
                if (IdTarefaAndamento <= 0)
                {
                    strMensagem = "Informe o andamento da tarefa.";
                    return false;
                }

                try
                {
                    //Exclui o andamento 
                    string strSql = "delete PrjTarefaAndamento WHERE IdTarefaAndamento = "+ IdTarefaAndamento +"";
                    using (Conexao cn = new Conexao())
                    {
                        cn.ExecSQL(strSql.ToString());
                    }


                    strMensagem = "Registro excluído com sucesso.";
                    IdTarefa = 0;
                    boleRetorno = true;
                }
                catch
                {
                    strMensagem = "Não foi possível excluir o registro.  Contate o administrador do sistema.";
                    boleRetorno = false;
                }
                return boleRetorno;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region [   GetTotalAndamentoPorTarefa  ]
        /// <summary>
        /// [   GetTotalAndamentoPorTarefa  ]
        /// </summary>
        /// <param name="intIdTarefa">int Código da tarefa</param>
        /// <returns>Retorna a quantidade de andamentos da tarefa</returns>
        public static int GetTotalAndamentoPorTarefa(int intIdTarefa)
        {
            System.Data.DataSet objDataSet = new System.Data.DataSet();
            try
            {
                if (intIdTarefa <= 0) return 0;

                string strSql = "SELECT COUNT(*) AS TOT_ANDAMENTO FROM PrjTarefaAndamento WHERE IdTarefa = " + intIdTarefa + "";

                using (Conexao cn = new Conexao())
                {
                    objDataSet = cn.ExecSQL(strSql);
                }

                if (objDataSet != null && objDataSet.Tables.Count > 0 && objDataSet.Tables[0].Rows.Count > 0)
                {
                    return Convert.ToInt32(objDataSet.Tables[0].Rows[0]["TOT_ANDAMENTO"].ToString().Trim());
                }
                else return 0;
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

        #region [   Gravar  ]
        /// <summary>
        /// OBJETIVO DO MÉTODO: MÉTODO PARA INSERÇÃO E ALTERAÇÃO DE REGISTROS NA TABELA PrjTarefaAndamento
        /// DATA\HORA CRIAÇÃO :02/08/2013 11:49:32
        /// COMPUTADOR GERADOR:DEVELOPMENT04
        /// </summary>
        /// <returns>RETORNA TRUE OU FALSE. SE O PROCESSO FOI REALIZADO COM SUCESSO OU NÃO </returns>
        /// <param name="strMsgRetorno">Variável string com uma mensagem de retorno da operação no método.</param>
        public bool Gravar(out string strMsgRetorno)
        {
            strMsgRetorno = "";

            try
            {

                //Valida das informações do projeto.
                if (!Validacao(out strMsgRetorno)) return false;

                //DefineDuracaoes();

                using (Conexao cn = new Conexao())
                {
                    cn.AddParametros("IdTarefaAndamento", (IdintTarefaAndamento != null && IdintTarefaAndamento > 0 ? IdintTarefaAndamento.ToString() : "0"));
                    cn.AddParametros("IdTarefa", IdTarefa.ToString());
                    cn.AddParametros("IdPessoa", IdPessoa.ToString());
                    cn.AddParametros("DescAndamento", DescAndamento);

                    cn.AddParametros("DataHoraInicio", (DataHoraInicio == null || DataHoraInicio.ToString().Trim() == "01/01/0001 00:00:00" || DataHoraInicio.ToString().Trim() == "" ? "" : DataHoraInicio));
                    cn.AddParametros("DataHoraFim", (DataHoraFim == null || DataHoraFim.ToString().Trim() == "01/01/0001 00:00:00" || DataHoraFim.ToString().Trim() == "" ? "" : DataHoraFim));
                    cn.AddParametros("Duracao", (Duracao.ToString().Trim().Replace(":", "") == "" ? "" : Duracao));

                    cn.AddParametros("PerConcluidoRefTarefa", PerConcluidoRefTarefa.ToString());
                    cn.AddParametros("IdInclusorUsuario", (IdInclusorUsuario > 0  && IdInclusorUsuario.ToString().Trim() != "0" && IdInclusorUsuario.ToString().Trim() != "" ? IdInclusorUsuario.ToString() : ""));
                    cn.AddParametros("DataInclusao", "");

                    cn.CriarPedido("STP_PrjTarefaAndamento_IncAlt", false);

                    string valor = cn.GetValor("RESPOSTA", 0, 0);

                    switch (valor)
                    {
                        case "I":
                            strMsgRetorno = "Registro incluído com sucesso.";
                            break;
                        case "A":
                            strMsgRetorno = "Registro alterado com sucesso.";
                            break;
                        default:
                            strMsgRetorno = "Não foi possível incluir ou alterar o registro.";
                            break;
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (strMsgRetorno == "")
                {
                    strMsgRetorno = "Operação realizada com sucesso.";
                }

                // ADICIONE AQUI FECHAMENTO DE OBJETOS QUE OCUPAM ESPAÇO NA MM E QUE NÃO SERÃO
                // USADOS DEPOIS QUE EXCUTAR ESSE MÉTODO.
            }
        }
        #endregion


        #endregion
    }
}
