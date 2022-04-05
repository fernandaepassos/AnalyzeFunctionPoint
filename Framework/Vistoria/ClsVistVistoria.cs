using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Database;

namespace Framework.Vistoria
{
    
    public class ClsVistVistoria
    {
        #region [   Propriedades    ]   

        private static string strIdVeiculo;
        public static string strIdEmpresa;
        private static string strIdOrdemServico;
        private string strIdEspecie;
        private string strIdMarca;
        private string strModelo;
        private string strNumPlaca;
        private string strIdArquivoPlaca;
        private string strIdStatus;
        private string strMotorNum;
        private string strMotorPadraoFabrica;
        private string strMotorPotencia;
        private string strMotorObs;
        private string strChassiNum;
        private string strChassiPadraoFabrica;
        private string strChassiObs;
        private string strIdArquivoChassi;
        private string strUf;
        private string strCidade;
        private string strCorVeiculo;
        private string strAnoDoModelo;
        private string strCapacidadePassageiro;
        private string strCapacidadeCarga;
        private string strObservacaoVistoria;
        private string strKM;
        private string strDataInclusao;
        private string strDataAlteracao;
        private string strIdUsuarioInclusao;
        private string strIdUsuarioAlteraca;
        private string strNumRenavam;
        private string strCilindrada;
        private string strQuantValvular;
        private string strNumEixos;
        private string strNumEixosAuxiliares;
        private string strNumEixosTraseiros;
        private string strCapacMaxPorTracao;
        private string strPesoBrutoTotal;
        private string strIdentifCambio;
        private string strIdentifCarroceria;
        private string strAnoDeFabricacao;
        private string strIdVeiculoTracao;
        private string strIdVeiculoCategoria;
        private string strNumPlacaLacre;
        private string strNumOdometro;	


        #region [     IdVeiculo    ]
        public string IdVeiculo
        {
            get
            {
                return strIdVeiculo; 
            }
            set
            {
                strIdVeiculo = value;
            }
        }
        #endregion

        #region [     IdOrdemServico    ]
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

        #region [     IdEmpresa    ]
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

        #region [     IdEspecie    ]
        public string IdEspecie
        {
            get
            {
                return strIdEspecie;
            }
            set
            {
                strIdEspecie = value;
            }
        }
        #endregion

        #region [     IdMarca  ]
        public string IdMarca
        {
            get
            {
                return strIdMarca;
            }
            set
            {
                strIdMarca = value;
            }
        }
        #endregion

        #region [     Modelo   ]
        public string Modelo
        {
            get
            {
                return strModelo;
            }
            set
            {
                strModelo = value;
            }
        }
        #endregion

        #region [     NumPlaca   ]
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

        #region [     IdArquivoPlaca   ]
        public string IdArquivoPlaca
        {
            get
            {
                return strIdArquivoPlaca;
            }
            set
            {
                strIdArquivoPlaca = value;
            }
        }
        #endregion

        #region [     IdStatus   ]
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

        #region [     MotorNum   ]
        public string MotorNum
        {
            get
            {
                return strMotorNum;
            }
            set
            {
                strMotorNum = value;
            }
        }
        #endregion

        #region [     MotorPadraoFabrica   ]
        public string MotorPadraoFabrica
        {
            get
            {
                return strMotorPadraoFabrica;
            }
            set
            {
                strMotorPadraoFabrica = value;
            }
        }
        #endregion

        #region [     MotorPotencia   ]
        public string MotorPotencia
        {
            get
            {
                return strMotorPotencia;
            }
            set
            {
                strMotorPotencia = value;
            }
        }
        #endregion

        #region [     MotorObs   ]
        public string MotorObs
        {
            get
            {
                return strMotorObs;
            }
            set
            {
                strMotorObs = value;
            }
        }
        #endregion

        #region [     ChassiNum   ]
        public string ChassiNum
        {
            get
            {
                return strChassiNum;
            }
            set
            {
                strChassiNum = value;
            }
        }
        #endregion

