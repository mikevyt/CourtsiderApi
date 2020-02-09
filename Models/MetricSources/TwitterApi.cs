using System;
using System.IO;
using System.Net;
using System.Text;

namespace CourtsiderApi.Models.MetricSources
{
    public class TwitterApi
    {
        public TwitterApi() { }

        public string getMetrics(string userName)
        {
            string url = string.Format("https://cdn.syndication.twimg.com/widgets/followbutton/info.json?screen_names={0}", userName);
            WebRequest request = WebRequest.Create(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Console.WriteLine(response.StatusDescription);

            Stream dataStream = response.GetResponseStream();

            StreamReader reader = new StreamReader(dataStream);

            string responseFromServer = reader.ReadToEnd();

            reader.Close();
            dataStream.Close();
            response.Close();

            return responseFromServer;
        }
    }
}