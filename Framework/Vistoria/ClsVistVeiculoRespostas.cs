using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Database;
using Framework;

namespace Framework.Vistoria
{
    public class ClsVistVeiculoRespostas
    {
        public string IdVeiculoRespostas;
        public string IdVeiculo;
        public string IdResposta;
        public string DataInclusao;
        public string IdUsuarioInclusao;
        public string DataAlteracao;
        public string IdUsuarioAlteracao;
        public string IdEmpresa;

        #region [   Gravar  ]
        /// <summary>
        /// OBJETIVO DO MÉTODO: MÉTODO PARA INSERÇÃO E ALTERAÇÃO DE REGISTROS NA TABELA VistVeiculoRespostas
        /// DATA\HORA CRIAÇÃO :11/09/2013 22:19:36
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
                    cn.AddParametros("IdVeiculoRespostas", IdVeiculoRespostas);
                    cn.AddParametros("IdVeiculo", IdVeiculo);
                    cn.AddParametros("IdResposta", IdResposta);
                    cn.AddParametros("DataInclusao", "");
                    cn.AddParametros("IdUsuarioInclusao", IdUsuarioInclusao);
                    cn.AddParametros("DataAlteracao", "");
                    cn.AddParametros("IdUsuarioAlteracao", IdUsuarioAlteracao);
                    cn.AddParametros("IdEmpresa", IdEmpresa);

                    cn.CriarPedido("STP_VistVeiculoRespostas_IncAlt", false);

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
        }
        #endregion

        #region [   Excluir     ]
        /// <summary>
        /// OBJETIVO DO MÉTODO: MÉTODO QUE TEM POR OBJETIVO EXCLUIR REGISTR POR PARAMENTRO DO CÓDIGO IDENTIFICADOR VistVeiculoRespostas
        /// DATA\HORA CRIAÇÃO :11/09/2013 22:19:36
        /// COMPUTADOR GERADOR:DESKTOP
        /// </summary>
        /// <returns>RETORNA TRUE OU FALSE. SE FOI EXCLUÍDO OU NÃO.</returns>
        /// <param name="strMsgRetorno">Variável string com uma mensagem de retorno da operação no método.</param>
        /// <param name="strCodigoRegistro">Código identificador do registro á ser excluído.</param>
        public bool Excluir(out string strMsgRetorno)
        {
            strMsgRetorno = "";

            try
            {
                using (Conexao cn = new Conexao())
                {
                    cn.AddParametros("IdVeiculo", IdVeiculo);

                    cn.CriarPedido("STP_VistVeiculoRespostas_Exc", false);

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
                throw ex;
            }
        }
        #endregion

        #region [   Pesquisar   ]
        /// <summary>
        /// OBJETIVO DO MÉTODO: MÉTODO QUE TEM POR OBJETIVO PESQUISAR REGISTROSVistVeiculoRespostas
        /// DATA\HORA CRIAÇÃO :11/09/2013 22:19:36
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
                    cn.AddParametros("IdVeiculoRespostas", IdVeiculoRespostas);

                    cn.CriarPedido("STP_VistVeiculoRespostas_Pes", false);

                    IdVeiculoRespostas = cn.GetValor("IdVeiculoRespostas", 0, 0);
                    IdVeiculo = cn.GetValor("IdVeiculo", 0, 0);
                    IdResposta = cn.GetValor("IdResposta", 0, 0);
                    DataInclusao = cn.GetValor("DataInclusao", 0, 0);
                    IdUsuarioInclusao = cn.GetValor("IdUsuarioInclusao", 0, 0);
                    DataAlteracao = cn.GetValor("DataAlteracao", 0, 0);
                    IdUsuarioAlteracao = cn.GetValor("IdUsuarioAlteracao", 0, 0);
                    IdEmpresa = cn.GetValor("IdEmpresa", 0, 0);

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

        #region [   AddResposta ]
        /// <summary>
        /// [   AddResposta ]
        /// </summary>
        /// <param name="strIdPergil">Código do perfil</param>
        /// <param name="strFuncionalidades">Funcionalidades a liberar/bloquear</param>
        /// <param name="strTipoAcao">Os tipos de ação podem ser: adicionar | remover </param>
        public bool AddResposta(string strIdVeiculo, string strIdResposta, string strIdEmpresa, string strIdUsuario)
        {
            bool bolRetorn = true;
            string strMensagem = "";
            int i = 0;
            try
            {
                if (string.IsNullOrEmpty(strIdVeiculo.Trim()) && string.IsNullOrEmpty(strIdResposta.Trim())) return false;

                IdVeiculoRespostas = "0";
                IdVeiculo = strIdVeiculo;
                DataInclusao  = "";
                IdUsuarioInclusao = strIdUsuario;
                DataAlteracao = "";
                IdUsuarioAlteracao =  strIdUsuario;
                IdEmpresa = strIdEmpresa;

                string[] strIdRes = strIdResposta.Split(',');
                i = 0;
                while (i < strIdRes.Length)
                {
                    IdResposta = strIdRes[i].ToString().Trim();
                    Gravar(out strMensagem);
                    i++;
                }

                return bolRetorn;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
