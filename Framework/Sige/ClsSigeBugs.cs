using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Database;
using System.Net.Mail;
using System.Net;
using Framework.Reflection.AcessoBancoDados;
using Framework.Reflection.InsertUpdateDelete;
using Framework.Util;

namespace Framework.Sige
{
    public class ClsSigeBugs
    {
        // Fields
        private string _DataAlteracao;
        private string _DataInclusao;
        private string _DescErro;
        private int _IdBugs;
        private int _IdEmpresa;
        private int _IdSistema;
        private int _IdUsuarioAlteracao;
        private int _IdUsuarioInclusao;
        private string _NomeEvento;
        private string _NomeTela;
        private long _NumErro;

        // Methods
        private static void EnviarEmlComBug(string strNumErro, string strDescErro, string strIdSistema, string strNomeTela, string strNomeEvento, string strIdUsario, string strDataInclusao, string strIdEmpresa = "", string strIdBugs = "")
        {
            ClsSigeUsuario usuario = new ClsSigeUsuario();
            StringBuilder builder = new StringBuilder();
            ClsSigeEmpresa empresa = new ClsSigeEmpresa();
            try
            {
                ClsEmail email = new ClsEmail();
                string nomeSistema = ClsSigeSistema.GetNomeSistema(strIdSistema);
                string nomeEmpresa = ClsSigeEmpresa.GetNomeEmpresa(strIdEmpresa);
                string nomeCompleto = usuario.GetNomeCompleto(Convert.ToInt32(strIdUsario));
                email.Assunto = "Bug =-( : " + strIdBugs + " | Cliente: " + nomeEmpresa + " | Sistema: " + nomeSistema + " | Tela: " + strNomeTela + " | Nº: " + strNumErro;
                email.EmailRemetente = "bugs@sisclick.com.br";
                email.EmailDestinatario = "bugs@sisclick.com.br";
                email.EmailAutenticacaoSenha = "srv$#@prod";
                email.EmailAutenticacao = "sisclickecommerce@gmail.com";
                email.EmailDoInternauta = "bugs@sisclick.com.br";
                builder.Append("Código do Bug: " + strIdBugs);
                builder.Append(" | Cliente: " + nomeEmpresa);
                builder.Append(" | Sistema: " + nomeSistema);
                builder.Append(" | Número do erro: " + strNumErro);
                builder.Append(" | Descrição do erro: " + strDescErro);
                builder.Append(" | Nome da tela: " + strNomeTela);
                builder.Append(" | Nome do evento: " + strNomeEvento);
                builder.Append(" | Nome do usuáro: " + nomeCompleto);
                builder.Append(" | Data/hora do bugs: " + strDataInclusao);
                email.Mensagem = builder.ToString().Trim();
                email.Nome = "Erro no cliente:" + nomeEmpresa;
                email.NomeDoSistema = nomeSistema;
                string urlLogo = empresa.GetUrlLogo(strIdEmpresa);
                email.UrlLogoSistema = urlLogo;
                email.Telefone = "";
                email.MensagemEmHtml = email.GetMsgHtml(ClsEmail.SistemaOrigem.SckEcommerce);
                string strMensagemRetorno = "";
                email.EnviarEmail(out strMensagemRetorno);
            }
            catch
            {
            }
        }

        public static void InsertBug(string strNumErro, string strDescErro, string strIdSistema, string strNomeTela, string strNomeEvento, string strIdUsario, string strDataInclusao)
        {
            try
            {
                if ((((!string.IsNullOrEmpty(strNumErro.Trim()) && !string.IsNullOrEmpty(strDescErro.Trim())) && (!string.IsNullOrEmpty(strIdSistema.Trim()) && !string.IsNullOrEmpty(strNomeTela.Trim()))) && (!string.IsNullOrEmpty(strNomeEvento.Trim()) && !string.IsNullOrEmpty(strIdUsario.Trim()))) && !string.IsNullOrEmpty(strDataInclusao.Trim()))
                {
                    ClsSigeBugs objSigeBugs = new ClsSigeBugs
                    {
                        IdBugs = 0,
                        NumErro = ((strNumErro != null) && (strNumErro.Trim() != "")) ? Convert.ToInt64(strNumErro) : 0L,
                        DescErro = strDescErro,
                        IdSistema = ((strIdSistema != null) && (strIdSistema.Trim() != "")) ? Convert.ToInt32(strIdSistema) : 0,
                        NomeTela = strNomeTela,
                        NomeEvento = strNomeEvento,
                        IdUsuarioInclusao = ((strIdUsario != null) && (strIdUsario.Trim() != "")) ? Convert.ToInt32(strIdUsario) : 0,
                        DataAlteracao = DateTime.Now.ToString(),
                        IdUsuarioAlteracao = ((strIdUsario != null) && (strIdUsario.Trim() != "")) ? Convert.ToInt32(strIdUsario) : 0,
                        DataInclusao = DateTime.Now.ToString(),
                        IdEmpresa = 0
                    };
                    objSigeBugs.Salvar(objSigeBugs, objSigeBugs.IdBugs);
                }
            }
            catch
            {
            }
        }

