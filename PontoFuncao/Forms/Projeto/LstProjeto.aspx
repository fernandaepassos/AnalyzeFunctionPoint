<%@ Page Title="" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeFile="LstProjeto.aspx.cs" Inherits="Forms_Projeto_LstProjeto" %>

<%@ Register Assembly="Infragistics35.Web.v12.2, Version=12.2.20122.2147, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" Namespace="Infragistics.Web.UI.LayoutControls" TagPrefix="ig" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="PaginaHeader">
        <asp:Button runat="server" Text="Atualizar" ToolTip="Atualizar listagem." ID="btnAtualizar" CssClass="Button" OnClick="btnAtualizar_Click1" />
        <asp:Button runat="server" Text="Novo" ToolTip="Cadastro novo registro." ID="btnNovo_2" CssClass="Button" OnClick="btnNovo_Click" />
    </div>
    <div class="PaginaTitulo">&nbsp;Projetos</div>
    <div class=""> 
        <asp:Label ID="LblMensagem" runat="server" CssClass="MensagemLista" Text="" EnableViewState="false"></asp:Label>
        <div id="DivListaGrid" class="DivListaGrid">
            <asp:GridView ID="GvwLista" runat="server" Width="100%" CellSpacing="1" CellPadding="0" AllowSorting="True" GridLines="None" AutoGenerateColumns="False" AllowPaging="True" PageSize="20" OnPageIndexChanging="Paginacao_Grid" DataSourceID="DsGrid" OnSorting="GvwLista_Sorting" OnRowCommand="GvwLista_RowCommand"  OnRowDataBound="GvwLista_RowDataBound" >
            <RowStyle CssClass="primeiroRegistro" />
            <HeaderStyle CssClass="headerEstilo" />
            <PagerStyle CssClass="paginacaoEstilo" />
            <AlternatingRowStyle CssClass="segundoRegistro" />
            <Columns>
                <asp:TemplateField HeaderText="" HeaderStyle-Wrap="false" ItemStyle-Wrap="false" HeaderStyle-Width="20" >
                    <ItemTemplate>
                        <asp:ImageButton runat="server" ID="lblImageButton_4" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "IDPROJETO")%>' CommandName="Editar" ImageUrl="~/images/editar.png" ToolTip="Alterar registro." />
                    </ItemTemplate>
                    <HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="False" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="" HeaderStyle-Wrap="false" ItemStyle-Wrap="false" HeaderStyle-Width="20">
                    <ItemTemplate>
                        <asp:ImageButton runat="server" ID="imgExcluir" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "IDPROJETO")%>' CommandName="Excluir" ImageUrl="~/images/excluir.png" ToolTip="Excluir registro." />
                    </ItemTemplate>
                    <HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="False" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="" HeaderStyle-Wrap="false" ItemStyle-Wrap="false" Visible="false" >
                    <ItemTemplate>
                        <asp:Label ID="LBLIDPROJETO" runat="server" Text='<%# Eval("IDPROJETO") %>' Visible="false"></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="False" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Nome do Projetos" HeaderStyle-Wrap="false" ItemStyle-Wrap="false" SortExpression="Nome" >
                    <ItemTemplate>
                        <asp:Label ID="lblNome" runat="server" Text='<%# Eval("Nome") %>'></asp:Label>
                    </ItemTemplate><HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="False" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Equipe" HeaderStyle-Wrap="false" ItemStyle-Wrap="false" SortExpression="DESCEQUIPE"  >
                    <ItemTemplate>
                        <asp:Label ID="lblNumRegistro" runat="server" Text='<%# Eval("DESCEQUIPE") %>'></asp:Label>
                    </ItemTemplate><HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="False" />
                </asp:TemplateField>
            </Columns>
            </asp:GridView>
                <asp:ObjectDataSource ID="DsGrid" runat="server" SelectMethod="ListaProjeto" TypeName="Framework.PontoFuncao.Projeto"></asp:ObjectDataSource>
            <asp:Label ID="LblCount" runat="server" CssClass="lbldescricao"></asp:Label>
        </div>
        <ig:WebDialogWindow ID="dlgCadProjeto" StyleSetName="ElectricBlue" MaintainLocationOnScroll="False"  runat="server" Height="437" Width="700px"  InitialLocation="Centered" Modal="true" WindowState="Hidden" >
                <Resizer Enabled="True" />
        </ig:WebDialogWindow> 

    </div>
</asp:Content>


