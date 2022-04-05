using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Collections;
using System.Net.Mail;
using System.Net.Mime;
using System.Text.RegularExpressions;
using System.Net.Configuration;
using System.Configuration;
using System.Web.Configuration;
using System.Web;

namespace Framework.Seguranca
{
    public class ClsREDE
    {
        public ClsREDE()
        {

        }

        #region Método - Retorna o número do IP do computador do usuário na internet.
        /// <summary>
        /// Método - Retorna o número do IP do computador do usuário na internet.
        /// </summary>
        /// <returns></returns>
        public static string strIPUsuario()
        {
             //Conexão utilizando proxy
            string strIPUsuario = System.Web.HttpContext.Current.Request.
            ServerVariables["HTTP_X_FORWARDED_FOR"];


            if (strIPUsuario == null)
            {

                // Conexão sem utilizar proxy
                strIPUsuario = System.Web.HttpContext.Current.Request.
                ServerVariables["REMOTE_ADDR"];
            }
           
            return strIPUsuario;

        }
        #endregion

        #region Metódo que retorna o IP de até 20 caracteres do computador do usuário do site
        /// <summary>
        /// Metódo que retorna o IP de até 20 caracteres do computador do usuário do site
        /// </summary>
        /// <param name="hostname"></param>
        /// <returns></returns>
        public static string DoGetHostEntry(string hostname)
        {
            IPHostEntry host;
            string objStringBuilder = "";
            
            host = Dns.GetHostEntry(hostname);

            Console.WriteLine("GetHostEntry({0}) returns:", hostname);

            foreach (IPAddress ip in host.AddressList)
            {
                //Console.WriteLine("    {0}", ip);
                if (ip.ToString().Length <= 20)
                {
                    objStringBuilder = ip.ToString();
                    return ip.ToString();
                }
            }

            return objStringBuilder;
        }
        #endregion

        #region Método que retorna o padrão de funda da mensagem dos emails
        /// <summary>
        /// Método que retorna a URL da empresa
        /// </summary>
        /// <returns></returns>
        private string GetTemplateEmail(string strConteudoMensagem, string strTitle = "")
        {
            try
            {
                System.Text.StringBuilder strBody = new StringBuilder();

                strBody.Append("<html");
                strBody.Append("<head>");
                strBody.Append("<meta http-equiv='Content-Type' content='text/html; charset=utf-8' />");
                strBody.Append("<title>" + strTitle  + "</title>");
                strBody.Append("</head>");
                strBody.Append("<body style='margin-top:0; margin-left:0' >");
                strBody.Append("<table style='margin-top:0; margin-left:0'>");
                strBody.Append("<tr>");
                    strBody.Append("<td>");
                    strBody.Append("<img src='Cabecalho.png' width='700' height='58' /></td>");
                strBody.Append("</tr>");
                strBody.Append("<tr>");
                    strBody.Append("<td>");
                    strBody.Append("" + strConteudoMensagem + "");
                    strBody.Append("</td>");
                strBody.Append("</tr>");
                strBody.Append("<tr>");
                    strBody.Append("<td>");
                    strBody.Append("<img src='Rodape.png' width='700' height='58'/>");
                    strBody.Append("</td>");
                strBody.Append("</tr>");
                strBody.Append("</table>");
                strBody.Append("</body>");
                strBody.Append("</html>");



                return strBody.ToString();
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
        #endregion

        #region Método de envio de email
        /// <summary>
        /// Método de envio de email
        /// </summary>
        public bool SendEmail(string strEmailRemetente, string strEmailDestinatario, string strAssuntoMensagem, string strConteudoMensagem)
        {
            try
            {
                string SendersAddress = strEmailRemetente;
                string ReceiversAddress = strEmailDestinatario;

                SmtpClient smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    Credentials = new NetworkCredential("fernanda.passos.f@gmail.com", "(@)e(#)8313"),
                    Timeout = 3000
                };

                MailMessage message = new MailMessage(SendersAddress, ReceiversAddress, strAssuntoMensagem, strConteudoMensagem);
                smtp.Send(message);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
