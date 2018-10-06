<%@ Page Title="" Language="C#" MasterPageFile="~/mode800x600/mpIndex.master" AutoEventWireup="true" CodeFile="pesquisa.aspx.cs" Inherits="mode800x600_pesquisa" %>
<%@ PreviousPageType VirtualPath="~/mode800x600/index.aspx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
      <script language="javascript" type="text/javascript">
          function validate() {   //pesquisa
              if (document.getElementById("<%=txtPesquisa.ClientID%>").value == "") {
                  alert("Informe conteúdo da pesquisa.");
                  document.getElementById("<%=txtPesquisa.ClientID%>").focus();
                  return false;
              }
          }
    </script>
     <style type="text/css">
       
         .btnPesquisa
        {
             position: relative;
             top: 23px;
             left: 348px;
         }
        .tblPesquisa
        {
            position:relative;
            left:153px;
            top: -1px;
            height: 24px;
            width: 27px;
         }
        .pnlPaginas
        {
           position:relative;           
           left:165px;
           top: 5px;
         }
         .lblMensagem
         {
           position:absolute;        
           left:155px;
             top: 68px;
         }
         
        .divPesquisa
        {
            border: 1px solid #999999;
            height: 27px;
            width: 515px;
            background-color: #FFFFFF;
        }
        
        .divPesquisa
        {
            border: 1px solid #999999;
            height: 27px;
            width: 315px;
            background-color: #FFFFFF;
            position:absolute;
            top:24px;
            left: 152px;
         }
        
        .txtPesquisa 
        {
            border: 1px none #999999;
            outline:none;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="btnEntrar" style="position:absolute;top:28px; left: 658px;"><a href="../Admin/login.aspx">Entrar</a></div>
    <div class="DivPesquisaCinza">
        <a href="index.aspx"><img alt="Lista Bem" 
            src="../imagens/logo-com-mapa2.jpg"            
            style=" position:relative; border-style: none; height: 52px; width: 99px; top: 4px; left: 37px;"/></a>
            <div class="divPesquisa" align="right">
            <asp:TextBox ID="txtPesquisa" runat="server" CssClass="txtPesquisa" Width="300px"></asp:TextBox>
                </div>
        <asp:Button ID="Button1" runat="server" Height="30px" Text="Pesquisa Lista Bem" 
            Width="146px" CssClass="btnPesquisa" onclick="Button1_Click" 
            onclientclick="return validate()" />
        
        
        <asp:Label ID="lblMensagem" runat="server" CssClass="lblMensagem" 
            Font-Size="Small" ForeColor="#666666"></asp:Label>
    </div>
    
    <br />
    <asp:Table ID="tblPesquisa" runat="server" CssClass="tblPesquisa" Width="600px">
        </asp:Table>
        
        <br />
        <a href="index.aspx"></a> 
        <asp:Panel ID="pnlPaginas" runat="server" Width="350px" 
            CssClass="pnlPaginas" HorizontalAlign="Center">
        </asp:Panel>
    <asp:HiddenField ID="hdfPesquisa" runat="server" />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
     <p align="center" 
        style=" font-size:x-small; width: 350px; position:relative; left:169px; top: -99px;">Sistemas Luziânia Online todo os direitos reservados
           <br /> Hospedagem de Sites em Luziânia
            <br />www.listabem.com<br />
    </p>
</asp:Content>

