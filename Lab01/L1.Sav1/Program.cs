using System;
using System.Collections.Generic;

namespace L1.Sav1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<GroupMember> members = GroupMember.ReadData("nariai.txt");
            Console.WriteLine($"Surinkta Pinigai: {GroupMember.GetContributedMoney(members)}");
            Console.WriteLine(new string('-', 74));
            GroupMember.PrintBiggestContributors(GroupMember.GetBiggestContributors(members));
            Console.ReadLine();
        }
    }
}
