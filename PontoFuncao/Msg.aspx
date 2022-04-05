<%@ Page Title="" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeFile="Msg.aspx.cs" Inherits="Msg" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="width:97%;height:95%;background-color:#fff;">
        <div id="DivMsgExcecao">
            <asp:Image ID="Image1" runat="server" ImageUrl="~/images/alerta_128.png"  />
        </div>
        <div id="DivTextoExcecao" >
            Ocorreu uma exceção na funcionalidade padrão do sistema.<br />
            Por favor, tente novamente.<br /><br />
            Caso a exceção persista, contate o administrador do sistema.
        </div>
    </div>
</asp:Content>