using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using EMP;
//
// Esta classe valida dados para previnir a injeção SQL
//
namespace SQLinject
{
    public class classeSQLinject
    {
        
    //Esta função faz uma varredura nos dados informados pelo
    //usário e verifica se há entrada de dados maliciosos, por exemplo, 
    //injeção SQL. Caso, sim ele retorna um TRUE dizendo que há lixo.
    
        public bool InjecaoSQL(string strUser, string strSenha)//login
        {
            bool  isLixo = false; // false = (nao lixo); true = (lixo);

            string[] lixo = new string[10];
            lixo[0] = "Select"; lixo[1] = "drop"; lixo[2] = ";"; lixo[3] = "--";
            lixo[4] = "insert"; lixo[5] = "delete"; lixo[6] = "xp-"; lixo[7] = "'";
            lixo[8] = "/*...*/"; lixo[9] = "update";

            strUser = strUser.ToUpper();
            strSenha = strSenha.ToUpper();
            try
            {
                for (int i = 0; i <= 9; i++)                {
                    
                    if (((strUser.IndexOf(lixo[i], 0, System.StringComparison.OrdinalIgnoreCase) + 1) != 0) 
                        || ((strSenha.IndexOf(lixo[i], 0, System.StringComparison.OrdinalIgnoreCase) + 1) != 0))
                    {
                        isLixo = true;
                        break;
                    }
                }
                return isLixo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool InjecaoSQLRecuperaSenha(EMP.Empresa e)//Recupera Senha
        {
            bool isLixo = false; // false = (nao lixo); true = (lixo);

            string[] lixo = new string[10];
            lixo[0] = "Select"; lixo[1] = "drop"; lixo[2] = ";"; lixo[3] = "--";
            lixo[4] = "insert"; lixo[5] = "delete"; lixo[6] = "xp-"; lixo[7] = "'";
            lixo[8] = "/*...*/"; lixo[9] = "update";

            string strUser = e.Usuario.ToUpper();
            string strEmail = e.Email.ToUpper();
            string strCNPJ = e.CNPJ.ToUpper();
            try
            {
                for (int i = 0; i <= 9; i++)
                {

                    if (((strUser.IndexOf(lixo[i], 0, System.StringComparison.OrdinalIgnoreCase) + 1) != 0)
                        || ((strEmail.IndexOf(lixo[i], 0, System.StringComparison.OrdinalIgnoreCase) + 1) != 0)
                        || ((strCNPJ.IndexOf(lixo[i], 0, System.StringComparison.OrdinalIgnoreCase) + 1) != 0))
                    {
                        isLixo = true;
                        break;
                    }
                }
                return isLixo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }          
    }
}