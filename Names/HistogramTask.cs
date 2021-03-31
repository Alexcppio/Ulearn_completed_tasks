using System;
using System.Linq;

namespace Names
{
    internal static class HistogramTask
    {
        public static HistogramData GetBirthsPerDayHistogram(NameData[] names, string name)
        {
            var birthsPerDay = new double[31];
            var daysCount = new string[birthsPerDay.Length];
            birthsPerDay[0] = 0;

            for (int i = 0; i < birthsPerDay.Length; i++)
            {
                daysCount[i] = (i + 1).ToString();
            }

            foreach (var day in names)
            {
                if (day.Name == name
                    && day.BirthDate.Day != 1)
                {
                    birthsPerDay[day.BirthDate.Day - 1]++;
                }
            }

            return new HistogramData(
                string.Format("Рождаемость людей с именем '{0}'", name),
                daysCount, 
                birthsPerDay);
        }
    }
}