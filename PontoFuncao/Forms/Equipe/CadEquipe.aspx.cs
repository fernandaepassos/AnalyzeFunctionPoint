using System;
using Framework.Reflection.AcessoBancoDados;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Framework.Util;
using Framework.Sige;
using Framework.Reflection.ControlesWeb;
using Framework.Seguranca;


public partial class Forms_Equipe_CadEquipe : System.Web.UI.Page
{
    private Framework.PontoFuncao.Equipe objEquipe = new Framework.PontoFuncao.Equipe();

    protected void btnExcluir_Click(object sender, EventArgs e)
    {
        try
        {
            object objProjeto = Framework.Reflection.AcessoBancoDados.AcessoBD.ExecutarComandoSqlEscalar("select NOME from projeto where idequipe = " + this.Id + "");

            if (objProjeto != null && objProjeto.ToString().Trim() != "")
            {
                ShowMessage("Equipe alocada no projeto " + objProjeto.ToString().Trim() + ". Impossível excluir.", "alertar");
                return;
            }

            Framework.Reflection.AcessoBancoDados.AcessoBD.ExecutarComandoSql("delete equipe where IDEQUIPE = " + this.Id + " ");
            Framework.Reflection.AcessoBancoDados.AcessoBD.ExecutarComandoSql("delete EQUIPEPESSOA where IDEQUIPE = " + this.Id + " ");

            ClsUtil.ClearPages(this);

            ShowMessage("Registro excluído com sucesso.", "ok");
        }
        catch (Exception)
        {
        }
    }

