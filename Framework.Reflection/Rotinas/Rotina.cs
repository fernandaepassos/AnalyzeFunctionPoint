using System;
using System.Configuration;
using OpenSmtp.Mail;
using System.Collections;
using System.IO;
using System.Data;
using Framework.Reflection.AcessoBancoDados;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;
using System.Web;

namespace Framework.Reflection.Rotinas
{
    public abstract class Rotina
    {
        // Methods
        protected Rotina()
        {
        }

        public double ArredondaDecimais(double valor, int qtdeCasasDecimais)
        {
            string format = "N" + Convert.ToString(qtdeCasasDecimais);
            return Convert.ToDouble(Math.Round(valor, qtdeCasasDecimais).ToString(format));
        }

        public double ArredondaDuasCasas(double valor)
        {
            return this.ArredondaDecimais(valor, 2);
        }

        [DllImport("DllInscE32.dll")]
        public static extern int ConsisteInscricaoEstadual(string cInsc, string cUF);
        public int ConvertToInt32(object valorInt)
        {
            if (valorInt != null)
            {
                if (valorInt == DBNull.Value)
                {
                    return 0;
                }
                if (this.IsInteger(valorInt.ToString()))
                {
                    return Convert.ToInt32(valorInt);
                }
            }
            return 0;
        }

