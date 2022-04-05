using System;
using System.Net;
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
using Framework.Seguranca;
using System.Configuration;

namespace Framework.Reflection.ControlesWeb
{
    
    public struct ControlesWeb
    {
        public static void Page_Load(Page objetoPage, ClassGeneric objetoClassGeneric)
        {
            try
            {
                Framework.Reflection.PaginaWeb.PaginaWeb.GetIdUsuarioCorrente(objetoPage);
                
                if (!objetoPage.IsPostBack)
                {
                    try
                    {
                        if (((objetoPage.Session["ControlarPermissao"] != null) && (objetoPage.Session["ControlarPermissao"].ToString().Trim() != "")) && (objetoPage.Session["ControlarPermissao"].ToString().Trim() == "S"))
                        {
                            PermissaoExibeOcultaObjetos(objetoPage.Session["IdUsuario"].ToString().Trim(), objetoPage.Session["IdFilial"].ToString().Trim(), objetoPage.Controls);
                        }
                    }
                    catch
                    {
                    }

                    Framework.Reflection.PaginaWeb.PaginaWeb.AtribuirIdObjetoPage(objetoPage);
                    Framework.Reflection.PaginaWeb.PaginaWeb.PreencherControlesWebValorDefault(objetoPage.Controls);
                    PreencheWebControls(objetoClassGeneric, objetoPage);
                    Framework.Reflection.PaginaWeb.PaginaWeb.FormatarGridView(objetoPage.Controls);
                }
                PreencheMascaraPesoVolume(objetoClassGeneric, objetoPage);
                Framework.Reflection.PaginaWeb.PaginaWeb.RegisterStartupScript(objetoPage);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public static void Page_Load(Page objetoPage)
        {
            try
            {
                Framework.Reflection.PaginaWeb.PaginaWeb.GetIdUsuarioCorrente(objetoPage);
                if (!objetoPage.IsPostBack)
                {
                    try
                    {
                        if (Framework.Util.ClsUtil.GetVarGlobalStatic("ControlarPermissao") != null && Framework.Util.ClsUtil.GetVarGlobalStatic("ControlarPermissao") != "" && Framework.Util.ClsUtil.GetVarGlobalStatic("ControlarPermissao") == "S")
                        {
                            PermissaoExibeOcultaObjetos(Framework.Util.ClsUtil.GetVarGlobalStatic("IdUsuario"), Framework.Util.ClsUtil.GetVarGlobalStatic("IdFilial"), objetoPage.Controls);
                        }
                    }
                    catch
                    {
                    }
                    Framework.Reflection.PaginaWeb.PaginaWeb.PreencherControlesWebValorDefault(objetoPage.Controls);
                    Framework.Reflection.PaginaWeb.PaginaWeb.FormatarGridView(objetoPage.Controls);
                }
                Framework.Reflection.PaginaWeb.PaginaWeb.RegisterStartupScript(objetoPage);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public static bool SalvarObjeto(Page objPage, ClassGeneric objetoInstancia)
        {
            Framework.Reflection.PaginaWeb.PaginaWeb.GetIdUsuarioCorrente(objPage);
            EnviarCamposParaInstancia(objPage, objetoInstancia);
            return GravarObjetoBancoDados(objPage, objetoInstancia);
        }

        public static bool SalvarObjetoNovoCadastro(Page objPage, ClassGeneric objetoInstancia)
        {
            bool flag = SalvarObjeto(objPage, objetoInstancia);
            if (flag)
            {
                NovoCadastro(objPage);
            }
            return flag;
        }

        public static void NovoCadastro(Page objPage)
        {
            Framework.Reflection.PaginaWeb.PaginaWeb.RecarregarPagina(objPage, 0);
            Framework.Reflection.PaginaWeb.PaginaWeb.GetIdUsuarioCorrente(objPage);
        }

        public static void Excluir(Page objPage, ClassGeneric objetoInstancia)
        {
            try
            {
                Framework.Reflection.PaginaWeb.PaginaWeb.GetIdUsuarioCorrente(objPage);
                int valorIDPaginaWeb = Framework.Reflection.PaginaWeb.PaginaWeb.GetValorIDPaginaWeb(objPage);
                objetoInstancia.NomeTela = objPage.Title;
                objetoInstancia.GetById(valorIDPaginaWeb);
                if (objetoInstancia.Excluir())
                {
                    NovoCadastro(objPage);
                }
                Framework.Reflection.PaginaWeb.PaginaWeb.Mensagem(objPage, "Registro excluído com sucesso!", TipoMensagem.Error);
            }
            catch (Exception exception)
            {
                Framework.Reflection.PaginaWeb.PaginaWeb.Mensagem(objPage, exception.Message, TipoMensagem.Warning);
            }
        }

        public static void LinkButtonEditar(DropDownList DdlEditar, string nomePaginaCadastro)
        {
            int idObjetoEditar = 0;
            if (((DdlEditar.SelectedIndex >= 0) && !string.IsNullOrEmpty(DdlEditar.SelectedValue)) && (DdlEditar.SelectedValue != ""))
            {
                idObjetoEditar = (DdlEditar.SelectedIndex == 0) ? 0 : Convert.ToInt32(DdlEditar.SelectedValue);
            }
            idObjetoEditar = tratarTipoPreDefinido(idObjetoEditar, nomePaginaCadastro);
            LinkChamarCadastro(DdlEditar.Page, idObjetoEditar, nomePaginaCadastro);
        }

        public static void LinkButtonEditar(TextBox TxtEditar, Type tipoObjeto, string nomePaginaCadastro)
        {
            int idObjetoEditar = 0;
            if (string.IsNullOrEmpty(TxtEditar.Text) || (TxtEditar.Text == ""))
            {
                idObjetoEditar = 0;
            }
            else
            {
                object obj2 = tipoObjeto.GetConstructor(new Type[0]).Invoke(null);
                if (!(obj2 is ClassGeneric))
                {
                    return;
                }
                try
                {
                    string name = ((ClassGeneric)obj2).GetType().Name;
                    ((ClassGeneric)obj2).GetBy("Cod" + name + " = '" + TxtEditar.Text + "'");
                    idObjetoEditar = ((ClassGeneric)obj2).Id;
                }
                catch
                {
                    idObjetoEditar = 0;
                }
            }
            LinkChamarCadastro(TxtEditar.Page, idObjetoEditar, nomePaginaCadastro);
        }

        public static void LinkChamarCadastro(Page objPage, int idObjetoEditar, string nomePaginaCadastro)
        {
            DirectoryInfo info = new DirectoryInfo(HttpContext.Current.Request.ServerVariables["APPL_PHYSICAL_PATH"]);
            nomePaginaCadastro = nomePaginaCadastro + ".aspx";
            nomePaginaCadastro = nomePaginaCadastro.Replace(".aspx.aspx", ".aspx");
            foreach (FileInfo info2 in info.GetFiles(nomePaginaCadastro, SearchOption.AllDirectories))
            {
                if (info2.Name.ToUpper() == nomePaginaCadastro.ToUpper())
                {
                    string str = getURL(info2.FullName, objPage.AppRelativeVirtualPath);
                    break;
                }
            }
        }

        public static void PreencheMascaraPesoVolume(ClassGeneric objetoClassGeneric, Page objetoPage)
        {
        }

        public static void FormatarPesoVolume(Page objPage, int idFilial)
        {
        }

        private static void loopFormataVolume(ControlCollection objColecaoControlesPagina, int qtdeCasasVolume)
        {
            foreach (Control control in objColecaoControlesPagina)
            {
                if ((control is TextBox) && (control.ID.Length > 4))
                {
                    if (control.ID.Substring(0, 3) != "TxV")
                    {
                        continue;
                    }
                    double num = string.IsNullOrEmpty(((TextBox)control).Text) ? 0.0 : Convert.ToDouble(((TextBox)control).Text.Trim());
                    switch (qtdeCasasVolume)
                    {
                        case 0:
                            formataJavaScript((TextBox)control, "integerde7ponto", num.ToString("N0"));
                            goto Label_0160;

                        case 1:
                            formataJavaScript((TextBox)control, "decimal15de1", num.ToString("N1"));
                            goto Label_0160;

                        case 2:
                            formataJavaScript((TextBox)control, "decimal15de2", num.ToString("N2"));
                            goto Label_0160;

                        case 3:
                            formataJavaScript((TextBox)control, "decimal15de3", num.ToString("N3"));
                            goto Label_0160;
                    }
                    formataJavaScript((TextBox)control, "decimal15de4", num.ToString("N4"));
                }
            Label_0160:
                if (control.HasControls())
                {
                    loopFormataVolume(control.Controls, qtdeCasasVolume);
                }
            }
        }

        private static void loopFormataPeso(ControlCollection objColecaoControlesPagina, int qtdeCasasPeso)
        {
            foreach (Control control in objColecaoControlesPagina)
            {
                if ((control is TextBox) && (control.ID.Length > 4))
                {
                    if (control.ID.Substring(0, 3) != "TxP")
                    {
                        continue;
                    }
                    double num = string.IsNullOrEmpty(((TextBox)control).Text) ? 0.0 : Convert.ToDouble(((TextBox)control).Text.Trim());
                    switch (qtdeCasasPeso)
                    {
                        case 0:
                            formataJavaScript((TextBox)control, "integerde7ponto", num.ToString("N0"));
                            goto Label_0160;

                        case 1:
                            formataJavaScript((TextBox)control, "decimal15de1", num.ToString("N1"));
                            goto Label_0160;

                        case 2:
                            formataJavaScript((TextBox)control, "decimal15de2", num.ToString("N2"));
                            goto Label_0160;

                        case 3:
                            formataJavaScript((TextBox)control, "decimal15de3", num.ToString("N3"));
                            goto Label_0160;
                    }
                    formataJavaScript((TextBox)control, "decimal15de4", num.ToString("N4"));
                }
            Label_0160:
                if (control.HasControls())
                {
                    loopFormataPeso(control.Controls, qtdeCasasPeso);
                }
            }
        }

        private static void formataJavaScript(TextBox objTextBox, string mascara, string valor)
        {
        }

        public static void DesabilitarPagina(Page objPage)
        {
            Framework.Reflection.PaginaWeb.PaginaWeb.HabilitaDesabilitaPagina(objPage.Controls, false);
        }

        public static void HabilitarPagina(Page objPage)
        {
            Framework.Reflection.PaginaWeb.PaginaWeb.HabilitaDesabilitaPagina(objPage.Controls, true);
        }

        public static void PreencheWebControls(ClassGeneric objetoClassGeneric, Page objetoPage)
        {
            if (objetoClassGeneric != null)
            {
                int valorIDPaginaWeb = Framework.Reflection.PaginaWeb.PaginaWeb.GetValorIDPaginaWeb(objetoPage);
                objetoClassGeneric.GetById(valorIDPaginaWeb);
                RelacionaObjetoClasseControlesPagina(objetoClassGeneric, objetoPage.Controls);
                PreencheMascaraPesoVolume(objetoClassGeneric, objetoPage);
            }
        }

        public static void EditarModal(Page objPage, int idPaginaOrigem, string nomePaginaModal)
        {
            DirectoryInfo info = new DirectoryInfo(HttpContext.Current.Request.ServerVariables["APPL_PHYSICAL_PATH"]);
            nomePaginaModal = nomePaginaModal + ".aspx";
            nomePaginaModal = nomePaginaModal.Replace(".aspx.aspx", ".aspx");
            foreach (FileInfo info2 in info.GetFiles(nomePaginaModal, SearchOption.AllDirectories))
            {
                if (info2.Name.ToUpper() == nomePaginaModal.ToUpper())
                {
                    string str = getURL(info2.FullName, objPage.AppRelativeVirtualPath);
                    break;
                }
            }
        }

        public static void Redirecionar(Page objPageOrigem, string nomePaginaDestino, int idPaginaDestino)
        {
            DirectoryInfo info = new DirectoryInfo(HttpContext.Current.Request.ServerVariables["APPL_PHYSICAL_PATH"]);
            nomePaginaDestino = nomePaginaDestino + ".aspx";
            nomePaginaDestino = nomePaginaDestino.Replace(".aspx.aspx", ".aspx");
            foreach (FileInfo info2 in info.GetFiles(nomePaginaDestino, SearchOption.AllDirectories))
            {
                if (info2.Name.ToUpper() == nomePaginaDestino.ToUpper())
                {
                    string url = getURL(info2.FullName, objPageOrigem.AppRelativeVirtualPath) + "?Id=" + idPaginaDestino.ToString();
                    objPageOrigem.Response.Redirect(url);
                    break;
                }
            }
        }

        public static void RedirecionarSimples(Page objPageOrigem, string nomePaginaDestino, string descricao)
        {
            DirectoryInfo info = new DirectoryInfo(HttpContext.Current.Request.ServerVariables["APPL_PHYSICAL_PATH"]);
            nomePaginaDestino = nomePaginaDestino + ".aspx";
            nomePaginaDestino = nomePaginaDestino.Replace(".aspx.aspx", ".aspx");
            foreach (FileInfo info2 in info.GetFiles(nomePaginaDestino, SearchOption.AllDirectories))
            {
                if (info2.Name.ToUpper() == nomePaginaDestino.ToUpper())
                {
                    string url = getURL(info2.FullName, objPageOrigem.AppRelativeVirtualPath) + "?" + descricao;
                    objPageOrigem.Response.Redirect(url);
                    break;
                }
            }
        }

        public static void PermissaoExibeOcultaObjetos(string strIdUsuario, string strIdFilial, ControlCollection objColecaoControlesPagina)
        {
            foreach (Control control in objColecaoControlesPagina)
            {
                if (control.HasControls())
                {
                    PermissaoExibeOcultaObjetos(strIdUsuario, strIdFilial, control.Controls);
                }
                if (((((!(control is Label) && !(control is TextBox)) && (!(control is DropDownList) && !(control is RadioButton))) && !(control is RadioButtonList)) && (control is Button)) && (((control.ID != null) && (control.ID != "")) && ((control.ID.Length >= 4) && (control.ID.Trim().Split(new char[] { '_' }).Length > 1))))
                {
                    ClsPERMISSAO spermissao = new ClsPERMISSAO();
                    if (spermissao.GetPermissao(strIdUsuario, control.ID.Trim().Split(new char[] { '_' })[1].Trim(), strIdFilial))
                    {
                        AtribuiPermissao(control, true);
                    }
                    else
                    {
                        AtribuiPermissao(control, false);
                    }
                }
            }
        }

        public static void RelacionaObjetoClasseControlesPagina(object objetoClasse, ControlCollection objColecaoControlesPagina)
        {
            foreach (Control objControlePagina in objColecaoControlesPagina)
            {
                if (objControlePagina.HasControls())
                {
                    RelacionaObjetoClasseControlesPagina(objetoClasse, objControlePagina.Controls);
                }
                if (!(objControlePagina is Button))
                {
                    if (objControlePagina is Label)
                    {
                        setLabelUltimoUsuario(objetoClasse, objControlePagina);
                    }
                    else if (((objControlePagina.ID != null) && (objControlePagina.ID != "")) && (objControlePagina.ID.Length >= 4))
                    {
                        string idControlePagina = objControlePagina.ID.Substring(3);
                        if (objetoClasse.GetType().Name == Framework.Reflection.PaginaWeb.PaginaWeb.GetNomeClasseIdControlePagina(idControlePagina))
                        {
                            string valorAtribuir = Framework.Reflection.InstanciaClassGeneric.InstanciaClassGeneric.RetornaValorAtributo(objetoClasse, idControlePagina);
                            setValorAtribuirEmControlePagina(objControlePagina, valorAtribuir);
                        }
                    }
                }
            }
        }

        public static bool GravarObjetoBancoDados(Page objPage, ClassGeneric objetoInstancia)
        {
            bool flag2;
            try
            {
                Framework.Reflection.PaginaWeb.PaginaWeb.GetIdUsuarioCorrente(objPage);
                objetoInstancia.NomeTela = objPage.Title;
                bool flag = objetoInstancia.Salvar();
                if (flag)
                {
                    PropertyInfo propertyInfoChamadaID = Framework.Reflection.PaginaWeb.PaginaWeb.GetPropertyInfoChamadaID(objPage);
                    if ((propertyInfoChamadaID == null) || !propertyInfoChamadaID.CanWrite)
                    {
                        throw new Exception("Implemente uma Property ID na pagina em questão com get e set");
                    }
                    propertyInfoChamadaID.SetValue(objPage, objetoInstancia.Id, null);
                    if (((ConfigurationManager.AppSettings["MsgJs"] != null) && (ConfigurationManager.AppSettings["MsgJs"].ToString().Trim() != "")) && (ConfigurationManager.AppSettings["MsgJs"].ToString().Trim().ToLower() == "a"))
                    {
                        //ScriptManager.RegisterStartupScript(objPage, objPage.GetType(), "showalert", "alert('Registro salvo  com sucesso.');", true);
                    }
                    else
                    {
                        Framework.Reflection.PaginaWeb.PaginaWeb.Mensagem(objPage, "Registro salvo com sucesso!", TipoMensagem.Information);
                    }
                }
                else if (((ConfigurationManager.AppSettings["MsgJs"] != null) && (ConfigurationManager.AppSettings["MsgJs"].ToString().Trim() != "")) && (ConfigurationManager.AppSettings["MsgJs"].ToString().Trim().ToLower() == "a"))
                {
                    //ScriptManager.RegisterStartupScript(objPage, objPage.GetType(), "showalert", "alert('Registro não foi salvo!');", true);
                }
                else
                {
                    Framework.Reflection.PaginaWeb.PaginaWeb.Mensagem(objPage, "Registro não foi salvo!", TipoMensagem.Error);
                }
                flag2 = flag;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            return flag2;
        }

        public static void EnviarCamposParaInstancia(Page objPage, ClassGeneric objetoInstancia)
        {
            int valorIDPaginaWeb = Framework.Reflection.PaginaWeb.PaginaWeb.GetValorIDPaginaWeb(objPage);
            Framework.Reflection.InstanciaClassGeneric.InstanciaClassGeneric.PreencherObjeto(objPage.Controls, objetoInstancia, valorIDPaginaWeb);
            
            Framework.Reflection.PaginaWeb.PaginaWeb.preencherCamposAuditoria(objetoInstancia, objPage);
        }

        private static void setLabelUltimoUsuario(object objetoClasse, Control objControlePagina)
        {
        }

        private static object getValorIDPaginaWebRequest(Page objPage)
        {
            object obj2 = objPage.Request["Id"];
            if (obj2 == null)
            {
                obj2 = objPage.Request["ID"];
            }
            if (obj2 == null)
            {
                obj2 = objPage.Request["id"];
            }
            if (obj2 == null)
            {
                obj2 = objPage.Request["iD"];
            }
            return obj2;
        }

        private static PropertyInfo getPropertyInfo(Type tipoObjeto, string nomeProperty)
        {
            return tipoObjeto.GetProperty(nomeProperty, BindingFlags.FlattenHierarchy | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
        }

        public static PropertyInfo GetPropertyInfoChamadaID(Page objPage)
        {
            Type baseType = objPage.GetType().BaseType;
            PropertyInfo info = getPropertyInfo(baseType, "Id");
            if (info == null)
            {
                info = getPropertyInfo(baseType, "ID");
            }
            if (info == null)
            {
                info = getPropertyInfo(baseType, "id");
            }
            if (info == null)
            {
                info = getPropertyInfo(baseType, "iD");
            }
            return info;
        }

        public static int GetValorIDPaginaWeb(Page objPage)
        {
            Tools tools = new Tools();
            object obj2 = getValorIDPaginaWebRequest(objPage);
            int num = 0;
            if ((obj2 != null) && !string.IsNullOrEmpty(tools.RetiraAlfas(obj2.ToString())))
            {
                num = Convert.ToInt32(obj2);
            }
            if (num == 0)
            {
                PropertyInfo propertyInfoChamadaID = GetPropertyInfoChamadaID(objPage);
                if (propertyInfoChamadaID == null)
                {
                    throw new Exception("Implemente uma Property chamada ID na pagina em questão com get e set");
                }
                obj2 = propertyInfoChamadaID.GetValue(objPage, null);
                if (obj2 == null)
                {
                    return num;
                }
                if (!string.IsNullOrEmpty(tools.RetiraAlfas(obj2.ToString())))
                {
                    num = Convert.ToInt32(obj2);
                }
            }
            return num;
        }

        private static void AtribuiPermissao(Control objControlePagina, bool valorAtribuir)
        {
            if (objControlePagina is Button)
            {
                ((Button)objControlePagina).Visible = valorAtribuir;
            }
        }

        private static void setValorAtribuirEmControlePagina(Control objControlePagina, string valorAtribuir)
        {
            if (objControlePagina is TextBox)
            {
                if (((TextBox)objControlePagina).ID.Substring(0, 3) == "TxH")
                {
                    if (valorAtribuirIsDateTime(valorAtribuir))
                    {
                        if (((TextBox)objControlePagina).Text == "00")
                        {
                            ((TextBox)objControlePagina).Text = string.Format("{0:HH}", Convert.ToDateTime(valorAtribuir));
                        }
                        else if (((TextBox)objControlePagina).Text == "00:00:00")
                        {
                            ((TextBox)objControlePagina).Text = string.Format("{0:HH:mm:ss}", Convert.ToDateTime(valorAtribuir));
                        }
                        else
                        {
                            ((TextBox)objControlePagina).Text = string.Format("{0:HH:mm}", Convert.ToDateTime(valorAtribuir));
                        }
                    }
                }
                else if (((GetValorIDPaginaWeb(objControlePagina.Page) <= 0) && (((TextBox)objControlePagina).Text.Trim() == "")) && ((valorAtribuir.Trim().ToLower() == "0".ToLower()) || (valorAtribuir.Trim().ToLower() == "0,00".ToLower())))
                {
                    ((TextBox)objControlePagina).Text = "";
                }
                else
                {
                    ((TextBox)objControlePagina).Text = valorAtribuir;
                }
            }
            else if (objControlePagina is DropDownList)
            {
                if (((DropDownList)objControlePagina).Items.Count > 0)
                {
                    if (((DropDownList)objControlePagina).Items.FindByValue(valorAtribuir) != null)
                    {
                        ((DropDownList)objControlePagina).SelectedValue = valorAtribuir;
                    }
                    else
                    {
                        ((DropDownList)objControlePagina).SelectedIndex = 0;
                    }
                }
            }
            else if (!(objControlePagina is RadioButton))
            {
                if (objControlePagina is RadioButtonList)
                {
                    try
                    {
                        ((RadioButtonList)objControlePagina).SelectedItem.Value = valorAtribuir.Trim();
                    }
                    catch
                    {
                    }
                }
                else if (objControlePagina is CheckBox)
                {
                    ((CheckBox)objControlePagina).Checked = valorAtribuir.Trim() == "1";
                }
                else if (objControlePagina is HiddenField)
                {
                    ((HiddenField)objControlePagina).Value = valorAtribuir;
                }
            }
            else
            {
                string text = ((RadioButton)objControlePagina).Text;
                string str2 = "";
                for (int i = 0; i < text.Length; i++)
                {
                    if (text[i] == ' ')
                    {
                        break;
                    }
                    str2 = str2 + text[i];
                }
                ((RadioButton)objControlePagina).Checked = str2.Trim() == valorAtribuir.Trim();
            }
        }

        private static string getURL(string pathArquivo, string urlPagina)
        {
            urlPagina = urlPagina.Replace(@"\", "/");
            string str = "";
            bool flag = false;
            for (int i = 0; i < urlPagina.Length; i++)
            {
                if (flag)
                {
                    if (urlPagina[i] == '/')
                    {
                        str = str + "../";
                    }
                }
                else if (urlPagina[i] == '/')
                {
                    flag = true;
                }
            }
            string physicalApplicationPath = HttpContext.Current.Request.PhysicalApplicationPath;
            int index = pathArquivo.ToUpper().IndexOf(physicalApplicationPath.ToUpper());
            if (index > 0)
            {
                pathArquivo = pathArquivo.Substring(index);
            }
            pathArquivo = pathArquivo.Replace(physicalApplicationPath, "");
            pathArquivo = pathArquivo.Replace(@"\", "/");
            return (str + pathArquivo);
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

        private static int tratarTipoPreDefinido(int idObjetoEditar, string nomePaginaCadastro)
        {
            return 0;
        }
    }
}