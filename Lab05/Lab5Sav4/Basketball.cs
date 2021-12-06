using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5Sav4
{
    class Basketball : Player
    {
        public int Takeovers { get; set; }
        public int Passes { get; set; }
        public Basketball(string teamName, string lastName, string firstName, int matchesPlayed, int pointsEarned, int takeovers, int passes) : base(teamName, lastName, firstName, matchesPlayed, pointsEarned)
        {
            Takeovers = takeovers;
            Passes = passes;
        }

        public override string ToString()
        {
            return $"{"Basketballer",-20}|{TeamName,-20}|{LastName,-20}|{FirstName,-20}|{MatchesPlayed,20}|{PointsEarned,15}|{Takeovers,20}|{Passes, 15}";
        }
    }
}
