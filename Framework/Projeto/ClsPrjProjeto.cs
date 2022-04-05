using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Database;
using System.Web;

namespace Framework.Projeto
{
    public class ClsPrjProjeto
    {
        private static int intIdInternalProjeto = 0;

        #region [prorpiedades]

        #region [     IdProjeto     ]
        
        public int IdProjeto
        {
            get
            {
                return intIdInternalProjeto;
            }
            set
            {
                intIdInternalProjeto = value;
            }
        }
        #endregion

        #region [    Titulo     ]
        
        public string Titulo
        {
            get;
            set;
        }
        #endregion

        #region [    DescProjeto     ]
        
        public string DescProjeto
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

        #region [    IdStatus     ]
        
        public int IdStatus
        {
            get;
            set;
        }
        #endregion

        #region [    IdEmpresa     ]
        
        public int IdEmpresa
        {
            get;
            set;
        }
        #endregion

        #region [    IdSistema     ]
        
        public int IdSistema
        {
            get;
            set;
        }
        #endregion

        #region [    NumPropostaComercial     ]
        
        public string NumPropostaComercial
        {
            get;
            set;
        }
        #endregion

        #region [    DataInicioPrevisto     ]
        
        public string DataInicioPrevisto
        {
            get;
            set;
        }
        #endregion

        #region [    DataFimPrevisto     ]
        
        public string DataFimPrevisto
        {
            get;
            set;
        }
        #endregion

        #region [    DataInicioRealizado     ]
        
        public string DataInicioRealizado
        {
            get;
            set;
        }
        #endregion

        #region [    DataFimRealizado     ]
        
        public string DataFimRealizado
        {
            get;
            set;
        }
        #endregion

        #region [    DuracaoPrevista     ]
        
        public string DuracaoPrevista
        {
            get;
            set;
        }
        #endregion

        #region [    DuracaoRalizada     ]
        
        public string DuracaoRalizada
        {
            get;
            set;
        }
        #endregion

        #region [    DuracaoCorrente     ]
        
        public string DuracaoCorrente
        {
            get;
            set;
        }
        #endregion

        #region [    IdEmprIdImpactoesa     ]
        
        public int IdImpacto
        {
            get;
            set;
        }
        #endregion

        #region [    IdUrgencia     ]
        
        public int IdUrgencia
        {
            get;
            set;
        }
        #endregion

        #region [    IdPrioridade     ]
        
        public int IdPrioridade
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
        
        public string UltimaAtualizacao
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

