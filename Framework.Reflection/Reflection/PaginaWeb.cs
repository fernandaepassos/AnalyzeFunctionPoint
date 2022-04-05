using System;
using System.Data;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
using Framework.Reflection.Generic;
using System.Reflection;
using System.IO;
using System.Web;
using System.Globalization;
using Framework.Reflection.Tool;
using Framework.Reflection.AcessoBancoDados;

namespace Framework.Reflection.PaginaWeb
{
    public class PaginaWeb
    {
        // Methods
        public static void AtribuirDropDownList(DropDownList objDropDownList, string valor)
        {
            if ((objDropDownList != null) && (objDropDownList.Items.Count > 0))
            {
                if (objDropDownList.Items.FindByValue(valor) != null)
                {
                    objDropDownList.SelectedValue = valor;
                }
                else
                {
                    objDropDownList.SelectedIndex = 0;
                }
            }
        }

        public static void AtribuirIdObjetoPage(Page objetoPage)
        {
            PropertyInfo propertyInfoChamadaID = GetPropertyInfoChamadaID(objetoPage);
            int valorIDPaginaWeb = 0;
            if ((propertyInfoChamadaID == null) || !propertyInfoChamadaID.CanWrite)
            {
                throw new Exception("Implemente uma Property ID na pagina em questão com get e set");
            }
            valorIDPaginaWeb = GetValorIDPaginaWeb(objetoPage);
            propertyInfoChamadaID.SetValue(objetoPage, valorIDPaginaWeb, null);
        }

        public static Control BuscaWebControl(ControlCollection objColecaoControlesPagina, string nomeWebControl)
        {
            Control control = null;
            foreach (Control control2 in objColecaoControlesPagina)
            {
                if (((control2.ID != null) && (control2.ID != "")) && (control2.ID == nomeWebControl))
                {
                    return control2;
                }
                if (control2.HasControls())
                {
                    control = BuscaWebControl(control2.Controls, nomeWebControl);
                    if (control != null)
                    {
                        return control;
                    }
                }
            }
            return control;
        }

        private static void carregarDropDownList(DropDownList controleDropDownList, string tabela, string idControle, string dataTextField, string dataValueField)
        {
            if (GetIDControl(controleDropDownList).Contains(idControle))
            {
                DataSet dsDados = ListaTabela(tabela);
                preencherDropDownList(controleDropDownList, dsDados, dataTextField, dataValueField);
                dsDados.Dispose();
            }
        }

        private static void CategoriaVeiculo(Control componente)
        {
        }

        private static void CST_ICMS(Control componente)
        {
        }

        public static void FormatarGridView(ControlCollection objControlCollection)
        {
            foreach (Control control in objControlCollection)
            {
                if (!control.HasControls())
                {
                    if (control is GridView)
                    {
                        GridView view = (GridView)control;
                        view.PreRender += new EventHandler(PaginaWeb.objGridView_PreRender);
                    }
                }
                else
                {
                    FormatarGridView(control.Controls);
                }
            }
        }

        private static string GetIDControl(Control componente)
        {
            string iD;
            if (componente.ID == "")
            {
                iD = "";
            }
            else
            {
                iD = componente.ID;
            }
            return (string.IsNullOrEmpty(iD) ? "" : iD);
        }

        public static int GetIdUsuarioCorrente(Page objPage)
        {
            if (objPage.Session["IdUsuario"] == null)
            {
                throw new Exception("Você ficou muito tempo sem utilizar o sistema. Por favor, faça o login novamente.");
            }
            int num = new Tools().ConvertToInt32(objPage.Session["IdUsuario"]);
            if (num == 0)
            {
                throw new Exception("Você ficou muito tempo sem utilizar o sistema. Por favor, faça o login novamente.");
            }
            return num;
        }

        public static string GetNomeClasseIdControlePagina(string idControlePagina)
        {
            string str = "";
            if (idControlePagina.Length >= 2)
            {
                if (!idControlePagina.Contains("_"))
                {
                    return str;
                }
                for (int i = idControlePagina.Length - 1; i >= 0; i--)
                {
                    if (idControlePagina[i] == '_')
                    {
                        return str;
                    }
                    str = idControlePagina[i] + str;
                }
            }
            return str;
        }

