using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Linq;
using System.Web;

namespace Common
{
    public class HtmlParser
    {
        public string RenderControlToHtml(Control ControlToRender)
        {
            //**********************************************
            //* Rederiza HTML de controle criado em RUNTIME
            //**********************************************
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            System.IO.StringWriter stWriter = new System.IO.StringWriter(sb);
            System.Web.UI.HtmlTextWriter htmlWriter = new System.Web.UI.HtmlTextWriter(stWriter);
            ControlToRender.RenderControl(htmlWriter);
            return sb.ToString();
        }
    }
}