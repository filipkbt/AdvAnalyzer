using System.Collections.Generic;

namespace AdvAnalyzer.WebApi.Dtos
{
    public class ChartDataDto
    {
        public List<ChartSingleDataDto> ChartData { get; set; }
    }

    public class ChartSingleData
    {
        public string Name { get; set; }
        public Serie Serie { get; set; }
    }

    public class Serie
    {
        public string Name { get; set; }
        public int Value { get; set; }
    }

    public class ChartSingleDataDto
    {
        public string Name { get; set; }
        public Serie Serie { get; set; }
        public List<Serie> Series { get; set; }
    }
}
