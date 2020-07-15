using System.Linq;
using System.Threading.Tasks;
using ChartJs.Blazor.ChartJS.Common;
using ChartJs.Blazor.ChartJS.Common.Enums;
using ChartJs.Blazor.ChartJS.LineChart;
using ChartJs.Blazor.Charts;
using ChartJs.Blazor.Util;
using Covid19Data.Models;
using Covid19Data.Services;
using Covid19Data.Shared;
using Microsoft.AspNetCore.Components;

namespace Covid19Data.Pages
{
    public class BrazilBase : ComponentBase
    {
        [Inject]
        public IDataSourceService DataSource { get; set; }

        public CovidDataFioCruz Data { get; set; }

        public ChartJsLineChart DailyChart { get; set; }

        public ChartJsLineChart TotalChart { get; set; }

        public LineConfig ConfigDaily { get; set; }

        public LineConfig ConfigTotal { get; set; }

        public string Mode { get; set; } = "TOTAL";

        private LineDataset<Point> casesPerDaySet;

        private LineDataset<Point> deathsPerDaySet;

        private LineDataset<Point> totalCasesPerDaySet;

        private LineDataset<Point> totalDeathsPerDaySet;

        protected override async Task OnInitializedAsync()
        {
            ConfigDailyChart();
            ConfigTotalChart();

            Data = await DataSource.getFioCruzData();

            casesPerDaySet.AddRange(Data.DailyData.Select(day => new Point(Data.DailyData.IndexOf(day) + 1, day.NewCases)));
            deathsPerDaySet.AddRange(Data.DailyData.Select(day => new Point(Data.DailyData.IndexOf(day) + 1, day.NewDeaths)));

            totalCasesPerDaySet.AddRange(Data.DailyData.Select(day => new Point(Data.DailyData.IndexOf(day) + 1,
                Data.DailyData.GetRange(0, Data.DailyData.IndexOf(day) + 1).Sum(s => s.NewCases))));
            totalDeathsPerDaySet.AddRange(Data.DailyData.Select(day => new Point(Data.DailyData.IndexOf(day) + 1,
                Data.DailyData.GetRange(0, Data.DailyData.IndexOf(day) + 1).Sum(s => s.NewDeaths))));

            ConfigDaily.Data.Datasets.Add(casesPerDaySet);
            ConfigDaily.Data.Datasets.Add(deathsPerDaySet);

            ConfigTotal.Data.Datasets.Add(totalCasesPerDaySet);
            ConfigTotal.Data.Datasets.Add(totalDeathsPerDaySet);

            await base.OnInitializedAsync();
        }

        private void ConfigDailyChart()
        {
            ConfigDaily = Helper.GetLineChartConfig("Brazil Covid-19 Daily Evolution", "Days", "Victims");

            casesPerDaySet = new LineDataset<Point>
            {
                BackgroundColor = ColorUtil.ColorString(0, 255, 0, 1.0),
                BorderColor = ColorUtil.ColorString(0, 0, 255, 1.0),
                Label = "New Cases",
                Fill = false,
                PointBackgroundColor = ColorUtil.ColorString(0, 0, 255, 1.0),
                BorderWidth = 1,
                PointRadius = 3,
                PointBorderWidth = 1,
                SteppedLine = SteppedLine.False,
            };

            deathsPerDaySet = new LineDataset<Point>
            {
                BackgroundColor = ColorUtil.ColorString(255, 0, 0, 1.0),
                BorderColor = ColorUtil.ColorString(255, 0, 0, 1.0),
                Label = "New Deaths",
                Fill = false,
                BorderWidth = 1,
                PointRadius = 2,
                PointBorderWidth = 1,
                SteppedLine = SteppedLine.False
            };
        }

        private void ConfigTotalChart()
        {
            ConfigTotal = Helper.GetLineChartConfig("Brazil Covid-19 Total Evolution", "Days", "Victims");

            totalCasesPerDaySet = new LineDataset<Point>
            {
                BackgroundColor = ColorUtil.ColorString(0, 255, 0, 1.0),
                BorderColor = ColorUtil.ColorString(0, 0, 255, 1.0),
                Label = "Total Cases",
                Fill = false,
                PointBackgroundColor = ColorUtil.ColorString(0, 0, 255, 1.0),
                BorderWidth = 1,
                PointRadius = 3,
                PointBorderWidth = 1,
                SteppedLine = SteppedLine.False,
            };

            totalDeathsPerDaySet = new LineDataset<Point>
            {
                BackgroundColor = ColorUtil.ColorString(255, 0, 0, 1.0),
                BorderColor = ColorUtil.ColorString(255, 0, 0, 1.0),
                Label = "Total Deaths",
                Fill = false,
                BorderWidth = 1,
                PointRadius = 2,
                PointBorderWidth = 1,
                SteppedLine = SteppedLine.False
            };
        }
    }
}