using BloonsTD6Inspector.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BloonsTD6Inspector.Repository
{
    public class LocalRepos : IRepos
    {
        private List<Tower> _gameObjects;

        public async Task<List<Tower>> GetTowersAsync()
        {
            if (_gameObjects != null) { return _gameObjects; }

            try
            {
                string fileInput = string.Empty;
                Tower[] towers = null;
                var task = Task.Run(() => 
                { 
                    fileInput = File.ReadAllText(@"../../Resources/towers.json");
                    towers = JsonConvert.DeserializeObject<Tower[]>(fileInput);
                });

                await task;

                foreach (var tower in towers)
                {
                    switch (tower.Type)
                    {
                        case "Primary":
                        case "Military":
                        case "Magic":
                        case "Support":
                            tower.ObjectType = "tower";
                            break;
                    }
                }

                _gameObjects = towers.ToList();
                return _gameObjects;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception! {ex.Message}");
            }

            return null;
        }

        public async Task<List<Tower>> GetTowersAsync(string type)
        {
            if (_gameObjects == null)
            {
                await GetTowersAsync();
            }
            if (type == "All")
            {
                return _gameObjects;
            }
            return _gameObjects.Where(x => x.Type == type).ToList();
        }
    }
}
