using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace EjercicioFinalMVC5.Services
{
    public class ImageHelper
    {
        public static byte[] dameByteArray(string url)
        {
            byte[] imageBytes;
            HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create(url);
            WebResponse myResp = myReq.GetResponse();

            Stream stream = myResp.GetResponseStream();
            using (BinaryReader br = new BinaryReader(stream))
            {
                imageBytes = br.ReadBytes(500000);
                br.Close();
            }
            myResp.Close();
            return imageBytes;
        }
    }
}