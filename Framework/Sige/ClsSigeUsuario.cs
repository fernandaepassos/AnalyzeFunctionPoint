using System;
using Framework.Reflection.AcessoBancoDados;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Database;
using Framework;
using Framework.Seguranca;

namespace Framework.Sige
{
    public class ClsSigeUsuario
    {
        // Fields
        private string strDataInclusao;
        private string strFlagPadraoSistema;
        private string strIdEmpresa;
        private string strIdInclusorUsuario;
        private string strIdPerfl;
        private string strIdPessoa;
        private string strIdSistemaParametro;
        private string strIdUltimoUsuario;
        private string strIdUsuario;
        private string strLogin;
        private string strSenha;
        private string strStatusAtivoInativo;
        private string strUltimaAtualizacao;

        // Methods
        public bool Excluir(out string strMsgRetorno)
        {
            bool flag;
            strMsgRetorno = "";
            try
            {
                using (Conexao conexao = new Conexao())
                {
                    conexao.AddParametros("IdUsuario", this.strIdUsuario);
                    conexao.CriarPedido("STP_SigeUsuario_Exc", false);
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
                throw exception;
            }
            return flag;
        }

        private string GetDiaDaSemana()
        {
            string str;
            try
            {
                switch (DateTime.Now.DayOfWeek.ToString().Trim())
                {
                    case "Monday":
                        return "segunda-feira";

                    case "Tuesday":
                        return "terça-feira";

                    case "Wednesday":
                        return "quarta-feira";

                    case "Thursday":
                        return "quinta-feira";

                    case "Friday":
                        return "sexta-feira";

                    case "Saturday":
                        return "sábado";

                    case "Sunday":
                        return "domingo";
                }
                str = "";
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return str;
        }

        public string GetIdUsuario(int intIdPessoa)
        {
            string str;
            try
            {
                if (intIdPessoa <= 0)
                {
                    return "";
                }
                DataSet set = AcessoBD.ObterDataSet("select IdUsuario from sigeusuario where IdPessoa = " + intIdPessoa + " ");
                if (((set != null) && (set.Tables.Count > 0)) && (set.Tables[0].Rows.Count > 0))
                {
                    return set.Tables[0].Rows[0][0].ToString().Trim();
                }
                str = "";
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return str;
        }

        public string GetNomeCompleto(int intIdUsuario)
        {
            string str;
            try
            {
                if (intIdUsuario <= 0)
                {
                    return "";
                }
                DataSet set = AcessoBD.ObterDataSet("select SigePessoa.NomePessoa from SigeUsuario Left Join SigePessoa on SigePessoa.IdPessoa = SigeUsuario.IdPessoa where IdUsuario = " + intIdUsuario.ToString().Trim());
                if (((set != null) && (set.Tables.Count > 0)) && (set.Tables[0].Rows.Count > 0))
                {
                    return set.Tables[0].Rows[0][0].ToString().Trim();
                }
                str = "";
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return str;
        }

        private string GetSistemaLiberado(string strIdUsuarioParam, string strIdEmpresaParam)
        {
            string str3;
            DataSet set = new DataSet();
            string str = "";
            try
            {
                set = AcessoBD.ObterDataSet((" SELECT IdSistema FROM SigeSistemaEmpresa " + " WHERE IdEmpresa = " + strIdEmpresaParam + " ") + " AND IdSistema IN (SELECT IdSistema FROM SigeUsuarioSistema WHERE IdUsuario = " + strIdUsuarioParam + ") ");
                if (((set != null) && (set.Tables.Count > 0)) && (set.Tables[0].Rows.Count > 0))
                {
                    for (int i = 0; i < set.Tables[0].Rows.Count; i++)
                    {
                        str = str + set.Tables[0].Rows[i]["idsistema"].ToString().Trim() + ",";
                    }
                    if (str.Trim().Length > 1)
                    {
                        str = str.Substring(0, str.Length - 1);
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
                if (set != null)
                {
                    set.Dispose();
                }
            }
            return str3;
        }

        private string GetSistemaLiberadoPorUsuario(string strIdUsuarioParam, string strIdEmpresaParam)
        {
            string str3;
            DataSet set = new DataSet();
            string str = "";
            try
            {
                using (Conexao conexao = new Conexao())
                {
                    string sQL = " SELECT IdSistema FROM SigeSistemaEmpresa ";
                    sQL = (sQL + " WHERE IdEmpresa = " + strIdEmpresaParam + " ") + " AND IdSistema IN (SELECT IdSistema FROM SigeUsuarioSistema WHERE IdUsuario = " + strIdUsuarioParam + ") ";
                    set = conexao.ExecSQL(sQL);
                }
                if (((set != null) && (set.Tables.Count > 0)) && (set.Tables[0].Rows.Count > 0))
                {
                    for (int i = 0; i < set.Tables[0].Rows.Count; i++)
                    {
                        str = str + set.Tables[0].Rows[i]["idsistema"].ToString().Trim() + ",";
                    }
                    if (str.Trim().Length > 1)
                    {
                        str = str.Substring(0, str.Length - 1);
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

        public bool Gravar(out string strMsgRetorno, out string strIdUsuaroNew)
        {
            bool flag;
            strMsgRetorno = "";
            strIdUsuaroNew = "";
            try
            {
                using (Conexao conexao = new Conexao())
                {
                    conexao.AddParametros("IdUsuario", this.strIdUsuario);
                    conexao.AddParametros("IdPerfl", this.strIdPerfl);
                    conexao.AddParametros("IdEmpresa", this.strIdEmpresa);
                    conexao.AddParametros("Login", this.strLogin);
                    conexao.AddParametros("Senha", this.strSenha);
                    conexao.AddParametros("StatusAtivoInativo", this.strStatusAtivoInativo);
                    conexao.AddParametros("IdPessoa", this.IdPessoa);
                    conexao.AddParametros("FlagPadraoSistema", this.strFlagPadraoSistema);
                    conexao.AddParametros("DataInclusao", "");
                    conexao.AddParametros("IdInclusorUsuario", this.strIdInclusorUsuario);
                    conexao.AddParametros("IdUltimoUsuario", this.strIdUltimoUsuario);
                    conexao.AddParametros("UltimaAtualizacao", "");
                    conexao.AddParametros("IdSistemaParametro", this.strIdSistemaParametro);
                    conexao.CriarPedido("STP_SigeUsuario_IncAlt", false);
                    string str2 = conexao.GetValor("RESPOSTA", 0, 0);
                    if (str2 == null)
                    {
                        goto Label_0164;
                    }
                    if (!(str2 == "I"))
                    {
                        if (str2 == "A")
                        {
                            goto Label_0159;
                        }
                        goto Label_0164;
                    }
                    strMsgRetorno = "Registro incluído com sucesso.";
                    strIdUsuaroNew = conexao.GetValor("IdUsuario", 0, 0);
                    return true;
                Label_0159:
                    strMsgRetorno = "Registro alterado com sucesso.";
                    return true;
                Label_0164:
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

        public bool Pesquisar(out string strMsgRetorno, string strCodigoRegistro)
        {
            bool flag;
            strMsgRetorno = "";
            try
            {
                using (Conexao conexao = new Conexao())
                {
                    conexao.AddParametros("IdUsuario", this.strIdUsuario);
                    conexao.CriarPedido("STP_SigeUsuario_Pes", false);
                    this.IdUsuario = conexao.GetValor("IdUsuario", 0, 0);
                    this.IdPerfl = conexao.GetValor("IdPerfl", 0, 0);
                    this.IdEmpresa = conexao.GetValor("IdEmpresa", 0, 0);
                    this.Login = conexao.GetValor("Login", 0, 0);
                    this.Senha = conexao.GetValor("Senha", 0, 0);
                    this.StatusAtivoInativo = conexao.GetValor("StatusAtivoInativo", 0, 0);
                    this.IdPessoa = conexao.GetValor("IdPessoa", 0, 0);
                    this.FlagPadraoSistema = conexao.GetValor("FlagPadraoSistema", 0, 0);
                    this.DataInclusao = conexao.GetValor("DataInclusao", 0, 0);
                    this.IdInclusorUsuario = conexao.GetValor("IdInclusorUsuario", 0, 0);
                    this.IdUltimoUsuario = conexao.GetValor("IdUltimoUsuario", 0, 0);
                    this.UltimaAtualizacao = conexao.GetValor("UltimaAtualizacao", 0, 0);
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

        private bool ValidaAcessoParaDiaIntervHoraAtual(out string strMensagem, string strIdUsuario)
        {
            bool flag2;
            strMensagem = "";
            bool flag = true;
            DataSet set = new DataSet();
            try
            {
                if (strIdUsuario.Trim() == "")
                {
                    return false;
                }
                string sQL = " SELECT COUNT(*) AcessoAutorizado ";
                sQL = ((((sQL + " FROM SigeUsuarioHrAcesso ") + " WHERE IdUsuario = " + strIdUsuario + " ") + "  AND DiaSemana IN ('" + this.GetDiaDaSemana() + "')") + " AND '" + DateTime.Now.ToString("HH:mm") + "' >= HoraInicio  ") + " AND '" + DateTime.Now.ToString("HH:mm") + "' <= HoraFim ";
                using (Conexao conexao = new Conexao())
                {
                    set = conexao.ExecSQL(sQL);
                }
                if (((set.Tables.Count > 0) && (set.Tables[0].Rows.Count > 0)) && (set.Tables[0].Rows[0][0].ToString().Trim() == "0"))
                {
                    strMensagem = "Seu login/senha estão corretos, porém não existe configuração para<br/> o usuário acessar nesta data/hora.";
                    flag = false;
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

        private bool ValidaAcessoParaDiaIntervHoraAtual_(out string strMensagem, string strIdUsuario)
        {
            bool flag2;
            strMensagem = "";
            bool flag = true;
            DataSet set = new DataSet();
            try
            {
                if (strIdUsuario.Trim() == "")
                {
                    return false;
                }
                set = AcessoBD.ObterDataSet(((((" SELECT COUNT(*) AcessoAutorizado " + " FROM SigeUsuarioHrAcesso ") + " WHERE IdUsuario = " + strIdUsuario + " ") + "  AND DiaSemana IN ('" + this.GetDiaDaSemana() + "')") + " AND '" + DateTime.Now.ToString("HH:mm") + "' >= HoraInicio  ") + " AND '" + DateTime.Now.ToString("HH:mm") + "' <= HoraFim ");
                if (((set.Tables.Count > 0) && (set.Tables[0].Rows.Count > 0)) && (set.Tables[0].Rows[0][0].ToString().Trim() == "0"))
                {
                    strMensagem = "Seu login/senha estão corretos, porém não existe configuração para<br/> o usuário acessar nesta data/hora.";
                    flag = false;
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

        public bool ValidaExclusao(string strIdUsuario)
        {
            bool flag;
            DataSet set = new DataSet();
            DataSet set2 = new DataSet();
            try
            {
                if (strIdUsuario == null)
                {
                    return false;
                }
                if (strIdUsuario.Trim() == "")
                {
                    return false;
                }
                set = AcessoBD.ObterDataSet((((" select 'select count(*) from '+ sysobjects.name +' where '+ syscolumns.name +' = " + strIdUsuario + "' ") + " From sysobjects, syscolumns ") + " where sysobjects.id = syscolumns.id " + " and sysobjects.xtype = 'u'  ") + " and syscolumns.name like '%IdUsuario%'  " + " and sysobjects.name <> 'SigeUsuario' and sysobjects.name <> 'SigeUsuarioSistema' and sysobjects.name <> 'SigeUsuarioHrAcesso'");
                if (((set != null) && (set.Tables.Count > 0)) && (set.Tables[0].Rows.Count > 0))
                {
                    for (int i = 0; i < set.Tables[0].Rows.Count; i++)
                    {
                        set2 = AcessoBD.ObterDataSet(set.Tables[0].Rows[i][0].ToString().Trim());
                        if ((((set2 != null) && (set2.Tables.Count > 0)) && (set2.Tables[0].Rows.Count > 0)) && (set2.Tables[0].Rows[0][0].ToString().Trim() != "0"))
                        {
                            return false;
                        }
                    }
                    return true;
                }
                flag = true;
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                if (set != null)
                {
                    set.Dispose();
                }
            }
            return flag;
        }

        public bool ValidUser(out string strMensagemRetorno, out string stridUsuario, out string strIdPerfil, out string strIdEmpresa, out string strNomeUsuario, out string strIdsSistema)
        {
            bool flag2;
            bool flag = true;
            strMensagemRetorno = "";
            stridUsuario = "";
            strIdPerfil = "";
            strIdEmpresa = "";
            strNomeUsuario = "";
            strIdsSistema = "";
            DataSet set = new DataSet();
            try
            {
                if (((this.Senha == null) || string.IsNullOrEmpty(this.Senha.Trim())) || ((this.Login == null) || string.IsNullOrEmpty(this.Login.Trim())))
                {
                    strMensagemRetorno = "Informe o login e a senha.";
                    return false;
                }
                this.Senha = ClsCRIPTOGRAFIA.Criptografa(this.Senha);
                string sQL = " SELECT SigeUsuario.IdPessoa, SigeUsuario.Login, Senha, SigePessoa.IdEmpresa, SigePessoa.NomePessoa, ";
                sQL = (((sQL + " (CASE WHEN StatusAtivoInativo = 'A' THEN 'Ativo' ELSE CASE WHEN StatusAtivoInativo = 'I' then 'Inativo' ELSE '' END END) AS STATUS, SigeUsuario.IdUsuario, SigeUsuario.IdPerfl ") + " FROM SigeUsuario, SigePessoa" + " WHERE SigeUsuario.IdPessoa = SigePessoa.IdPessoa ") + " AND lower(SigeUsuario.Login)  = lower('" + this.Login.Trim() + "') ") + " and lower(Senha) = lower('" + this.Senha.Trim() + "')\t";
                using (Conexao conexao = new Conexao())
                {
                    set = conexao.ExecSQL(sQL);
                    if (((set != null) && (set.Tables.Count > 0)) && (set.Tables[0].Rows.Count > 0))
                    {
                        if (set.Tables[0].Rows[0][5].ToString().Trim().ToLower() == "inativo")
                        {
                            strMensagemRetorno = "Login desativado no sistema.  Contato o administrador do sistema.";
                            flag = false;
                        }
                        else if (!this.ValidaAcessoParaDiaIntervHoraAtual(out strMensagemRetorno, set.Tables[0].Rows[0]["IdUsuario"].ToString().Trim().ToLower()))
                        {
                            flag = false;
                        }
                        else
                        {
                            stridUsuario = set.Tables[0].Rows[0][6].ToString().Trim();
                            strIdPerfil = set.Tables[0].Rows[0][7].ToString().Trim();
                            strIdEmpresa = set.Tables[0].Rows[0][3].ToString().Trim();
                            strNomeUsuario = set.Tables[0].Rows[0][4].ToString().Trim();
                            strIdsSistema = this.GetSistemaLiberadoPorUsuario(set.Tables[0].Rows[0]["IdUsuario"].ToString().Trim().ToLower(), set.Tables[0].Rows[0]["IdEmpresa"].ToString().Trim());
                        }
                    }
                    else
                    {
                        strMensagemRetorno = "Login e/ou senha inválido.";
                        flag = false;
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
                if (set != null)
                {
                    set.Dispose();
                }
            }
            return flag2;
        }

        public bool ValidUser_(out string strMensagemRetorno, out string stridUsuario, out string strIdPerfil, out string strIdEmpresa, out string strNomeUsuario, out string strIdsSistema, out string strDesEmpresa)
        {
            bool flag2;
            bool flag = true;
            strMensagemRetorno = "";
            stridUsuario = "";
            strIdPerfil = "";
            strIdEmpresa = "";
            strNomeUsuario = "";
            strIdsSistema = "";
            strDesEmpresa = "";
            DataSet set = new DataSet();
            try
            {
                if (((this.Senha == null) || string.IsNullOrEmpty(this.Senha.Trim())) || ((this.Login == null) || string.IsNullOrEmpty(this.Login.Trim())))
                {
                    strMensagemRetorno = "Informe o login e a senha.";
                    return false;
                }
                this.Senha = ClsCRIPTOGRAFIA.Criptografa(this.Senha);
                string sqlComand = " SELECT SigeUsuario.IdPessoa ";
                sqlComand = (((((((sqlComand + " , SigeUsuario.Login " + " , Senha ") + " , SigePessoa.IdEmpresa " + " , SigePessoa.NomePessoa ") + " , SigeEmpresa.RazaoSocial  " + " , (CASE WHEN SigeUsuario.StatusAtivoInativo = 'A' THEN 'Ativo' ELSE CASE WHEN SigeUsuario.StatusAtivoInativo = 'I' then 'Inativo' ELSE '' END END) AS STATUS ") + " , SigeUsuario.IdUsuario " + " , SigeUsuario.IdPerfl   ") + " FROM SigeUsuario " + " LEFT JOIN SigePessoa ON SigePessoa.IdPessoa = SigeUsuario.IdPessoa  ") + " LEFT JOIN SigeEmpresa ON SigeEmpresa.IdEmpresa = SigePessoa.IdEmpresa  " + " WHERE 1 = 1   ") + " AND lower(SigeUsuario.Login)  = lower('" + this.Login.Trim() + "')   ") + " and lower(Senha) = lower('" + this.Senha.Trim() + "')\t ";
                if (this.IdEmpresa.Trim() != "")
                {
                    sqlComand = sqlComand + " AND SigePessoa.IdEmpresa = " + this.IdEmpresa.Trim() + " ";
                }
                set = AcessoBD.ObterDataSet(sqlComand);
                if (((set != null) && (set.Tables.Count > 0)) && (set.Tables[0].Rows.Count > 0))
                {
                    if (set.Tables[0].Rows[0]["STATUS"].ToString().Trim().ToLower() == "inativo")
                    {
                        strMensagemRetorno = "Login desativado no sistema.  Contato o administrador do sistema.";
                        flag = false;
                    }
                    else if (!this.ValidaAcessoParaDiaIntervHoraAtual_(out strMensagemRetorno, set.Tables[0].Rows[0]["IdUsuario"].ToString().Trim().ToLower()))
                    {
                        flag = false;
                    }
                    else
                    {
                        stridUsuario = set.Tables[0].Rows[0]["IdUsuario"].ToString().Trim();
                        strIdPerfil = set.Tables[0].Rows[0]["IdPerfl"].ToString().Trim();
                        strIdEmpresa = set.Tables[0].Rows[0]["IdEmpresa"].ToString().Trim();
                        strNomeUsuario = set.Tables[0].Rows[0]["NomePessoa"].ToString().Trim();
                        strIdsSistema = this.GetSistemaLiberado(set.Tables[0].Rows[0]["IdUsuario"].ToString().Trim().ToLower(), set.Tables[0].Rows[0]["IdEmpresa"].ToString().Trim());
                        strDesEmpresa = set.Tables[0].Rows[0]["RazaoSocial"].ToString().Trim();
                    }
                }
                else
                {
                    strMensagemRetorno = "Login e/ou senha inválido.";
                    flag = false;
                }
                flag2 = flag;
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                if (set != null)
                {
                    set.Dispose();
                }
            }
            return flag2;
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

        public string IdPerfl
        {
            get
            {
                return this.strIdPerfl;
            }
            set
            {
                this.strIdPerfl = value;
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

        public string IdSistemaParametro
        {
            get
            {
                return this.strIdSistemaParametro;
            }
            set
            {
                this.strIdSistemaParametro = value;
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

        public string Login
        {
            get
            {
                return this.strLogin;
            }
            set
            {
                this.strLogin = value;
            }
        }

        public string Senha
        {
            get
            {
                return this.strSenha;
            }
            set
            {
                this.strSenha = value;
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
