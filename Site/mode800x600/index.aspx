<%@ Page Title="" Language="C#" MasterPageFile="~/mode800x600/mpIndex.master" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="mode800x600_index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script language="javascript" type="text/javascript">
        function validate() {   //pesquisa
            if (document.getElementById("<%=txtPesquisa.ClientID%>").value == "") {
                alert("Informe conteúdo da pesquisa.");
                document.getElementById("<%=txtPesquisa.ClientID%>").focus();
                return false;
            }

        }


        if (screen.height > 600) {
            location.href = "../index.aspx";
        } 
    </script>
    
    <style type="text/css">
        .divPesquisa
        {
            border: 1px solid #999999;
            height: 27px;
            width: 415px;
            background-color: #FFFFFF;
        }
        
        .txtPesquisa 
        {
            border: 1px none #999999;
            outline:none;
            height:23px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
   
    <div align="center" 
        style="position: absolute; top: 2px; left: 0px; width: 730px;">
        <div id="btnEntrar" style=" position: absolute; right:-41px; top:27px;">
            <a href="../Admin/login.aspx">Entrar no Sistema</a>
        </div> 
        <br />
        <br />
        <img alt="Lista Bem" height="150" src="../imagens/logo-com-mapa.jpg" />
        <br />
         <br />
         <br />
         <div class="divPesquisa" align="right">
         <asp:TextBox ID="txtPesquisa" runat="server"
                Width="400px" CssClass="txtPesquisa"></asp:TextBox>
        </div>
               
            <br />
            <asp:Button ID="btnPesquisa" runat="server" 
            Height="30px" Text="Pesquisa Lista Bem" Width="146px"
            onclientclick="return validate()" onclick="btnPesquisa_Click" />
            <br />
            <br />
            <br />
            
           <p align="center" style="font-size:x-small">Sistemas Luziânia Online. Todos os direitos são reservados. 
Hospedagem de Sites em Luziânia. 
www.listabem.com</p>
    </div>
 
</asp:Content>

