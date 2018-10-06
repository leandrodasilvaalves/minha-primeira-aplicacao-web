<%@ Page Language="C#" AutoEventWireup="true" CodeFile="altera_usuario.aspx.cs" Inherits="altera_usuario" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        body { font-family:Arial;}
        .style1
        {
            width: 100%;
        }
        .style2
        {
        }
        .style3
        {
            width: 196px;
            height: 23px;
        }
        .style4
        {
            height: 23px;
        }
        .style5
        {
            height: 62px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Escolha seu novo usuário:</h1>
        <hr />
        <div style="position: relative; width: 36px; top: -65px; left: 483px; height: 18px;">
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/logout.aspx">Sair</asp:HyperLink></div>
    </div>
    <table class="style1">
        <tr>
            <td class="style5" align="left" colspan="2">
                <h3>Cuidado ao escolher o novo usuário! <font color="red">Esta operação é irreversível.</font> </h3></td>
        </tr>
        <tr>
            <td class="style2" align="right">
                Usuário Atual:</td>
            <td>
                <asp:TextBox ID="txtUsuarioAtual" runat="server" Width="250px" 
                    BackColor="#BFC098" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style2" align="right">
                Novo Usuário:</td>
            <td>
                <asp:TextBox ID="txtNovoUsuario" runat="server" Width="250px" MaxLength="45"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvNovoUsuario" runat="server" 
                    ControlToValidate="txtNovoUsuario" ErrorMessage="Informe o novo Usuário" 
                    ForeColor="Red">*</asp:RequiredFieldValidator>
                <asp:CompareValidator ID="CompareValidator1" runat="server" 
                    ControlToCompare="txtNovoUsuario" ControlToValidate="txtConfirmaNovoUsuario" 
                    ErrorMessage="Os campos não estão iguais." ForeColor="Red">*</asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td class="style2" align="right">
                Confirme Novo Usuário:</td>
            <td>
                <asp:TextBox ID="txtConfirmaNovoUsuario" runat="server" Width="250px" 
                    MaxLength="45"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvNovoUsuario0" runat="server" 
                    ControlToValidate="txtConfirmaNovoUsuario" 
                    ErrorMessage="Confirme o novo Usuário" ForeColor="Red">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style3" align="right">
            </td>
            <td class="style4">
                <asp:Button ID="btnEnviar" runat="server" Text="Enviar" 
                    onclick="btnEnviar_Click" Width="69px" />
            &nbsp;</td>
        </tr>
        <tr>
            <td class="style3" align="right">
                </td>
            <td class="style4">
                <asp:Button ID="btnContinuar" runat="server" onclick="btnContinuar_Click" 
                    Text="Continuar &gt;&gt;" Visible="False" />
&nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td>
                <asp:Label ID="lblMensagem" runat="server" ForeColor="Red"></asp:Label>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
