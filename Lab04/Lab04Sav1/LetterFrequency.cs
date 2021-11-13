using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab04Sav1
{
    /// <summary>
    /// LetterFrequency Class
    /// </summary>
    class LetterFrequency
    {
        // Declarations
        public string Alphabet { get;}
        private Dictionary<char, int> Frequency;
        
        public LetterFrequency()
        {
            Alphabet = "AĄBCČDEĘĖFGHIĮYJKLMNOPRSŠTUŲŪVZŽ";
            Frequency = new Dictionary<char, int>();
            foreach (char ch in Alphabet)
            {
                Frequency[ch] = 0;
                Frequency[Char.ToLower(ch)] = 0;
            }
        }

        /// <summary>
        /// Add Function
        /// </summary>
        public void Add(char ch)
        {
            if (Frequency.ContainsKey(ch))
                Frequency[ch]++;
        }

        /// <summary>
        /// Get Function
        /// </summary>
        public int Get(char ch) => Frequency[ch];
    }
}
