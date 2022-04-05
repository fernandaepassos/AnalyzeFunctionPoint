<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CadFuncionario.aspx.cs" Inherits="Forms_Funcionario_CadFuncionario" %>

<%@ Register Assembly="Infragistics35.Web.v12.2, Version=12.2.20122.2147, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" Namespace="Infragistics.Web.UI.LayoutControls" TagPrefix="ig" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Funcionário</title>
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
            <ig:WebTab ID="WebTab1" runat="server" Height="100px" Width="670px" StyleSetName="ElectricBlue" BackColor="White" >
                <Tabs>
                    <ig:ContentTabItem runat="server" Text="Dados do Funcionário" BackColor="White">
                        <Template>
                            <div class="BoxCampos" style="top:10px;">
                                <table >
                                    <tr >
                                        <td>
                                            <asp:TextBox ID="txtIdFuncionario" runat="server" Visible="false"></asp:TextBox>
                                            <asp:TextBox ID="txtIdPessoa" runat="server" Visible="false"></asp:TextBox>
                                            <asp:Label runat="server" Text="Nome completo: "  CssClass="LabelTitulo"  ID="lblFuncionario"></asp:Label><br />
                                            <asp:TextBox runat="server" Text="" Width="490" MaxLength="100" CssClass="LabelDescricaoObr" ID="txtNome_Pessoa"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Label runat="server" Text="Nº matrícula:"  CssClass="LabelTitulo"  ID="lblNumMatricula"></asp:Label><br />
                                            <asp:TextBox runat="server" Text="" Width="150" MaxLength="100" CssClass="LabelDescricaoObr" ID="txtNumRegistro_Pessoa"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
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