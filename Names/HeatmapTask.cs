using System;

namespace Names
{
    internal static class HeatmapTask
    {
        public static HeatmapData GetBirthsPerDateHeatmap(NameData[] names)
        {
            var days = new string[30];
            var months = new string[12];
            var birthsMonthDate = new double[days.Length, months.Length];

            for(var i = 0; i < days.Length; i++)
            {
                if(i != 0)
                {
                    days[i] = (i + 2).ToString();
                }
            }

            for(var i = 0; i < months.Length; i++)
            {
                months[i] = (i + 1).ToString();
            }

            foreach (var name in names)
            {
                if (name.BirthDate.Day != 1)
                {
                    birthsMonthDate[name.BirthDate.Day - 2, name.BirthDate.Month - 1]++;
                }
            }

            return new HeatmapData(
                "Пример карты интенсивностей",
                birthsMonthDate,
                days,
                months);
        }
    }
}