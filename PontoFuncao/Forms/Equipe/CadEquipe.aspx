<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CadEquipe.aspx.cs" Inherits="Forms_Equipe_CadEquipe" %>

<%@ Register Assembly="Infragistics35.Web.v12.2, Version=12.2.20122.2147, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" Namespace="Infragistics.Web.UI.LayoutControls" TagPrefix="ig" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Equipe</title>
    <link rel="stylesheet" type="text/css" href="../../css/PadraoGlobal.css" title="style1" />
    <link rel="stylesheet" type="text/css" href="../../css/PadraoLista.css" title="style1" />
    <script src="../../Files/Js/Funcoes.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <ajax:ToolkitScriptManager runat="server" ID="scriptManagerCadFuncionario"></ajax:ToolkitScriptManager>
        <asp:UpdatePanel runat="server" ID="updPnlCadFuncionario" >
            <ContentTemplate>
            <div class="PaginaHeader">
                <asp:Button runat="server" Text="Excluir" ToolTip="Excluir registro." ID="btnExcluir_5" CssClass="Button" OnClick="btnExcluir_Click" />
                <asp:Button runat="server" Text="Salvar" ToolTip="Clique aqui para salvar" ID="btnSalvar" CssClass="Button" OnClick="btnSalvar_Click" />
            </div>
            <div class="LinhaSubSotoes" ></div>
            <div class="BoxMensagem">
                <table width="900px">
                    <tr>
                        <td align="left">
                            &nbsp;<asp:Image ID="imgMsg" runat="server" Width="20px" Height="24px" Visible="false" ImageUrl="~/images/excluir_128.png" />
                        </td>
                        <td align="left">
                            <asp:Label ID="LblMensagem" runat="server" BorderStyle="None" Visible="false"  Font-Bold="False" Font-Names="Arial" Font-Size="Medium" ForeColor="#666666" Height="16px" ToolTip="Mensagem" Width="95%"></asp:Label>
                            <asp:Label runat="server" ID="lblIdUsuario" Visible="false" ></asp:Label>
                        </td>
                    </tr>
                </table>
            </div>
            <div style="top:80px;position:absolute;">
             <ig:WebTab ID="WebTab1" runat="server" Height="1500px" Width="670px" StyleSetName="ElectricBlue" BackColor="White" >
                <Tabs>
                    <ig:ContentTabItem runat="server" Text="Dados da Equipe" BackColor="White">
                        <Template>
                            <div class="BoxCampos" style="top:10px;" >
                                <table >
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="txtIdEquipe" runat="server" Visible="false"></asp:TextBox>
                                            <asp:Label runat="server" Text="Nome da Equipe: "  CssClass="LabelTitulo"  ID="lblEquipe"></asp:Label><br />
                                            <asp:TextBox runat="server" Text="" Width="150" MaxLength="100" CssClass="LabelDescricaoObr" ID="txtNome_Equipe"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Label runat="server" Text="Tempo (hora) por Ponto de Função:"  CssClass="LabelTitulo"  ID="lblNumMatricula"></asp:Label><br />
                                            <asp:TextBox runat="server" Text="" Width="150" MaxLength="100" CssClass="LabelDescricaoObr" ID="txtHoraPorPontoFuncao_Equipe"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Label runat="server" Text="Valor do Ponto de Função:"  CssClass="LabelTitulo"  ID="Label1"></asp:Label><br />
                                            <asp:TextBox runat="server" Text="" Width="150" MaxLength="100" CssClass="LabelDescricaoObr" ID="txtValorPontoFuncao_Equipe"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div class="BoxCampos" style="top:60px;" runat="server" id="divComposicaoEquipe" >
                                <fieldset class="fieldset" style="width:625px;">
                                <legend>Composição da equipe : Funcionários associados</legend>
                                    <table style="width:400px;">
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblDiaSemana" runat="server" Text="Funcionário" CssClass="LabelTitulo" ></asp:Label><br />
                                            <asp:DropDownList DataValueField="IDPESSOA" DataTextField="NOME" DataSourceID="DsFuncionario" runat ="server" ID="ddlFuncionario" CssClass="DropDownList" Width="540"></asp:DropDownList>
                                            <asp:ObjectDataSource ID="DsFuncionario" runat="server" SelectMethod="ListaFuncionario" TypeName="Framework.PontoFuncao.Funcionario"></asp:ObjectDataSource>
                                        </td>
                                        <td  style="vertical-align:bottom;" > 
                                            <asp:Button runat="server" Text="Adicionar" CssClass="Button" ID="btnAdicionarHrAcesso" ToolTip="Adicionar hora de acesso ao sistema." Height="23" OnClick="btnAdicionarHrAcesso_Click" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4" style="height:100px;vertical-align:top;width:350px; ">
                                            <div id="Div1" class="DivListaGrid" style="top:5px;" >
                                                <asp:GridView ID="gridEquipePessoas"  DataSourceID="DsgridEquipePessoas" runat="server" Width="550" CellSpacing="1" CellPadding="0" AllowSorting="True" GridLines="None" AutoGenerateColumns="False" AllowPaging="True" PageSize="7" OnPageIndexChanging="Paginacao_Grid"  OnSorting="gridEquipePessoas_Sorting" OnRowCommand="gridEquipePessoas_RowCommand" >
                                                <RowStyle CssClass="primeiroRegistro" />
                                                <HeaderStyle CssClass="headerEstilo" />
                                                <PagerStyle CssClass="paginacaoEstilo" />
                                                <AlternatingRowStyle CssClass="segundoRegistro" />
                                                <Columns>
                                                      <asp:TemplateField HeaderText="" HeaderStyle-Wrap="false" ItemStyle-Wrap="false" HeaderStyle-Width="10" >
                                                        <ItemTemplate>
                                                            <asp:ImageButton runat="server" ID="imgExcluir" CommandArgument='<%# Eval("IDPESSOA") %>'  CommandName="Excluir" ImageUrl="~/images/excluir.png" ToolTip="Excluir registro." />
                                                        </ItemTemplate>
                                                        <HeaderStyle Wrap="False" />
                                                        <ItemStyle Wrap="False" />
                                                    </asp:TemplateField>
                                                     <asp:TemplateField HeaderText="Funcionário" HeaderStyle-Wrap="true" ItemStyle-Wrap="true" ItemStyle-Width="260" Visible="true" >
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblNomePessoa" runat="server" Text='<%# Eval("NomePessoa") %>' ></asp:Label>
                                                        </ItemTemplate><HeaderStyle Wrap="False" />
                                                        <ItemStyle Wrap="False" />
                                                    </asp:TemplateField>     
                                                </Columns>
                                                </asp:GridView>
                                                <asp:ObjectDataSource ID="DsgridEquipePessoas" runat="server" SelectMethod="ListaEquipePessoa" TypeName="Framework.PontoFuncao.EquipePessoa">
                                                    <SelectParameters>
                                                        <asp:ControlParameter ControlID="txtIdEquipe" PropertyName="Text" Name="intIdEquipe" Type="String" />
                                                    </SelectParameters>
                                                </asp:ObjectDataSource>
                                               <asp:Label ID="LblCount" runat="server" CssClass="lbldescricao"></asp:Label>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </fieldset>
                            </div>
                        </Template>
                    </ig:ContentTabItem>
                </Tabs>
            </ig:WebTab>
            </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>