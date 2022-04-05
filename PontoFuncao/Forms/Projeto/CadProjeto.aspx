<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CadProjeto.aspx.cs" Inherits="Forms_Projeto_CadProjeto" %>

<%@ Register Assembly="Infragistics35.Web.v12.2, Version=12.2.20122.2147, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" Namespace="Infragistics.Web.UI.LayoutControls" TagPrefix="ig" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Projeto</title>
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
            <ig:WebTab ID="WebTab1" runat="server" Height="300px" Width="670px" StyleSetName="ElectricBlue" BackColor="White" OnSelectedIndexChanged="WebTab1_SelectedIndexChanged"  >
                <Tabs>
                    <ig:ContentTabItem runat="server" Text="Projeto" BackColor="White">
                        <Template>
                            <div class="BoxCampos" style="top:10px;">
                                <table >
                                    <tr >
                                        <td>
                                            <asp:TextBox ID="txtIdProjeto" runat="server" Visible="false"></asp:TextBox>
                                            <asp:TextBox ID="txtIdProjetoContagem" runat="server" Visible="false"></asp:TextBox>
                                            <asp:TextBox ID="txtIdProjetoComplexidade" runat="server" Visible="false"></asp:TextBox>
                                            <asp:TextBox ID="txtIdProjetoFuncaoDados" runat="server" Visible="false"></asp:TextBox>
                                            <asp:TextBox ID="txtIdProjetoFuncaoTransacao" runat="server" Visible="false"></asp:TextBox>
                                            <asp:Label runat="server" Text="Nome do Projeto: "  CssClass="LabelTitulo"  ID="lblNomeProjeto"></asp:Label><br />
                                            <asp:TextBox runat="server" Text="" Width="150" MaxLength="100" CssClass="LabelDescricaoObr" ID="txtNome_Projeto"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Label runat="server" Text="Equipe Alocada:"  CssClass="LabelTitulo"  ID="lblEquipe"></asp:Label><br />
                                            <asp:DropDownList DataValueField="IDEQUIPE" DataTextField="NOME" DataSourceID="DsEquipe" runat ="server" ID="ddlIdEquipe_Projeto" CssClass="DropDownListObr" Width="150"></asp:DropDownList>
                                            <asp:ObjectDataSource ID="DsEquipe" runat="server" SelectMethod="ListaEquipeParaListagem" TypeName="Framework.PontoFuncao.Equipe"></asp:ObjectDataSource>
                                        </td>
                                    </tr>
                                </table>
                                <fieldset class="fieldset" style="width:325px; left:150px;position:relative;top:60px;" runat="server" id="divVisaoGeral" visible="false">
                                <legend>Análise Geral</legend>
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:Label runat="server" Text="Tamanho Funcional: "  CssClass="LabelTitulo"  ID="Label37"></asp:Label><br />
                                                <asp:TextBox runat="server" BackColor="White" Text="" Width="150" Enabled="false" MaxLength="100" CssClass="LabelDescricao" ID="txtTamahoFuncional"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:Label runat="server" Text="Tamanho Funcional Ajustado: "  CssClass="LabelTitulo"  ID="Label38"></asp:Label><br />
                                                <asp:TextBox runat="server"  BackColor="White" Text="" Width="150" Enabled="false" MaxLength="100" CssClass="LabelDescricao" ID="txtTamahoFuncionalAjustado"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label runat="server" Text="Tempo Homem Hora: "  CssClass="LabelTitulo"  ID="Label39"></asp:Label><br />
                                                <asp:TextBox runat="server" Text="" Width="150"  BackColor="White" Enabled="false" MaxLength="100" CssClass="LabelDescricao" ID="txtTempoHomemHora"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:Label runat="server" Text="Preço do ponto de função: "  CssClass="LabelTitulo"  ID="Label40"></asp:Label><br />
                                                <asp:TextBox runat="server" Text="" Width="150" Enabled="false"  BackColor="White" MaxLength="100" CssClass="LabelDescricao" ID="txtValorTotalProjeto" ></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </fieldset>
                            </div>
                        </Template>
                    </ig:ContentTabItem>
                    <ig:ContentTabItem runat="server" Text="Configurar Contagem" BackColor="White">
                        <Template>
                            <div class="BoxCampos" style="top:10px;" >
                                <table >
                                    <tr >
                                        <td>
                                            <asp:Label runat="server" Text="Comunicacao de Dados: "  CssClass="LabelTitulo"  ID="Label1"></asp:Label><br />
                                            <asp:TextBox OnTextChanged="Contagem_TextChanged" AutoPostBack="true" runat="server" onkeyup="campoNumeroDe0a5(this);" Text="" Width="150" MaxLength="1" CssClass="LabelDescricao" ID="txtComunicacaoDados"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Label runat="server" Text="Processamento Distribuído: "  CssClass="LabelTitulo"  ID="Label2"></asp:Label><br />
                                            <asp:TextBox OnTextChanged="Contagem_TextChanged" AutoPostBack="true" runat="server" onkeyup="campoNumeroDe0a5(this);" Text="" Width="150" MaxLength="1" CssClass="LabelDescricao" ID="txtProcessamentoDistribuido"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Label runat="server" Text="Performance: "  CssClass="LabelTitulo"  ID="Label3"></asp:Label><br />
                                            <asp:TextBox OnTextChanged="Contagem_TextChanged" AutoPostBack="true" runat="server" onkeyup="campoNumeroDe0a5(this);" Text="" Width="150" MaxLength="1" CssClass="LabelDescricao" ID="txtPerformance"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Label runat="server" Text="Config. Intensamente Utilizada: "  CssClass="LabelTitulo"  ID="Label4"></asp:Label><br />
                                            <asp:TextBox OnTextChanged="Contagem_TextChanged" AutoPostBack="true" runat="server" onkeyup="campoNumeroDe0a5(this);" Text="" Width="150" MaxLength="1" CssClass="LabelDescricao" ID="txtConfigIntensaUsada"></asp:TextBox>
                                        </td>
                                    </tr>
                                     <tr >
                                        <td>
                                            <asp:Label runat="server" Text="Volume de Transações: "  CssClass="LabelTitulo"  ID="Label5"></asp:Label><br />
                                            <asp:TextBox OnTextChanged="Contagem_TextChanged" AutoPostBack="true" runat="server" onkeyup="campoNumeroDe0a5(this);" Text="" Width="150" MaxLength="1" CssClass="LabelDescricao" ID="txtVolumeTransacao"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Label runat="server" Text="Entrada de Dados Online: "  CssClass="LabelTitulo"  ID="Label6"></asp:Label><br />
                                            <asp:TextBox OnTextChanged="Contagem_TextChanged" AutoPostBack="true" runat="server" onkeyup="campoNumeroDe0a5(this);" Text="" Width="150" MaxLength="1" CssClass="LabelDescricao" ID="txtEntradaDadosOnline"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Label runat="server" Text="Eficiência do Usuário Final: "  CssClass="LabelTitulo"  ID="Label7"></asp:Label><br />
                                            <asp:TextBox OnTextChanged="Contagem_TextChanged" AutoPostBack="true" runat="server" onkeyup="campoNumeroDe0a5(this);" Text="" Width="150" MaxLength="1" CssClass="LabelDescricao" ID="txtEficienciaUsuarioFinal"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Label runat="server" Text="Atualização Online: "  CssClass="LabelTitulo"  ID="Label8"></asp:Label><br />
                                            <asp:TextBox OnTextChanged="Contagem_TextChanged" AutoPostBack="true" runat="server" onkeyup="campoNumeroDe0a5(this);" Text="" Width="150" MaxLength="1" CssClass="LabelDescricao" ID="txtAtualizacaoOnline"></asp:TextBox>
                                        </td>
                                    </tr>
                                     <tr >
                                        <td>
                                            <asp:Label runat="server" Text="Processamento Complexo: "  CssClass="LabelTitulo"  ID="Label9"></asp:Label><br />
                                            <asp:TextBox OnTextChanged="Contagem_TextChanged" AutoPostBack="true" runat="server" onkeyup="campoNumeroDe0a5(this);" Text="" Width="150" MaxLength="1" CssClass="LabelDescricao" ID="txtProcessamentoComplexo"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Label runat="server" Text="Reusabilidade: "  CssClass="LabelTitulo"  ID="Label10"></asp:Label><br />
                                            <asp:TextBox OnTextChanged="Contagem_TextChanged" AutoPostBack="true" runat="server" onkeyup="campoNumeroDe0a5(this);" Text="" Width="150" MaxLength="1" CssClass="LabelDescricao" ID="txtReusabilidade"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Label runat="server" Text="Facilidade de Instalação: "  CssClass="LabelTitulo"  ID="Label11"></asp:Label><br />
                                            <asp:TextBox OnTextChanged="Contagem_TextChanged" AutoPostBack="true" runat="server" onkeyup="campoNumeroDe0a5(this);" Text="" Width="150" MaxLength="1" CssClass="LabelDescricao" ID="txtFacilidadeInstalacao"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Label runat="server" Text="Facilidade de Operação: "  CssClass="LabelTitulo"  ID="Label12"></asp:Label><br />
                                            <asp:TextBox OnTextChanged="Contagem_TextChanged" AutoPostBack="true" runat="server" onkeyup="campoNumeroDe0a5(this);" Text="" Width="150" MaxLength="1" CssClass="LabelDescricao" ID="txtFacilidadeOperacao"></asp:TextBox>
                                        </td>
                                    </tr>
                                     <tr >
                                        <td>
                                            <asp:Label runat="server" Text="Múltiplos locais: "  CssClass="LabelTitulo"  ID="Label13"></asp:Label><br />
                                            <asp:TextBox OnTextChanged="Contagem_TextChanged" AutoPostBack="true" runat="server" onkeyup="campoNumeroDe0a5(this);" Text="" Width="150" MaxLength="1" CssClass="LabelDescricao" ID="txtMultiplosLocais"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Label runat="server" Text="Facilidade de Mudança: "  CssClass="LabelTitulo"  ID="Label14"></asp:Label><br />
                                            <asp:TextBox OnTextChanged="Contagem_TextChanged" AutoPostBack="true" runat="server" onkeyup="campoNumeroDe0a5(this);" Text="" Width="150" MaxLength="1" CssClass="LabelDescricao" ID="txtFacilidadeMudancao"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                                <div style="position:relative; width:100%;text-align:left;">
                                    <asp:Label ID="lblContagemSome" runat="server" Font-Bold="true" ForeColor="Blue" Font-Size="12"></asp:Label>
                                </div>
                                <div style="position:relative; width:100%;text-align:right;bottom:-70px;">
                                    <asp:Button runat="server" Text="Salvar" ToolTip="Salvar configuração da contagem." ID="btnContagem" CssClass="Button" OnClick="btnContagem_Click" />
                                </div>
                            </div>
                        </Template>
                    </ig:ContentTabItem>
                    <ig:ContentTabItem runat="server" Text="Configurar Complexidade" BackColor="White">
                        <Template>
                            <div class="BoxCampos" style="top:10px;" >
                                <table >
                                    <tr >
                                        <td>
                                            <asp:Label runat="server" Text="AIE Baixo: "  CssClass="LabelTitulo"  ID="Label17"></asp:Label><br />
                                            <asp:TextBox runat="server" onkeyup="campoNumero(this);" Text="5" Width="150"  CssClass="LabelDescricao" ID="txtAIE_BAIXO"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Label runat="server" Text="AIE Médio: "  CssClass="LabelTitulo"  ID="Label16"></asp:Label><br />
                                            <asp:TextBox runat="server" onkeyup="campoNumero(this);" Text="7" Width="150"  CssClass="LabelDescricao" ID="txtAIE_MEDIO"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Label runat="server" Text="AIE Alto: "  CssClass="LabelTitulo"  ID="Label15"></asp:Label><br />
                                            <asp:TextBox  runat="server" onkeyup="campoNumero(this);" Text="10" Width="150"  CssClass="LabelDescricao" ID="txtAIE_ALTO"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr >
                                        <td>
                                            <asp:Label runat="server" Text="ALI Baixo: "  CssClass="LabelTitulo"  ID="Label18"></asp:Label><br />
                                            <asp:TextBox runat="server" onkeyup="campoNumero(this);" Text="7" Width="150" CssClass="LabelDescricao" ID="txtALI_BAIXO"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Label runat="server" Text="ALI Médio: "  CssClass="LabelTitulo"  ID="Label19"></asp:Label><br />
                                            <asp:TextBox runat="server" onkeyup="campoNumero(this);" Text="10" Width="150"  CssClass="LabelDescricao" ID="txtALI_MEDIO"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Label runat="server" Text="ALI Alto: "  CssClass="LabelTitulo"  ID="Label20"></asp:Label><br />
                                            <asp:TextBox  runat="server" onkeyup="campoNumero(this);" Text="15" Width="150"  CssClass="LabelDescricao" ID="txtALI_ALTO"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr >
                                        <td>
                                            <asp:Label runat="server" Text="EE Baixo: "  CssClass="LabelTitulo"  ID="Label21"></asp:Label><br />
                                            <asp:TextBox runat="server" onkeyup="campoNumero(this);" Text="3" Width="150"  CssClass="LabelDescricao" ID="txtEE_BAIXO"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Label runat="server" Text="EE Médio: "  CssClass="LabelTitulo"  ID="Label22"></asp:Label><br />
                                            <asp:TextBox runat="server" onkeyup="campoNumero(this);" Text="4" Width="150"  CssClass="LabelDescricao" ID="txtEE_MEDIO"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Label runat="server" Text="EE Alto: "  CssClass="LabelTitulo"  ID="Label23"></asp:Label><br />
                                            <asp:TextBox  runat="server" onkeyup="campoNumero(this);" Text="6" Width="150"  CssClass="LabelDescricao" ID="txtEE_ALTO"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr >
                                        <td>
                                            <asp:Label runat="server" Text="CE Baixa    : "  CssClass="LabelTitulo"  ID="Label24"></asp:Label><br />
                                            <asp:TextBox runat="server" onkeyup="campoNumero(this);" Text="3" Width="150" CssClass="LabelDescricao" ID="txtCE_BAIXA"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Label runat="server" Text="CE Média: "  CssClass="LabelTitulo"  ID="Label25"></asp:Label><br />
                                            <asp:TextBox runat="server" onkeyup="campoNumero(this);" Text="4" Width="150"  CssClass="LabelDescricao" ID="txtCE_MEDIA"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Label runat="server" Text="CE Alta: "  CssClass="LabelTitulo"  ID="Label26"></asp:Label><br />
                                            <asp:TextBox  runat="server" onkeyup="campoNumero(this);" Text="6" Width="150" CssClass="LabelDescricao" ID="txtCE_ALTA"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr >
                                        <td>
                                            <asp:Label runat="server" Text="SE Baixa: "  CssClass="LabelTitulo"  ID="Label27"></asp:Label><br />
                                            <asp:TextBox runat="server" onkeyup="campoNumero(this);" Text="4" Width="150"  CssClass="LabelDescricao" ID="txtSE_BAIXA"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Label runat="server" Text="SE Média: "  CssClass="LabelTitulo"  ID="Label28"></asp:Label><br />
                                            <asp:TextBox runat="server" onkeyup="campoNumero(this);" Text="5" Width="150"  CssClass="LabelDescricao" ID="txtSE_MEDIA"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Label runat="server" Text="SE Alta: "  CssClass="LabelTitulo"  ID="Label30"></asp:Label><br />
                                            <asp:TextBox  runat="server" onkeyup="campoNumero(this);" Text="7" Width="150" CssClass="LabelDescricao" ID="txtSE_ALTA"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                                <div style="position:relative; width:100%;text-align:right;bottom:-30px;">
                                    <asp:Button runat="server" Text="Salvar" ToolTip="Salvar configuração da complexidade." ID="btnConfigComplexidade" CssClass="Button" OnClick="btnConfigComplexidade_Click" />
                                </div>
                            </div>
                        </Template>
                    </ig:ContentTabItem>
                    <ig:ContentTabItem runat="server" Text="Função de Dados" BackColor="White">
                        <Template>
                            <div class="BoxCampos" style="top:10px;" >
                                <table >
                                    <tr >
                                        <td>
                                            <asp:Label runat="server" Text="Nome: "  CssClass="LabelTitulo"  ID="Label45"></asp:Label><br />
                                            <asp:TextBox runat="server"  Text="" Width="150"  CssClass="LabelDescricao" ID="txtFdNome"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Label runat="server" Text="Tipo: "  CssClass="LabelTitulo"  ID="Label29"></asp:Label><br />
                                            <asp:DropDownList runat ="server" ID="ddlFdIdTipo" CssClass="DropDownListObr" Width="150">
                                                <asp:ListItem Text="" Value="" Selected="True"></asp:ListItem>
                                                <asp:ListItem Text="AIE" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="ALI" Value="2"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:Label runat="server" Text="TR: "  CssClass="LabelTitulo"  ID="Label31"></asp:Label><br />
                                            <asp:TextBox runat="server" onkeyup="campoNumero(this);" Text="" Width="150"  CssClass="LabelDescricao" ID="txtFdNumTr"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Label runat="server" Text="TD: "  CssClass="LabelTitulo"  ID="Label32"></asp:Label><br />
                                            <asp:TextBox  runat="server" onkeyup="campoNumero(this);" Text="" Width="150"  CssClass="LabelDescricao" ID="txtFdNumTd"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4" style="text-align:right;">
                                            <asp:Button runat="server" Text="Atualizar" ToolTip="Atualizar." ID="btnAtualizadFuncaoDados" CssClass="Button" OnClick="btnAtualizadFuncaoDados_Click" />
                                            <asp:Button runat="server" Text="Novo" ToolTip="Salvar função de dados." ID="btnFuncaoDadosNovo" CssClass="Button" OnClick="btnFuncaoDadosNovo_Click" />
                                            <asp:Button runat="server" Text="Salvar" ToolTip="Salvar função de dados." ID="btnFuncaoDados" CssClass="Button" OnClick="btnFuncaoDados_Click" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4" style="height:100px;vertical-align:top;width:350px; ">
                                            <div id="Div1" class="DivListaGrid" style="top:5px;" >
                                                <asp:GridView ID="GvwLista"  DataSourceID="DsGridFuncaoDados" runat="server" Width="550" CellSpacing="1" CellPadding="0" AllowSorting="True" GridLines="None" AutoGenerateColumns="False" AllowPaging="True" PageSize="7" OnPageIndexChanging="Paginacao_Grid"  OnSorting="GvwLista_Sorting" OnRowCommand="GvwLista_RowCommand" >
                                                <RowStyle CssClass="primeiroRegistro" />
                                                <HeaderStyle CssClass="headerEstilo" />
                                                <PagerStyle CssClass="paginacaoEstilo" />
                                                <AlternatingRowStyle CssClass="segundoRegistro" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="" HeaderStyle-Wrap="false" ItemStyle-Wrap="false" >
                                                        <ItemTemplate>
                                                            <asp:ImageButton runat="server" ID="imgAlterar" CommandArgument='<%# Eval("IDPROJETOFUNCAODADOS") %>'  CommandName="Alterar" ImageUrl="~/images/editar.png" ToolTip="Alterar registro." />
                                                        </ItemTemplate>
                                                        <HeaderStyle Wrap="False" />
                                                        <ItemStyle Wrap="False" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="" HeaderStyle-Wrap="false" ItemStyle-Wrap="false" >
                                                        <ItemTemplate>
                                                            <asp:ImageButton runat="server" ID="imgExcluir" CommandArgument='<%# Eval("IDPROJETOFUNCAODADOS") %>'  CommandName="Excluir" ImageUrl="~/images/excluir.png" ToolTip="Excluir registro." />
                                                        </ItemTemplate>
                                                        <HeaderStyle Wrap="False" />
                                                        <ItemStyle Wrap="False" />
                                                    </asp:TemplateField>
                                                     <asp:TemplateField HeaderText="" HeaderStyle-Wrap="false" ItemStyle-Wrap="false" ItemStyle-Width="260" Visible="false" >
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblIDPROJETOFUNCAODADOS" runat="server" Text='<%# Eval("IDPROJETOFUNCAODADOS") %>' ></asp:Label>
                                                        </ItemTemplate><HeaderStyle Wrap="False" />
                                                        <ItemStyle Wrap="False" />
                                                    </asp:TemplateField>     
                                                     <asp:TemplateField HeaderText="" HeaderStyle-Wrap="false" ItemStyle-Wrap="false" ItemStyle-Width="260" Visible="false" >
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblIDPROJETO" runat="server" Text='<%# Eval("IDPROJETO") %>' ></asp:Label>
                                                        </ItemTemplate><HeaderStyle Wrap="False" />
                                                        <ItemStyle Wrap="False" />
                                                    </asp:TemplateField>     
                                                     <asp:TemplateField HeaderText="Nome" HeaderStyle-Wrap="false" ItemStyle-Wrap="false" SortExpression="NOME"  ItemStyle-Width="300" >
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblNOME" runat="server" Text='<%# Eval("NOME") %>' ></asp:Label>
                                                        </ItemTemplate><HeaderStyle Wrap="False" />
                                                        <ItemStyle Wrap="False" />
                                                    </asp:TemplateField>     
                                                     <asp:TemplateField HeaderText="Tipo" HeaderStyle-Wrap="false" ItemStyle-Wrap="false" SortExpression="DSTIPO"  ItemStyle-Width="260" >
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblDSTIPO" runat="server" Text='<%# Eval("DSTIPO") %>' ></asp:Label>
                                                        </ItemTemplate><HeaderStyle Wrap="False" />
                                                        <ItemStyle Wrap="False" />
                                                    </asp:TemplateField>     
                                                     <asp:TemplateField HeaderText="TR" HeaderStyle-Wrap="false" ItemStyle-Wrap="false" SortExpression="NUMTR"  ItemStyle-Width="260" >
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblNUMTR" runat="server" Text='<%# Eval("NUMTR") %>' ></asp:Label>
                                                        </ItemTemplate><HeaderStyle Wrap="False" />
                                                        <ItemStyle Wrap="False" />
                                                    </asp:TemplateField>     
                                                     <asp:TemplateField HeaderText="TD" HeaderStyle-Wrap="false" ItemStyle-Wrap="false" SortExpression="NUMTD"  ItemStyle-Width="260" >
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblNUMTD" runat="server" Text='<%# Eval("NUMTD") %>' ></asp:Label>
                                                        </ItemTemplate><HeaderStyle Wrap="False" />
                                                        <ItemStyle Wrap="False" />
                                                    </asp:TemplateField>                                                        
                                                     <asp:TemplateField HeaderText="Complexidade" HeaderStyle-Wrap="false" ItemStyle-Wrap="false" SortExpression="DSPRIORIDADE "  ItemStyle-Width="260" >
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblPRIORIDADE" runat="server" Text='<%# Eval("DSPRIORIDADE ") %>' ></asp:Label>
                                                        </ItemTemplate><HeaderStyle Wrap="False" />
                                                        <ItemStyle Wrap="False" />
                                                    </asp:TemplateField>                                                        
                                                     <asp:TemplateField HeaderText="Ponto de Função" HeaderStyle-Wrap="false" ItemStyle-Wrap="false" SortExpression="QTDPONTOFUNCAO"  ItemStyle-Width="260" >
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblQTDPONTOFUNCAO" runat="server" Text='<%# Eval("QTDPONTOFUNCAO") %>' ></asp:Label>
                                                        </ItemTemplate><HeaderStyle Wrap="False" />
                                                        <ItemStyle Wrap="False" />
                                                    </asp:TemplateField>                                                        
                                                </Columns>
                                                </asp:GridView>
                                                <asp:ObjectDataSource ID="DsGridFuncaoDados" runat="server" SelectMethod="ListaFuncaoDados" TypeName="Framework.PontoFuncao.ProjetoFuncaoDados">
                                                    <SelectParameters>
                                                        <asp:SessionParameter SessionField="IdProjeto" Name="strIdProjeto" Type="String" />
                                                    </SelectParameters>
                                                </asp:ObjectDataSource>
                                                <asp:Label ID="LblCount" runat="server" CssClass="lbldescricao"></asp:Label>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </Template>
                    </ig:ContentTabItem>
                    <ig:ContentTabItem runat="server" Text="Função de Transação" BackColor="White">
                        <Template>
                            <div class="BoxCampos" style="top:10px;" >
                                <table >
                                    <tr >
                                        <td>
                                            <asp:Label runat="server" Text="Nome: "  CssClass="LabelTitulo"  ID="Label33"></asp:Label><br />
                                            <asp:TextBox runat="server"  Text="" Width="150"  CssClass="LabelDescricao" ID="txtFtNome"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Label runat="server" Text="Tipo: "  CssClass="LabelTitulo"  ID="Label34"></asp:Label><br />
                                            <asp:DropDownList runat ="server" ID="ddlFtIdTipo" CssClass="DropDownListObr" Width="150">
                                                <asp:ListItem Text="" Value="" Selected="True"></asp:ListItem>
                                                <asp:ListItem Text="EE" Value="6"></asp:ListItem>
                                                <asp:ListItem Text="CE" Value="7"></asp:ListItem>
                                                <asp:ListItem Text="SE" Value="8"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:Label runat="server" Text="AR´s: "  CssClass="LabelTitulo"  ID="Label35"></asp:Label><br />
                                            <asp:TextBox runat="server" onkeyup="campoNumero(this);" Text="" Width="150"  CssClass="LabelDescricao" ID="txtfTNumAr"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Label runat="server" Text="TD´s: "  CssClass="LabelTitulo"  ID="Label36"></asp:Label><br />
                                            <asp:TextBox  runat="server" onkeyup="campoNumero(this);" Text="" Width="150"  CssClass="LabelDescricao" ID="txtFtNumTd"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4" style="text-align:right;">
                                            <asp:Button runat="server" Text="Atualizar" ToolTip="Atualizar listagem." ID="btnAtualizar" CssClass="Button" OnClick="btnAtualizar_Click" />
                                            <asp:Button runat="server" Text="Novo" ToolTip="Salvar função de transação." ID="btnFtNovo" CssClass="Button" OnClick="btnftFuncaoDadosNovo_Click" />
                                            <asp:Button runat="server" Text="Salvar" ToolTip="Salvar função de transação." ID="btnFtSalvar" CssClass="Button" OnClick="btnFuncaoTransacao_Click" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4" style="height:100px;vertical-align:top;width:350px; ">
                                            <div id="Div1" class="DivListaGrid" style="top:5px;" >
                                                <asp:GridView ID="gridFuncaoTransacao"  DataSourceID="DsFuncaoTransacao" runat="server" Width="550" CellSpacing="1" CellPadding="0" AllowSorting="True" GridLines="None" AutoGenerateColumns="False" AllowPaging="True" PageSize="7" OnPageIndexChanging="Paginacao_GridFuncaoTransacao"  OnSorting="GvwLista_SortingFuncaoTransacao" OnRowCommand="GvwLista_RowCommandFuncaoTransacao" >
                                                <RowStyle CssClass="primeiroRegistro" />
                                                <HeaderStyle CssClass="headerEstilo" />
                                                <PagerStyle CssClass="paginacaoEstilo" />
                                                <AlternatingRowStyle CssClass="segundoRegistro" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="" HeaderStyle-Wrap="false" ItemStyle-Wrap="false" >
                                                        <ItemTemplate>
                                                            <asp:ImageButton runat="server" ID="imgAlterar" CommandArgument='<%# Eval("IDPROJETOFUNCAOTRANSACAO") %>'  CommandName="Alterar" ImageUrl="~/images/editar.png" ToolTip="Alterar registro." />
                                                        </ItemTemplate>
                                                        <HeaderStyle Wrap="False" />
                                                        <ItemStyle Wrap="False" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="" HeaderStyle-Wrap="false" ItemStyle-Wrap="false" >
                                                        <ItemTemplate>
                                                            <asp:ImageButton runat="server" ID="imgExcluir" CommandArgument='<%# Eval("IDPROJETOFUNCAOTRANSACAO") %>'  CommandName="Excluir" ImageUrl="~/images/excluir.png" ToolTip="Excluir registro." />
                                                        </ItemTemplate>
                                                        <HeaderStyle Wrap="False" />
                                                        <ItemStyle Wrap="False" />
                                                    </asp:TemplateField>
                                                     <asp:TemplateField HeaderText="" HeaderStyle-Wrap="false" ItemStyle-Wrap="false" ItemStyle-Width="260" Visible="false" >
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblIDPROJETOFUNCAOTRANSACAO" runat="server" Text='<%# Eval("IDPROJETOFUNCAOTRANSACAO") %>' ></asp:Label>
                                                        </ItemTemplate><HeaderStyle Wrap="False" />
                                                        <ItemStyle Wrap="False" />
                                                    </asp:TemplateField>     
                                                     <asp:TemplateField HeaderText="" HeaderStyle-Wrap="false" ItemStyle-Wrap="false" ItemStyle-Width="260" Visible="false" >
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblIDPROJETO" runat="server" Text='<%# Eval("IDPROJETO") %>' ></asp:Label>
                                                        </ItemTemplate><HeaderStyle Wrap="False" />
                                                        <ItemStyle Wrap="False" />
                                                    </asp:TemplateField>     
                                                     <asp:TemplateField HeaderText="Nome" HeaderStyle-Wrap="false" ItemStyle-Wrap="false" SortExpression="NOME"  ItemStyle-Width="300" >
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblNOME" runat="server" Text='<%# Eval("NOME") %>' ></asp:Label>
                                                        </ItemTemplate><HeaderStyle Wrap="False" />
                                                        <ItemStyle Wrap="False" />
                                                    </asp:TemplateField>     
                                                     <asp:TemplateField HeaderText="Tipo" HeaderStyle-Wrap="false" ItemStyle-Wrap="false" SortExpression="DSTIPO"  ItemStyle-Width="260" >
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblDSTIPO" runat="server" Text='<%# Eval("DSTIPO") %>' ></asp:Label>
                                                        </ItemTemplate><HeaderStyle Wrap="False" />
                                                        <ItemStyle Wrap="False" />
                                                    </asp:TemplateField>     
                                                     <asp:TemplateField HeaderText="AR´s" HeaderStyle-Wrap="false" ItemStyle-Wrap="false" SortExpression="NUMAR"  ItemStyle-Width="260" >
                                                        <ItemTemplate>
                                                            <asp:Label ID="NUMAR" runat="server" Text='<%# Eval("NUMAR") %>' ></asp:Label>
                                                        </ItemTemplate><HeaderStyle Wrap="False" />
                                                        <ItemStyle Wrap="False" />
                                                    </asp:TemplateField>     
                                                     <asp:TemplateField HeaderText="TD´s" HeaderStyle-Wrap="false" ItemStyle-Wrap="false" SortExpression="NUMTD"  ItemStyle-Width="260" >
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblNUMTD" runat="server" Text='<%# Eval("NUMTD") %>' ></asp:Label>
                                                        </ItemTemplate><HeaderStyle Wrap="False" />
                                                        <ItemStyle Wrap="False" />
                                                    </asp:TemplateField>                                                        
                                                     <asp:TemplateField HeaderText="Complexidade" HeaderStyle-Wrap="false" ItemStyle-Wrap="false" SortExpression="DSPRIORIDADE "  ItemStyle-Width="260" >
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblPRIORIDADE" runat="server" Text='<%# Eval("DSPRIORIDADE ") %>' ></asp:Label>
                                                        </ItemTemplate><HeaderStyle Wrap="False" />
                                                        <ItemStyle Wrap="False" />
                                                    </asp:TemplateField>                                                        
                                                     <asp:TemplateField HeaderText="Ponto de Função" HeaderStyle-Wrap="false" ItemStyle-Wrap="false" SortExpression="QTDPONTOFUNCAO"  ItemStyle-Width="260" >
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblQTDPONTOFUNCAO" runat="server" Text='<%# Eval("QTDPONTOFUNCAO") %>' ></asp:Label>
                                                        </ItemTemplate><HeaderStyle Wrap="False" />
                                                        <ItemStyle Wrap="False" />
                                                    </asp:TemplateField>                                                        
                                                </Columns>
                                                </asp:GridView>
                                                <asp:ObjectDataSource ID="DsFuncaoTransacao" runat="server" SelectMethod="ListaFuncaoTransacao" TypeName="Framework.PontoFuncao.ProjetoFuncaoTransacao">
                                                    <SelectParameters>
                                                        <asp:SessionParameter SessionField="IdProjeto" Name="strIdProjeto" Type="String" />
                                                    </SelectParameters>
                                                </asp:ObjectDataSource>
                                                <asp:Label ID="LblCountFt" runat="server" CssClass="lbldescricao"></asp:Label>
                                            </div>
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