using System;
using Database;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.Projeto
{
    public class ClsPrjTarefas
    {
        #region [Prorpiedades]
        private static int intIdTarefa;

        #region [     IdTarefa     ]
        
        public int IdTarefa
        {
            get
            {
                return intIdTarefa;
            }
            set
            {
                intIdTarefa = value;
            }
        }
        #endregion

        #region [    NumTarefa     ]
        
        public string NumTarefa
        {
            get;
            set;
        }
        #endregion

        #region [    IdProjeto     ]
        
        public int IdProjeto
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

        #region [    TituloTarefa     ]
        
        public string TituloTarefa
        {
            get;
            set;
        }
        #endregion

        #region [    DescTarefa     ]
        
        public string DescTarefa
        {
            get;
            set;
        }
        #endregion

        #region [    IdCategoria     ]
        
        public int IdCategoria
        {
            get;
            set;
        }
        #endregion

        #region [    IdFase     ]
        
        public int IdFase
        {
            get;
            set;
        }
        #endregion

        #region [    IdComplexidade     ]
        
        public int IdComplexidade
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

        #region [    DataInicioRealizada     ]
        
        public string DataInicioRealizada
        {
            get;
            set;
        }
        #endregion

        #region [    DataFimRealizada     ]
        
        public string DataFimRealizada
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

        #region [    DuracaoRealizada     ]
        
        public string DuracaoRealizada
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

        #region [    IdImpacto     ]
        
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

        #region "MÉTODO - EXCLUIR REGISTRO
        /// <summary>
        /// OBJETIVO DO MÉTODO: MÉTODO QUE TEM POR OBJETIVO EXCLUIR REGISTR POR PARAMENTRO DO CÓDIGO IDENTIFICADOR PrjTarefas
        /// DATA\HORA CRIAÇÃO :06/08/2013 10:51:14
        /// COMPUTADOR GERADOR:DEVELOPMENT04
        /// </summary>
        /// <returns>RETORNA TRUE OU FALSE. SE FOI EXCLUÍDO OU NÃO.</returns>
        /// <param name="strMsgRetorno">Variável string com uma mensagem de retorno da operação no método.</param>
        /// <param name="strCodigoRegistro">Código identificador do registro á ser excluído.</param>
        public static bool Excluir(out string strMsgRetorno, string strCodigoRegistro)
        {
            strMsgRetorno = "";

            try
            {
                using (Conexao cn = new Conexao())
                {
                    cn.AddParametros("IdTarefa", intIdTarefa.ToString().Trim());
                    cn.CriarPedido("STP_PrjTarefas_Exc", false);

                    string valor = cn.GetValor("RESPOSTA", 0, 0);

                    switch (valor)
                    {
                        case "1":
                            strMsgRetorno = "Registro excluído com sucesso.";
                            break;
                        case "2":
                            strMsgRetorno = "Não foi possível excluir o registro.";
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
                strMsgRetorno = ex.Message;
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
                if (IdTarefa <= 0)
                {
                    strMensagem = "Informe a tarefa.";
                    return false;
                }

                try
                {
                    //Remove todos os andamentos da tarefa
                    string strSql = "DELETE PrjTarefaAndamento	where IdTarefa = "+ IdTarefa +"";
                    using (Conexao cn = new Conexao())
                    {
                         cn.ExecSQL(strSql.ToString());

                        //Remove todos os arquivos da tarefa
                        strSql = " DELETE SigeArquivo where  IdArquivo in (select IdArquivo from SigeArquivoVinculo where IdRegistroTabela = " + IdTarefa + " and NomeTabela = 'PrjTarefas') ";
                        cn.ExecSQL(strSql.ToString());

                        //Remove a tarefa
                        strSql = " DELETE PrjTarefas WHERE IdTarefa = " + IdTarefa + "";
                        cn.ExecSQL(strSql.ToString());

                        strMensagem = "Registro excluído com sucesso.";
                        IdTarefa = 0;
                        boleRetorno = true;
                    }
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

        #region [   Método - Retorna as tarefas ]
        /// <summary>
        /// Método - Retorna as tarefas
        /// </summary>
        /// <returns>Retorna um DataSet com as tarefas</returns>
        public static System.Data.DataSet GetTarefas(int intIdProjeto, string strNumTarefa, string strDescTarefa, int intIdFase, int intIdPessoa, string strAtribuicao)
        {
            System.Data.DataSet objDataSet = new System.Data.DataSet();
            try
            {

                string strSql = "  SELECT IdTarefa,   IdProjeto,   TituloTarefa,   NumTarefa, ";
                strSql += " (select NomePessoa from SigePessoa where IdPessoa =  PrjTarefas.IdPessoa) as NomePessoa,   ";
                strSql += " (select NomeFase from PrjFase where IdFase = PrjTarefas.IdFase) as NomeFase,";
                strSql += "(CONVERT(NVARCHAR, PrjTarefas.DataInicioPrevisto, 103) +' '+ CONVERT(NVARCHAR, PrjTarefas.DataInicioPrevisto, 108)) AS DataInicioPrevisto,   (CONVERT(NVARCHAR,PrjTarefas.DataFimPrevisto, 103)+' '+CONVERT(NVARCHAR,PrjTarefas.DataFimPrevisto, 108)) AS DataFimPrevisto,   (CONVERT(NVARCHAR, PrjTarefas.DataFimRealizada, 103) +' '+ CONVERT(NVARCHAR, PrjTarefas.DataFimRealizada, 108)) AS DataFimRealizada ";
                strSql += " FROM PrjTarefas";
                strSql += " WHERE 1=1 ";

                if (intIdProjeto > 0) strSql += " AND IdProjeto = " + intIdProjeto + " ";
                if (!string.IsNullOrEmpty(strNumTarefa)) strSql += " AND PrjTarefas.NumTarefa = '" + strNumTarefa + "'";
                if (!string.IsNullOrEmpty(strDescTarefa)) strSql += " AND PrjTarefas.TituloTarefa LIKE '%" + strDescTarefa + "%' ";
                if (intIdFase > 0) strSql += " AND PrjTarefas.IdFase = " + intIdFase + "";
                if (intIdPessoa > 0) strSql += " AND PrjTarefas.IdPessoa = " + intIdPessoa + "";

                if (!string.IsNullOrEmpty(strAtribuicao) && strAtribuicao.ToLower() == "atribuida".ToLower())
                    strSql += " AND PrjTarefas.IdPessoa IS NOT NULL ";
                else
                    if (!string.IsNullOrEmpty(strAtribuicao) && strAtribuicao.ToLower() == "naoatribuida".ToLower()) strSql += " AND PrjTarefas.IdPessoa IS NULL ";

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

       

        #region [   Método - Retorna as tarefas ]
        /// <summary>
        /// Método - Retorna as tarefas
        /// </summary>
        /// <returns>Retorna um DataSet com as tarefas</returns>
        /// <param name="intIdTarefa">Número inteiro com o código da tarefa</param>
        public static System.Data.DataSet GetTarefas(int intIdTarefa)
        {
            System.Data.DataSet objDataSet = new System.Data.DataSet();
            try
            {
                if (intIdTarefa <= 0) return null;

                string strSql = " SELECT * FROM  vwPrjTarefaPesq1";

                if (intIdTarefa > 0) strSql += " WHERE IdTarefa = " + intIdTarefa + " ";

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

        #region [   Método - Retorna as tarefas ]
        /// <summary>
        /// Método - Retorna as tarefas
        /// </summary>
        /// <returns>Retorna um DataSet com as tarefas</returns>
        /// <param name="intIdTarefa">Número inteiro com o código da tarefa</param>
        /// <param name="intIdCategoria">int Código da categoria</param>
        /// <param name="intIdFase">int Código da fase</param>
        /// <param name="intIdPessoa">int Código da pessoa</param>
        /// <param name="strDataFimPrevista">string Data término previsto</param>
        /// <param name="strDAtaFimReal">string Data de término realizada</param>
        /// <param name="strDataInicioPrevista">string Data de início prevista</param>
        /// <param name="strDataInicioReal">string Data de início real</param>
        /// <param name="strNumTarefa">string Número da tarefa</param>
        /// <param name="strTituloTarefa">string Título da tarefa</param>
        public static System.Data.DataSet GetTarefas(string strNumTarefa, int intIdFase, string strTituloTarefa, int intIdPessoa, int intIdCategoria, string strIdUsuario = "")
        {
            System.Data.DataSet objDataSet = new System.Data.DataSet();
            try
            {
                string strSql = " SELECT IdTarefa, IdProjeto, IdPessoa, NumTarefa, TituloTarefa, PrjPrioridade.NomePrioridade,";
                strSql += " (SELECT NomeFase FROM PrjFase WHERE IdFase  = PrjTarefas.IdFase) AS NomeFase, ";
                strSql += " (SELECT Titulo FROM PrjProjeto WHERE IdProjeto = PrjTarefas.IdProjeto)  as TituloProjeto,  ";
                strSql += " (SELECT NomeCategoria FROM PrjCategoria WHERE IdCategoria = PrjTarefas.IdCategoria) as Categoria,  ";
                strSql += " IdCategoria,  ";
                strSql += " (SELECT NomePessoa FROM SigePessoa WHERE IdPessoa = PrjTarefas.IdPessoa) as NomePessoa ,  ";
                strSql += " (convert(nvarchar,DataInicioPrevisto, 103) +' '+ convert(nvarchar,DataInicioPrevisto, 108)) as DataInicioPrevisto,  ";
                strSql += " (convert(nvarchar,DataFimPrevisto, 103) +' '+ convert(nvarchar,DataFimPrevisto, 108)) as DataFimPrevisto,  ";
                strSql += " (convert(nvarchar, DataInicioRealizada , 103) +' '+ convert(nvarchar,DataInicioRealizada , 108)) as DataInicioRealizada ,  ";
                strSql += " (convert(nvarchar,DataFimRealizada, 103) +' '+ convert(nvarchar,DataFimRealizada, 108)) as DataFimRealizada, ";
                strSql += " (CASE WHEN DataInicioPrevisto < GETDATE() AND DataInicioRealizada IS NULL THEN 'Sim' ELSE 'Não' END) as InicioAtrasado,  ";
                strSql += " (CASE WHEN DataFimRealizada IS NOT NULL THEN 'Sim' ELSE 'Não' END) AS Concluido, ";
                strSql += " (CASE WHEN DataInicioPrevisto > GETDATE() THEN 'Sim' ELSE 'Não' END) as TarefaFutura, ";
                strSql += " (CASE WHEN DataInicioPrevisto >= DataInicioRealizada and DataFimPrevisto > GETDATE() AND DataFimRealizada IS NULL THEN	'Sim' ELSE 'Não' END) AS IniciadoENoPrazoPraConcluir, ";
                strSql += " (CASE WHEN DataFimPrevisto < GETDATE() AND DataFimRealizada IS NULL THEN 'Sim' ELSE 'Não' END) AS TerminoAtrasado ";
                strSql += " FROM PrjTarefas, PrjPrioridade ";
                strSql += " WHERE PrjTarefas.IdPrioridade = PrjPrioridade.IdPrioridade  AND IDFASE <> 6 ";
                strSql += " AND ( PrjTarefas.IdFase = 1  OR PrjTarefas.IdPessoa = " + strIdUsuario + " OR PrjTarefas.IdPessoa IS NULL) ";

                if (!string.IsNullOrEmpty(strNumTarefa)) strSql += " AND NumTarefa = " + strNumTarefa + " ";
                if (intIdFase > 0) strSql += " AND PrjTarefas.IdFase = " + intIdFase + " ";
                if (!string.IsNullOrEmpty(strTituloTarefa)) strSql += " AND TituloTarefa LIKE '%" + strTituloTarefa.Trim() + "%' ";
                if (intIdPessoa > 0) strSql += " AND IdPessoa = " + intIdPessoa + " ";
                if (intIdCategoria > 0) strSql += " AND IdCategoria = " + intIdCategoria + "";

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

        #region [   Valida Tarefa ]
        /// <summary>
        /// Método - Valida Tarefa
        /// Data: 15/07/2013 | Autor: Fernanda Passos
        /// </summary>
        /// <param name="strMensagemValida">String com mensagem de retorno de como foi a operação no método</param>
        /// <returns>Retorna true ou false. Se foi ou não validado.</returns>
        private bool Validacao(out string strMensagemValida)
        {
            strMensagemValida = "";
            bool bolRetorno = true;
            try
            {
                if (string.IsNullOrEmpty(NumTarefa))
                {
                    strMensagemValida += " Informe o número da tarefa.";
                    bolRetorno = false;
                }

                if (string.IsNullOrEmpty(TituloTarefa))
                {
                    strMensagemValida += "Informe o título.";
                    bolRetorno = false;
                }

                if (string.IsNullOrEmpty(DescTarefa))
                {
                    strMensagemValida += "Informe a descrição";
                    bolRetorno = false;
                }

                if (IdFase <= 0 )
                {
                    strMensagemValida  += "Informe a fase. ";
                    bolRetorno = false;
                }

                if (DataInicioPrevisto == null)
                {
                    strMensagemValida += "Informa a data início prevista.";
                    bolRetorno = false;
                }

                if (DataFimPrevisto == null)
                {
                    strMensagemValida += "Informe a data de término prevista.";
                    bolRetorno = false;
                }

                //if((DataInicioPrevisto != null && DataFimPrevisto != null) && (DataFimPrevisto < DataInicioPrevisto))
                //{
                //    strMensagemValida += "Data de término menor que data de início previsto.";
                //    bolRetorno = false;
                //}

                if (IdPrioridade <= 0)
                {
                    strMensagemValida += "Informe a prioridade.";
                    bolRetorno = false;
                }

                //Se a tarefa estiver com algum executar a fase deve ser preenchida e não pode ser a selecionada.
                if(IdPessoa > 0 && IdFase <= 0)
                {
                    strMensagemValida += "Tarefas que tem uma pessoa alocada  precisa ter uma fase definida.";
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

        #region [   Método - Salvar Tarefa ]
        /// <summary>
        /// Método - Salvar Tarefa
        /// Data da criação: 15/07/2013 | Autora: Fernanda Passos
        /// </summary>
        /// <param name="strMensagem">String com mensagem de retorno da operação</param>
        /// <returns>Retorna true ou false. Se foi salvou o não</returns>
        public bool Salvar(out string strMensagem, out int intIdTarefaDoMetodo, out string strNumProxTarefa)
        {
            strMensagem = "";
            strNumProxTarefa = "";
            bool bolRetorno = true;
            intIdTarefaDoMetodo = 0;

            try
            {
                //Valida das informações do projeto.
                if (!Validacao(out strMensagem)) return false;

                //Define as durações da tarefa
                //DefineDuracaoes();

                using (Conexao cn = new Conexao())
                {
                    cn.AddParametros("IdTarefa", (intIdTarefa != null && intIdTarefa.ToString() != "" ? intIdTarefa.ToString() : "0"));	
                    cn.AddParametros("NumTarefa", NumTarefa.ToString());	
                    cn.AddParametros("IdProjeto", (IdProjeto <= 0 ? "" : IdProjeto.ToString()));	
                    cn.AddParametros("IdPessoa", (IdPessoa <= 0 ? "" : IdPessoa.ToString()));	
                    cn.AddParametros("TituloTarefa", TituloTarefa.ToString());
                    cn.AddParametros("DescTarefa", DescTarefa.ToString());
                    cn.AddParametros("IdCategoria", (IdCategoria <= 0 ? "" : IdCategoria.ToString()));
                    cn.AddParametros("IdFase", (IdFase <= 0 ? "" : IdFase.ToString()));
                    cn.AddParametros("IdComplexidade", (IdComplexidade <= 0 ? "" : IdComplexidade.ToString()));

                    cn.AddParametros("DataInicioPrevisto", (DataInicioPrevisto == null || DataInicioPrevisto.ToString().Trim() == "01/01/0001 00:00:00" || DataInicioPrevisto.ToString().Trim() == "" ? "" : DataInicioPrevisto));
                    cn.AddParametros("DataFimPrevisto", (DataFimPrevisto == null || DataFimPrevisto.ToString().Trim() == "01/01/0001 00:00:00" || DataFimPrevisto.ToString().Trim() == "" ? "" : DataFimPrevisto));
                    cn.AddParametros("DataInicioRealizada", (DataInicioRealizada == null || DataInicioRealizada.ToString().Trim() == "01/01/0001 00:00:00" || DataInicioRealizada.ToString().Trim() == "" ? "" : DataInicioRealizada));
                    cn.AddParametros("DataFimRealizada", (DataFimRealizada == null || DataFimRealizada.ToString().Trim() == "01/01/0001 00:00:00" || DataFimRealizada.ToString().Trim() == "" ? "" : DataFimRealizada));


                    ////////cn.AddParametros("DataInicioPrevisto", (DataInicioPrevisto.ToString().Trim() == "01/01/0001 00:00:00" || DataFimRealizada.ToString().Trim() == "" ? "" : DataInicioPrevisto.ToString("yyyy-MM-dd HH:MM").Trim()));
                    ////////cn.AddParametros("DataFimPrevisto", (DataFimPrevisto.ToString().Trim() == "01/01/0001 00:00:00" || DataFimRealizada.ToString().Trim()  == ""? "" : DataFimPrevisto.ToString("yyyy-MM-dd HH:MM").Trim()));
                    ////////cn.AddParametros("DataInicioRealizada", (DataInicioRealizada.ToString().Trim() == "01/01/0001 00:00:00" || DataFimRealizada.ToString().Trim() == "" ? "" : DataInicioRealizada.ToString("yyyy-MM-dd HH:MM").Trim()));
                    ////////cn.AddParametros("DataFimRealizada", (DataFimRealizada.ToString().Trim() == "01/01/0001 00:00:00" || DataFimRealizada.ToString().Trim() == "" ? "" : DataFimRealizada.ToString("yyyy-MM-dd HH:MM").Trim()));

                    cn.AddParametros("DuracaoPrevista", (DuracaoPrevista.ToString().Trim().Replace(":", "") == "" ? "" : DuracaoPrevista));
                    cn.AddParametros("DuracaoRealizada", (DuracaoRealizada.ToString().Trim().Replace(":", "") == "" ? "" : DuracaoRealizada));
                    cn.AddParametros("DuracaoCorrente", (DuracaoCorrente.ToString().Trim().Replace(":", "") == "" ? "" : DuracaoCorrente));
                  
                    cn.AddParametros("IdImpacto", (IdImpacto <= 0 ? "" :IdImpacto.ToString()));
                    cn.AddParametros("IdUrgencia", (IdUrgencia <= 0 ? "": IdUrgencia.ToString()));
                    cn.AddParametros("IdPrioridade", (IdPrioridade <= 0 ? "" :IdPrioridade.ToString()));

                    cn.AddParametros("IdUltimoUsuario", (IdUltimoUsuario != null && IdUltimoUsuario.ToString().Trim() != "0" && IdUltimoUsuario.ToString().Trim() != "" ? IdUltimoUsuario.ToString() :""));
                    cn.AddParametros("IdInclusorUsuario", (IdInclusorUsuario != null && IdInclusorUsuario.ToString().Trim() != "0" && IdInclusorUsuario.ToString().Trim() != "" ? IdInclusorUsuario.ToString() :""));


                    cn.CriarPedido("STP_PrjTarefas_IncAlt", false);

                    string valor = cn.GetValor("RESPOSTA", 0, 0);
                    


                    switch (valor)
                    {
                        case "I":
                            strMensagem = "Registro incluído com sucesso.";
                            SetMaxIdTarefa();
                            
                            //Pega o ID da tarefa que foi gerada
                            string strIntIdTarefa = cn.GetValor("ID_TAREFA", 0, 0);
                            if (!string.IsNullOrEmpty(strIntIdTarefa.Trim()))
                            {
                                intIdTarefa = Convert.ToInt32(strIntIdTarefa.Trim());
                                intIdTarefaDoMetodo = Convert.ToInt32(strIntIdTarefa.Trim());
                            }
                            bolRetorno = true;
                            break;
                        case "A":
                            strMensagem = "Registro alterado com sucesso.";
                            intIdTarefa = IdTarefa;
                            bolRetorno = true;
                            break;
                        default:
                            strMensagem = "Não foi possível incluir ou alterar o registro.";
                            bolRetorno = false;
                            break;
                    }
                }
                return bolRetorno;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

      #region [   SetMaxIdTarefa     ]
        /// <summary>
        /// Método - SetMaxIdTarefa
        /// </summary>
        private int SetMaxIdTarefa()
        {
            System.Data.DataSet objDataSet = objDataSet = new System.Data.DataSet();
            try
            {
                using (Conexao cn = new Conexao())
                {
                    objDataSet = cn.ExecSQL("SELECT MAX(IdTarefa) AS IDMAX FROM PrjTarefas");
                }
                if (objDataSet.Tables != null && objDataSet.Tables[0].Rows.Count > 0)
                {
                    IdTarefa = Convert.ToInt32(objDataSet.Tables[0].Rows[0][0].ToString());
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

        #region [   Get Next Number Task     ]
        /// <summary>
        /// [ GetNextNumberTask ]
        /// </summary>
        public static int GetNextNumberTask()
        {
            System.Data.DataSet objDataSet = new System.Data.DataSet();
            try
            {
                string strSql = " SELECT";
                strSql += " ( ";
                strSql += " CASE WHEN (max(NumTarefa)+1)  IS NULL THEN ";
                strSql += " 1 ";
                strSql += " ELSE ";
                strSql += "     (max(NumTarefa)+1) ";
                strSql += " END";
                strSql += " ) AS NumTarefa_Next ";
                strSql += " FROM PrjTarefas";

                using (Conexao cn = new Conexao())
                {
                    objDataSet = cn.ExecSQL(strSql);
                }
                if (objDataSet.Tables.Count > 0 && objDataSet.Tables[0].Rows.Count > 0)
                {
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

        #region [   GetDuracaoReal    ]
        /// <summary>
        /// [   GetDuracaoReal    ]
        /// </summary>
        /// <param name="intIdTarefa">int Código da tarefa</param>
        /// <returns>Retorna uma string com duração em dias</returns>
        private string GetDuracaoReal(int intIdTarefa)
        {
            System.Data.DataSet objDataSet = new System.Data.DataSet();
            try
            {
                if (intIdTarefa > 0)
                {
                    string strTemp = " SELECT (DATEDIFF(DAY, DataInicioRealizada, DataFimRealizada)) AS TOT_DIA  ";
                    strTemp += " FROM PrjTarefas ";
                    strTemp += " where 1=1 ";
                    strTemp += "  AND DataInicioRealizada is not null  ";
                    strTemp += " and DataFimRealizada is not null  ";
                    strTemp += " and IdTarefa = " + intIdTarefa + " ";

                    using (Conexao cn = new Conexao())
                    {
                        objDataSet = cn.ExecSQL(strTemp);
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

        #region [   GetDatasHoraInicioEFimReal    ]
        /// <summary>
        /// [   GetDataUltimaTarefaConcluida    ]
        /// </summary>
        /// <param name="intIdProjeto">Código da tarefa</param>
        /// <returns>Retorna uma string com a data ou vazio.</returns>
        /// <param name="strTipoData">Os tipos de dado podem ser: InicioReal ou FimReal</param>
        private string GetDatasHoraInicioEFimReal(int intIdTarefa, string strTipoData)
        {
            System.Data.DataSet objDataSet = new System.Data.DataSet();
            try
            {
                if (intIdTarefa > 0)
                {
                    string strSql = "";
                    if (strTipoData.Trim().ToLower().Contains("FimReal".ToLower()))
                    {   //Tarefas	Data Fim Real	[Data/Hora Fim do último andamento da última tarefa]	Cálcula-se somente se a fase estiver como concluída.
                        strSql = " SELECT TOP 1 CONVERT(NVARCHAR, DataHoraFim, 103)+' '+ CONVERT(NVARCHAR, DataHoraFim, 108)";
                        strSql += "  FROM PrjTarefaAndamento";
                        strSql += "  WHERE IdTarefa  = " + intIdTarefa + " ";
                        strSql += "  ORDER BY DataHoraFim DESC ";
                    }
                    else if (strTipoData.Trim().ToLower().Contains("InicioReal".ToLower()))
                    {   //Tarefas	Data Início Real	[Data/Hora Início - Primeiro registro de andamento entre as tarefas]	Cálcula-se somente se houver andamento.
                        strSql = " SELECT TOP 1 CONVERT(NVARCHAR, datahorainicio, 103)+' '+ CONVERT(NVARCHAR, datahorainicio, 108)  ";
                        strSql += "  FROM PrjTarefaAndamento";
                        strSql += "  WHERE IdTarefa  = " + intIdTarefa + " ";
                        strSql += "  ORDER BY DataHoraFim ASC ";
                    }
                    else return "";

                    objDataSet = new System.Data.DataSet();
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

        #region [   DefineDuracaoes ]
        /// <summary>
        /// [   DefineDuracaoes ]
        /// </summary>
        private void DefineDuracaoes()
        {
            try
            {
                ////Duração Prevista (Em dias)
                //if ((DataInicioPrevisto != null && DataInicioPrevisto.ToString().Trim() != "" && DataInicioPrevisto.ToString().Trim() != "01/01/0001 00:00:00") && (DataFimPrevisto != null && DataFimPrevisto.ToString().Trim() != "" && DataFimPrevisto.ToString().Trim() != "01/01/0001 00:00:00"))
                //{
                //    try
                //    {
                //        DuracaoPrevista = (DataFimPrevisto - DataInicioPrevisto).TotalDays.ToString().Substring(0, 4);
                //    }
                //    catch { }
                //}

                ////Tarefas	Data Início Real	[Data/Hora Início - Primeiro registro de andamento entre as tarefas]	Cálcula-se somente se houver andamento.
                //if (DataFimRealizada == null || DataFimRealizada.ToString().Trim() == "" || DataFimRealizada.ToString().Trim() == "01/01/0001 00:00:00")
                //{
                //    try
                //    {
                //        string strDataFimRealizado = GetDatasHoraInicioEFimReal(IdProjeto, "InicioReal");
                //        if (!string.IsNullOrEmpty(strDataFimRealizado)) DataFimRealizada = Convert.ToDateTime(strDataFimRealizado);
                //    }
                //    catch { }
                //}

                ////Tarefas	Data Fim Real	[Data/Hora Fim do último andamento da última tarefa]	Cálcula-se somente se a fase estiver como concluída.
                //if (IdFase == 6 && (DataFimRealizada == null || DataFimRealizada.ToString().Trim() == "" || DataFimRealizada.ToString().Trim() == "01/01/0001 00:00:00"))
                //{
                //    try
                //    {
                //        string strDataFimRealizado = GetDatasHoraInicioEFimReal(IdProjeto, "FimReal");
                //        if (!string.IsNullOrEmpty(strDataFimRealizado)) DataFimRealizada = Convert.ToDateTime(strDataFimRealizado);
                //    }
                //    catch { }
                //}

                ////Tarefas	Duração Corrente	"=Soma[DuracaoDeTodosAndamentoDeTodasTarefasDoProjeto]"	
                //if (DuracaoCorrente == null || DuracaoCorrente.Trim() == "")
                //{
                //    try
                //    {
                //        DuracaoCorrente = GetDuracaoReal(IdTarefa).Substring(0, 4);
                //    }
                //    catch { }
                //}
                     
                ////Tarefas	Duração Real	"=Soma[DuracaoDeTodosAndamentoDaTarefa]"	Cálcula-se somente se a fase estiver como concluída.
                //if (DuracaoRealizada == null || DuracaoRealizada.Trim() == "")
                //{
                //    try
                //    {
                //        DuracaoRealizada = GetDuracaoReal(IdTarefa).Substring(0, 4);
                //    }
                //    catch { }
                //}   

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #endregion


    }
}



