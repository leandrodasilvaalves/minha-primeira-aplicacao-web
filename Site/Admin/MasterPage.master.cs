using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.User.Identity.Name.ToString() == "admin")
        {
            Menu1.Items.RemoveAt(2);//Cadastro de Empresas;
            
        }
        if (HttpContext.Current.User.Identity.Name.ToString() != "admin")
        {
            Menu1.Items.RemoveAt(1);//Painel de controle    
        }
                        
         
    }

    
}
