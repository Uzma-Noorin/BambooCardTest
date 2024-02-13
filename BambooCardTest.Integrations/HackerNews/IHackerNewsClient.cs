using BambooCardTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BambooCardTest.Integrations.HackerNews
{
    public interface IHackerNewsClient
    {
        Task<IEnumerable<int>> GetStoryIDs();
        Task<Story> GetStoryDetails(int id);
    }
}