        #region [     ChassiPadraoFabrica   ]
        public string ChassiPadraoFabrica
        {
            get
            {
                return strChassiPadraoFabrica;
            }
            set
            {
                strChassiPadraoFabrica = value;
            }
        }
        #endregion

        #region [     ChassiObs   ]
        public string ChassiObs
        {
            get
            {
                return strChassiObs;
            }
            set
            {
                strChassiObs = value;
            }
        }
        #endregion

        #region [     IdArquivoChassi   ]
        public string IdArquivoChassi
        {
            get
            {
                return strIdArquivoChassi;
            }
            set
            {
                strIdArquivoChassi = value;
            }
        }
        #endregion

        #region [     Uf   ]
        public string Uf
        {
            get
            {
                return strUf;
            }
            set
            {
                strUf = value;
            }
        }
        #endregion

        #region [     Cidade ]
        public string Cidade
        {
            get
            {
                return strCidade;
            }
            set
            {
                strCidade = value;
            }
        }
        #endregion

        #region [     CorVeiculo  ]
        public string CorVeiculo
        {
            get
            {
                return strCorVeiculo;
            }
            set
            {
                strCorVeiculo = value;
            }
        }
        #endregion

        #region [     AnoDoModelo ]
        public string AnoDoModelo
        {
            get
            {
                return strAnoDoModelo;
            }
            set
            {
                strAnoDoModelo = value;
            }
        }
        #endregion

        #region [     CapacidadePassageiro  ]
        public string CapacidadePassageiro
        {
            get
            {
                return strCapacidadePassageiro; 
            }
            set
            {
                strCapacidadePassageiro = value;
            }
        }
        #endregion

        #region [     CapacidadeCarga   ]
        public string CapacidadeCarga
        {
            get
            {
                return strCapacidadeCarga;
            }
            set
            {
                strCapacidadeCarga = value;
            }
        }
        #endregion

        #region [     ObservacaoVistoria  ]
        public string ObservacaoVistoria
        {
            get
            {
                return strObservacaoVistoria; 
            }
            set
            {
                strObservacaoVistoria = value;
            }
        }
        #endregion

        #region [     KM   ]
        public string KM
        {
            get
            {
                return strKM;
            }
            set
            {
                strKM = value;
            }
        }
        #endregion

        #region [     DataInclusao   ]
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

        #region [     DataAlteracao   ]
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

        #region [     IdUsuarioInclusao  ]
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

        #region [     IdUsuarioAlteraca   ]
        public string IdUsuarioAlteraca
        {
            get
            {
                return strIdUsuarioAlteraca; 
            }
            set
            {
                strIdUsuarioAlteraca = value;
            }
        }
        #endregion

        #region [     NumRenavam   ]
        public string NumRenavam
        {
            get
            {
                return strNumRenavam; 
            }
            set
            {
                strNumRenavam = value;
            }
        }
        #endregion

        #region [     Cilindrada   ]
        public string Cilindrada
        {
            get
            {
                return strCilindrada;
            }
            set
            {
                strCilindrada = value;
            }
        }
        #endregion

        #region [     QuantValvular   ]
        public string QuantValvular
        {
            get
            {
                return strQuantValvular;
            }
            set
            {
                strQuantValvular = value;
            }
        }
        #endregion

        #region [     NumEixos   ]
        public string NumEixos
        {
            get
            {
                return strNumEixos;
            }
            set
            {
                strNumEixos = value;
            }
        }
        #endregion

        #region [     NumEixosAuxiliares   ]
        public string NumEixosAuxiliares
        {
            get
            {
                return strNumEixosAuxiliares;
            }
            set
            {
                strNumEixosAuxiliares = value;
            }
        }
        #endregion

        #region [     NumEixosTraseiros   ]
        public string NumEixosTraseiros
        {
            get
            {
                return strNumEixosTraseiros;
            }
            set
            {
                strNumEixosTraseiros = value;
            }
        }
        #endregion

