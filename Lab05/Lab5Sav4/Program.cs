using System;
using System.Collections.Generic;

namespace Lab5Sav4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            InOutUtils.CreateFile("Output.txt");

            List<Team> teams = InOutUtils.ReadTeams("Komandos3.txt");
            InOutUtils.WriteTeams(teams, "output.txt", "Initial Teams:");
            List<Player> players = InOutUtils.ReadPlayers("Sportininkai3.txt");
            InOutUtils.WritePlayers(players, "output.txt", "Initial Players:");

            List<Player> BestPlayers = TaskUtils.BestPlayers(players, teams, "Klaipėda");
            InOutUtils.WritePlayers(BestPlayers, "output.txt", "Best Players:");
        }
    }
}
