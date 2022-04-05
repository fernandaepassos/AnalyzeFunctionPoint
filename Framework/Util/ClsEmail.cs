using System;
using System.Collections;
using System.Net.Mail;
using System.Net.Mime;
using System.Net;
using System.Text.RegularExpressions;
using System.Net.Configuration;
using System.Configuration;
using System.Web.Configuration;
using System.Web;

namespace Framework.Util
{
    public class ClsEmail
    {
        // Fields
        private string strAssunto = "";
        private string strEmailAutenticacao = "";
        private string strEmailAutenticacaoSenha = "";
        private string strEmailDestinatario = "";
        private string strEmailDoInternauta = "";
        private string strEmailRemetente = "";
        private string strMensagem = "";
        private string strMensagemEmHtml = "";
        private string strNome = "";
        private string strNomeDoSistema = "";
        private string strTelefone = "";
        private string strUrlLogoSistema = "";
        private string strArrayPathAnexo = "";

        // Methods
        public bool EnviarEmail(out string strMensagemRetorno)
        {
            bool flag2;
            bool flag = true;
            strMensagemRetorno = "";
            try
            {
                if (!this.Validacao(out strMensagemRetorno))
                {
                    return false;
                }
                MailMessage message = new MailMessage(this.strEmailRemetente, this.strEmailDestinatario, this.strAssunto, this.strMensagemEmHtml.ToString().Trim());
                SmtpClient client = new SmtpClient("smtp.gmail.com", 0x24b)
                {
                    Credentials = new NetworkCredential(this.strEmailAutenticacao, this.strEmailAutenticacaoSenha),
                    EnableSsl = true
                };
                MailMessage message2 = new MailMessage
                {
                    From = new MailAddress(this.strEmailRemetente, this.strNomeDoSistema)
                };
                message2.To.Add(this.strEmailDestinatario);
                message2.Bcc.Add(this.strEmailAutenticacao);
                message2.Subject = this.strNomeDoSistema + " -  Mensagem de:" + this.strNome;
                message2.Body = this.strMensagemEmHtml.ToString().Trim();
                message2.IsBodyHtml = true;
                message2.Priority = MailPriority.High;

                //Verifica se existe url para enviar anexo, se sim, envia o anexo
                if (strArrayPathAnexo.Trim() != "")
                {
                    if (strArrayPathAnexo.Trim().Split(',').Length > 0)
                    {
                        for (int i = 0; i < strArrayPathAnexo.Trim().Split(',').Length; i++)
                        {
                            message2.Attachments.Add(new Attachment(strArrayPathAnexo.Trim().Split(',')[i]));
                        }
                    }
                }

                client.Send(message2);
                flag2 = flag;
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return flag2;
        }

        public string GetMsgHtml(SistemaOrigem enumSistema)
        {
            string str2;
            string str = "";
            try
            {
                object obj2;
                if (enumSistema == SistemaOrigem.SckAvaliacao)
                {
                    str = "<html xmlns='http://www.w3.org/1999/xhtml'> ";
                    str = ((((str + " <head>" + " <meta http-equiv='Content-Type' content='text/html; charset=utf-8' /> ") + " <title>.:: " + this.strNomeDoSistema + " ::.</title>") + " </head>" + " <body>") + " <table width='100%' border='0'>" + " <style>.fonttexto{font-family:verdana, Arial, Helvetica, sans-serif;font-size:14px;}</style>") + " <tr>" + " <td>";
                    if (this.strUrlLogoSistema.Trim() != "")
                    {
                        str = str + " <img width='200px' height='40px' src='" + this.strUrlLogoSistema + "'/><br/></td>";
                    }
                    obj2 = (str + " </tr>" + " <tr>") + " <td class='fonttexto'><p>" + this.strNomeDoSistema + " - E-mail da tela de Contato<br/></p> ";
                    str = (string.Concat(new object[] { obj2, " <br/> O contato ", this.strNome, " acessou o site ", this.strNomeDoSistema, " no dia ", DateTime.Now.ToString("dd/MM/yyyy").ToString(), " - ", DateTime.Now.Hour, ":", DateTime.Now.Minute, ":", DateTime.Now.Second, " e <br/> enviou os dados abaixo para contato: <br/><br/><hr/>" }) + " <br/> NOME: " + this.strNome + " ") + " <br/>";
                    if (this.strEmailDoInternauta.Trim() != "")
                    {
                        str = str + " <br/> EMAIL: " + this.strEmailDoInternauta + " ";
                    }
                    str = str + " <br/>";
                    if (this.strTelefone.Trim() != "")
                    {
                        str = str + " <br/> TELEFONE: " + this.strTelefone + " ";
                    }
                    str = str + " <br/>";
                    if (this.strAssunto.Trim() != "")
                    {
                        str = str + " <br/> ASSUNTO: " + this.strAssunto + " ";
                    }
                    str = str + " <br/>";
                    if (this.strMensagem.Trim() != "")
                    {
                        str = str + " <br/> MENSAGEM: " + this.strMensagem;
                    }
                    return (((((str + " </td>") + " </tr>" + " <tr>") + " <td class='fonttexto'>" + " </td>") + " </tr>" + " </table>") + " </body>" + " </html>");
                }
                if (enumSistema == SistemaOrigem.SckEcommerce)
                {
                    str = "<html xmlns='http://www.w3.org/1999/xhtml'> ";
                    str = ((((str + " <head>" + " <meta http-equiv='Content-Type' content='text/html; charset=utf-8' /> ") + " <title>.:: " + this.strNomeDoSistema + " ::.</title>") + " </head>" + " <body>") + " <table width='100%' border='0'>" + " <style>.fonttexto{font-family:verdana, Arial, Helvetica, sans-serif;font-size:14px;}</style>") + " <tr>" + " <td>";
                    if (this.strUrlLogoSistema.Trim() != "")
                    {
                        str = str + " <img  width='200px' height='40px' src='" + this.strUrlLogoSistema + "'/><br/></td>";
                    }
                    obj2 = (str + " </tr>" + " <tr>") + " <td class='fonttexto'><p>" + this.strNomeDoSistema + " - E-mail da tela de Contato<br/></p> ";
                    str = (string.Concat(new object[] { obj2, " <br/> O contato ", this.strNome, " acessou o site ", this.strNomeDoSistema, " no dia ", DateTime.Now.ToString("dd/MM/yyyy").ToString(), " - ", DateTime.Now.Hour, ":", DateTime.Now.Minute, ":", DateTime.Now.Second, " e <br/> enviou os dados abaixo para contato: <br/><br/><hr/>" }) + " <br/> NOME: " + this.strNome + " ") + " <br/>";
                    if (this.strEmailDoInternauta.Trim() != "")
                    {
                        str = str + " <br/> EMAIL: " + this.strEmailDoInternauta + " ";
                    }
                    str = str + " <br/>";
                    if (this.strTelefone.Trim() != "")
                    {
                        str = str + " <br/> TELEFONE: " + this.strTelefone + " ";
                    }
                    str = str + " <br/>";
                    if (this.strAssunto.Trim() != "")
                    {
                        str = str + " <br/> ASSUNTO: " + this.strAssunto + " ";
                    }
                    str = str + " <br/>";
                    if (this.strMensagem.Trim() != "")
                    {
                        str = str + " <br/> MENSAGEM: " + this.strMensagem;
                    }
                    return (((((str + " </td>") + " </tr>" + " <tr>") + " <td class='fonttexto'>" + " </td>") + " </tr>" + " </table>") + " </body>" + " </html>");
                }
                str2 = "";
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            return str2;
        }

        private bool Validacao(out string strMensagemRetorno)
        {
            bool flag;
            strMensagemRetorno = "";
            try
            {
                if (string.IsNullOrEmpty(this.strEmailRemetente.Trim()))
                {
                    strMensagemRetorno = "Informe o e-mail do remetente.";
                    return false;
                }
                if (string.IsNullOrEmpty(this.strEmailDestinatario.Trim()))
                {
                    strMensagemRetorno = "Informe o e-mail do destinatário.";
                    return false;
                }
                if (string.IsNullOrEmpty(this.strAssunto.Trim()))
                {
                    strMensagemRetorno = "Informe o assunto.";
                    return false;
                }
                if (string.IsNullOrEmpty(this.strMensagem))
                {
                    strMensagemRetorno = "Informe a mensagem.";
                    return false;
                }
                if (string.IsNullOrEmpty(this.strNome))
                {
                    strMensagemRetorno = "Informe o nome.";
                    return false;
                }
                if (string.IsNullOrEmpty(this.strNomeDoSistema))
                {
                    strMensagemRetorno = "Informe o nome do sistema.";
                    return false;
                }
                if (string.IsNullOrEmpty(this.strUrlLogoSistema))
                {
                    strMensagemRetorno = "Informe a url da logomarca do sistema.";
                    return false;
                }
                flag = true;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            return flag;
        }

        // Properties
        public string Assunto
        {
            get
            {
                return this.strAssunto;
            }
            set
            {
                this.strAssunto = value;
            }
        }

        public string EmailAutenticacao
        {
            get
            {
                return this.strEmailAutenticacao;
            }
            set
            {
                this.strEmailAutenticacao = value;
            }
        }

        public string EmailAutenticacaoSenha
        {
            get
            {
                return this.strEmailAutenticacaoSenha;
            }
            set
            {
                this.strEmailAutenticacaoSenha = value;
            }
        }

        public string EmailDestinatario
        {
            get
            {
                return this.strEmailDestinatario;
            }
            set
            {
                this.strEmailDestinatario = value;
            }
        }

        public string EmailDoInternauta
        {
            get
            {
                return this.strEmailDoInternauta;
            }
            set
            {
                this.strEmailDoInternauta = value;
            }
        }

        public string EmailRemetente
        {
            get
            {
                return this.strEmailRemetente;
            }
            set
            {
                this.strEmailRemetente = value;
            }
        }

        public string Mensagem
        {
            get
            {
                return this.strMensagem;
            }
            set
            {
                this.strMensagem = value;
            }
        }

        public string MensagemEmHtml
        {
            get
            {
                return this.strMensagemEmHtml;
            }
            set
            {
                this.strMensagemEmHtml = value;
            }
        }

        public string Nome
        {
            get
            {
                return this.strNome;
            }
            set
            {
                this.strNome = value;
            }
        }

        public string NomeDoSistema
        {
            get
            {
                return this.strNomeDoSistema;
            }
            set
            {
                this.strNomeDoSistema = value;
            }
        }

        public string Telefone
        {
            get
            {
                return this.strTelefone;
            }
            set
            {
                this.strTelefone = value;
            }
        }

        public string UrlLogoSistema
        {
            get
            {
                return this.strUrlLogoSistema;
            }
            set
            {
                this.strUrlLogoSistema = value;
            }
        }

        /// <summary>
        /// String com caminho dos anexos - Exemplo: "C:\Temp\File1.doc,C:\Temp\File2.doc,C:\Temp\File3.doc,C:\Temp\File4.doc,C:\Temp\File5.doc,C:\Temp\File6.doc"
        /// </summary>
        public string ArrayPathAnexo
        {
            get
            {
                return this.strArrayPathAnexo;
            }
            set
            {
                this.strArrayPathAnexo = value;
            }
        }

        // Nested Types
        public enum SistemaOrigem
        {
            SckAvaliacao,
            SckEcommerce
        }
    }
}
