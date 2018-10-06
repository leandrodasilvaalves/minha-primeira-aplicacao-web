using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Threading;

namespace STR
{
    public class clsString
    {
        
        public string Right(string Text, int Start)
        {
            try
            {
                string result = Text.Substring(Start);
                return result;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }
        public string rRight(string Text, int Start)
        {
            try
            {
                string result = Text.Substring(Text.Length- Start);
                return result;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }
        public string Left(string Text, int End)
        {
            try
            {
                string result = Text.Substring(0, End);
                return result;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }
        public string Mid(string Text, int Start, int End)
        {
            try
            {
                string result = Text.Substring(Start, End);
                return result;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string ProperCase(string Text)
        {
            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;
            try
            {
                return textInfo.ToTitleCase(Text);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        
    }
}
