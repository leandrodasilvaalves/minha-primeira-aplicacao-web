using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using USER;

public partial class altera_senha : System.Web.UI.Page
{
    BLL.classeBLL bll;  
    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.User.Identity.ToString() != "admin")
        {
            var menu = Page.Master.FindControl("Menu1") as Menu;
            if (menu != null)
            {
                menu.Items.RemoveAt(1);
            }
        }
    }
    protected void btnEnviar_Click(object sender, EventArgs e)
    {
        lblMensagem.ForeColor = System.Drawing.Color.Red;
        bll = new BLL.classeBLL();
        try
        {
            SQLinject.classeSQLinject Lixo = new SQLinject.classeSQLinject();
            if (Lixo.InjecaoSQL(txtSenhaAtual.Text, txtNovaSenha.Text) == true)
            {
                lblMensagem.Text = "Foi localizado uma entrada de comandos maliciosos. Operação cancelada.";
            }
            else
            {
                int tb = 0;
                string usuario = (string)Session["Usuario"];
                USER.Usuario US = new USER.Usuario();
                US.usuario = usuario;
                US.Senha = txtSenhaAtual.Text;

                if (usuario == "admin")
                    tb = 1;
                else
                    tb = 0;

                US = bll.Login(tb, US);// verifica se a senha está correta
                if (US.usuario==(string)Session["Usuario"] && US.Senha==txtSenhaAtual.Text)
                {
                    bll.AtualisaSenha(tb, (string)Session["Usuario"], txtNovaSenha.Text);
                    lblMensagem.Text = "Senha atualizada com sucesso.";
                    lblMensagem.ForeColor = System.Drawing.Color.Blue;
                }
                else
                    lblMensagem.Text = "A SENHA ATUAL informada não é compatível com a senha armazenada no sistema.";
                             
            }
        }
        catch (Exception ex)
        {
            bll.EnviarErros(ex.Message.ToString());
        }
    }
}