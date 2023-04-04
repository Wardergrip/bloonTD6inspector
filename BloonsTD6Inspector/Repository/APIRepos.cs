using BloonsTD6Inspector.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BloonsTD6Inspector.Repository
{
    public class APIRepos
    {
        // Class

        private List<Tower> _gameObjects;

        public async Task<List<Tower>> GetTowersAsync()
        {
            if (_gameObjects != null) { return _gameObjects; }

            using (HttpClient client = new HttpClient())
            {
                string endpoint = $"https://statsnite.com/api/btd/v3/towers";
                try
                {
                    var response = await client.GetAsync(endpoint);

                    if (!response.IsSuccessStatusCode)
                    {
                        throw new HttpRequestException(response.ReasonPhrase);
                    }

                    string json = await response.Content.ReadAsStringAsync();
                    var towers = JsonConvert.DeserializeObject<Tower[]>(json);

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
