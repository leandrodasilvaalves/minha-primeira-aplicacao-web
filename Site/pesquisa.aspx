<%@ Page Title="" Language="C#" MasterPageFile="~/mpIndex.master" AutoEventWireup="true" CodeFile="pesquisa.aspx.cs" Inherits="_Pesquisa" %>
<%@ PreviousPageType VirtualPath="~/index.aspx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
  <link href="jquery-ui-1.10.3.custom.css" rel="stylesheet" type="text/css" />
    <script src="jquery-ui-1.10.3.custom.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            function log(message) {
                $("<div/>").text(message).prependTo("#log");
                $("#log").attr("scrollTop", 0);
            }

            $.ajax({
                url: "DataBase.xml",
                dataType: "xml",
                success: function (xmlResponse) {
                    var data = $("autocompletesource", xmlResponse).map(function () {
                        return {
                            value: $("item", this).text()
                        };
                    }).get();
                    $("#<%=txtPesquisa.ClientID%>").autocomplete({
                        source: data,
                        minLength: 3,
                        select: function (event, ui) {
                            log(ui.item ?
							"Selected: " + ui.item.value + ", geonameId: " + ui.item.id :
							"Nothing selected, input was " + this.value);
                        }
                    });
                }
            });
        });
    </script>

    
    <script language="javascript" type="text/javascript">
        function validate() 
        {   //pesquisa
            if (document.getElementById("<%=txtPesquisa.ClientID%>").value == "")
            {
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
             left: 569px;
             height: 33px;
         }
        .tblPesquisa
        {
            position:relative;
            left:164px;
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
           left:164px;
             top: 68px;
         }
              
         
        .txtPesquisa 
        {
            border: 1px solid #999999;
            outline:none;
            height: 27px;
            width: 525px;
            padding-left: 8px;
            z-index:1;
            font-size:16px;
            position:absolute;
             top: 24px;
             left: 162px;
         }
        .R
        {
            position:absolute; 
            height:14px; 
            width:22px; 
            top: 21px; 
            left: 667px;
            z-index:2;
        }
        
         .DivPesquisaCinza
        {
             border: 1px solid #C0C0C0;
             background-color: #EEEEEE;
             position: relative;
             width: 99.9%;
             height: 90px;
             top:0px;
             left: 0px;
         }
   
        body{ font-size:16px;}
    </style>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <div class="DivPesquisaCinza">
        <div id="btnEntrar" style=" position: absolute; right:10px; top:34px" ><a href="Admin/login.aspx">Entrar no Sistema</a></div>
        <a href="index.aspx"><img alt="Lista Bem" 
            src="imagens/logo-com-mapa2.jpg"            
            style=" position:relative; border-style: none; height: 48px; width: 109px; top: 4px; left: 37px;"/></a>
            <asp:TextBox ID="txtPesquisa" runat="server" CssClass="txtPesquisa"></asp:TextBox>
            <p class="R">®</p>

        <asp:Button ID="Button1" runat="server" Text="Pesquisa Lista Bem" 
            Width="146px" CssClass="btnPesquisa" onclick="Button1_Click" 
            onclientclick="return validate()" />
        
        
        <asp:Label ID="lblMensagem" runat="server" CssClass="lblMensagem" 
            Font-Size="Small" ForeColor="#666666"></asp:Label>
    </div>
    
    <br />
    <asp:Table ID="tblPesquisa" runat="server" CssClass="tblPesquisa" Width="700px">
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
        style="width: 350px; position:relative; left:169px; top: -99px; font-size:12px;">Sistemas Luziânia Online todo os direitos reservados
           <br /> Hospedagem de Sites em Luziânia
            <br />www.listabem.com<br />
    </p>
    </asp:Content>

