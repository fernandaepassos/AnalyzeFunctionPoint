using System;
using System.Text;
using System.Web;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using OpenSmtp.Mail;
using System.IO;

namespace Framework.Reflection.RastrearExcecao
{
    public static class ToTrackException
    {
        // Methods
        private static string Cookies(HttpContext c)
        {
            StringBuilder builder = new StringBuilder();
            string[] allKeys = c.Request.Cookies.AllKeys;
            int length = allKeys.Length;
            for (int i = 0; i < length; i++)
            {
                builder.Append(string.Format("{0}: {1}", allKeys[i], c.Request.Cookies[allKeys[i]].Value));
            }
            return builder.ToString();
        }

        private static string Form(HttpContext c)
        {
            StringBuilder builder = new StringBuilder();
            NameValueCollection form = c.Request.Form;
            string[] allKeys = form.AllKeys;
            int length = allKeys.Length;
            for (int i = 0; i < length; i++)
            {
                builder.Append(string.Format("{0}: {1}", allKeys[i], form[allKeys[i]]));
            }
            return builder.ToString();
        }

        private static string Server(HttpContext c)
        {
            StringBuilder builder = new StringBuilder();
            NameValueCollection serverVariables = c.Request.ServerVariables;
            string[] allKeys = serverVariables.AllKeys;
            int length = allKeys.Length;
            for (int i = 0; i < length; i++)
            {
                builder.Append(string.Format("{0}: {1}", allKeys[i], serverVariables[allKeys[i]]));
            }
            return builder.ToString();
        }

        private static string Session(HttpContext c)
        {
            StringBuilder builder = new StringBuilder();
            int count = c.Session.Count;
            for (int i = 0; i < count; i++)
            {
                builder.Append(string.Format("{0}: {1}", c.Session.Keys[i], c.Session[i]));
            }
            return builder.ToString();
        }

        public static void ToTrack(Exception e)
        {
            HttpContext current = HttpContext.Current;
            string str = Session(current);
            string str2 = Cookies(current);
            string str3 = Server(current);
            string str4 = Form(current);
            string name = current.User.Identity.Name;
            StringBuilder builder = new StringBuilder();
            builder.Append(string.Format("*************************************************************INFORMACOES DO ERRO*************************************************************Mensagem: ------------{1}*************************************************************Fonte: ------------{2}*************************************************************Usuario: {0}------------{4}*************************************************************Informacoes do Servidor:------------------------------{6}*************************************************************Informacoes da Tela:------------------------{7}*************************************************************Rastro: ------------{3}*************************************************************Cookies:------------{5}", new object[] { name, e.Message, e.Source, e.StackTrace, str, str2, str3, str4 }));
            string str6 = "Não informado";
            if (HttpContext.Current.Session["TituloSistema"] != null)
            {
                str6 = HttpContext.Current.Session["TituloSistema"].ToString();
            }
            string str7 = Convert.ToString(DateTime.Now).Replace("/", "").Replace(":", "") + ".eml";
            Smtp smtp = new Smtp("smtp.sisclick.com.br", "suporte=sisclick.com.br", "sckeml10", 0x24b);
            MailMessage message = new MailMessage {
                From = new EmailAddress("suporte@sisclick.com.br", "Suporte - Sisclick"),
                Subject = str6 + " - sisclickErro " + str7,
                Body = builder.ToString()
            };
            message.To.Add(new EmailAddress("suporte@sisclick.com.br", "Suporte - Sisclick"));
            message.Save(@"C:\SisclickErro " + str7);
            try
            {
            }
            catch
            {
            }
        }
    }
}
