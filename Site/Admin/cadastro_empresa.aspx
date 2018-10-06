<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="cadastro_empresa.aspx.cs" Inherits="cadastro_empresa" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
   

    <script type="text/javascript" language="javascript">
        function ConfirmaExclusao() {            
            return confirm("Deseja realmente excluir este Banner?");
        }
   
        function ConfirmaExclusaoDivisao() {
            return confirm("Deseja realmente excluir este registro?");
        }
    </script> 
        
    <style type="text/css">
        .style1
        {
        }
        .style2
        {
            width: 469px;
            margin-left: 40px;
        }
        .Painel {
        }
               
        
        .style4
        {
            width: 151px;
            height: 27px;
        }
        .style5
        {
            width: 469px;
            height: 27px;
        }
       
        
        .style9
        {
            width: 151px;
        }
       
        
        .style10
        {
            width: 151px;
            height: 3px;
        }
        .style11
        {
            width: 469px;
            margin-left: 40px;
            height: 3px;
        }
       
        
        .style12
        {
            width: 151px;
            height: 40px;
        }
        .style13
        {
            width: 469px;
            margin-left: 40px;
            height: 40px;
        }
       
        
        .style14
        {
            width: 218px;
        }
       
        
        .style15
        {
            width: 137px;
        }
       
        
        .gridView
        {
            position: relative;
            left: 25px;
            top: 9px;
        }
       
        
        .style16
        {
            height: 22px;
        }
               
        
        .style17
    {
        width: 151px;
        height: 23px;
    }
    .style18
    {
        width: 469px;
        margin-left: 40px;
        height: 23px;
    }
               
        
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="subMenu" 
        style="position:relative; top: 9px; left: 10px; width: 633px;">
        <asp:Button ID="btnCadastro" runat="server" Text="Cadastro" Height="36px" 
            Width="120px" onclick="btnCadastro_Click" CausesValidation="False" 
            Enabled="False" />
        <asp:Button ID="btnSubDivisoes" runat="server" Text="Sub Divisões" 
            Height="36px" Width="120px" onclick="btnSubDivisoes_Click" 
            CausesValidation="False" />
        <asp:Button ID="btnFotos" runat="server" Text="Fotos" Height="36px" 
            Width="120px" onclick="btnFotos_Click" CausesValidation="False" />

        &nbsp;<asp:Button ID="btnEnviar" runat="server" Height="36px" 
            onclick="btnEnviar_Click" Text="Enviar" Width="93px" 
            CausesValidation="False" Font-Bold="True" ForeColor="Blue" />

        <asp:Button ID="btnNovoRegistro" runat="server" Height="36px" 
            onclick="btnNovoRegistro_Click" Text="Novo Registro" Width="120px" 
            CausesValidation="False" Font-Bold="True" ForeColor="Red" />

    </div>
    <div style="position:relative; top: -30px; left: 616px; width: 431px; height: 36px;">
        
        <asp:Label ID="lblMensagem" runat="server" ForeColor="Red"></asp:Label>
    </div>
    <asp:Panel ID="pnlCadastro" runat="server">
    
    <table style="width:800px; position: relative; top: 5px; left: 21px;">
        <tr>
            <td align="right" class="style10">
                Usuário:</td>
            <td class="style11">
                <asp:TextBox ID="txtUsuario" runat="server" BackColor="#BFC098" ReadOnly="True"></asp:TextBox>
                
            </td>
        </tr>
        <tr>
            <td align="right" class="style9">
                Nome Primário:</td>
            <td class="style2">
                <asp:TextBox ID="txtNomePrimario" runat="server" Width="450px" MaxLength="45"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" class="style9">
                Nome Secundário:</td>
            <td class="style2">
                <asp:TextBox ID="txtNomeSecundario" runat="server" Width="450px" MaxLength="45"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" class="style17">
                <strong>Auto Complete:</strong></td>
            <td class="style18">
                <asp:TextBox ID="txtAutoCompelte" runat="server" MaxLength="90" Width="450px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" class="style9">
                Endereço:</td>
            <td class="style2">
                <asp:TextBox ID="txtEndereco" runat="server" MaxLength="100" Width="450px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" class="style9">
                Bairro:</td>
            <td class="style2">
                <asp:TextBox ID="txtBairro" runat="server" Width="244px" MaxLength="45"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" class="style9">
                Cidade:</td>
            <td class="style2">
                <asp:DropDownList ID="dpdCidade" runat="server">
                    <asp:ListItem Value="1">Luziânia</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="right" class="style4">
                CEP:</td>
            <td class="style5">
                <asp:TextBox ID="txtCEP" runat="server" MaxLength="9"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" class="style4">
                Estado:</td>
            <td class="style5">
                <asp:DropDownList ID="dpdEstado" runat="server">
                    <asp:ListItem>GO</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="right" class="style9">
                CNPJ:</td>
            <td class="style2">
                <asp:TextBox ID="txtCNPJ" runat="server" MaxLength="20"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" class="style9">
                Telefone 01:</td>
            <td class="style2">
                <asp:TextBox ID="txtTelefone1" runat="server" MaxLength="15"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" class="style9">
                Telefone 02:</td>
            <td class="style2">
                <asp:TextBox ID="txtTelefone2" runat="server" MaxLength="15"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" class="style9">
                Telefone 03:</td>
            <td class="style2">
                <asp:TextBox ID="txtTelefone3" runat="server" MaxLength="15"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" class="style9">
                Telefone 04:</td>
            <td class="style2">
                <asp:TextBox ID="txtTelefone4" runat="server" MaxLength="15"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" class="style9">
                E-mail:</td>
            <td class="style2">
                <asp:TextBox ID="txtEmail" runat="server" Width="450px" MaxLength="80"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" class="style9">
                Site:</td>
            <td class="style2">
                <asp:TextBox ID="txtSite" runat="server" Width="450px" MaxLength="80"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" class="style12" valign="top">
                Palavras-Comercial:</td>
            <td class="style13">
                <asp:TextBox ID="txtPalavrasComercial" runat="server" TextMode="MultiLine" 
                    Width="450px" MaxLength="255" Height="150px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" class="style9">
                Data do Cadastro:</td>
            <td class="style2">
                <asp:TextBox ID="txtDataCadastro" runat="server" BackColor="#BFC098" 
                    ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" class="style9">
                <asp:Label ID="lblAtivo" runat="server" Text="Ativo:"></asp:Label>
            </td>
            <td class="style2">
                <asp:RadioButtonList ID="rblAtivo" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Value="0">Não</asp:ListItem>
                    <asp:ListItem Selected="True" Value="1">Sim</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td align="right" class="style9">
                <asp:Label ID="lblPrioridade" runat="server" Text="Prioridade"></asp:Label>
            </td>
            <td class="style2">
                <asp:RadioButtonList ID="rblPrioridade" runat="server" 
                    RepeatDirection="Horizontal">
                    <asp:ListItem Selected="True">0</asp:ListItem>
                    <asp:ListItem>1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                    <asp:ListItem>4</asp:ListItem>
                    <asp:ListItem>5</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td align="right" class="style9" valign="top">
                <asp:Label ID="lblConc" runat="server" Text="Concorrentes:"></asp:Label>
            </td>
            <td class="style2">
                <asp:TextBox ID="txtRamoAtividade" runat="server" Height="150px" 
                    MaxLength="255" TextMode="MultiLine" Width="450px"></asp:TextBox>
            </td>
        </tr>
    </table>
   
     </asp:Panel>
    <asp:Panel ID="pnlSubDivisoes" runat="server" Visible="False">
       
        <table width="60%" style="position:relative; top: 0px; left: 22px;">
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td align="left">
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="right">
                    SubDivisão 01:</td>
                <td>
                    <asp:TextBox ID="txtSubDivisao1" runat="server" Width="235px" MaxLength="45"></asp:TextBox>
                </td>
                <td align="right">
                    SubDivisão 04:</td>
                <td>
                    <asp:TextBox ID="txtSubDivisao4" runat="server" Width="235px" MaxLength="45"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right">
                    Site</td>
                <td>
                    <asp:TextBox ID="txtSiteSubDivisao1" runat="server" Width="235px" 
                        MaxLength="80"></asp:TextBox>
                </td>
                <td align="right">
                    Site:</td>
                <td>
                    <asp:TextBox ID="txtSiteSubDivisao4" runat="server" Width="235px" 
                        MaxLength="80"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" class="style16">
                    Telefone:</td>
                <td class="style16">
                    <asp:TextBox ID="txtTelefoneSubDivisao1" runat="server" MaxLength="45" 
                        Width="235px"></asp:TextBox>
                </td>
                <td align="right" class="style16">
                    Telefone:</td>
                <td class="style16">
                    <asp:TextBox ID="txtTelefoneSubDivisao4" runat="server" MaxLength="45" 
                        Width="235px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right">
                    Atividades:</td>
                <td>
                    <asp:TextBox ID="txtAtividadesSubDivisao1" runat="server" Width="235px" 
                        MaxLength="45"></asp:TextBox>
                </td>
                <td align="right">
                    Atividades:</td>
                <td>
                    <asp:TextBox ID="txtAtividadesSubDivisao4" runat="server" Width="235px" 
                        MaxLength="45"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td align="right">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="right">
                    SubDivisão 02:</td>
                <td>
                    <asp:TextBox ID="txtSubDivisao2" runat="server" Width="235px" MaxLength="45"></asp:TextBox>
                </td>
                <td align="right">
                    SubDivisão 05:</td>
                <td>
                    <asp:TextBox ID="txtSubDivisao5" runat="server" Width="235px" MaxLength="45"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right">
                    Site:</td>
                <td>
                    <asp:TextBox ID="txtSiteSubDivisao2" runat="server" Width="235px" 
                        MaxLength="80"></asp:TextBox>
                </td>
                <td align="right">
                    Site:</td>
                <td>
                    <asp:TextBox ID="txtSiteSubDivisao5" runat="server" Width="235px" 
                        MaxLength="80"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right">
                    Telefone:</td>
                <td>
                    <asp:TextBox ID="txtTelefoneSubDivisao2" runat="server" MaxLength="45" 
                        Width="235px"></asp:TextBox>
                </td>
                <td align="right">
                    Telefone:</td>
                <td>
                    <asp:TextBox ID="txtTelefoneSubDivisao5" runat="server" MaxLength="45" 
                        Width="235px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right">
                    Atividades:</td>
                <td>
                    <asp:TextBox ID="txtAtividadesSubDivisao2" runat="server" Width="235px" 
                        MaxLength="45"></asp:TextBox>
                </td>
                <td align="right">
                    Atividades:</td>
                <td>
                    <asp:TextBox ID="txtAtividadesSubDivisao5" runat="server" Width="235px" 
                        MaxLength="45"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td align="right">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="right">
                    SubDivisão 03:</td>
                <td>
                    <asp:TextBox ID="txtSubDivisao3" runat="server" Width="235px" MaxLength="45"></asp:TextBox>
                </td>
                <td align="right">
                    SubDivisão 06:</td>
                <td>
                    <asp:TextBox ID="txtSubDivisao6" runat="server" Width="235px" MaxLength="45"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right">
                    Site:</td>
                <td>
                    <asp:TextBox ID="txtSiteSubDivisao3" runat="server" Width="235px" 
                        MaxLength="80"></asp:TextBox>
                </td>
                <td align="right">
                    Site:</td>
                <td>
                    <asp:TextBox ID="txtSiteSubDivisao6" runat="server" Width="235px" 
                        MaxLength="80"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right">
                    Telefone:</td>
                <td>
                    <asp:TextBox ID="txtTelefoneSubDivisao3" runat="server" MaxLength="45" 
                        Width="235px"></asp:TextBox>
                </td>
                <td align="right">
                    Telefone:</td>
                <td>
                    <asp:TextBox ID="txtTelefoneSubDivisao6" runat="server" MaxLength="45" 
                        Width="235px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right">
                    Atividades:</td>
                <td>
                    <asp:TextBox ID="txtAtividadesSubDivisao3" runat="server" Width="235px" 
                        MaxLength="45"></asp:TextBox>
                </td>
                <td align="right">
                    Atividades:</td>
                <td>
                    <asp:TextBox ID="txtAtividadesSubDivisao6" runat="server" Width="235px" 
                        MaxLength="45"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
       
        <br />
        <br />
        <br />
    </asp:Panel>
    <asp:Panel ID="pnlFoto" runat="server" Visible="False">
        <br />
        <br />
       
        <table style="width:679px;" align="center">
            <tr>
                <td align="right">
                    Banner 1:</td>
                <td class="style14">
                    <asp:FileUpload ID="fupBanner1" runat="server" />
                </td>
                <td class="style15">
                    <asp:Button ID="bntEnviarBanner1" runat="server" 
                        onclick="bntEnviarBanner1_Click" Text="Enviar Banner 01" Width="140px" />
                </td>
                <td>
                    <asp:Button ID="btnExcluir1" runat="server" onclick="btnExcluir1_Click1" 
                        onclientclick="javascript:return ConfirmaExclusao();" Text="Excluir" />
                </td>
            </tr>
            <tr>
                <td align="right">
                    Banner 2:</td>
                <td class="style14">
                    <asp:FileUpload ID="fupBanner2" runat="server" />
                </td>
                <td class="style15">
                    <asp:Button ID="bntEnviarBanner2" runat="server" 
                        onclick="bntEnviarBanner2_Click" Text="Enviar Banner 02" Width="140px" />
                </td>
                <td>
                    <asp:Button ID="btnExcluir2" runat="server" onclick="btnExcluir2_Click" 
                        onclientclick="javascript:return ConfirmaExclusao();" Text="Excluir" />
                </td>
            </tr>
            <tr>
                <td align="right">
                    Banner 3:</td>
                <td class="style14">
                    <asp:FileUpload ID="fupBanner3" runat="server" />
                </td>
                <td class="style15">
                    <asp:Button ID="bntEnviarBanner3" runat="server" 
                        onclick="bntEnviarBanner3_Click" Text="Enviar Banner 03" Width="140px" />
                </td>
                <td>
                    <asp:Button ID="btnExcluir3" runat="server" onclick="btnExcluir3_Click" 
                        onclientclick="javascript:return ConfirmaExclusao();" Text="Excluir" />
                </td>
            </tr>
            <tr>
                <td align="right">
                    Banner 4:</td>
                <td class="style14">
                    <asp:FileUpload ID="fupBanner4" runat="server" />
                </td>
                <td class="style15">
                    <asp:Button ID="bntEnviarBanner4" runat="server" 
                        onclick="bntEnviarBanner4_Click" Text="Enviar Banner 04" Width="140px" />
                </td>
                <td>
                    <asp:Button ID="btnExcluir4" runat="server" onclick="btnExcluir4_Click" 
                        onclientclick="javascript:return ConfirmaExclusao();" Text="Excluir" />
                </td>
            </tr>
        </table>
        
        <table align="center" style="border: 2px solid #666666">
            <tr><td align="center" style="border: 1px solid #666666">Banner 01:</td>
                <td align="center" style="border: 1px solid #666666">Banner 02:</td></tr>
            <tr>
                <td style="border: 1px solid #666666">
                    <asp:Panel ID="pnl_Banner1" runat="server" CssClass="Painel" Height="210px" HorizontalAlign="Center" 
                        ScrollBars="Both" Width="410px">
                        <br />
                        <asp:Image ID="imgBanner1" runat="server" Height="200px" />
                    </asp:Panel>
                </td>
                <td style="border: 1px solid #666666">
                    <asp:Panel ID="pnl_Banner2" runat="server" CssClass="Painel" Height="210px" HorizontalAlign="Center" 
                        ScrollBars="Both" Width="410px">
                        <asp:Image ID="imgBanner2" runat="server" Height="200px" />
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td align="center" style="border: 1px solid #666666">
                    Banner 03:</td>
                <td align="center" style="border: 1px solid #666666">
                    Banner 04:</td>
            </tr>
            <tr>
                <td style="border: 1px solid #666666">
                    <asp:Panel ID="pnl_Banner3" runat="server" CssClass="Painel" Height="210px" 
                        HorizontalAlign="Center" ScrollBars="Both" Width="410px">
                        <asp:Image ID="imgBanner3" runat="server" Height="200px" />
                    </asp:Panel>
                </td>
                <td style="border: 1px solid #666666">
                    <asp:Panel ID="pnl_Banner4" runat="server" CssClass="Painel" Height="210px" 
                        HorizontalAlign="Center" ScrollBars="Both" Width="410px">
                        <asp:Image ID="imgBanner4" runat="server" Height="200px" />
                    </asp:Panel>
                </td>
            </tr>
        </table>
        <br />
    </asp:Panel>
    <asp:Panel ID="pnlCutImagem" runat="server" Visible="False">
        <br />
        <br />
        <br />
        <div align="center">
        <asp:Image CssClass="cropbox" ID="imgCorte" runat="server" />
        <asp:HiddenField ID="txtX" runat="server" />
        <asp:HiddenField ID="txtY" runat="server" />
        <asp:HiddenField ID="txtW" runat="server" />
        <asp:HiddenField ID="txtH" runat="server" />
        <br />
        <asp:Button ID="btnSalvarRecorte" runat="server" Text="Usar Recorte" Width="123px" 
                onclick="btnSalvarRecorte_Click" Height="38px" />
        &nbsp;<asp:Button ID="btnUsarOriginal" runat="server" Text="Usar Original" 
                Width="123px" Height="38px" onclick="btnUsarOriginal_Click" />
        </div>
    </asp:Panel>
    <br /><br /><br />
</asp:Content>

