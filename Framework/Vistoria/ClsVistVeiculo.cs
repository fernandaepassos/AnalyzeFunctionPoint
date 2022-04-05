using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Database;
using Framework;

namespace Framework.Vistoria
{
    public class ClsVistVeiculo
    {
        #region Propriedades

        public string IdVeiculo;
        public string IdEspecie;
        public string IdMarca;
        public string Modelo;
        public string IdEmpresa;
        public string NumPlaca;
        public string IdArquivoPlaca;
        public string IdTipoSituacao;
        public string IdStatus;
        public string MotorNum;
        public string MotorPadraoFabrica;
        public string MotorPotencia;
        public string MotorObs;
        public string ChassiNum;
        public string ChassiPadraoFabrica;
        public string ChassiObs;
        public string IdArquivoChassi;
        public string Uf;
        public string Cidade;
        public string CorVeiculo;
        public string AnoDoModelo;
        public string CapacidadePassageiro;
        public string CapacidadeCarga;
        public string ObservacaoVistoria;
        public string KM;
        public string DataInclusao;
        public string DataAlteracao;
        public string IdUsuarioInclusao;
        public string IdUsuarioAlteraca;
        public string NumRenavam;
        public string Cilindrada;
        public string QuantValvular;
        public string NumEixos;
        public string NumEixosAuxiliares;
        public string NumEixosTraseiros;
        public string CapacMaxPorTracao;
        public string PesoBrutoTotal;
        public string IdentifCambio;
        public string IdentifCarroceria;
        public string AnoDeFabricacao;
        public string IdOrdemServico;
        public string IdVeiculoTracao;
        public string IdVeiculoCategoria;
        public string DescCombustivel;
        public string NumPlacaLacre;
        public string NumOdometro;	

        #endregion

        #region Métodos

