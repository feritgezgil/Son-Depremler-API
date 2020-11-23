﻿using HtmlAgilityPack;
using System;
using System.Net;
using System.Text;

namespace SonDepremlerApi.Utils
{

    public class CrawlUtils
    {
        protected Uri uri { get; set; }
        protected HtmlDocument document { get; set; }

        public CrawlUtils(string link)
        {
            this.uri = new Uri(link);
            this.InitUrl();
        }

        public string GetHtmlRaw()
        {
            WebClient wc = new WebClient
            {
                Encoding = Encoding.UTF8
            };
            string RawHtml = wc.DownloadString(this.uri);
            return RawHtml;
        }

        public void InitUrl()
        {
            document = new HtmlDocument();
            document.LoadHtml(this.GetHtmlRaw());
        }

        public HtmlNodeCollection CrawlNodes(string xpath)
        {
             return this.document.DocumentNode.SelectNodes(xpath);
        }
    }
}