<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="painel_controle.aspx.cs" Inherits="painel_controle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    
    <script language="javascript">
        function ConfirmaExclusao() {
            return confirm("Deseja realmente excluir este registro?");
        }
        $(document).ready(function () {
            $("#styleBanners").fancybox(
      {
          'titleShow': false
      });
        });
    </script>    
    
    <style type="text/css">
        .fonteGridView
        {
            font-size:15px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    <br />
    <br />
    <div style="position:relative; top: -43px; left: 69px;">
        <asp:Label ID="Label1" runat="server" Text="Pesquisar"></asp:Label>
    &nbsp;Por:
        <asp:DropDownList ID="dpdPesquisar" runat="server">
            <asp:ListItem Selected="True" Value="0">Todos os Campos</asp:ListItem>
            <asp:ListItem Value="1">Usuario</asp:ListItem>
            <asp:ListItem Value="2">Nome Primário</asp:ListItem>
            <asp:ListItem Value="3">Nome Secundário</asp:ListItem>
            <asp:ListItem Value="4">Prioridade</asp:ListItem>
        </asp:DropDownList>
    <asp:Label ID="lblMensagem" runat="server" ForeColor="Red"></asp:Label>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Procurar: "></asp:Label>
&nbsp;<asp:TextBox ID="txtPesquisar" runat="server" Width="316px"></asp:TextBox>
&nbsp;<asp:Button ID="btnPesquisar" runat="server" Text="Pesquisar" 
            onclick="btnPesquisar_Click" Height="26px" />
    &nbsp;<asp:Button ID="btnListar" runat="server" Font-Bold="False" Height="26px" 
            onclick="btnListar_Click" Text="Listar Empresas" Width="133px" />


        <asp:Button ID="btnIncluir" runat="server" Font-Bold="True" Height="26px" 
            onclick="btnIncluir_Click1" Text="Novo Registro" Width="128px" 
            ForeColor="Red" />
        


    </div>
    <div style=" position:relative; top: -31px; left: 71px;">
                <asp:GridView ID="gdvEmpresas" runat="server" CssClass="fonteGridView" 
                    CellPadding="4" ForeColor="#333333" 
                    AutoGenerateColumns="False" onrowdeleting="gdvEmpresas_RowDeleting" 
                    DataKeyNames="Usuario" AllowPaging="True" 
                    onpageindexchanging="gdvEmpresas_PageIndexChanging" PageSize="25" 
                    onrowdatabound="gdvEmpresas_RowDataBound" 
                    onrowcommand="gdvEmpresas_RowCommand" ShowHeaderWhenEmpty="True" >
                    <AlternatingRowStyle Wrap="False" BackColor="White" />
                    <Columns>
                        <asp:ButtonField CommandName="Alterar" Text="Alterar" 
                            HeaderText="Alterar" >
                        <ControlStyle ForeColor="#0000EE" />
<ControlStyle ForeColor="#0000EE"></ControlStyle>
                        </asp:ButtonField>
                        <asp:TemplateField HeaderText="Excluir" ShowHeader="False">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkDelete" runat="server" CausesValidation="False" 
                                    CommandName="Delete" onclientclick="javascript:return ConfirmaExclusao();" 
                                    Text="Excluir"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="ID" HeaderText="ID" Visible="False" />
                        <asp:BoundField DataField="Usuario" HeaderText="Usuario" />
                        <asp:BoundField DataField="Senha" HeaderText="Senha" />
                        <asp:BoundField DataField="NomePrimario" HeaderText="Nome Primário" >
                        <ControlStyle Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="NomeSecundario" HeaderText="Nome Secundário" />
                        <asp:BoundField DataField="Prioridade" HeaderText="Prior" />
                        <asp:BoundField DataField="Ativo" HeaderText="Ativo" />
                    </Columns>
                    <EditRowStyle Wrap="False" BackColor="#2461BF" />
                    <EmptyDataRowStyle Wrap="False" />
                    <FooterStyle Wrap="False" BackColor="#507CD1" Font-Bold="True" 
                        ForeColor="White" />
                    <HeaderStyle Wrap="False" BackColor="#507CD1" Font-Bold="True" 
                        ForeColor="White" />
                    <PagerStyle Wrap="False" BackColor="#2461BF" ForeColor="White" 
                        HorizontalAlign="Center" />
                    <RowStyle Wrap="False" BackColor="#EFF3FB" />
                    <SelectedRowStyle Wrap="False" BackColor="#D1DDF1" Font-Bold="True" 
                        ForeColor="#333333" />
                    <SortedAscendingCellStyle Wrap="False" BackColor="#F5F7FB" />
                    <SortedAscendingHeaderStyle Wrap="False" BackColor="#6D95E1" />
                    <SortedDescendingCellStyle Wrap="False" BackColor="#E9EBEF" />
                    <SortedDescendingHeaderStyle Wrap="False" BackColor="#4870BE" />

<SortedAscendingCellStyle Wrap="False" BackColor="#F5F7FB"></SortedAscendingCellStyle>

<SortedAscendingHeaderStyle Wrap="False" BackColor="#6D95E1"></SortedAscendingHeaderStyle>

<SortedDescendingCellStyle Wrap="False" BackColor="#E9EBEF"></SortedDescendingCellStyle>

<SortedDescendingHeaderStyle Wrap="False" BackColor="#4870BE"></SortedDescendingHeaderStyle>
                </asp:GridView>
            </div>
    
</asp:Content>

