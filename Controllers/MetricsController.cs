using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

using CourtsiderApi.Models.MetricSources;

namespace CourtsiderApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MetricsController : ControllerBase
    {
        [HttpGet]
        public string GetAllMetrics(string youtubeChannelId = "", string twitterUser = "", string twitchUser = "")
        {
            Dictionary<string, dynamic> result = new Dictionary<string, dynamic>();
            if (youtubeChannelId.Length > 0)
            {
                YoutubeApi youtubeApi = new YoutubeApi();
                result.Add("Youtube", youtubeApi.getMetrics(youtubeChannelId));
            }

            if (twitterUser.Length > 0)
            {
                TwitterApi twitterApi = new TwitterApi();
                result.Add("Twitter", twitterApi.getMetrics(twitterUser));
            }

            if (twitchUser.Length > 0)
            {
                TwitchApi twitchApi = new TwitchApi();
                result.Add("Twitch", twitchApi.getMetrics(twitchUser));
            }

            return JsonConvert.SerializeObject(result);
        }

        [Route("youtube/{channelId}")]
        [HttpGet]
        public string GetYoutubeMetrics(string channelId)
        {
            YoutubeApi youtubeApi = new YoutubeApi();
            return youtubeApi.getMetrics(channelId);
        }

        [Route("twitter/{userName}")]
        [HttpGet]
        public string GetTwitterMetrics(string userName)
        {
            TwitterApi twitterApi = new TwitterApi();
            return twitterApi.getMetrics(userName);
        }

        [Route("twitch/{userName}")]
        [HttpGet]
        public string GetTwitchMetrics(string userName)
        {
            TwitchApi twitchApi = new TwitchApi();
            return twitchApi.getMetrics(userName);
        }
    }
}