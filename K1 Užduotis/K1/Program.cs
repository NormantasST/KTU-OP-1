// Stankevičius Normantas IFF-1/4
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace K1
{
    class Program
    {
        const string CDoutput = "Result.txt";
        const string CDcandidates = "CandidateCV.txt";
        const string CDOffice = "Office.txt";
        static void Main(string[] args)
        {
            new StreamWriter(CDoutput).Close();
            OfficeCandidates allCandidates = InOut.ReadCandidatesData(CDcandidates);
            InOut.Print(allCandidates, CDoutput, "Pradiniai kandidatų duomenys:");
            List<Candidate> officeChoices = InOut.ReadOfficeData(CDOffice);
            InOut.Print(officeChoices, CDoutput, "Pradiniai ofisų ieškomų darbuotojų duomenys:");

            allCandidates.AddChoice(officeChoices);
            InOut.Print(allCandidates, CDoutput, "Papildyti kandidatų duomenys:");
            InOut.Print(officeChoices, CDoutput, "papildyti ofisų ieškomų darbuotojų duomenys:");

            using (StreamWriter sw = new StreamWriter(CDoutput, append: true))
                sw.WriteLine($"Pozicijoje: \"testuotojas\" vidutinis darbo stažas yra {allCandidates.Average("testuotojas"), 0:f}");

        }

    }

    /// <summary>
    /// Candidate Object/Class
    /// </summary>
    class Candidate
    {
        public string OfficeName { get; set; }
        public string CandidateName { get; set; }
        public string Position { get; set; }
        public int WorkYear { get; set; }
        public int CertificateNumber { get; set; }
        public bool Invited { get; set; }

        /// <summary>
        /// Default Constructor
        /// </summary>
        public Candidate(string officeName, string candidateName, string position, int workYear,
                         int certificateNumber, bool invited)
        {
            OfficeName = officeName;
            CandidateName = candidateName;
            Position = position;
            WorkYear = workYear;
            CertificateNumber = certificateNumber;
            Invited = invited;
        }

        /// <summary>
        /// Simplified Office Constructor
        /// </summary>
        public Candidate(string officeName, string position)
        {
            OfficeName = officeName;
            CandidateName = "";
            Position = position;
            WorkYear = 0;
            CertificateNumber = 0;
            Invited = true;
        }

        /// <summary>
        /// ToString() override
        /// </summary>
        public override string ToString()
        {
            return $"{OfficeName,-20}|{CandidateName,-20}|{Position,-30}|{WorkYear,15}|{CertificateNumber,20}|{Invited,-10}|";
        }

        /// <summary>
        /// Opearotr <= implementation
        /// </summary>
        public static bool operator <=(Candidate lhs, Candidate rhs)
        {
            if (lhs.Position == rhs.Position && (lhs.WorkYear < rhs.WorkYear || (lhs.WorkYear == rhs.WorkYear && lhs.CertificateNumber <= rhs.CertificateNumber)))
                return true;
            else
                return false;
        }

        /// <summary>
        /// Opearotr >= implementation
        /// </summary>
        public static bool operator >=(Candidate lhs, Candidate rhs)
        {
            if (lhs.Position == rhs.Position && (lhs.WorkYear > rhs.WorkYear || (lhs.WorkYear == rhs.WorkYear && lhs.CertificateNumber >= rhs.CertificateNumber)))
                return true;
            else
                return false;
        }
    }

    /// <summary>
    /// OfficeCandidates class/object
    /// </summary>
    class OfficeCandidates
    {
        private List<Candidate> Candidates;

        /// <summary>
        /// Default Construcotr
        /// </summary>
        public OfficeCandidates()
        {
            Candidates = new List<Candidate>();
        }

        /// <summary>
        /// Specialized Constructor
        /// </summary>
        public OfficeCandidates(List<Candidate> candidates)
        {
            Candidates = candidates;
        }


        /// <summary>
        /// Gets How many Candidates are in Register
        /// </summary>
        public int GetCount()
        {
            return Candidates.Count;
        }

        /// <summary>
        /// Gets Entry from a Register
        /// </summary>
        public Candidate GetEntry(int index)
        {
            try
            {
                Candidate output = Candidates[index];
                return output;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        /// <summary>
        /// Adds entry to a Register
        /// </summary>
        public void AddEntry(Candidate candidate)
        {
            Candidates.Add(candidate);
        }

        /// <summary>
        /// Average WorkYear in specified Position
        /// </summary>
        public double Average(string position)
        {
            int devider = 0;
            int sum = 0;

            foreach (Candidate candidate in Candidates)
            {
                if(candidate.Position == position)
                {
                    devider++;
                    sum += candidate.WorkYear;
                }
            }

            if (devider == 0)
                return 0;
            else
                return
                    (double)sum / devider;
        }

        /// <summary>
        /// Finds best choice for the company in specified position
        /// </summary>
        public int MaxIndex(Candidate candidate)
        {
            Candidate curr = new Candidate(candidate.OfficeName, candidate.Position);
            int index = -1;
            for (int i = 0; i < Candidates.Count; i++)
            {
                Candidate selected = Candidates[i];
                if(selected.Invited == false && selected >= curr)
                {
                    index = i;
                    curr = selected;
                }
            }

            return index;
        }

        /// <summary>
        /// Finds A choice for an office
        /// </summary>
        public void AddChoice(List<Candidate> officeChoise)
        {
            foreach (Candidate choice in officeChoise)
            {
                int index = MaxIndex(choice);
                if (index != -1)
                {
                    Candidate candidate = GetEntry(index);
                    candidate.Invited = true;
                    candidate.OfficeName = choice.OfficeName;

                    choice.CandidateName = candidate.CandidateName;
                    choice.WorkYear = candidate.WorkYear;
                    choice.CertificateNumber = candidate.CertificateNumber;
                }
            }
        }

    }

    /// <summary>
    /// Input/Output Utility/Helper Static Class
    /// </summary>
    static class InOut
    {
        /// <summary>
        /// Reads Data to OfficeCandidates File
        /// </summary>
        public static OfficeCandidates ReadCandidatesData(string fileName)
        {
            OfficeCandidates candidates = new OfficeCandidates();
            string[] lines = File.ReadAllLines(fileName);
            foreach (string line in lines)
            {
                string[] elements = line.Split(';');
                candidates.AddEntry(new Candidate(elements[0],
                                              elements[1],
                                              elements[2],
                                              int.Parse(elements[3]),
                                              int.Parse(elements[4]),
                                              bool.Parse(elements[5])
                                              )
                               );


            }

            return candidates;

        }

        /// <summary>
        /// Reads Office Data Files
        /// </summary>
        public static List<Candidate> ReadOfficeData(string fileName)
        {
            List<Candidate> officeChoice = new List<Candidate>();
            string[] lines = File.ReadAllLines(fileName);

            foreach (string line in lines)
            {
                string[] elements = line.Split(';');
                officeChoice.Add(new Candidate(elements[0], elements[1]));
            }

            return officeChoice;
        }


        /// <summary>
        /// Print Function from OfficeCnadidates to File
        /// </summary>
        public static void Print(OfficeCandidates allCandidates, string fileName, string header)
        {
            using (StreamWriter sw = new StreamWriter(fileName, append:true))
            {
                sw.WriteLine(header);
                sw.WriteLine(new string('-', 121));
                sw.WriteLine($"{"Firma",-20}|{"Pavardė",-20}|{"Pozicija",-30}|{"Darbo Stažas",-15}|{"Sertifikatų skaičius",-20}|{"Pakviestas",-10}|");
                sw.WriteLine(new string('-', 121));

                if (allCandidates.GetCount() > 0)
                    for (int i = 0; i < allCandidates.GetCount(); i++)
                        sw.WriteLine(allCandidates.GetEntry(i).ToString());
                else
                    sw.WriteLine("Duomenų nėra");

                sw.WriteLine();
            }
        }

        public static void Print(List<Candidate> officeChoice, string fileName, string header)
        {
            using (StreamWriter sw = new StreamWriter(fileName, append: true))
            {
                sw.WriteLine(header);
                sw.WriteLine(new string('-', 121));
                sw.WriteLine($"{"Firma",-20}|{"Pavardė",-20}|{"Pozicija",-30}|{"Darbo Stažas",-15}|{"Sertifikatų skaičius",-20}|{"Pakviestas",-10}|");
                sw.WriteLine(new string('-', 121));

                if (officeChoice.Count > 0)
                    for (int i = 0; i < officeChoice.Count; i++)
                        sw.WriteLine(officeChoice[i].ToString());
                else
                    sw.WriteLine("Duomenų nėra");



                sw.WriteLine();
            }
        }

    }


}
