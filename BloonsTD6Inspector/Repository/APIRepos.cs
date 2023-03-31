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
        // Response classes
        #region AllTowersResponse
        public class AllTowersResponse
        {
            public TowerResponse[] Towers { get; set; }
        }

        public class TowerResponse
        {
            public string id { get; set; }
            public string name { get; set; }
            public string description { get; set; }
            public string type { get; set; }
            public CostResponse cost { get; set; }
            public StatsResponse stats { get; set; }
            public int footprint { get; set; }
            public string defaultHotkey { get; set; }
            public PathsResponse paths { get; set; }
        }

        public class CostResponse
        {
            public int easy { get; set; }
            public int medium { get; set; }
            public int hard { get; set; }
            public int impoppable { get; set; }
        }

        public class StatsResponse
        {
            public string damage { get; set; }
            public string pierce { get; set; }
            public string attackSpeed { get; set; }
            public string range { get; set; }
            public string type { get; set; }
            public SpecialResponse[] special { get; set; }
        }

        public class SpecialResponse
        {
            public string name { get; set; }
            public string value { get; set; }
        }

        public class PathsResponse
        {
            public PathResponse[] path1 { get; set; }
            public PathResponse[] path2 { get; set; }
            public PathResponse[] path3 { get; set; }
            public ParagonResponse paragon { get; set; }
        }

        public class ParagonResponse
        {
            public string name { get; set; }
            public string description { get; set; }
            public CostResponse cost { get; set; }
            public int unlockXp { get; set; }
            public string[] effects { get; set; }
            public string source { get; set; }
        }

        public class PathResponse
        {
            public string name { get; set; }
            public string description { get; set; }
            public CostResponse cost { get; set; }
            public int unlockXp { get; set; }
            public string[] effects { get; set; }
            public string source { get; set; }
        }
        #endregion AllTowersResponse

        // Class

        private List<GameObject> _gameObjects;
        public List<GameObject> GetGameObjects()
        {
            if (_gameObjects == null)
            {

            }
            return _gameObjects;
        }

        public async Task<List<GameObject>> GetTowersAsync()
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
                    var towers = JsonConvert.DeserializeObject<TowerResponse[]>(json);

                    List<GameObject> output = new List<GameObject>();
                    foreach (var tower in towers)
                    {
                        GameObject outputTower = new GameObject();
                        outputTower.Name = tower.name;
                        outputTower.Id = tower.id;
                        outputTower.Description = tower.description;
                        outputTower.Type = tower.type;
                        switch (outputTower.Type)
                        {
                            case "Primary":
                            case "Military":
                            case "Magic":
                            case "Support":
                                outputTower.ObjectType = "tower";
                                break;
                        }
                        output.Add(outputTower);
                    }

                    return output;
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
