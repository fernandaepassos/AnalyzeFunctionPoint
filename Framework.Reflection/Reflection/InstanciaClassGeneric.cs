using System;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
using Framework.Reflection.Generic;
using System.Reflection;
using System.IO;
using System.Web;
using System.Globalization;
using Framework.Reflection.Tool;
using Framework.Reflection.PaginaWeb;

namespace Framework.Reflection.InstanciaClassGeneric
{
    //[StructLayout(LayoutKind.Sequential, Size = 1)]
    public struct InstanciaClassGeneric
    {
        public static void PreencherObjeto(ControlCollection objColecaoControlesPagina, object objetoClasse, int idObjetoClasse)
        {
            if (objetoClasse is ClassGeneric)
            {
                if (idObjetoClasse > 0)
                {
                    ((ClassGeneric)objetoClasse).GetById(idObjetoClasse);
                }
                preencherObjetoComValorControle(objColecaoControlesPagina, objetoClasse);
            }
        }

        public static string RetornaValorAtributo(object objetoClasse, string idControlePagina)
        {
            //string nomeClasseIdControlePagina = PaginaWeb.GetNomeClasseIdControlePagina(idControlePagina);
            string nomeClasseIdControlePagina = Framework.Reflection.PaginaWeb.PaginaWeb.GetNomeClasseIdControlePagina(idControlePagina);


            string idControlePaginaNomeClasseRemovido = Framework.Reflection.PaginaWeb.PaginaWeb.RemoveNomeClasseIdControlePagina(idControlePagina);
            string nomePropriedadeIdControlePagina = Framework.Reflection.PaginaWeb.PaginaWeb.GetNomePropriedadeIdControlePagina(idControlePaginaNomeClasseRemovido);
            PropertyInfo property = objetoClasse.GetType().GetProperty(nomePropriedadeIdControlePagina);
            if (property == null)
            {
                return "";
            }
            object obj2 = property.GetValue(objetoClasse, null);
            if (obj2 == null)
            {
                return "";
            }
            if (obj2 is ClassGeneric)
            {
                return RetornaValorAtributo(obj2, idControlePaginaNomeClasseRemovido);
            }
            if ((property.PropertyType == typeof(double)) || (property.PropertyType == typeof(double)))
            {
                string format = getMarcara(Convert.ToDouble(obj2));
                return (string.IsNullOrEmpty(obj2.ToString()) ? "0,00" : Convert.ToDouble(obj2).ToString(format));
            }
            return obj2.ToString();
        }

        private static void preencherObjetoComValorControle(ControlCollection objColecaoControlesPagina, object objetoClasse)
        {
            foreach (Control control in objColecaoControlesPagina)
            {
                if (control.HasControls())
                {
                    preencherObjetoComValorControle(control.Controls, objetoClasse);
                }
                if (((!(control is Label) && !(control is Button)) && ((control.ID != null) && (control.ID != ""))) && ((control.ID.Length >= 6) && (control.ID.Substring(0, 3) != "TxH")))
                {
                    string idControlePagina = control.ID.Substring(3);
                    if (objetoClasse.GetType().Name == Framework.Reflection.PaginaWeb.PaginaWeb.GetNomeClasseIdControlePagina(idControlePagina))
                    {
                        try
                        {
                            object valorAtribuir = getValorControlePagina(control);
                            setValorControlePaginaEmObjeto((ClassGeneric)objetoClasse, idControlePagina, valorAtribuir);
                        }
                        catch
                        {
                            throw new Exception(idControlePagina);
                        }
                    }
                }
            }
        }

