using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Usuario
/// </summary>
namespace USER
{
    public class Usuario
    {
        int _id;
        string _usuario;
        string _senha;
        string _email;
        string _CNPJ;
        int _userTemp = 0;
       
        public int  ID
        {
            get { return _id; }
            set{_id =value; }
        }
        public string usuario
        {
            get { return _usuario; }
            set { _usuario = value; }
        }

        public string Senha
        {
            get { return _senha; }
            set { _senha = value; }
        }
        public int UserTemp
        {
            get { return _userTemp; }
            set { _userTemp = value; }
        }
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public string CNPJ
        {
            get { return _CNPJ; }
            set { _CNPJ = value; }
        }
       
    }
}