        public static string GetNomePropriedadeIdControlePagina(string IdControlePaginaNomeClasseRemovido)
        {
            if (!IdControlePaginaNomeClasseRemovido.Contains("_"))
            {
                return IdControlePaginaNomeClasseRemovido;
            }
            string str = "";
            for (int i = IdControlePaginaNomeClasseRemovido.Length - 1; i >= 0; i--)
            {
                if (IdControlePaginaNomeClasseRemovido[i] == '_')
                {
                    return str;
                }
                str = IdControlePaginaNomeClasseRemovido[i] + str;
            }
            return str;
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

        public static void HabilitaDesabilitaPagina(ControlCollection objControlCollection, bool paginaHabilitada)
        {
            foreach (Control control in objControlCollection)
            {
                if (control is WebControl)
                {
                }
                if (((((control is DropDownList) || (control is TextBox)) || ((control is ListBox) || (control is Button))) || ((control is CheckBox) || (control is RadioButton))) || (control is LinkButton))
                {
                    ((WebControl)control).Enabled = paginaHabilitada;
                }
                if (control.HasControls())
                {
                    HabilitaDesabilitaPagina(control.Controls, paginaHabilitada);
                }
            }
        }

        private static void ImpostoIncluso(Control componente)
        {
        }

        private static void Integrador(Control componente)
        {
        }

        private static DataSet ListaTabela(string nomeTabela)
        {
            return AcessoBD.ObterDataSet("SELECT * FROM " + nomeTabela);
        }

        private static void Lotacao(Control componente)
        {
        }

        private static void MeioPagto(Control componente)
        {
        }

        public static void Mensagem(Page objPage, string Mensagem, TipoMensagem objTipoMensagem)
        {
            Label objLblMensagem = (Label)BuscaWebControl(objPage.Controls, "LblMensagem");
            System.Web.UI.WebControls.Image objImage = (System.Web.UI.WebControls.Image)BuscaWebControl(objPage.Controls, "imgMsg");
             
            if ((objLblMensagem != null) && (objLblMensagem is Label))
            {
                switch (objTipoMensagem)
                {
                    case TipoMensagem.Information:
                        if (objImage != null)
                        {
                            ((System.Web.UI.WebControls.Image)objImage).ImageUrl = "~/images/ok_128.png";
                        }
                        break;

                    case TipoMensagem.Error:
                        if (objImage != null)
                        {
                            ((System.Web.UI.WebControls.Image)objImage).ImageUrl = "~/images/error.png";
                        }
                        break;

                    case TipoMensagem.Warning:
                        if (objImage != null)
                        {
                            ((System.Web.UI.WebControls.Image)objImage).ImageUrl = "~/images/alerta_128.png";
                        }
                        break;
                }
                ((Label)objLblMensagem).Text = Mensagem;
                ((Label)objLblMensagem).Visible = true;
                ((System.Web.UI.WebControls.Image)objImage).Visible = true;
            }
        }

        private static void objGridView_PreRender(object sender, EventArgs e)
        {
            foreach (GridViewRow row in ((GridView)sender).Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    selecionarCheck(row.Controls, row);
                }
            }
        }

        private static void PagtoPara(Control componente)
        {
        }

        public static void preencherCamposAuditoria(ClassGeneric objetoInstancia, Page objPage)
        {
            objetoInstancia.IdUltimoUsuario = GetIdUsuarioCorrente(objPage);
            objetoInstancia.UltimaAtualizacao = DateTime.Now.ToString();
            objetoInstancia.NomeTela = objPage.Title;
        }

        public static void PreencherControleDropDown(DropDownList objDropDownList)
        {
            carregarDropDownList(objDropDownList, "Departamento", "DdlIdDepartamento_Pessoa", "DescDepartamento", "IdDepartamento");
            carregarDropDownList(objDropDownList, "Funcao", "DdlIdFuncao_Pessoa", "DescFuncao", "IdFuncao");
            carregarDropDownList(objDropDownList, "Estado", "DdlIdEstado_Pessoa", "Nome", "IdEstado");
            carregarDropDownList(objDropDownList, "sigesistema order by NomeSistema", "DdlIdSistema_ClsSdskChamado", "NomeSistema", "IdSistema");
            carregarDropDownList(objDropDownList, "SigeTipo where IdTipo in (select idtipo from SigeTipoTabela where NomeTabela = 'SdskChamado')", "DdlIdTipo_ClsSdskChamado", "NomeTipo", "IdTipo");
            carregarDropDownList(objDropDownList, "SigeStatus where IdStatus in (select IdStatus from SigeStatusTabela where NomeTabela = 'SdskChamado') order by ordem", "ddlIdStatus_ClsSdskChamado", "NomeStatus", "idstatus");
            carregarDropDownList(objDropDownList, "SdskOrigem ", "DdlIdOrigem_ClsSdskChamado", "Nome", "IdOrigem");
            carregarDropDownList(objDropDownList, "SdskImpacto", "DdlIdImpacto_ClsSdskChamado", "Descricao", "IdImpacto");
            carregarDropDownList(objDropDownList, "SdskUrgencia", "DdlIdUrgencia_ClsSdskChamado", "Descricao", "IdUrgencia");
            carregarDropDownList(objDropDownList, "SdskPrioridade", "IdPrioridade_ClsSdskChamado", "Descricao", "IdPrioridade");
            carregarDropDownList(objDropDownList, "SigePessoa where IdEmpresa in (select IdEmpresa from SigeEmpresa where IdEmpresaContratante = 1) order by IdEmpresa desc", "DdlIdPessoaSolicitante_ClsSdskChamado", "NomePessoa", "IdPessoa");
            SituacaoPedidoCarga(objDropDownList);
            SituacaoProgramacao(objDropDownList);
            SituacaoContainer(objDropDownList);
            TipoDocPedidoCliente(objDropDownList);
            UnidadesMedida(objDropDownList);
            TipoConciliacao(objDropDownList);
            CST_ICMS(objDropDownList);
            TipoEmissaoSEFAZ(objDropDownList);
            Lotacao(objDropDownList);
            ImpostoIncluso(objDropDownList);
            TipoComponenteFrete(objDropDownList);
            UF(objDropDownList);
            TipoTributo(objDropDownList);
            TipoConta(objDropDownList);
            MeioPagto(objDropDownList);
            CategoriaVeiculo(objDropDownList);
            Integrador(objDropDownList);
            PagtoPara(objDropDownList);
        }

