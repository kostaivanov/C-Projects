using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace WebSearch
{
    class SearchWeb
    {
        private int numberVertices;
        private HTMLSearch htmlSearcher;

        private LinkedList<int>[] arrayWithAdjacencyLists;

        //internal SearchWeb(int nOVertices)
        //{
        //    arrayWithAdjacencyLists = new LinkedList<int>[nOVertices];

        //    for (int i = 0; i < arrayWithAdjacencyLists.Length; i++)
        //    {
        //        arrayWithAdjacencyLists[i] = new LinkedList<int>();
        //    }
        //    numberVertices = nOVertices;
        //}

        //internal void AddEdge(int v, int w)
        //{
        //    arrayWithAdjacencyLists[v].AddLast(w);
        //}

        internal void BreadthFirstSearch(string currentURL, int numberOfWebJumps)
        {
            //bool[] visited = new bool[numberVertices];

            //for (int i = 0; i < numberVertices; i++)
            //{
            //    visited[i] = false;
            //}
     

            LinkedList<string> queue = new LinkedList<string>();
            htmlSearcher = new HTMLSearch();

            //visited[sourceNode] = true;
            queue.AddLast(currentURL);

            while (queue.Any())
            {
                numberOfWebJumps--;
                if (numberOfWebJumps < 0)
                {
                    return;
                }

                string currentURL_ = queue.First();

                string currentHTMLstring = htmlSearcher.GetHtmlString(currentURL_);

                if (currentHTMLstring == null)
                {
                    continue;
                }
                bool ifValidURL = htmlSearcher.IfValidURL(currentURL_);

                int matches = htmlSearcher.CountMatches(currentHTMLstring);

                Console.WriteLine(currentURL_ + $" = {matches} - " + ifValidURL);
               
                queue.RemoveFirst();


                //LinkedList<int> list = arrayWithAdjacencyLists[sourceNode];
                try
                {
                    List<string> websitesList = htmlSearcher.ParseHTML_2(currentURL_);
                    Console.WriteLine("Lista ima = " + websitesList.Count);
                    Console.WriteLine(" ");

                    foreach (var val in websitesList)
                    {
                        ////if (!visited[val])
                        ////{
                        ////    visited[val] = true;
                        ////    queue.AddLast(val);
                        ////}
                        ///
                        queue.AddLast(val);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception source: {0}", ex.Source);
                    //throw;
                }
               
            }
        }
    }
}
