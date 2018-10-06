using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using BLL;
using SQLinject;
using STR;

using MySql.Data.MySqlClient;
using System.Configuration;


public partial class altera_usuario : System.Web.UI.Page
{
    BLL.classeBLL bll;
    protected void Page_Load(object sender, EventArgs e)
    {       
        txtUsuarioAtual.Text = (string)Session["Usuario"];
    }
    protected void btnEnviar_Click(object sender, EventArgs e)
    {
        bll = new BLL.classeBLL();
        try
        {
            SQLinject.classeSQLinject Lixo = new SQLinject.classeSQLinject();
            if (Lixo.InjecaoSQL(txtUsuarioAtual.Text,txtNovoUsuario.Text) == true)
            {
                lblMensagem.Text="Foi localizado uma entrada de comandos maliciosos. Operação cancelada.";
            }
            else
            {
           
                if (bll.VerificaSeUsuarioTemp(txtUsuarioAtual.Text) == false)//0
                {// se retornar false o usuario é permanente
                    lblMensagem.Text = "Opa! O usuario <b><u>" + txtNovoUsuario.Text + "</u></b> já é permanente. <br/> Operação não realizada!";
                }
                else if (bll.ExisteUsuario(txtNovoUsuario.Text) >= 1)
                { //Se o usuario já estiver em uso.
                    lblMensagem.Text = "<b><u>" + txtNovoUsuario.Text + "</u></b> já está sendo usado por outra conta LISTA BEM. <br/> Vamos tentar novamente?";
                }           
                else
                {
                    if (ValidaUsuario(txtNovoUsuario.Text) == true)
                    {
                        string NewUs = txtNovoUsuario.Text;
                        NewUs = NewUs.Trim();
                        bll.AtualizaUsuario(txtUsuarioAtual.Text, NewUs);
                        Session["Usuario"] = NewUs;
                        lblMensagem.ForeColor = System.Drawing.Color.Blue;
                        btnContinuar.Visible = true;
                        lblMensagem.Text = "<b>Usuário atualizado com sucesso.</b> <br/>Agora troque sua senha temporária por uma de sua preferência. <br/>Clique em continuar para prosseguir...";
                        btnEnviar.Enabled = false;
                    }
                    else
                        lblMensagem.Text = "Espaços em branco não são permitidos. Caso haja nessecidade de separar palavras no usuário utilize <b>Underline</b> ( _ ).";
                }
             }
        }
        catch (Exception ex)
        {
            bll.EnviarErros(ex.Message.ToString());
        }
        
    }
    protected bool ValidaUsuario(string Us)
    {
        bool b = false;
        STR.clsString strVal = new STR.clsString();
        for (int i = 1; i <= Us.Length; i++)
        {
            if (strVal.Mid(Us, i,1) == " ")
            {
                b = false;
                break;
            }
            else
                b = true;
        }
        return b;
    }


    protected void btnContinuar_Click(object sender, EventArgs e)
    {
        Response.Redirect("altera_senha.aspx");
    }
   
   

}