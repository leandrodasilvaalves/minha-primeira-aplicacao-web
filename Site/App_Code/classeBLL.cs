using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

using EMP;
using DAL;
using USER;
using SQLinject;
using CONTATO;

namespace BLL
{
    public class classeBLL
    {
        public void AtualizaEmpresa(Empresa e)
        {           
            try
            {
                DAL.classeDAL dal = new DAL.classeDAL();
                dal.UpdateEmpresa(e);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Usuario Login(int tb, Usuario u)
        {
            try
            {
                classeDAL dal = new classeDAL();
                Usuario us = new Usuario();
                classeSQLinject inj = new classeSQLinject();

                /*Caso seja retornado um TRUE na classe inj, o método retornará um valor zero
                 indicando que não há usuário no sistema com estes dados. 
                 Assim será evitado que haja entrada de dados maliciosos (instruções SQL).*/
                if (inj.InjecaoSQL(u.usuario, u.Senha) == true)
                {
                    us.usuario = string.Empty;
                    us.Senha = string.Empty;
                    us.UserTemp = 0;
                    return us;
                }
                else
                {
                    return dal.Login(tb, u);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Usuario GeraNovoUsuario()
        {
            classeDAL dal = new classeDAL();
            try
            {
                return dal.GerarUsuario();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable ListarEmpresas()
        {
            try
            {
                classeDAL da = new classeDAL();
                return da.ListarEmpresas();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public void ExcluiEmpresa(Empresa e)
        {
            try
            {
                classeDAL da = new classeDAL();
                da.DeleteEmpresa(e);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public Empresa SelecionaEmpresaPorUsuario(string US)
        {
            classeDAL da = new classeDAL();
            try
            {
                return da.SelecionaEmpresaPorUsuario(US);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable SelecionaEmpresa_pnl_Control(string buscar, int op)
        {
            try
            {
                DAL.classeDAL da = new DAL.classeDAL();
                return da.SelecionaEmpresa_pnl_Control(buscar, op);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }        
        public void AtualisaBanner(string US, string caminho_Banner, int i)
        {
            try
            {
                DAL.classeDAL da = new classeDAL();
                da.UpdateBanner(US, caminho_Banner, i);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ExcluiBanner(string US, int i)
        {
            try
            {
                DAL.classeDAL da = new classeDAL();
                da.DeleteBanner(US,  i);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void AtualizaUsuario(string US, string NewID)
        {
            try
            {
                DAL.classeDAL da = new DAL.classeDAL();
                da.UpdateUsuario(US, NewID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int ExisteUsuario(string US)
        {
            try
            {
                DAL.classeDAL da = new DAL.classeDAL();
                return da.ExistUsuario(US);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool VerificaSeUsuarioTemp(string usuario)
        {
            try
            {
                DAL.classeDAL da = new DAL.classeDAL();
                return da.VerificaSeUsuarioTemp(usuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void EnviarErros(string Erro)
        {
            DAL.classeDAL da = new DAL.classeDAL();
            da.EnviarErros(Erro);
        }
        public void EnviarContatos(CONTATO.classeContatos co)
        {
            try
            {
                DAL.classeDAL da = new DAL.classeDAL();
                da.EnviarContatos(co);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public bool RecuperaSenha(EMP.Empresa emp)
        {
            try
            {
                DAL.classeDAL da = new DAL.classeDAL();
                return da.RecuperaSenha(emp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void AtualisaSenha(int tb, string Usuario, string NewPassword)
        {
            try
            {
                DAL.classeDAL da = new DAL.classeDAL();
                da.UpdateSenha(tb, Usuario, NewPassword);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable PesquisaListaBem(string Buscar, int Inicio, int Procedure)
        {
            try
            {
                DAL.classeDAL da = new DAL.classeDAL();
                return da.SearchListaBem(Buscar, Inicio, Procedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public long ContaRegistrosPesquisa(string Buscar)
        {
            try
            {
                DAL.classeDAL da = new DAL.classeDAL();
                return da.ContaRegistrosPesquisa(Buscar);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<string> SearchAutoComplete(string prefixText, int count)
        {
            DAL.classeDAL da = new DAL.classeDAL();
            return da.SearchAutoComplete(prefixText, count);
        }
        
    }
}