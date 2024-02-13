using BambooCardTest.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BambooCardTest.Integrations.HackerNews
{
    public class HackerNewsClient : IHackerNewsClient
    {
        private HackerNewsSettings _hackerNewsSettings;
        public HackerNewsClient(IOptions<HackerNewsSettings> hackerNewsSettings)
        {
            _hackerNewsSettings = hackerNewsSettings.Value;
        }
        public async Task<IEnumerable<int>> GetStoryIDs()
        {
            return await ApiCall.GetAsync<IEnumerable<int>>(_hackerNewsSettings.BaseURL, "beststories.json");
        }
        public async Task<Story> GetStoryDetails(int id)
        {
            return await ApiCall.GetAsync<Story>(_hackerNewsSettings.BaseURL, GetStoryAPIName(id));
        }

        private string GetStoryAPIName(int storyId)
        {
            return $"item/{storyId}.json";
        }
    }
}
