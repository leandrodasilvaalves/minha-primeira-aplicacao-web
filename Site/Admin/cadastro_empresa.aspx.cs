using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Configuration;
using System.Threading; //Adicionado para utilizar o Sleep

using EMP;
using BLL;
using USER;



public partial class cadastro_empresa : System.Web.UI.Page
{
    BLL.classeBLL bll;

    protected void Page_Load(object sender, EventArgs e)
    {

        string strUser = (string)Session["CarregaUsuario"];
       
        if (HttpContext.Current.User.Identity.Name.ToString() != "admin")
        {
            rblAtivo.Visible = false;            
            lblAtivo.Visible = false;
            rblPrioridade.Visible = false;
            lblPrioridade.Visible = false;
            btnNovoRegistro.Visible = false;
            lblConc.Visible = false;
            txtRamoAtividade.Visible = false;
        }
        if (strUser == null || strUser == string.Empty)
        {   //Se a sessão expirar redireciona para login
            FormsAuthentication.SignOut();
            Response.Redirect("index.aspx");
        }
            
        else
        {
            
            if (!IsPostBack == true)
            {
                SelecionaEmpresaPorUsuario(strUser);
               
            }
        }
        
    }
    protected void SelecionaEmpresaPorUsuario(string US)
    {
       bll = new classeBLL();
        try
        {
            Empresa emp = new Empresa();            
            emp = bll.SelecionaEmpresaPorUsuario(US);
            txtUsuario.Text = emp.Usuario;
            txtNomePrimario.Text = emp.NomePrimario;
            txtNomeSecundario.Text = emp.NomeSecundario;
            txtAutoCompelte.Text = emp.AutoComplete;
            txtRamoAtividade.Text = emp.RamoAtividade;
            txtEndereco.Text = emp.Endereco;
            txtBairro.Text = emp.Bairro;
            dpdCidade.Text = emp.Cidade;
            dpdEstado.Text = emp.Estado;
            txtCNPJ.Text = emp.CNPJ;
            txtCEP.Text = emp.CEP;
            txtTelefone1.Text = emp.Tel1;
            txtTelefone2.Text = emp.Tel2;
            txtTelefone3.Text = emp.Tel3;
            txtTelefone4.Text = emp.Tel4;
            txtEmail.Text = emp.Email;
            txtSite.Text = emp.Site;
            txtPalavrasComercial.Text = emp.PalavrasCom;
            imgBanner1.ImageUrl = emp.Banner1 + "?time=" + DateTime.Now.ToString();
            imgBanner2.ImageUrl = emp.Banner2 + "?time=" + DateTime.Now.ToString();
            imgBanner3.ImageUrl = emp.Banner3 + "?time=" + DateTime.Now.ToString();
            imgBanner4.ImageUrl = emp.Banner4 + "?time=" + DateTime.Now.ToString();
            txtDataCadastro.Text = emp.DataCadastro;
            rblAtivo.SelectedIndex = emp.Ativo;
            rblPrioridade.SelectedIndex = emp.Prioridade;

            txtSubDivisao1.Text = emp.subDivisao1;
            txtSiteSubDivisao1.Text = emp.siteSubDivisao1;
            txtTelefoneSubDivisao1.Text = emp.TelefoneSuDivisao1;
            txtAtividadesSubDivisao1.Text = emp.AtividadesSubDivisao1;

            txtSubDivisao2.Text = emp.subDivisao2;
            txtSiteSubDivisao2.Text = emp.siteSubDivisao2;
            txtTelefoneSubDivisao2.Text = emp.TelefoneSuDivisao2;
            txtAtividadesSubDivisao2.Text = emp.AtividadesSubDivisao2;

            txtSubDivisao3.Text = emp.subDivisao3;
            txtSiteSubDivisao3.Text = emp.siteSubDivisao3;
            txtTelefoneSubDivisao3.Text = emp.TelefoneSuDivisao3;
            txtAtividadesSubDivisao3.Text = emp.AtividadesSubDivisao3;

            txtSubDivisao4.Text = emp.subDivisao4;
            txtSiteSubDivisao4.Text = emp.siteSubDivisao4;
            txtTelefoneSubDivisao4.Text = emp.TelefoneSuDivisao4;
            txtAtividadesSubDivisao4.Text = emp.AtividadesSubDivisao4;

            txtSubDivisao5.Text = emp.subDivisao5;
            txtSiteSubDivisao5.Text = emp.siteSubDivisao5;
            txtTelefoneSubDivisao5.Text = emp.TelefoneSuDivisao5;
            txtAtividadesSubDivisao5.Text = emp.AtividadesSubDivisao5;

            txtSubDivisao6.Text = emp.subDivisao6;
            txtSiteSubDivisao6.Text = emp.siteSubDivisao6;
            txtTelefoneSubDivisao6.Text = emp.TelefoneSuDivisao6;
            txtAtividadesSubDivisao6.Text = emp.AtividadesSubDivisao6;

        }
        catch (Exception ex)
        {
            //bll.EnviarErros(ex.Message.ToString());
            Response.Write(ex.Message.ToString());
        }
    }   
    protected void btnEnviar_Click(object sender, EventArgs e)
    {
        bll = new BLL.classeBLL();
        try
        {
            EMP.Empresa emp = new EMP.Empresa();
            emp.Usuario = txtUsuario.Text;
            emp.NomePrimario = txtNomePrimario.Text;
            emp.NomeSecundario = txtNomeSecundario.Text;
            emp.AutoComplete = txtAutoCompelte.Text;
            emp.RamoAtividade = txtRamoAtividade.Text;
            emp.Endereco = txtEndereco.Text;
            emp.Bairro = txtBairro.Text;
            emp.Cidade = dpdCidade.Text;
            emp.Estado = dpdEstado.Text;
            emp.CNPJ = txtCNPJ.Text;
            emp.CEP = txtCEP.Text;
            emp.Tel1 = txtTelefone1.Text;
            emp.Tel2 = txtTelefone2.Text;
            emp.Tel3 = txtTelefone3.Text;
            emp.Tel4 = txtTelefone4.Text;
            emp.Email = txtEmail.Text;
            emp.Site = txtSite.Text;
            emp.PalavrasCom = txtPalavrasComercial.Text;
            emp.Ativo = int.Parse(rblAtivo.SelectedValue);
            emp.Prioridade = int.Parse(rblPrioridade.SelectedValue);
            
            emp.subDivisao1 = txtSubDivisao1.Text;
            emp.siteSubDivisao1 = txtSiteSubDivisao1.Text;
            emp.TelefoneSuDivisao1 = txtTelefoneSubDivisao1.Text;
            emp.AtividadesSubDivisao1 = txtAtividadesSubDivisao1.Text;
            emp.subDivisao2 = txtSubDivisao2.Text;
            emp.siteSubDivisao2 = txtSiteSubDivisao2.Text;
            emp.TelefoneSuDivisao2 = txtTelefoneSubDivisao2.Text;
            emp.AtividadesSubDivisao2 = txtAtividadesSubDivisao2.Text;
            emp.subDivisao3 = txtSubDivisao3.Text;
            emp.siteSubDivisao3 = txtSiteSubDivisao3.Text;
            emp.TelefoneSuDivisao3 = txtTelefoneSubDivisao3.Text;
            emp.AtividadesSubDivisao3 = txtAtividadesSubDivisao3.Text;
            emp.subDivisao4 = txtSubDivisao4.Text;
            emp.siteSubDivisao4 = txtSiteSubDivisao4.Text;
            emp.TelefoneSuDivisao4 = txtTelefoneSubDivisao4.Text;
            emp.AtividadesSubDivisao4 = txtAtividadesSubDivisao4.Text;
            emp.subDivisao5 = txtSubDivisao5.Text;
            emp.siteSubDivisao5 = txtSiteSubDivisao5.Text;
            emp.TelefoneSuDivisao5 = txtTelefoneSubDivisao5.Text;
            emp.AtividadesSubDivisao5 = txtAtividadesSubDivisao5.Text;
            emp.subDivisao6 = txtSubDivisao6.Text;
            emp.siteSubDivisao6 = txtSiteSubDivisao6.Text;
            emp.TelefoneSuDivisao6 = txtTelefoneSubDivisao6.Text;
            emp.AtividadesSubDivisao6 = txtAtividadesSubDivisao6.Text;

            bll.AtualizaEmpresa(emp);
            lblMensagem.Text = "Cadastro atualizado com sucesso.";           
        }
        catch (Exception ex)
        {
            bll.EnviarErros(ex.Message.ToString());
        }
    }    
    protected void bntEnviarBanner1_Click(object sender, EventArgs e)
    {
        //Verificar se existe algum arquivo
        if (fupBanner1.HasFile)
        {
            Session["Banner"] = 1; //Para identificar qual banner salvar
            Enviar_Otimizar_Imagem(fupBanner1, "_Banner1");
        }
        else
        {
            ShowMessageBox("Nenhum arquivo foi selecionado no Banner 01.");
        }
    }    
    protected void bntEnviarBanner2_Click(object sender, EventArgs e)
    {
        //Verificar se existe algum arquivo
        if (fupBanner2.HasFile)
        {
            Session["Banner"] = 2; //Para identificar qual banner salvar
            Enviar_Otimizar_Imagem(fupBanner2, "_Banner2");
        }
        else
        {
            ShowMessageBox("Nenhum arquivo foi selecionado no Banner 02.");
        }


    }    
    protected void bntEnviarBanner3_Click(object sender, EventArgs e)
    {
        //Verificar se existe algum arquivo
        if (fupBanner3.HasFile)
        {
            Session["Banner"] = 3; //Para identificar qual banner salvar
            Enviar_Otimizar_Imagem(fupBanner3, "_Banner3");
        }
        else
        {
            ShowMessageBox("Nenhum arquivo foi selecionado no Banner 03.");
        }
    }
    protected void bntEnviarBanner4_Click(object sender, EventArgs e)
    {
        //Verificar se existe algum arquivo
        if (fupBanner4.HasFile)
        {
            Session["Banner"] = 4; //Para identificar qual banner salvar
            Enviar_Otimizar_Imagem(fupBanner4, "_Banner4");
        }
        else
        {
            ShowMessageBox("Nenhum arquivo foi selecionado no Banner 04.");
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
    protected void Enviar_Otimizar_Imagem( FileUpload fup, string Banner)
    {
            bll = new BLL.classeBLL();// para enviar erros
            string sImgFile = string.Empty;
            int TamanhoMaximoBanner = int.Parse(ConfigurationManager.AppSettings["TamanhoMaximoBanners"].ToString());
            bool bValido = false;
            string sPath = Server.MapPath("~/Admin/upload/");//caminho onde vai ser salva a imagem
            string sFileName = fup.FileName;
            sImgFile = sPath + sFileName;


            //Verifica se é imagem
            string fileExtension = System.IO.Path.GetExtension(sFileName).ToLower();
            foreach (string extension in new string[] { ".gif", ".jpg", "jpeg", "png" })
            {
                if (fileExtension == extension)
                    bValido = true;
            }
            if (bValido == true)
            {
                try
                {
                    //Cria o diretorio se ainda não existir
                    if (!Directory.Exists(sPath))
                        Directory.CreateDirectory(sPath);

                    //Salvar imagem
                    fup.SaveAs(sImgFile);
                  

                    //compacta a imagem para web
                    Bitmap imgFonte = new Bitmap(sImgFile);

                    int Ht_prop = 0;
                    int Wt_prop = 0;

                    int Ht_f = 0;
                    int Wt_f = 0;

                    int Larg = 0;
                    int Alt = 0;


                    if (imgFonte.Width > TamanhoMaximoBanner)
                        {
                            //modifica as dimensões proporcionalmente usando regra de 3
                            Wt_prop = TamanhoMaximoBanner;
                            Ht_f = imgFonte.Height;
                            Wt_f = imgFonte.Width;
                            Ht_prop = (Wt_prop * Ht_f) / Wt_f;

                            if (Ht_prop > TamanhoMaximoBanner)
                            {
                                Ht_prop = TamanhoMaximoBanner;
                                Ht_f = imgFonte.Height;
                                Wt_f = imgFonte.Width;
                                Wt_prop = (Ht_prop * Wt_f) / Ht_f;
                            }

                            Larg = Wt_prop;
                            Alt = Ht_prop;

                        }
                        else
                        {
                            Larg = imgFonte.Width;
                            Alt = imgFonte.Height;
                        }

                    if (imgFonte.Height > TamanhoMaximoBanner)
                        {
                            //modifica as dimensões proporcionalmente usando regra de 3
                            Ht_prop = TamanhoMaximoBanner;
                            Ht_f = imgFonte.Height;
                            Wt_f = imgFonte.Width;
                            Wt_prop = (Ht_prop * Wt_f) / Ht_f;

                            if (Wt_prop > TamanhoMaximoBanner)
                            {
                                Wt_prop = TamanhoMaximoBanner;
                                Ht_f = imgFonte.Height;
                                Wt_f = imgFonte.Width;
                                Ht_prop = (Wt_prop * Ht_f) / Wt_f;
                            }

                            Larg = Wt_prop;
                            Alt = Ht_prop;

                        }
                        else
                        {
                            Larg = imgFonte.Width;
                            Alt = imgFonte.Height;
                        }


                    Bitmap Alvo = new Bitmap(Larg, Alt);
                    Graphics g = Graphics.FromImage(Alvo);
                    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                    g.DrawImage(imgFonte, new Rectangle(0, 0, Larg, Alt));

                    string NewImg = Server.MapPath("~/Admin/upload/") + (string)Session["CarregaUsuario"] + Banner + ".jpg";
                    Alvo.Save(NewImg, ImageFormat.Jpeg); //Salva a imagem otimizada

                    imgFonte.Dispose();//Libera memória fechando as instâncias
                    Alvo.Dispose();                    

                    //Limpar diretório
                    File.Delete(sImgFile);                    

                    //Carrega a imagem
                    pnlCadastro.Visible = false;
                    pnlFoto.Visible = false;
                    pnlSubDivisoes.Visible = false;
                    pnlCutImagem.Visible = true;
                    imgCorte.ImageUrl = "~/Admin/upload/" + (string)Session["CarregaUsuario"] + Banner + ".jpg";
                    Session["NomeImg"] = (string)Session["CarregaUsuario"] + Banner + ".jpg";
                }
                catch (Exception ex)
                {
                    bll.EnviarErros(ex.Message.ToString());
                }
            }
            else
                ShowMessageBox("O arquivo selecionado não é válido. Utilize apenas imagens com extensão .jpg");
        }
    protected void btnSalvarRecorte_Click(object sender, EventArgs e)
    {
        bll = new BLL.classeBLL();// para enviar erros
        string sImgFile = Server.MapPath("~/Admin/upload/") + (string)Session["NomeImg"];
        string sNomeImg = (string)Session["NomeImg"];
        Session["NomeImg"]   = null;

        //Validando se foi selecionada alguma parte da imagem.
        if (string.IsNullOrEmpty(txtX.Value))
            ShowMessageBox("Selecione a parte da imagem a ser recortada!");
        else
        {
            int x = Convert.ToInt32(txtX.Value);
            int y = Convert.ToInt32(txtY.Value);
            int w = Convert.ToInt32(txtW.Value);
            int h = Convert.ToInt32(txtH.Value);
            //Verificar se a parte selecionada é maior que zero.
            if (w < 1 || h < 1)
                ShowMessageBox("Selecione a parte da imagem a ser recortada!");
            else
            {   
                //Cortar imagem
                Rectangle cropRect = new Rectangle(x, y, w, h);
                Bitmap src = System.Drawing.Image.FromFile(sImgFile) as Bitmap;
                Bitmap target = new Bitmap(cropRect.Width, cropRect.Height);

                using (Graphics g = Graphics.FromImage(target))
                {
                    g.DrawImage(src,
                        new Rectangle(0, 0, target.Width, target.Height), cropRect, GraphicsUnit.Pixel);
                }

                
                //Salvar imagem recortada
                target.Save(Server.MapPath("~/Admin/Banner/") + sNomeImg);
                
                
                target.Dispose();
                src.Dispose();

                //Limpa Lixo
                File.Delete(sImgFile);

                //Salva o caminho da imagem no banco de dados
                try
                {
                    bll = new classeBLL();
                    bll.AtualisaBanner((string)Session["CarregaUsuario"],
                                        "~/Admin/Banner/" + sNomeImg, 
                                        int.Parse(Session["Banner"].ToString()));
                    Session["Banner"] = null;

                    SelecionaEmpresaPorUsuario((string)Session["CarregaUsuario"]);
                    btnNovoRegistro.Visible = false;
                    btnFotos.Enabled = false;
                    btnCadastro.Enabled = true;
                    btnSubDivisoes.Enabled = true;
                    btnEnviar.Visible = false;
                    pnlCadastro.Visible = false;
                    pnlCutImagem.Visible = false;
                    pnlFoto.Visible = true;
                    pnlSubDivisoes.Visible = false;
                    lblMensagem.Text = "";
                }
                catch (Exception ex)
                {
                    bll.EnviarErros(ex.Message.ToString());
                }

            }

        }
    }
    protected void btnUsarOriginal_Click(object sender, EventArgs e)
    {
        string sImgFile = Server.MapPath("~/Admin/upload/") + (string)Session["NomeImg"];
        string sNomeImg = (string)Session["NomeImg"];
        Session["NomeImg"] = null;

        Bitmap bnn = System.Drawing.Image.FromFile(sImgFile) as Bitmap;
        bnn.Save(Server.MapPath("~/Admin/Banner/") + sNomeImg);
        bnn.Dispose();

        //Limpa Lixo
        File.Delete(sImgFile);

        //Salva o caminho da imagem no banco de dados
        bll = new classeBLL();
        try
        {

            bll.AtualisaBanner((string)Session["CarregaUsuario"],
                                "~/Admin/Banner/" + sNomeImg,
                                int.Parse(Session["Banner"].ToString()));
            Session["Banner"] = null;

            SelecionaEmpresaPorUsuario((string)Session["CarregaUsuario"]);
            btnNovoRegistro.Visible = false;
            btnFotos.Enabled = false;
            btnCadastro.Enabled = true;
            btnSubDivisoes.Enabled = true;
            btnEnviar.Visible = false;
            pnlCadastro.Visible = false;
            pnlCutImagem.Visible = false;
            pnlFoto.Visible = true;
            pnlSubDivisoes.Visible = false;
            lblMensagem.Text = "";
        }
        catch (Exception ex)
        {
            bll.EnviarErros(ex.Message.ToString());
        }

    }   
    protected void btnExcluir1_Click1(object sender, EventArgs e)
    {
        if (imgBanner1.ImageUrl == null || imgBanner1.ImageUrl == string.Empty)
            ShowMessageBox("Não há imagem para ser excluída no Banner 01!");
        else
        {
            ExcluirBanner(1);
        }
    }
    protected void btnExcluir2_Click(object sender, EventArgs e)
    {
        if (imgBanner2.ImageUrl == null || imgBanner2.ImageUrl == string.Empty)
            ShowMessageBox("Não há imagem para ser excluída no Banner 02!");
        else
            ExcluirBanner(2);
    }
    protected void btnExcluir3_Click(object sender, EventArgs e)
    {
        if (imgBanner3.ImageUrl == null || imgBanner3.ImageUrl == string.Empty)
            ShowMessageBox("Não há imagem para ser excluída no Banner 03!");
        else
            ExcluirBanner(3);
    }
    protected void btnExcluir4_Click(object sender, EventArgs e)
    {
        if (imgBanner4.ImageUrl == null || imgBanner4.ImageUrl == string.Empty)
            ShowMessageBox("Não há imagem para ser excluída no Banner 04!");
        else
        ExcluirBanner(4);
    }
    protected void ExcluirBanner(int i)
    {
        bll = new classeBLL();    
        try
        {
            bll.ExcluiBanner((string)Session["Usuario"], i);
            Page.Response.Redirect("cadastro_empresa.aspx");
        }
        catch (Exception ex)
        {
            bll.EnviarErros(ex.Message.ToString());
        } 
    }
    protected void btnNovoRegistro_Click(object sender, EventArgs e)
    {
        bll = new BLL.classeBLL();
        LimpaControles();

        try
        {
            Usuario us = new Usuario();
            us = bll.GeraNovoUsuario();
            txtUsuario.Text = us.usuario;            
            lblMensagem.Text = "<b>Novo Usuário e nova Senha gerados com sucesso.</b>";
            
        }
        catch (Exception ex)
        {
            bll.EnviarErros(ex.Message.ToString());
        }
    }
    protected void LimpaControles()
    {
        txtUsuario.Text = "";
        txtNomePrimario.Text = "";
        txtNomeSecundario.Text = "";
        txtAutoCompelte.Text = "";
        txtRamoAtividade.Text = "";
        txtEndereco.Text = "";
        txtBairro.Text = "";
        dpdCidade.Text = "";
        dpdEstado.Text = "";
        txtCNPJ.Text = "";
        txtCEP.Text = "";
        txtTelefone1.Text = "";
        txtTelefone2.Text = "";
        txtTelefone3.Text = "";
        txtTelefone4.Text = "";
        txtEmail.Text = "";
        txtSite.Text = "";
        txtPalavrasComercial.Text = "";
        imgBanner1.ImageUrl = "";
        imgBanner2.ImageUrl = "";
        imgBanner3.ImageUrl = "";
        imgBanner4.ImageUrl = "";
        txtDataCadastro.Text = "";
        rblAtivo.SelectedIndex = 0;
        rblPrioridade.SelectedIndex = 0;

       
        txtSubDivisao1.Text = "";
        txtSiteSubDivisao1.Text = "";
        txtTelefoneSubDivisao1.Text = "";
        txtAtividadesSubDivisao1.Text = "";
        txtSubDivisao2.Text = "";
        txtSiteSubDivisao2.Text = "";
        txtTelefoneSubDivisao2.Text = "";
        txtAtividadesSubDivisao2.Text = "";
        txtSubDivisao3.Text = "";
        txtSiteSubDivisao3.Text = "";
        txtTelefoneSubDivisao3.Text = "";
        txtAtividadesSubDivisao3.Text = "";
        txtSubDivisao4.Text = "";
        txtSiteSubDivisao4.Text = "";
        txtTelefoneSubDivisao4.Text = "";
        txtAtividadesSubDivisao4.Text = "";
        txtSubDivisao5.Text = "";
        txtSiteSubDivisao5.Text = "";
        txtTelefoneSubDivisao5.Text = "";
        txtAtividadesSubDivisao5.Text = "";
        txtSubDivisao6.Text = "";
        txtSiteSubDivisao6.Text = "";
        txtTelefoneSubDivisao6.Text = "";
        txtAtividadesSubDivisao6.Text = "";
    }
    protected void btnCadastro_Click(object sender, EventArgs e)
    {
        btnCadastro.Enabled = false;
        if (HttpContext.Current.User.Identity.Name.ToString() != "admin"
            || Session["Usuario"].ToString() !="admin")//se não for admin fecha a seção e redireciona para o login
             btnNovoRegistro.Visible = false;
        else
            btnNovoRegistro.Visible = true;
        
        btnSubDivisoes.Enabled = true;
        btnFotos.Enabled = true;
        btnEnviar.Visible = true;
        pnlCadastro.Visible = true;
        pnlCutImagem.Visible = false;
        pnlFoto.Visible = false;
        pnlSubDivisoes.Visible = false;
        lblMensagem.Text = "";
    }
    protected void btnSubDivisoes_Click(object sender, EventArgs e)
    {
        btnNovoRegistro.Visible = false;
        btnSubDivisoes.Enabled = false;
        btnCadastro.Enabled = true;
        btnFotos.Enabled = true;
        btnEnviar.Visible = true;
        pnlCadastro.Visible = false;
        pnlCutImagem.Visible = false;
        pnlFoto.Visible = false;
        pnlSubDivisoes.Visible = true;
        lblMensagem.Text = "";
    }
    protected void btnFotos_Click(object sender, EventArgs e)
    {
        btnNovoRegistro.Visible = false;
        btnFotos.Enabled = false;
        btnCadastro.Enabled = true;
        btnSubDivisoes.Enabled = true;
        btnEnviar.Visible = false;
        pnlCadastro.Visible = false;
        pnlCutImagem.Visible = false;
        pnlFoto.Visible = true;
        pnlSubDivisoes.Visible = false;
        lblMensagem.Text = "";
    }

   
}
