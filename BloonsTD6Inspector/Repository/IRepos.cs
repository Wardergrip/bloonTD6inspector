using BloonsTD6Inspector.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloonsTD6Inspector.Repository
{
    public interface IRepos
    {
        Task<List<Tower>> GetTowersAsync();

        Task<List<Tower>> GetTowersAsync(string type);
    }
}