        #region [   Valida Projeto ]
        /// <summary>
        /// Método - Valida Projeto
        /// Data: 09/07/2013 | Autor: Fernanda Passos
        /// </summary>
        /// <param name="strMensagemValida">String com mensagem de retorno de como foi a operação no método</param>
        /// <returns>Retorna true ou false. Se foi ou não validado.</returns>
        private bool Validacao(out string strMensagemValida)
        {
            strMensagemValida = "";
            bool bolRetorno = true;
            try
            {
                if (string.IsNullOrEmpty(Titulo))
                {
                    strMensagemValida += "Informe o título do projeto.";
                    bolRetorno = false;
                }

                if (string.IsNullOrEmpty(DescProjeto))
                {
                    strMensagemValida +=  "Informe a descrição do projeto. ";
                    bolRetorno = false;
                }

                if (IdStatus <= 0)
                {
                    strMensagemValida += "Selecione o status.  ";
                    bolRetorno = false;
                }

                if (IdPessoa <= 0)
                {
                    strMensagemValida += "Informe o responsável.  ";
                    bolRetorno = false;
                }

                if (IdEmpresa <= 0)
                {
                    strMensagemValida += "Selecione o cliente.  ";
                    bolRetorno = false;
                }

                if (IdSistema <= 0)
                {
                    strMensagemValida += "Selecione o sistema no qual se aplica o projeto.  ";
                    bolRetorno = false;
                }

                if (IdPrioridade <= 0)
                {
                    strMensagemValida += "Selecione a prioridade.  ";
                    bolRetorno = false;
                }
                
                //if ((DataFimPrevisto != null && DataInicioPrevisto != null && DataFimPrevisto.ToString().Trim() != "01/01/0001 00:00:00" && DataInicioPrevisto.ToString().Trim() != "01/01/0001 00:00:00") && (DataFimPrevisto < DataInicioPrevisto))
                //{
                //    strMensagemValida += "A data fim prevista não pode ser menor que a data de início prevista.  ";
                //    bolRetorno = false;
                //}

                //if ((DataFimRealizado != null && DataInicioRealizado != null && DataFimRealizado.ToString().Trim() != "01/01/0001 00:00:00" && DataInicioRealizado.ToString().Trim() != "01/01/0001 00:00:00") && (DataFimRealizado < DataInicioRealizado))
                //{
                //    strMensagemValida +=  "A data fim realizada não pode ser menor que a data de início realizada.  ";
                //    bolRetorno = false;
                //}

                return bolRetorno;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region [   GetDuracaoPrevista    ]
        /// <summary>
        /// [   GetDuracaoPrevista    ]
        /// </summary>
        /// <param name="intIdProjeto"></param>
        /// <returns></returns>
        private string GetDuracaoPrevista(int intIdProjeto)
        {
            System.Data.DataSet objDataSet = objDataSet = new System.Data.DataSet();
            try
            {
                if (intIdProjeto > 0)
                {
                    string strTemp = " SELECT (DATEDIFF(DAY,DataInicioPrevisto, DataFimPrevisto)) AS TOT_DIA , (DATEDIFF(HOUR,DataInicioPrevisto, DataFimPrevisto))  AS TOT_HORA ";
                    strTemp += "  FROM PrjProjeto ";
                    strTemp += "  where DataInicioPrevisto is not null";
                    strTemp += "  and DataFimPrevisto is not null";
                    strTemp += "  and IdProjeto = " + intIdProjeto + "";

                    using (Conexao cn = new Conexao())
                    {
                        objDataSet = cn.ExecSQL(strTemp);
                    }

                    if (objDataSet != null && objDataSet.Tables.Count > 0 && objDataSet.Tables[0].Rows.Count > 0)
                    {
                        return objDataSet.Tables[0].Rows[0]["TOT_DIA"].ToString().Trim() + ":" + objDataSet.Tables[0].Rows[0]["TOT_HORA"].ToString().Trim();
                    }
                    else return "";
                }
                else return "";
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

        #region [   GetDuracaoReal    ]
        /// <summary>
        /// [   GetDuracaoReal    ]
        /// </summary>
        /// <param name="intIdProjeto"></param>
        /// <returns></returns>
        private string GetDuracaoReal(int intIdProjeto)
        {
            System.Data.DataSet objDataSet = objDataSet = new System.Data.DataSet();
            try
            {
                if (intIdProjeto > 0)
                {
                    string strTemp = " SELECT (DATEDIFF(DAY, DataInicioRealizado , DataFimRealizado)) AS TOT_DIA";
                    strTemp += " FROM PrjProjeto ";
                    strTemp += " where DataInicioRealizado is not null ";
                    strTemp += " and DataFimRealizado is not null ";
                    strTemp += " and IdProjeto = " + intIdProjeto + " ";

                    using (Conexao cn = new Conexao())
                    {
                        objDataSet = cn.ExecSQL (strTemp);
                    }

                    if (objDataSet != null && objDataSet.Tables.Count > 0 && objDataSet.Tables[0].Rows.Count > 0)
                    {
                        return objDataSet.Tables[0].Rows[0]["TOT_DIA"].ToString().Trim();
                    }
                    else return "";
                }
                else return "";
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

        #region [   GetDataUltimaTarefaConcluida    ]
        /// <summary>
        /// [   GetDataUltimaTarefaConcluida    ]
        /// </summary>
        /// <param name="intIdProjeto"></param>
        /// <returns></returns>
        private string GetDataUltimaTarefaConcluida(int intIdProjeto)
        {
            System.Data.DataSet objDataSet = new System.Data.DataSet();
            try
            {
                if (intIdProjeto > 0)
                {
                    string strSql = " SELECT top 1 CONVERT(nvarchar,DataFimRealizada, 103)+' '+ CONVERT(nvarchar, DataFimRealizada, 108) as DataFimRealizada ";
                    strSql += "  FROM PrjTarefas";
                    strSql += "  WHERE IdProjeto = " + intIdProjeto + " ";
                    strSql += "  ORDER BY DataFimRealizada DESC ";

                    using (Conexao cn = new Conexao())
                    {
                        objDataSet = cn.ExecSQL(strSql);
                    }
                    if (objDataSet != null && objDataSet.Tables.Count > 0 && objDataSet.Tables[0].Rows.Count > 0) return objDataSet.Tables[0].Rows[0]["DataFimRealizada"].ToString().Trim(); else return "";

                }
                else return "";
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

        #region [   GetDatasHoraInicioEFimReal    ]
        /// <summary>
        /// [   GetDataUltimaTarefaConcluida    ]
        /// </summary>
        /// <param name="intIdProjeto">Código do projeto</param>
        /// <returns>Retorna uma string com a data ou vazio.</returns>
        /// <param name="strTipoData">Os tipos de dado podem ser: InicioReal ou FimReal</param>
        private string GetDatasHoraInicioEFimReal(int intIdProjeto, string strTipoData)
        {
            System.Data.DataSet objDataSet = new System.Data.DataSet();
            try
            {
                if (intIdProjeto > 0)
                {
                    string strSql = "";
                    if (strTipoData.Trim().ToLower().Contains("FimReal".ToLower()))
                    {
                        //Projeto	Data Fim Real	"=[Data/Hora Fim do último andamento entre as tarefas do projeto]"	Cálculada somente quando o status do projeto mudar para concluído.
                        strSql = " SELECT TOP  1 CONVERT(NVARCHAR, DataHoraFim, 103)+' '+ CONVERT(NVARCHAR, DataHoraFim, 108) ";
                        strSql += "  FROM PrjTarefaAndamento";
                        strSql += "  WHERE IdTarefa IN (SELECT IdTarefa FROM PrjTarefas WHERE IdProjeto = " + IdProjeto + ") ";
                        strSql += "  ORDER BY DataHoraFim DESC ";
                    }
                    else if (strTipoData.Trim().ToLower().Contains("InicioReal".ToLower()))
                    {
                        //Projeto -  Define Data Início Real - Fórmula - "=[Data/Hora Início do Primeiro Andamento]" - Regra: Cálculada somente quando houver tarefa com registro de andamento.
                        strSql = "  SELECT  TOP 1 CONVERT(NVARCHAR, DATAHORAINICIO, 103)+' '+ CONVERT(NVARCHAR, DATAHORAINICIO, 108)  ";
                        strSql += "  FROM PrjTarefaAndamento ";
                        strSql += "  WHERE IdTarefa IN (SELECT IdTarefa FROM PrjTarefas WHERE IdProjeto = " + intIdProjeto + ") ";
                        strSql += "  ORDER BY DATAHORAINICIO ASC ";

                    }
                    else return "";

                    if (objDataSet != null && objDataSet.Tables.Count > 0 && objDataSet.Tables[0].Rows.Count > 0)
                    {
                        return objDataSet.Tables[0].Rows[0][0].ToString().Trim();
                    }
                    else
                    {
                        return "";
                    }
                }
                else return "";
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

        #region [   GetSomaDuracaoProjeto    ]
        /// <summary>
        /// [   GetSomaDuracaoProjeto    ]
        /// </summary>
        /// <param name="intIdProjeto">Código do projeto</param>
        /// <returns>Retorna a duração do projeto</returns>
        private string GetSomaDuracaoProjeto(int intIdProjeto)
        {
            System.Data.DataSet objDataSet = new System.Data.DataSet();
            try
            {
                if (intIdProjeto > 0)
                {

                    string strSql = " SELECT SUM(CONVERT(INT,DURACAO))";
                    strSql += "  FROM PrjTarefaAndamento ";
                    strSql += "  WHERE IdTarefa IN (SELECT IdTarefa FROM PrjTarefas WHERE IdProjeto = " + intIdProjeto + ") ";


                    if (objDataSet != null && objDataSet.Tables.Count > 0 && objDataSet.Tables[0].Rows.Count > 0)
                    {
                        return objDataSet.Tables[0].Rows[0][0].ToString().Trim();
                    }
                    else
                    {
                        return "";
                    }
                }
                else return "";
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

        #region "MÉTODO - INCLUI E ALTERA REGISTRO NO BANCO DE DADOS
        /// <summary>
        /// OBJETIVO DO MÉTODO: MÉTODO PARA INSERÇÃO E ALTERAÇÃO DE REGISTROS NA TABELA PrjProjeto
        /// DATA\HORA CRIAÇÃO :01/08/2013 16:57:05
        /// COMPUTADOR GERADOR:DEVELOPMENT04
        /// </summary>
        /// <returns>RETORNA TRUE OU FALSE. SE O PROCESSO FOI REALIZADO COM SUCESSO OU NÃO </returns>
        /// <param name="strMsgRetorno">Variável string com uma mensagem de retorno da operação no método.</param>
        public bool Gravar(out string strMsgRetorno, out int intIdProjeto)
        {
            strMsgRetorno = "";
            intIdProjeto = 0;
            try
            {

                //Valida das informações do projeto.
                if (!Validacao(out strMsgRetorno)) return false;

                //DefineDuracaoes();

                using (Conexao cn = new Conexao())
                {
                    cn.AddParametros("IdProjeto", (IdProjeto > 0 ? IdProjeto.ToString() : "0"));
                    cn.AddParametros("Titulo", Titulo);
                    cn.AddParametros("DescProjeto", DescProjeto);
                    cn.AddParametros("IdPessoa", (IdPessoa > 0 ? IdPessoa.ToString() : ""));
                    cn.AddParametros("IdStatus", (IdStatus > 0 ? IdStatus.ToString() : ""));
                    cn.AddParametros("IdEmpresa", (IdEmpresa > 0 ? IdEmpresa.ToString() : ""));
                    cn.AddParametros("IdSistema", (IdSistema > 0 ? IdSistema.ToString() : ""));
                    cn.AddParametros("NumPropostaComercial", NumPropostaComercial);

                    cn.AddParametros("DataInicioPrevisto", (DataInicioPrevisto == null || DataInicioPrevisto.ToString().Trim() == "01/01/0001 00:00:00" || DataInicioPrevisto.ToString().Trim() == "" ? "" : DataInicioPrevisto));
                    cn.AddParametros("DataFimPrevisto", (DataFimPrevisto == null || DataFimPrevisto.ToString().Trim() == "01/01/0001 00:00:00" || DataFimPrevisto.ToString().Trim() == "" ? "" : DataFimPrevisto));
                    cn.AddParametros("DataInicioRealizado", (DataInicioRealizado == null || DataInicioRealizado.ToString().Trim() == "01/01/0001 00:00:00" || DataInicioRealizado.ToString().Trim() == "" ? "" : DataInicioRealizado));
                    cn.AddParametros("DataFimRealizado", (DataFimRealizado == null || DataFimRealizado.ToString().Trim() == "01/01/0001 00:00:00" || DataFimRealizado.ToString().Trim() == "" ? "" : DataFimRealizado));

                    cn.AddParametros("DuracaoPrevista", (DuracaoPrevista.ToString().Trim().Replace(":", "") == "" ? "" : DuracaoPrevista));
                    cn.AddParametros("DuracaoRalizada", (DuracaoRalizada.ToString().Trim().Replace(":", "") == "" ? "" : DuracaoRalizada));
                    cn.AddParametros("DuracaoCorrente", (DuracaoCorrente.ToString().Trim().Replace(":", "") == "" ? "" : DuracaoCorrente));

                    cn.AddParametros("IdImpacto", (IdImpacto > 0 ? IdImpacto.ToString() : ""));
                    cn.AddParametros("IdUrgencia", (IdUrgencia > 0 ? IdUrgencia.ToString() : ""));
                    cn.AddParametros("IdPrioridade", (IdPrioridade > 0 ? IdPrioridade.ToString() : ""));

                    cn.AddParametros("IdUltimoUsuario", (IdUltimoUsuario != null && IdUltimoUsuario.ToString().Trim() != "0" && IdUltimoUsuario.ToString().Trim() != "" ? IdUltimoUsuario.ToString() :""));
                    cn.AddParametros("IdInclusorUsuario", (IdInclusorUsuario != null && IdInclusorUsuario.ToString().Trim() != "0" && IdInclusorUsuario.ToString().Trim() != "" ? IdInclusorUsuario.ToString() :""));

                    cn.AddParametros("UltimaAtualizacao", "");
                    cn.AddParametros("DataInclusao", "");

                    cn.CriarPedido("STP_PrjProjeto_IncAlt", false);

                    string valor = cn.GetValor("RESPOSTA", 0, 0);

                    switch (valor)
                    {
                        case "I":
                            strMsgRetorno = "Registro incluído com sucesso.";
                            string strIdProjetoNew = cn.GetValor("ID_PROJETO", 0, 0);
                            if (!string.IsNullOrEmpty(strIdProjetoNew))
                            {
                                IdProjeto = Convert.ToInt32(strIdProjetoNew);
                                intIdProjeto = Convert.ToInt32(strIdProjetoNew);
                                intIdInternalProjeto = Convert.ToInt32(strIdProjetoNew);
                            }
                            return true;
                        case "A":
                            strMsgRetorno = "Registro alterado com sucesso.";
                            intIdProjeto = intIdInternalProjeto;
                            return true;
                        default:
                            strMsgRetorno = "Não foi possível incluir ou alterar o registro.";
                            return false;
                    }
                    return false;
                }
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
                //if ((DataInicioPrevisto != null && DataInicioPrevisto.ToString().Trim() != "" && DataInicioPrevisto.ToString().Trim() != "01/01/0001 00:00:00") && (DataFimPrevisto != null && DataFimPrevisto.ToString().Trim() != "" && DataFimPrevisto.ToString().Trim() != "01/01/0001 00:00:00"))
                //{
                //    try
                //    {
                //        DuracaoPrevista = (DataFimPrevisto - DataInicioPrevisto).TotalDays.ToString().Substring(0, 4);
                //    }
                //    catch { }
                //}

                //try
                //{
                //    //Projeto -  Define Data Início Real - Fórmula - "=[Data/Hora Início do Primeiro Andamento]" - Regra: Cálculada somente quando houver tarefa com registro de andamento.
                //    string strInicioReal = GetDatasHoraInicioEFimReal(IdProjeto, "InicioReal");
                //    if (!string.IsNullOrEmpty(strInicioReal)) DataFimRealizado = Convert.ToDateTime(strInicioReal);
                //}
                //catch { }

                //Projeto	Data Fim Real	"=[Data/Hora Fim do último andamento entre as tarefas do projeto]"	Cálculada somente quando o status do projeto mudar para concluído.
                //if (IdStatus == 5 && (DataFimRealizado == null || DataFimRealizado.ToString().Trim() == "" || DataFimRealizado.ToString().Trim() == "01/01/0001 00:00:00"))
                //{
                //    try
                //    {
                //        string strDataFimRealizado = GetDatasHoraInicioEFimReal(IdProjeto, "FimReal");
                //        if (!string.IsNullOrEmpty(strDataFimRealizado)) DataFimRealizado = Convert.ToDateTime(strDataFimRealizado);
                //    }
                //    catch { }
                //}

                //Projeto	Duração Real	"=Soma[DuracaoAndamentosDeTodasTarefas]"	Cálculada somente quando o status do projeto mudar para concluído.
                if (IdStatus == 5 && (DuracaoRalizada == null || DuracaoRalizada.ToString().Trim() == "" || DuracaoRalizada.Trim().Replace(":","") == ""))
                {
                    try
                    {
                        DuracaoRalizada = GetDuracaoReal(IdProjeto).Substring(0, 4);
                    }
                    catch { }
                }
                
                //Projeto	Duração Corrente	"=Soma[DuracaoAndamentosDeTodasTarefas]"	Cálculada somente quando houver registro de andamento de tarefas do projeto
                try
                {
                    DuracaoRalizada = GetDuracaoReal(IdProjeto).ToString().Substring(0, 4);
                }
                catch { }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region [   Método - Excluir Projeto ]
        /// <summary>
        /// Método - Excluir Projeto
        /// Data da criação: 09/07/2013 | Autora: Fernanda Passos
        /// </summary>
        /// <param name="intIdProjeto">Número inteiro com o código do projeto</param>
        /// <param name="strMensagem">Mensagem com retorno da operação</param>
        /// <returns>Retorna true ou false, se foi ou não excluído.</returns>
        public bool ExcluirProjeto(out string strMensagem)
        {
            strMensagem = "";
            bool boleRetorno = true;

            try
            {
                //Valida a exclusão
                if (!ValidacaoExclusao(out strMensagem)) return false;

                try
                {
                    using (Conexao cn = new Conexao())
                    {
                        cn.AddParametros("IdProjeto", intIdInternalProjeto.ToString());

                        cn.CriarPedido("STP_PrjProjeto_Exc", false);
                        //string valor = cn.GetValor("RESPOSTA", 0, 0);

                        string valor = cn.GetValor("RESPOSTA", 0, 0);

                        switch (valor)
                        {
                            case "1":
                                strMensagem = "Registro excluído com sucesso.";
                                boleRetorno = true;
                                break;
                            case "2":
                                strMensagem = "Não foi possível excluir o registro.";
                                boleRetorno = false;
                                break;
                            default:
                                strMensagem = "Não foi possível excluir o registro.";
                                boleRetorno = false;
                                break;
                        }
                   }

                   IdProjeto = 0;
                    return boleRetorno;

                }
                catch
                {
                    strMensagem = "Não foi possível excluir o registro.  Contate o administrador do sistema.";
                    return boleRetorno;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region [   SetMaxIdProject     ]
        /// <summary>
        /// Método - SetMaxIdProject
        /// </summary>
        private int SetMaxIdProject()
        {
            System.Data.DataSet objDataSet = objDataSet = new System.Data.DataSet();
            try
            {
                using (Conexao cn = new Conexao())
                {
                    objDataSet = cn.ExecSQL("SELECT MAX(IdProjeto) AS IDMAX FROM PRJPROJETO");
                }
                if (objDataSet.Tables != null && objDataSet.Tables[0].Rows.Count > 0)
                {
                    IdProjeto = Convert.ToInt32(objDataSet.Tables[0].Rows[0][0].ToString());
                    return Convert.ToInt32(objDataSet.Tables[0].Rows[0][0].ToString());
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

        #region [   Valida Exclusão do Projeto ]
        /// <summary>
        /// Método - Valida Exclusão do Projeto
        /// Data: 09/07/2013 | Autor: Fernanda Passos
        /// </summary>
        /// <param name="strMensagemValida">String com mensagem de retorno de como foi a operação no método</param>
        /// <returns>Retorna true ou false. Se foi ou não validado.</returns>
        private bool ValidacaoExclusao(out string strMensagemValida)
        {
            strMensagemValida = "";
            bool bolRetorno = true;
            try
            {

                //Verifica se foi informado um número do projeto
                if (intIdInternalProjeto <= 0)
                {
                    strMensagemValida =  "Selecione o projeto para excluir.";
                    bolRetorno = false;
                }


                return bolRetorno;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region [   VerificaSeExisteAndamentoDeTarefas    ]
        /// <summary>
        /// [   VerificaSeExisteAndamentoDeTarefas    ]
        /// </summary>
        /// <param name="intIdProjeto"></param>
        /// <returns></returns>
        public static bool VerificaSeExisteAndamentoDeTarefasDoProjeto(int intIdProjeto)
        {
            System.Data.DataSet objDataSet = new System.Data.DataSet();
            try
            {
                if (intIdProjeto > 0)
                {
                    string strSql = " SELECT COUNT(*) AS TOTAL_TAREFAS ";
                    strSql += " FROM PrjTarefaAndamento ";
                    strSql += " WHERE IdTarefa IN (SELECT IdTarefa FROM PrjTarefas WHERE IdProjeto = " + intIdProjeto + ") ";

                    using (Conexao cn = new Conexao())
                    {
                        objDataSet = cn.ExecSQL(strSql);
                    }

                    if (objDataSet != null && objDataSet.Tables.Count > 0 && objDataSet.Tables[0].Rows.Count > 0)
                    {
                        if (objDataSet.Tables[0].Rows[0]["TOTAL_TAREFAS"].ToString().Trim() != "" && Convert.ToInt32(objDataSet.Tables[0].Rows[0]["TOTAL_TAREFAS"].ToString().Trim()) > 0)
                        {
                            return true;
                        }
                        else return false;
                    }
                    else return false;
                }
                else return false;
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

        #region [   Retorna DataSet com dados do projeto   ]
        /// <summary>
        /// Método - Retorna DataSet com dados do projeto
        /// </summary>
        /// <returns>Retorna um DataSet com dados do projeto.</returns>
        public static System.Data.DataSet GetProject( int intIdProjeto = 0 )
        {
            System.Data.DataSet objDataSet = new System.Data.DataSet();
            try
            {
                string strSql = " SELECT * FROM vwPrjProjetoPesq WHERE 1=1";
                if (intIdProjeto > 0) strSql += " AND IdProjeto = " + intIdProjeto + "  ";

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

        #region [   Retorna DataSet com dados do projeto   ]
        /// <summary>
        /// Método - Retorna DataSet com dados do projeto
        /// </summary>
        /// <returns>Retorna um DataSet com dados do projeto.</returns>
        public static System.Data.DataSet GetProject(string strTitulo, string strNumProposta, int intIdCliente, int intIdSistema, int intIdStatus, string strDtPrevFimIni, string strDtPrevFimFim)
        {
            try
            {
                string strSql = " SELECT IdProjeto, Titulo, DescProjeto, NumPropostaComercial, DuracaoPrevista, DuracaoRalizada, DuracaoCorrente,  PrjProjeto.IdPessoa, PrjProjeto.IdStatus, PrjProjeto.IdEmpresa, PrjProjeto.IdSistema, IdImpacto, IdUrgencia, IdPrioridade, ";
                strSql += " (convert(nvarchar,DataInicioPrevisto, 103) +' '+ convert(nvarchar,DataInicioPrevisto, 108)) as DataInicioPrevisto,  ";
                strSql += " (convert(nvarchar,DataFimPrevisto, 103) +' '+ convert(nvarchar,DataFimPrevisto, 108)) as DataFimPrevisto, ";
                strSql += " (convert(nvarchar,DataInicioRealizado, 103) +' '+ convert(nvarchar,DataInicioRealizado, 108)) as DataInicioRealizado,  ";
                strSql += " (convert(nvarchar,DataFimRealizado, 103) +' '+ convert(nvarchar,DataFimRealizado, 108)) as DataFimRealizado, ";
                strSql += " SigeStatus.NomeStatus, SigeEmpresa.NomeFantazia, SigePessoa.NomePessoa , SigeSistema.NomeSistema , ";
                strSql += " (SELECT COUNT(*) FROM PrjTarefaAndamento WHERE IdTarefa IN (SELECT IdTarefa FROM PrjTarefas WHERE IdProjeto = PrjProjeto.IdProjeto)) PrjQtdAndamentoTarefa, ";
                strSql += " (CASE WHEN DataInicioPrevisto < GETDATE() AND DataInicioRealizado IS NULL THEN 'Sim' ELSE 'Não' END) as InicioAtrasado, ";
                strSql += " (CASE WHEN DataFimRealizado IS NOT NULL THEN 'Sim' ELSE 'Não' END) AS Concluido, ";
                strSql += " (CASE WHEN DataInicioPrevisto > GETDATE() THEN 'Sim' ELSE 'Não' END) as ProjetoFuturo, ";
                strSql += " (CASE WHEN DataInicioPrevisto >= DataInicioRealizado and DataFimPrevisto > GETDATE() AND DataFimRealizado IS NULL THEN	'Sim' ELSE 'Não' END) AS IniciadoENoPrazoPraConcluir, ";
                strSql += " (CASE WHEN DataFimPrevisto < GETDATE() AND DataFimRealizado IS NULL THEN 'Sim' ELSE 'Não' END) AS TerminoAtrasado ";
                strSql += " FROM PrjProjeto , SigeStatus,  SigeEmpresa, SigePessoa, SigeSistema  ";
                strSql += " WHERE  PrjProjeto.IdStatus = SigeStatus.IdStatus  ";
                strSql += " AND SigeEmpresa.IdEmpresa = PrjProjeto.IdEmpresa  ";
                strSql += " AND SigePessoa.IdPessoa =  PrjProjeto.IdPessoa  ";
                strSql += " AND SigeSistema.IdSistema = PrjProjeto.IdSistema  ";
                if(!string.IsNullOrEmpty(strTitulo)) strSql += " AND PrjProjeto.Titulo like '%"+ strTitulo +"%' ";
                if(!string.IsNullOrEmpty(strNumProposta)) strSql += " AND PrjProjeto.NumPropostaComercial = "+ strNumProposta +" ";
                if(intIdCliente > 0 ) strSql += " AND PrjProjeto.IdEmpresa = "+  intIdCliente +" ";
                if(intIdStatus > 0) strSql += " AND PrjProjeto.IdStatus = "+ intIdStatus +" ";
                if (intIdSistema > 0) strSql += " AND PrjProjeto.IdSistema = " + intIdSistema + " ";

                if (!string.IsNullOrEmpty(strDtPrevFimIni) && !string.IsNullOrEmpty(strDtPrevFimFim))
                {
                    strDtPrevFimIni = (string)Convert.ToDateTime(strDtPrevFimIni).ToString("yyyy-MM-dd HH:mm");
                    strDtPrevFimFim = (string)Convert.ToDateTime(strDtPrevFimFim).ToString("yyyy-MM-dd HH:mm");
                    strSql += " AND (PrjProjeto.DataFimPrevisto >= '" + strDtPrevFimIni + "' AND PrjProjeto.DataFimPrevisto <= '" + strDtPrevFimFim + "')";
                }

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

        #region [   Retorna DataSet com dados do projeto   ]
        /// <summary>
        /// Método - Retorna DataSet com dados do projeto
        /// </summary>
        /// <returns>Retorna um DataSet com dados do projeto.</returns>
        /// <param name="intIdStatusProjeto">Int com o código do status para trazer projetos por status</param>
        public static System.Data.DataSet GetProject()
        {
            System.Data.DataSet objDataSet = new System.Data.DataSet();
            try
            {
                string strSql = " SELECT IdProjeto, Titulo +' - Nº: '+ CONVERT(NVARCHAR, PrjProjeto.IdProjeto) ";
                strSql += " FROM PrjProjeto ";
                strSql += " order by DataInclusao desc";

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
