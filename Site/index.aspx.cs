using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;



public partial class index : System.Web.UI.Page

{       
    public string Pesquisa
    {
        get { return txtPesquisa.Text;}
       
    }

    protected void Page_Load(object sender, EventArgs e)
    {        
        this.txtPesquisa.Focus();
    }   
    protected void btnPesquisa_Click(object sender, EventArgs e)
    {
        Server.Transfer("pesquisa.aspx");        
    }

    [System.Web.Script.Services.ScriptMethod()]
    [System.Web.Services.WebMethod]
    public static List<string> SearchAutoComplete(string prefixText, int count)
    {
        BLL.classeBLL bll = new BLL.classeBLL();
        return bll.SearchAutoComplete(prefixText, count);
    }

   
}