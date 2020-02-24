using System;
using System.Net;
using Newtonsoft.Json;
using System.Net.Http;
using System.Web;

namespace Program
{   
    class Google{
        public long GetResults(string keyWords, string KEY, string EngineID){
            string urlGoogle = "https://www.googleapis.com/customsearch/v1?key="+KEY+"&cx="+EngineID+"&q="+keyWords;
               
            var jsonGoogle = new WebClient().DownloadString(urlGoogle);
            // Converting strings to Objects
            dynamic resGoogle = JsonConvert.DeserializeObject(jsonGoogle);
            
            // Going through the Google request object
            long numberOfResults = 0;
            foreach (var google in resGoogle.queries.request)
            {
                    numberOfResults = google.totalResults;
            }
            Console.WriteLine("{0}: Google => {1}",keyWords, numberOfResults);
            return numberOfResults;
        }
    }
    class Bing{
        public long GetResults(string keyWords, string KEY, string EngineID){
            string urlBing = "https://www.googleapis.com/customsearch/v1?key="+KEY+"&cx="+EngineID+"&q="+keyWords;
               
            var jsonBing = new WebClient().DownloadString(urlBing);
            // Converting strings to Objects
            dynamic resBing = JsonConvert.DeserializeObject(jsonBing);
            
            // Going through the Google request object
            long numberOfResults = 0;
            foreach (var bing in resBing.queries.request)
            {
                numberOfResults = bing.totalResults;
            }
            Console.WriteLine("{0}: Bing   => {1}",keyWords, numberOfResults);
            return numberOfResults;
        }
    }
    static class Program
    {
        static void Main(string[] args)
        {
            long iBing = 0;
            long iGoogle = 0;
            string KEY = "AIzaSyDZ9Xp_pjTaqR7-9KwUaRrZtPJPloRXZ6E";
            string EngineIdGoogle = "004432549449583349288:nalrskjiw5l";
            string EngineIdBing = "004432549449583349288:dzujar3pgzy";
            var searchGoogle = new Google();
            var searchBing = new Bing();

            Console.WriteLine("__________________________________________________");
            foreach (string argumento in args)
            {
                
                long resultsGoogle = searchGoogle.GetResults(argumento, KEY, EngineIdGoogle);
                long resultsBing = searchBing.GetResults(argumento, KEY, EngineIdBing);
                if (resultsGoogle>resultsBing)
                {
                    iGoogle++;
                }else if (resultsGoogle<resultsBing)
                {
                    iBing++;
                }
                
            }
            Console.WriteLine("============================");
            if (iBing>iGoogle)
            {
                Console.WriteLine("Bing winner");
            }else if(iBing<iGoogle){
                Console.WriteLine("Google winner");
            }else{
                Console.WriteLine("It is a tie");
            }
            Console.WriteLine("============================");

        }
    }
}