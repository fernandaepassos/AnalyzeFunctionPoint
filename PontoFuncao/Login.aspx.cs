using System;
using System.Drawing;
using Framework.Sige;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Framework.PontoFuncao;

public partial class Login : System.Web.UI.Page
{
    private Usuario objUsuario = new Usuario();

    protected void btnEntrar_Click(object sender, EventArgs e)
    {
        try
        {
            if (this.ValidaCampos())
            {
                this.lblMensagem.Visible = false;
                this.objUsuario.Senha = (this.txtSenha.Text.Trim());
                this.objUsuario.Login = (this.txtLogin.Text.Trim());
                string str = System.Configuration.ConfigurationManager.ConnectionStrings["SqlServer"].ConnectionString;

                if (this.objUsuario.ValidaAcessoUsuario(out str))
                {
                    base.Application.Add("IdUsuario", this.objUsuario.IdUsuario);
                    base.Application.Add("IdPessoa", this.objUsuario.IdPessoa);
                    base.Application.Add("Nome", this.objUsuario.Nome);
                    base.Response.Redirect("~/Default.aspx", false);
                }
                else
                {
                    this.lblMensagem.Text = str;
                    this.lblMensagem.Visible = true;
                    this.lblMensagem.ForeColor = Color.Red;
                }
            }
        }
        catch (Exception exception)
        {
            ClsSigeBugs.InsertBug(exception.GetHashCode().ToString().Trim(), "Descrição: " + exception.Message.ToString().Trim() + " | Local do erro: " + exception.StackTrace, "1", exception.TargetSite.ReflectedType.Name, exception.TargetSite.Name.ToString().Trim(), Framework.Util.ClsUtil.GetVarGlobalStatic("IdUsuario"), DateTime.Now.ToString().Trim());
        }
    }

    #region [   Page_Load   ]
    /// <summary>
    /// [   Page_Load   ]
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
           base.Application.RemoveAll();
        }
        catch (Exception exception)
        {
            ClsSigeBugs.InsertBug(exception.GetHashCode().ToString().Trim(), "Descrição: " + exception.Message.ToString().Trim() + " | Local do erro: " + exception.StackTrace, "1", exception.TargetSite.ReflectedType.Name, exception.TargetSite.Name.ToString().Trim(), Framework.Util.ClsUtil.GetVarGlobalStatic("IdUsuario"), DateTime.Now.ToString().Trim());
        }
    }
    #endregion

    private bool ValidaCampos()
    {
        if (this.txtLogin.Text.Trim() == "")
        {
            this.lblMensagem.Text = "Preencha o campo login.";
            this.lblMensagem.ForeColor = Color.Red;
            this.lblMensagem.Visible = true;
            this.txtLogin.Focus();
            return false;
        }
        if (this.txtSenha.Text.Trim() == "")
        {
            this.lblMensagem.Text = "Preencha o campo senha.";
            this.lblMensagem.ForeColor = Color.Red;
            this.lblMensagem.Visible = true;
            this.txtSenha.Focus();
            return false;
        }
        return true;
    }




}