        #region [     CapacMaxPorTracao      ]
        public string CapacMaxPorTracao
        {
            get
            {
                return strCapacMaxPorTracao;
            }
            set
            {
                strCapacMaxPorTracao = value;
            }
        }
        #endregion

        #region [     PesoBrutoTotal    ]
        public string PesoBrutoTotal
        {
            get
            {
                return strPesoBrutoTotal;
            }
            set
            {
                strPesoBrutoTotal = value;
            }
        }
        #endregion

        #region [     IdentifCambio      ]
        public string IdentifCambio
        {
            get
            {
                return strIdentifCambio;
            }
            set
            {
                strIdentifCambio = value;
            }
        }
        #endregion

        #region [     IdentifCarroceria      ]
        public string IdentifCarroceria
        {
            get
            {
                return strIdentifCarroceria;
            }
            set
            {
                strIdentifCarroceria = value;
            }
        }
        #endregion

        #region [     AnoDeFabricacao      ]
        public string AnoDeFabricacao
        {
            get
            {
                return strAnoDeFabricacao;
            }
            set
            {
                strAnoDeFabricacao = value;
            }
        }
        #endregion

        #region [     IdVeiculoTracao      ]
        public string IdVeiculoTracao
        {
            get
            {
                return strIdVeiculoTracao;
            }
            set
            {
                strIdVeiculoTracao = value;
            }
        }
        #endregion

        #region [     IdVeiculoCategoria      ]
        public string IdVeiculoCategoria
        {
            get
            {
                return strIdVeiculoCategoria;
            }
            set
            {
                strIdVeiculoCategoria = value;
            }
        }
        #endregion

        #region [     NumPlacaLacre      ]
        public string NumPlacaLacre
        {
            get
            {
                return strNumPlacaLacre;
            }
            set
            {
                strNumPlacaLacre = value;
            }
        }
        #endregion

        #region [     NumOdometro      ]
        public string NumOdometro
        {
            get
            {
                return strNumOdometro;
            }
            set
            {
                strNumOdometro = value;
            }
        }
        #endregion

        #endregion

