using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using EMP;
using BLL;
using SQLinject;

public partial class recupera_senha : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnEnviar_Click(object sender, EventArgs e)
    {
        BLL.classeBLL bll = new BLL.classeBLL();
        EMP.Empresa emp = new EMP.Empresa();
        SQLinject.classeSQLinject InjecaoSQL = new SQLinject.classeSQLinject();
        bool valida = true;
        try
        {
            emp.Usuario = txtUsuario.Text;
            emp.Email = txtEmail.Text;
            emp.CNPJ = txtCNPJ.Text;
            valida = InjecaoSQL.InjecaoSQLRecuperaSenha(emp);
            if (valida == false)// se não há lixo
            {
                valida = bll.RecuperaSenha(emp);//verifica se os dados conferem com os do banco de dados
                if (valida == true)
                    lblMensagem.Text = "Senha enviada para o E-mail: " + txtEmail.Text;
                else
                    lblMensagem.Text = "Não foi possível recuperar sua senha" +
                                    "<br/> porque os dados informados estão inconsistentes." +
                                    "<br/> Caso haja necessidade, entre em contado com o Suporte LISTA BEM através do link abaixo:" +
                                    "<br/><a href=contato.aspx>Contato LISTA BEM</a>";
            }
            else //se há lixo
                lblMensagem.Text = "Foi localizado uma entrada de comandos maliciosos. Operação cancelada.";
        }
        catch (Exception ex)
        {
            bll.EnviarErros(ex.Message.ToString());
        }
    }
}