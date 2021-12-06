using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5Sav4
{
    public abstract class Player
    {
        public string TeamName { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public int MatchesPlayed { get; set; }
        public int PointsEarned { get; set; }


        public Player(string teamName,    string lastName,   string firstName, int matchesPlayed, int pointsEarned)
        {
            TeamName = teamName;
            LastName = lastName;
            FirstName = firstName;
            MatchesPlayed = matchesPlayed;
            PointsEarned = pointsEarned;

        }
    }
}
