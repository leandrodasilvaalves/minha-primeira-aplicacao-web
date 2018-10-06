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

public partial class _Pesquisa : System.Web.UI.Page
{
    protected System.Web.UI.WebControls.Button btnPg;
    BLL.classeBLL bll;
    long cont;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (PreviousPage != null && PreviousPage.Pesquisa != string.Empty)
            {
                txtPesquisa.Text = PreviousPage.Pesquisa;
                hdfPesquisa.Value = txtPesquisa.Text;
            }
        }
        
        bll = new BLL.classeBLL();
        try
        {   
            if (!string.IsNullOrEmpty(txtPesquisa.Text))
                cont = bll.ContaRegistrosPesquisa(txtPesquisa.Text);
            else
                cont = bll.ContaRegistrosPesquisa(hdfPesquisa.Value.ToString());

            int TamanhoPg = int.Parse(ConfigurationManager.AppSettings["TamanhoPaginaPesquisa"].ToString());
            double NroPgs = cont / TamanhoPg;
            if (NroPgs > 1)
            {
                int pg = 0;
                for (int i = 1; i <= NroPgs; i++)
                {
                    btnPg = new Button();
                    btnPg.ID = "btn" + i.ToString();
                    btnPg.Text = i.ToString();
                    btnPg.CommandArgument = pg.ToString();
                    btnPg.Font.Bold = true;
                    btnPg.Width = 25;
                    btnPg.Height = 25;
                    btnPg.ForeColor = System.Drawing.Color.Blue;
                    pnlPaginas.Controls.Add(btnPg);

                    this.btnPg.Command += new CommandEventHandler(this.btnPaginas_Command);
                    pg += TamanhoPg + 1;
                }
            }

            if (!IsPostBack)
                Pesquisar(txtPesquisa.Text, 0);

                this.txtPesquisa.Focus();
            

        }
        catch (Exception ex)
        {
            bll.EnviarErros(ex.Message);
        }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {   
        Pesquisar(txtPesquisa.Text, 0);
        hdfPesquisa.Value = txtPesquisa.Text;
    }
    protected void btnPaginas_Command(object sender, CommandEventArgs e)
    {
        if(!string.IsNullOrEmpty(txtPesquisa.Text))
            Pesquisar(txtPesquisa.Text, int.Parse(e.CommandArgument.ToString()));
        else
            Pesquisar(hdfPesquisa.Value.ToString(), int.Parse(e.CommandArgument.ToString()));
    }
    protected void Pesquisar(string Buscar, int Inicio)
    {
        bll = new BLL.classeBLL();
        STR.clsString str = new STR.clsString();

        lblMensagem.Text = "";
        tblPesquisa.Rows.Clear();
        
        try
        {
            if (cont > 0)//Se houver resultados
            {
                PreencheTabella(Buscar, Inicio, 1, cont);
            }
            else
            {
                lblMensagem.Text = "Nenhum resultado foi encontrado para sua busca: <b><u>"
                    + txtPesquisa.Text + "</u></b>.";
                string strBuscar= str.Left(Buscar,1).ToString();  
                PreencheTabella(strBuscar, Inicio,2, bll.ContaRegistrosPesquisa(strBuscar));
            }
        }
        catch (Exception ex)
        {
            bll.EnviarErros(ex.Message.ToString());
        }

    }
    protected void PreencheTabella(string Buscar, int Inicio, int Procedure, long totalRegistros)
    {
        try
        {
            DataTable dt = new DataTable();
            dt = bll.PesquisaListaBem(Buscar, Inicio, Procedure);
            for (int i = 0; i <= totalRegistros; i++)
            {
                if (dt.Rows[i]["Ativo"].ToString() == "1")
                {

                    //Cabecalho - linha 1
                    TableRow linha1 = new TableRow();
                    TableCell cel1 = new TableCell();
                    if (!string.IsNullOrEmpty(dt.Rows[i]["Site"].ToString()))
                    {
                        cel1.Text = "<a href=http://" + dt.Rows[i]["Site"].ToString() + " target=_blank/>"
                                    + dt.Rows[i]["NomePrimario"].ToString() +
                                    " " + dt.Rows[i]["NomeSecundario"].ToString() + "</a>";
                    }
                    else
                    {
                        cel1.Text = "<a href=sem_representacao.aspx target=_blank/>"
                                + dt.Rows[i]["NomePrimario"].ToString() +
                                " " + dt.Rows[i]["NomeSecundario"].ToString() + "</a>";

                    }
                    cel1.ForeColor = Color.Blue;
                    cel1.Font.Size = 13;
                    linha1.Cells.Add(cel1);
                    tblPesquisa.Rows.Add(linha1);

                    //linha2                   
                    TableRow linha2 = new TableRow();
                    TableCell cel2 = new TableCell();

                    if (!string.IsNullOrEmpty(dt.Rows[i]["Site"].ToString())
                        && !string.IsNullOrEmpty(dt.Rows[i]["Email"].ToString()))
                    {
                        cel2.Text = dt.Rows[i]["Site"].ToString().ToLower() + " - " +
                            dt.Rows[i]["Email"].ToString().ToLower();
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(dt.Rows[i]["Site"].ToString()))
                            cel2.Text = dt.Rows[i]["Site"].ToString().ToLower();

                        if (!string.IsNullOrEmpty(dt.Rows[i]["Email"].ToString()))
                            cel2.Text = dt.Rows[i]["Email"].ToString().ToLower();
                    }
                    cel2.ForeColor = Color.Green;
                    cel2.Font.Size = 11;
                    linha2.Cells.Add(cel2);
                    tblPesquisa.Rows.Add(linha2);


                    //linha3
                    TableRow linha3 = new TableRow();
                    TableCell cel3 = new TableCell();
                    cel3.Text = dt.Rows[i]["Endereco"].ToString() +
                                " " + dt.Rows[i]["Bairro"].ToString() +
                                " CEP: " + dt.Rows[i]["CEP"].ToString();
                    cel3.ForeColor = ColorTranslator.FromHtml("#444444");
                    cel3.Font.Size = 10;
                    linha3.Cells.Add(cel3);
                    tblPesquisa.Rows.Add(linha3);

                    //linha4
                    TableRow linha4 = new TableRow();
                    TableCell cel4 = new TableCell();
                    cel4.Text = dt.Rows[i]["Telefone1"].ToString() +
                                " . " + dt.Rows[i]["Telefone2"].ToString() +
                                " . " + dt.Rows[i]["Telefone3"].ToString() +
                                " . " + dt.Rows[i]["Telefone4"].ToString();
                    cel4.ForeColor = ColorTranslator.FromHtml("#444444");
                    cel4.Font.Size = 10;
                    linha4.Cells.Add(cel4);
                    tblPesquisa.Rows.Add(linha4);

                    //Banners
                    STR.clsString str = new STR.clsString();// para remover o "~/" do caminho das imagens                   
                    string Banners = string.Empty;
                    string Banner1 = str.Right(dt.Rows[i]["Banner1"].ToString(), 2);
                    string Banner2 = str.Right(dt.Rows[i]["Banner2"].ToString(), 2);
                    string Banner3 = str.Right(dt.Rows[i]["Banner3"].ToString(), 2);
                    string Banner4 = str.Right(dt.Rows[i]["Banner4"].ToString(), 2);

                    int Alt = int.Parse(ConfigurationManager.AppSettings["AlturaBannerListagem"].ToString());
                    int Larg = int.Parse(ConfigurationManager.AppSettings["LarguraBannerListagem"].ToString());
                    string ModoTransicaoBanners = ConfigurationManager.AppSettings["TransicaoBanners"].ToString();

                    if (str.rRight(Banner1, 4) == ".jpg")
                        Banners += "<a " + ModoTransicaoBanners + " href=" + Banner1 + "><img src=" + Banner1 + " height=" + Alt + " width= " + Larg + "></a>";
                    if (str.rRight(Banner2, 4) == ".jpg")
                        Banners += "<a " + ModoTransicaoBanners + " href=" + Banner2 + "><img src=" + Banner2 + " height=" + Alt + " width= " + Larg + "></a>";
                    if (str.rRight(Banner3, 4) == ".jpg")
                        Banners += "<a " + ModoTransicaoBanners + " href=" + Banner3 + "><img src=" + Banner3 + " height=" + Alt + " width= " + Larg + "></a>";
                    if (str.rRight(Banner4, 4) == ".jpg")
                        Banners += "<a " + ModoTransicaoBanners + " href=" + Banner4 + "><img src=" + Banner4 + " height=" + Alt + " width= " + Larg + "></a>";


                    TableRow rowBanner = new TableRow();
                    TableCell cellBanner1 = new TableCell();
                    cellBanner1.Text = Banners;
                    rowBanner.Cells.Add(cellBanner1);
                    tblPesquisa.Rows.Add(rowBanner);


                    //SubDivisoes                            
                    TableRow linhaSbD = new TableRow();
                    TableCell CelSbD = new TableCell();
                    CelSbD.ForeColor = ColorTranslator.FromHtml("#444444");
                    CelSbD.Font.Size = 11;
                    CelSbD.Text = "<table>" +
                        //linha1 - Cabecalho

                                        "<tr style=font-size:14px;>";
                    if (!string.IsNullOrEmpty(dt.Rows[i]["SubDivisao1"].ToString()))
                    {
                        if (!string.IsNullOrEmpty(dt.Rows[i]["SiteSubDivisao1"].ToString()))
                        {
                            CelSbD.Text += "<td>&nbsp &nbsp &nbsp &nbsp</td>" +
                            "<td><a href=http://" + dt.Rows[i]["SiteSubDivisao1"].ToString() + " target=_blank>"
                                    + dt.Rows[i]["SubDivisao1"].ToString() + "</a></td>";
                        }
                        else
                        {
                            CelSbD.Text += "<td>&nbsp &nbsp &nbsp &nbsp</td>" +
                            "<td><a href=sem_representacao.aspx target=_blank >"
                                    + dt.Rows[i]["SubDivisao1"].ToString() + "</a></td>";
                        }
                    }

                    if (!string.IsNullOrEmpty(dt.Rows[i]["SubDivisao2"].ToString()))
                    {
                        if (!string.IsNullOrEmpty(dt.Rows[i]["SiteSubDivisao2"].ToString()))
                        {
                            CelSbD.Text += "<td>&nbsp &nbsp &nbsp &nbsp</td>" +
                            "<td><a href=http://" + dt.Rows[i]["SiteSubDivisao2"].ToString() + " target=_blank>"
                                    + dt.Rows[i]["SubDivisao2"].ToString() + "</a></td>";
                        }
                        else
                        {
                            CelSbD.Text += "<td>&nbsp &nbsp &nbsp &nbsp</td>" +
                            "<td><a href=sem_representacao.aspx target=_blank>"
                                    + dt.Rows[i]["SubDivisao2"].ToString() + "</a></td>";
                        }
                    }
                    CelSbD.Text += "</tr>" +


                   //Atividades
                   "<tr style=font-size:12px;>";

                    if (!string.IsNullOrEmpty(dt.Rows[i]["SubDivisao1"].ToString()))
                    {
                        if (!string.IsNullOrEmpty(dt.Rows[i]["AtividadesSubDivisao1"].ToString()))
                        {
                            CelSbD.Text += "<td>&nbsp &nbsp &nbsp &nbsp</td>" +
                            "<td>" + dt.Rows[i]["AtividadesSubDivisao1"].ToString() + "</td>";
                        }
                    }

                    if (!string.IsNullOrEmpty(dt.Rows[i]["SubDivisao2"].ToString()))
                    {
                        if (!string.IsNullOrEmpty(dt.Rows[i]["AtividadesSubDivisao2"].ToString()))
                        {
                            CelSbD.Text += "<td>&nbsp &nbsp &nbsp &nbsp &nbsp &nbsp</td>" +
                             "<td>" + dt.Rows[i]["AtividadesSubDivisao2"].ToString() + "</td>";
                        }
                    }

                    CelSbD.Text += "</tr>" +
                        //Telefone
                "<tr style=font-size:12px;>";

                    if (!string.IsNullOrEmpty(dt.Rows[i]["SubDivisao1"].ToString()))
                    {
                        if (!string.IsNullOrEmpty(dt.Rows[i]["TelefoneSubDivisao1"].ToString()))
                        {
                            CelSbD.Text += "<td>&nbsp &nbsp &nbsp &nbsp</td>" +
                            "<td>" + dt.Rows[i]["TelefoneSubDivisao1"].ToString() + "</td>";
                        }
                    }


                    if (!string.IsNullOrEmpty(dt.Rows[i]["SubDivisao2"].ToString()))
                    {
                        if (!string.IsNullOrEmpty(dt.Rows[i]["TelefoneSubDivisao2"].ToString()))
                        {
                            CelSbD.Text += "<td>&nbsp &nbsp &nbsp &nbsp &nbsp &nbsp</td>" +
                   "<td>" + dt.Rows[i]["TelefoneSubDivisao2"].ToString() + "</td>";
                        }
                    }


                    CelSbD.Text += "</tr>" +
                        //Cabecalho
              "<tr style=font-size:12px;>";

                    if (!string.IsNullOrEmpty(dt.Rows[i]["SubDivisao3"].ToString()))
                    {
                        if (!string.IsNullOrEmpty(dt.Rows[i]["SiteSubDivisao3"].ToString()))
                        {
                            CelSbD.Text += "<td>&nbsp &nbsp &nbsp &nbsp</td>" +
                            "<td><a href=http://" + dt.Rows[i]["SiteSubDivisao3"].ToString() + " target=_blank>"
                                    + dt.Rows[i]["SubDivisao3"].ToString() + "</a></td>";
                        }
                        else
                        {
                            CelSbD.Text += "<td>&nbsp &nbsp &nbsp &nbsp</td>" +
                            "<td><a href=sem_representacao.aspx target=_blank>"
                                    + dt.Rows[i]["SubDivisao3"].ToString() + "</a></td>";
                        }
                    }

                    if (!string.IsNullOrEmpty(dt.Rows[i]["SubDivisao4"].ToString()))
                    {
                        if (!string.IsNullOrEmpty(dt.Rows[i]["SiteSubDivisao4"].ToString()))
                        {
                            CelSbD.Text += "<td>&nbsp &nbsp &nbsp &nbsp</td>" +
                            "<td><a href=http://" + dt.Rows[i]["SiteSubDivisao4"].ToString() + ">"
                                    + dt.Rows[i]["SubDivisao4"].ToString() + "</a></td>";
                        }
                        else
                        {
                            CelSbD.Text += "<td>&nbsp &nbsp &nbsp &nbsp</td>" +
                            "<td><a href=sem_representacao.aspx>"
                                    + dt.Rows[i]["SubDivisao4"].ToString() + "</a></td>";
                        }
                    }

                    CelSbD.Text += "</tr>" +
                        //Atividades
               "<tr style=font-size:12px;>";


                    if (!string.IsNullOrEmpty(dt.Rows[i]["SubDivisao3"].ToString()))
                    {
                        if (!string.IsNullOrEmpty(dt.Rows[i]["AtividadesSubDivisao3"].ToString()))
                        {
                            CelSbD.Text += "<td>&nbsp &nbsp &nbsp &nbsp</td>" +
                   "<td>" + dt.Rows[i]["AtividadesSubDivisao3"].ToString() + "</td>";
                        }
                    }

                    if (!string.IsNullOrEmpty(dt.Rows[i]["SubDivisao4"].ToString()))
                    {
                        if (!string.IsNullOrEmpty(dt.Rows[i]["AtividadesSubDivisao4"].ToString()))
                        {
                            CelSbD.Text += "<td>&nbsp &nbsp &nbsp &nbsp &nbsp &nbsp</td>" +
                                "<td>" + dt.Rows[i]["AtividadesSubDivisao4"].ToString() + "</td>";
                        }
                    }


                    CelSbD.Text += "</tr>" +
                        //Telefone
               "<tr style=font-size:12px;>";

                    if (!string.IsNullOrEmpty(dt.Rows[i]["SubDivisao3"].ToString()))
                    {
                        if (!string.IsNullOrEmpty(dt.Rows[i]["TelefoneSubDivisao3"].ToString()))
                        {
                            CelSbD.Text += "<td>&nbsp &nbsp &nbsp &nbsp</td>" +
                           "<td>" + dt.Rows[i]["TelefoneSubDivisao3"].ToString() + "</td>";
                        }
                    }

                    if (!string.IsNullOrEmpty(dt.Rows[i]["SubDivisao4"].ToString()))
                    {
                        if (!string.IsNullOrEmpty(dt.Rows[i]["TelefoneSubDivisao4"].ToString()))
                        {
                            CelSbD.Text += "<td>&nbsp &nbsp &nbsp &nbsp &nbsp &nbsp</td>" +
                           "<td>" + dt.Rows[i]["TelefoneSubDivisao4"].ToString() + "</td>";
                        }
                    }

                    CelSbD.Text += "</tr>" +
                        //Cabecalho
                    "<tr style=font-size:12px;>";

                    if (!string.IsNullOrEmpty(dt.Rows[i]["SubDivisao5"].ToString()))
                    {
                        if (!string.IsNullOrEmpty(dt.Rows[i]["SiteSubDivisao5"].ToString()))
                        {
                            CelSbD.Text += "<td>&nbsp &nbsp &nbsp &nbsp</td>" +
                            "<td><a href=http://" + dt.Rows[i]["SiteSubDivisao5"].ToString() + " target=_blank>"
                                    + dt.Rows[i]["SubDivisao5"].ToString() + "</a></td>";
                        }
                        else
                        {
                            CelSbD.Text += "<td>&nbsp &nbsp &nbsp &nbsp</td>" +
                            "<td><a href=sem_representacao.aspx target=_blank>"
                                    + dt.Rows[i]["SubDivisao5"].ToString() + "</a></td>";
                        }
                    }

                    if (!string.IsNullOrEmpty(dt.Rows[i]["SubDivisao6"].ToString()))
                    {
                        if (!string.IsNullOrEmpty(dt.Rows[i]["SiteSubDivisao6"].ToString()))
                        {
                            CelSbD.Text += "<td>&nbsp &nbsp &nbsp &nbsp</td>" +
                            "<td><a href=http://" + dt.Rows[i]["SiteSubDivisao6"].ToString() + " target=_blank>"
                                    + dt.Rows[i]["SubDivisao6"].ToString() + "</a></td>";
                        }
                        else
                        {
                            CelSbD.Text += "<td>&nbsp &nbsp &nbsp &nbsp</td>" +
                            "<td><a href=sem_representacao.aspx target=_blank>"
                                    + dt.Rows[i]["SubDivisao6"].ToString() + "</a></td>";
                        }
                    }

                    CelSbD.Text += "</tr>" +
                        //Atividades
                "<tr style=font-size:12px;>";

                    if (!string.IsNullOrEmpty(dt.Rows[i]["SubDivisao5"].ToString()))
                    {
                        if (!string.IsNullOrEmpty(dt.Rows[i]["AtividadesSubDivisao5"].ToString()))
                        {
                            CelSbD.Text += "<td>&nbsp &nbsp &nbsp &nbsp</td>" +
                         "<td>" + dt.Rows[i]["AtividadesSubDivisao5"].ToString() + "</td>";
                        }
                    }

                    if (!string.IsNullOrEmpty(dt.Rows[i]["SubDivisao6"].ToString()))
                    {
                        if (!string.IsNullOrEmpty(dt.Rows[i]["AtividadesSubDivisao6"].ToString()))
                        {
                            CelSbD.Text += "<td>&nbsp &nbsp &nbsp &nbsp &nbsp &nbsp</td>" +
                            "<td>" + dt.Rows[i]["AtividadesSubDivisao6"].ToString() + "</td>";
                        }
                    }

                    CelSbD.Text += "</tr>" +
                        //Telefone
                    "<tr style=font-size:12px;>";

                    if (!string.IsNullOrEmpty(dt.Rows[i]["SubDivisao5"].ToString()))
                    {
                        if (!string.IsNullOrEmpty(dt.Rows[i]["TelefoneSubDivisao5"].ToString()))
                        {
                            CelSbD.Text += "<td>&nbsp &nbsp &nbsp &nbsp</td>" +
                            "<td>" + dt.Rows[i]["TelefoneSubDivisao5"].ToString() + "</td>";
                        }
                    }

                    if (!string.IsNullOrEmpty(dt.Rows[i]["SubDivisao6"].ToString()))
                    {
                        if (!string.IsNullOrEmpty(dt.Rows[i]["TelefoneSubDivisao6"].ToString()))
                        {
                            CelSbD.Text += "<td>&nbsp &nbsp &nbsp &nbsp &nbsp &nbsp</td>" +
                            "<td>" + dt.Rows[i]["TelefoneSubDivisao6"].ToString() + "</td>";
                        }
                    }
                    CelSbD.Text += "</tr>" +
                    "</table>" +
                    "<br/>";




                    linhaSbD.Cells.Add(CelSbD);
                    tblPesquisa.Rows.Add(linhaSbD);


                }
                else
                {
                    //Cabecalho - linha 1
                    TableRow nlinha1 = new TableRow();
                    TableCell ncel1 = new TableCell();

                    ncel1.Text = "<a href=sem_representacao.aspx" + dt.Rows[i]["Site"].ToString() + " target=_blank/>"
                                + dt.Rows[i]["NomePrimario"].ToString() +
                                " " + dt.Rows[i]["NomeSecundario"].ToString() + "</a>";
                    ncel1.ForeColor = Color.Blue;
                    ncel1.Font.Size = 13;
                    nlinha1.Cells.Add(ncel1);
                    tblPesquisa.Rows.Add(nlinha1);

                    //linha2
                    TableRow nlinha2 = new TableRow();
                    TableCell ncel2 = new TableCell();
                    ncel2.Text = dt.Rows[i]["Telefone1"].ToString() + "</br></br>";
                    ncel2.ForeColor = ColorTranslator.FromHtml("#444444");
                    ncel2.Font.Size = 10;
                    nlinha2.Cells.Add(ncel2);
                    tblPesquisa.Rows.Add(nlinha2);

                }

            }

        }
        catch(Exception ex)
        {
            throw ex;
        }
    }
    
}