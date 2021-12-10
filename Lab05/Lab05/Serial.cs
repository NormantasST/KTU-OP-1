using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab05
{
    /// <summary>
    /// Serial Class inherited from record claass.
    /// Meant to be used for Tv Shows (Serialized) media
    /// </summary>
    class Serial : Record
    {
        public bool StillGoing { get; set; }
        public int StartYear { get; set; }
        public int EndYear { get; set; }
        public int EpisodeCount { get; set; }
        /// <summary>
        /// Constructor for a serial that ended
        /// </summary>
        public Serial(string name, string genre, string studio, string actor1, string actor2, int episodeCount, int startYear, int endYear, bool status) : base(name, genre, studio, actor1, actor2)
        {
            EpisodeCount = episodeCount;
            StartYear = startYear;
            EndYear = endYear;
            StillGoing = status;
        }

        /// <summary>
        /// Constructor for a serial that is still airing
        /// </summary>
        public Serial(string name, string genre, string studio, string actor1, string actor2, int episodeCount, int startYear, bool status) : base(name, genre, studio, actor1, actor2)
        {
            EpisodeCount = episodeCount;
            StartYear = startYear;
            StillGoing = status;
        }

        /// <summary>
        /// ToString() override
        /// </summary>
        public override string ToString()
        {
            return ToString('|');
        }

        /// <summary>
        /// ToString(char splitter) from class Record override
        /// </summary>
        public override string ToString(char splitter)
        {
            string output =  $"{"Serial",-20}{splitter}" +
                   base.ToString(splitter) +
                   $"{EpisodeCount,20}{splitter}" +
                   $"{StartYear,20}{splitter}" +
                   $"{StillGoing,-20}{splitter}";

            if (StillGoing == false)
                output += $"{EndYear,-20}{splitter}";

            return output;
        }
    }
}