using BambooCardTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BambooCardTest.Services.Interfaces
{
    public interface IHackerNewsService
    {
        Task<IEnumerable<Story>> GetTopStories(int n);
    }
}
