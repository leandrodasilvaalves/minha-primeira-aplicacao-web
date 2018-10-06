<%@ Page Title="" Language="C#" MasterPageFile="~/mpIndex.master" AutoEventWireup="true" CodeFile="contato.aspx.cs" Inherits="contato" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .logo
       {
           height:100px;
           position:absolute;
           top: 51px;
           left: 48px;
        }
        .tabela
        {
            position:absolute;
            top: 207px;
            left: 50px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <a href="index.aspx"><img src="imagens/logo-com-mapa2.jpg" class="logo" /></a>
    <table class="tabela">
        <tr>
            <td>Nome:</td>
            <td>
                <asp:TextBox ID="txtNome" runat="server" Width="400px"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfvNome" runat="server" 
                    ControlToValidate="txtNome" ErrorMessage="Informe o nome" ForeColor="Red">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Email:</td>
            <td>
                <asp:TextBox ID="txtEmail" runat="server" Width="400px"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfvEmail" runat="server" 
                    ControlToValidate="txtEmail" ErrorMessage="Informe o E-mail" ForeColor="Red">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Site:</td>
            <td>
                <asp:TextBox ID="txtSite" runat="server" Width="400px"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td valign="top">Mensagem:</td>
            <td>
                <asp:TextBox ID="txtMensagem" runat="server" Height="99px" TextMode="MultiLine" 
                    Width="400px"></asp:TextBox>
            </td>
            <td valign="top">
                <asp:RequiredFieldValidator ID="rfvMensagem" runat="server" 
                    ControlToValidate="txtMensagem" ErrorMessage="Digite a mensagem" 
                    ForeColor="Red">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:Button ID="btnEnviar" runat="server" Text="Enviar" Height="28px" 
                    Width="111px" onclick="btnEnviar_Click" /></td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Label ID="lblMensagem" runat="server" ForeColor="Red"></asp:Label>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>

</asp:Content>

