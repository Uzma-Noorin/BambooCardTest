using BambooCardTest.Integrations.HackerNews;
using BambooCardTest.Models;
using BambooCardTest.Services.Interfaces;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BambooCardTest.Services.Implementations
{
    public class HackerNewsService : IHackerNewsService
    {
        public IHackerNewsClient _hackerNewsClient;
        public HackerNewsService(IHackerNewsClient hackerNewsClient)
        {
            _hackerNewsClient = hackerNewsClient;
        }
        public async Task<IEnumerable<Story>> GetTopStories(int n)
        {
            List<Story> allStories = new List<Story>();
            var storyIds = await _hackerNewsClient.GetStoryIDs();
            var tasks = storyIds.Select(async id =>
            {
                var storyDetails = await _hackerNewsClient.GetStoryDetails(id);
                return storyDetails;
            });

            var stories = await Task.WhenAll(tasks);
            allStories.AddRange(stories);

            return allStories.OrderByDescending(s => s.score).Take(n);
        }
    }
}
