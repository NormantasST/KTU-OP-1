using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5Sav4
{
    public class Team
    {
        public string Type { get; set; }
        public readonly Type TypeClass;
        public string TeamName { get; set; }
        public string City { get; set; }
        public string Trainer { get; set; }
        public int MatchesPlayed { get; set; }

        public Team(string type, string teamName, string city, string trainer, int matchesPlayed)
        {
            switch (type)
            {
                case "k":
                    Type = "Basketball";
                    TypeClass = typeof(Basketball);
                    break;
                case "f":
                    Type = "Football";
                    TypeClass = typeof(Football);
                    break;
                default:
                    Type = "Unknown";
                    break;
            }
            TeamName = teamName;
            City = city;
            Trainer = trainer;
            MatchesPlayed = matchesPlayed;
        }

        public override string ToString()
        {
            return $"{Type, -20}|{TeamName, -20}|{City, -20}|{Trainer, -20}|{MatchesPlayed, 20}";
        }
    }
}
