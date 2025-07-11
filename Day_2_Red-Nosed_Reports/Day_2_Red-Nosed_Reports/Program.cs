namespace Day_2_Red_Nosed_Reports
{
    internal class Program
    {
        /// <summary>
        /// Determines whether the sequence is monotone.
        /// </summary>
        /// <param name="report">One row of levels.</param>
        /// <param name="failCounter">Counter of failures.</param>
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
                    
                    if (failCounter == 1)
                    {
                        var temp = new List<int>(report);
                        temp.RemoveAt(level);

                        if (MonotoneOfTheSequence(temp, ref failCounter))
                        {
                            return true;
                        }
                        else
                        {
                            failCounter = 1;
                            var temp2 = new List<int>(report);
                            temp2.RemoveAt(level + 1);

                            return MonotoneOfTheSequence(temp2, ref failCounter);
                        }
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Determines the difference between levels.
        /// </summary>
        /// <param name="report">One row of levels.</param>
        /// <param name="failCounter">Counter of failures.</param>
        /// <returns>Returns true if any two adjacent levels differ by at least one and at most three.</returns>
        static bool DifferenceOfLevels(List<int> report, ref int failCounter)
        {
            for (var level = 0; level < report.Count - 1; level++)
            {
                var difference = Math.Abs(report[level] - report[level + 1]);
                if (!(difference >= 1 && difference <= 3))
                {
                    
                    failCounter++;
                    if (failCounter > 1)
                    {
                        return false;
                    }

                    if (failCounter == 1)
                    {
                        var temp = new List<int>(report);
                        temp.RemoveAt(level);

                        if (DifferenceOfLevels(temp, ref failCounter))
                        {
                            report = temp;

                            return true;
                        }
                        else
                        {
                            failCounter = 1;
                            report.RemoveAt(level + 1);

                            return DifferenceOfLevels(report, ref failCounter);
                        }
                    }
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