        public void EnviarEmail(string smtp, string usuario, string senha, int porta, string emailRemetente, string nomeRemetente, string assunto, string mensagem, string emailDestinatario)
        {
            try
            {
                Smtp smtp2 = new Smtp(smtp, usuario, senha, porta);
                MailMessage msg = new MailMessage
                {
                    From = new EmailAddress(emailRemetente, nomeRemetente),
                    Subject = assunto,
                    Body = mensagem
                };
                msg.To.Add(new EmailAddress(emailDestinatario));
                smtp2.SendMail(msg);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public void EnviarEmail(string smtp, string usuario, string senha, int porta, string emailRemetente, string nomeRemetente, string assunto, string mensagem, string emailDestinatario, string emailCopia)
        {
            try
            {
                Smtp smtp2 = new Smtp(smtp, usuario, senha, porta);
                MailMessage msg = new MailMessage
                {
                    From = new EmailAddress(emailRemetente, nomeRemetente),
                    Subject = assunto,
                    Body = mensagem
                };
                msg.To.Add(new EmailAddress(emailDestinatario));
                msg.CC.Add(new EmailAddress(emailCopia));
                smtp2.SendMail(msg);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public void EnviarEmail(string smtp, string usuario, string senha, int porta, string emailRemetente, string nomeRemetente, string assunto, string mensagem, string emailDestinatario, string emailCopia, string[] anexos)
        {
            try
            {
                int num;
                Smtp smtp2 = new Smtp(smtp, usuario, senha, porta);
                MailMessage msg = new MailMessage
                {
                    From = new EmailAddress(emailRemetente, nomeRemetente),
                    Subject = assunto,
                    Body = mensagem
                };
                msg.To.Add(new EmailAddress(emailDestinatario));
                msg.CC.Add(new EmailAddress(emailCopia));
                if (anexos.Length > 0)
                {
                    for (num = 0; anexos.Length > num; num++)
                    {
                        msg.AddAttachment(new Attachment(anexos.GetValue(num).ToString()));
                    }
                }
                smtp2.SendMail(msg);
                if (anexos.Length > 0)
                {
                    for (num = 0; anexos.Length > num; num++)
                    {
                        File.Delete(anexos.GetValue(num).ToString());
                    }
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public void EnviarEmail(string smtp, string usuario, string senha, int porta, string emailRemetente, string nomeRemetente, string assunto, string mensagem, string emailDestinatario, string[] emailCopia, string[] anexos)
        {
            try
            {
                int num2;
                Smtp smtp2 = new Smtp(smtp, usuario, senha, porta);
                MailMessage msg = new MailMessage
                {
                    From = new EmailAddress(emailRemetente, nomeRemetente),
                    Subject = assunto,
                    Body = mensagem
                };
                msg.To.Add(new EmailAddress(emailDestinatario));
                if (emailCopia.Length > 0)
                {
                    for (int i = 0; i < emailCopia.Length; i++)
                    {
                        msg.CC.Add(new EmailAddress(emailCopia.GetValue(i).ToString()));
                    }
                }
                if (anexos.Length > 0)
                {
                    for (num2 = 0; anexos.Length > num2; num2++)
                    {
                        msg.AddAttachment(new Attachment(anexos.GetValue(num2).ToString()));
                    }
                }
                smtp2.SendMail(msg);
                if (anexos.Length > 0)
                {
                    for (num2 = 0; anexos.Length > num2; num2++)
                    {
                        File.Delete(anexos.GetValue(num2).ToString());
                    }
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public void EnviarEmailNoReply(string assunto, string mensagem, string emailDestinatario)
        {
            try
            {
                Smtp smtp = new Smtp("smtp.sisclick.com.br", "no-reply=sisclick.com.br", "sckeml10", 0x24b);
                MailMessage msg = new MailMessage
                {
                    From = new EmailAddress("no-reply@sisclick.com.br", "no-reply@sisclick.com.br"),
                    Subject = assunto
                };
                mensagem = mensagem + "Este e-mail foi enviado automaticamente. Não responda a esta mensagem.";
                msg.Body = mensagem;
                msg.To.Add(new EmailAddress(emailDestinatario));
                smtp.SendMail(msg);
            }
            catch
            {
                throw new Exception("O sistema não conseguiu enviar o e-mail automaticamente.");
            }
        }

        public void EnviarEmailNoReply(string assunto, string mensagem, string emailDestinatario, string emailCopia)
        {
            try
            {
                Smtp smtp = new Smtp("smtp.sisclick.com.br", "no-reply=sisclick.com.br", "sckeml10", 0x24b);
                MailMessage msg = new MailMessage
                {
                    From = new EmailAddress("no-reply@sisclick.com.br", "no-reply@sisclick.com.br"),
                    Subject = assunto
                };
                mensagem = mensagem + "Este e-mail foi enviado automaticamente. Não responda a esta mensagem.";
                msg.Body = mensagem;
                msg.To.Add(new EmailAddress(emailDestinatario));
                msg.CC.Add(new EmailAddress(emailCopia));
                smtp.SendMail(msg);
            }
            catch
            {
                throw new Exception("O sistema não conseguiu enviar o e-mail automaticamente.");
            }
        }

        public void EnviarEmailNoReply(string assunto, string mensagem, string emailDestinatario, string emailCopia, string[] anexos)
        {
            try
            {
                int num;
                Smtp smtp = new Smtp("smtp.sisclick.com.br", "no-reply=sisclick.com.br", "sckeml10", 0x24b);
                MailMessage msg = new MailMessage
                {
                    From = new EmailAddress("no-reply@sisclick.com.br", "no-reply@sisclick.com.br"),
                    Subject = assunto
                };
                mensagem = mensagem + "Este e-mail foi enviado automaticamente. Não responda a esta mensagem.";
                msg.Body = mensagem;
                msg.To.Add(new EmailAddress(emailDestinatario));
                msg.CC.Add(new EmailAddress(emailCopia));
                if (anexos.Length > 0)
                {
                    for (num = 0; anexos.Length > num; num++)
                    {
                        msg.AddAttachment(new Attachment(anexos.GetValue(num).ToString()));
                    }
                }
                smtp.SendMail(msg);
                if (anexos.Length > 0)
                {
                    for (num = 0; anexos.Length > num; num++)
                    {
                        File.Delete(anexos.GetValue(num).ToString());
                    }
                }
            }
            catch
            {
                throw new Exception("O sistema não conseguiu enviar o e-mail automaticamente.");
            }
        }

        public void EnviarEmailNoReply(string assunto, string mensagem, string emailDestinatario, string[] emailCopia, string[] anexos)
        {
            try
            {
                int num2;
                Smtp smtp = new Smtp("smtp.sisclick.com.br", "no-reply=sisclick.com.br", "sckeml10", 0x24b);
                MailMessage msg = new MailMessage
                {
                    From = new EmailAddress("no-reply@sisclick.com.br", "no-reply@sisclick.com.br"),
                    Subject = assunto
                };
                mensagem = mensagem + "Este e-mail foi enviado automaticamente. Não responda a esta mensagem.";
                msg.Body = mensagem;
                msg.To.Add(new EmailAddress(emailDestinatario));
                if (emailCopia.Length > 0)
                {
                    for (int i = 0; i < emailCopia.Length; i++)
                    {
                        msg.CC.Add(new EmailAddress(emailCopia.GetValue(i).ToString()));
                    }
                }
                if (anexos.Length > 0)
                {
                    for (num2 = 0; anexos.Length > num2; num2++)
                    {
                        msg.AddAttachment(new Attachment(anexos.GetValue(num2).ToString()));
                    }
                }
                smtp.SendMail(msg);
                if (anexos.Length > 0)
                {
                    for (num2 = 0; anexos.Length > num2; num2++)
                    {
                        File.Delete(anexos.GetValue(num2).ToString());
                    }
                }
            }
            catch
            {
                throw new Exception("O sistema não conseguiu enviar o e-mail automaticamente.");
            }
        }

        public string Extenso_Valor(decimal pdbl_Valor)
        {
            string param = "";
            string s = "";
            string str3 = "";
            string str4 = "";
            decimal d = 0M;
            decimal num2 = 0M;
            int num3 = 0;
            bool flag = false;
            bool flag2 = false;
            bool flag3 = false;
            bool flag4 = false;
            if ((pdbl_Valor == 0M) || (pdbl_Valor <= 0M))
            {
                param = "Verificar se há valor negativo ou nada foi informado";
            }
            if (pdbl_Valor > 9999999999.99M)
            {
                param = "Valor não suportado pela Função";
            }
            else
            {
                d = pdbl_Valor - ((int)pdbl_Valor);
                num2 = (int)pdbl_Valor;
                if (num2 > 0M)
                {
                    if (num2 > 999M)
                    {
                        flag3 = true;
                    }
                    if (num2 > 999999M)
                    {
                        flag2 = true;
                        flag3 = false;
                    }
                    if (num2 > 999999999M)
                    {
                        flag3 = false;
                        flag2 = false;
                        flag = true;
                    }
                    for (int i = num2.ToString().Trim().Length - 1; i >= 0; i--)
                    {
                        string introduced16 = num2.ToString().Trim();
                        s = this.Mid(introduced16, (num2.ToString().Trim().Length - i) - 1, 1);
                        switch (i)
                        {
                            case 0:
                            case 3:
                            case 6:
                                if ((int.Parse(s) <= 0) || flag4)
                                {
                                    goto Label_0445;
                                }
                                if (((this.Right(param, 5).Trim() != "entos") && (this.Right(param, 3).Trim() != "nte")) && !(this.Right(param, 3).Trim() == "nta"))
                                {
                                    goto Label_0428;
                                }
                                param = param + " e ";
                                goto Label_0436;

                            case 1:
                            case 4:
                            case 7:
                                {
                                    if (int.Parse(s) <= 0)
                                    {
                                        continue;
                                    }
                                    string introduced18 = num2.ToString().Trim();
                                    str4 = this.Mid(introduced18, (num2.ToString().Trim().Length - i) - 1, 2);
                                    if ((int.Parse(str4) <= 10) || (int.Parse(str4) >= 20))
                                    {
                                        goto Label_033A;
                                    }
                                    param = param + ((this.Right(param, 5).Trim() == "entos") ? " e " : " ") + this.fcn_Numero_Dezena0(this.Right(str4, 1));
                                    flag4 = true;
                                    goto Label_037A;
                                }
                            case 2:
                            case 5:
                            case 8:
                                {
                                    if (int.Parse(s) <= 0)
                                    {
                                        continue;
                                    }
                                    string introduced17 = num2.ToString().Trim();
                                    str3 = this.Mid(introduced17, (num2.ToString().Trim().Length - i) - 1, 3);
                                    if ((int.Parse(str3) <= 100) || (int.Parse(str3) >= 200))
                                    {
                                        break;
                                    }
                                    param = param + " Cento e ";
                                    goto Label_0268;
                                }
                            case 9:
                                {
                                    param = this.fcn_Numero_Unidade(s) + ((int.Parse(s) > 1) ? " Bilhões de" : " Bilhão de");
                                    flag = true;
                                    continue;
                                }
                            default:
                                {
                                    continue;
                                }
                        }
                        param = param + " " + this.fcn_Numero_Centena(s);
                    Label_0268:
                        switch (num3)
                        {
                            case 8:
                                flag2 = true;
                                break;

                            case 5:
                                flag3 = true;
                                break;
                        }
                        continue;
                    Label_033A:
                        param = param + ((this.Right(param, 5).Trim() == "entos") ? " e " : " ") + this.fcn_Numero_Dezena1(this.Left(str4, 1));
                        flag4 = false;
                    Label_037A:
                        if (num3 == 7)
                        {
                            flag2 = true;
                        }
                        else if (num3 == 4)
                        {
                            flag3 = true;
                        }
                        continue;
                    Label_0428:
                        param = param + " ";
                    Label_0436:
                        param = param + this.fcn_Numero_Unidade(s);
                    Label_0445:
                        if ((i == 6) && (flag2 || (int.Parse(s) > 0)))
                        {
                            param = param + (((int.Parse(s) == 1) && !flag4) ? " Milhão de" : " Milhões de");
                            flag2 = true;
                        }
                        if ((i == 3) && (flag3 || (int.Parse(s) > 0)))
                        {
                            param = param + " Mil";
                            flag3 = true;
                        }
                        if (i == 0)
                        {
                            if (((flag && !flag2) && (!flag3 && (this.Right(num2.ToString().Trim(), 3) == "0"))) || (((!flag && flag2) && !flag3) && (this.Right(num2.ToString().Trim(), 3) == "0")))
                            {
                                param = param + " de ";
                            }
                            param = param + ((int.Parse(num2.ToString()) > 1) ? " Reais " : " Real ");
                        }
                        flag4 = false;
                    }
                }
                if (d > 0M)
                {
                    if ((decimal.Parse(d.ToString()) > 0M) && (d < 0.1M))
                    {
                        s = this.Right(decimal.Round(d, 2).ToString().Trim(), 1);
                        param = param + ((decimal.Parse(d.ToString()) > 0M) ? " e " : " ") + this.fcn_Numero_Unidade(s) + ((decimal.Parse(s) > 1M) ? " Centavos " : " Centavo ");
                    }
                    else if ((d > 0.1M) && (d < 0.2M))
                    {
                        decimal num6 = decimal.Round(d, 2) - 0.1M;
                        s = this.Right(num6.ToString().Trim(), 1);
                        param = param + ((decimal.Parse(d.ToString()) > 0M) ? " e " : " ") + this.fcn_Numero_Dezena0(s) + " Centavos ";
                    }
                    else if (d > 0M)
                    {
                        s = this.Right(d.ToString().Trim(), 2);
                        param = param + ((int.Parse(s) > 0) ? " e " : "") + this.fcn_Numero_Dezena1(this.Left(s, 1));
                        if (d.ToString().Trim().Length > 2)
                        {
                            s = this.Right(decimal.Round(d, 2).ToString().Trim(), 1);
                            if (int.Parse(s) > 0)
                            {
                                if (this.Mid(param.Trim(), param.Trim().Length - 2, 1) == "e")
                                {
                                    param = param + " " + this.fcn_Numero_Unidade(s);
                                }
                                else
                                {
                                    param = param + " e " + this.fcn_Numero_Unidade(s);
                                }
                            }
                        }
                        param = param + " Centavos ";
                    }
                }
                if (num2 < 1M)
                {
                    param = this.Mid(param.Trim(), 2, param.Trim().Length - 2);
                }
            }
            return param.Trim();
        }

        private string fcn_Numero_Centena(string pstrCentena)
        {
            ArrayList list = new ArrayList();
            list.Add("Cem");
            list.Add("Duzentos");
            list.Add("Trezentos");
            list.Add("Quatrocentos");
            list.Add("Quinhentos");
            list.Add("Seiscentos");
            list.Add("Setecentos");
            list.Add("Oitocentos");
            list.Add("Novecentos");
            return list[int.Parse(pstrCentena) - 1].ToString();
        }

        private string fcn_Numero_Dezena0(string pstrDezena0)
        {
            ArrayList list = new ArrayList();
            list.Add("Onze");
            list.Add("Doze");
            list.Add("Treze");
            list.Add("Quatorze");
            list.Add("Quinze");
            list.Add("Dezesseis");
            list.Add("Dezessete");
            list.Add("Dezoito");
            list.Add("Dezenove");
            return list[int.Parse(pstrDezena0) - 1].ToString();
        }

        private string fcn_Numero_Dezena1(string pstrDezena1)
        {
            ArrayList list = new ArrayList();
            list.Add("Dez");
            list.Add("Vinte");
            list.Add("Trinta");
            list.Add("Quarenta");
            list.Add("Cinquenta");
            list.Add("Sessenta");
            list.Add("Setenta");
            list.Add("Oitenta");
            list.Add("Noventa");
            return list[int.Parse(pstrDezena1) - 1].ToString();
        }

        private string fcn_Numero_Unidade(string pstrUnidade)
        {
            ArrayList list = new ArrayList();
            list.Add("Um");
            list.Add("Dois");
            list.Add("Três");
            list.Add("Quatro");
            list.Add("Cinco");
            list.Add("Seis");
            list.Add("Sete");
            list.Add("Oito");
            list.Add("Nove");
            return list[int.Parse(pstrUnidade) - 1].ToString();
        }

        public byte FieldByte(object field)
        {
            return ((field == DBNull.Value) ? ((byte)0) : Convert.ToByte(field));
        }

        public double FieldDouble(object field)
        {
            return ((field == DBNull.Value) ? 0.0 : Convert.ToDouble(field));
        }

        public float FieldFloat(object field)
        {
            float num;
            if ((field != DBNull.Value) && float.TryParse(Convert.ToString(field), out num))
            {
                return num;
            }
            return 0f;
        }

        public int FieldInt(object field)
        {
            return ((field == DBNull.Value) ? 0 : Convert.ToInt32(field));
        }

        public long FieldInt64(object field)
        {
            return ((field == DBNull.Value) ? 0L : Convert.ToInt64(field));
        }

        public short FieldShort(object field)
        {
            string str = this.FieldString(field);
            return (string.IsNullOrEmpty(str) ? ((short)0) : Convert.ToInt16(str));
        }

        public float FieldSingle(object field)
        {
            return ((field == DBNull.Value) ? 0f : Convert.ToSingle(field));
        }

        public string FieldString(object field)
        {
            return ((field == DBNull.Value) ? "" : Convert.ToString(field));
        }

        public string FormatoData(DateTime data)
        {
            string str;
            try
            {
                if (AcessoBD.DefiniTipoBancoDados() == "SQLSERVER")
                {
                    return ("'" + data.ToString("MM/dd/yyyy HH:mm:ss") + "'");
                }
                if (AcessoBD.DefiniTipoBancoDados() != "ORACLE")
                {
                    throw new Exception("Atenção! Não foi possível conectar ao banco de dados. Comunique ao Administrador do sistema!");
                }
                str = "to_date('" + data.ToString() + "','DD/MM/YYYY HH24:MI:SS')";
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            return str;
        }

        public int getLength(string valor)
        {
            if (valor == null)
            {
                return 0;
            }
            return valor.Length;
        }

        public int getQtdeCasasDecimais(double valor)
        {
            string str = valor.ToString();
            if (!this.PossuiAlfas(str))
            {
                return 0;
            }
            int num = 0;
            bool flag = false;
            for (int i = str.Length - 1; i >= 0; i--)
            {
                char c = str[i];
                if (!char.IsDigit(c))
                {
                    flag = true;
                    break;
                }
                num++;
            }
            if (!flag)
            {
                num = 0;
            }
            return num;
        }

        public bool IsDataValida(string data)
        {
            try
            {
                this.ValidaData(data);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool IsInteger(string valor)
        {
            if (string.IsNullOrEmpty(valor))
            {
                return false;
            }
            for (int i = 0; i < valor.Length; i++)
            {
                char c = valor[i];
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }
            return true;
        }

        public bool IsNullOrEmpty(string value)
        {
            return ((value == null) || string.IsNullOrEmpty(value.Trim()));
        }

        public string Left(string param, int length)
        {
            if (param == "")
            {
                return "";
            }
            return param.Substring(0, length);
        }

        public string MaxLinhaInicial()
        {
            string str;
            try
            {
                if (HttpContext.Current.Session["MaxLinhaInicial"] != null)
                {
                    if (HttpContext.Current.Session["MaxLinhaInicial"].ToString() == "1")
                    {
                        if (AcessoBD.DefiniTipoBancoDados() == "SQLSERVER")
                        {
                            return " TOP 100 ";
                        }
                        if (AcessoBD.DefiniTipoBancoDados() == "ORACLE")
                        {
                            return " ROW 100 ";
                        }
                        return "";
                    }
                    return "";
                }
                str = "";
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            return str;
        }

        public string Mid(string param, int startIndex)
        {
            return param.Substring(startIndex);
        }

        public string Mid(string param, int startIndex, int length)
        {
            return param.Substring(startIndex, length);
        }

        public bool PossuiAlfas(string valor)
        {
            if (valor == null)
            {
                return false;
            }
            for (int i = 0; i < valor.Length; i++)
            {
                char c = valor[i];
                if (!char.IsDigit(c))
                {
                    return true;
                }
            }
            return false;
        }

        public string RemoveAcentos(string stringComAcento)
        {
            stringComAcento = stringComAcento.Replace("á", "a");
            stringComAcento = stringComAcento.Replace("é", "e");
            stringComAcento = stringComAcento.Replace("í", "i");
            stringComAcento = stringComAcento.Replace("ó", "o");
            stringComAcento = stringComAcento.Replace("ú", "u");
            stringComAcento = stringComAcento.Replace("Á", "A");
            stringComAcento = stringComAcento.Replace("È", "E");
            stringComAcento = stringComAcento.Replace("Í", "I");
            stringComAcento = stringComAcento.Replace("Ó", "O");
            stringComAcento = stringComAcento.Replace("Ú", "U");
            stringComAcento = stringComAcento.Replace("á", "a");
            stringComAcento = stringComAcento.Replace("ê", "e");
            stringComAcento = stringComAcento.Replace("í", "i");
            stringComAcento = stringComAcento.Replace("ó", "o");
            stringComAcento = stringComAcento.Replace("ú", "u");
            stringComAcento = stringComAcento.Replace("À", "A");
            stringComAcento = stringComAcento.Replace("È", "E");
            stringComAcento = stringComAcento.Replace("Ì", "I");
            stringComAcento = stringComAcento.Replace("Ò", "O");
            stringComAcento = stringComAcento.Replace("Ù", "U");
            stringComAcento = stringComAcento.Replace("à", "a");
            stringComAcento = stringComAcento.Replace("õ", "o");
            stringComAcento = stringComAcento.Replace("À", "A");
            stringComAcento = stringComAcento.Replace("Ò", "O");
            stringComAcento = stringComAcento.Replace("ç", "c");
            stringComAcento = stringComAcento.Replace("Ç", "C");
            stringComAcento = stringComAcento.Replace("ù", "u");
            stringComAcento = stringComAcento.Replace("Ù", "U");
            stringComAcento = stringComAcento.Replace("à", "a");
            stringComAcento = stringComAcento.Replace("è", "e");
            stringComAcento = stringComAcento.Replace("ì", "i");
            stringComAcento = stringComAcento.Replace("ò", "o");
            stringComAcento = stringComAcento.Replace("ù", "u");
            stringComAcento = stringComAcento.Replace("À", "A");
            stringComAcento = stringComAcento.Replace("È", "E");
            stringComAcento = stringComAcento.Replace("Ì", "I");
            stringComAcento = stringComAcento.Replace("Ò", "O");
            stringComAcento = stringComAcento.Replace("Ù", "U");
            stringComAcento = stringComAcento.Replace("'", "''");
            stringComAcento = stringComAcento.Replace("/", "");
            stringComAcento = stringComAcento.Replace(@"\", "");
            stringComAcento = stringComAcento.Replace("Ç", "");
            stringComAcento = stringComAcento.Replace("Â", "");
            return stringComAcento;
        }

        public string RemoverEspacos(string stringComEspaco)
        {
            if (string.IsNullOrEmpty(stringComEspaco))
            {
                return "";
            }
            return stringComEspaco.Replace(" ", "");
        }

        public string RetiraAlfas(string valor)
        {
            if (string.IsNullOrEmpty(valor))
            {
                valor = "";
            }
            string str = "";
            for (int i = 0; i < valor.Length; i++)
            {
                char c = valor[i];
                if (char.IsDigit(c))
                {
                    str = str + c;
                }
            }
            return str;
        }

        public string RetiraDDD(string telefone)
        {
            if (telefone == null)
            {
                telefone = "";
            }
            telefone = this.RetiraAlfas(telefone);
            if (telefone.Length >= 8)
            {
                telefone = telefone.Substring(telefone.Length - 8, 8);
            }
            return telefone;
        }

        public string RetiraMascaraCnpjCpf(string valor)
        {
            if (valor == null)
            {
                valor = "";
            }
            string str = "";
            for (int i = 0; i < valor.Length; i++)
            {
                char ch = valor[i];
                if (((ch != '.') && (ch != '/')) && (ch != '-'))
                {
                    str = str + ch;
                }
            }
            return str;
        }

        public string RetornaDDD(string telefone)
        {
            if (telefone == null)
            {
                telefone = "";
            }
            telefone = this.RetiraAlfas(telefone);
            switch (telefone.Length)
            {
                case 10:
                    return ("0" + this.SubString(telefone, 2));

                case 11:
                    return this.SubString(telefone, 3);
            }
            return "";
        }

        public string Right(string param, int length)
        {
            if (param == "")
            {
                return "";
            }
            return param.Substring(param.Length - length, length);
        }

        public string SubString(string valor, int tamanho)
        {
            if (valor == null)
            {
                valor = "";
            }
            string str = "";
            if (valor.Length <= tamanho)
            {
                return valor;
            }
            if ((valor.Length > 0) && (tamanho > 0))
            {
                str = valor.Substring(0, tamanho);
            }
            return str;
        }

        public string SubString(string valor, int indiceInicial, int tamanho)
        {
            if (valor == null)
            {
                return "";
            }
            string str = "";
            if (((valor.Length - 1) >= indiceInicial) && (indiceInicial >= 0))
            {
                str = valor.Substring(indiceInicial);
                str = this.SubString(str, tamanho);
            }
            return str;
        }

        public bool ValidaCnpj(string cnpj)
        {
            int num3;
            char ch;
            int[] numArray = new int[] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] numArray2 = new int[] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            cnpj = cnpj.Trim();
            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");
            if (cnpj.Length != 14)
            {
                return false;
            }
            string str2 = cnpj.Substring(0, 12);
            int num = 0;
            for (num3 = 0; num3 < 12; num3++)
            {
                ch = str2[num3];
                num += int.Parse(ch.ToString()) * numArray[num3];
            }
            int num2 = num % 11;
            if (num2 < 2)
            {
                num2 = 0;
            }
            else
            {
                num2 = 11 - num2;
            }
            string str = num2.ToString();
            str2 = str2 + str;
            num = 0;
            for (num3 = 0; num3 < 13; num3++)
            {
                ch = str2[num3];
                num += int.Parse(ch.ToString()) * numArray2[num3];
            }
            num2 = num % 11;
            if (num2 < 2)
            {
                num2 = 0;
            }
            else
            {
                num2 = 11 - num2;
            }
            str = str + num2.ToString();
            return cnpj.EndsWith(str);
        }

        public bool ValidaCpf(string cpf)
        {
            int num3;
            char ch;
            int[] numArray = new int[] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] numArray2 = new int[] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
            {
                return false;
            }
            string str = cpf.Substring(0, 9);
            int num = 0;
            for (num3 = 0; num3 < 9; num3++)
            {
                ch = str[num3];
                num += int.Parse(ch.ToString()) * numArray[num3];
            }
            int num2 = num % 11;
            if (num2 < 2)
            {
                num2 = 0;
            }
            else
            {
                num2 = 11 - num2;
            }
            string str2 = num2.ToString();
            str = str + str2;
            num = 0;
            for (num3 = 0; num3 < 10; num3++)
            {
                ch = str[num3];
                num += int.Parse(ch.ToString()) * numArray2[num3];
            }
            num2 = num % 11;
            if (num2 < 2)
            {
                num2 = 0;
            }
            else
            {
                num2 = 11 - num2;
            }
            str2 = str2 + num2.ToString();
            return cpf.EndsWith(str2);
        }

        public void ValidaData(string data)
        {
            try
            {
                DateTime time = Convert.ToDateTime(data.Replace("'", "''"));
                DateTime time2 = Convert.ToDateTime("01/01/1900 00:00:00");
                if (time.CompareTo(time2) < 0)
                {
                    throw new Exception("Data inválida!");
                }
            }
            catch
            {
                throw new Exception("Data inválida!");
            }
        }

        public bool ValidaIEstadual(string uf, string iEstadual)
        {
            int num4;
            string str = iEstadual.Replace(".", "").Replace("/", "").Replace("-", "");
            int num = 0;
            int num2 = 0;
            int num3 = 0;
            string str2 = "";
            bool flag = true;
            bool flag2 = false;
            if (uf.Trim().ToUpper() == "AC")
            {
                str = str.PadLeft(9, '0');
                str2 = "98765432";
                if (str.Substring(0, 2).CompareTo("01") != 0)
                {
                    flag = false;
                }
                else
                {
                    for (num4 = 0; num4 <= 7; num4++)
                    {
                        num += Convert.ToInt32(str.Substring(num4, 1)) * Convert.ToInt32(str2.Substring(num4, 1));
                    }
                    num2 = num % 11;
                    if ((11 - num2) > 1)
                    {
                        num3 = 0;
                    }
                    else
                    {
                        num3 = 11 - num2;
                    }
                    if (str.Substring(8, 1) != num3.ToString())
                    {
                        flag = false;
                    }
                }
                flag2 = true;
            }
            if (uf.Trim().ToUpper() == "AL")
            {
                str = str.PadLeft(9, '0');
                str2 = "98765432";
                if (str.Substring(0, 2).CompareTo("24") != 0)
                {
                    flag = false;
                }
                else
                {
                    for (num4 = 0; num4 <= 7; num4++)
                    {
                        num += Convert.ToInt32(str.Substring(num4, 1)) * Convert.ToInt32(str2.Substring(num4, 1));
                    }
                    num *= 10;
                    num2 = (num % 11) * 11;
                    if ((num - num2) == 10)
                    {
                        num3 = 0;
                    }
                    if (str.Substring(8, 1) != num3.ToString())
                    {
                        flag = false;
                    }
                }
                flag2 = true;
            }
            if (uf.Trim().ToUpper() == "AP")
            {
                str = str.PadLeft(9, '0');
                str2 = "98765432";
                int num5 = 0;
                int num6 = 0;
                if (str.Substring(0, 2).CompareTo("03") != 0)
                {
                    flag = false;
                }
                else
                {
                    if ((str.Substring(0, 8).CompareTo("03000001") < 0) && (str.Substring(0, 8).CompareTo("03017000") > 0))
                    {
                        num5 = 5;
                        num6 = 0;
                    }
                    else if ((str.Substring(0, 8).CompareTo("03017001") < 0) && (str.Substring(0, 8).CompareTo("03019022") > 0))
                    {
                        num5 = 9;
                        num6 = 1;
                    }
                    else if (str.Substring(0, 8).CompareTo("03019023") < 0)
                    {
                        num5 = 0;
                        num6 = 0;
                    }
                    num4 = 0;
                    while (num4 <= 7)
                    {
                        num += Convert.ToInt32(str.Substring(num4, 1)) * Convert.ToInt32(str2.Substring(num4, 1));
                        num4++;
                    }
                    num += num5;
                    num2 = num % 11;
                    if ((11 - num2) == 10)
                    {
                        num3 = 0;
                    }
                    else if ((11 - num2) == 11)
                    {
                        num3 = num6;
                    }
                    else
                    {
                        num3 = 11 - num2;
                    }
                    if (str.Substring(8, 1) != num3.ToString())
                    {
                        flag = false;
                    }
                }
                flag2 = true;
            }
            if (uf.Trim().ToUpper() == "AM")
            {
                str = str.PadLeft(9, '0');
                str2 = "98765432";
                for (num4 = 0; num4 <= 7; num4++)
                {
                    num += Convert.ToInt32(str.Substring(num4, 1)) * Convert.ToInt32(str2.Substring(num4, 1));
                }
                num2 = num % 11;
                if (num < 11)
                {
                    num3 = 11 - num;
                }
                else if (num2 < 2)
                {
                    num3 = 0;
                }
                else
                {
                    num3 = 11 - num2;
                }
                if (str.Substring(8, 1) != num3.ToString())
                {
                    flag = false;
                }
                flag2 = true;
            }
            if (uf.Trim().ToUpper() == "BA")
            {
                str = str.PadLeft(8, '0');
                str2 = "765432";
                for (num4 = 0; num4 <= 5; num4++)
                {
                    num += Convert.ToInt32(str.Substring(num4, 1)) * Convert.ToInt32(str2.Substring(num4, 1));
                }
                if (((Convert.ToInt32(str.Substring(0, 1)) >= 0) && (Convert.ToInt32(str.Substring(0, 1)) < 5)) || (Convert.ToInt32(str.Substring(0, 1)) == 8))
                {
                    num2 = num % 10;
                    if (num2 < 1)
                    {
                        num3 = 0;
                    }
                    else
                    {
                        num3 = 10 - num2;
                    }
                }
                else
                {
                    num2 = num % 11;
                    if (num2 < 2)
                    {
                        num3 = 0;
                    }
                    else
                    {
                        num3 = 11 - num2;
                    }
                }
                if (str.Substring(7, 1) != num3.ToString())
                {
                    flag = false;
                }
                else
                {
                    num = 0;
                    str2 = "87654302";
                    for (num4 = 0; num4 <= 7; num4++)
                    {
                        num += Convert.ToInt32(str.Substring(num4, 1)) * Convert.ToInt32(str2.Substring(num4, 1));
                    }
                    if (((Convert.ToInt32(str.Substring(0, 1)) == 6) && (Convert.ToInt32(str.Substring(0, 1)) == 7)) || (Convert.ToInt32(str.Substring(0, 1)) == 9))
                    {
                        num3 = 11 - (num % 11);
                    }
                    else
                    {
                        num3 = 10 - (num % 10);
                    }
                    if (str.Substring(6, 1) != num3.ToString())
                    {
                        flag = false;
                    }
                }
                flag2 = true;
            }
            if (uf.Trim().ToUpper() == "CE")
            {
                str = str.PadLeft(9, '0');
                str2 = "98765432";
                for (num4 = 0; num4 <= 7; num4++)
                {
                    num += Convert.ToInt32(str.Substring(num4, 1)) * Convert.ToInt32(str2.Substring(num4, 1));
                }
                num2 = num % 11;
                if (num2 < 2)
                {
                    num3 = 0;
                }
                else
                {
                    num3 = 11 - num2;
                }
                if (str.Substring(8, 1) != num3.ToString())
                {
                    flag = false;
                }
                flag2 = true;
            }
            if (uf.Trim().ToUpper() == "DF")
            {
                str = str.PadLeft(12, '0');
                str2 = "43298765432";
                if (str.Substring(0, 2).CompareTo("07") != 0)
                {
                    flag = false;
                }
                else
                {
                    for (num4 = 0; num4 <= 10; num4++)
                    {
                        num += Convert.ToInt32(str.Substring(num4, 1)) * Convert.ToInt32(str2.Substring(num4, 1));
                    }
                    num2 = num % 11;
                    if (num2 < 2)
                    {
                        num3 = 0;
                    }
                    else
                    {
                        num3 = 11 - num2;
                    }
                    if (str.Substring(11, 1) != num3.ToString())
                    {
                        flag = false;
                    }
                    else
                    {
                        str = str.PadLeft(13, '0');
                        str2 = "543298765432";
                        num = 0;
                        for (num4 = 0; num4 < 10; num4++)
                        {
                            num += Convert.ToInt32(str.Substring(num4, 1)) * Convert.ToInt32(str2.Substring(num4, 1));
                        }
                        num2 = num % 11;
                        if (num2 < 2)
                        {
                            num3 = 0;
                        }
                        else
                        {
                            num3 = 11 - num2;
                        }
                        if (str.Substring(12, 1) != num3.ToString())
                        {
                            flag = false;
                        }
                    }
                }
                flag2 = true;
            }
            if (uf.Trim().ToUpper() == "ES")
            {
                str = str.PadLeft(9, '0');
                str2 = "98765432";
                for (num4 = 0; num4 <= 7; num4++)
                {
                    num += Convert.ToInt32(str.Substring(num4, 1)) * Convert.ToInt32(str2.Substring(num4, 1));
                }
                num2 = num % 11;
                if (num2 < 2)
                {
                    num3 = 0;
                }
                else
                {
                    num3 = 11 - num2;
                }
                if (str.Substring(8, 1) != num3.ToString())
                {
                    flag = false;
                }
                flag2 = true;
            }
            if (uf.Trim().ToUpper() == "GO")
            {
                str = str.PadLeft(9, '0');
                str2 = "98765432";
                if ((str.Substring(0, 8).CompareTo("11094402") == 0) && ((str.Substring(8, 1).CompareTo("0") == 0) || (str.Substring(8, 1).CompareTo("1") == 0)))
                {
                    flag = true;
                }
                for (num4 = 0; num4 <= 7; num4++)
                {
                    num += Convert.ToInt32(str.Substring(num4, 1)) * Convert.ToInt32(str2.Substring(num4, 1));
                }
                num2 = num % 11;
                if ((str.Substring(0, 8).CompareTo("10103105") >= 0) && (str.Substring(0, 8).CompareTo("10119997") <= 0))
                {
                    if (num2 == 1)
                    {
                        num3 = 1;
                    }
                    else if (num2 == 0)
                    {
                        num3 = 0;
                    }
                    else
                    {
                        num3 = 11 - num2;
                    }
                }
                else if (num2 < 2)
                {
                    num3 = 0;
                }
                else
                {
                    num3 = 11 - num2;
                }
                if (str.Substring(8, 1) != num3.ToString())
                {
                    flag = false;
                }
                flag2 = true;
            }
            if (uf.Trim().ToUpper() == "MA")
            {
                str = str.PadLeft(10, '0');
                str2 = "98765432";
                if (str.Substring(0, 2).CompareTo("12") != 0)
                {
                    flag = false;
                }
                for (num4 = 0; num4 <= 7; num4++)
                {
                    num += Convert.ToInt32(str.Substring(num4, 1)) * Convert.ToInt32(str2.Substring(num4, 1));
                }
                num2 = num % 11;
                if (num2 < 2)
                {
                    num3 = 0;
                }
                else
                {
                    num3 = 11 - num2;
                }
                if (str.Substring(9, 1) != num3.ToString())
                {
                    flag = false;
                }
                flag2 = true;
            }
            if (uf.Trim().ToUpper() == "MT")
            {
                str = str.PadLeft(11, '0');
                str2 = "3298765432";
                for (num4 = 0; num4 <= 9; num4++)
                {
                    num += Convert.ToInt32(str.Substring(num4, 1)) * Convert.ToInt32(str2.Substring(num4, 1));
                }
                num2 = num % 11;
                if (num2 < 2)
                {
                    num3 = 0;
                }
                else
                {
                    num3 = 11 - num2;
                }
                if (str.Substring(10, 1) != num3.ToString())
                {
                    flag = false;
                }
                flag2 = true;
            }
            if (uf.Trim().ToUpper() == "MS")
            {
                str = str.PadLeft(9, '0');
                str2 = "98765432";
                if (str.Substring(0, 2).CompareTo("28") != 0)
                {
                    flag = false;
                }
                else
                {
                    for (num4 = 0; num4 <= 7; num4++)
                    {
                        num += Convert.ToInt32(str.Substring(num4, 1)) * Convert.ToInt32(str2.Substring(num4, 1));
                    }
                    num2 = num % 11;
                    if (num2 < 2)
                    {
                        num3 = 0;
                    }
                    else
                    {
                        num3 = 11 - num2;
                    }
                    if (str.Substring(8, 1) != num3.ToString())
                    {
                        flag = false;
                    }
                }
                flag2 = true;
            }
            if (!(uf.Trim().ToUpper() == "MG"))
            {
                goto Label_0ECE;
            }
            str = str.PadLeft(13, '0');
            str2 = "121212121212";
            string str3 = str.Substring(0, 3) + "0" + str.Substring(3, 8);
            int num7 = 0;
            int num8 = 0;
            string str4 = "";
            int num9 = 0;
            for (num4 = 0; num4 <= 11; num4++)
            {
                num7 = Convert.ToInt32(str3.Substring(num4, 1));
                num8 = (num8 == 2) ? 1 : 2;
                num7 *= num8;
                if (num7 > 9)
                {
                    str4 = num7.ToString().PadLeft(2, '0');
                    int introduced19 = Convert.ToInt32(num7.ToString().Substring(0, 1));
                    num7 = introduced19 + Convert.ToInt32(num7.ToString().Substring(1, 1));
                }
                num += num7;
            }
            num7 = num;
        Label_0D98:
            string introduced20 = num7.ToString().PadLeft(3, '0');
            if (introduced20.Substring(num7.ToString().Length - 1, 1) != "0")
            {
                num7++;
                goto Label_0D98;
            }
            int num11 = num7 - num;
            num11 = num7 - num;
            string introduced21 = num11.ToString().PadLeft(2, '0');
            str4 = introduced21.Substring(num11.ToString().Length - 1, 1);
            str3 = str.Substring(0, 11) + str4;
            num = 0;
            num9 = 2;
            for (int i = 11; i >= 0; i--)
            {
                num7 = Convert.ToInt32(str3.Substring(i, 1)) * num9;
                num += num7;
                num9++;
                if (num9 > 11)
                {
                    num9 = 2;
                }
            }
            num2 = num % 11;
            num11 = (num2 < 2) ? 0 : (11 - num2);
            num11 = (num2 < 2) ? 0 : (11 - num2);
            string introduced22 = num11.ToString();
            num3 = Convert.ToInt32(introduced22.Substring(num11.ToString().Length - 1, 1));
            str3 = str3 + num3.ToString();
            if (str != str3)
            {
                flag = false;
            }
            flag2 = true;
        Label_0ECE:
            if (uf.Trim().ToUpper() == "PA")
            {
                str = str.PadLeft(9, '0');
                str2 = "98765432";
                if (str.Substring(0, 2).CompareTo("15") != 0)
                {
                    flag = false;
                }
                else
                {
                    for (num4 = 0; num4 <= 7; num4++)
                    {
                        num += Convert.ToInt32(str.Substring(num4, 1)) * Convert.ToInt32(str2.Substring(num4, 1));
                    }
                    num2 = num % 11;
                    if (num2 < 2)
                    {
                        num3 = 0;
                    }
                    else
                    {
                        num3 = 11 - num2;
                    }
                    if (str.Substring(8, 1) != num3.ToString())
                    {
                        flag = false;
                    }
                }
                flag2 = true;
            }
            if (uf.Trim().ToUpper() == "PB")
            {
                str = str.PadLeft(9, '0');
                str2 = "98765432";
                for (num4 = 0; num4 <= 7; num4++)
                {
                    num += Convert.ToInt32(str.Substring(num4, 1)) * Convert.ToInt32(str2.Substring(num4, 1));
                }
                num2 = num % 11;
                if (num2 < 2)
                {
                    num3 = 0;
                }
                else
                {
                    num3 = 11 - num2;
                }
                if (str.Substring(8, 1) != num3.ToString())
                {
                    flag = false;
                }
                flag2 = true;
            }
            if (uf.Trim().ToUpper() == "PR")
            {
                str = str.PadLeft(10, '0');
                str2 = "32765432";
                for (num4 = 0; num4 <= 7; num4++)
                {
                    num += Convert.ToInt32(str.Substring(num4, 1)) * Convert.ToInt32(str2.Substring(num4, 1));
                }
                num2 = num % 11;
                if (num2 < 2)
                {
                    num3 = 0;
                }
                else
                {
                    num3 = 11 - num2;
                }
                if (str.Substring(8, 1) != num3.ToString())
                {
                    flag = false;
                }
                else
                {
                    num = 0;
                    str2 = "432765432";
                    for (num4 = 0; num4 <= 8; num4++)
                    {
                        num += Convert.ToInt32(str.Substring(num4, 1)) * Convert.ToInt32(str2.Substring(num4, 1));
                    }
                    num2 = num % 11;
                    if (num2 < 2)
                    {
                        num3 = 0;
                    }
                    else
                    {
                        num3 = 11 - num2;
                    }
                    if (str.Substring(9, 1) != num3.ToString())
                    {
                        flag = false;
                    }
                }
                flag2 = true;
            }
            if (uf.Trim().ToUpper() == "PI")
            {
                str = str.PadLeft(9, '0');
                str2 = "98765432";
                for (num4 = 0; num4 <= 7; num4++)
                {
                    num += Convert.ToInt32(str.Substring(num4, 1)) * Convert.ToInt32(str2.Substring(num4, 1));
                }
                num2 = num % 11;
                if (num2 < 2)
                {
                    num3 = 0;
                }
                else
                {
                    num3 = 11 - num2;
                }
                if (str.Substring(8, 1) != num3.ToString())
                {
                    flag = false;
                }
                flag2 = true;
            }
            if (uf.Trim().ToUpper() == "PE")
            {
                str = str.PadLeft(14, '0');
                str2 = "5432198765432";
                for (num4 = 0; num4 <= 12; num4++)
                {
                    num += Convert.ToInt32(str.Substring(num4, 1)) * Convert.ToInt32(str2.Substring(num4, 1));
                }
                num2 = num % 11;
                if (num2 < 2)
                {
                    num3 = 0;
                }
                else
                {
                    num3 = 11 - num2;
                }
                if (str.Substring(13, 1) != num3.ToString())
                {
                    flag = false;
                }
                flag2 = true;
            }
            if (uf.Trim().ToUpper() == "RJ")
            {
                str = str.PadLeft(8, '0');
                str2 = "2765432";
                for (num4 = 0; num4 <= 6; num4++)
                {
                    num += Convert.ToInt32(str.Substring(num4, 1)) * Convert.ToInt32(str2.Substring(num4, 1));
                }
                num2 = num % 11;
                if (num2 < 2)
                {
                    num3 = 0;
                }
                else
                {
                    num3 = 11 - num2;
                }
                if (str.Substring(7, 1) != num3.ToString())
                {
                    flag = false;
                }
                flag2 = true;
            }
            if (uf.Trim().ToUpper() == "RN")
            {
                str = str.PadLeft(9, '0');
                str2 = "98765432";
                for (num4 = 0; num4 <= 7; num4++)
                {
                    num += Convert.ToInt32(str.Substring(num4, 1)) * Convert.ToInt32(str2.Substring(num4, 1));
                }
                num *= 10;
                num2 = num % 11;
                if ((11 - num2) > 9)
                {
                    num3 = 0;
                }
                else
                {
                    num3 = num2;
                }
                if (str.Substring(8, 1) != num3.ToString())
                {
                    flag = false;
                }
                flag2 = true;
            }
            if (uf.Trim().ToUpper() == "RS")
            {
                str = str.PadLeft(10, '0');
                str2 = "298765432";
                if ((str.Substring(0, 3).CompareTo("001") < 0) && (str.Substring(0, 3).CompareTo("467") > 0))
                {
                    flag = false;
                }
                for (num4 = 0; num4 <= 8; num4++)
                {
                    num += Convert.ToInt32(str.Substring(num4, 1)) * Convert.ToInt32(str2.Substring(num4, 1));
                }
                num2 = num % 11;
                if ((11 - num2) > 9)
                {
                    num3 = 0;
                }
                else
                {
                    num3 = 11 - num2;
                }
                if (str.Substring(9, 1) != num3.ToString())
                {
                    flag = false;
                }
                flag2 = true;
            }
            if (uf.Trim().ToUpper() == "RO")
            {
                str = str.PadLeft(9, '0');
                str = "00000000" + str.Substring(3, 6);
                str2 = "6543298765432";
                for (num4 = 0; num4 <= 12; num4++)
                {
                    num += Convert.ToInt32(str.Substring(num4, 1)) * Convert.ToInt32(str2.Substring(num4, 1));
                }
                num2 = num % 11;
                if (num2 < 2)
                {
                    num3 = (11 - num2) - 10;
                }
                else
                {
                    num3 = 11 - num2;
                }
                if (str.Substring(13, 1) != num3.ToString())
                {
                    flag = false;
                }
                flag2 = true;
            }
            if (uf.Trim().ToUpper() == "RR")
            {
                str = str.PadLeft(9, '0');
                str2 = "12345678";
                if (str.Substring(0, 2).CompareTo("24") != 0)
                {
                    flag = false;
                }
                else
                {
                    for (num4 = 0; num4 <= 7; num4++)
                    {
                        num += Convert.ToInt32(str.Substring(num4, 1)) * Convert.ToInt32(str2.Substring(num4, 1));
                    }
                    num3 = num % 9;
                    if (str.Substring(8, 1) != num3.ToString())
                    {
                        flag = false;
                    }
                }
                flag2 = true;
            }
            if (uf.Trim().ToUpper() == "SC")
            {
                str = str.PadLeft(8, '0');
                str2 = "98765432";
                for (num4 = 0; num4 <= 7; num4++)
                {
                    num += Convert.ToInt32(str.Substring(num4, 1)) * Convert.ToInt32(str2.Substring(num4, 1));
                }
                num2 = num % 11;
                if (num2 < 2)
                {
                    num3 = 0;
                }
                else
                {
                    num3 = 11 - num2;
                }
                if (str.Substring(7, 1) != num3.ToString())
                {
                    flag = false;
                }
                flag2 = true;
            }
            if (uf.Trim().ToUpper() == "SP")
            {
                flag = true;
                str2 = "0103040506070810";
                str3 = "";
                if (str.Length == 13)
                {
                    if (str.Substring(0, 1) != "P")
                    {
                        flag = false;
                    }
                    else
                    {
                        str3 = str.Substring(1, 12);
                    }
                }
                else
                {
                    str3 = str;
                }
                if (flag)
                {
                    for (num4 = 0; num4 <= 7; num4++)
                    {
                        num += Convert.ToInt32(str3.Substring(num4, 1)) * Convert.ToInt32(str2.Substring(num4, 1));
                    }
                    num2 = num % 11;
                    string introduced23 = num2.ToString();
                    num3 = Convert.ToInt32(introduced23.Substring(num2.ToString().Length - 1, 1));
                    if (str3.Substring(8, 1) != num3.ToString())
                    {
                        flag = false;
                    }
                    else if (str3.Length == 12)
                    {
                        num = 0;
                        str2 = "0302100908070605040302";
                        for (num4 = 0; num4 <= 10; num4++)
                        {
                            num += Convert.ToInt32(str3.Substring(num4, 1)) * Convert.ToInt32(str2.Substring(num4, 1));
                        }
                        num2 = num % 11;
                        string introduced24 = num2.ToString();
                        num3 = Convert.ToInt32(introduced24.Substring(num2.ToString().Length - 1, 1));
                        if (str3.Substring(13, 1) != num3.ToString())
                        {
                            flag = false;
                        }
                    }
                }
                flag2 = true;
            }
            if (uf.Trim().ToUpper() == "SE")
            {
                str = str.PadLeft(9, '0');
                str2 = "98765432";
                for (num4 = 0; num4 <= 7; num4++)
                {
                    num += Convert.ToInt32(str.Substring(num4, 1)) * Convert.ToInt32(str2.Substring(num4, 1));
                }
                num2 = num % 11;
                if (num2 < 2)
                {
                    num3 = 0;
                }
                else
                {
                    num3 = 11 - num2;
                }
                if (str.Substring(8, 1) != num3.ToString())
                {
                    flag = false;
                }
                flag2 = true;
            }
            if (uf.Trim().ToUpper() == "TO")
            {
                str = str.PadLeft(11, '0');
                str2 = "9800765432";
                if ((((str.Substring(2, 2).CompareTo("01") != 0) || (str.Substring(2, 2).CompareTo("02") != 0)) || (str.Substring(2, 2).CompareTo("03") != 0)) || (str.Substring(2, 2).CompareTo("99") != 0))
                {
                    flag = false;
                }
                else
                {
                    for (num4 = 0; num4 <= 9; num4++)
                    {
                        num += Convert.ToInt32(str.Substring(num4, 1)) * Convert.ToInt32(str2.Substring(num4, 1));
                    }
                    num2 = num % 11;
                    if (num2 < 2)
                    {
                        num3 = 0;
                    }
                    else
                    {
                        num3 = 11 - num2;
                    }
                    if (str.Substring(10, 1) != num3.ToString())
                    {
                        flag = false;
                    }
                }
                flag2 = true;
            }
            if (!flag2)
            {
                return false;
            }
            return flag;
        }

        public void ValidarEmail(string email)
        {
            try
            {
                Regex regex = new Regex(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$");
                if (!regex.IsMatch(email))
                {
                    throw new Exception("Email Inválido.");
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public int ValidarInscricaoEstadual(string InscEstadual, string UF)
        {
            return ConsisteInscricaoEstadual(InscEstadual, UF);
        }
    }
} 
