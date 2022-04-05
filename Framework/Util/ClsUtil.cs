using System;
using System.Configuration;
using System.Collections;
using System.IO;
using System.Data;
using Framework.Reflection.AcessoBancoDados;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web;


namespace Framework.Util
{
    public class ClsUtil
    {
        // Methods
        public static void BloqueiaCampos(Control objPage)
        {
            try
            {
                foreach (Control control in objPage.Controls)
                {
                    if (control.HasControls())
                    {
                        BloqueiaCampos(control);
                    }
                    else if (control is TextBox)
                    {
                        if ((((TextBox) control).ID.Trim().ToLower() != "TxtUltimaAtualizacao".ToLower().Trim()) && (((TextBox) control).ID.Trim().ToLower() != "TxtIdUltimoUsuario".ToLower().Trim()))
                        {
                            ((TextBox) control).Enabled = false;
                        }
                    }
                    else if (control is DropDownList)
                    {
                        ((DropDownList) control).Enabled = false;
                    }
                    else if (control is CheckBoxList)
                    {
                        ((CheckBoxList) control).Enabled = false;
                    }
                    else if (control is RadioButtonList)
                    {
                        ((RadioButtonList) control).Enabled = false;
                    }
                    else if (control is ListBox)
                    {
                        ((ListBox) control).Enabled = false;
                    }
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public void ClearPage(Control objPage)
        {
            try
            {
                foreach (Control control in objPage.Controls)
                {
                    if (control.HasControls())
                    {
                        this.ClearPage(control);
                    }
                    else if (control is TextBox)
                    {
                        ((TextBox) control).Text = string.Empty;
                    }
                    else if (control is DropDownList)
                    {
                        ((DropDownList) control).ClearSelection();
                    }
                    else if (control is CheckBoxList)
                    {
                        ((CheckBoxList) control).ClearSelection();
                    }
                    else if (control is RadioButtonList)
                    {
                        ((RadioButtonList) control).ClearSelection();
                    }
                    else if (control is ListBox)
                    {
                        ((ListBox) control).ClearSelection();
                    }
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public static void ClearPages(Control objPage)
        {
            try
            {
                foreach (Control control in objPage.Controls)
                {
                    if (control.HasControls())
                    {
                        ClearPages(control);
                    }
                    else if (control is TextBox)
                    {
                        ((TextBox) control).Text = string.Empty;
                    }
                    else if (control is DropDownList)
                    {
                        ((DropDownList) control).ClearSelection();
                    }
                    else if (control is CheckBoxList)
                    {
                        ((CheckBoxList) control).ClearSelection();
                    }
                    else if (control is RadioButtonList)
                    {
                        ((RadioButtonList) control).ClearSelection();
                    }
                    else if (control is ListBox)
                    {
                        ((ListBox) control).ClearSelection();
                    }
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public DataSet ConvertObjectDataSourceEmDataSet(ObjectDataSource DataSource)
        {
            DataSet set2;
            try
            {
                DataSet set = new DataSet();
                DataView view = (DataView) DataSource.Select();
                if ((view != null) && (view.Count > 0))
                {
                    DataTable table = view.ToTable();
                    set.Tables.Add(table);
                }
                set2 = set;
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return set2;
        }

        public static void DesBloqueiaCampos(Control objPage)
        {
            try
            {
                foreach (Control control in objPage.Controls)
                {
                    if (control.HasControls())
                    {
                        DesBloqueiaCampos(control);
                    }
                    else if (control is TextBox)
                    {
                        if ((((TextBox) control).ID.Trim().ToLower() != "TxtUltimaAtualizacao".ToLower().Trim()) && (((TextBox) control).ID.Trim().ToLower() != "TxtIdUltimoUsuario".ToLower().Trim()))
                        {
                            ((TextBox) control).Enabled = true;
                        }
                    }
                    else if (control is DropDownList)
                    {
                        ((DropDownList) control).Enabled = true;
                    }
                    else if (control is CheckBoxList)
                    {
                        ((CheckBoxList) control).Enabled = true;
                    }
                    else if (control is RadioButtonList)
                    {
                        ((RadioButtonList) control).Enabled = true;
                    }
                    else if (control is ListBox)
                    {
                        ((ListBox) control).Enabled = true;
                    }
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public string GetVarGlobal(string strNomeVariavel)
        {
            string str;
            try
            {
                try
                {
                    str = HttpContext.Current.Application.Contents[strNomeVariavel].ToString();
                }
                catch
                {
                    str = "";
                }
            }
            catch
            {
                str = "";
            }
            return str;
        }

        public static string GetVarGlobalStatic(string strNomeVariavel)
        {
            string str;
            try
            {
                try
                {
                    str = HttpContext.Current.Application.Contents[strNomeVariavel].ToString();
                }
                catch
                {
                    str = "";
                }
            }
            catch
            {
                str = "";
            }
            return str;
        }

        public bool ValidaCep(string cep)
        {
            try
            {
                if (Convert.ToInt32(cep.Trim().Replace("-", "").Replace(".", "").Replace(",", "")) == 0)
                {
                    return false;
                }
            }
            catch
            {
            }
            if (cep.Length == 8)
            {
                cep = cep.Substring(0, 5) + "-" + cep.Substring(5, 3);
            }
            return Regex.IsMatch(cep, "[0-9]{5}-[0-9]{3}");
        }

        public bool ValidaCnpj(string cnpj)
        {
            try
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
                if ((((((cnpj == "00000000000000") || (cnpj == "11111111111111")) || ((cnpj == "22222222222222") || (cnpj == "33333333333333"))) || (((cnpj == "44444444444444") || (cnpj == "55555555555555")) || ((cnpj == "66666666666666") || (cnpj == "77777777777777")))) || (cnpj == "88888888888888")) || (cnpj == "99999999999999"))
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
            catch
            {
                return false;
            }
        }

        public bool ValidaCpf(string vrCPF)
        {
            try
            {
                int num;
                string str = vrCPF.Replace(".", "").Replace("-", "");
                if (str.Length != 11)
                {
                    return false;
                }
                bool flag = true;
                for (num = 1; (num < 11) && flag; num++)
                {
                    if (str[num] != str[0])
                    {
                        flag = false;
                    }
                }
                if (flag || (str == "12345678909"))
                {
                    return false;
                }
                int[] numArray = new int[11];
                for (num = 0; num < 11; num++)
                {
                    numArray[num] = int.Parse(str[num].ToString());
                }
                int num2 = 0;
                for (num = 0; num < 9; num++)
                {
                    num2 += (10 - num) * numArray[num];
                }
                int num3 = num2 % 11;
                switch (num3)
                {
                    case 1:
                    case 0:
                        if (numArray[9] != 0)
                        {
                            return false;
                        }
                        break;

                    default:
                        if (numArray[9] != (11 - num3))
                        {
                            return false;
                        }
                        break;
                }
                num2 = 0;
                for (num = 0; num < 10; num++)
                {
                    num2 += (11 - num) * numArray[num];
                }
                num3 = num2 % 11;
                switch (num3)
                {
                    case 1:
                    case 0:
                        if (numArray[10] != 0)
                        {
                            return false;
                        }
                        break;

                    default:
                        if (numArray[10] != (11 - num3))
                        {
                            return false;
                        }
                        break;
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool ValidaData(string data)
        {
            try
            {
                DateTime time = Convert.ToDateTime(data.Replace("'", "''"));
                DateTime time2 = Convert.ToDateTime("01/01/1900 00:00:00");
                if (time.CompareTo(time2) < 0)
                {
                    return false;
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool ValidaEmail(string email)
        {
            return Regex.IsMatch(email, "(?<user>[^@]+)@(?<host>.+)");
        }

        public bool ValidaRenavam(string RENAVAM)
        {
            try
            {
                int num2;
                if (string.IsNullOrEmpty(RENAVAM.Trim()))
                {
                    return false;
                }
                int[] numArray = new int[11];
                string str = "3298765432";
                string str2 = Regex.Replace(RENAVAM, "[^0-9]", string.Empty);
                if (string.IsNullOrEmpty(str2))
                {
                    return false;
                }
                if (new string(str2[0], str2.Length) == str2)
                {
                    return false;
                }
                str2 = Convert.ToInt64(str2).ToString("00000000000");
                int num = 0;
                for (num2 = 0; num2 < 11; num2++)
                {
                    numArray[num2] = Convert.ToInt32(str2.Substring(num2, 1));
                }
                for (num2 = 0; num2 < 10; num2++)
                {
                    num += numArray[num2] * Convert.ToInt32(str.Substring(num2, 1));
                }
                num = (num * 10) % 11;
                num = (num != 10) ? num : 0;
                return (num == numArray[10]);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool ValidaTelefone(string telefone)
        {
            try
            {
                if (Convert.ToInt32(telefone.Trim().Replace("(", "").Replace(")", "").Replace("-", "")) == 0)
                {
                    return false;
                }
            }
            catch
            {
            }
            Regex regex = new Regex("^[0-9]{7,8}$");
            return regex.IsMatch(telefone);
        }
    }

}
