using System;
using System.Data;
using Database;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Framework.Sige
{
    public class ClsSigePerfil
    {
        // Fields
        private string strDataInclusao;
        private string strFlagPadraoSistema;
        private string strIdEmpresa;
        private string strIdInclusorUsuario;
        private string strIdPerfil;
        private string strIdUltimoUsuario;
        private string strNomePerfil;
        private string strUltimaAtualizacao;

        // Methods
        public bool Excluir(out string strMsgRetorno, string strCodigoRegistro)
        {
            bool flag;
            strMsgRetorno = "";
            try
            {
                using (Conexao conexao = new Conexao())
                {
                    conexao.AddParametros("IdPerfil", this.strIdPerfil);
                    conexao.CriarPedido("STP_SigePerfil_Exc", false);
                    string str2 = conexao.GetValor("RESPOSTA", 0, 0);
                    if (str2 == null)
                    {
                        goto Label_0074;
                    }
                    if (!(str2 == "1"))
                    {
                        if (str2 == "2")
                        {
                            goto Label_006B;
                        }
                        goto Label_0074;
                    }
                    strMsgRetorno = "Registro excluído com sucesso.";
                    goto Label_007D;
                Label_006B:
                    strMsgRetorno = "Não foi possível excluir o registro.";
                    goto Label_007D;
                Label_0074:
                    strMsgRetorno = "Não foi possível incluir ou alterar o registro.";
                Label_007D:
                    flag = true;
                }
            }
            catch (Exception exception)
            {
                strMsgRetorno = exception.Message;
                throw exception;
            }
            return flag;
        }

        public string GetFuncionalidadesPorPerfi(string strIdPerfil)
        {
            string str3;
            DataSet set = new DataSet();
            string str = "";
            try
            {
                if (string.IsNullOrEmpty(strIdPerfil.Trim()))
                {
                    return "";
                }
                string sQL = "";
                sQL = " SELECT IdFuncionalidade ";
                sQL = (sQL + " FROM SigePerfilFuncionalidade ") + " WHERE IdPerfil = " + strIdPerfil + " ";
                using (Conexao conexao = new Conexao())
                {
                    set = conexao.ExecSQL(sQL);
                    if (((set != null) && (set.Tables.Count > 0)) && (set.Tables[0].Rows.Count > 0))
                    {
                        for (int i = 0; i < set.Tables[0].Rows.Count; i++)
                        {
                            if (str.Trim() == "")
                            {
                                str = set.Tables[0].Rows[i][0].ToString().Trim();
                            }
                            else
                            {
                                str = str + "," + set.Tables[0].Rows[i][0].ToString().Trim();
                            }
                        }
                    }
                }
                str3 = str;
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                set.Dispose();
            }
            return str3;
        }

        public static DataSet GetPerfil(string strIdEmpresa)
        {
            DataSet set2;
            DataSet set = new DataSet();
            try
            {
                string sQL = " SELECT IdPerfil, NomePerfil  FROM SigePerfil WHERE IdEmpresa = " + strIdEmpresa + " ";
                using (Conexao conexao = new Conexao())
                {
                    set = conexao.ExecSQL(sQL);
                }
                set2 = set;
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                set.Dispose();
            }
            return set2;
        }

        public static DataSet GetPerfilPes(string strIdEmpresaLogado, string strIdEmpresaPes, string strIdPerfil, string strDtCadastro, string strQtdUserAssociadoPergil)
        {
            DataSet set;
            try
            {
                using (Conexao conexao = new Conexao())
                {
                    string sQL = "SELECT * FROM vwSigePerfilPesq  WHERE 1=1";
                    if (!string.IsNullOrEmpty(strIdEmpresaPes.Trim()))
                    {
                        sQL = sQL + " AND IDEMPRESA = " + strIdEmpresaPes.Trim();
                    }
                    else if (!string.IsNullOrEmpty(strIdEmpresaLogado.Trim()))
                    {
                        sQL = sQL + " AND IDEMPRESA = " + strIdEmpresaLogado.Trim() + " ";
                    }
                    if (!string.IsNullOrEmpty(strIdPerfil.Trim()))
                    {
                        sQL = sQL + " AND IDPERFIL = " + strIdPerfil.Trim();
                    }
                    if (!string.IsNullOrEmpty(strDtCadastro.Trim()))
                    {
                        sQL = sQL + " AND CONVERT(VARCHAR, DataInclusao, 103) = '" + strDtCadastro.Trim() + "' ";
                    }
                    if (!string.IsNullOrEmpty(strQtdUserAssociadoPergil.Trim()))
                    {
                        sQL = sQL + " AND QtdUserAssociadoPergil = " + strQtdUserAssociadoPergil.Trim() + " ";
                    }
                    set = conexao.ExecSQL(sQL);
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return set;
        }

        public bool GetPermissaoPorFuncionalidade(string strIdPerfil, string strIdFuncionalidade)
        {
            bool flag2;
            DataSet set = new DataSet();
            bool flag = false;
            try
            {
                string sQL = "";
                sQL = "SELECT CASE WHEN COUNT(IdPerfilFuncionalidade) > 0 THEN 'TRUE' ELSE 'FALSE' END TemAcesso";
                sQL = ((sQL + " FROM SigePerfilFuncionalidade  ") + " WHERE IdPerfil = " + strIdPerfil + " ") + " AND IdFuncionalidade = " + strIdFuncionalidade + " ";
                using (Conexao conexao = new Conexao())
                {
                    set = conexao.ExecSQL(sQL);
                    if (((set != null) && (set.Tables.Count > 0)) && (set.Tables[0].Rows.Count > 0))
                    {
                        return (set.Tables[0].Rows[0][0].ToString().Trim() == "TRUE");
                    }
                }
                flag2 = flag;
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                set.Dispose();
            }
            return flag2;
        }

        public bool Gravar(out string strMsgRetorno)
        {
            bool flag;
            strMsgRetorno = "";
            try
            {
                using (Conexao conexao = new Conexao())
                {
                    conexao.AddParametros("IdPerfil", this.strIdPerfil);
                    conexao.AddParametros("NomePerfil", this.strNomePerfil);
                    conexao.AddParametros("IdEmpresa", this.strIdEmpresa);
                    conexao.AddParametros("FlagPadraoSistema", ((this.strFlagPadraoSistema == null) || (this.strFlagPadraoSistema.Trim() == "")) ? "N" : this.strFlagPadraoSistema);
                    conexao.AddParametros("IdUltimoUsuario", this.strIdUltimoUsuario);
                    conexao.AddParametros("IdInclusorUsuario", this.strIdInclusorUsuario);
                    conexao.AddParametros("UltimaAtualizacao", this.strUltimaAtualizacao);
                    conexao.AddParametros("DataInclusao", this.strDataInclusao);
                    conexao.CriarPedido("STP_SigePerfil_IncAlt", false);
                    string str2 = conexao.GetValor("RESPOSTA", 0, 0);
                    if (str2 == null)
                    {
                        goto Label_0131;
                    }
                    if (!(str2 == "I"))
                    {
                        if (str2 == "A")
                        {
                            goto Label_0126;
                        }
                        goto Label_0131;
                    }
                    strMsgRetorno = "Registro incluído com sucesso.";
                    this.IdPerfil = conexao.GetValor("IdPerfil", 0, 0);
                    return true;
                Label_0126:
                    strMsgRetorno = "Registro alterado com sucesso.";
                    return true;
                Label_0131:
                    strMsgRetorno = "Não foi possível incluir ou alterar o registro.";
                    flag = false;
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return flag;
        }

        // Properties
        public string DataInclusao
        {
            get
            {
                return this.strDataInclusao;
            }
            set
            {
                this.strDataInclusao = value;
            }
        }

        public string FlagPadraoSistema
        {
            get
            {
                return this.strFlagPadraoSistema;
            }
            set
            {
                this.strFlagPadraoSistema = value;
            }
        }

        public string IdEmpresa
        {
            get
            {
                return this.strIdEmpresa;
            }
            set
            {
                this.strIdEmpresa = value;
            }
        }

        public string IdInclusorUsuario
        {
            get
            {
                return this.strIdInclusorUsuario;
            }
            set
            {
                this.strIdInclusorUsuario = value;
            }
        }

        public string IdPerfil
        {
            get
            {
                return this.strIdPerfil;
            }
            set
            {
                this.strIdPerfil = value;
            }
        }

        public string IdUltimoUsuario
        {
            get
            {
                return this.strIdUltimoUsuario;
            }
            set
            {
                this.strIdUltimoUsuario = value;
            }
        }

        public string NomePerfil
        {
            get
            {
                return this.strNomePerfil;
            }
            set
            {
                this.strNomePerfil = value;
            }
        }

        public string UltimaAtualizacao
        {
            get
            {
                return this.strUltimaAtualizacao;
            }
            set
            {
                this.strUltimaAtualizacao = value;
            }
        }
    }

}
