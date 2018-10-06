using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace MsgBox
{
    /// <summary>
    /// Summary description for MessageBox
    /// </summary>
    public class MessageBox
    {
        /// <summary>
        /// Exibe um MessageBox
        /// </summary>
        public MessageBox()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        /// <summary>
        /// Exibe mensagem de Alerta
        /// </summary>
        /// <param name="mensagem">Mensagem que será exibida</param>
        /// <param name="control">Pagina atual</param>
        public void Alert(string mensagem, Control control)
        {
            StringBuilder jsString = new StringBuilder();
            jsString.AppendLine(" function dw_AlertBox() ");
            jsString.AppendLine(" { ");
            jsString.AppendLine("   alert('" + mensagem + "') ");
            jsString.AppendLine(" } ");

            jsString.AppendLine(" dw_AlertBox(); ");

            ScriptManager.RegisterClientScriptBlock(control, typeof(Page), "dw_AlertBox", jsString.ToString(), true);
        }

        /// <summary>
        /// Exibe mensagem de Alerta e Redireciona
        /// </summary>
        /// <param name="mensagem">Mensagem que será exibida</param>
        /// <param name="urlRedirect">URL para redirecionar após exibir mensagem de alerta</param>
        /// <param name="control">Pagina atual</param>
        public void AlertAndRedirect(string mensagem, string urlRedirect, Control control)
        {
            StringBuilder jsString = new StringBuilder();
            jsString.AppendLine(" function dw_AlertAndRedirectBox() ");
            jsString.AppendLine(" { ");
            jsString.AppendLine("   alert('" + mensagem + "') ");
            jsString.AppendLine("   window.location='" + urlRedirect + "'; ");
            jsString.AppendLine(" } ");

            jsString.AppendLine(" dw_AlertAndRedirectBox(); ");

            ScriptManager.RegisterClientScriptBlock(control, typeof(Page), "dw_AlertAndRedirectBox", jsString.ToString(), true);
        }

        /// <summary>
        /// Exibe mensagem de Confirmação
        /// </summary>
        /// <param name="mensagem">Mensagem que será exibida</param>
        /// <param name="urlOK">URL para redirecionar caso o botão OK seja pressionado</param>
        /// <param name="urlCancel">URL para redirecionar caso o botão Cancelar seja pressionado</param>
        /// <param name="control">Pagina atual</param>
        public void Confirm1(string mensagem, string urlOK, string urlCancel, Control control)
        {
            StringBuilder jsString = new StringBuilder();
            jsString.AppendLine(" function dw_ConfirmBox() ");
            jsString.AppendLine(" { ");
            jsString.AppendLine("   if( confirm('" + mensagem + "') ) ");
            jsString.AppendLine("   { ");
            jsString.AppendLine("       window.location='" + urlOK + "'; ");
            jsString.AppendLine("   }else{ ");
            jsString.AppendLine("       window.location='" + urlCancel + "'; ");
            jsString.AppendLine("   } ");
            jsString.AppendLine(" } ");

            jsString.AppendLine(" dw_ConfirmBox(); ");

            ScriptManager.RegisterStartupScript(control, typeof(Page), "dw_ConfirmBox", jsString.ToString(), true);
        }

        /// <summary>
        /// Exibe mensagem de Confirmação
        /// </summary>
        /// <param name="mensagem">Mensagem que será exibida</param>
        /// <param name="url">URL para redirecionar caso o botão OK seja pressionado</param>
        /// <param name="OkRedirect">
        /// True para redirecionar quando o botão OK for clicado e 
        /// False para redirecionar quando o botão Cancelar for clicado
        /// </param>
        /// <param name="control">Pagina atual</param>
        public void Confirm2(string mensagem, string url, Boolean OkRedirect, Control control)
        {
            string OK = string.Empty;
            string CANCEL = string.Empty;

            if (OkRedirect)
            {
                OK = "window.location='" + url + "';";
                CANCEL = "return false;";
            }
            else
            {
                OK = "return false;";
                CANCEL = "window.location='" + url + "';";
            }

            StringBuilder jsString = new StringBuilder();
            jsString.AppendLine(" function dw_ConfirmBox() ");
            jsString.AppendLine(" { ");
            jsString.AppendLine("   if( confirm('" + mensagem + "') ) ");
            jsString.AppendLine("   { ");
            jsString.AppendLine("       " + OK + " ");
            jsString.AppendLine("   }else{ ");
            jsString.AppendLine("       " + CANCEL + " ");
            jsString.AppendLine("   } ");
            jsString.AppendLine(" } ");

            jsString.AppendLine(" dw_ConfirmBox(); ");

            ScriptManager.RegisterStartupScript(control, typeof(Page), "dw_ConfirmBox", jsString.ToString(), true);
        }

        //protected void ShowMessageBox(string Mensagem)
        //{
        //    string csname1 = "PopupScript";
        //    Type cstype = this.GetType();
        //    ClientScriptManager cs = Page.ClientScript;
        //    if (!cs.IsStartupScriptRegistered(cstype, csname1))
        //    {
        //        String cstext1 = "alert('" + Mensagem + "');";
        //        cs.RegisterStartupScript(cstype, csname1, cstext1, true);
        //    }
        //}


        
    }
}