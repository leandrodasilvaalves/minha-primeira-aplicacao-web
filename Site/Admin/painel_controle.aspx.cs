using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Data;
using System.Text;
using System.Web.Services;
using BLL;
using USER;
using EMP;
using MsgBox; 

public partial class painel_controle : System.Web.UI.Page
{
    BLL.classeBLL bll;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.User.Identity.Name.ToString() != "admin"
            || Session["Usuario"].ToString() !="admin")//se não for admin fecha a seção e redireciona para o login
        {
            Session.Abandon();
            FormsAuthentication.SignOut();
            Response.Redirect("index.aspx");
        }
        lblMensagem.Text = "";
       
        if(!IsPostBack)
            ListarEmpresas();
                
    }  
    protected void btnIncluir_Click1(object sender, EventArgs e)
    {
       bll = new classeBLL();
        try
        {           
            Usuario us = new Usuario();
            us = bll.GeraNovoUsuario();            
            lblMensagem.Text = "<b>Novo Usuário e nova Senha gerados com sucesso.</b>";
            ListarEmpresas();
        }
        catch (Exception ex)
        {
            bll.EnviarErros(ex.Message.ToString());
        }
    }
    protected void btnListar_Click(object sender, EventArgs e)
    {
        ListarEmpresas();
    }
    protected void ListarEmpresas()
    {
        bll = new classeBLL();
        try
        {
            gdvEmpresas.DataSource = bll.ListarEmpresas();
            gdvEmpresas.DataBind();
            
        }
        catch (Exception ex)
        {
           bll.EnviarErros(ex.Message.ToString());
        }
    }
    protected void ShowMessageBox(string Mensagem)
    {
        string csname1 = "PopupScript";
        Type cstype = this.GetType();
        ClientScriptManager cs = Page.ClientScript;
        if (!cs.IsStartupScriptRegistered(cstype, csname1))
        {
            String cstext1 = "alert('" + Mensagem + "');";
            cs.RegisterStartupScript(cstype, csname1, cstext1, true);
        }
    }
    protected void gdvEmpresas_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        
        if (e.CommandName == "Alterar")
        {
            try
            {   
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow rw = gdvEmpresas.Rows[index];
                string Usuario = Server.HtmlDecode(rw.Cells[3].Text);
                Session["CarregaUsuario"] = Usuario;
                Response.Redirect("cadastro_empresa.aspx");                
            }
            catch (Exception ex)
            {
                bll = new BLL.classeBLL();
                bll.EnviarErros(ex.Message.ToString());
            }

        }
        
    }
    protected void gdvEmpresas_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        bll = new BLL.classeBLL();
        try
        {
            EMP.Empresa emp = new Empresa();           
            string Usuario = gdvEmpresas.DataKeys[e.RowIndex].Value.ToString();
            emp.Usuario = Usuario;
            bll.ExcluiEmpresa(emp);
            ListarEmpresas();
        }
        catch (Exception ex)
        {
            bll.EnviarErros(ex.Message.ToString());
        }
    }
    protected void btnPesquisar_Click(object sender, EventArgs e)
    {
        bll = new BLL.classeBLL();
        try
        {
            int op = int.Parse(dpdPesquisar.SelectedValue.ToString());            
            gdvEmpresas.DataSource = bll.SelecionaEmpresa_pnl_Control(txtPesquisar.Text.ToString(), op);
            gdvEmpresas.DataBind();
            if (gdvEmpresas.Rows.Count <= 0)
                lblMensagem.Text = "Nenhum resultado foi encontrado para sua busca: <b><u>" + txtPesquisar.Text + "</u></b>."; 

        }
        catch (Exception ex)
        {
            bll.EnviarErros(ex.Message.ToString());
        }
    }
    protected void gdvEmpresas_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gdvEmpresas.PageIndex = e.NewPageIndex;
        ListarEmpresas();

    }    
    protected void gdvEmpresas_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            switch (e.Row.Cells[8].Text) //modifica os valores do campo "Ativo"
            {
                case "0": 
                    e.Row.BackColor = System.Drawing.ColorTranslator.FromHtml("#FCD5B4");
                    e.Row.Cells[8].Text = "Não";
                    break;
                case "1":
                    e.Row.Cells[8].Text = "Sim";
                    break;
            }
        }
    }
}
   