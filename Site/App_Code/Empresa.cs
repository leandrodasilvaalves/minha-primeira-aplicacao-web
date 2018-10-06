using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EMP
{
    public class Empresa
    {
        int _ID;
        string _Usuario;
        string _nomePrimario;
        string _nomeSecundario;
        string _ramoAtividade;
        string _AutoComplete;
        string _endereco;
        string _bairro;
        string _cidade;
        string _estado;
        string _CNPJ;
        string _CEP;
        string _tel1;
        string _tel2;
        string _tel3;
        string _tel4;
        string _email;
        string _site;
        string _palavrasCom;
        string _banner1;
        string _banner2;
        string _banner3;
        string _banner4;
        int _ativo;
        int _prioridade;
        string _dataCad;

        string _subDivisao1;
        string _siteSubDivisao1;
        string _TelefoneSuDivisao1;
        string _AtividadesSubDivisao1;

        string _subDivisao2;
        string _siteSubDivisao2;
        string _TelefoneSuDivisao2;
        string _AtividadesSubDivisao2;

        string _subDivisao3;
        string _siteSubDivisao3;
        string _TelefoneSuDivisao3;
        string _AtividadesSubDivisao3;

        string _subDivisao4;
        string _siteSubDivisao4;
        string _TelefoneSuDivisao4;
        string _AtividadesSubDivisao4;

        string _subDivisao5;
        string _siteSubDivisao5;
        string _TelefoneSuDivisao5;
        string _AtividadesSubDivisao5;

        string _subDivisao6;
        string _siteSubDivisao6;
        string _TelefoneSuDivisao6;
        string _AtividadesSubDivisao6;

        public int  ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        public string Usuario
        {
            get { return _Usuario; }
            set { _Usuario = value; }
        }
        public string NomePrimario
        {
            get {
                if (_nomePrimario == null)
                    return string.Empty;
                else
                return _nomePrimario; }
            set { _nomePrimario = value; }
        }
        public string NomeSecundario
        {
            get
            {
                if (_nomeSecundario == null)
                    return string.Empty;
                else
                    return _nomeSecundario;
            }
            set { _nomeSecundario = value; }
        }
        public string AutoComplete
        {
            get
            {
                if (_AutoComplete == null)
                    return string.Empty;
                else
                    return _AutoComplete;
            }
            set { _AutoComplete = value; }
        }

        public string RamoAtividade
        {
            get
            {
                if (_ramoAtividade == null)
                    return string.Empty;
                else
                return _ramoAtividade; }
            set { _ramoAtividade = value; }
        }
        public string Endereco
        {
            get
            {
                if (_endereco == null)
                    return string.Empty;
                else
                return _endereco; }
            set { _endereco = value; }
        }
        public string Bairro
        {
            get
            {
                if (_bairro == null)
                    return string.Empty;
                else
                return _bairro; }
            set { _bairro = value; }
        }
        public string Cidade
        {
            get
            {
                if (_cidade == null)
                    return string.Empty;
                else
                return _cidade; }
            set { _cidade = value; }
        }
        public string Estado
        {
            get
            {
                if (_estado == null)
                    return string.Empty;
                else
                return _estado; }
            set { _estado = value; }
        }
        public string CNPJ
        {
            get
            {
                if (_CNPJ == null)
                    return string.Empty;
                else
                return _CNPJ; }
            set { _CNPJ = value; }
        }
        public string CEP
        {
            get
            {
                if (_CEP == null)
                    return string.Empty;
                else
                    return _CEP;
            }
            set { _CEP = value; }
        }
        public string Tel1
        {
            get
            {
                if (_tel1 == null)
                    return string.Empty;
                else
                return _tel1; }
            set { _tel1 = value; }

        }
        public string Tel2
        {
            get
            {
                if (_tel2 == null)
                    return string.Empty;
                else
                return _tel2; }
            set { _tel2 = value; }

        }
        public string Tel3
        {
            get
            {
                if (_tel3 == null)
                    return string.Empty;
                else
                return _tel3; }
            set { _tel3 = value; }

        }
        public string Tel4
        {
            get
            {
                if (_tel4 == null)
                    return string.Empty;
                else
                return _tel4; }
            set { _tel4 = value; }

        }
        public string Email
        {
            get
            {
                if (_email == null)
                    return string.Empty;
                else
                return _email; }
            set { _email = value; }

        }
        public string Site
        {
            get
            {
                if (_site == null)
                    return string.Empty;
                else
                return _site; }
            set { _site = value; }

        }
        public string PalavrasCom
        {
            get
            {
                if (_palavrasCom == null)
                    return string.Empty;
                else
                return _palavrasCom; }
            set { _palavrasCom = value; }

        }       
        public string Banner1
        {
            get
            {
                if (_banner1 == null)
                    return string.Empty;
                else
                return _banner1; }
            set { _banner1 = value; }

        }
        public string Banner2
       {
           get
           {
               if (_banner2 == null)
                   return string.Empty;
               else
                   return _banner2;
           }
           set { _banner2 = value; }

       }
        public string Banner3
       {
           get
           {
               if (_banner3 == null)
                   return string.Empty;
               else
                   return _banner3;
           }
           set { _banner3 = value; }

       }
        public string Banner4
       {
           get
           {
               if (_banner4 == null)
                   return string.Empty;
               else
                   return _banner4;
           }
           set { _banner4 = value; }

       }
        public int Ativo
        {
            get {
                if (_ativo == null)
                    return 0;
                else                   
                    return _ativo; }
            set { _ativo = value; }

        }
        public int Prioridade        
        {   
            get {
                if (_prioridade == null)
                    return 0;
                else
                    return _prioridade; }
            set { _prioridade = value; }

        }
        public string DataCadastro
        {
            get
            {
                if (_dataCad == null)
                    return string.Empty;
                else
                return _dataCad; }
            set { _dataCad = value; }

        }

        public string subDivisao1
        {
            get
            {
                if (_subDivisao1 == null)
                    return string.Empty;
                else
                    return _subDivisao1;
            }
            set { _subDivisao1 = value; }
        }
        public string subDivisao2
        {
            get
            {
                if (_subDivisao2 == null)
                    return string.Empty;
                else
                    return _subDivisao2;
            }
            set { _subDivisao2 = value; }
        }
        public string subDivisao3
        {
            get
            {
                if (_subDivisao3 == null)
                    return string.Empty;
                else
                    return _subDivisao3;
            }
            set { _subDivisao3 = value; }
        }
        public string subDivisao4
        {
            get
            {
                if (_subDivisao4 == null)
                    return string.Empty;
                else
                    return _subDivisao4;
            }
            set { _subDivisao4 = value; }
        }
        public string subDivisao5
        {
            get
            {
                if (_subDivisao5 == null)
                    return string.Empty;
                else
                    return _subDivisao5;
            }
            set { _subDivisao5 = value; }
        }
        public string subDivisao6
        {
            get
            {
                if (_subDivisao6 == null)
                    return string.Empty;
                else
                    return _subDivisao6;
            }
            set { _subDivisao6 = value; }
        }

        public string siteSubDivisao1
        {
            get
            {
                if (_siteSubDivisao1 == null)
                    return string.Empty;
                else
                    return _siteSubDivisao1;
            }
            set { _siteSubDivisao1 = value; }
        }
        public string siteSubDivisao2
        {
            get
            {
                if (_siteSubDivisao2 == null)
                    return string.Empty;
                else
                    return _siteSubDivisao2;
            }
            set { _siteSubDivisao2 = value; }
        }
        public string siteSubDivisao3
        {
            get
            {
                if (_siteSubDivisao3 == null)
                    return string.Empty;
                else
                    return _siteSubDivisao3;
            }
            set { _siteSubDivisao3 = value; }
        }
        public string siteSubDivisao4
        {
            get
            {
                if (_siteSubDivisao4 == null)
                    return string.Empty;
                else
                    return _siteSubDivisao4;
            }
            set { _siteSubDivisao4 = value; }
        }
        public string siteSubDivisao5
        {
            get
            {
                if (_siteSubDivisao5 == null)
                    return string.Empty;
                else
                    return _siteSubDivisao5;
            }
            set { _siteSubDivisao5 = value; }
        }
        public string siteSubDivisao6
        {
            get
            {
                if (_siteSubDivisao6 == null)
                    return string.Empty;
                else
                    return _siteSubDivisao6;
            }
            set { _siteSubDivisao6 = value; }
        }

        public string TelefoneSuDivisao1
        {
            get
            {
                if (_TelefoneSuDivisao1 == null)
                    return string.Empty;
                else
                    return _TelefoneSuDivisao1;
            }
            set { _TelefoneSuDivisao1 = value; }
        }
        public string TelefoneSuDivisao2
        {
            get
            {
                if (_TelefoneSuDivisao2 == null)
                    return string.Empty;
                else
                    return _TelefoneSuDivisao2;
            }
            set { _TelefoneSuDivisao2 = value; }
        }
        public string TelefoneSuDivisao3
        {
            get
            {
                if (_TelefoneSuDivisao3 == null)
                    return string.Empty;
                else
                    return _TelefoneSuDivisao3;
            }
            set { _TelefoneSuDivisao3 = value; }
        }
        public string TelefoneSuDivisao4
        {
            get
            {
                if (_TelefoneSuDivisao4 == null)
                    return string.Empty;
                else
                    return _TelefoneSuDivisao4;
            }
            set { _TelefoneSuDivisao4 = value; }
        }
        public string TelefoneSuDivisao5
        {
            get
            {
                if (_TelefoneSuDivisao5 == null)
                    return string.Empty;
                else
                    return _TelefoneSuDivisao5;
            }
            set { _TelefoneSuDivisao5 = value; }
        }
        public string TelefoneSuDivisao6
        {
            get
            {
                if (_TelefoneSuDivisao6 == null)
                    return string.Empty;
                else
                    return _TelefoneSuDivisao6;
            }
            set { _TelefoneSuDivisao6 = value; }
        }

        public string AtividadesSubDivisao1
        {
            get
            {
                if (_AtividadesSubDivisao1 == null)
                    return string.Empty;
                else
                    return _AtividadesSubDivisao1;
            }
            set { _AtividadesSubDivisao1 = value; }
        }
        public string AtividadesSubDivisao2
        {
            get
            {
                if (_AtividadesSubDivisao2 == null)
                    return string.Empty;
                else
                    return _AtividadesSubDivisao2;
            }
            set { _AtividadesSubDivisao2 = value; }
        }
        public string AtividadesSubDivisao3
        {
            get
            {
                if (_AtividadesSubDivisao3 == null)
                    return string.Empty;
                else
                    return _AtividadesSubDivisao3;
            }
            set { _AtividadesSubDivisao3 = value; }
        }
        public string AtividadesSubDivisao4
        {
            get
            {
                if (_AtividadesSubDivisao4 == null)
                    return string.Empty;
                else
                    return _AtividadesSubDivisao4;
            }
            set { _AtividadesSubDivisao4 = value; }
        }
        public string AtividadesSubDivisao5
        {
            get
            {
                if (_AtividadesSubDivisao5 == null)
                    return string.Empty;
                else
                    return _AtividadesSubDivisao5;
            }
            set { _AtividadesSubDivisao5 = value; }
        }
        public string AtividadesSubDivisao6
        {
            get
            {
                if (_AtividadesSubDivisao6 == null)
                    return string.Empty;
                else
                    return _AtividadesSubDivisao6;
            }
            set { _AtividadesSubDivisao6 = value; }
        }
    }
}