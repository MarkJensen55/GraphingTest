using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DotNet.Highcharts;
using DotNet.Highcharts.Enums;
using DotNet.Highcharts.Helpers;
using DotNet.Highcharts.Options;


namespace GraphingTest.Models
{
    // create a highcharts chart to pass to the controller
    public class TestChart
    {
        public Highcharts CreateChart(DateTime[] xdata, object[][] ydata)
        {
            var xdataString = new string[xdata.Count()];
            for (int i = 0; i < xdata.Count(); i++)
			{
                xdataString[i] = xdata[i].ToLongDateString();
			}

            var plotBand =  new YAxisPlotBands();
            plotBand.Color = System.Drawing.Color.LightGreen;
            plotBand.From = 45;
            plotBand.To=100;



            var whyAxis = new YAxis();
            whyAxis.PlotBands = new[] { plotBand };
            var myTitle = new YAxisTitle();
            myTitle.Text = "Some Units";
            whyAxis.Title =  myTitle;


            var chart = new Highcharts("chart");
            chart.InitChart(new Chart { DefaultSeriesType = ChartTypes.Line });
            chart.SetTitle(new Title { Text = "Glucose Level" });
            chart.SetXAxis(new XAxis { Categories = xdataString });
            chart.SetYAxis(whyAxis);
            chart.SetSeries(new[] {new Series{Name="Glucose Level", Data = new Data(ydata)}});

            return chart;
        }
    }
}