        #region [   GetVeiculoAll   ]
        /// <summary>
        /// [   GetVeiculoAll   ]
        /// </summary>
        /// <param name="strIdEmpresa">Código da empresa</param>
        /// <returns>Retorna uma coleção (SqlDataReader) de dados com a espécie</returns>
        public static System.Data.DataSet GetVeiculoAll(string strIdEmpresa)
        {
            try
            {
                string strSql = " SELECT * FROM wvVistVeiculoPesq ";

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

        #region [   Gravar  ]
        /// <summary>
        /// OBJETIVO DO MÉTODO: MÉTODO PARA INSERÇÃO E ALTERAÇÃO DE REGISTROS NA TABELA VistVeiculo
        /// DATA\HORA CRIAÇÃO :27/08/2013 22:14:38
        /// COMPUTADOR GERADOR:DESKTOP
        /// </summary>
        /// <returns>RETORNA TRUE OU FALSE. SE O PROCESSO FOI REALIZADO COM SUCESSO OU NÃO </returns>
        /// <param name="strMsgRetorno">Variável string com uma mensagem de retorno da operação no método.</param>
        public bool Gravar(out string strMsgRetorno, out string strIdVeiculo)
        {
            strMsgRetorno = "";
            strIdVeiculo = "";
            try
            {
                using (Conexao cn = new Conexao())
                {
                    cn.AddParametros("IdVeiculo", IdVeiculo);
                    cn.AddParametros("IdEspecie", IdEspecie);
                    cn.AddParametros("IdMarca", IdMarca);
                    cn.AddParametros("Modelo", Modelo);
                    cn.AddParametros("IdEmpresa", IdEmpresa);
                    cn.AddParametros("NumPlaca", NumPlaca);
                    cn.AddParametros("IdArquivoPlaca", IdArquivoPlaca);
                    cn.AddParametros("IdStatus", IdStatus);
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
                    cn.AddParametros("DescCombustivel", DescCombustivel);
                    cn.AddParametros("NumPlacaLacre", NumPlacaLacre);
                    cn.AddParametros("NumOdometro", NumOdometro); 

                    cn.CriarPedido("STP_VistVeiculo_IncAlt", false);

                    string valor = cn.GetValor("RESPOSTA", 0, 0);

                    switch (valor)
                    {
                        case "I":
                            strIdVeiculo = cn.GetValor("IdVeiculo", 0, 0);
                            strMsgRetorno = "Registro incluído com sucesso.";
                            return true;
                        case "A":
                            strIdVeiculo = cn.GetValor("IdVeiculo", 0, 0);
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

        #region [   Excluir ]
        /// <summary>
        /// OBJETIVO DO MÉTODO: MÉTODO QUE TEM POR OBJETIVO EXCLUIR REGISTR POR PARAMENTRO DO CÓDIGO IDENTIFICADOR VistVeiculo
        /// DATA\HORA CRIAÇÃO :27/08/2013 22:14:38
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
        }
        #endregion

        #region [   Pesquisar   ]
        /// <summary>
        /// OBJETIVO DO MÉTODO: MÉTODO QUE TEM POR OBJETIVO PESQUISAR REGISTROSVistVeiculo
        /// DATA\HORA CRIAÇÃO :27/08/2013 22:14:38
        /// COMPUTADOR GERADOR:DESKTOP
        /// </summary>
        /// <returns>RETORNA TRUE OU FALSE. SE A PESQUISA FOI REALIZADA COM SUCESSO OU NÃO.</returns>
        /// <param name="strMsgRetorno">Variável string com uma mensagem de retorno da operação no método.</param>
        public bool Pesquisar(out string strMsgRetorno, string strCodigoRegistro)
        {
            strMsgRetorno = "";

            try
            {
                using (Conexao cn = new Conexao())
                {
                    cn.AddParametros("IdVeiculo", IdVeiculo);

                    cn.CriarPedido("STP_VistVeiculo_Pes", false);

                    IdVeiculo = cn.GetValor("IdVeiculo", 0, 0);
                    IdEspecie = cn.GetValor("IdEspecie", 0, 0);
                    IdMarca = cn.GetValor("IdMarca", 0, 0);
                    Modelo = cn.GetValor("Modelo", 0, 0);
                    IdEmpresa = cn.GetValor("IdEmpresa", 0, 0);
                    NumPlaca = cn.GetValor("NumPlaca", 0, 0);
                    IdArquivoPlaca = cn.GetValor("IdArquivoPlaca", 0, 0);
                    IdTipoSituacao = cn.GetValor("IdTipoSituacao", 0, 0);
                    IdStatus = cn.GetValor("IdStatus", 0, 0);
                    MotorNum = cn.GetValor("MotorNum", 0, 0);
                    MotorPadraoFabrica = cn.GetValor("MotorPadraoFabrica", 0, 0);
                    MotorPotencia = cn.GetValor("MotorPotencia", 0, 0);
                    MotorObs = cn.GetValor("MotorObs", 0, 0);
                    ChassiNum = cn.GetValor("ChassiNum", 0, 0);
                    ChassiPadraoFabrica = cn.GetValor("ChassiPadraoFabrica", 0, 0);
                    ChassiObs = cn.GetValor("ChassiObs", 0, 0);
                    IdArquivoChassi = cn.GetValor("IdArquivoChassi", 0, 0);
                    Uf = cn.GetValor("Uf", 0, 0);
                    Cidade = cn.GetValor("Cidade", 0, 0);
                    CorVeiculo = cn.GetValor("CorVeiculo", 0, 0);
                    AnoDoModelo = cn.GetValor("AnoDoModelo", 0, 0);
                    CapacidadePassageiro = cn.GetValor("CapacidadePassageiro", 0, 0);
                    CapacidadeCarga = cn.GetValor("CapacidadeCarga", 0, 0);
                    ObservacaoVistoria = cn.GetValor("ObservacaoVistoria", 0, 0);
                    KM = cn.GetValor("KM", 0, 0);
                    DataInclusao = cn.GetValor("DataInclusao", 0, 0);
                    DataAlteracao = cn.GetValor("DataAlteracao", 0, 0);
                    IdUsuarioInclusao = cn.GetValor("IdUsuarioInclusao", 0, 0);
                    IdUsuarioAlteraca = cn.GetValor("IdUsuarioAlteraca", 0, 0);
                    NumRenavam = cn.GetValor("NumRenavam", 0, 0);
                    Cilindrada = cn.GetValor("Cilindrada", 0, 0);
                    QuantValvular = cn.GetValor("QuantValvular", 0, 0);
                    NumEixos = cn.GetValor("NumEixos", 0, 0);
                    NumEixosAuxiliares = cn.GetValor("NumEixosAuxiliares", 0, 0);
                    NumEixosTraseiros = cn.GetValor("NumEixosTraseiros", 0, 0);
                    CapacMaxPorTracao = cn.GetValor("CapacMaxPorTracao", 0, 0);
                    PesoBrutoTotal = cn.GetValor("PesoBrutoTotal", 0, 0);
                    IdentifCambio = cn.GetValor("IdentifCambio", 0, 0);
                    IdentifCarroceria = cn.GetValor("IdentifCarroceria", 0, 0);
                    AnoDeFabricacao = cn.GetValor("AnoDeFabricacao", 0, 0);
                    IdOrdemServico = cn.GetValor("IdOrdemServico", 0, 0);
                    IdVeiculoTracao = cn.GetValor("IdVeiculoTracao", 0, 0);
                    IdVeiculoCategoria = cn.GetValor("IdVeiculoCategoria", 0, 0);
                    DescCombustivel = cn.GetValor("DescCombustivel", 0, 0);

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
