using System;
using Framework.Reflection.ControlesWeb;
using Framework.Sige;
using System.IO;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

using System.Web.UI.WebControls;
using Framework.Avaliacao;
using System.Data;
using Framework.Util;

public partial class Forms_Funcionario_LstFuncionario : System.Web.UI.Page
{

    protected void btnAtualizar_Click(object sender, EventArgs e)
    {
        try
        {
            this.GvwLista.DataBind();
        }
        catch (Exception)
        {
        }
    }

    protected void btnNovo_Click(object sender, EventArgs e)
    {
        try
        {
            this.dlgCadFuncionario.WindowState = Infragistics.Web.UI.LayoutControls.DialogWindowState.Normal;
            this.dlgCadFuncionario.ContentPane.ContentUrl = "CadFuncionario.aspx?Id=0";
            this.dlgCadFuncionario.ContentPane.ScrollBars = Infragistics.Web.UI.ContentOverflow.Hidden;
            this.dlgCadFuncionario.Header.CaptionText = "Atualização de funcionário";
            this.dlgCadFuncionario.Header.ImageUrl = "~/images/funcionario.png";
        }
        catch (Exception)
        {
        }
    }


    protected void FiltraPesquisa()
    {
        try
        {
            this.DsGrid.FilterExpression = "1 = 1";
            this.GvwLista.DataBind();
            this.LblCount.Text = string.Format("{0} registro(s) apresentado(s)", this.GvwLista.Rows.Count);
        }
        catch (Exception exception)
        {
            throw new Exception(exception.Message);
        }
    }

    protected void GvwLista_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Editar")
            {
                this.dlgCadFuncionario.WindowState = Infragistics.Web.UI.LayoutControls.DialogWindowState.Normal;
                this.dlgCadFuncionario.ContentPane.ContentUrl = "CadFuncionario.aspx?Id=" + e.CommandArgument.ToString().Trim();
                this.dlgCadFuncionario.ContentPane.ScrollBars = Infragistics.Web.UI.ContentOverflow.Hidden;
                this.dlgCadFuncionario.Header.CaptionText = "Atualização de funcionário.";
                this.dlgCadFuncionario.Header.ImageUrl = "~/images/funcionario.png";
            }
            else if(e.CommandName.Trim() == "Excluir")
            {
                try
                {
                    object obj = Framework.Reflection.AcessoBancoDados.AcessoBD.ExecutarComandoSqlEscalar("SELECT EQUIPE.NOME FROM EQUIPEPESSOA  LEFT JOIN EQUIPE ON EQUIPE.IDEQUIPE = EQUIPEPESSOA.IDEQUIPE WHERE EQUIPEPESSOA.IDPESSOA = " + e.CommandArgument.ToString().Trim() + "");
                    if (obj != null && obj.ToString().Trim() != "")
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "showalert", "alert('Este funcionário esta alocado na equipe " + obj.ToString().Trim() + ". Exclusão cancelada.');", true);
                    }
                    else
                    {
                        Framework.Reflection.AcessoBancoDados.AcessoBD.ExecutarComandoSql("delete FUNCIONARIO where IDPESSOA = " + e.CommandArgument.ToString().Trim() + " ");
                        Framework.Reflection.AcessoBancoDados.AcessoBD.ExecutarComandoSql("DELETE USUARIO WHERE IDPESSOA = " + e.CommandArgument.ToString().Trim() + " ");
                        Framework.Reflection.AcessoBancoDados.AcessoBD.ExecutarComandoSql("delete PESSOA where IDPESSOA = " + e.CommandArgument.ToString().Trim() + " ");
                        FiltraPesquisa();
                    }
                }
                catch (Exception)
                {
                }            
            }
        }
        catch (Exception)
        {
        }
    }

    protected void GvwLista_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {
            this.FiltraPesquisa();
        }
        catch (Exception exception)
        {
            this.LblMensagem.ForeColor = Color.Red;
            this.LblMensagem.Text = exception.Message;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(Framework.Util.ClsUtil.GetVarGlobalStatic("IdUsuario"))) Response.Redirect("~/Login.aspx");

        if (!this.Page.IsPostBack)
        {
            this.FiltraPesquisa();
            ControlesWeb.Page_Load(this.Page);
        }
    }

    protected void Paginacao_Grid(object sender, GridViewPageEventArgs e)
    {
        try
        {
            this.GvwLista.PageIndex = e.NewPageIndex;
            this.FiltraPesquisa();
            this.GvwLista.DataBind();
            this.LblCount.Text = string.Format("{0} registro(s) apresentado(s)", this.GvwLista.Rows.Count);
        }
        catch (Exception exception)
        {
            this.LblMensagem.ForeColor = Color.Red;
            this.LblMensagem.Text = exception.Message;
        }
    }
    protected void btnAtualizar_Click1(object sender, EventArgs e)
    {
        FiltraPesquisa();
    }
    
    
    protected void GvwLista_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        { 
             if (e.Row.RowType == DataControlRowType.DataRow)
             {
                 ImageButton imgExcluir = (ImageButton)e.Row.FindControl("imgExcluir");
                 imgExcluir.Attributes.Add("onclick", "javascript:return confirm('Deseja realmente excluir este registro?');");
             }
        }
        catch
        { }
    }
}