using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab04Sav1
{
    class LettersFrequency
    {

        public string Alphabet { get; }
        private const int CMax = 256;
        private Dictionary<char, int> Frequency; // Frequency of letters
        public string line { get; set; }
        public LettersFrequency()
        {
            Alphabet = "aąbčdeęėfghiįjklmnopqrsštuųūvwxyzž";
            Frequency = new Dictionary<char, int>();
            foreach (char ch in Alphabet)
            {
                Frequency.Add(ch, 0);
                Frequency.Add(Char.ToUpper(ch), 0);
            }
        }
        public int Get(char character)
        {
            if (Frequency.ContainsKey(character))
                return Frequency[character];
            else
                return 0;
        }


        public void Add(char ch)
        {
            if (Frequency.ContainsKey(ch))
                Frequency[ch]++;
        }

        public char[] GetSortedLetterString()
        {
            char[] letterString = Alphabet.ToArray();
            for (int i = 0; i < letterString.Length - 1; i++)
                for (int j = 0; j < letterString.Length - 1 - i; j++)
                {
                    // lhs - left hand side, rhs - right hand side
                    int sumlhs = Frequency[letterString[j]] + Frequency[Char.ToUpper(letterString[j])];
                    int sumrhs = Frequency[letterString[j + 1]] + Frequency[Char.ToUpper(letterString[j + 1])];

                    // Swap
                    if (sumlhs < sumrhs)
                    {
                        char temp = letterString[j];
                        letterString[j] = letterString[j + 1];
                        letterString[j + 1] = temp;
                    }
                }

            return letterString;
        }
    }
}
