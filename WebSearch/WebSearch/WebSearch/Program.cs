using System;
using System.Net;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace WebSearch
{
    internal class Program
    {

        static void Main()
        {
            HTMLSearch htmlSearch = new HTMLSearch();
            
            //htmlSearch.ReadInput(Console.ReadLine().Trim());
            //htmlSearch.ReadTimesToSearch(int.Parse(Console.ReadLine()));
            //int numberTimesToSearch = int.Parse(Console.ReadLine());

            SearchWeb searchWeb = new SearchWeb();
            searchWeb.BreadthFirstSearch("http://varko.xyz/writing_a_pe32_x86_exe_packer.html", 50);


            //List<string> listLinks = new List<string>();
            //string htmlString = htmlSearch.GetHtmlString("http://varko.xyz/writing_a_pe32_x86_exe_packer.html");
            //listLinks = htmlSearch.ParseHTML(htmlString);
            //foreach (var item in listLinks)
            //{
            //    Console.WriteLine(item);
            //}


            //Console.WriteLine(htmlCode);
            //Console.WriteLine(htmlSearch.CountMatches(htmlCode));
            //Console.WriteLine($"{htmlSearch.IfValidURL()}");
        }

       
    }

}
