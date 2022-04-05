using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using Database;

namespace Framework.Sige
{
    public class ClsSigeUsuarioHrAcesso
    {
        // Fields
        private string strDataInclusao;
        private string strDiaSemana;
        private string strHoraFim;
        private string strHoraInicio;
        private string strIdInclusorUsuario;
        private string strIdUltimoUsuario;
        private string strIdUsuario;
        private string strIdUsuarioHrAcesso;
        private string strUltimaAtualizacao;

        // Methods
        public bool ExcluirUmHrAcesso(out string strMsgRetorno, string strIdUsuarioHrAcesso)
        {
            bool flag;
            strMsgRetorno = "";
            try
            {
                using (Conexao conexao = new Conexao())
                {
                    conexao.AddParametros("IdUsuarioHrAcesso", strIdUsuarioHrAcesso);
                    conexao.CriarPedido("STP_SigeUsuarioHrAcesso_Exc", false);
                    string str2 = conexao.GetValor("RESPOSTA", 0, 0);
                    if (str2 == null)
                    {
                        goto Label_006F;
                    }
                    if (!(str2 == "1"))
                    {
                        if (str2 == "2")
                        {
                            goto Label_0066;
                        }
                        goto Label_006F;
                    }
                    strMsgRetorno = "Registro excluído com sucesso.";
                    goto Label_0078;
                Label_0066:
                    strMsgRetorno = "Não foi possível excluir o registro.";
                    goto Label_0078;
                Label_006F:
                    strMsgRetorno = "Não foi possível incluir ou alterar o registro.";
                Label_0078:
                    flag = true;
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return flag;
        }

        public static DataSet GetHrAcesso(string strIdUsuario)
        {
            DataSet set2;
            DataSet set = new DataSet();
            try
            {
                if (strIdUsuario == null)
                {
                    return null;
                }
                if (strIdUsuario.Trim() == "")
                {
                    return null;
                }
                string sQL = " SELECT IdUsuarioHrAcesso, IdUsuario, DiaSemana, HoraInicio, HoraFim ";
                sQL = sQL + " FROM SigeUsuarioHrAcesso " + " WHERE 1=1 ";
                if (!string.IsNullOrEmpty(strIdUsuario.Trim()))
                {
                    sQL = sQL + " AND IdUsuario = " + strIdUsuario + " ";
                }
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

        public bool Gravar(out string strMsgRetorno)
        {
            bool flag;
            strMsgRetorno = "";
            try
            {
                using (Conexao conexao = new Conexao())
                {
                    conexao.AddParametros("IdUsuarioHrAcesso", this.strIdUsuarioHrAcesso);
                    conexao.AddParametros("IdUsuario", this.strIdUsuario);
                    conexao.AddParametros("DiaSemana", this.strDiaSemana);
                    conexao.AddParametros("HoraInicio", this.strHoraInicio);
                    conexao.AddParametros("HoraFim", this.strHoraFim);
                    conexao.AddParametros("UltimaAtualizacao", "");
                    conexao.AddParametros("IdUltimoUsuario", this.strIdUltimoUsuario);
                    conexao.AddParametros("IdInclusorUsuario", this.strIdInclusorUsuario);
                    conexao.AddParametros("DataInclusao", "");
                    conexao.CriarPedido("STP_SigeUsuarioHrAcesso_IncAlt", false);
                    string str2 = conexao.GetValor("RESPOSTA", 0, 0);
                    if (str2 == null)
                    {
                        goto Label_0102;
                    }
                    if (!(str2 == "I"))
                    {
                        if (str2 == "A")
                        {
                            goto Label_00F9;
                        }
                        goto Label_0102;
                    }
                    strMsgRetorno = "Registro incluído com sucesso.";
                    goto Label_010B;
                Label_00F9:
                    strMsgRetorno = "Registro alterado com sucesso.";
                    goto Label_010B;
                Label_0102:
                    strMsgRetorno = "Não foi possível incluir ou alterar o registro.";
                Label_010B:
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

        public string DiaSemana
        {
            get
            {
                return this.strDiaSemana;
            }
            set
            {
                this.strDiaSemana = value;
            }
        }

        public string HoraFim
        {
            get
            {
                return this.strHoraFim;
            }
            set
            {
                this.strHoraFim = value;
            }
        }

        public string HoraInicio
        {
            get
            {
                return this.strHoraInicio;
            }
            set
            {
                this.strHoraInicio = value;
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

        public string IdUsuario
        {
            get
            {
                return this.strIdUsuario;
            }
            set
            {
                this.strIdUsuario = value;
            }
        }

        public string IdUsuarioHrAcesso
        {
            get
            {
                return this.strIdUsuarioHrAcesso;
            }
            set
            {
                this.strIdUsuarioHrAcesso = value;
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
