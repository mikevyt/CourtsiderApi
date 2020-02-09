using System;
using System.Collections.Generic;
using HtmlAgilityPack;
using Newtonsoft.Json;

namespace CourtsiderApi.Models.MetricSources
{
    public class TwitchApi
    {
        public TwitchApi() { }

        public string getMetrics(string userName)
        {
            HtmlWeb web = new HtmlWeb();
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            string url = string.Format("https://sullygnome.com/channel/{0}/30", userName);
            doc = web.Load(url);

            Dictionary<string, dynamic> result = new Dictionary<string, dynamic>();

            string hoursWatched = doc.DocumentNode.SelectSingleNode("//div[@title='Number of hours watched']").InnerText;
            result.Add("hoursWatched", Int32.Parse(hoursWatched.Replace(",", "")));

            string timeStreamed = doc.DocumentNode.SelectSingleNode("//div[@title='Amount of time streamed']").InnerText;
            result.Add("timeStreamed", Int32.Parse(timeStreamed.Replace(",", "")));

            string averageViewers = doc.DocumentNode.SelectSingleNode("//div[@title='Average number of viewers']").InnerText;
            result.Add("averageViewers", Int32.Parse(averageViewers.Replace(",", "")));

            result.Add("userName", userName);

            return JsonConvert.SerializeObject(result, Formatting.Indented);
        }
    }
}