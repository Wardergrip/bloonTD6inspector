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
        public List<Tower> GetGameObjects()
        {
            if (_gameObjects == null)
            {

            }
            return _gameObjects;
        }

        public async Task<List<Tower>> GetTowersAsync()
        {
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

                    return towers.ToList();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Exception! {ex.Message}");
                }
            }

            return null;
        }
    }
}