    protected void btnSalvar_Click(object sender, EventArgs e)
    {
        try
        {
            if (this.Validacao())
            {
                ControlesWeb.SalvarObjeto(this.Page, this.objEquipe);
                ControlesWeb.PreencheWebControls(new Framework.PontoFuncao.Equipe(), this.Page);
                this.Id = this.objEquipe.IdEquipe;
                txtIdEquipe.Text = this.objEquipe.IdEquipe.ToString().Trim();

                //if (this.objPessoa.IdPessoa > 0 && this.txtIdFuncionario.Text.Trim() == "")
                //{
                //    Framework.PontoFuncao.Funcionario funcionario = new Framework.PontoFuncao.Funcionario();
                //    funcionario.IdFuncionario = 0;
                //    funcionario.IdPessoa = (this.objPessoa.IdPessoa);
                //    if (funcionario.Salvar() && (funcionario.IdFuncionario > 0))
                //    {
                //        this.txtIdFuncionario.Text = funcionario.IdPessoa.ToString();
                //    }
                //}
            }
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message, "erro");
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (string.IsNullOrEmpty(Framework.Util.ClsUtil.GetVarGlobalStatic("IdUsuario"))) Response.Redirect("~/Login.aspx");

            if (!Page.IsPostBack)
            {
                if (this.Id > 0)
                {
                    this.txtIdEquipe.Text = this.Id.ToString().Trim();
                    FiltraPesquisa();
                }
            }
        }
        catch (Exception)
        {
        }
    }

    protected void Page_PreRenderComplete(object sender, EventArgs e)
    {
        try
        {
            if (string.IsNullOrEmpty(Framework.Util.ClsUtil.GetVarGlobalStatic("IdUsuario"))) Response.Redirect("~/Login.aspx");

            ControlesWeb.Page_Load(this.Page, this.objEquipe);

            this.btnExcluir_5.Attributes.Add("onclick", "javascript:return confirm('Deseja realmente excluir este registro?');");

            if (!Page.IsPostBack)
            {
                if (this.Id > 0)
                {
                    this.txtIdEquipe.Text = this.Id.ToString().Trim();
                    FiltraPesquisa();
                }
            }

        }
        catch (Exception)
        {
        }
    }

    private void ShowMessage(string strMensagemPraExibir, string strTipoImagem)
    {
        try
        {
            this.LblMensagem.Text = strMensagemPraExibir;
            this.LblMensagem.Visible = true;
            string str = strTipoImagem;
            if (str == null)
            {
                goto Label_00CE;
            }
            if (!(str == "excluir"))
            {
                if (str == "alertar")
                {
                    goto Label_0074;
                }
                if (str == "perguntar")
                {
                    goto Label_0092;
                }
                if (str == "ok")
                {
                    goto Label_00B0;
                }
                goto Label_00CE;
            }
            this.imgMsg.ImageUrl = "~/images/excluir_128.png";
            this.imgMsg.Visible = true;
            return;
        Label_0074:
            this.imgMsg.ImageUrl = "~/images/alerta_128.png";
            this.imgMsg.Visible = true;
            return;
        Label_0092:
            this.imgMsg.ImageUrl = "~/images/help_96.png";
            this.imgMsg.Visible = true;
            return;
        Label_00B0:
            this.imgMsg.ImageUrl = "~/images/ok_128.png";
            this.imgMsg.Visible = true;
            return;
        Label_00CE:
            this.imgMsg.ImageUrl = "~/images/alerta_128.png";
            this.imgMsg.Visible = true;
        }
        catch (Exception)
        {
        }
    }

    private bool Validacao()
    {
        try
        {
            if (this.txtNome_Equipe.Text.Trim() == "")
            {
                this.ShowMessage("Informe o nome da equipe.", "alertar");
                this.txtNome_Equipe.Focus();
                return false;
            }
            else if (txtNome_Equipe.Text.Trim() != "")
            {
                string strSql = "select  * from equipe where NOME = '" + txtNome_Equipe.Text.Trim() + "' ";

                if (this.Id > 0) strSql += " and idequipe <> " + this.Id + " ";

                object objEquipe = AcessoBD.ExecutarComandoSqlEscalar(strSql);

                if (objEquipe != null && !string.IsNullOrEmpty(objEquipe.ToString().Trim()))
                {
                    this.ShowMessage("O nome dessa equipe já existe para outra equipe.", "alertar");
                    this.txtNome_Equipe.Focus();
                    return false;
                }
            }

            if (this.txtHoraPorPontoFuncao_Equipe.Text.Trim() == "")
            {
                this.ShowMessage("Informe a hora por ponto de função.", "alertar");
                this.txtHoraPorPontoFuncao_Equipe.Focus();
                return false;
            }

            if (this.txtValorPontoFuncao_Equipe.Text.Trim() == "")
            {
                this.ShowMessage("Informe o valor por ponto de função.", "alertar");
                this.txtValorPontoFuncao_Equipe.Focus();
                return false;
            }

           
            return true;
        }
        catch (Exception exception)
        {
            this.ShowMessage(exception.Message, "alertar");
            return false;
        }
    }

    public int Id
    {
        get
        {
            try
            {
                return Convert.ToInt32(this.ViewState["Id"]);
            }
            catch
            {
                return 0;
            }
        }
        set
        {
            txtIdEquipe.Text = value.ToString().Trim();
            this.ViewState["Id"] = value;
        }
    }

    protected void btnAdicionarHrAcesso_Click(object sender, EventArgs e)
    {
        try
        {
            if (this.Id <= 0)
            {
                ShowMessage("Primeiro salve a equipe para depois associar os funcionários.","alerta");
                return;
            }

            if (string.IsNullOrEmpty(ddlFuncionario.SelectedValue.Trim()) || ddlFuncionario.SelectedValue.Trim() == "0")
            {
                ShowMessage("Selecione o funcionário.", "alerta");
                return;
            }

            object objPessoa = AcessoBD.ExecutarComandoSqlEscalar("SELECT IDPESSOA FROM EQUIPEPESSOA WHERE IDPESSOA = "+ ddlFuncionario.SelectedValue.Trim() +" AND IDEQUIPE = "+ this.Id +"");
            if (objPessoa != null && objPessoa.ToString().Trim() != "" && Convert.ToInt32(objPessoa) > 0)
            {
                ShowMessage("O funcionário selecionado já esta associado a equipe.", "alerta");
                return;
            }

            AcessoBD.ExecutarComandoSqlEscalar("insert into EQUIPEPESSOA values ("+ ddlFuncionario.SelectedValue.Trim() +","+ this.Id +",NULL, NULL) ");
            FiltraPesquisa();
            ShowMessage("Associação realizada com sucesso.", "ok");
        }
        catch (Exception exception)
        {
            ClsSigeBugs.InsertBug(exception.GetHashCode().ToString().Trim(), "Descrição: " + exception.Message.ToString().Trim() + " | Local do erro: " + exception.StackTrace, "3", exception.TargetSite.ReflectedType.Name, exception.TargetSite.Name.ToString().Trim(), Framework.Util.ClsUtil.GetVarGlobalStatic("IdUsuario"), DateTime.Now.ToString().Trim(), Framework.Util.ClsUtil.GetVarGlobalStatic("IdEmpresa"));
        }
    }

    protected void gridEquipePessoas_Sorting(object sender, GridViewSortEventArgs e)
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

    protected void Paginacao_Grid(object sender, GridViewPageEventArgs e)
    {
        try
        {
            this.gridEquipePessoas.PageIndex = e.NewPageIndex;
            this.FiltraPesquisa();
            this.gridEquipePessoas.DataBind();
            this.LblCount.Text = string.Format("{0} registro(s) apresentado(s)", this.gridEquipePessoas.Rows.Count);
        }
        catch (Exception exception)
        {
            this.LblMensagem.ForeColor = Color.Red;
            this.LblMensagem.Text = exception.Message;
        }
    }

    protected void FiltraPesquisa()
    {
        try
        {
            this.DsgridEquipePessoas.FilterExpression = "1 = 1";
            this.gridEquipePessoas.DataBind();
            this.LblCount.Text = string.Format("{0} registro(s) apresentado(s)", this.gridEquipePessoas.Rows.Count);
        }
        catch (Exception exception)
        {
            throw new Exception(exception.Message);
        }
    }

    protected void gridEquipePessoas_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Excluir")
            {
                AcessoBD.ExecutarComandoSqlEscalar("delete EQUIPEPESSOA where IDPESSOA = " + e.CommandArgument.ToString().Trim() + " ");
                FiltraPesquisa();
                ShowMessage("Pessoa desassociada com sucesso.", "ok");
            }
        }
        catch (Exception)
        {
        }
    }
}