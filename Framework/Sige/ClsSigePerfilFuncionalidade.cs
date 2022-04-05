using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Database;

namespace Framework.Sige
{
    public class ClsSigePerfilFuncionalidade
    {
        // Fields
        public string DataInclusao;
        public string FlagPadraoSistema;
        public string IdEmpresa;
        public string IdFuncionalidade;
        public string IdInclusorUsuario;
        public string IdPerfil;
        public string IdPerfilFuncionalidade;
        public string IdUltimoUsuario;
        public string UltimaAtualizacao;

        // Methods
        public bool AddRemovePerfil(string strIdPerfil, string strFuncionalidades, string strTipoAcao, string strIdEmpresa, out string strMensagem, string strIdUsuarioLoaado)
        {
            bool flag2;
            strMensagem = "";
            bool flag = true;
            int index = 0;
            try
            {
                if (((string.IsNullOrEmpty(strIdPerfil.Trim()) || string.IsNullOrEmpty(strFuncionalidades.Trim())) || (string.IsNullOrEmpty(strTipoAcao.Trim()) || string.IsNullOrEmpty(strIdEmpresa.Trim()))) || (strIdUsuarioLoaado.Trim() == ""))
                {
                    strMensagem = "Certifique-se de ter informado o Perfil e a funcionalidade.";
                    return false;
                }
                this.IdInclusorUsuario = strIdUsuarioLoaado;
                this.IdUltimoUsuario = strIdUsuarioLoaado;
                string[] strArray = strFuncionalidades.Split(new char[] { ',' });
                if (strTipoAcao.Trim().ToLower() == "adicionar")
                {
                    for (index = 0; index < strArray.Length; index++)
                    {
                        this.Adicionar(strArray[index].ToString().Trim(), strIdPerfil, strIdEmpresa, out strMensagem);
                    }
                }
                else if (strTipoAcao.Trim().ToLower() == "remover")
                {
                    for (index = 0; index < strArray.Length; index++)
                    {
                        Remover(strArray[index].ToString().Trim(), strIdPerfil, out strMensagem);
                    }
                }
                flag2 = flag;
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return flag2;
        }

        public bool Adicionar(string strFunc, string strIdPerfil, string strIdEmpresa, out string strMsgRetorno)
        {
            bool flag;
            strMsgRetorno = "";
            try
            {
                using (Conexao conexao = new Conexao())
                {
                    conexao.AddParametros("IdPerfilFuncionalidade", "0");
                    conexao.AddParametros("IdFuncionalidade", strFunc);
                    conexao.AddParametros("IdPerfil", strIdPerfil);
                    conexao.AddParametros("IdEmpresa", strIdEmpresa);
                    conexao.AddParametros("FlagPadraoSistema", "N");
                    conexao.AddParametros("IdUltimoUsuario", this.IdUltimoUsuario);
                    conexao.AddParametros("IdInclusorUsuario", this.IdInclusorUsuario);
                    conexao.AddParametros("UltimaAtualizacao", "");
                    conexao.AddParametros("DataInclusao", "");
                    conexao.CriarPedido("STP_SigePerfilFuncionalidade_IncAlt", false);
                    string str2 = conexao.GetValor("RESPOSTA", 0, 0);
                    if (str2 == null)
                    {
                        goto Label_00F4;
                    }
                    if (!(str2 == "I"))
                    {
                        if (str2 == "A")
                        {
                            goto Label_00EA;
                        }
                        goto Label_00F4;
                    }
                    strMsgRetorno = "Registro incluído com sucesso.";
                    goto Label_00FE;
                Label_00EA:
                    strMsgRetorno = "Registro alterado com sucesso.";
                    goto Label_00FE;
                Label_00F4:
                    strMsgRetorno = "Não foi possível incluir ou alterar o registro.";
                Label_00FE:
                    flag = true;
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                if (strMsgRetorno == "")
                {
                    strMsgRetorno = "Operação realizada com sucesso.";
                }
            }
            return flag;
        }

        public static DataSet GetConfigPerfil(string strIdPerfil, string strExibirLiberadasBloqueadas, string strIdSistema)
        {
            DataSet set;
            string sQL = "";
            try
            {
                if (string.IsNullOrEmpty(strIdPerfil.Trim()) || string.IsNullOrEmpty(strExibirLiberadasBloqueadas.Trim()))
                {
                    return null;
                }
                if (!(string.IsNullOrEmpty(strExibirLiberadasBloqueadas.Trim()) || !(strExibirLiberadasBloqueadas.Trim() == "liberadas")))
                {
                    sQL = " SELECT IdFuncionalidade, NomeFuncionalidade ";
                    sQL = (((((sQL + " FROM SigeSistemaFuncionalidade  ") + " WHERE IDSISTEMA = " + strIdSistema + "  AND IdFuncionalidade IN ") + " ( ") + " SELECT IdFuncionalidade" + " FROM SigePerfilFuncionalidade") + " WHERE IdPerfil = " + strIdPerfil) + " )                ";
                }
                else if (!(string.IsNullOrEmpty(strExibirLiberadasBloqueadas.Trim()) || !(strExibirLiberadasBloqueadas.Trim() == "naoliberadas")))
                {
                    sQL = " SELECT IdFuncionalidade, NomeFuncionalidade ";
                    sQL = (((((sQL + " FROM SigeSistemaFuncionalidade ") + " WHERE IDSISTEMA = " + strIdSistema + " AND IdFuncionalidade NOT IN  ") + " ( ") + "     SELECT IdFuncionalidade " + "     FROM SigePerfilFuncionalidade ") + "     WHERE IdPerfil = " + strIdPerfil + " ") + " ) ";
                }
                using (Conexao conexao = new Conexao())
                {
                    set = conexao.ExecSQL(sQL);
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return set;
        }

        public bool Pesquisar(out string strMsgRetorno, string strCodigoRegistro)
        {
            bool flag;
            strMsgRetorno = "";
            try
            {
                using (Conexao conexao = new Conexao())
                {
                    conexao.AddParametros("IdPerfilFuncionalidade", this.IdPerfilFuncionalidade);
                    conexao.CriarPedido("STP_SigePerfilFuncionalidade_Pes", false);
                    this.IdPerfilFuncionalidade = conexao.GetValor("IdPerfilFuncionalidade", 0, 0);
                    this.IdFuncionalidade = conexao.GetValor("IdFuncionalidade", 0, 0);
                    this.IdPerfil = conexao.GetValor("IdPerfil", 0, 0);
                    this.IdEmpresa = conexao.GetValor("IdEmpresa", 0, 0);
                    this.FlagPadraoSistema = conexao.GetValor("FlagPadraoSistema", 0, 0);
                    this.IdUltimoUsuario = conexao.GetValor("IdUltimoUsuario", 0, 0);
                    this.IdInclusorUsuario = conexao.GetValor("IdInclusorUsuario", 0, 0);
                    this.UltimaAtualizacao = conexao.GetValor("UltimaAtualizacao", 0, 0);
                    this.DataInclusao = conexao.GetValor("DataInclusao", 0, 0);
                    strMsgRetorno = "Pesquisa realizada com sucesso.";
                    flag = true;
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return flag;
        }

        public static bool Remover(string strFunc, string strIdPerfil, out string strMsgRetorno)
        {
            bool flag;
            strMsgRetorno = "";
            try
            {
                using (Conexao conexao = new Conexao())
                {
                    conexao.AddParametros("IdFuncionalidade ", strFunc);
                    conexao.AddParametros("IdPerfil", strIdPerfil);
                    conexao.CriarPedido("STP_SigePerfilFuncionalidade_Exc", false);
                    string str2 = conexao.GetValor("RESPOSTA", 0, 0);
                    if (str2 == null)
                    {
                        goto Label_007C;
                    }
                    if (!(str2 == "1"))
                    {
                        if (str2 == "2")
                        {
                            goto Label_0073;
                        }
                        goto Label_007C;
                    }
                    strMsgRetorno = "Registro excluído com sucesso.";
                    goto Label_0085;
                Label_0073:
                    strMsgRetorno = "Não foi possível excluir o registro.";
                    goto Label_0085;
                Label_007C:
                    strMsgRetorno = "Não foi possível incluir ou alterar o registro.";
                Label_0085:
                    flag = true;
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return flag;
        }
    }
}
