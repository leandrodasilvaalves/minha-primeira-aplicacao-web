using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Data;
// name spaces para enviar email--
using System.Net.Mail;
using System.Net.Mime;
using System.Net.Configuration;
using System.Net;
using System.Text;
//-------------------------------

using EMP;
using USER;
using CONTATO;

namespace DAL
{
    public class classeDAL
    {
        string strCon = ConfigurationManager.ConnectionStrings["ListaBemConnectionString"].ConnectionString.ToString();


        public void UpdateEmpresa(Empresa e)
        {
            string sqlUpdate = ConfigurationManager.AppSettings["sqlUpdate"].ToString();
            MySqlConnection con = new MySqlConnection(strCon);
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(sqlUpdate, con);
                cmd.Parameters.AddWithValue("@Usuario", e.Usuario);
                cmd.Parameters.AddWithValue("@NomePrimario", e.NomePrimario);
                cmd.Parameters.AddWithValue("@NomeSecundario", e.NomeSecundario);
                cmd.Parameters.AddWithValue("@AutoComplete", e.AutoComplete);
                cmd.Parameters.AddWithValue("@RamoAtividade", e.RamoAtividade);
                cmd.Parameters.AddWithValue("@Endereco", e.Endereco);
                cmd.Parameters.AddWithValue("@Bairro", e.Bairro);
                cmd.Parameters.AddWithValue("@Cidade", e.Cidade);
                cmd.Parameters.AddWithValue("@Estado", e.Estado);
                cmd.Parameters.AddWithValue("@CNPJ", e.CNPJ);
                cmd.Parameters.AddWithValue("@CEP", e.CEP);
                cmd.Parameters.AddWithValue("@Telefone1", e.Tel1);
                cmd.Parameters.AddWithValue("@Telefone2", e.Tel2);
                cmd.Parameters.AddWithValue("@Telefone3", e.Tel3);
                cmd.Parameters.AddWithValue("@Telefone4", e.Tel4);
                cmd.Parameters.AddWithValue("@Email", e.Email);
                cmd.Parameters.AddWithValue("@Site", e.Site);
                cmd.Parameters.AddWithValue("@Prioridade", e.Prioridade);
                cmd.Parameters.AddWithValue("@Ativo", e.Ativo);
                cmd.Parameters.AddWithValue("@ChaveComercial", e.PalavrasCom);

                cmd.Parameters.AddWithValue("@SubDivisao1", e.subDivisao1);
                cmd.Parameters.AddWithValue("@SiteSubDivisao1", e.siteSubDivisao1);
                cmd.Parameters.AddWithValue("@TelefoneSubDivisao1", e.TelefoneSuDivisao1);
                cmd.Parameters.AddWithValue("@AtividadesSubDivisao1", e.AtividadesSubDivisao1);
                cmd.Parameters.AddWithValue("@SubDivisao2", e.subDivisao2);
                cmd.Parameters.AddWithValue("@SiteSubDivisao2", e.siteSubDivisao2);
                cmd.Parameters.AddWithValue("@TelefoneSubDivisao2", e.TelefoneSuDivisao2);
                cmd.Parameters.AddWithValue("@AtividadesSubDivisao2", e.AtividadesSubDivisao2);
                cmd.Parameters.AddWithValue("@SubDivisao3", e.subDivisao3);
                cmd.Parameters.AddWithValue("@SiteSubDivisao3", e.siteSubDivisao3);
                cmd.Parameters.AddWithValue("@TelefoneSubDivisao3", e.TelefoneSuDivisao3);
                cmd.Parameters.AddWithValue("@AtividadesSubDivisao3", e.AtividadesSubDivisao3);
                cmd.Parameters.AddWithValue("@SubDivisao4", e.subDivisao4);
                cmd.Parameters.AddWithValue("@SiteSubDivisao4", e.siteSubDivisao4);
                cmd.Parameters.AddWithValue("@TelefoneSubDivisao4", e.TelefoneSuDivisao4);
                cmd.Parameters.AddWithValue("@AtividadesSubDivisao4", e.AtividadesSubDivisao4);
                cmd.Parameters.AddWithValue("@SubDivisao5", e.subDivisao5);
                cmd.Parameters.AddWithValue("@SiteSubDivisao5", e.siteSubDivisao5);
                cmd.Parameters.AddWithValue("@TelefoneSubDivisao5", e.TelefoneSuDivisao5);
                cmd.Parameters.AddWithValue("@AtividadesSubDivisao5", e.AtividadesSubDivisao5);
                cmd.Parameters.AddWithValue("@SubDivisao6", e.subDivisao6);
                cmd.Parameters.AddWithValue("@SiteSubDivisao6", e.siteSubDivisao6);
                cmd.Parameters.AddWithValue("@TelefoneSubDivisao6", e.TelefoneSuDivisao6);
                cmd.Parameters.AddWithValue("@AtividadesSubDivisao6", e.AtividadesSubDivisao6);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
        }
        public Usuario Login(int tb, Usuario u)
        {
            /*Este médto (funcao) recebe o inteiro (tb)
              para verificar em qual tabela buscar os dados            
             */
            string tabela = "";
            string sql = "";

            if (tb == 1)
                tabela = "Admin";
            else
                tabela = "Empresas";

            sql = "SELECT Usuario, Senha, UserTemp FROM " + tabela + " WHERE (Usuario=@Usuario) AND (Senha=@senha) AND (Ativo=1)";

            MySqlConnection con = new MySqlConnection(strCon);
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Usuario", u.usuario);
                cmd.Parameters.AddWithValue("@senha", u.Senha);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();

                USER.Usuario user = new USER.Usuario();
                while (dr.Read())
                {
                    user.usuario = dr.GetString("Usuario");
                    user.Senha = dr.GetString("Senha");
                    user.UserTemp = dr.GetInt32("UserTemp");
                }
                return user;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }

        }
        public Usuario GerarUsuario()
        {
        inicio:

            string[] ch = new string[26];
            ch[0] = "A"; ch[1] = "B"; ch[2] = "C"; ch[3] = "D"; ch[4] = "E";
            ch[5] = "F"; ch[6] = "G"; ch[7] = "H"; ch[8] = "I"; ch[9] = "J";
            ch[10] = "K"; ch[11] = "L"; ch[12] = "M"; ch[13] = "N"; ch[14] = "O";
            ch[15] = "P"; ch[16] = "Q"; ch[17] = "R"; ch[18] = "S"; ch[19] = "T";
            ch[20] = "U"; ch[21] = "V"; ch[22] = "W"; ch[23] = "X"; ch[24] = "Y";
            ch[25] = "Z";

            try
            {
                Random rnd = new Random();
                string Usuario = "";
                string senha = "";

                while (Usuario.Length <= 6)
                {
                    Usuario = Usuario + rnd.Next(0, 9).ToString();
                    Usuario = Usuario + ch[rnd.Next(0, 25)];
                }

                while (senha.Length <= 6)
                {
                    senha = senha + rnd.Next(0, 9).ToString();
                    senha = senha + ch[rnd.Next(0, 25)];
                }

                if (VerificarUsuario(Usuario) > 0)
                {
                    //("Existe um codigo igual esse na tabela");
                    goto inicio;
                }
                else
                {
                    IncluiUsuario(Usuario, senha);
                    Usuario u = new Usuario();
                    u.usuario = Usuario;
                    u.Senha = senha;
                    return u;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
        protected void IncluiUsuario(string Usuario, string Senha)//Usado para gerar usuario
        {
            MySqlConnection con = new MySqlConnection(strCon);
            string sql = string.Empty;
            try
            {
                con.Open();
                sql = "INSERT INTO Empresas (Usuario, UserTemp, Senha, DataCadastro, Prioridade, Ativo) VALUES (@Usuario, @UserTemp, @Senha, @DataCad, @Prio, @Ativo)";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Usuario", Usuario);
                cmd.Parameters.AddWithValue("@UserTemp", 1);
                cmd.Parameters.AddWithValue("@Senha", Senha);
                cmd.Parameters.AddWithValue("@DataCad", DateTime.Today.ToShortDateString());
                cmd.Parameters.AddWithValue("@Prio", 0);
                cmd.Parameters.AddWithValue("@Ativo", 1);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }

        }
        protected int VerificarUsuario(string Usuario)//Usado para gerar usuario
        {
            string sql = string.Empty;
            MySqlConnection con = new MySqlConnection(strCon);
            try
            {
                sql = "SELECT COUNT(Usuario) FROM Empresas WHERE Usuario ='" + Usuario + "'";
                con.Open();
                MySqlCommand cmd = new MySqlCommand(sql, con);
                return int.Parse(cmd.ExecuteScalar().ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }

        }
        public void UpdateUsuario(string Usuario, string NewUser)
        {
            MySqlConnection con = new MySqlConnection(strCon);
            string sql = "UPDATE Empresas SET Usuario=@NewUser, UserTemp=0 WHERE Usuario=@Usuario";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Usuario", Usuario);
                cmd.Parameters.AddWithValue("@NewUser", NewUser);
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
        }
        public int ExistUsuario(string Usuario)
        {
            MySqlConnection con = new MySqlConnection(strCon);
            string Sql = "SELECT COUNT(Usuario) FROM Empresas WHERE Usuario=@Usuario";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(Sql, con);
                cmd.Parameters.AddWithValue("@Usuario", Usuario);
                return int.Parse(cmd.ExecuteScalar().ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
        }
        public bool VerificaSeUsuarioTemp(string usuario)
        {
            MySqlConnection con = new MySqlConnection(strCon);
            string Sql = "SELECT UserTemp FROM Empresas WHERE Usuario=@Usuario";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(Sql, con);
                cmd.Parameters.AddWithValue("@Usuario", usuario);
                MySqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                if (dr.GetInt32("UserTemp") == 0) //se for permanente
                    return false;
                else
                    return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
        }
        public DataTable ListarEmpresas()
        {
            MySqlConnection con = new MySqlConnection(strCon);
            string sqlSelect = ConfigurationManager.AppSettings["sqlListarEmpresas"].ToString();
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(sqlSelect, con);
                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
        }
        public void DeleteEmpresa(Empresa e)
        {
            MySqlConnection con = new MySqlConnection(strCon);
            try
            {
                string sqlDeleteEmpresa = ConfigurationManager.AppSettings["sqlDeleteEmpresa"].ToString();
                MySqlCommand cmd = new MySqlCommand(sqlDeleteEmpresa, con);
                cmd.Parameters.AddWithValue("@Usuario", e.Usuario);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
        }
        public Empresa SelecionaEmpresaPorUsuario(string Us)
        {
            Empresa emp = new Empresa();
            MySqlConnection con = new MySqlConnection(strCon);
            try
            {
                string sql = ConfigurationManager.AppSettings["sqlSelecionaEmpresaPorUsuario"].ToString();
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Usuario", Us);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read())
                {

                    if (!dr.IsDBNull(0))
                        emp.ID = int.Parse(dr.GetString("ID"));
                    if (!dr.IsDBNull(1))
                        emp.Usuario = dr.GetString("Usuario");
                    if (!dr.IsDBNull(4))
                        emp.NomePrimario = dr.GetString("NomePrimario");
                    if (!dr.IsDBNull(5))
                        emp.NomeSecundario = dr.GetString("NomeSecundario");
                    if (!dr.IsDBNull(6))
                        emp.RamoAtividade = dr.GetString("RamoAtividade");
                    if (!dr.IsDBNull(7))
                        emp.Endereco = dr.GetString("Endereco");
                    if (!dr.IsDBNull(8))
                        emp.Bairro = dr.GetString("Bairro");
                    if (!dr.IsDBNull(9))
                        emp.Estado = dr.GetString("Estado");
                    if (!dr.IsDBNull(10))
                        emp.Cidade = dr.GetString("Cidade");                   
                    if (!dr.IsDBNull(11))
                        emp.CNPJ = dr.GetString("CNPJ");
                    if (!dr.IsDBNull(12))
                        emp.CEP = dr.GetString("CEP");
                    if (!dr.IsDBNull(13))
                        emp.Tel1 = dr.GetString("Telefone1");
                    if (!dr.IsDBNull(14))
                        emp.Tel2 = dr.GetString("Telefone2");
                    if (!dr.IsDBNull(15))
                        emp.Tel3 = dr.GetString("Telefone3");
                    if (!dr.IsDBNull(16))
                        emp.Tel4 = dr.GetString("Telefone4");
                    if (!dr.IsDBNull(17))
                        emp.Email = dr.GetString("Email");
                    if (!dr.IsDBNull(18))
                        emp.Site = dr.GetString("Site");
                    if (!dr.IsDBNull(19))
                        emp.Prioridade = int.Parse(dr.GetString("Prioridade"));
                    if (!dr.IsDBNull(20))
                        emp.Ativo = int.Parse(dr.GetString("Ativo"));
                    if (!dr.IsDBNull(21))
                        emp.PalavrasCom = dr.GetString("ChaveComercial");
                    if (!dr.IsDBNull(22))
                        emp.DataCadastro = dr.GetString("DataCadastro");
                    if (!dr.IsDBNull(23))
                        emp.Banner1 = dr.GetString("Banner1");
                    if (!dr.IsDBNull(24))
                        emp.Banner2 = dr.GetString("Banner2");
                    if (!dr.IsDBNull(25))
                        emp.Banner3 = dr.GetString("Banner3");
                    if (!dr.IsDBNull(26))
                        emp.Banner4 = dr.GetString("Banner4");
                    
                    
                    if (!dr.IsDBNull(27))
                        emp.subDivisao1 = dr.GetString("SubDivisao1");
                    if (!dr.IsDBNull(28))
                        emp.siteSubDivisao1 = dr.GetString("SiteSubDivisao1");
                    if (!dr.IsDBNull(29))
                        emp.TelefoneSuDivisao1 = dr.GetString("TelefoneSubDivisao1");
                    if (!dr.IsDBNull(30))
                        emp.AtividadesSubDivisao1 = dr.GetString("AtividadesSubDivisao1");

                    if (!dr.IsDBNull(31))
                        emp.subDivisao2 = dr.GetString("SubDivisao2");
                    if (!dr.IsDBNull(32))
                        emp.siteSubDivisao2 = dr.GetString("SiteSubDivisao2");
                    if (!dr.IsDBNull(33))
                        emp.TelefoneSuDivisao2 = dr.GetString("TelefoneSubDivisao2");
                    if (!dr.IsDBNull(34))
                        emp.AtividadesSubDivisao2 = dr.GetString("AtividadesSubDivisao2");

                    if (!dr.IsDBNull(35))
                        emp.subDivisao3 = dr.GetString("SubDivisao3");
                    if (!dr.IsDBNull(36))
                        emp.siteSubDivisao3 = dr.GetString("SiteSubDivisao3");
                    if (!dr.IsDBNull(37))
                        emp.TelefoneSuDivisao3 = dr.GetString("TelefoneSubDivisao3");
                    if (!dr.IsDBNull(38))
                        emp.AtividadesSubDivisao3 = dr.GetString("AtividadesSubDivisao3");

                    if (!dr.IsDBNull(39))
                        emp.subDivisao4 = dr.GetString("SubDivisao4");
                    if (!dr.IsDBNull(40))
                        emp.siteSubDivisao4 = dr.GetString("SiteSubDivisao4");
                    if (!dr.IsDBNull(41))
                        emp.TelefoneSuDivisao4 = dr.GetString("TelefoneSubDivisao4");
                    if (!dr.IsDBNull(42))
                        emp.AtividadesSubDivisao4 = dr.GetString("AtividadesSubDivisao4");

                    if (!dr.IsDBNull(43))
                        emp.subDivisao5 = dr.GetString("SubDivisao5");
                    if (!dr.IsDBNull(44))
                        emp.siteSubDivisao5 = dr.GetString("SiteSubDivisao5");
                    if (!dr.IsDBNull(45))
                        emp.TelefoneSuDivisao5 = dr.GetString("TelefoneSubDivisao5");
                    if (!dr.IsDBNull(46))
                        emp.AtividadesSubDivisao5 = dr.GetString("AtividadesSubDivisao5");

                    if (!dr.IsDBNull(47))
                        emp.subDivisao6 = dr.GetString("SubDivisao6");
                    if (!dr.IsDBNull(48))
                        emp.siteSubDivisao6 = dr.GetString("SiteSubDivisao6");
                    if (!dr.IsDBNull(49))
                        emp.TelefoneSuDivisao6 = dr.GetString("TelefoneSubDivisao6");
                    if (!dr.IsDBNull(50))
                        emp.AtividadesSubDivisao6 = dr.GetString("AtividadesSubDivisao6");
                    if (!dr.IsDBNull(51))
                        emp.AutoComplete = dr.GetString("AutoComplete");
                }
                return emp;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
        }
        public DataTable SelecionaEmpresa_pnl_Control(string buscar, int op)
        {
            MySqlConnection con = new MySqlConnection(strCon);
            string strSQL = string.Empty;
            string cmdSql = string.Empty;
            switch (op)
            {
                case 0:
                    strSQL = "sqlPesquisarTodosCampos";
                    break;
                case 1:
                    strSQL = "sqlPesquisarUsuario";
                    break;
                case 2:
                    strSQL = "sqlPesquisarNomePrimario";
                    break;
                case 3:
                    strSQL = "sqlPesquisarNomeSecundario";
                    break;
                case 4:
                    strSQL = "sqlPesquisarPrioridade";
                    break;
            }

            try
            {
                con.Open();
                cmdSql = ConfigurationManager.AppSettings[strSQL].ToString();
                MySqlCommand cmd = new MySqlCommand(cmdSql, con);
                cmd.Parameters.AddWithValue("@buscar", "%" + buscar + "%");
                MySqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }


        }       
        public void UpdateBanner(string Us, string caminho_Banner, int i)
        {
            MySqlConnection con = new MySqlConnection(strCon);
            string sql = "UPDATE Empresas SET Banner" + i + "=@Banner WHERE Usuario=@Usuario";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Usuario", Us);
                cmd.Parameters.AddWithValue("@Banner", caminho_Banner);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }

        }
        public void DeleteBanner(string Us, int i)
        {
            //insere 0 zero no lugar do caminho do banner
            MySqlConnection con = new MySqlConnection(strCon);
            string sql = "UPDATE Empresas SET Banner" + i + "='0' WHERE Usuario=@Usuario";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Usuario", Us);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
        }
        public void EnviarErros(string Erro)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.Subject = "Erro - LISTA BEM: " + System.DateTime.Now.ToString();
                mail.To.Add("listabem.erros@gmail.com");
                mail.From = new MailAddress("listabem.erros@gmail.com");
                mail.Body = Erro;
                SmtpClient SMTP = new SmtpClient("smtp.gmail.com");
                NetworkCredential cred = new NetworkCredential("listabem.erros@gmail.com", "listaserv");
                SMTP.Credentials = cred;
                SMTP.Port = 587;
                SMTP.Send(mail);
            }
            catch
            {
                //nao faz nada
            }
        }       
        public void EnviarContatos(CONTATO.classeContatos co)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.Subject = "Contato - LISTA BEM: " + co.Nome;
                mail.To.Add("contato@listabem.com");
                mail.From = new MailAddress("contato@listabem.com");
                mail.IsBodyHtml = true;
                mail.SubjectEncoding = Encoding.GetEncoding("ISO-8859-1");
                mail.BodyEncoding = Encoding.GetEncoding("ISO-8859-1");
                mail.Body = "<font color=blue>" + co.Site + 
                            "<br/>" + co.Email + "</font>" +
                            "<br/><font color=green>" + System.DateTime.Now.ToString() + "</font>" +
                            "<br/><br/>" + co.Mensagem;
                SmtpClient SMTP = new SmtpClient("smtp.listabem.com");
                NetworkCredential cred = new NetworkCredential("contato@listabem.com", "lb22859822");
                SMTP.Credentials = cred;
                SMTP.Port = 587;
                SMTP.Send(mail);
            }
            catch//(Exception ex)
            {
                //throw ex;
            }
        }
        private void EnviaSenha(USER.Usuario Us)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.Subject = "LISTA BEM: Recuperação de senha";
                mail.To.Add(Us.Email);
                mail.From = new MailAddress("contato@listabem.com");
                mail.IsBodyHtml = true;
                mail.SubjectEncoding = Encoding.GetEncoding("ISO-8859-1");
                mail.BodyEncoding = Encoding.GetEncoding("ISO-8859-1");
                mail.Body = "Olá, conforme a solicitação feita pelo usuário <b>" + Us.usuario + "</b> em nosso sistema, " +
                            "estamos reenviando a sua senha de acesso ao LISTA BEM." +
                            "<br/><br/><font color=blue>Usuário: " + Us.usuario +
                            "<br/>Senha: " + Us.Senha +
                            "<br/>E-mail: " + Us.Email + 
                            "<br/>CNPJ: " + Us.CNPJ + "</font>" +
                            "<br/><font color=green>" + System.DateTime.Now.ToString() + "</font>" +
                            "<br/><br/> Esta mensagem foi enviada automaticamente. Favor não responder.";
                SmtpClient SMTP = new SmtpClient("smtp.listabem.com");
                NetworkCredential cred = new NetworkCredential("contato@listabem.com", "lb22859822");
                SMTP.Credentials = cred;
                SMTP.Port = 587;
                SMTP.Send(mail);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool RecuperaSenha(EMP.Empresa emp)
        {
            string sql = ConfigurationManager.AppSettings["sqlRecuperaEmail"].ToString();
            MySqlConnection con = new MySqlConnection(strCon);
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand (sql,con);
                cmd.Parameters.AddWithValue("@Usuario",emp.Usuario);
                cmd.Parameters.AddWithValue("@Email",emp.Email);
                cmd.Parameters.AddWithValue("@CNPJ",emp.CNPJ);
                MySqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                int count = 0;

                USER.Usuario objUsuario = new USER.Usuario();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        objUsuario.usuario = dr.GetString("Usuario");
                        objUsuario.Email= dr.GetString("Email");
                        objUsuario.CNPJ= dr.GetString("CNPJ");
                        objUsuario.Senha = dr.GetString("Senha");
                        count += 1;
                    }
                    if (count !=1)
                        return false;
                    else
                    {
                        if (objUsuario.usuario == emp.Usuario &&
                            objUsuario.Email == emp.Email &&
                            objUsuario.CNPJ == emp.CNPJ)
                        {
                            EnviaSenha(objUsuario);
                            return true;
                        }
                        else
                            return false;
                        
                    }
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }

        }
        public void UpdateSenha(int tb, string Usuario, string NewPassword)
        {
            MySqlConnection con = new MySqlConnection(strCon);

            string tabela = "";
            if (tb == 1)
                tabela = "Admin";
            else
                tabela = "Empresas";

            string sql = "UPDATE " + tabela + " SET Senha=@NewPassword WHERE Usuario=@Usuario";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Usuario", Usuario);
                cmd.Parameters.AddWithValue("@NewPassword", NewPassword);
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
        }   
        public DataTable SearchListaBem(string Buscar, int Inicio, int Procedure)
        {
            MySqlConnection con = new MySqlConnection(strCon);
            int TamanhoPg = int.Parse(ConfigurationManager.AppSettings["TamanhoPaginaPesquisa"].ToString());
            string strProcedure = string.Empty;
            if (Procedure == 1)
                strProcedure = "PesquisaListaBem";
            else if (Procedure == 2)
                strProcedure = "PesquisaListaBem2";/* Esta pesquisa será usada quando a primeira pesquina não encontrar nenhum resultado.
                                                      Então está pesquisa retornará resultados cuja primeira letra coincide com a primeira
                                                      letra da pesquisa. */

            try
            {
                con.Open();
                //MySqlCommand cmd = new MySqlCommand(strProcedure, con);
                MySqlCommand cmd = new MySqlCommand("SearchListaBem", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("buscar", Buscar);
                cmd.Parameters.AddWithValue("IncioPg", Inicio);
                cmd.Parameters.AddWithValue("TamanhoPg", TamanhoPg);
                DataTable dt = new DataTable();
                MySqlDataReader dr = cmd.ExecuteReader();
                dt.Load(dr);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }

        }
        public long ContaRegistrosPesquisa(string Buscar)
        {
            MySqlConnection con = new MySqlConnection(strCon);
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("ContPesquisaListaBem", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("buscar", Buscar);
                return long.Parse(cmd.ExecuteScalar().ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
        }
        public List<string> SearchAutoComplete(string prefixText, int count)
        {
            using (MySqlConnection conn = new MySqlConnection())
            {
                conn.ConnectionString = ConfigurationManager
                        .ConnectionStrings["ListaBemConnectionString"].ConnectionString;
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.CommandText = "SELECT AutoComplete FROM Empresas WHERE " +
                    "AutoComplete LIKE CONCAT (@SearchText, '%')";
                    cmd.Parameters.AddWithValue("@SearchText", prefixText);
                    cmd.Connection = conn;
                    conn.Open();
                    List<string> customers = new List<string>();
                    using (MySqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            customers.Add(sdr["AutoComplete"].ToString());
                        }
                    }
                    conn.Close();
                    return customers;
                }
            }
        }

    }
}