        #region [   GetVistoriaAll ]
        /// <summary>
        /// [   GetVistoriaAll ]
        /// </summary>
        /// <returns>Retorna um dataset</returns>
        public static System.Data.DataSet GetVistoriaAll(string strIdEmpresa, string strIdVistoria, string strIdOS)
        {
            System.Data.DataSet objDataSet = new System.Data.DataSet();
            try
            {

                if(string.IsNullOrEmpty(strIdEmpresa.Trim())) return null;
                if(string.IsNullOrEmpty(strIdVistoria) && string.IsNullOrEmpty(strIdOS)) return null;
                string strSql = " SELECT * FROM wvVistVeiculoPesq where idempresa = "+ strIdEmpresa +" ";

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

        #region [   GetVistoria ]
        /// <summary>
        /// [   GetVistoria ]
        /// </summary>
        /// <param name="intIdOrdemServico">int Número da OS</param>
        /// <param name="intIdPessoaVistoriador">int idPessoaVistoriador</param>
        /// <param name="intIdStatus">int IdStatus</param>
        /// <param name="strDataCadastro">Datetime rDataCadastro</param>
        /// <param name="intIdPessoaProprietario">int IdPessoaProprietario </param>
        /// <param name="intIdPessoaCondutor">int IdPessoaCondutor</param>
        /// <param name="strNumPlaca">string NumPlaca</param>
        /// <returns>Retorna um dataset</returns>
        public static System.Data.DataSet GetVistoria(string strIdCondutor, string strFlagConcluido, string strPropriatario, string strSituacaoOS, string strStatusDaVistoria, string strVistoriado,  string strtxtNumOs, string strtxtNumPlaca)
        {
            System.Data.DataSet objDataSet = new System.Data.DataSet();
            try
            {

                string strSql = " SELECT * FROM vwVistVeiculo WHERE 1=1 ";

                if(!string.IsNullOrEmpty(strIdCondutor.Trim())) strSql += " AND IdPessoaCondutor = "+ strIdCondutor.Trim() + " ";
                if (!string.IsNullOrEmpty(strFlagConcluido.Trim())) strSql += " AND lower(FlagConcluido) = '"+ strFlagConcluido.ToLower() +"' ";
                if (!string.IsNullOrEmpty(strPropriatario.Trim())) strSql += " AND IdPessoaProprietario = "+ strPropriatario.Trim() +" ";
                if (!string.IsNullOrEmpty(strtxtNumPlaca.Trim())) strSql += " AND NumPlaca = "+ strtxtNumPlaca.Trim() +"  ";
                if (!string.IsNullOrEmpty(strtxtNumOs.Trim())) strSql += " AND OsId = "+  strtxtNumOs.Trim() +" ";
                if (!string.IsNullOrEmpty(strVistoriado.Trim())) strSql += " AND IdPessoaVistoriador = "+ strVistoriado.Trim() +" ";

                if (!string.IsNullOrEmpty(strStatusDaVistoria.Trim())) strSql += " AND VeiIdStatus = " + strStatusDaVistoria.Trim()  + " ";

                if (!string.IsNullOrEmpty(strSituacaoOS.Trim())) strSql += " AND OsIdStatusSituacao = " + strSituacaoOS.Trim() + " ";


                strSql += "  ORDER BY OsId DESC";

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

        #region "MÉTODO - INCLUI E ALTERA REGISTRO NO BANCO DE DADOS
        /// <summary>
        /// OBJETIVO DO MÉTODO: MÉTODO PARA INSERÇÃO E ALTERAÇÃO DE REGISTROS NA TABELA VistVeiculo
        /// DATA\HORA CRIAÇÃO :12/08/2013 22:37:30
        /// COMPUTADOR GERADOR:DESKTOP
        /// </summary>
        /// <returns>RETORNA TRUE OU FALSE. SE O PROCESSO FOI REALIZADO COM SUCESSO OU NÃO </returns>
        /// <param name="strMsgRetorno">Variável string com uma mensagem de retorno da operação no método.</param>
        public bool Gravar(out string strMsgRetorno)
        {
            strMsgRetorno = "";

            try
            {
                using (Conexao cn = new Conexao())
                {
                    cn.AddParametros("IdVeiculo",  IdVeiculo);
                    cn.AddParametros("IdEspecie", strIdEspecie);
                    cn.AddParametros("IdMarca", strIdMarca);
                    cn.AddParametros("Modelo", strModelo);
                    cn.AddParametros("IdEmpresa", IdEmpresa);
                    cn.AddParametros("NumPlaca", NumPlaca);
                    cn.AddParametros("IdArquivoPlaca", strIdArquivoPlaca);
                    cn.AddParametros("IdStatus", strIdStatus);
                    cn.AddParametros("MotorNum", MotorNum);
                    cn.AddParametros("MotorPadraoFabrica", MotorPadraoFabrica);
                    cn.AddParametros("MotorPotencia", MotorPotencia);
                    cn.AddParametros("MotorObs", MotorObs);
                    cn.AddParametros("ChassiNum", ChassiNum);
                    cn.AddParametros("ChassiPadraoFabrica", ChassiPadraoFabrica);
                    cn.AddParametros("ChassiObs", ChassiObs);
                    cn.AddParametros("IdArquivoChassi", IdArquivoChassi);
                    cn.AddParametros("Uf", Uf);
                    cn.AddParametros("Cidade", Cidade);
                    cn.AddParametros("CorVeiculo", CorVeiculo);
                    cn.AddParametros("AnoDoModelo", AnoDoModelo);
                    cn.AddParametros("CapacidadePassageiro", CapacidadePassageiro);
                    cn.AddParametros("CapacidadeCarga", CapacidadeCarga);
                    cn.AddParametros("ObservacaoVistoria", ObservacaoVistoria);
                    cn.AddParametros("KM", KM);
                    cn.AddParametros("DataInclusao", DataInclusao);
                    cn.AddParametros("DataAlteracao", DataAlteracao);
                    cn.AddParametros("IdUsuarioInclusao", IdUsuarioInclusao);
                    cn.AddParametros("IdUsuarioAlteraca", IdUsuarioAlteraca);
                    cn.AddParametros("NumRenavam", NumRenavam);
                    cn.AddParametros("Cilindrada", Cilindrada);
                    cn.AddParametros("QuantValvular", QuantValvular);
                    cn.AddParametros("NumEixos", NumEixos);
                    cn.AddParametros("NumEixosAuxiliares", NumEixosAuxiliares);
                    cn.AddParametros("NumEixosTraseiros", NumEixosTraseiros);
                    cn.AddParametros("CapacMaxPorTracao", CapacMaxPorTracao);
                    cn.AddParametros("PesoBrutoTotal", PesoBrutoTotal);
                    cn.AddParametros("IdentifCambio", IdentifCambio);
                    cn.AddParametros("IdentifCarroceria", IdentifCarroceria);
                    cn.AddParametros("AnoDeFabricacao", AnoDeFabricacao);
                    cn.AddParametros("IdOrdemServico", IdOrdemServico);
                    cn.AddParametros("IdVeiculoTracao", IdVeiculoTracao);
                    cn.AddParametros("IdVeiculoCategoria", IdVeiculoCategoria);
                    cn.AddParametros("NumPlacaLacre", strNumPlacaLacre);
                    cn.AddParametros("NumOdometro", strNumOdometro); 

                    cn.CriarPedido("STP_VistVeiculo_IncAlt", false);

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
            }
        }
        #endregion


        #region "MÉTODO - EXCLUIR REGISTRO
        /// <summary>
        /// OBJETIVO DO MÉTODO: MÉTODO QUE TEM POR OBJETIVO EXCLUIR REGISTR POR PARAMENTRO DO CÓDIGO IDENTIFICADOR VistVeiculo
        /// DATA\HORA CRIAÇÃO :12/08/2013 22:37:30
        /// COMPUTADOR GERADOR:DESKTOP
        /// </summary>
        /// <returns>RETORNA TRUE OU FALSE. SE FOI EXCLUÍDO OU NÃO.</returns>
        /// <param name="strMsgRetorno">Variável string com uma mensagem de retorno da operação no método.</param>
        /// <param name="strCodigoRegistro">Código identificador do registro á ser excluído.</param>
        public bool Excluir(out string strMsgRetorno, string strCodigoRegistro)
        {
            strMsgRetorno = "";

            try
            {
                using (Conexao cn = new Conexao())
                {

                    cn.AddParametros("IdVeiculo", strIdVeiculo);
                    cn.CriarPedido("STP_VistVeiculo_Exc", false);

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


        #region "MÉTODO - PESQUISAR REGISTRO
        /// <summary>
        /// OBJETIVO DO MÉTODO: MÉTODO QUE TEM POR OBJETIVO PESQUISAR REGISTROSVistVeiculo
        /// DATA\HORA CRIAÇÃO :12/08/2013 22:37:30
        /// COMPUTADOR GERADOR:DESKTOP
        /// </summary>
        /// <returns>RETORNA TRUE OU FALSE. SE A PESQUISA FOI REALIZADA COM SUCESSO OU NÃO.</returns>
        /// <param name="strMsgRetorno">Variável string com uma mensagem de retorno da operação no método.</param>
        public static bool Pesquisar(out string strMsgRetorno, string strCodigoRegistro)
        {
            strMsgRetorno = "";

            try
            {
                using (Conexao cn = new Conexao())
                {
                    cn.AddParametros("IdVeiculo", strIdVeiculo );

                    cn.CriarPedido("STP_VistVeiculo_Pes", false);

                    strMsgRetorno = "Pesquisa realizada com sucesso.";

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

    }
}
