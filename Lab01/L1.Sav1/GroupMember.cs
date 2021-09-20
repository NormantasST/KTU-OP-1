using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L1.Sav1
{
    class GroupMember
    {
        public double Money { get; set; }
        public string Name  { get; set; }

        public GroupMember(string name,
                           double money)
        {
            Name  = name;
            Money = money;
        }

        public static List<GroupMember> ReadData(string inputFile)
        {
            List<GroupMember> members = new List<GroupMember>();

            using (StreamReader sw = new StreamReader(inputFile))
            {
                string line;
                while ((line = sw.ReadLine()) != null)
                {
                    string[] items = line.Split(';');
                    members.Add(new GroupMember(items[0], double.Parse(items[1])));
                }
            }

            return members;
        }

        public static List<String> GetBiggestContributors(List<GroupMember> members)
        {
            List<string> output = new List<string>();
            double larContribution = 0;

            foreach (GroupMember member in members)
            {
                if (larContribution < member.Money)
                {
                    output.Clear();
                    output.Add(member.Name);
                    larContribution = member.Money;
                }
                else if (larContribution == member.Money)
                {
                    output.Add(member.Name);
                }
            }

            return output;
        }

        public static void PrintBiggestContributors(List<string> names)
        {
            Console.WriteLine("Daugiausiai skyrė pinigų išlaidoms:");

            foreach (string name in names)
                Console.WriteLine($"{name}");
            
        }

        public static double GetContributedMoney(List<GroupMember> members)
        {
            double contributed = 0;
            foreach (GroupMember member in members)
                contributed += (double)member.Money * 0.25;

            return contributed;
        }
    }
}
