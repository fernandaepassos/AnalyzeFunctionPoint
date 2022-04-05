using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Database;

namespace Framework.Vistoria
{
    public class ClsVistOrdemServico
    {

        #region [   Propriedades       ]

        private static string strIdOrdemServico;
        private static string strIdEmpresa;
        private static string strIdPessoaDigitador;
        private static string strIdPessoaVistoriador;
        private static string strDescPessoaCondutor;
        private static string strDescPessoaProprietario;
        private static string strIdStatusResultado;
        private static string strFlagConcluido;
        private static string strNumPlaca;
        private static string strIdStatus;
        private static string strDataInclusao;
        private static string strDataAlteracao;
        private static string strIdUsuarioInclusao;
        private static string strIdUsuarioAlteracao;
        private static string strIdEmpresaCliente;

        #region [     FlagConcluido     ]
        public string FlagConcluido
        {
            get
            {
                return strFlagConcluido;
            }
            set
            {
                strFlagConcluido = value;
            }
        }
        #endregion

        #region [     IdStatusResultado     ]
        public string IdStatusResultado
        {
            get
            {
                return strIdStatusResultado;
            }
            set
            {
                strIdStatusResultado = value;
            }
        }
        #endregion

        #region [     IdOrdemServico     ]
        public string IdOrdemServico
        {
            get
            {
                return strIdOrdemServico;
            }
            set
            {
                strIdOrdemServico = value;
            }
        }
        #endregion

        #region [     IdEmpresa     ]
        public string IdEmpresa
        {
            get
            {
                return strIdEmpresa;
            }
            set
            {
                strIdEmpresa = value;
            }
        }
        #endregion

        #region [     IdPessoaDigitador     ]
        public string IdPessoaDigitador
        {
            get
            {
                return strIdPessoaDigitador;
            }
            set
            {
                strIdPessoaDigitador = value;
            }
        }
        #endregion

        #region [     IdPessoaVistoriador     ]
        public string IdPessoaVistoriador
        {
            get
            {
                return strIdPessoaVistoriador;
            }
            set
            {
                strIdPessoaVistoriador = value;
            }
        }
        #endregion

        #region [     DescPessoaCondutor     ]
        public string DescPessoaCondutor
        {
            get
            {
                return strDescPessoaCondutor;
            }
            set
            {
                strDescPessoaCondutor = value;
            }
        }
        #endregion

        #region [     DescPessoaProprietario     ]
        public string DescPessoaProprietario
        {
            get
            {
                return strDescPessoaProprietario;
            }
            set
            {
                strDescPessoaProprietario = value;
            }
        }
        #endregion

        #region [     NumPlaca     ]
        public string NumPlaca
        {
            get
            {
                return strNumPlaca;
            }
            set
            {
                strNumPlaca = value;
            }
        }
        #endregion

        #region [     IdStatus     ]
        public string IdStatus
        {
            get
            {
                return strIdStatus;
            }
            set
            {
                strIdStatus = value;
            }
        }
        #endregion

        #region [     DataInclusao     ]
        public string DataInclusao
        {
            get
            {
                return strDataInclusao;
            }
            set
            {
                strDataInclusao = value;
            }
        }
        #endregion

        #region [     DataAlteracao     ]
        public string DataAlteracao
        {
            get
            {
                return strDataAlteracao;
            }
            set
            {
                strDataAlteracao = value;
            }
        }
        #endregion

        #region [     IdUsuarioInclusao     ]
        public string IdUsuarioInclusao
        {
            get
            {
                return strIdUsuarioInclusao;
            }
            set
            {
                strIdUsuarioInclusao = value;
            }
        }
        #endregion

        #region [     IdUsuarioAlteracao     ]
        public string IdUsuarioAlteracao
        {
            get
            {
                return strIdUsuarioAlteracao;
            }
            set
            {
                strIdUsuarioAlteracao = value;
            }
        }
        #endregion  

        #region [     IdEmpresaCliente     ]
        public string IdEmpresaCliente
        {
            get
            {
                return strIdEmpresaCliente;
            }
            set
            {
                strIdEmpresaCliente = value;
            }
        }
        #endregion  

