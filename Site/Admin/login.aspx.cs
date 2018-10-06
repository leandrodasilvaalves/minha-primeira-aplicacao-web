using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Data;
using System.Drawing;
using System.Configuration;


using BLL;
using USER;
using STR;
using SQLinject;

public partial class Admin_login : System.Web.UI.Page
{
    BLL.classeBLL bll;

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnEntrar_Click(object sender, EventArgs e)
    {
        bll = new classeBLL();
        try
        {
            SQLinject.classeSQLinject lixo = new SQLinject.classeSQLinject();
            if (lixo.InjecaoSQL(txtUsuario.Text, txtSenha.Text) == true)
            {
                lblMensagem.Text = "Foi localizado uma entrada de comandos maliciosos. Operação cancelada.";
            }
            else
            {
                lblMensagem.Text = "";

                int op;
                if (txtUsuario.Text == "admin")
                    op = 1;
                else
                    op = 0;

                Usuario u = new Usuario();
                u.usuario = txtUsuario.Text;
                u.Senha = txtSenha.Text;
                USER.Usuario Logado = new USER.Usuario();
                Logado = bll.Login(op, u);

                if (Logado.usuario == txtUsuario.Text && Logado.Senha == txtSenha.Text)
                {
                    Session["Usuario"] = u.usuario;
                    if (Logado.UserTemp == 1) //Se for usuario temporário
                    {
                        FormsAuthentication.RedirectFromLoginPage("admin", false);
                        Response.Redirect("~/Admin/altera_usuario.aspx");
                    }
                    else
                    {
                        if (op == 1)//Se for admin
                        {
                            FormsAuthentication.RedirectFromLoginPage("admin", false);
                            Response.Redirect("~/Admin/painel_controle.aspx");
                        }
                        else // se for empresa
                        {
                            FormsAuthentication.RedirectFromLoginPage("emp", false);
                            Session["CarregaUsuario"] = u.usuario;
                            Response.Redirect("~/Admin/cadastro_empresa.aspx");

                        }
                    }
                }
                else
                {

                    lblMensagem.Text = "Usuário ou senha inválidos";
                }
            }

        }
        catch (Exception ex)
        {
            bll.EnviarErros(ex.Message.ToString());
            lblMensagem.Text = "Ocorreu uma exceção no sistema. Tente novamente mais tarde.";
        }

    }
}