        private static void setValorControlePaginaEmObjeto(ClassGeneric objetoClasse, string idControlePagina, object valorAtribuir)
        {
            if (valorAtribuir != null)
            {
                PropertyInfo property;
                string idControlePaginaNomeClasseRemovido = Framework.Reflection.PaginaWeb.PaginaWeb.RemoveNomeClasseIdControlePagina(idControlePagina);
                string nomePropriedadeIdControlePagina = Framework.Reflection.PaginaWeb.PaginaWeb.GetNomePropriedadeIdControlePagina(idControlePaginaNomeClasseRemovido);
                if (IsPropriedadeSimples(idControlePaginaNomeClasseRemovido))
                {
                    property = objetoClasse.GetType().GetProperty(nomePropriedadeIdControlePagina);
                    if ((property != null) && (property.CanWrite && property.CanRead))
                    {
                        atribuirPropertyInfo(objetoClasse, property, valorAtribuir);
                    }
                }
                else
                {
                    nomePropriedadeIdControlePagina = Framework.Reflection.PaginaWeb.PaginaWeb.GetNomePropriedadeIdControlePagina(Framework.Reflection.PaginaWeb.PaginaWeb.GetNomeClasseIdControlePagina(idControlePaginaNomeClasseRemovido));
                    idControlePaginaNomeClasseRemovido = Framework.Reflection.PaginaWeb.PaginaWeb.RemoveNomeClasseIdControlePagina(idControlePaginaNomeClasseRemovido);
                    if ((IsPropriedadeSimples(idControlePaginaNomeClasseRemovido) && (nomePropriedadeIdControlePagina.Length >= 3)) && ((idControlePaginaNomeClasseRemovido.Length >= 3) && ((idControlePaginaNomeClasseRemovido.Substring(0, 2).ToUpper() == "ID") || (idControlePaginaNomeClasseRemovido.Substring(0, 3).ToUpper() == "COD"))))
                    {
                        property = objetoClasse.GetType().GetProperty(nomePropriedadeIdControlePagina);
                        if ((property != null) && (property.CanWrite && property.CanRead))
                        {
                            object obj2 = property.GetValue(objetoClasse, null);
                            if (obj2 is ClassGeneric)
                            {
                                if (idControlePaginaNomeClasseRemovido.Substring(0, 2).ToUpper() == "ID")
                                {
                                    int id = convertToInt(valorAtribuir);
                                    ((ClassGeneric)obj2).GetById(id);
                                    property.SetValue(objetoClasse, (ClassGeneric)obj2, null);
                                }
                                else if (idControlePaginaNomeClasseRemovido.Substring(0, 3).ToUpper() == "COD")
                                {
                                    string str4 = Convert.ToString(valorAtribuir);
                                    string name = ((ClassGeneric)obj2).GetType().Name;
                                    if (!string.IsNullOrEmpty(str4))
                                    {
                                        ((ClassGeneric)obj2).GetBy("Cod" + name + " = '" + str4.ToString() + "'");
                                        property.SetValue(objetoClasse, (ClassGeneric)obj2, null);
                                    }
                                    else
                                    {
                                        object obj3 = ((ClassGeneric)obj2).GetType().GetConstructor(new Type[0]).Invoke(null);
                                        ((ClassGeneric)obj3).GetById(0);
                                        property.SetValue(objetoClasse, (ClassGeneric)obj3, null);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private static int convertToInt(object valorAtribuir)
        {
            try
            {
                return Convert.ToInt32(valorAtribuir);
            }
            catch
            {
                return 0;
            }
        }

        private static void atribuirPropertyInfo(object objetoClasse, PropertyInfo objPropertyInfo, object valorAtribuir)
        {
            try
            {
                if (objPropertyInfo.PropertyType == typeof(string))
                {
                    valorAtribuir = Convert.ToString(valorAtribuir);
                }
                else if ((objPropertyInfo.PropertyType == typeof(int)) || (objPropertyInfo.PropertyType == typeof(int)))
                {
                    valorAtribuir = Convert.ToInt32(valorAtribuir);
                }
                else if (objPropertyInfo.PropertyType == typeof(short))
                {
                    valorAtribuir = Convert.ToInt16(valorAtribuir);
                }
                else if (objPropertyInfo.PropertyType == typeof(byte))
                {
                    valorAtribuir = Convert.ToByte(valorAtribuir);
                }
                else if (objPropertyInfo.PropertyType == typeof(double))
                {
                    valorAtribuir = Convert.ToDouble(valorAtribuir);
                }
                else if (objPropertyInfo.PropertyType == typeof(long))
                {
                    valorAtribuir = Convert.ToInt64(valorAtribuir);
                }
                else
                {
                    float num;
                    if ((objPropertyInfo.PropertyType == typeof(float)) && float.TryParse(Convert.ToString(valorAtribuir), out num))
                    {
                        valorAtribuir = num;
                    }
                }
                objPropertyInfo.SetValue(objetoClasse, valorAtribuir, null);
            }
            catch
            {
            }
        }

        private static bool IsPropriedadeSimples(string idControlePagina)
        {
            int num = 0;
            for (int i = 0; i < idControlePagina.Length; i++)
            {
                if (idControlePagina[i] == '_')
                {
                    num++;
                }
            }
            return (num == 0);
        }

        private static object getValorControlePagina(Control objControlePagina)
        {
            if (objControlePagina is TextBox)
            {
                string text = ((TextBox)objControlePagina).Text;
                if (text.Contains("/") && (text.Length <= 10))
                {
                    if (!valorAtribuirIsDateTime(text))
                    {
                        return text;
                    }
                    string nomeWebControl = "TxH" + ((TextBox)objControlePagina).ID.Substring(3);
                    Control control = Framework.Reflection.PaginaWeb.PaginaWeb.BuscaWebControl(objControlePagina.Page.Controls, nomeWebControl);
                    if (control == null)
                    {
                        return text;
                    }
                    if (!(control is TextBox))
                    {
                        return text;
                    }
                    string str3 = ((TextBox)control).Text.Trim();
                    if (str3.Length == 2)
                    {
                        str3 = str3 + ":00:00";
                    }
                    else if (str3.Length == 5)
                    {
                        str3 = str3 + ":00";
                    }
                    if (str3.Length == 8)
                    {
                        text = text + " " + str3;
                    }
                }
                return text;
            }
            if (objControlePagina is DropDownList)
            {
                if (((DropDownList)objControlePagina).Items.Count > 0)
                {
                    return ((DropDownList)objControlePagina).SelectedValue;
                }
            }
            else
            {
                string str4;
                string str5;
                int num;
                if (!(objControlePagina is RadioButtonList))
                {
                    if (objControlePagina is RadioButton)
                    {
                        if (!((RadioButton)objControlePagina).Checked)
                        {
                            return null;
                        }
                        str4 = ((RadioButton)objControlePagina).Text;
                        str5 = "";
                        for (num = 0; num < str4.Length; num++)
                        {
                            if (str4[num] == ' ')
                            {
                                break;
                            }
                            str5 = str5 + str4[num];
                        }
                        return str5.Trim();
                    }
                    if (objControlePagina is CheckBox)
                    {
                        return (((CheckBox)objControlePagina).Checked ? "1" : "0");
                    }
                    if (objControlePagina is HiddenField)
                    {
                        return ((HiddenField)objControlePagina).Value;
                    }
                }
                else
                {
                    if (((RadioButtonList)objControlePagina).SelectedItem.Value.Trim() == "")
                    {
                        return null;
                    }
                    str4 = ((RadioButtonList)objControlePagina).SelectedItem.Value.Trim();
                    str5 = "";
                    for (num = 0; num < str4.Length; num++)
                    {
                        if (str4[num] == ' ')
                        {
                            break;
                        }
                        str5 = str5 + str4[num];
                    }
                    return str5.Trim();
                }
            }
            return null;
        }

        private static bool valorAtribuirIsDateTime(string valorAtribuir)
        {
            try
            {
                DateTime time = Convert.ToDateTime(valorAtribuir.Replace("'", "''"));
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

        private static string getMarcara(double valor)
        {
            int num = new Tools().getQtdeCasasDecimais(valor);
            if (num <= 2)
            {
                return "N2";
            }
            return ("N" + num.ToString());
        }
    }
} 
