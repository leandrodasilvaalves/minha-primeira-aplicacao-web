<%@ Page Title="" Language="C#" MasterPageFile="~/mpIndex.master" AutoEventWireup="true" CodeFile="recupera_senha.aspx.cs" Inherits="recupera_senha" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .logo
       {
           height:100px;
        }
        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 173px;
        }
        .style3
        {
            width: 313px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   
    <table class="style1">
        <tr>
            <td class="style2">
                <a href="index.aspx"><img alt="LISTA BEM" src="imagens/logo-com-mapa2.jpg" class="logo" /></a></td>
            <td align="left" valign="middle" class="style3">
                <h2>Recuperação de Senha</h2></td>
            <td align="left" valign="middle">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="right" class="style2">
                Usuário:</td>
            <td class="style3">
                <asp:TextBox ID="txtUsuario" runat="server" Width="300px"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfvUsuario" runat="server" 
                    ControlToValidate="txtUsuario" ErrorMessage="Informe o usuário" ForeColor="Red">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td align="right" class="style2">
                E-mail:</td>
            <td class="style3">
                <asp:TextBox ID="txtEmail" runat="server" Width="300px"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfvEmail" runat="server" 
                    ControlToValidate="txtEmail" ErrorMessage="Informe o E-mail" ForeColor="Red">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td align="right" class="style2">
                CNPJ:</td>
            <td class="style3">
                <asp:TextBox ID="txtCNPJ" runat="server" Width="300px"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfvCNPJ" runat="server" 
                    ControlToValidate="txtCNPJ" ErrorMessage="Informe o CNPJ" ForeColor="Red">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style3">
                <asp:Button ID="btnEnviar" runat="server" onclick="btnEnviar_Click" 
                    style="font-style: italic" Text="Enviar" Width="93px" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style3">
                <asp:Label ID="lblMensagem" runat="server" ForeColor="Red"></asp:Label>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
&nbsp;
</asp:Content>

