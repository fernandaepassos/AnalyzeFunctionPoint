using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Framework.Sige;
using Infragistics.Web.UI.NavigationControls;

public partial class Master : System.Web.UI.MasterPage
{
    // Fields

    // Methods
    private void LoadPage()
    {
        try
        {
            if (!string.IsNullOrEmpty(Framework.Util.ClsUtil.GetVarGlobalStatic("Nome")))
            {
                this.lblSejaBemVindo.Text = "Seja bem vindo(a) " + Framework.Util.ClsUtil.GetVarGlobalStatic("Nome") + ".";
            }
            else
            {
                this.lblSejaBemVindo.Visible = false;
            }

            if (!string.IsNullOrEmpty(Framework.Util.ClsUtil.GetVarGlobalStatic("Empresa")) && !string.IsNullOrEmpty(Framework.Util.ClsUtil.GetVarGlobalStatic("Filial")))
            {
                string text = this.lblSejaBemVindo.Text;
                this.lblSejaBemVindo.Text = text + " | Empresa: " + Framework.Util.ClsUtil.GetVarGlobalStatic("Empresa") + " | Loja: " + Framework.Util.ClsUtil.GetVarGlobalStatic("Filial");
            }
        }
        catch (Exception exception)
        {
            ClsSigeBugs.InsertBug(exception.GetHashCode().ToString().Trim(), "Descrição: " + exception.Message.ToString().Trim() + " | Local do erro: " + exception.StackTrace, "1", exception.TargetSite.ReflectedType.Name, exception.TargetSite.Name.ToString().Trim(), Framework.Util.ClsUtil.GetVarGlobalStatic("IdUsuario"), DateTime.Now.ToString().Trim());
        }
    }

    protected void menu_ItemSelected(object sender, ExplorerBarItemSelectedEventArgs e)
    {
        try
        {
            Infragistics.Web.UI.NavigationControls.WebExplorerBar objItem = new Infragistics.Web.UI.NavigationControls.WebExplorerBar();
            objItem = (Infragistics.Web.UI.NavigationControls.WebExplorerBar)sender;
        }
        catch (Exception exception)
        {
            ClsSigeBugs.InsertBug(exception.GetHashCode().ToString().Trim(), "Descrição: " + exception.Message.ToString().Trim() + " | Local do erro: " + exception.StackTrace, "1", exception.TargetSite.ReflectedType.Name, exception.TargetSite.Name.ToString().Trim(), Framework.Util.ClsUtil.GetVarGlobalStatic("IdUsuario"), DateTime.Now.ToString().Trim());
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (string.IsNullOrEmpty(Framework.Util.ClsUtil.GetVarGlobalStatic("IdUsuario"))) Response.Redirect("~/Login.aspx");

            if (!this.Page.IsPostBack)
            {
                if (!string.IsNullOrEmpty(Framework.Util.ClsUtil.GetVarGlobalStatic("IdEmpresa")))
                    Session["IdEmpresa"] = Framework.Util.ClsUtil.GetVarGlobalStatic("IdEmpresa");
                else Session.Remove("IdEmpresa");

                if (!string.IsNullOrEmpty(Framework.Util.ClsUtil.GetVarGlobalStatic("IdFilial")))
                    Session["IdFilial"] = Framework.Util.ClsUtil.GetVarGlobalStatic("IdFilial");
                else Session.Remove("IdFilial");

                if (!string.IsNullOrEmpty(Framework.Util.ClsUtil.GetVarGlobalStatic("IdUsuario")))
                    Session["IdUsuario"] = Framework.Util.ClsUtil.GetVarGlobalStatic("IdUsuario");
                else Session.Remove("IdUsuario");

                if (!string.IsNullOrEmpty(Framework.Util.ClsUtil.GetVarGlobalStatic("ControlarPermissao")))
                    Session["ControlarPermissao"] = Framework.Util.ClsUtil.GetVarGlobalStatic("ControlarPermissao");
                else Session.Remove("ControlarPermissao");

                this.LoadPage();
            }
        }
        catch
        {
        }
    }

    #region [   imgSair_Click   ]
    /// <summary>
    /// [   imgSair_Click   ]
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void imgSair_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            base.Application.RemoveAll();
            Response.Redirect("~/Login.aspx");
        }
        catch (Exception exception)
        {
            ClsSigeBugs.InsertBug(exception.GetHashCode().ToString().Trim(), "Descrição: " + exception.Message.ToString().Trim() + " | Local do erro: " + exception.StackTrace, "1", exception.TargetSite.ReflectedType.Name, exception.TargetSite.Name.ToString().Trim(), Framework.Util.ClsUtil.GetVarGlobalStatic("IdUsuario"), DateTime.Now.ToString().Trim());
        }
    }
    #endregion
}
