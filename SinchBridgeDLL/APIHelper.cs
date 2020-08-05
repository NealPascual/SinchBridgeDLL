using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace SinchBridgeDLL
{
    public class APIHelper
    {
        public static string CallRestMethod(string url)
        {
            HttpWebRequest webrequest = (HttpWebRequest)WebRequest.Create(url);
            webrequest.Method = "GET";
            //webrequest.ContentType = "application/x-www-form-urlencoded";
            webrequest.ContentLength = 0;
            //webrequest.Headers.Add("Username", "xyz");
            //webrequest.Headers.Add("Password", "abc");
            HttpWebResponse webresponse = (HttpWebResponse)webrequest.GetResponse();
            Encoding enc = System.Text.Encoding.GetEncoding("utf-8");
            StreamReader responseStream = new StreamReader(webresponse.GetResponseStream(), enc);
            string result = string.Empty;
            result = responseStream.ReadToEnd();
            webresponse.Close();
            return result;
        }
    }
}
