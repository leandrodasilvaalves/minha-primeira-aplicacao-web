using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using BLL;
using CONTATO;

public partial class contato : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblMensagem.Text = "";
        this.txtNome.Focus();
    }
    protected void btnEnviar_Click(object sender, EventArgs e)
    {
        BLL.classeBLL bll = new BLL.classeBLL();
        try
        {
            CONTATO.classeContatos c = new CONTATO.classeContatos();
            c.Nome = txtNome.Text;
            c.Email = txtEmail.Text;
            c.Site = txtSite.Text;
            c.Mensagem = txtMensagem.Text;
            bll.EnviarContatos(c);
            lblMensagem.Text = "Mensagem enviada com sucesso.";
            txtNome.Text = "";
            txtEmail.Text = "";
            txtSite.Text = "";
            txtMensagem.Text = "";
            this.txtNome.Focus();
        }
        catch (Exception ex)
        {

            bll.EnviarErros(ex.Message.ToString());
        }
    }
}