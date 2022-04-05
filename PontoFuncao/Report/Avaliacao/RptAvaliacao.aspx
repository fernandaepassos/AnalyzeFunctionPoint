<%@ Page Title="" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeFile="RptAvaliacao.aspx.cs" Inherits="Report_Avaliacao_RptAvaliacao" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript" src="../../Files/Js/Mascaras.js"></script>
    <script src="../../Files/Js/Funcoes.js" type="text/javascript"></script> 
    <link rel="stylesheet" type="text/css" href="../../css/PadraoGlobal.css" title="style1" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="PaginaTitulo" style="width:300px;position:relative;" >&nbsp;<asp:Label runat="server" ID="lblTitulo" Text="Relatório de Avaliações"></asp:Label> </div>
        <div style="position:relative;top:5px;left:5px;">
        <table width="600px">
            <tr>
                <td align="left">
                    &nbsp;<asp:Image ID="imgMsg" runat="server" Width="20px" Height="24px" Visible="false" ImageUrl="~/images/excluir_128.png" />
                </td>
                <td align="left">
                    <asp:Label ID="LblMensagem"  runat="server" BorderStyle="None" Visible="false"  Font-Bold="False" Font-Names="Arial" Font-Size="Medium" ForeColor="#666666" Height="16px" ToolTip="Mensagem" Width="100%"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    <br /><br />
    <fieldset class="fieldset" style="vertical-align:central;left:30px;position:relative;width:400px;" >
        <legend>Filtro - Escolha uma das opções abaixo para realizar a pesquisa</legend>
        <table>
            <tr>
                <td>
                    <asp:Label runat="server" ID="lblPeriodoDe" CssClass="LabelTitulo" Text="Período de:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtPerdiodoDe" MaxLength="10" onKeyUp="mascaraData(this,data);" onblur="validaDat(this,this.value)" CssClass="Texbox" Width="100"></asp:TextBox>
                </td>
                <td>
                    <asp:Label runat="server" ID="Label1" CssClass="LabelTitulo" Text=" á "></asp:Label>
                    <asp:TextBox runat="server" ID="txtPeriodoAte" MaxLength="10" onKeyUp="mascaraData(this,data);" onblur="validaDat(this,this.value)" CssClass="Texbox" Width="100"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server" ID="Label2" CssClass="LabelTitulo" Text="KM:"></asp:Label>
                </td>
                <td colspan="3">
                    <asp:DropDownList runat="server" ID="ddlKm" Width="218" CssClass="DropDownList">
                        <asp:ListItem Text="" Value="" Selected="True"></asp:ListItem>
                        <asp:ListItem Text="ABAIXO DE  100.000 KM" Value="1"></asp:ListItem>
                        <asp:ListItem Text="ACIMA DE 100.001 KM" Value="2"></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server" ID="Label3" CssClass="LabelTitulo" Text="Ano:"></asp:Label>
                </td>
                <td colspan="3">
                    <asp:DropDownList runat="server" ID="ddlAno" Width="218" CssClass="DropDownList">
                        <asp:ListItem Text="" Value="" Selected="True"></asp:ListItem>
                        <asp:ListItem Text="ATÉ 3 ANOS" Value="1"></asp:ListItem>
                        <asp:ListItem Text="DE 4 À 6 ANOS" Value="2"></asp:ListItem>
                        <asp:ListItem Text="DE 7 À 9 ANOS" Value="3"></asp:ListItem>
                        <asp:ListItem Text="ACIMA DE 10 ANOS" Value="4"></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server" ID="Label4" CssClass="LabelTitulo" Text="Valor:"></asp:Label>
                </td>
                <td colspan="3">
                    <asp:DropDownList runat="server" ID="ddlValor" Width="218" CssClass="DropDownList">
                        <asp:ListItem Text="" Value="" Selected="True"></asp:ListItem>
                        <asp:ListItem Text="ATÉ R$ 10.000" Value="1"></asp:ListItem>
                        <asp:ListItem Text="DE R$ 10.001 À R$ 20.000" Value="2"></asp:ListItem>
                        <asp:ListItem Text="DE R$ 20.001 À R$ 35.000" Value="3"></asp:ListItem>
                        <asp:ListItem Text="DE R$ 35.001 À R$ 50.000" Value="4"></asp:ListItem>
                        <asp:ListItem Text="ACIMA DE R$ 50.001" Value="5"></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server" ID="Label5" CssClass="LabelTitulo" Text="Loja:"></asp:Label>
                </td>
                <td colspan="3">
                    <asp:DropDownList ID="ddlLoja" CssClass="DropDownList" Width="218" runat="server" DataValueField="IdFilial" DataTextField="RazaoSocial" DataSourceID="DsFilial"></asp:DropDownList>
                    <asp:ObjectDataSource ID="DsFilial" runat="server" SelectMethod="ListaFilialForDropDown" TypeName="Framework.Avaliacao.Filial">
                        <SelectParameters>
                            <asp:SessionParameter Name="strIdEmpresa" SessionField="IdEmpresa" Type="String" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server" ID="Label6" CssClass="LabelTitulo" Text="Finalidade:"></asp:Label>
                </td>
                <td colspan="3">
                    <asp:DropDownList runat="server" ID="ddlFinalidade" Width="218" CssClass="DropDownList">
                        <asp:ListItem Text="" Value="" Selected="True"></asp:ListItem>
                        <asp:ListItem Text="Trocar por novo" Value="Trocar por novo" ></asp:ListItem>
                        <asp:ListItem Text="Trocar por seminovo" Value="Trocar por seminovo" ></asp:ListItem>
                        <asp:ListItem Text="Compra" Value="Compra" ></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server" ID="Label7" CssClass="LabelTitulo" Text="Status:"></asp:Label>
                </td>
                <td colspan="3">
                     <asp:DropDownList  runat ="server" DataSourceID="DsStatus"  DataTextField="DescStatus" DataValueField="IdStatus" ID="ddlStatus"  CssClass="DropDownList" Width="218"></asp:DropDownList>
                        <asp:ObjectDataSource ID="DsStatus" runat="server" SelectMethod="ListaStatusPorTabelaCampo" TypeName="Framework.Avaliacao.StatusTabela">
                            <SelectParameters>
                                <asp:Parameter Name="strTabela" DefaultValue="Avalia" DbType="String"  />
                                <asp:Parameter Name="strCampo" DefaultValue="IdStatusAvaliacao" DbType="String"  />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server" ID="Label8" CssClass="LabelTitulo" Text="Vendedor:"></asp:Label>
                </td>
                <td colspan="3">
                       <asp:DropDownList DataSourceID="DsVendedor" DataValueField="IdPessoa" DataTextField="nome" runat="server" Width="218" ID="ddlVendedor" CssClass="DropDownList"></asp:DropDownList>
                        <asp:ObjectDataSource ID="DsVendedor" runat="server" SelectMethod="ListaPessoaVendedor" TypeName="Framework.Avaliacao.Pessoa">
                            <SelectParameters>
                                <asp:SessionParameter Name="strIdFilial" SessionField="IdFilial" Type="String" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                </td>
            </tr>
            <tr>
                <td colspan="4"></td>
            </tr>
            <tr>
                <td>
                    <asp:Button runat ="server" ID="btnNaTela" CssClass="Button" Text="Exibir em tela" style="width:100px;" OnClick="btnNaTela_Click" Visible="false" />
                </td>
                <td>
                    <asp:Button runat ="server" ID="btnPdf" CssClass="Button" Text="Exibir PDF" style="width:100px;" OnClick="btnNaTela_Click"/>
                </td>
                <td>
                    <asp:Button runat ="server" ID="btnExcel" CssClass="Button" Text="Exibir Excel" style="width:100px;" OnClick="btnNaTela_Click"/>
                </td>
                <td></td>
            </tr>
        </table>
    </fieldset>
</asp:Content>

