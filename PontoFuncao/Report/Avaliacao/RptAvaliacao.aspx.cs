using System;
using Framework.Sige;
using Framework.Reflection.AcessoBancoDados;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Framework.Reflection.ControlesWeb;

public partial class Report_Avaliacao_RptAvaliacao : System.Web.UI.Page
{
   
  
    // Methods
    protected void btnNaTela_Click(object sender, EventArgs e)
    {
        DataSet set = new DataSet();
        try
        {
            if (this.ValidaFiltro())
            {
                Button button = (Button)sender;
                set = AcessoBD.ObterDataSet(this.GetSql());
                this.Session["dsPopulado"] = set;
                if (button.ID == "btnNaTela")
                {
                    this.Session["ModoSaida"] = "2";
                }
                else if (button.ID == "btnPdf")
                {
                    this.Session["ModoSaida"] = "3";
                }
                else if (button.ID == "btnExcel")
                {
                    this.Session["ModoSaida"] = "1";
                }
                string str2 = HttpContext.Current.Request.Url.ToString();
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "popup", "window.open('" + (str2.Substring(0, str2.Trim().IndexOf("RptAvaliacao.aspx")) + "PrwAvaliacao.aspx") + "','_blank')", true);
            }
        }
        catch (Exception exception)
        {
            ClsSigeBugs.InsertBug(exception.GetHashCode().ToString().Trim(), "Descrição: " + exception.Message.ToString().Trim() + " | Local do erro: " + exception.StackTrace, "1", exception.TargetSite.ReflectedType.Name, exception.TargetSite.Name.ToString().Trim(), Framework.Util.ClsUtil.GetVarGlobalStatic("IdUsuario"), DateTime.Now.ToString().Trim());
        }
        finally
        {
            if (set != null)
            {
                set.Dispose();
            }
        }
    }

    private string GetSql()
    {
        string str2;
        try
        {
            string str = "select Avalia.IdAvalia, Avalia.IdFilial\r\n            , (CONVERT(varchar,DataCadastro,103)) as DataCadastro\r\n            , Placa\r\n            , Modelo\r\n            , AnoModelo\r\n            , Km\r\n            , PrecoTotalOrcamento as Orcamente\r\n            , AvalEfetivo as Valor\r\n            , Indexador.DescIndexador as DescIndexador\r\n            , Filial.RazaoSocial as Filial\r\n            , Pessoa.Nome as Vendedor\r\n            , Status.DescStatus as Status\r\n            , avaliaindexador.Valor as IndexadorValor\r\n            , Avalia.IdStatusAvaliacao\r\n            , StatusNaoEntrou.DescStatus as StatusNaoEntrou\r\n            , Avalia.IdStatusMotivoNaoEntrou\r\n            , (select COUNT(*) from Avalia as Avalia2  where Avalia2.IdStatusAvaliacao = 4 and IdFilial = Avalia.IdFilial) as QtdEntrou\r\n            ,(select COUNT(*) from Avalia as Avalia2  where Avalia2.IdStatusAvaliacao = 5 and IdFilial = Avalia.IdFilial) as QtdNaoEntrou\r\n            ,(select COUNT(*) from Avalia as Avalia2  where Avalia2.IdStatusAvaliacao = 6 and IdFilial = Avalia.IdFilial) as QtdEmAndamento\r\n            ,(select COUNT(*) from Avalia as Avalia2  where Avalia2.IdStatusAvaliacao = 7 and IdFilial = Avalia.IdFilial) as QtdAguarRetorno\r\n            ,(select COUNT(*) from Avalia as Avalia2  where Avalia2.IdStatusAvaliacao IS NULL and IdFilial = Avalia.IdFilial) as QtdSemStatus\r\n            ,(select COUNT(*) from Avalia as Avalia2  where Avalia2.IdStatusAvaliacao = 5 and Avalia2.IdStatusMotivoNaoEntrou is null and  IdFilial = Avalia.IdFilial) as QtdNE_Indefinido\r\n            ,(select COUNT(*) from Avalia as Avalia2  where Avalia2.IdStatusAvaliacao = 5 and Avalia2.IdStatusMotivoNaoEntrou = 8 and IdFilial = Avalia.IdFilial) as QtdNE_PrecoBaixo\r\n            ,(select COUNT(*) from Avalia as Avalia2  where Avalia2.IdStatusAvaliacao = 5 and Avalia2.IdStatusMotivoNaoEntrou = 9 and IdFilial = Avalia.IdFilial) as QtdNE_DesistiuNegocio\r\n            ,(select COUNT(*) from Avalia as Avalia2  where Avalia2.IdStatusAvaliacao = 5 and Avalia2.IdStatusMotivoNaoEntrou = 10 and IdFilial = Avalia.IdFilial) as QtdNE_ValorQuitacaoAlto\r\n            ,(select COUNT(*) from Avalia as Avalia2  where Avalia2.IdStatusAvaliacao = 5 and Avalia2.IdStatusMotivoNaoEntrou = 11 and IdFilial = Avalia.IdFilial) as QtdNE_NaoTeveOfertaPreco\r\n            ,(select COUNT(*) from Avalia as Avalia2  where Avalia2.IdStatusAvaliacao = 5 and Avalia2.IdStatusMotivoNaoEntrou = 12 and IdFilial = Avalia.IdFilial) as QtdNE_NaoAprovouaCadastro\r\n            ,(select COUNT(*) from Avalia as Avalia2  where Avalia2.IdStatusAvaliacao = 5 and Avalia2.IdStatusMotivoNaoEntrou = 13 and IdFilial = Avalia.IdFilial) as QtdNE_RepassouPorContaPropria\r\n            ,(select COUNT(*) from Avalia as Avalia2  where Avalia2.IdStatusAvaliacao = 5 and Avalia2.IdStatusMotivoNaoEntrou = 14 and IdFilial = Avalia.IdFilial) as QtdNE_ExpectativaForaDoMercado\r\n            ,(select COUNT(*) from Avalia as Avalia2  where Avalia2.IdStatusAvaliacao = 5 and Avalia2.IdStatusMotivoNaoEntrou = 15 and IdFilial = Avalia.IdFilial) as QtdNE_VeiculoIrregular\r\n            ,(select COUNT(*) from Avalia as Avalia2  where Avalia2.IdStatusAvaliacao = 5 and Avalia2.IdStatusMotivoNaoEntrou = 16 and IdFilial = Avalia.IdFilial) as QtdNE_DesistiuPorMotivosFamiliares\r\n            ,(select COUNT(*) from Avalia as Avalia2  where Avalia2.IdStatusAvaliacao = 5 and Avalia2.IdStatusMotivoNaoEntrou = 17 and IdFilial = Avalia.IdFilial) as QtdNE_AdiouACompra\r\n            ,(select COUNT(*) from Avalia as Avalia2  where Avalia2.IdStatusAvaliacao = 5 and Avalia2.IdStatusMotivoNaoEntrou = 18 and IdFilial = Avalia.IdFilial) as QtdNE_ComprouOutraMarca\r\n            ,(select COUNT(*) from Avalia as Avalia2  where Avalia2.IdStatusAvaliacao = 5 and Avalia2.IdStatusMotivoNaoEntrou = 19 and IdFilial = Avalia.IdFilial) as QtdNE_ComprouOutraRevenda\r\n            ,(select COUNT(*) from Avalia as Avalia2  where Avalia2.IdStatusAvaliacao = 5 and Avalia2.IdStatusMotivoNaoEntrou = 20 and IdFilial = Avalia.IdFilial) as QtdNE_ContatoImpossivel\r\n            ,(select COUNT(*) from Avalia as Avalia2  where Avalia2.IdStatusAvaliacao = 5 and Avalia2.IdStatusMotivoNaoEntrou = 21 and IdFilial = Avalia.IdFilial) as QtdNE_FaltaCapacidadeFinanceira\r\n            ,(select COUNT(*) from Avalia as Avalia2  where Avalia2.IdStatusAvaliacao = 5 and Avalia2.IdStatusMotivoNaoEntrou = 22 and IdFilial = Avalia.IdFilial) as QtdNE_AguardandoEntradaModeloDesejado\r\n            from Avalia\r\n            Left Join AvaliaIndexador on AvaliaIndexador.idavalia = Avalia.idavalia and AvaliaIndexador.flagselecionado = 's'\r\n            Left Join Indexador on Indexador.IdIndexador = AvaliaIndexador.IdIndexador\r\n            Left Join Filial on Filial.IdFilial = Avalia.IdFilial \r\n            Left Join Pessoa on Pessoa.IdPessoa =  Avalia.IdPessoaVendedor\r\n            Left Join Status on Status.IdStatus = Avalia.IdStatusAvaliacao\r\n            Left Join Status as StatusNaoEntrou on StatusNaoEntrou.IdStatus = Avalia.IdStatusMotivoNaoEntrou\r\n            where  Filial.IdEmpresa = " + Framework.Util.ClsUtil.GetVarGlobalStatic("IdEmpresa") + " ";
            if ((this.ddlLoja.SelectedValue.Trim() != "") && (this.ddlLoja.SelectedValue.Trim() != "0"))
            {
                str = str + " and Avalia.idfilial = " + this.ddlLoja.SelectedValue.Trim() + " ";
            }
            if (this.txtPerdiodoDe.Text.Trim() != "")
            {
                str = str + "  AND DataCadastro >= '" + Convert.ToDateTime(this.txtPerdiodoDe.Text + " 00:00:00").ToString() + "'";
            }
            if (this.txtPeriodoAte.Text.Trim() != "")
            {
                str = str + " AND DataCadastro <= '" + Convert.ToDateTime(this.txtPeriodoAte.Text + " 23:59:59").ToString() + "'";
            }
            if (this.ddlKm.SelectedValue.Trim() != "")
            {
                if (this.ddlKm.SelectedValue.Trim() == "1")
                {
                    str = str + " AND Km <= 100.000 ";
                }
                else if (this.ddlKm.SelectedValue.Trim() == "2")
                {
                    str = str + " AND Km > 100.001 ";
                }
            }
            if (this.ddlAno.SelectedValue.Trim() != "")
            {
                int year = DateTime.Now.Year;
                int num2 = 0;
                if (this.ddlAno.SelectedValue.Trim() == "1")
                {
                    num2 = year - 3;
                    object obj2 = str;
                    str = string.Concat(new object[] { obj2, " and Ano >= ", num2, " " });
                }
                if (this.ddlAno.SelectedValue.Trim() == "2")
                {
                    num2 = year - 6;
                    object obj3 = str;
                    str = string.Concat(new object[] { obj3, " and (Ano >= ", num2, " or Ano <= ", num2, " ) " });
                }
                if (this.ddlAno.SelectedValue.Trim() == "3")
                {
                    num2 = year - 9;
                    object obj4 = str;
                    str = string.Concat(new object[] { obj4, " and (Ano >= ", num2, " or Ano <= ", num2, " ) " });
                }
                if (this.ddlAno.SelectedValue.Trim() == "4")
                {
                    num2 = year - 10;
                    object obj5 = str;
                    str = string.Concat(new object[] { obj5, " and Ano >= ", num2, " " });
                }
            }
            if (this.ddlValor.SelectedValue.Trim() == "")
            {
                if (this.ddlValor.SelectedValue.Trim() == "1")
                {
                    str = str + " and AvalEfetivo <= 10.000 ";
                }
                if (this.ddlValor.SelectedValue.Trim() == "2")
                {
                    str = str + " and (AvalEfetivo >= 10.001 and AvalEfetivo <= 20.000) ";
                }
                if (this.ddlValor.SelectedValue.Trim() == "3")
                {
                    str = str + " and (AvalEfetivo >= 20.001 and AvalEfetivo <= 35.000) ";
                }
                if (this.ddlValor.SelectedValue.Trim() == "4")
                {
                    str = str + " and (AvalEfetivo >= 35.001 and AvalEfetivo <= 50.000) ";
                }
                if (this.ddlValor.SelectedValue.Trim() == "5")
                {
                    str = str + " and AvalEfetivo >= 50.001 ";
                }
            }
            if (this.ddlFinalidade.SelectedValue.Trim() != "")
            {
                str = str + " and DescFinalidade  = " + this.ddlFinalidade.SelectedValue.Trim() + " ";
            }
            if ((this.ddlStatus.SelectedValue.Trim() != "") && (this.ddlStatus.SelectedValue.Trim() != "0"))
            {
                str = str + " and IdStatusAvaliacao  = " + this.ddlStatus.SelectedValue.Trim() + " ";
            }
            if ((this.ddlVendedor.SelectedValue.Trim() != "") && (this.ddlVendedor.SelectedValue.Trim() != "0"))
            {
                str = str + " and IdPessoaVendedor  = " + this.ddlVendedor.SelectedValue.Trim() + " ";
            }
            str2 = str;
        }
        catch (Exception exception)
        {
            throw exception;
        }
        return str2;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(Framework.Util.ClsUtil.GetVarGlobalStatic("IdUsuario"))) Response.Redirect("~/Login.aspx");
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
        catch (Exception exception)
        {
            ClsSigeBugs.InsertBug(exception.GetHashCode().ToString().Trim(), "Descrição: " + exception.Message.ToString().Trim() + " | Local do erro: " + exception.StackTrace, "1", exception.TargetSite.ReflectedType.Name, exception.TargetSite.Name.ToString().Trim(), Framework.Util.ClsUtil.GetVarGlobalStatic("IdUsuario"), DateTime.Now.ToString().Trim());
        }
    }

    private bool ValidaFiltro()
    {
        bool flag;
        try
        {
            if ((((((this.txtPerdiodoDe.Text.Trim() == "") && (this.txtPeriodoAte.Text.Trim() == "")) && ((this.ddlKm.SelectedValue.Trim() == "") && (this.ddlAno.SelectedValue.Trim() == ""))) && ((this.ddlValor.SelectedValue.Trim() == "") && ((this.ddlLoja.SelectedValue.Trim() == "") || (this.ddlLoja.SelectedValue.Trim() == "0")))) && ((this.ddlFinalidade.SelectedValue.Trim() == "") && ((this.ddlStatus.SelectedValue.Trim() == "") || (this.ddlStatus.SelectedValue.Trim() == "0")))) && ((this.ddlVendedor.SelectedValue.Trim() == "") || (this.ddlVendedor.SelectedValue.Trim() == "0")))
            {
                this.ShowMessage("Defina no mínimo um filtro para pesquisa.", "alertar");
                return false;
            }
            if (((this.txtPerdiodoDe.Text.Trim() == "") && (this.txtPeriodoAte.Text.Trim() != "")) || ((this.txtPerdiodoDe.Text.Trim() != "") && (this.txtPeriodoAte.Text.Trim() == "")))
            {
                this.ShowMessage("Para pesquisar por período preencha os dois campos data.", "alertar");
                return false;
            }
            if ((this.txtPeriodoAte.Text.Trim() != "") && (this.txtPerdiodoDe.Text.Trim() != ""))
            {
                try
                {
                    Convert.ToDateTime(this.txtPerdiodoDe.Text.Trim());
                }
                catch
                {
                    this.ShowMessage("Data inválida no campo período de.", "alertar");
                    return false;
                }
                try
                {
                    Convert.ToDateTime(this.txtPeriodoAte.Text.Trim());
                }
                catch
                {
                    this.ShowMessage("Data inválida no campo data final.", "alertar");
                    return false;
                }
                if (Convert.ToDateTime(this.txtPeriodoAte.Text.Trim()) < Convert.ToDateTime(this.txtPerdiodoDe.Text.Trim()))
                {
                    this.ShowMessage("A data final não pode ser menor que a inicial.", "alertar");
                    return false;
                }
            }
            flag = true;
        }
        catch (Exception exception)
        {
            throw exception;
        }
        return flag;
    }




}