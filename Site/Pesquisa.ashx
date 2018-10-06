<%@ WebHandler Language="C#" Class="Pesquisa" %>

using System;
using System.Web;

using MySql.Data.MySqlClient;
using System.Configuration;
using System.Text;

public class Pesquisa : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        string PrefixText =context.Request.QueryString["q"] ;
        using (MySqlConnection con = new MySqlConnection())
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["ListaBemConnectionString"].ConnectionString;
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = "SELECT AutoComplete FROM Empresas WHERE AutoComplete LIKE CONCAT(@Pesquisar, '%') LIMIT 0,8";
                cmd.Parameters.AddWithValue("@Pesquisar", PrefixText);
                cmd.Connection = con;
                StringBuilder sb = new StringBuilder();
                con.Open();
                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        sb.Append(dr["AutoComplete"]).Append(Environment.NewLine);
                    }
                }
                con.Close();
                context.Response.Write(sb.ToString());
            }
        }
        
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}