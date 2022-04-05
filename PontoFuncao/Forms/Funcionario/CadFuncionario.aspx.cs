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


public partial class Forms_Funcionario_CadFuncionario : System.Web.UI.Page
{
    private Framework.PontoFuncao.Pessoa objPessoa = new Framework.PontoFuncao.Pessoa();

    protected void btnExcluir_Click(object sender, EventArgs e)
    {
        try
        {
            AcessoBD.ExecutarComandoSql("delete FUNCIONARIO where IDPESSOA = " + this.Id + " ");
            AcessoBD.ExecutarComandoSql("delete PESSOA where IDPESSOA = " + this.Id + " ");

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
                ControlesWeb.SalvarObjeto(this.Page, this.objPessoa);
                ControlesWeb.PreencheWebControls(new Framework.PontoFuncao.Pessoa(), this.Page);
                this.Id = this.objPessoa.IdPessoa;
                txtIdPessoa.Text = this.objPessoa.IdPessoa.ToString().Trim();
                if (this.objPessoa.IdPessoa > 0 && this.txtIdFuncionario.Text.Trim() == "")
                {
                    Framework.PontoFuncao.Funcionario funcionario = new Framework.PontoFuncao.Funcionario();
                    funcionario.IdFuncionario = 0;
                    funcionario.IdPessoa = (this.objPessoa.IdPessoa);
                    if (funcionario.Salvar() && (funcionario.IdFuncionario > 0))
                    {
                        this.txtIdFuncionario.Text = funcionario.IdPessoa.ToString();
                    }
                }
            }
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message, "erro");
        }
    }

    protected void Page_PreRenderComplete(object sender, EventArgs e)
    {
        try
        {
            if (string.IsNullOrEmpty(Framework.Util.ClsUtil.GetVarGlobalStatic("IdUsuario"))) Response.Redirect("~/Login.aspx");

            ControlesWeb.Page_Load(this.Page, this.objPessoa);

            this.btnExcluir_5.Attributes.Add("onclick", "javascript:return confirm('Deseja realmente excluir este registro?');");

            if (!this.Page.IsPostBack)
            {
                if (this.Id > 0)
                {
                    this.txtIdPessoa.Text = this.Id.ToString().Trim();
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
            if (this.txtNome_Pessoa.Text.Trim() == "")
            {
                this.ShowMessage("Informe o nome do funcionário.", "alertar");
                this.txtNome_Pessoa.Focus();
                return false;
            }
            else if (txtNome_Pessoa.Text.Trim() != "")
            {
                string strSql = "select nome ";
                strSql += " from pessoa ";
                strSql += " where pessoa.nome = '" + txtNome_Pessoa.Text + "' ";
                if (this.Id > 0) strSql += " and PESSOA.IDPESSOA <> " + this.Id + "";

                object objPessoa = AcessoBD.ExecutarComandoSqlEscalar(strSql);

                if (objPessoa != null && !string.IsNullOrEmpty(objPessoa.ToString().Trim()))
                {
                    this.ShowMessage("Já existe um funcionário cadastrado com o nome que informou.", "alertar");
                    this.txtNumRegistro_Pessoa.Focus();
                    return false;
                }
            }

            if (this.txtNumRegistro_Pessoa.Text.Trim() == "")
            {
                this.ShowMessage("Informe o número de registro do funcionário.", "alertar");
                this.txtNumRegistro_Pessoa.Focus();
                return false;
            }
            else if (txtNumRegistro_Pessoa.Text.Trim() != "")
            {
                string strSql = "select nome ";
                strSql += " from pessoa ";
                strSql += " where pessoa.NUMREGISTRO = " + txtNumRegistro_Pessoa.Text + " ";
                if(this.Id > 0) strSql += " and PESSOA.IDPESSOA <> " + this.Id + "";

                object objPessoa = AcessoBD.ExecutarComandoSqlEscalar(strSql);

                if (objPessoa != null && !string.IsNullOrEmpty(objPessoa.ToString().Trim()))
                {
                    this.ShowMessage("O funcionário " + objPessoa.ToString().Trim() + " já tem esse número de registro.", "alertar");
                    this.txtNumRegistro_Pessoa.Focus();
                    return false;
                }
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
            this.ViewState["Id"] = value;
        }
    }

    
}