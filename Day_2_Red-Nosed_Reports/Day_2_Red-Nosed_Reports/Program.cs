using System;
using System.Collections.Generic;
using System.IO;

namespace Day_2_Red_Nosed_Reports
{
    internal class Program
    {
        /// <summary>
        /// Determines whether the sequence is monotone.
        /// </summary>
        /// <param name="report">One row of levels.</param>
        /// <returns>Returns true if the sequence is monotone.</returns>
        static bool MonotoneOfTheSequence(List<int> report)
        {
            var ascending = 0;
            var descending = 0;

            for (var level = 0; level < report.Count - 1; level++)
            {
                if (report[level] > report[level + 1])
                {
                    descending++;
                }
                else
                {
                    ascending++;
                }

                if ((ascending > 0) && (descending > 0))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Determines the difference between levels.
        /// </summary>
        /// <param name="report">One row of levels.</param>
        /// <returns>Returns true if any two adjacent levels differ by at least one and at most three.</returns>
        static bool DifferenceOfLevels(List<int> report)
        {
            for (var level = 0; level < report.Count - 1; level++)
            {
                var difference = report[level] - report[level + 1];
                if (!(difference >= -3 && difference <= -1) && !(difference >= 1 && difference <= 3))
                {
                    return false;
                }
            }

            return true;
        }

        static void Main(string[] args)
        {
            var sr = new StreamReader("unusual_data.txt");
            var safeCount = 0;

            while (!sr.EndOfStream)
            {
                var report = sr.ReadLine();
                var reportArray = report.Split(' ');

                List<int> currentReport = new List<int>();
                foreach (var item in reportArray)
                {
                    currentReport.Add(Convert.ToInt32(item));
                }

                if (DifferenceOfLevels(currentReport) && MonotoneOfTheSequence(currentReport))
                {
                    Console.WriteLine("Safe");
                    safeCount++;
                }
                else
                {
                    Console.WriteLine("Unsafe");
                }
            }

            sr.Close();
            Console.WriteLine("The count of safe reports: {0}", safeCount);
        }
    }
}
