<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="altera_senha.aspx.cs" Inherits="altera_senha" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
        <h2>Alterar sua senha </h2>
        <hr />
    </div>
    <table class="style1">
        <tr>
            <td class="style5" align="left" colspan="2">
                <h3>Uma senha forte ajuda a impedir o acesso não autorizado à sua conta.</h3></td>
        </tr>
        <tr>
            <td class="style2" align="right">
                Senha Atual:</td>
            <td align="left">
                <asp:TextBox ID="txtSenhaAtual" runat="server" Width="250px" 
                    TextMode="Password" MaxLength="8"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtSenhaAtual" ErrorMessage="Informe a senha atual." 
                    ForeColor="Red">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style2" align="right">
                Nova Senha:</td>
            <td align="left">
                <asp:TextBox ID="txtNovaSenha" runat="server" Width="250px" TextMode="Password" 
                    MaxLength="8"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvNovoUsuario" runat="server" 
                    ControlToValidate="txtNovaSenha" ErrorMessage="Informe a Nova Senha" 
                    ForeColor="Red">*</asp:RequiredFieldValidator>
                <asp:CompareValidator ID="CompareValidator1" runat="server" 
                    ControlToCompare="txtNovaSenha" ControlToValidate="txtConfirmaNovaSenha" 
                    ErrorMessage="Os campos não estão iguais." ForeColor="Red">*</asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td class="style2" align="right">
                Confirme a Nova Senha:</td>
            <td align="left">
                <asp:TextBox ID="txtConfirmaNovaSenha" runat="server" Width="250px" 
                    TextMode="Password" MaxLength="8"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvNovoUsuario0" runat="server" 
                    ControlToValidate="txtConfirmaNovaSenha" 
                    ErrorMessage="Confirme a Nova Senha" ForeColor="Red">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style3" align="right">
            </td>
            <td class="style4" align="left">
                <asp:Button ID="btnEnviar" runat="server" Text="Enviar" 
                    onclick="btnEnviar_Click" Width="69px" />
            </td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td>
                <asp:Label ID="lblMensagem" runat="server" ForeColor="Red"></asp:Label>
                <br />
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
            </td>
        </tr>
    </table>
</asp:Content>

