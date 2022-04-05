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


public partial class Forms_Projeto_CadProjeto : System.Web.UI.Page
{
    private Framework.PontoFuncao.Projeto objProjeto = new Framework.PontoFuncao.Projeto();

    private int _intSomaContagem;
    public int intSomaContagem
    {
        set
        {
            _intSomaContagem = value;
        }
        get
        {
            return _intSomaContagem;
        }
    }

    protected void btnExcluir_Click(object sender, EventArgs e)
    {
        try
        {
            if (this.Id <= 0)
            {
                ShowMessage("Não há registro salvo na tela para exclusão.", "alerta");
                return;
            }
            Session.Remove("IdProjeto");
            Framework.Reflection.AcessoBancoDados.AcessoBD.ExecutarComandoSql("delete PROJETOFUNCAOTRANSACAO where IDPROJETO = " + this.Id + " ");
            Framework.Reflection.AcessoBancoDados.AcessoBD.ExecutarComandoSql("delete PROJETOFUNCAODADOS where IDPROJETO = " + this.Id + " ");
            Framework.Reflection.AcessoBancoDados.AcessoBD.ExecutarComandoSql("delete PROJETOCONTAGEM where IDPROJETO = " + this.Id + " ");
            Framework.Reflection.AcessoBancoDados.AcessoBD.ExecutarComandoSql("delete PROJETOCOMPLEXIDADE where IDPROJETO = " + this.Id + " ");
            Framework.Reflection.AcessoBancoDados.AcessoBD.ExecutarComandoSql("delete PROJETO where IDPROJETO = " + this.Id + " ");

            ClsUtil.ClearPages(this);
            WebTab1.Tabs[1].Hidden = true;

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
                ControlesWeb.SalvarObjeto(this.Page, this.objProjeto);
                ControlesWeb.PreencheWebControls(new Framework.PontoFuncao.Projeto(), this.Page);
                this.Id = this.objProjeto.IdProjeto;
                Session["IdProjeto"] = this.objProjeto.IdProjeto.ToString().Trim();
                txtIdProjeto.Text = this.objProjeto.IdProjeto.ToString().Trim();
                HabilitaHabas();
                SomaContagem();
                SalvarComplexidade();
            }
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message, "erro");
        }
    }

    private void SalvarContagem()
    {
        try
        {

            if (this.Id <= 0)
            {
                ShowMessage("Salve o projeto antes de salvar os dados da contagem.","alertar");
                return;
            }

            if (txtComunicacaoDados.Text.Trim() != "" || txtProcessamentoDistribuido.Text.Trim() != "" || txtPerformance.Text.Trim() != "" || txtConfigIntensaUsada.Text.Trim() != "" || txtVolumeTransacao.Text.Trim() != "" || txtEntradaDadosOnline.Text.Trim() != "" || txtEficienciaUsuarioFinal.Text.Trim() != "" || txtAtualizacaoOnline.Text.Trim() != "" || txtProcessamentoComplexo.Text.Trim() != "" || txtReusabilidade.Text.Trim() != "" || txtFacilidadeInstalacao.Text.Trim() != "" || txtFacilidadeOperacao.Text.Trim() != "" || txtMultiplosLocais.Text.Trim() != "" || txtFacilidadeMudancao.Text.Trim() != "")
            {
                if (txtComunicacaoDados.Text.Trim() == "" || txtProcessamentoDistribuido.Text.Trim() == "" || txtPerformance.Text.Trim() == "" || txtConfigIntensaUsada.Text.Trim() == "" || txtVolumeTransacao.Text.Trim() == "" || txtEntradaDadosOnline.Text.Trim() == "" || txtEficienciaUsuarioFinal.Text.Trim() == "" || txtAtualizacaoOnline.Text.Trim() == "" || txtProcessamentoComplexo.Text.Trim() == "" || txtReusabilidade.Text.Trim() == "" || txtFacilidadeInstalacao.Text.Trim() == "" || txtFacilidadeOperacao.Text.Trim() == "" || txtMultiplosLocais.Text.Trim() == "" || txtFacilidadeMudancao.Text.Trim() == "")
                {
                    ShowMessage("Se preencher um campo de contagem, todos os outros serão obrigatórios.", "alertar");
                    return;
                }
            }

            Framework.PontoFuncao.ProjetoContagem objProjetoContagem = new Framework.PontoFuncao.ProjetoContagem();

            objProjetoContagem.IdProjetoContagem = (txtIdProjetoContagem.Text.Trim() == "" ? 0 : Convert.ToInt32(txtIdProjetoContagem.Text.Trim())); 
            objProjetoContagem.IdProjeto = this.Id;

            

            if (txtComunicacaoDados.Text.Trim() != "")
                objProjetoContagem.ComunicacaoDados =  Convert.ToInt32(txtComunicacaoDados.Text.Trim());
            
            if (txtProcessamentoDistribuido.Text.Trim() != "")
                objProjetoContagem.ProcessamentoDistribuido =Convert.ToInt32(txtProcessamentoDistribuido.Text.Trim());
            
            if(txtPerformance.Text.Trim() != "")
                objProjetoContagem.Performance = Convert.ToInt32(txtPerformance.Text.Trim());

            if (txtConfigIntensaUsada.Text.Trim() != "")
                objProjetoContagem.ConfigIntensaUsada = Convert.ToInt32(txtConfigIntensaUsada.Text.Trim());

            if (txtVolumeTransacao.Text.Trim() != "")
                objProjetoContagem.VolumeTransacao = Convert.ToInt32(txtVolumeTransacao.Text.Trim());

            if (txtEntradaDadosOnline.Text.Trim() != "")
                objProjetoContagem.EntradaDadosOnline = Convert.ToInt32(txtEntradaDadosOnline.Text.Trim());


            if (txtEficienciaUsuarioFinal.Text.Trim() != "")
                objProjetoContagem.EficienciaUsuarioFinal = Convert.ToInt32(txtEficienciaUsuarioFinal.Text.Trim());


            if (txtAtualizacaoOnline.Text.Trim() != "")
                objProjetoContagem.AtualizacaoOnline = Convert.ToInt32(txtAtualizacaoOnline.Text.Trim());


            if (txtProcessamentoComplexo.Text.Trim() != "")
                objProjetoContagem.ProcessamentoComplexo = Convert.ToInt32(txtProcessamentoComplexo.Text.Trim()) ;

            if (txtReusabilidade.Text.Trim() != "")
                objProjetoContagem.Reusabilidade = Convert.ToInt32(txtReusabilidade.Text.Trim());

            if (txtFacilidadeInstalacao.Text.Trim() != "")
                objProjetoContagem.FacilidadeInstalacao = Convert.ToInt32(txtFacilidadeInstalacao.Text.Trim());

            if (txtFacilidadeOperacao.Text.Trim() != "")
                objProjetoContagem.FacilidadeOperacao = Convert.ToInt32(txtFacilidadeOperacao.Text.Trim());

            if (txtMultiplosLocais.Text.Trim() != "")
                objProjetoContagem.MultiplosLocais = Convert.ToInt32(txtMultiplosLocais.Text.Trim());


            if (txtFacilidadeMudancao.Text.Trim() != "")
                objProjetoContagem.FacilidadeMudancao= Convert.ToInt32(txtFacilidadeMudancao.Text.Trim());

            objProjetoContagem.Soma = SomaContagem();

            objProjetoContagem.Vaf = (objProjetoContagem.Soma * 0.01) + 0.65;
            
            objProjetoContagem.Salvar();

            txtIdProjetoContagem.Text = objProjetoContagem.IdProjetoContagem.ToString().Trim();

            SomaContagem();

            

            ShowMessage("Operação realizada com sucesso.", "ok");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (this.Id > 0)
            {
                Session["IdProjeto"] = this.Id.ToString().Trim();
                txtIdProjeto.Text = this.Id.ToString().Trim();
                
            }

            CalculaVisaoGeral();
            PreencheCampo();
            
        }
    }

    protected void Page_PreRenderComplete(object sender, EventArgs e)
    {
        try
        {
            if (string.IsNullOrEmpty(Framework.Util.ClsUtil.GetVarGlobalStatic("IdUsuario"))) Response.Redirect("~/Login.aspx");

            ControlesWeb.Page_Load(this.Page, this.objProjeto);

            this.btnExcluir_5.Attributes.Add("onclick", "javascript:return confirm('Deseja realmente excluir este registro?');");

            if (!this.Page.IsPostBack)
            {
                if (this.Id > 0)
                {
                    Session["IdProjeto"] = this.Id.ToString().Trim();
                    this.txtIdProjeto.Text = this.Id.ToString().Trim();
                    PreencheCampo();
                }
            }


            CalculaVisaoGeral();
            HabilitaHabas();
        }
        catch (Exception)
        {
        }
    }

    private void PreencheCampo()
    {
        try
        {
            SomaContagem();
            Framework.PontoFuncao.ProjetoContagem objProjetoContagem = new Framework.PontoFuncao.ProjetoContagem();
            Framework.PontoFuncao.ProjetoComplexidade objProjetoComplexidade = new Framework.PontoFuncao.ProjetoComplexidade();

            if (this.Id > 0)
            {
                

                object objId = AcessoBD.ExecutarComandoSqlEscalar("SELECT IDPROJETOCONTAGEM FROM PROJETOCONTAGEM WHERE IDPROJETO = " + this.Id + "");

                if (objId != null && Convert.ToInt32(objId) > 0)
                {
                    objProjetoContagem.GetById(Convert.ToInt32(objId));
                    txtIdProjetoContagem.Text = objProjetoContagem.IdProjetoContagem.ToString();
                    txtComunicacaoDados.Text = (objProjetoContagem.Soma == Convert.ToDouble(35) && objProjetoContagem.ComunicacaoDados == 0 ? "" : objProjetoContagem.ComunicacaoDados.ToString().Trim());
                    txtProcessamentoDistribuido.Text = (objProjetoContagem.Soma == Convert.ToDouble(35) && objProjetoContagem.ProcessamentoDistribuido == 0 ? "" : objProjetoContagem.ProcessamentoDistribuido.ToString().Trim());
                    txtPerformance.Text = (objProjetoContagem.Soma == Convert.ToDouble(35) && objProjetoContagem.Performance == 0 ? "" : objProjetoContagem.Performance.ToString().Trim());
                    txtConfigIntensaUsada.Text = (objProjetoContagem.Soma == Convert.ToDouble(35) && objProjetoContagem.ConfigIntensaUsada == 0 ? "" : objProjetoContagem.ConfigIntensaUsada.ToString().Trim());
                    txtVolumeTransacao.Text = (objProjetoContagem.Soma == Convert.ToDouble(35) && objProjetoContagem.VolumeTransacao == 0 ? "" : objProjetoContagem.VolumeTransacao.ToString().Trim());
                    txtEntradaDadosOnline.Text = (objProjetoContagem.Soma == Convert.ToDouble(35) && objProjetoContagem.EntradaDadosOnline == 0 ? "" : objProjetoContagem.EntradaDadosOnline.ToString().Trim());
                    txtEficienciaUsuarioFinal.Text = (objProjetoContagem.Soma == Convert.ToDouble(35) && objProjetoContagem.EficienciaUsuarioFinal == 0 ? "" : objProjetoContagem.EficienciaUsuarioFinal.ToString().Trim());
                    txtAtualizacaoOnline.Text = (objProjetoContagem.Soma == Convert.ToDouble(35) && objProjetoContagem.AtualizacaoOnline == 0 ? "" : objProjetoContagem.AtualizacaoOnline.ToString().Trim());
                    txtProcessamentoComplexo.Text = (objProjetoContagem.Soma == Convert.ToDouble(35) && objProjetoContagem.ProcessamentoComplexo == 0 ? "" : objProjetoContagem.ProcessamentoComplexo.ToString().Trim());
                    txtReusabilidade.Text = (objProjetoContagem.Soma == Convert.ToDouble(35) && objProjetoContagem.Reusabilidade == 0 ? "" : objProjetoContagem.Reusabilidade.ToString().Trim());
                    txtFacilidadeInstalacao.Text = (objProjetoContagem.Soma == Convert.ToDouble(35) && objProjetoContagem.FacilidadeInstalacao == 0 ? "" : objProjetoContagem.FacilidadeInstalacao.ToString().Trim());
                    txtFacilidadeOperacao.Text = (objProjetoContagem.Soma == Convert.ToDouble(35) && objProjetoContagem.FacilidadeOperacao == 0 ? "" : objProjetoContagem.FacilidadeOperacao.ToString().Trim());
                    txtMultiplosLocais.Text = (objProjetoContagem.Soma == Convert.ToDouble(35) && objProjetoContagem.MultiplosLocais == 0 ? "" : objProjetoContagem.MultiplosLocais.ToString().Trim());
                    txtFacilidadeMudancao.Text = (objProjetoContagem.Soma == Convert.ToDouble(35) && objProjetoContagem.FacilidadeMudancao == 0 ? "" : objProjetoContagem.FacilidadeMudancao.ToString().Trim()); ;
                    SomaContagem();
                }

                object objId1 = AcessoBD.ExecutarComandoSqlEscalar("SELECT IDPROJETOCOMPLEXIDADE FROM PROJETOCOMPLEXIDADE WHERE IDPROJETO = "+ this.Id +"");
                if (objId1 != null && Convert.ToInt32(objId1) > 0)
                {
                    objProjetoComplexidade.GetById(Convert.ToInt32(objId1));
                    txtIdProjetoComplexidade.Text = objProjetoComplexidade.IdProjetoComplexidade.ToString().Trim();
                    txtAIE_BAIXO.Text = objProjetoComplexidade.AIE_BAIXO.ToString().Trim();
                    txtAIE_MEDIO.Text = objProjetoComplexidade.AIE_MEDIO.ToString();
                    txtAIE_ALTO.Text = objProjetoComplexidade.AIE_ALTO.ToString().Trim();
                    txtALI_BAIXO.Text = objProjetoComplexidade.ALI_BAIXO.ToString();
                    txtALI_MEDIO.Text = objProjetoComplexidade.ALI_MEDIO.ToString();
                    txtALI_ALTO.Text = objProjetoComplexidade.ALI_ALTO.ToString();
                    txtEE_BAIXO.Text = objProjetoComplexidade.EE_BAIXO.ToString();
                    txtEE_MEDIO.Text = objProjetoComplexidade.EE_MEDIO.ToString();
                    txtEE_ALTO.Text = objProjetoComplexidade.EE_ALTO.ToString();
                    txtCE_BAIXA.Text = objProjetoComplexidade.CE_BAIXA.ToString();
                    txtCE_MEDIA.Text = objProjetoComplexidade.CE_MEDIA.ToString();
                    txtCE_ALTA.Text = objProjetoComplexidade.CE_ALTA.ToString();
                    txtSE_BAIXA.Text = objProjetoComplexidade.SE_BAIXA.ToString();
                    txtSE_MEDIA.Text = objProjetoComplexidade.SE_MEDIA.ToString();
                    txtSE_ALTA.Text = objProjetoComplexidade.SE_ALTA.ToString();
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
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
            if (this.txtNome_Projeto.Text.Trim() == "")
            {
                this.ShowMessage("Informe o nome do projeto.", "alertar");
                this.txtNome_Projeto.Focus();
                return false;
            }
            else if (txtNome_Projeto.Text.Trim() != "")
            {
                string strSql = "SELECT NOME FROM PROJETO WHERE NOME = '" + txtNome_Projeto.Text + "' ";
                if (this.Id > 0) strSql += " and PROJETO.IDPROJETO <> " + this.Id + "";

                object objProjeto = AcessoBD.ExecutarComandoSqlEscalar(strSql);

                if (objProjeto != null && !string.IsNullOrEmpty(objProjeto.ToString().Trim()))
                {
                    this.ShowMessage("Já existe um projeto cadastrado com esse nome.", "alertar");
                    this.txtNome_Projeto.Focus();
                    return false;
                }
            }

            if (this.ddlIdEquipe_Projeto.SelectedValue.Trim() == "" || this.ddlIdEquipe_Projeto.SelectedValue.Trim() == "0")
            {
                this.ShowMessage("Informe a equipe.", "alertar");
                this.ddlIdEquipe_Projeto.Focus();
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
                if (this.ViewState["Id"] != null)
                    return Convert.ToInt32(this.ViewState["Id"]);
                else if (txtIdProjeto != null && txtIdProjeto.Text.Trim() != "")
                    return Convert.ToInt32(txtIdProjeto.Text.Trim());
                else return 0;
            }
            catch
            {
                return 0;
            }
        }
        set
        {
            this.ViewState["Id"] = value;
            txtIdProjeto.Text = value.ToString().Trim();
        }
    }

    private void CalculaVisaoGeral()
    {

        try
        {
            if (this.Id <= 0) return;

            //* O campo tamanho funcional deverá ser a soma de todos os pontos de função do projeto.
            string strSql = "SELECT ((SELECT CASE WHEN SUM(QTDPONTOFUNCAO) IS NULL THEN 0 ELSE SUM(QTDPONTOFUNCAO) END AS PF_FUNCAODADOS FROM PROJETOFUNCAODADOS WHERE IDPROJETO = "+ this.Id +")  ";
            strSql += " + (SELECT CASE WHEN SUM(QTDPONTOFUNCAO) IS NULL THEN 0 ELSE SUM(QTDPONTOFUNCAO) END AS PF_FUNCAOTRANSACAO FROM PROJETOFUNCAOTRANSACAO WHERE IDPROJETO = "+ this.Id +")) TamahoFuncional ";

            object objTamahoFuncional = AcessoBD.ExecutarComandoSqlEscalar(strSql);
            if (objTamahoFuncional != null && Convert.ToInt32(objTamahoFuncional.ToString()) > 0)
                txtTamahoFuncional.Text = objTamahoFuncional.ToString().Trim();
            else txtTamahoFuncional.Text = "0";

            //* Tamanho funcional ajustado é o tamanho funcional (valor de cima = soma de todos os pontos de função ) vezes o VAF que foi encontrado no configurar contagem.         
            strSql  = " SELECT ";
            strSql += "( ";
	        strSql += " ((SELECT CASE WHEN SUM(QTDPONTOFUNCAO) IS NULL THEN 0 ELSE SUM(QTDPONTOFUNCAO) END AS PF_FUNCAODADOS FROM PROJETOFUNCAODADOS WHERE IDPROJETO = "+ this.Id +")  ";
	        strSql += "  +   ";
	        strSql += "  (SELECT CASE WHEN SUM(QTDPONTOFUNCAO) IS NULL THEN 0 ELSE SUM(QTDPONTOFUNCAO) END AS PF_FUNCAOTRANSACAO FROM PROJETOFUNCAOTRANSACAO WHERE IDPROJETO = "+ this.Id +"))  ";
	        strSql += "  * (SELECT VAF FROM PROJETOCONTAGEM WHERE IDPROJETO = "+ this.Id +")  ";
            strSql += " ) TamahoFuncional ";

            object objTamahoFuncionalAjustado = AcessoBD.ExecutarComandoSqlEscalar(strSql);
            if (objTamahoFuncionalAjustado != null && objTamahoFuncionalAjustado.ToString().Trim() != "" && Convert.ToInt32(objTamahoFuncionalAjustado.ToString()) > 0)
                txtTamahoFuncionalAjustado.Text = objTamahoFuncionalAjustado.ToString().Trim();
            else
                txtTamahoFuncionalAjustado.Text = "0";

            //* O campo tempo homem hora é o tamanho funcional ajustado ( que é o segundo campo ) vezes o tempo homem hora  da equipe do projeto. 
            object objTempoHomemHora = AcessoBD.ExecutarComandoSqlEscalar("SELECT HORAPORPONTOFUNCAO FROM EQUIPE WHERE IDEQUIPE IN (SELECT IDEQUIPE FROM PROJETO WHERE IDPROJETO = "+ this.Id +")");
            int intTamahoFuncionalAjustado = (txtTamahoFuncionalAjustado.Text.Trim() == "" ? 0 : Convert.ToInt32(txtTamahoFuncionalAjustado.Text.Trim()));
            int intTempoHomemHora = (objTempoHomemHora == null || objTempoHomemHora.ToString().Trim() == "" ? 0 : Convert.ToInt32(objTempoHomemHora));
            txtTempoHomemHora.Text = (intTamahoFuncionalAjustado * intTempoHomemHora).ToString(); ;


            //* O valor total do projeto é "tamanho funcional ajustado" vezes "tela de equipe"."valor do ponto de função" (** Usar o termo "Preço do ponto de função".
            object objValorTotalProjeto = AcessoBD.ExecutarComandoSqlEscalar("SELECT VALORPONTOFUNCAO FROM EQUIPE WHERE IDEQUIPE IN (SELECT IDEQUIPE FROM PROJETO WHERE IDPROJETO = " + this.Id + ")");
            double dblTempoHomemHora = (objValorTotalProjeto == null || objValorTotalProjeto.ToString().Trim() == "" ? 0 : Convert.ToDouble(objValorTotalProjeto));
            txtValorTotalProjeto.Text = "R$ " + (intTamahoFuncionalAjustado * dblTempoHomemHora).ToString("N2");


        }
        catch
        { }
    }

    private void HabilitaHabas()
    {
        try
        {
            gridFuncaoTransacao.DataBind();
            DsGridFuncaoDados.DataBind();

            if (this.Id <= 0)
            {
                WebTab1.Tabs[1].Hidden = true;
                WebTab1.Tabs[2].Hidden = true;
                WebTab1.Tabs[3].Hidden = true;
                WebTab1.Tabs[4].Hidden = true;
                divVisaoGeral.Visible = false;
            }
            else
            {
                WebTab1.Tabs[1].Hidden = false;
                WebTab1.Tabs[2].Hidden = false;
                WebTab1.Tabs[3].Hidden = false;
                WebTab1.Tabs[4].Hidden = false;
                divVisaoGeral.Visible = true;
            }
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }

    protected void btnContagem_Click(object sender, EventArgs e)
    {
        try
        {
            SalvarContagem();
        }
        catch
        { 
        
        }
    }
    
    protected void Contagem_TextChanged(object sender, EventArgs e)
    {
        try
        {
            TextBox objTextBox = (TextBox)sender;
            if (objTextBox != null)
            {

                SomaContagem();
            }

        }
        catch
        { }
    }

    private int SomaContagem()
    {
        try
        {
            int objSomaContagem = 
            (txtComunicacaoDados.Text.Trim() != "" ? Convert.ToInt32(txtComunicacaoDados.Text.Trim()) : 0)
            + (txtProcessamentoDistribuido.Text.Trim() != "" ? Convert.ToInt32(txtProcessamentoDistribuido.Text.Trim()) : 0)
            + (txtPerformance.Text.Trim() != "" ? Convert.ToInt32(txtPerformance.Text.Trim()) : 0)
            + (txtConfigIntensaUsada.Text.Trim() != "" ? Convert.ToInt32(txtConfigIntensaUsada.Text.Trim()) : 0)
            + (txtVolumeTransacao.Text.Trim() != "" ? Convert.ToInt32(txtVolumeTransacao.Text.Trim()) : 0)
            + (txtEntradaDadosOnline.Text.Trim() != "" ? Convert.ToInt32(txtEntradaDadosOnline.Text.Trim()) : 0)
            + (txtEficienciaUsuarioFinal.Text.Trim() != "" ? Convert.ToInt32(txtEficienciaUsuarioFinal.Text.Trim()) : 0)
            + (txtAtualizacaoOnline.Text.Trim() != "" ? Convert.ToInt32(txtAtualizacaoOnline.Text.Trim()) : 0)
            + (txtProcessamentoComplexo.Text.Trim() != "" ? Convert.ToInt32(txtProcessamentoComplexo.Text.Trim()) : 0)
            + (txtReusabilidade.Text.Trim() != "" ? Convert.ToInt32(txtReusabilidade.Text.Trim()) : 0)
            + (txtFacilidadeInstalacao.Text.Trim() != "" ? Convert.ToInt32(txtFacilidadeInstalacao.Text.Trim()) : 0)
            + (txtFacilidadeOperacao.Text.Trim() != "" ? Convert.ToInt32(txtFacilidadeOperacao.Text.Trim()) : 0)
            + (txtMultiplosLocais.Text.Trim() != "" ? Convert.ToInt32(txtMultiplosLocais.Text.Trim()) : 0)
            + (txtFacilidadeMudancao.Text.Trim() != "" ? Convert.ToInt32(txtFacilidadeMudancao.Text.Trim()) : 0);

            if (objSomaContagem > 0)
            {
                lblContagemSome.Text = "Soma: " + objSomaContagem.ToString().Trim();
            }
            else if (objSomaContagem <= 0)
            {
                if(SomaContagemTodosCamposComZero())
                {
                    lblContagemSome.Text = "Soma: 0";
                    objSomaContagem = 0;
                }
                else
                {
                    lblContagemSome.Text = "Soma: 35";
                    objSomaContagem = 35;
                }
            }

            return objSomaContagem;
        }
        catch
        {
            return 0;
        }    
    }

    private bool SomaContagemTodosCamposComZero()
    {
        try
        {
            if(txtComunicacaoDados.Text.Trim() == "0" && txtProcessamentoDistribuido.Text.Trim() == "0" && txtPerformance.Text.Trim() == "0" && txtConfigIntensaUsada.Text == "0" && txtVolumeTransacao.Text.Trim() == "0" && txtEntradaDadosOnline.Text.Trim() == "0" && txtEficienciaUsuarioFinal.Text.Trim() == "0" && txtAtualizacaoOnline.Text.Trim() == "0" && txtProcessamentoComplexo.Text.Trim() == "0" && txtProcessamentoComplexo.Text.Trim() == "0" && txtReusabilidade.Text.Trim() == "0" && txtFacilidadeInstalacao.Text.Trim() == "0" && txtFacilidadeOperacao.Text.Trim() == "0" && txtMultiplosLocais.Text.Trim() == "0" && txtFacilidadeMudancao.Text.Trim() == "0")
                return true;
            else return false;
        }
        catch 
        {
            return false;
        }

    }

    protected void btnConfigComplexidade_Click(object sender, EventArgs e)
    {
        SalvarComplexidade();
    }

    private void SalvarComplexidade()
    {
        try
        {

            if (this.Id <= 0)
            {
                ShowMessage("Salve o projeto antes de salvar os dados da complexidade.", "alertar");
                return;
            }

            Framework.PontoFuncao.ProjetoComplexidade objProjetoComplexidade = new Framework.PontoFuncao.ProjetoComplexidade();

            objProjetoComplexidade.IdProjetoComplexidade = (txtIdProjetoComplexidade.Text.Trim() == "" ? 0 : Convert.ToInt32(txtIdProjetoComplexidade.Text.Trim()));
            objProjetoComplexidade.IdProjeto = this.Id;

            objProjetoComplexidade.AIE_BAIXO =  (txtAIE_BAIXO.Text.Trim() != "" ? Convert.ToInt32(txtAIE_BAIXO.Text.Trim()) : 0);
            objProjetoComplexidade.AIE_MEDIO = (txtAIE_MEDIO.Text.Trim() != "" ? Convert.ToInt32(txtAIE_MEDIO.Text.Trim()) : 0);
            objProjetoComplexidade.AIE_ALTO = (txtAIE_ALTO.Text.Trim() != "" ? Convert.ToInt32(txtAIE_ALTO.Text.Trim()) : 0);
            objProjetoComplexidade.ALI_BAIXO = (txtALI_BAIXO.Text.Trim() != "" ? Convert.ToInt32(txtALI_BAIXO.Text.Trim()) : 0);
            objProjetoComplexidade.ALI_MEDIO = (txtALI_MEDIO.Text.Trim() != "" ? Convert.ToInt32(txtALI_MEDIO.Text.Trim()) : 0);
            objProjetoComplexidade.ALI_ALTO = (txtALI_ALTO.Text.Trim() != "" ? Convert.ToInt32(txtALI_ALTO.Text.Trim()) : 0);
            objProjetoComplexidade.EE_BAIXO = (txtEE_BAIXO.Text.Trim() != "" ? Convert.ToInt32(txtEE_BAIXO.Text.Trim()) : 0);
            objProjetoComplexidade.EE_MEDIO = (txtEE_MEDIO.Text.Trim() != "" ? Convert.ToInt32(txtEE_MEDIO.Text.Trim()) : 0);
            objProjetoComplexidade.EE_ALTO = (txtEE_ALTO.Text.Trim() != "" ? Convert.ToInt32(txtEE_ALTO.Text.Trim()) : 0);
            objProjetoComplexidade.CE_BAIXA = (txtCE_BAIXA.Text.Trim() != "" ? Convert.ToInt32(txtCE_BAIXA.Text.Trim()) : 0);
            objProjetoComplexidade.CE_MEDIA = (txtCE_MEDIA.Text.Trim() != "" ? Convert.ToInt32(txtCE_MEDIA.Text.Trim()) : 0);
            objProjetoComplexidade.CE_ALTA = (txtCE_ALTA.Text.Trim() != "" ? Convert.ToInt32(txtCE_ALTA.Text.Trim()) : 0);
            objProjetoComplexidade.SE_BAIXA = (txtSE_BAIXA.Text.Trim() != "" ? Convert.ToInt32(txtSE_BAIXA.Text.Trim()) : 0);
            objProjetoComplexidade.SE_MEDIA = (txtSE_MEDIA.Text.Trim() != "" ? Convert.ToInt32(txtSE_MEDIA.Text.Trim()) : 0);
            objProjetoComplexidade.SE_ALTA = (txtSE_ALTA.Text.Trim() != "" ? Convert.ToInt32(txtSE_ALTA.Text.Trim()) : 0); 

            objProjetoComplexidade.Salvar();

            txtIdProjetoComplexidade.Text = objProjetoComplexidade.IdProjetoComplexidade.ToString().Trim();

            ShowMessage("Operação realizada com sucesso.", "ok");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    #region [  GvwLista_RowCommandFuncaoTransacao  ]
    /// <summary>
    /// [  GvwLista_RowCommandFuncaoTransacao  ]
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GvwLista_RowCommandFuncaoTransacao(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Alterar")
            {
                if (e.CommandArgument != null && e.CommandArgument.ToString().Trim() != "")
                {
                    Framework.PontoFuncao.ProjetoFuncaoTransacao objProjetoFuncaoTransacao = new Framework.PontoFuncao.ProjetoFuncaoTransacao();
                    objProjetoFuncaoTransacao.GetById(Convert.ToInt32(e.CommandArgument.ToString().Trim()));
                    if (objProjetoFuncaoTransacao != null && objProjetoFuncaoTransacao.IdProjetoFuncaoTransacao > 0)
                    {
                        txtIdProjetoFuncaoTransacao.Text = objProjetoFuncaoTransacao.IdProjetoFuncaoTransacao.ToString().Trim();
                        txtFtNome.Text = objProjetoFuncaoTransacao.Nome.ToString().Trim();
                        txtFtNumTd.Text = objProjetoFuncaoTransacao.NumTd.ToString().Trim();
                        txtfTNumAr.Text = objProjetoFuncaoTransacao.NumAr.ToString().Trim();
                        ddlFtIdTipo.SelectedValue = objProjetoFuncaoTransacao.IdTipo.ToString().Trim();
                    }
                }
            }
            else if (e.CommandName == "Excluir")
            {
                if (this.Id > 0)
                {
                    AcessoBD.ExecutarComandoSqlEscalar("DELETE PROJETOFUNCAOTRANSACAO WHERE IDPROJETOFUNCAOTRANSACAO = " + e.CommandArgument.ToString().Trim() + "");
                    FiltraPesquisa("ft");
                    ShowMessage("Exclusão realizada com sucesso.", "ok");
                }
            }

        }
        catch (Exception)
        {
        }
    }
    #endregion

    #region [  GvwLista_RowCommand  ]
    /// <summary>
    /// [  GvwLista_RowCommand  ]
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GvwLista_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Alterar")
            {
                if (e.CommandArgument != null && e.CommandArgument.ToString().Trim() != "")
                {
                    Framework.PontoFuncao.ProjetoFuncaoDados objProjetoFuncaoDados = new Framework.PontoFuncao.ProjetoFuncaoDados();
                    objProjetoFuncaoDados.GetById(Convert.ToInt32(e.CommandArgument.ToString().Trim()));
                    if (objProjetoFuncaoDados != null && objProjetoFuncaoDados.IdProjetoFuncaoDados > 0)
                    {
                        txtIdProjetoFuncaoDados.Text = objProjetoFuncaoDados.IdProjetoFuncaoDados.ToString().Trim();
                        ddlFdIdTipo.SelectedValue = objProjetoFuncaoDados.IdTipo.ToString().Trim();
                        txtFdNome.Text = objProjetoFuncaoDados.Nome.ToString().Trim();
                        txtFdNumTd.Text = objProjetoFuncaoDados.NumTd.ToString().Trim();
                        txtFdNumTr.Text = objProjetoFuncaoDados.NumTr.ToString().Trim();
                    }
                }
            }
            else if (e.CommandName == "Excluir")
            {
                if (this.Id > 0)
                {
                    AcessoBD.ExecutarComandoSqlEscalar("DELETE PROJETOFUNCAODADOS WHERE IDPROJETOFUNCAODADOS = "+ e.CommandArgument.ToString().Trim() +"");
                    FiltraPesquisa("fd");
                    ShowMessage("Exclusão realizada com sucesso.","ok");
                }
            }

        }
        catch (Exception)
        {
        }
    }
    #endregion


    #region [   GvwLista_SortingFuncaoTransacao    ]
    /// <summary>
    /// [   GvwLista_SortingFuncaoTransacao    ]
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GvwLista_SortingFuncaoTransacao(object sender, GridViewSortEventArgs e)
    {
        try
        {
            this.FiltraPesquisa("ft");
        }
        catch (Exception exception)
        {
            this.LblMensagem.ForeColor = Color.Red;
            this.LblMensagem.Text = exception.Message;
        }
    }
    #endregion

    #region [   GvwLista_Sorting    ]
    /// <summary>
    /// [   GvwLista_Sorting    ]
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GvwLista_Sorting(object sender, GridViewSortEventArgs e)
    {
        try
        {
            this.FiltraPesquisa("fd");
        }
        catch (Exception exception)
        {
            this.LblMensagem.ForeColor = Color.Red;
            this.LblMensagem.Text = exception.Message;
        }
    }
    #endregion

    #region [   Paginacao_GridFuncaoTransacao  ]
    /// <summary>
    /// [   Paginacao_GridFuncaoTransacao  ]
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Paginacao_GridFuncaoTransacao(object sender, GridViewPageEventArgs e)
    {
        try
        {
            this.gridFuncaoTransacao.PageIndex = e.NewPageIndex;
            this.FiltraPesquisa("ft");
            this.gridFuncaoTransacao.DataBind();
            this.LblCountFt.Text = string.Format("{0} registro(s) apresentado(s)", this.gridFuncaoTransacao.Rows.Count);
        }
        catch (Exception exception)
        {
            this.LblMensagem.ForeColor = Color.Red;
            this.LblMensagem.Text = exception.Message;
        }
    }
    #endregion

    #region [   Paginacao_Grid  ]
    /// <summary>
    /// [   Paginacao_Grid  ]
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Paginacao_Grid(object sender, GridViewPageEventArgs e)
    {
        try
        {
            this.GvwLista.PageIndex = e.NewPageIndex;
            this.FiltraPesquisa("fd");
            this.GvwLista.DataBind();
            this.LblCount.Text = string.Format("{0} registro(s) apresentado(s)", this.GvwLista.Rows.Count);
        }
        catch (Exception exception)
        {
            this.LblMensagem.ForeColor = Color.Red;
            this.LblMensagem.Text = exception.Message;
        }
    }
    #endregion

    #region [   FiltraPesquisa  ]
    /// <summary>
    /// [   FiltraPesquisa  ]
    /// </summary>
    protected void FiltraPesquisa(string strTipo)
    {
        try
        {
            if (strTipo.Trim() == "fd")
            {
                this.DsGridFuncaoDados.FilterExpression = "1 = 1";
                this.GvwLista.DataBind();
                this.LblCount.Text = string.Format("{0} registro(s) apresentado(s)", this.GvwLista.Rows.Count);
            }
            else if (strTipo.Trim() == "ft")
            {
                this.DsFuncaoTransacao.FilterExpression = "1 = 1";
                this.gridFuncaoTransacao.DataBind();
                this.LblCountFt.Text = string.Format("{0} registro(s) apresentado(s)", this.GvwLista.Rows.Count);
            }
        }
        catch (Exception exception)
        {
            throw new Exception(exception.Message);
        }
    }
    #endregion

    #region [   btnFuncaoDados_Click    ]
    /// <summary>
    /// [   btnFuncaoDados_Click    ]
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnFuncaoDados_Click(object sender, EventArgs e)
    {
        Framework.PontoFuncao.ProjetoFuncaoDados objProjetoFuncaoDados = new Framework.PontoFuncao.ProjetoFuncaoDados();
        try
        {
            if (this.Id <= 0)
            {
                ShowMessage("Salve o projeto antes.", "alertar");
                return;
            }

            if (txtFdNome.Text.Trim() == "")
            {
                ShowMessage("Informe o nome da função de dados.", "alertar");
                txtFdNome.Focus();
                return;
            }

            else if(txtIdProjetoFuncaoDados.Text.Trim() == "")
            {
                object obj = AcessoBD.ExecutarComandoSqlEscalar("SELECT NOME FROM PROJETOFUNCAODADOS WHERE IDPROJETO = "+ this.Id +" AND NOME = '"+ txtFdNome.Text.Trim() +"'");
                if (obj != null && obj.ToString().Trim() == txtFdNome.Text.Trim())
                {
                    ShowMessage("O nome da função de dados já existe para esse projeto.", "alertar");
                    txtFdNome.Focus();
                    return;
                }
            }

            if (ddlFdIdTipo.SelectedValue.Trim() == "")
            {
                ShowMessage("Informe o tipo da função de dados.", "alertar");
                ddlFdIdTipo.Focus();
                return;
            }
                
            if (txtFdNumTd.Text.Trim() == "")
            {
                ShowMessage("Informe o número TD da função de dados.", "alertar");
                txtFdNumTd.Focus();
                return;
            }

            if (txtFdNumTr.Text.Trim() == "")
            {
                ShowMessage("Informe o número TR da função de dados.", "alertar");
                txtFdNumTr.Focus();
                return;
            }

            objProjetoFuncaoDados.IdProjeto = this.Id;
            objProjetoFuncaoDados.IdProjetoFuncaoDados = (this.txtIdProjetoFuncaoDados.Text.Trim() == "" ? 0 : Convert.ToInt32(this.txtIdProjetoFuncaoDados.Text.Trim()));
            objProjetoFuncaoDados.Nome = txtFdNome.Text.Trim();
            objProjetoFuncaoDados.NumTd = Convert.ToInt32(txtFdNumTd.Text.Trim());
            objProjetoFuncaoDados.NumTr = Convert.ToInt32(txtFdNumTr.Text.Trim());
            objProjetoFuncaoDados.IdTipo = Convert.ToInt32(ddlFdIdTipo.SelectedValue.Trim());
            objProjetoFuncaoDados.Prioridade = GetPrioridadeFuncaoDados(objProjetoFuncaoDados.NumTd, objProjetoFuncaoDados.NumTr);
            objProjetoFuncaoDados.QtdPontoFuncao = GetQtdPontoFuncaoFuncaoDados(objProjetoFuncaoDados.Prioridade);

            objProjetoFuncaoDados.Salvar();

            if (objProjetoFuncaoDados.IdProjetoFuncaoDados > 0)
            {
                txtIdProjetoFuncaoDados.Text = objProjetoFuncaoDados.IdProjetoFuncaoDados.ToString().Trim();
                FiltraPesquisa("fd");
                LimparFuncaoDados();
                ShowMessage("Registro salvo com sucesso.","ok");
            }
        }
        catch
        { 
        
        }
        finally
        {
            objProjetoFuncaoDados = null;
        }
    }
    #endregion

    #region [   btnftFuncaoDados_Click    ]
    /// <summary>
    /// [   btnftFuncaoDados_Click    ]
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnFuncaoTransacao_Click(object sender, EventArgs e)
    {
        Framework.PontoFuncao.ProjetoFuncaoTransacao objProjetoFuncaoTransacao = new Framework.PontoFuncao.ProjetoFuncaoTransacao();
        try
        {
            if (this.Id <= 0)
            {
                ShowMessage("Salve o projeto antes.", "alertar");
                return;
            }

            if (txtFtNome.Text.Trim() == "")
            {
                ShowMessage("Informe o nome da função de transação.", "alertar");
                txtFtNome.Focus();
                return;
            }
            else if (txtIdProjetoFuncaoTransacao.Text.Trim() == "")
            {
                object obj = AcessoBD.ExecutarComandoSqlEscalar("SELECT NOME FROM PROJETOFUNCAOTRANSACAO WHERE IDPROJETO = " + this.Id + " AND NOME = '" + txtFtNome.Text.Trim() + "'");
                if (obj != null && obj.ToString().Trim() == txtFtNome.Text.Trim())
                {
                    ShowMessage("O nome da função de transação já existe para esse projeto.", "alertar");
                    txtFtNome.Focus();
                    return;
                }
            }



            if (ddlFtIdTipo.SelectedValue.Trim() == "")
            {
                ShowMessage("Informe o tipo.", "alertar");
                ddlFtIdTipo.Focus();
                return;
            }

            if (txtfTNumAr.Text.Trim() == "")
            {
                ShowMessage("Informe o número da AR´s da função de transação.", "alertar");
                txtfTNumAr.Focus();
                return;
            }

            if (txtFtNumTd.Text.Trim() == "")
            {
                ShowMessage("Informe o número da TD da função de transação.", "alertar");
                txtFtNumTd.Focus();
                return;
            }

            objProjetoFuncaoTransacao.IdProjeto = this.Id;
            objProjetoFuncaoTransacao.IdProjetoFuncaoTransacao = (this.txtIdProjetoFuncaoTransacao.Text.Trim() == "" ? 0 : Convert.ToInt32(this.txtIdProjetoFuncaoTransacao.Text.Trim()));
            objProjetoFuncaoTransacao.Nome = txtFtNome.Text.Trim();
            objProjetoFuncaoTransacao.NumTd = Convert.ToInt32(txtFtNumTd.Text.Trim());
            objProjetoFuncaoTransacao.NumAr = Convert.ToInt32(txtfTNumAr.Text.Trim());
            objProjetoFuncaoTransacao.IdTipo = Convert.ToInt32(ddlFtIdTipo.SelectedValue.Trim());
            objProjetoFuncaoTransacao.Prioridade = GetPrioridadeFuncaoTransacao(Convert.ToInt32(ddlFtIdTipo.SelectedValue.Trim()), objProjetoFuncaoTransacao.NumAr, objProjetoFuncaoTransacao.NumTd);
            objProjetoFuncaoTransacao.QtdPontoFuncao = GetQtdPontoFuncaoTransacao(objProjetoFuncaoTransacao.Prioridade, objProjetoFuncaoTransacao.IdTipo);

            objProjetoFuncaoTransacao.Salvar();

            if (objProjetoFuncaoTransacao.IdProjetoFuncaoTransacao > 0)
            {
                txtIdProjetoFuncaoTransacao.Text = objProjetoFuncaoTransacao.IdProjetoFuncaoTransacao.ToString().Trim();
                FiltraPesquisa("ft");
                LimparFuncaoTransacao();
                ShowMessage("Registro salvo com sucesso.", "ok");
            }
        }
        catch
        { 
        
        }
        finally
        {
            objProjetoFuncaoTransacao = null;
        }
    }
    #endregion

    #region [   GetQtdPontoFuncaoTransacao    ]
    /// <summary>
    /// [   GetQtdPontoFuncaoTransacao    ]
    /// </summary>
    /// <param name="intIdProjetoFuncaoDados"></param>
    /// <returns></returns>
    private int GetQtdPontoFuncaoTransacao(int intIdPrioridade, int intIdTipo)
    {
        try
        {
            //6	EE
            //7	CE
            //8	SE

            //3	Alta
            //4	Média
            //5	Baixa
            if (intIdTipo <= 0 || intIdPrioridade <= 0) return 0;

            if (intIdTipo == 6) //	EE
            {
                if (intIdPrioridade == 3) return 6;//3	Alta
                if (intIdPrioridade == 4) return 4;//4	Média
                if (intIdPrioridade == 5) return 3; //5	Baixa
            }
            else if (intIdTipo == 7 ) //CE
            {
                if (intIdPrioridade == 3) return 6  ;//3	Alta
                if (intIdPrioridade == 4) return 4;//4	Média
                if (intIdPrioridade == 5) return 3; //5	Baixa
            }
            else if (intIdTipo == 8) //SE
            {
                if (intIdPrioridade == 3) return 7;//3	Alta
                if (intIdPrioridade == 4) return 5;//4	Média
                if (intIdPrioridade == 5) return 4; //5	Baixa
            }

            return 0;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    #endregion


    #region [   GetQtdPontoFuncaoFuncaoDados    ]
    /// <summary>
    /// [   GetQtdPontoFuncaoFuncaoDados    ]
    /// </summary>
    /// <param name="intIdProjetoFuncaoDados"></param>
    /// <returns></returns>
    private int GetQtdPontoFuncaoFuncaoDados(int intIdProjetoFuncaoDados)
    {
        try
        {
            //1	AIE
            //2	ALI

            //3	Alta
            //4	Média
            //5	Baixa
            if (intIdProjetoFuncaoDados <= 0) return 0;

            if (ddlFdIdTipo.SelectedValue.Trim() == "1") //	AIE
            {
                if (intIdProjetoFuncaoDados == 5)////5	Baixa
                    return 5;
                else if (intIdProjetoFuncaoDados == 4)//4	Média
                    return 7;
                else if (intIdProjetoFuncaoDados == 3)//3	Alta
                    return 10;
            }
            else if (ddlFdIdTipo.SelectedValue.Trim() == "2") //ALI
            {
                if (intIdProjetoFuncaoDados == 5)////5	Baixa
                    return 7;
                else if (intIdProjetoFuncaoDados == 4)//4	Média
                    return 10;
                else if (intIdProjetoFuncaoDados == 3)//3	Alta
                    return 15;
            }

            return 0;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    #endregion

    #region [   GetPrioridadeFuncaoTransacao    ]
    /// <summary>
    /// [   GetPrioridadeFuncaoTransacao    ]
    /// </summary>
    /// <param name="NumTd"></param>
    /// <param name="NumTr"></param>
    /// <returns></returns>
    private int GetPrioridadeFuncaoTransacao(int intIdTipo, int intNumAr, int intNumTd)
    {
        try
        {
            //3	Alta
            //4	Média
            //5	Baixa
            if (intIdTipo <= 0) return 0;

            if (intIdTipo == 7 || intIdTipo == 8)// 7	CE | // 8	SE
            {
                if (intNumAr <= 1)
                { 
                    if(intNumTd < 6)return 5;
                    if(intNumTd >= 6 && intNumTd <= 19) return 5;
                    if(intNumTd > 20) return 4;
                }
                else if (intNumAr >= 2 && intNumAr <= 3)
                { 
                    if(intNumTd < 6)return 5;
                    if(intNumTd >= 6 && intNumTd <= 19) return 4;
                    if(intNumTd > 20) return 3;
                }
                if (intNumAr > 3)
                {
                    if (intNumTd < 6) return 4;
                    if (intNumTd >= 6 && intNumTd <= 19) return 3;
                    if (intNumTd > 20) return 3;
                }
            }
            //3	Alta
            //4	Média
            //5	Baixa
            else if (intIdTipo == 6)//6	EE
            {
                if (intNumAr <= 1)
                {
                    if (intNumTd < 5) return 5;
                    if (intNumTd >= 5 && intNumTd <= 15) return 5;
                    if (intNumTd > 15) return 4;
                }
                else if (intNumAr == 2)
                {
                    if (intNumTd < 6) return 5;
                    if (intNumTd >= 6 && intNumTd <= 19) return 4;
                    if (intNumTd > 20) return 3;
                }
                if (intNumAr > 2)
                {
                    if (intNumTd < 6) return 4;
                    if (intNumTd >= 6 && intNumTd <= 19) return 3;
                    if (intNumTd > 20) return 3;
                }
            }

            return 0;
        }
        catch
        {
            return 0;
        }
    }
    #endregion

    
    #region [   GetPrioridadeFuncaoDados    ]
    /// <summary>
    /// [   GetPrioridadeFuncaoDados    ]
    /// </summary>
    /// <param name="NumTd"></param>
    /// <param name="NumTr"></param>
    /// <returns></returns>
     private int GetPrioridadeFuncaoDados(int NumTd,int NumTr)
     {
        try 
	    {
            //3	Alta
            //4	Média
            //5	Baixa
            if (NumTr <= 1)
            {
                if ((NumTd < 20) || (NumTd >= 20 && NumTd <= 50))
                    return 5;
                else if (NumTd > 50)
                    return 4;
            }
            else if (NumTr >= 2 && NumTr <= 5)
            {
                if (NumTd < 20)
                    return 5;
                else if (NumTd >= 20 && NumTd <= 50)
                    return 4;
                else if (NumTd > 50)
                    return 3;
            }
            else if (NumTr > 5)
            {
                if (NumTd < 20)
                    return 4;
                else if (NumTd >= 20 && NumTd <= 50)
                    return 3;
                else if (NumTd > 50)
                    return 3;
            }

            return 0;
	    }
	    catch 
	    {
            return 0;
	    }
     }
    #endregion

     #region [   btnFuncaoDadosNovo_Click    ]
     /// <summary>
    /// [   btnFuncaoDadosNovo_Click    ]
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnFuncaoDadosNovo_Click(object sender, EventArgs e)
    {
        LimparFuncaoDados();
    }

    private void LimparFuncaoDados()
    {
        txtIdProjetoFuncaoDados.Text = "";
        txtFdNome.Text = "";
        txtFdNumTd.Text = "";
        txtFdNumTr.Text = "";
        ddlFdIdTipo.SelectedValue = "";
    }
     #endregion

    #region [   btnftFuncaoDadosNovo_Click    ]
    /// <summary>
    /// [   btnftFuncaoDadosNovo_Click    ]
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnftFuncaoDadosNovo_Click(object sender, EventArgs e)
    {
        LimparFuncaoTransacao();
    }

    private void LimparFuncaoTransacao()
    {
        txtIdProjetoFuncaoTransacao.Text = "";
        txtFtNome.Text = "";
        txtfTNumAr.Text = "";
        txtFtNumTd.Text = "";
        ddlFtIdTipo.SelectedValue = "";
    }
    #endregion


    protected void btnAtualizar_Click(object sender, EventArgs e)
    {
        try
        {
            gridFuncaoTransacao.DataBind();
            GvwLista.DataBind();
        
        }
        catch
        { }
    }
    protected void btnAtualizadFuncaoDados_Click(object sender, EventArgs e)
    {
        try
        {
            gridFuncaoTransacao.DataBind();
            GvwLista.DataBind();

        }
        catch
        { }
    }
    protected void WebTab1_SelectedIndexChanged(object sender, Infragistics.Web.UI.LayoutControls.TabSelectedIndexChangedEventArgs e)
    {
        try
        {
            gridFuncaoTransacao.DataBind();
            GvwLista.DataBind();

        }
        catch
        { }

    }
}
