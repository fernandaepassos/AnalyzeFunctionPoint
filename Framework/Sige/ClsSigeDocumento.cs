using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Database;

namespace Framework.Sige
{
    public class ClsSigeDocumento
    {
        // Fields
        private string strDataInclusao;
        private string strIdDocumento;
        private string strIdEmpresa;
        private string strIdInclusorUsuario;
        private string strIdPessoa;
        private string strIdTipoDocumento;
        private string strIdUltimoUsuario;
        private string strNumDocumento;
        private string strUltimaAtualizacao;

        // Methods
        public bool Gravar(out string strMsgRetorno)
        {
            bool flag;
            strMsgRetorno = "";
            try
            {
                if (this.strIdPessoa.Trim() == "")
                {
                    flag = false;
                }
                else
                {
                    using (Conexao conexao = new Conexao())
                    {
                        conexao.AddParametros("IdDocumento", string.IsNullOrEmpty(this.strIdDocumento.Trim()) ? "0" : this.strIdDocumento);
                        conexao.AddParametros("IdPessoa", this.strIdPessoa);
                        conexao.AddParametros("NumDocumento", this.strNumDocumento);
                        conexao.AddParametros("IdTipoDocumento", this.strIdTipoDocumento);
                        conexao.AddParametros("DataInclusao", "");
                        conexao.AddParametros("UltimaAtualizacao", "");
                        conexao.AddParametros("IdInclusorUsuario", this.strIdInclusorUsuario);
                        conexao.AddParametros("IdUltimoUsuario", this.strIdUltimoUsuario);
                        conexao.CriarPedido("STP_SigeDocumento_IncAlt", false);
                        string str2 = conexao.GetValor("RESPOSTA", 0, 0);
                        if (str2 == null)
                        {
                            goto Label_0146;
                        }
                        if (!(str2 == "I"))
                        {
                            if (str2 == "A")
                            {
                                goto Label_0134;
                            }
                            if (str2 == "E")
                            {
                                goto Label_013D;
                            }
                            goto Label_0146;
                        }
                        strMsgRetorno = "Registro incluído com sucesso.";
                        goto Label_014F;
                    Label_0134:
                        strMsgRetorno = "Registro alterado com sucesso.";
                        goto Label_014F;
                    Label_013D:
                        strMsgRetorno = "Registro excluído com sucesso.";
                        goto Label_014F;
                    Label_0146:
                        strMsgRetorno = "Não foi possível incluir ou alterar o registro.";
                    Label_014F:
                        flag = true;
                    }
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

        public string IdDocumento
        {
            get
            {
                return this.strIdDocumento;
            }
            set
            {
                this.strIdDocumento = value;
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

        public string IdPessoa
        {
            get
            {
                return this.strIdPessoa;
            }
            set
            {
                this.strIdPessoa = value;
            }
        }

        public string IdTipoDocumento
        {
            get
            {
                return this.strIdTipoDocumento;
            }
            set
            {
                this.strIdTipoDocumento = value;
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

        public string NumDocumento
        {
            get
            {
                return this.strNumDocumento;
            }
            set
            {
                this.strNumDocumento = value;
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
