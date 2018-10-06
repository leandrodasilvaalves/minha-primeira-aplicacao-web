using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class mode800x600_index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.txtPesquisa.Focus();
    }
    public string Pesquisa
    {
        get { return txtPesquisa.Text; }
    }
    protected void btnPesquisa_Click(object sender, EventArgs e)
    {
        Server.Transfer("pesquisa.aspx");
    }
}