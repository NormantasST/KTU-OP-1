using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5Sav4
{
    class Football : Player
    {
        public int Fouls { get; set; }
        public Football(string teamName, string lastName, string firstName, int matchesPlayed, int pointsEarned, int fouls) : base(teamName, lastName, firstName, matchesPlayed, pointsEarned)
        {
            Fouls = fouls;
        }

        public override string ToString()
        {
            return $"{"Footballer",-20}|{TeamName, -20}|{LastName,-20}|{FirstName,-20}|{MatchesPlayed,20}|{PointsEarned,15}|{Fouls,20}|";
        }
    }
}
