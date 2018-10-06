<%@ Page Title="" Language="C#" MasterPageFile="~/mpIndex.master" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

<script src="jquery-1.9.1.js" type="text/javascript"></script>
     
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
     function validate() {   //pesquisa
         if (document.getElementById("<%=txtPesquisa.ClientID%>").value == "") {
             alert("Informe conteúdo da pesquisa.");
             document.getElementById("<%=txtPesquisa.ClientID%>").focus();
             return false;
         }
     }

     if (screen.height == 600) {
         location.href = "mode800x600/index.aspx";
     }


    </script>
   
    <style type="text/css">
       
        .txtPesquisa 
        {
            border: 1px solid #999999;
            outline:none;
            height: 27px;
            width: 525px;
            padding-left: 8px;
            z-index:1;
            font-size:16px;
        }
        .R
        {
            position:absolute; 
            height:17px; 
            width:22px; 
            top: 319px; 
            left: 917px;
            z-index:2;
        }
        
        .style1
        {
            color: #808080;
            font-size:13px;
        }
           
        body{ font-size:16px; font-family:Arial;}
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server" >
    
    
        <div id="btnEntrar" style=" position: absolute; right:10px; top:80px">
            <a href="Admin/login.aspx">Entrar no Sistema</a>
        </div>  
   
    <div align="center">
        <br />
        <br />
        <br />
        <img alt="Lista Bem" height="200" src="imagens/logo-com-mapa.jpg" />
        <br />
         <br />
         <br />
        <div>        
        <asp:ScriptManager ID="ScriptManager1" runat="server" 
        EnablePageMethods = "true">
        </asp:ScriptManager>

         
         <asp:TextBox ID="txtPesquisa" runat="server" CssClass="txtPesquisa"></asp:TextBox>
            <p class="R">®</p>
                
          
            <br />
            <br />
            <asp:Button ID="btnPesquisa" runat="server" 
            Height="40px" Text="Pesquisar" Width="146px"
            onclientclick="return validate()" onclick="btnPesquisa_Click" 
            ForeColor="#000066"/>
            <br />
            </div>

            <br />
            <br />
            <br />
            <br />
            <br />
            <br />      
            <br />
            <br />
            <br />
            <br />   
            <br />         
            <br />
            <br />
           <p align="center" class="style1">Sistemas Luziânia Online Host. 
Hospedagem de Sites em Luziânia.<br/> Todos os direitos reservados. <br />
www.listabem.com ®</p>
    </div>
 
</asp:Content>

