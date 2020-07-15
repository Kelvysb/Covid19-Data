using System;
using System.Collections.Generic;
using ChartJs.Blazor.ChartJS.Common;
using ChartJs.Blazor.ChartJS.Common.Axes;
using ChartJs.Blazor.ChartJS.Common.Enums;
using ChartJs.Blazor.ChartJS.Common.Handlers;
using ChartJs.Blazor.ChartJS.Common.Properties;
using ChartJs.Blazor.ChartJS.LineChart;

namespace Covid19Data.Shared
{
    public class Helper
    {
        public static string FormatDate(DateTime input)
        {
            return input.ToString("MM/dd/yyyy");
        }

        public static LineConfig GetLineChartConfig(string title, string xAxis, string yAxis)
        {
            return new LineConfig()
            {
                Options = new LineOptions()
                {
                    Title = new OptionsTitle()
                    {
                        Display = true,
                        Text = title
                    },
                    Responsive = true,
                    Legend = new Legend
                    {
                        Position = Position.Right
                    },
                    Scales = new Scales
                    {
                        xAxes = new List<CartesianAxis>
                    {
                        new LinearCartesianAxis
                        {
                            ScaleLabel = new ScaleLabel
                            {
                                LabelString = xAxis
                            },
                            GridLines = new GridLines
                            {
                                Display = false
                            }
                        }
                    },
                        yAxes = new List<CartesianAxis>
                    {
                        new LinearCartesianAxis
                        {
                            ScaleLabel = new ScaleLabel
                            {
                                LabelString = yAxis
                            }
                        }
                    }
                    }
                }
            };
        }
    }
}