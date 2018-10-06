<%@ Page Title="" Language="C#" MasterPageFile="~/mpIndex.master" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="Admin_login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        #Content2
        {
            position:absolute;
            top:250px;
        }
       .tabela
       {
           position:absolute; 
           top: 194px; 
           left: 116px;
       }
       .divMensagens
       {
           position:absolute; 
           top: 323px; 
           left: 116px;
       }
       .logo
       {
           height:100px;
           position:absolute;
           top: 71px;
           left: 116px;
        }
        
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   <div style="height:90%; width:100%;">
   <a href="../index.aspx"><img src="../imagens/logo-com-mapa2.jpg" class="logo" /></a>
    <table class="tabela">
        <tr>
            <td>Usuário</td>
            <td >
                <asp:TextBox ID="txtUsuario" runat="server" Width="200px" MaxLength="45"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfvUsuario" runat="server" 
                    ControlToValidate="txtUsuario" ErrorMessage="Informe o usuário" ForeColor="Red">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Senha</td>
            <td"></td>
            <td>
                <asp:TextBox ID="txtSenha" runat="server" MaxLength="16" Width="200px" 
                    TextMode="Password"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfvSenha" runat="server" 
                    ControlToValidate="txtSenha" ErrorMessage="Informe a senha" ForeColor="Red">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:Button ID="btnEntrar" runat="server" Text="Entrar" 
                    onclick="btnEntrar_Click" />
            </td>
            <td></td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:HyperLink ID="hplSenha" runat="server" NavigateUrl="~/recupera_senha.aspx">Esqueci minha senha</asp:HyperLink>
            </td>
            <td></td>
        </tr>
        </table>
        <div class="divMensagens">
            <asp:Label ID="lblMensagem" runat="server" ForeColor="Red"></asp:Label>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
        </div>
    </div>
    <br />
    <br />
    <br />
    <br />
    <br />
    </asp:Content>

