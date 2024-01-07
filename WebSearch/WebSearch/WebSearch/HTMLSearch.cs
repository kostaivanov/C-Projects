using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Text.RegularExpressions;
using HtmlAgilityPack;
using System.Linq;

namespace WebSearch
{
    internal class HTMLSearch
    {
        string extensionPattern = @"^.*\.(jpg|JPG|gif|GIF|doc|DOC|pdf|PDF)$";

        //string uriName = "http://varko.xyz/writing_a_pe32_x86_exe_packer.html";
        //string[] input = Console.ReadLine().Trim().Split(';').ToArray();
        string uriName = string.Empty;
        internal void ReadInput(string input)
        {
            uriName = input;
            //CountMatches(uriName);
        }

        //internal void ReadTimesToSearch(int numberInput)
        //{
        //    numberSearches = numberInput;
        //}

        internal string GetHtmlString(string link)
        {
            WebClient client = new WebClient();
            string htmlCode = string.Empty;

            try
            {
                htmlCode = client.DownloadString(link);
            }
            catch (Exception ex)
            {
                WebException we = ex as WebException;
                if (we != null && we.Response is HttpWebResponse)
                {
                    HttpWebResponse response = (HttpWebResponse)we.Response;
                    // it can be 404, 500 etc...
                    Console.WriteLine(response.StatusCode + " - " + response.ResponseUri);
                }
            }

            return htmlCode;
        }

        internal int CountMatches(string htmlCode)
        {
            Regex rx = new Regex(@"\bexecutable\b",
            RegexOptions.Compiled | RegexOptions.IgnoreCase);

            //string text = GetHtmlString(htmlCode);
            MatchCollection matches = rx.Matches(htmlCode);

            return matches.Count;
        }

        internal bool IfValidURL(string uriName)
        {

            Uri uriResult;
            bool result = Uri.TryCreate(uriName, UriKind.Absolute, out uriResult)
                && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
            return result;
        }

        internal List<string> ParseHTML(string webLink)
        {
            HtmlDocument document = new HtmlDocument();
            List<string> websitesList = new List<string>();
            //string htmlString = "<html>blabla</html>";
            document.LoadHtml(webLink);
            HtmlNodeCollection collection = document.DocumentNode.SelectNodes("//a[@href]");
            foreach (HtmlNode link in collection)
            {
                string target = link.Attributes["href"].Value;
                websitesList.Add(target.Trim());
            }
            return websitesList;
        }

        internal List<string> ParseHTML_2(string webLink)
        {
            WebClient webClient = new WebClient();
            byte[] data = webClient.DownloadData(webLink);
            string download = Encoding.ASCII.GetString(data);
            HashSet<string> list = new HashSet<string>();

            HtmlDocument document = new HtmlDocument();

            //List<string> websitesList = new List<string>();
            //string htmlString = "<html>blabla</html>";
            document.LoadHtml(download);
            HtmlNodeCollection collection = document.DocumentNode.SelectNodes("//a[@href]");
            if (collection != null)
            {
                foreach (HtmlNode link in collection)
                {
                    string target = link.Attributes["href"].Value;

                    if (Regex.IsMatch(target, extensionPattern))
                    {
                        continue;
                    }

                    list.Add(GetAbsoluteUrlString(webLink, target));
                }
            }

            return list.ToList();
        }

        private string GetAbsoluteUrlString(string baseUrl, string url)
        {
            var uri = new Uri(url, UriKind.RelativeOrAbsolute);
            if (!uri.IsAbsoluteUri)
            {
                uri = new Uri(new Uri(baseUrl), uri);
            }

            return uri.ToString();
        }
    }

   
}
