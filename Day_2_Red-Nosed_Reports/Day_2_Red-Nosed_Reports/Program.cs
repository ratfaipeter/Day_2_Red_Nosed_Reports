namespace Day_2_Red_Nosed_Reports
{
    internal class Program
    {
        /// <summary>
        /// Determines whether the sequence is monotone.
        /// </summary>
        /// <param name="report">One row of levels.</param>
        /// <returns>Returns true if the sequence is monotone.</returns>
        static bool MonotoneOfTheSequence(List<int> report, ref int failCounter)
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
                    failCounter++;
                    if (failCounter > 1)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Determines the difference between levels.
        /// </summary>
        /// <param name="report">One row of levels.</param>
        /// <returns>Returns true if any two adjacent levels differ by at least one and at most three.</returns>
        static bool DifferenceOfLevels(List<int> report, ref int failCounter)
        {
            for (var level = 0; level < report.Count - 1; level++)
            {
                var difference = report[level] - report[level + 1];
                if (!(difference >= -3 && difference <= -1) && !(difference >= 1 && difference <= 3))
                {
                    failCounter++;
                    if (failCounter > 1)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        static void Main(string[] args)
        {
            var sr = new StreamReader("test_data.txt");
            var safeCount = 0;

            while (!sr.EndOfStream)
            {
                var report = sr.ReadLine();
                var reportArray = report.Split(' ');
                var failCounter = 0;

                List<int> currentReport = new List<int>();
                foreach (var item in reportArray)
                {
                    currentReport.Add(Convert.ToInt32(item));
                }

                if (DifferenceOfLevels(currentReport, ref failCounter) && MonotoneOfTheSequence(currentReport, ref failCounter))
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