        public static void PreencherControlesWebValorDefault(ControlCollection objControlCollection)
        {
            foreach (Control control in objControlCollection)
            {
                if (!control.HasControls())
                {
                    if (control is DropDownList)
                    {
                        DropDownList objDropDownList = (DropDownList)control;
                        PreencherControleDropDown(objDropDownList);
                    }
                }
                else
                {
                    PreencherControlesWebValorDefault(control.Controls);
                }
            }
        }

        private static void preencherDropDownList(Control componente, DataSet dsDados, string dataTextField, string dataValueField)
        {
            ((DropDownList)componente).Items.Clear();
            ((DropDownList)componente).AppendDataBoundItems = false;
            ((DropDownList)componente).AppendDataBoundItems = true;
            ((DropDownList)componente).DataSource = dsDados;
            ((DropDownList)componente).DataTextField = dataTextField;
            ((DropDownList)componente).DataValueField = dataValueField;
            ((DropDownList)componente).DataBind();
            if ((((DropDownList)componente).Items.Count > 0) && (((DropDownList)componente).Items[0].Value != "0"))
            {
                ((DropDownList)componente).Items.Clear();
                ((DropDownList)componente).Items.Insert(0, new ListItem("Selecione...", "0"));
                ((DropDownList)componente).AppendDataBoundItems = false;
                ((DropDownList)componente).AppendDataBoundItems = true;
                ((DropDownList)componente).DataSource = dsDados;
                ((DropDownList)componente).DataTextField = dataTextField;
                ((DropDownList)componente).DataValueField = dataValueField;
                ((DropDownList)componente).DataBind();
            }
        }

        public static void RecarregarPagina(Page objPage, int valorId)
        {
            objPage.Response.Redirect(objPage.AppRelativeVirtualPath + "?Id=" + valorId.ToString(), false);
        }

        public static void RegisterStartupScript(Page objPage)
        {
        }

        public static string RemoveNomeClasseIdControlePagina(string idControlePagina)
        {
            if (!idControlePagina.Contains("_"))
            {
                return idControlePagina;
            }
            string str = "";
            bool flag = false;
            for (int i = idControlePagina.Length - 1; i >= 0; i--)
            {
                if (flag)
                {
                    str = idControlePagina[i] + str;
                }
                if (idControlePagina[i] == '_')
                {
                    flag = true;
                }
            }
            return str;
        }

        private static void selecionarCheck(ControlCollection objControlCollection, GridViewRow row)
        {
            foreach (Control control in objControlCollection)
            {
                if (control is CheckBox)
                {
                    ((CheckBox)control).Attributes.Add("onClick", "SelecionarCheck(this,'" + row.RowState.ToString() + "');");
                }
                else if (control.HasControls())
                {
                    selecionarCheck(control.Controls, row);
                }
            }
        }

        private static void SituacaoContainer(Control componente)
        {
        }

        private static void SituacaoPedidoCarga(Control componente)
        {
        }

        private static void SituacaoProgramacao(Control componente)
        {
        }

        private static void TipoComponenteFrete(Control componente)
        {
        }

        private static void TipoConciliacao(Control componente)
        {
            if (GetIDControl(componente).ToUpper().Contains("DdlTipoConciliacao".ToUpper()) && (componente is DropDownList))
            {
                ((DropDownList)componente).Items.Insert(0, new ListItem("", "0"));
                ((DropDownList)componente).Items.Insert(1, new ListItem("PROVISÓRIA", "1"));
                ((DropDownList)componente).Items.Insert(2, new ListItem("FINAL", "2"));
            }
        }

        private static void TipoConta(Control componente)
        {
        }

        private static void TipoDocPedidoCliente(Control componente)
        {
        }

        private static void TipoEmissaoSEFAZ(Control componente)
        {
        }

        private static void TipoTributo(Control componente)
        {
        }

        private static void UF(Control componente)
        {
        }

        private static void UnidadesMedida(Control componente)
        {
        }
    }

    #region [ TipoMensagem ]
    public enum TipoMensagem { Information, Error, Warning };
    #endregion
}

