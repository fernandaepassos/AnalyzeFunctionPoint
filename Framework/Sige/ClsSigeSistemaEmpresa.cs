using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using Database;

namespace Framework.Sige
{
    public class ClsSigeSistemaEmpresa
    {
        // Fields
        private string strDataInclusao;
        private string strIdEmpresa;
        private string strIdInclusorUsuario;
        private string strIdSistema;
        private string strIdSistemaEmpresa;
        private string strIdUltimoUsuario;
        private string strStatusAtivoInativo;
        private string strUltimaAtualizacao;

        // Methods
        public bool Excluir(out string strMsgRetorno, string strCodigoRegistro)
        {
            bool flag;
            strMsgRetorno = "";
            if (string.IsNullOrEmpty(strCodigoRegistro.Trim()))
            {
                strMsgRetorno = "Informe o sistema associado.";
                return false;
            }
            try
            {
                using (Conexao conexao = new Conexao())
                {
                    conexao.AddParametros("IdSistemaEmpresa", strCodigoRegistro);
                    conexao.CriarPedido("STP_SigeSistemaEmpresa_Exc", false);
                    string str2 = conexao.GetValor("RESPOSTA", 0, 0);
                    if (str2 == null)
                    {
                        goto Label_0092;
                    }
                    if (!(str2 == "1"))
                    {
                        if (str2 == "2")
                        {
                            goto Label_0089;
                        }
                        goto Label_0092;
                    }
                    strMsgRetorno = "Registro excluído com sucesso.";
                    goto Label_009B;
                Label_0089:
                    strMsgRetorno = "Não foi possível excluir o registro.";
                    goto Label_009B;
                Label_0092:
                    strMsgRetorno = "Não foi possível incluir ou alterar o registro.";
                Label_009B:
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

        public static DataSet GetSistemasPorEmpresa(string strIdEmpresa)
        {
            DataSet set2;
            DataSet set = new DataSet();
            try
            {
                using (Conexao conexao = new Conexao())
                {
                    set = conexao.ExecSQL("SELECT * FROM vwSistemaEmpresaPesq WHERE IDEMPRESA = " + strIdEmpresa);
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

        public bool Gravar(out string strMsgRetorno)
        {
            bool flag;
            strMsgRetorno = "";
            try
            {
                using (Conexao conexao = new Conexao())
                {
                    conexao.AddParametros("IdSistemaEmpresa", this.strIdSistemaEmpresa);
                    conexao.AddParametros("IdSistema", this.strIdSistema);
                    conexao.AddParametros("IdEmpresa", this.strIdEmpresa);
                    conexao.AddParametros("StatusAtivoInativo", this.strStatusAtivoInativo);
                    conexao.AddParametros("DataInclusao", this.strDataInclusao);
                    conexao.AddParametros("UltimaAtualizacao", this.strUltimaAtualizacao);
                    conexao.AddParametros("IdUltimoUsuario", this.strIdUltimoUsuario);
                    conexao.AddParametros("IdInclusorUsuario", this.strIdInclusorUsuario);
                    conexao.CriarPedido("STP_SigeSistemaEmpresa_IncAlt", false);
                    string str2 = conexao.GetValor("RESPOSTA", 0, 0);
                    if (str2 == null)
                    {
                        goto Label_00F2;
                    }
                    if (!(str2 == "I"))
                    {
                        if (str2 == "A")
                        {
                            goto Label_00E9;
                        }
                        goto Label_00F2;
                    }
                    strMsgRetorno = "Registro incluído com sucesso.";
                    goto Label_00FB;
                Label_00E9:
                    strMsgRetorno = "Registro alterado com sucesso.";
                    goto Label_00FB;
                Label_00F2:
                    strMsgRetorno = "Não foi possível incluir ou alterar o registro.";
                Label_00FB:
                    flag = true;
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

        public string IdSistema
        {
            get
            {
                return this.strIdSistema;
            }
            set
            {
                this.strIdSistema = value;
            }
        }

        public string IdSistemaEmpresa
        {
            get
            {
                return this.strIdSistemaEmpresa;
            }
            set
            {
                this.strIdSistemaEmpresa = value;
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

        public string StatusAtivoInativo
        {
            get
            {
                return this.strStatusAtivoInativo;
            }
            set
            {
                this.strStatusAtivoInativo = value;
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
