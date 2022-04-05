<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Projeto</title>
    <link href="css/AreaDeLogin.css" rel="stylesheet" type="text/css"/>
    <link rel="icon" href="images/favicon.png">
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
         <div class="AreaTotal">
            <div id="wrapper" >
                
                <fieldset>
                    <legend>Projeto - Análise de Pontos de Função</legend>
                    <div id="logo" class="logomarca" >
                        <a href="#" target="_blank"><img  src="images/logo.png" width="250" height="70" alt="" /></a>
                    </div>
                    <asp:Label runat="server" id="lblMensagem" Text=""></asp:Label><br /><br />
                    <div>
                        <asp:textbox runat="server" MaxLength="20" ID="txtLogin" placeholder="Informe o usuário"></asp:textbox>
                    </div>
                    <div>
                        <asp:textbox runat="server" ID="txtSenha" TextMode="Password" MaxLength="50" placeholder="Informe sua senha"></asp:textbox>
                    </div>
                    <asp:Button runat="server" ID="btnEntrar" Text="Entrar" OnClick="btnEntrar_Click" />
                </fieldset>    
            </div>
        </div>
    </form>
</body>
</html>