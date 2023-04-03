using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BloonsTD6Inspector.Repository.APIRepos;

namespace BloonsTD6Inspector.Model
{
    public class Cost
    {
        [JsonProperty(PropertyName = "easy")]
        public int EasyCost { get; set; }
        [JsonProperty(PropertyName = "medium")]
        public int MediumCost { get; set; }
        [JsonProperty(PropertyName = "hard")]
        public int HardCost { get; set; }
        [JsonProperty(PropertyName = "impoppable")]
        public int ImpoppableCost { get; set; }
    }

    public class Special
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }

    public class Stats
    {
        public string Damage { get; set; }
        public string Pierce { get; set; }
        public string AttackSpeed { get; set; }
        public string Range { get; set; }
        public string Type { get; set; }
        public List<Special> Special { get; set; }
    }

    public class Path
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Cost Cost { get; set; }
        public int UnlockXp { get; set; }
        public List<string> Effects { get; set; }
    }

    public class Paragon
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Cost Cost { get; set; }
        public int UnlockXp { get; set; }
        public List<string> Effects { get; set; }
    }

    public class Paths
    {
        public Path[] path1 { get; set; }
        public Path[] path2 { get; set; }
        public Path[] path3 { get; set; }
        public Paragon paragon { get; set; }
    }

    // Main class
    public class Tower
    {
        // General
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        [JsonIgnore]
        public string ObjectType { get; set; }

        public Cost Cost { get; set; }
        public Stats Stats { get; set; }
        public int Footprint { get; set; }
        public string DefaultHotkey { get; set; }
        public Paths Paths { get; set; }

        [JsonIgnore]
        public string ImageURL 
        { 
            get
            {
                return $"https://statsnite.com/images/btd/{ObjectType + "s"}/{Id}/{ObjectType}.png";
            }
        }

        [JsonIgnore]
        public List<string> Path1Images 
        {  
            get
            {
                List<string> result = new List<string>();

                for (int i = 1; i <= 5; ++i)
                {
                    result.Add($"https://statsnite.com/images/btd/towers/{Id}/{i}00.png");
                }

                return result;
            }
        }
        [JsonIgnore]
        public List<string> Path2Images 
        { 
            get
            {
                List<string> result = new List<string>();

                for (int i = 1; i <= 5; ++i)
                {
                    result.Add($"https://statsnite.com/images/btd/towers/{Id}/0{i}0.png");
                }

                return result;
            }
        }
        [JsonIgnore]
        public List<string> Path3Images 
        { 
            get
            {
                List<string> result = new List<string>();

                for (int i = 1; i <= 5; ++i)
                {
                    result.Add($"https://statsnite.com/images/btd/towers/{Id}/00{i}.png");
                }

                return result;
            }
        }
    }
}
