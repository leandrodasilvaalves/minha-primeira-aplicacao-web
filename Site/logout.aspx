<%@ Page Title="" Language="C#" MasterPageFile="~/mpIndex.master" AutoEventWireup="true" CodeFile="logout.aspx.cs" Inherits="logout" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .logo
       {
           height:100px;
           position:absolute;
           top: 51px;
           left: 48px;
        }
        #EntrarNovamente  a:link
        {
            font-family: Arial, Helvetica, sans-serif;
            padding: 10px;
            background-color: #0066FF;
            font-weight: bold;
            color: #FFFFFF;
            text-decoration: none;
            border: 1px solid #666666;
            width: 150px;
        }
       #EntrarNovamente a:visited
        {
            font-family: Arial, Helvetica, sans-serif;
            padding: 10px;
            background-color:  #0066FF;
            font-weight: bold;
            color: #FFFFFF;
            text-decoration: none;
            border: 1px solid #666666;
            width: 150px;
        }
        #EntrarNovamente a:active
        {
           font-family: Arial, Helvetica, sans-serif;
            padding: 10px;
            background-color:  #0066FF;
            font-weight: bold;
            color: #FFFFFF;
            text-decoration: none;
            border: 1px solid #666666;
            width: 150px;
        }
        #EntrarNovamente a:hover
        {
            font-family: Arial, Helvetica, sans-serif;
            padding: 10px;
            background-color: #3399FF;
            font-weight: bold;
            color: #FFFFFF;
            text-decoration: none;
            border: 1px solid #666666;
            width: 150px;
        }
        
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <a href="index.aspx"><img src="imagens/logo-com-mapa2.jpg" class="logo" /></a>

   
    <div style=" position:absolute; height:350px; top: 225px; left: 48px;">
     <h2>Logout - você saiu do sistema.</h2>
       
            <table id="EntrarNovamente">
                <tr>
                    <td><asp:HyperLink ID="hplEntrar" runat="server" NavigateUrl="~/Admin/login.aspx">Entrar Novamente</asp:HyperLink></td>
                    <td><asp:HyperLink ID="hplHome" runat="server" NavigateUrl="~/index.aspx">Ir para a Home Page</asp:HyperLink></td>
                </tr>
            </table>
    </div>
</asp:Content>

