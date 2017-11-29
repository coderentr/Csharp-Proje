using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MynetRssXml
{
   public  class RssReader
    {
        public RssReader(string _url)
        {
            this.siteurl = _url;
            xDoc = new XmlDocument();
        }

        private string siteurl;
        private XmlDocument xDoc;

        private void HaberGetirRss()
        {
            WebClient wc =new WebClient();
            wc.Encoding = Encoding.UTF8;
            string xmldata = wc.DownloadString(siteurl);
            xDoc.LoadXml(xmldata);
        }
    
        public List<Haberler> HaberGetir()
        {
            List<Haberler> haberlistesi = new List<Haberler>();
            HaberGetirRss();
            XmlNodeList nod = xDoc.DocumentElement.GetElementsByTagName("item");
            foreach (XmlNode item in nod)
            {
                try
                {
                    Haberler h = new Haberler();
                    h.HaberBasligi = item.SelectSingleNode("title").InnerText;
                    h.Link = item.SelectSingleNode("link").InnerText;
                    haberlistesi.Add(h);
                }
                catch (Exception)
                {
                    continue;
                }
            
            }
            return haberlistesi;
        }

    }
}