        #endregion

        #region     [   Métodos     ]

        #region [   GetOrdemServico ]
        /// <summary>
        /// [   GetOrdemServico ]
        /// </summary>
        /// <param name="intIdOrdemServico">int Número da OS</param>
        /// <param name="intIdPessoaVistoriador">int idPessoaVistoriador</param>
        /// <param name="intIdStatus">int IdStatus</param>
        /// <param name="strDataCadastro">Datetime rDataCadastro</param>
        /// <param name="intIdPessoaProprietario">int IdPessoaProprietario </param>
        /// <param name="intIdPessoaCondutor">int IdPessoaCondutor</param>
        /// <param name="strNumPlaca">string NumPlaca</param>
        /// <returns>Retorna um dataset</returns>
        public static System.Data.DataSet GetOrdemServico(int intIdOrdemServico, int intIdPessoaVistoriador, int intIdStatus,  string strDataCadastro, string strPessoaProprietario, string strPessoaCondutor, string strNumPlaca)
        {
            System.Data.DataSet objDataSet = new System.Data.DataSet();
            try
            {
                string strSql = " SELECT IdPessoaDigitador, IdOrdemServico, NumPlaca, CONVERT(NVARCHAR, DataInclusao, 103)+' '+ CONVERT(NVARCHAR, DataInclusao, 108) AS DataInclusao1,";
                strSql += " (SELECT NomePessoa FROM SigePessoa WHERE IdPessoa = VistOrdemServico.IdPessoaVistoriador) NomePessoaVistoriador, IdPessoaVistoriador, ";
                strSql += " DescPessoaCondutor NomePessoaCondutor, ";
                strSql += " DescPessoaProprietario NomePessoaProprietario, ";
                strSql += " (SELECT NomeStatus FROM SigeStatus WHERE IdStatus = VistOrdemServico.IdStatus) Status , VistOrdemServico.IdStatus, ";
                strSql += " (SELECT NomePessoa FROM SigePessoa WHERE IdPessoa = (select IdPessoa from SigeUsuario where IdUsuario = VistOrdemServico.IdUsuarioInclusao)) Inclusor, ";
                strSql += " FlagConcluido, CASE WHEN IdStatusResultado IS NULL THEN 0 ELSE IdStatusResultado END IdStatusResultado , ";
                strSql += " (SELECT IdVeiculo FROM VistVeiculo WHERE IdOrdemServico = VistOrdemServico.IdOrdemServico) QTD_VEIC_PRA_OS ,";
                strSql += " DataInclusao ";
                strSql += " FROM VistOrdemServico ";
                strSql += " WHERE 1=1 ";
                if(intIdOrdemServico > 0) strSql += " AND IdOrdemServico = "+ intIdOrdemServico +"";
                if (intIdPessoaVistoriador > 0) strSql += " AND IdPessoaVistoriador = " + intIdPessoaVistoriador  + " ";
                if (intIdStatus > 0) strSql += " AND IdStatus = " + intIdStatus + " ";
                if (!string.IsNullOrEmpty(strDataCadastro.Trim())) strSql += " and convert(varchar,DataInclusao, 103)  = '"+ strDataCadastro +"' ";
                if (strPessoaProprietario.Trim() != "") strSql += " AND DescPessoaProprietario like '%" + strPessoaProprietario + "%' ";
                if (strPessoaCondutor.Trim() != "") strSql += " AND DescPessoaCondutor like '%" + strPessoaCondutor + "%' ";
                if (!string.IsNullOrEmpty(strNumPlaca.Trim())) strSql += " AND NumPlaca like '%"+ strNumPlaca.Trim() +"%'    ";

                strSql += "  ORDER BY IdOrdemServico DESC";

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

        #region [   GetOrdemServico ]
        /// <summary>
        /// [   GetOrdemServico ]
        /// </summary>
        /// <param name="intIdOrdemServico">int Número da OS</param>
        /// <param name="intIdPessoaVistoriador">int idPessoaVistoriador</param>
        /// <param name="intIdStatus">int IdStatus</param>
        /// <param name="strDataCadastro">Datetime rDataCadastro</param>
        /// <param name="intIdPessoaProprietario">int IdPessoaProprietario </param>
        /// <param name="intIdPessoaCondutor">int IdPessoaCondutor</param>
        /// <param name="strNumPlaca">string NumPlaca</param>
        /// <returns>Retorna um dataset</returns>
        public static System.Data.DataSet GetOrdemServico()
        {
            System.Data.DataSet objDataSet = new System.Data.DataSet();
            try
            {
                string strSql = " SELECT IdPessoaDigitador, IdOrdemServico, NumPlaca, CONVERT(NVARCHAR, DataInclusao, 103)+' '+ CONVERT(NVARCHAR, DataInclusao, 108) AS DataInclusao1,";
                strSql += " (SELECT NomePessoa FROM SigePessoa WHERE IdPessoa = VistOrdemServico.IdPessoaVistoriador) NomePessoaVistoriador, IdPessoaVistoriador, ";
                strSql += " DescPessoaCondutor NomePessoaCondutor, ";
                strSql += " DescPessoaProprietario NomePessoaProprietario, ";
                strSql += " (SELECT NomeStatus FROM SigeStatus WHERE IdStatus = VistOrdemServico.IdStatus) Status , VistOrdemServico.IdStatus, ";
                strSql += " (SELECT NomePessoa FROM SigePessoa WHERE IdPessoa = (select IdPessoa from SigeUsuario where IdUsuario = VistOrdemServico.IdUsuarioInclusao)) Inclusor, ";
                strSql += " FlagConcluido, CASE WHEN IdStatusResultado IS NULL THEN 0 ELSE IdStatusResultado END IdStatusResultado , ";
                strSql += " (SELECT IdVeiculo FROM VistVeiculo WHERE IdOrdemServico = VistOrdemServico.IdOrdemServico) QTD_VEIC_PRA_OS ,";
                strSql += " DataInclusao ";
                strSql += " FROM VistOrdemServico ";
                strSql += "  ORDER BY IdOrdemServico DESC";

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

        #region [   GetOrdemServico ]
        /// <summary>
        /// [   GetOrdemServico ]
        /// </summary>
        /// <param name="strIdEmpresa">Código da empresa</param>
        /// <returns>Retorna um dataset</returns>
        public static System.Data.DataSet GetOrdemServico(string strIdEmpresa)
        {
            System.Data.DataSet objDataSet = new System.Data.DataSet();
            try
            {
                string strSql = @" SELECT IdPessoaDigitador, IdOrdemServico, NumPlaca, CONVERT(NVARCHAR, DataInclusao, 103)+' '+ CONVERT(NVARCHAR, DataInclusao, 108) AS DataInclusao1,
                (SELECT NomePessoa FROM SigePessoa WHERE IdPessoa = VistOrdemServico.IdPessoaVistoriador) NomePessoaVistoriador, IdPessoaVistoriador, 
                DescPessoaCondutor NomePessoaCondutor, 
                DescPessoaProprietario NomePessoaProprietario, 
                (SELECT NomeStatus FROM SigeStatus WHERE IdStatus = VistOrdemServico.IdStatus) Status , VistOrdemServico.IdStatus, 
                (SELECT NomePessoa FROM SigePessoa WHERE IdPessoa = (select IdPessoa from SigeUsuario where IdUsuario = VistOrdemServico.IdUsuarioInclusao)) Inclusor, 
                FlagConcluido, CASE WHEN IdStatusResultado IS NULL THEN 0 ELSE IdStatusResultado END IdStatusResultado , 
                (SELECT IdVeiculo FROM VistVeiculo WHERE IdOrdemServico = VistOrdemServico.IdOrdemServico) QTD_VEIC_PRA_OS ,
                DataInclusao 
                FROM VistOrdemServico 
                WHERE 1=1 ";

                if(strIdEmpresa.Trim() != "") strSql += " AND IDEMPRESA = "+ strIdEmpresa.Trim() +" ";
                strSql += " ORDER BY IdOrdemServico DESC ";

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
                if(objDataSet != null ) objDataSet.Dispose();
            }
        }

        #endregion
        #region [   Validacao   ]
        /// <summary>
        /// [   Validacao   ]
        /// </summary>
        /// <param name="strMensagem">string com mensagem do retorno da operação</param>
        /// <returns>Retorna true ou false. Se foi validado ou não.</returns>
        private bool Validacao(out string strMensagem)
        {
            bool bolValidacao = true;
            strMensagem = "";
            try
            {
                if(string.IsNullOrEmpty(strDescPessoaCondutor.Trim ()))
                {
                    strMensagem = "Informe o condutor.";
                    bolValidacao = false;
                }

                if(string.IsNullOrEmpty(strDescPessoaProprietario.Trim ()))
                {
                    strMensagem = "Informe o condutor.";
                    bolValidacao = false;
                }

                return bolValidacao;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        public static string GetNextNumOS()
        {
            System.Data.SqlClient.SqlDataReader DataReader;
            try
            {
                string strSql = " SELECT (CASE WHEN MAX(IdOrdemServico) IS NULL THEN 1 ELSE  MAX(IdOrdemServico) + 1 END ) NEXTOS FROM VISTORDEMSERVICO ";

                using (Conexao cn = new Conexao())
                {
                    DataReader = cn.GetSqlDataReader(strSql);
                    return DataReader[0].ToString().Trim();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                DataReader = null;
            }
        }

        #region [   Gravar  ]
        /// <summary>
        /// OBJETIVO DO MÉTODO: MÉTODO PARA INSERÇÃO E ALTERAÇÃO DE REGISTROS NA TABELA VistOrdemServico
        /// DATA\HORA CRIAÇÃO :30/07/2013 17:53:57
        /// COMPUTADOR GERADOR:DESKTOP
        /// </summary>
        /// <returns>RETORNA TRUE OU FALSE. SE O PROCESSO FOI REALIZADO COM SUCESSO OU NÃO </returns>
        /// <param name="strMsgRetorno">Variável string com uma mensagem de retorno da operação no método.</param>
        public static bool Gravar(out string strMsgRetorno)
        {
            strMsgRetorno = "";

            try
            {

                //Valida os campos
                using (Conexao cn = new Conexao())
                {
                    cn.AddParametros("IdOrdemServico", (strIdOrdemServico.Trim() == ""? "0" :strIdOrdemServico.Trim()));
                    cn.AddParametros("IdEmpresa", strIdEmpresa);
                    cn.AddParametros("IdPessoaDigitador", strIdPessoaDigitador);
                    cn.AddParametros("IdPessoaVistoriador", strIdPessoaVistoriador);
                    cn.AddParametros("DescPessoaCondutor", strDescPessoaCondutor);
                    cn.AddParametros("DescPessoaProprietario", strDescPessoaProprietario);
                    cn.AddParametros("IdStatusResultado", strIdStatusResultado);
                    cn.AddParametros("FlagConcluido", strFlagConcluido);
                    cn.AddParametros("NumPlaca", strNumPlaca);
                    cn.AddParametros("IdStatus", strIdStatus);
                    cn.AddParametros("DataInclusao", "");
                    cn.AddParametros("IdUsuarioInclusao", strIdUsuarioInclusao);
                    cn.AddParametros("DataAlteracao", "");
                    cn.AddParametros("IdUsuarioAlteracao", strIdUsuarioAlteracao);
                    cn.AddParametros("IdEmpresaCliente", strIdEmpresaCliente);

                    cn.CriarPedido("STP_VistOrdemServico_IncAlt", false);

                    string valor = cn.GetValor("RESPOSTA", 0, 0);

                    switch (valor)
                    {
                        case "I":
                            strMsgRetorno = "Registro incluído com sucesso.";
                            return true;
                        case "A":
                            strMsgRetorno = "Registro alterado com sucesso.";
                            return true;
                        default:
                            strMsgRetorno = "Não foi possível incluir ou alterar o registro.";
                            return false;
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region [   VerificaSeExisteLaudoParaOS ]
        /// <summary>
        /// [   VerificaSeExisteLaudoParaOS ]
        /// </summary>
        /// <param name="strNumPlaca">string Número da placa.</param>
        private void VerificaSeExisteLaudoParaOS(out string strNumPlaca, int intIdOS)
        {
            strNumPlaca = "";
            try
            {
                if (intIdOS <= 0) return;

                string strSql = "";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region [   Excluir     ]
        /// <summary>
        /// OBJETIVO DO MÉTODO: MÉTODO QUE TEM POR OBJETIVO EXCLUIR REGISTR POR PARAMENTRO DO CÓDIGO IDENTIFICADOR VistOrdemServico
        /// DATA\HORA CRIAÇÃO :30/07/2013 17:53:57
        /// COMPUTADOR GERADOR:DESKTOP
        /// </summary>
        /// <returns>RETORNA TRUE OU FALSE. SE FOI EXCLUÍDO OU NÃO.</returns>
        /// <param name="strMsgRetorno">Variável string com uma mensagem de retorno da operação no método.</param>
        /// <param name="strCodigoRegistro">Código identificador do registro á ser excluído.</param>
        public static bool Excluir(out string strMsgRetorno, string strCodigoRegistro)
        {
            strMsgRetorno = "";

            try
            {
                if (string.IsNullOrEmpty(strIdOrdemServico.Trim()))
                {
                    strMsgRetorno = "Exclusão cancelada. OS não informada.<br/> Selecione a OS para excluir.";
                    return false;
                }

                using (Conexao cn = new Conexao())
                {
                    cn.AddParametros("IdOrdemServico", strIdOrdemServico.Trim());
                    cn.CriarPedido("STP_VistOrdemServico_Exc", false);

                    string valor = cn.GetValor("RESPOSTA", 0, 0);

                    switch (valor)
                    {
                        case "1":
                            strMsgRetorno = "Registro excluído com sucesso.";
                            return true;
                        case "2":
                            strMsgRetorno = "Não foi possível excluir o registro.";
                            return false;
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

        #region [   Pesquisar   ]
        /// <summary>
        /// OBJETIVO DO MÉTODO: MÉTODO QUE TEM POR OBJETIVO PESQUISAR REGISTROSVistOrdemServico
        /// DATA\HORA CRIAÇÃO :30/07/2013 23:05:24
        /// COMPUTADOR GERADOR:DESKTOP
        /// </summary>
        /// <returns>RETORNA TRUE OU FALSE. SE A PESQUISA FOI REALIZADA COM SUCESSO OU NÃO.</returns>
        /// <param name="strMsgRetorno">Variável string com uma mensagem de retorno da operação no método.</param>
        public static bool Pesquisar(out string strMsgRetorno)
        {
            strMsgRetorno = "";

            try
            {
                using (Conexao cn = new Conexao())
                {
                    cn.AddParametros("IdOrdemServico",  strIdOrdemServico);

                    cn.CriarPedido("STP_VistOrdemServico_Pes", false);

                    strIdOrdemServico = cn.GetValor("IdOrdemServico", 0, 0);
                    strIdPessoaVistoriador = cn.GetValor("IdPessoaVistoriador", 0, 0);
                    strDescPessoaCondutor = cn.GetValor("DescPessoaCondutor", 0, 0);
                    strDescPessoaProprietario = cn.GetValor("DescPessoaProprietario", 0, 0);
                    strNumPlaca = cn.GetValor("NumPlaca", 0, 0);
                    strIdStatus = cn.GetValor("IdStatus", 0, 0);
                    strDataInclusao = cn.GetValor("DataInclusao", 0, 0);
                    strDataAlteracao = cn.GetValor("DataAlteracao", 0, 0);
                    strIdUsuarioInclusao = cn.GetValor("IdUsuarioInclusao", 0, 0);
                    strIdUsuarioAlteracao = cn.GetValor("IdUsuarioAlteracao", 0, 0);
                    strIdEmpresaCliente = cn.GetValor("IdEmpresaCliente", 0, 0);

                    strMsgRetorno = "Pesquisa realizada com sucesso.";

                    return true;
                }
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
