using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5Sav4
{
    static class InOutUtils
    {
        public static void CreateFile(string fileName)
           => new StreamWriter(new FileStream(fileName, FileMode.Create), encoding: Encoding.UTF8).Close();

        public static List<Team> ReadTeams(string fileName)
        {
            List<Team> list = new List<Team>();
            string[] lines = File.ReadAllLines(fileName);

            foreach (string line in lines)
            {
                string[] elements = line.Split(';');
                string type = elements[0];
                string teamName = elements[1];
                string city = elements[2];
                string trainer = elements[3];
                int matchesPlayed = int.Parse(elements[4]);
                list.Add(new Team(type, teamName, city, trainer, matchesPlayed));
            }

            return list;
        }

        /// <summary>
        /// Reads Players from .txt file
        /// </summary>
        public static List<Player> ReadPlayers(string fileName)
        {
            List<Player> list = new List<Player>();
            string[] lines = File.ReadAllLines(fileName);

            foreach (string line in lines)
            {
                string[] elements = line.Split(';', StringSplitOptions.RemoveEmptyEntries);
                string team = elements[0];
                string lastName = elements[1];
                string firstName = elements[2];
                int matchesPlayed = int.Parse(elements[3]);
                int pointsEarned = int.Parse(elements[4]);

                switch (elements.Length)
                {
                    case 6: // Football
                        int fouls = int.Parse(elements[5]);
                        list.Add(new Football(team, lastName, firstName, matchesPlayed, pointsEarned, fouls));
                        break;
                    case 7: // BasketBall
                        int takeovers = int.Parse(elements[5]);
                        int passes = int.Parse(elements[6]);
                        list.Add(new Basketball(team, lastName, firstName, matchesPlayed, pointsEarned, takeovers, passes));
                        break;
                }
            }

            return list;
        }

        public static void WriteTeams(List<Team> teams, string fileName, string label)
        {
            using (StreamWriter sw = new StreamWriter(fileName, append: true))
            {
                sw.WriteLine(label);
                sw.WriteLine();
                sw.WriteLine($"{"Type",-20}|{"TeamName",-20}|{"City",-20}|{"Trainer",-20}|{"MatchesPlayed",-20}");
                if (teams.Count > 0)
                    foreach (Team team in teams)
                        sw.WriteLine(team);
                else
                    sw.WriteLine("No Data Found");

                sw.WriteLine();
            }
        }

        public static void WritePlayers(List<Player> players, string fileName, string label)
        {
            using (StreamWriter sw = new StreamWriter(fileName, append: true))
            {
                sw.WriteLine(label);
                sw.WriteLine();
                sw.WriteLine($"{"Player-Type",-20}|{"TeamName",-20}|{"LastName",-20}|{"FirstName",-20}|{"MatchesPlayed",-20}|{"PointsEarned",-15}|{"Fouls/Takeovers",-20}|{"Passes",-15}");
                if (players.Count > 0)
                    foreach (Player player in players)
                        switch (player.GetType().ToString())
                        {
                            case "Lab5Sav4.Basketball":
                                sw.WriteLine(player as Basketball);
                                break;
                            case "Lab5Sav4.Football":
                                sw.WriteLine(player as Football);
                                break;
                        }
                else
                    sw.WriteLine("No Data Found");

                sw.WriteLine();
            }
            
        } 
    }
}