        public static void InsertBug(string strNumErro, string strDescErro, string strIdSistema, string strNomeTela, string strNomeEvento, string strIdUsario, string strDataInclusao, string strIdEmpresa)
        {
            try
            {
                if ((((!string.IsNullOrEmpty(strNumErro.Trim()) && !string.IsNullOrEmpty(strDescErro.Trim())) && (!string.IsNullOrEmpty(strIdSistema.Trim()) && !string.IsNullOrEmpty(strNomeTela.Trim()))) && (!string.IsNullOrEmpty(strNomeEvento.Trim()) && !string.IsNullOrEmpty(strIdUsario.Trim()))) && !string.IsNullOrEmpty(strDataInclusao.Trim()))
                {
                    ClsSigeBugs objSigeBugs = new ClsSigeBugs
                    {
                        IdBugs = 0,
                        NumErro = ((strNumErro != null) && (strNumErro.Trim() != "")) ? Convert.ToInt64(strNumErro) : 0L,
                        DescErro = strDescErro,
                        IdSistema = ((strIdSistema != null) && (strIdSistema.Trim() != "")) ? Convert.ToInt32(strIdSistema) : 0,
                        NomeTela = strNomeTela,
                        NomeEvento = strNomeEvento,
                        IdUsuarioInclusao = ((strIdUsario != null) && (strIdUsario.Trim() != "")) ? Convert.ToInt32(strIdUsario) : 0,
                        DataAlteracao = DateTime.Now.ToString(),
                        IdUsuarioAlteracao = ((strIdUsario != null) && (strIdUsario.Trim() != "")) ? Convert.ToInt32(strIdUsario) : 0,
                        DataInclusao = DateTime.Now.ToString(),
                        IdEmpresa = ((strIdEmpresa != null) && (strIdEmpresa.Trim() != "")) ? Convert.ToInt32(strIdEmpresa.Trim()) : 0
                    };
                    objSigeBugs.Salvar(objSigeBugs, objSigeBugs.IdBugs);
                    try
                    {
                        EnviarEmlComBug(objSigeBugs.NumErro.ToString().Trim(), objSigeBugs.DescErro.Trim(), objSigeBugs.IdSistema.ToString().Trim(), objSigeBugs.NomeTela, objSigeBugs.NomeEvento, objSigeBugs.IdUsuarioInclusao.ToString().Trim(), objSigeBugs.DataInclusao.ToString().Trim(), strIdEmpresa, objSigeBugs.IdBugs.ToString().Trim());
                    }
                    catch
                    {
                    }
                }
            }
            catch
            {
            }
        }

        public int Salvar(ClsSigeBugs objSigeBugs, int id)
        {
            int num2;
            try
            {
                num2 = AcessoBD.InsertUpdateRegistro(objSigeBugs, id);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            return num2;
        }

        // Properties
        [AtributoBancoDados(AtributoBD = true)]
        public string DataAlteracao
        {
            get
            {
                return this._DataAlteracao;
            }
            set
            {
                this._DataAlteracao = value;
            }
        }

        [AtributoBancoDados(AtributoBD = true)]
        public string DataInclusao
        {
            get
            {
                return this._DataInclusao;
            }
            set
            {
                this._DataInclusao = value;
            }
        }

        [AtributoBancoDados(AtributoBD = true)]
        public string DescErro
        {
            get
            {
                return this._DescErro;
            }
            set
            {
                this._DescErro = value;
            }
        }

        [AtributoBancoDados(AtributoBD = true)]
        public int IdBugs
        {
            get
            {
                return this._IdBugs;
            }
            set
            {
                this._IdBugs = value;
            }
        }

        [AtributoBancoDados(AtributoBD = true)]
        public int IdEmpresa
        {
            get
            {
                return this._IdEmpresa;
            }
            set
            {
                this._IdEmpresa = value;
            }
        }

        [AtributoBancoDados(AtributoBD = true)]
        public int IdSistema
        {
            get
            {
                return this._IdSistema;
            }
            set
            {
                this._IdSistema = value;
            }
        }

        [AtributoBancoDados(AtributoBD = true)]
        public int IdUsuarioAlteracao
        {
            get
            {
                return this._IdUsuarioAlteracao;
            }
            set
            {
                this._IdUsuarioAlteracao = value;
            }
        }

        [AtributoBancoDados(AtributoBD = true)]
        public int IdUsuarioInclusao
        {
            get
            {
                return this._IdUsuarioInclusao;
            }
            set
            {
                this._IdUsuarioInclusao = value;
            }
        }

        [AtributoBancoDados(AtributoBD = true)]
        public string NomeEvento
        {
            get
            {
                return this._NomeEvento;
            }
            set
            {
                this._NomeEvento = value;
            }
        }

        [AtributoBancoDados(AtributoBD = true)]
        public string NomeTela
        {
            get
            {
                return this._NomeTela;
            }
            set
            {
                this._NomeTela = value;
            }
        }

        [AtributoBancoDados(AtributoBD = true)]
        public long NumErro
        {
            get
            {
                return this._NumErro;
            }
            set
            {
                this._NumErro = value;
            }
        }
    }
}
