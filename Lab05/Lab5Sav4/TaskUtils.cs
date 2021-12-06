using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5Sav4
{
    public static class TaskUtils
    {
        public static double GetAverageScore(List<Player> players, Type type)
        {
            int sum = 0;
            int devider = 0;
            foreach (Player player in players)
            {
                if(player.GetType() == type)
                {
                    sum += player.PointsEarned;
                    devider++;
                }
            }

            return sum / devider;
        }

        public static List<Player> BestPlayers(List<Player> players, List<Team> teams, string city)
        {
            double fbAverage = GetAverageScore(players, typeof(Football)); // Football
            double bbAverage = GetAverageScore(players, typeof(Basketball)); // Basketball
            Console.WriteLine(fbAverage);
            Console.WriteLine(bbAverage);
            List<Player> output = new List<Player>();
            foreach (Team team in teams)
            {
                if (team.City == city)
                {
                    foreach(Player player in players)
                    {
                        if(player.TeamName == team.TeamName && player.GetType() == team.TypeClass && player.MatchesPlayed == team.MatchesPlayed) // Checks for same player and matches
                        {
                            if (player.GetType() == typeof(Basketball) && player.PointsEarned >= bbAverage)
                                output.Add(player);
                            else if (player.GetType() == typeof(Football) && player.PointsEarned >= fbAverage)
                                output.Add(player);
                        }
                    }
                }
            }
            
            return output;
        }
    }
}
