using System;
using System.IO;
using System.Net;

namespace CourtsiderApi.Models.MetricSources
{
    public class YoutubeApi
    {
        public YoutubeApi() { }

        public string getMetrics(string channelId)
        {
            string apiKey = Environment.GetEnvironmentVariable("YOUTUBE_API_KEY");
            string url = string.Format("https://www.googleapis.com/youtube/v3/channels?part=statistics&id={0}&key={1}", channelId, apiKey);
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