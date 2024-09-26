

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace StockAnalyzerProject2
{

    public partial class Form2 : Form
    {
        private List<CandleStickData> _currentData;
        private int _currentPeriod;
        private string _currentPeriodName;

        public Form2()
        {
            InitializeComponent();

            chart1.Titles.Add("Candlestick Chart");

            // Instantiate the derived pattern recognizers
            EngulfingPatternRecognizer recognizerEngulfingPattern = new EngulfingPatternRecognizer();
            DragonflyDojiRecognizer recognizerDragonflyDoji = new DragonflyDojiRecognizer();
            DojiRecognizer recognizerDoji = new DojiRecognizer();
            GravestoneDojiRecognizer recognizerGravestoneDoji = new GravestoneDojiRecognizer();
            HammerRecognizer recognizerHammer = new HammerRecognizer();
            InvertedHammerRecognizer recognizerInvertedHammer = new InvertedHammerRecognizer();
            LongLeggedDojiRecognizer recognizerLongleggedDoji = new LongLeggedDojiRecognizer();
            MarubozuRecognizer recognizerMarabozu = new MarubozuRecognizer();
            NeutralDojiRecognizer recognizerNeutralDoji = new NeutralDojiRecognizer();
            HaramiPatternRecognizer recognizerHaramiPattern = new HaramiPatternRecognizer();

            // Add the instances of the derived pattern recognizers to the ComboBox
            patternComboBox.Items.Add(recognizerEngulfingPattern);
            patternComboBox.Items.Add(recognizerDragonflyDoji);
            patternComboBox.Items.Add(recognizerDoji);
            patternComboBox.Items.Add(recognizerGravestoneDoji);
            patternComboBox.Items.Add(recognizerHammer);
            patternComboBox.Items.Add(recognizerInvertedHammer);
            patternComboBox.Items.Add(recognizerLongleggedDoji);
            patternComboBox.Items.Add(recognizerMarabozu);
            patternComboBox.Items.Add(recognizerNeutralDoji);
            patternComboBox.Items.Add(recognizerHaramiPattern);

            // Add an event handler for the ComboBox
            patternComboBox.SelectedIndexChanged += PatternComboBox_SelectedIndexChanged;

        }

        private void PatternComboBox_SelectedIndexChanged(object sender, EventArgs e)
        // Event handler for the ComboBox that have patterns
        {
            if (patternComboBox.SelectedItem != null)
            {
                DisplayCandlestickChart(_currentData, _currentPeriod, _currentPeriodName);
            }
        }



       
        public void DisplayCandlestickChart(List<CandleStickData> data, int period, string periodName)
        // DisplayCandlestickChart() method is responsible for generating the candlestick chart based on the provided data,
        // highlighting the selected pattern and handling the chart's appearance.

        {
            // Set the current data, period, and period name
            // Check if data is available and display an error message if not
            // Instantiate pattern recognizers and get the indices of recognized patterns
            // Create a new candlestick series
            // Loop through the data and check for recognized patterns, then style the data points accordingly
            // Set up the chart's appearance, axes, and intervals
            // Add the pattern label to the chart conditionally
            _currentData = data;
            _currentPeriod = period;
            _currentPeriodName = periodName;


            EngulfingPatternRecognizer engulfingPatternRecognizer = new EngulfingPatternRecognizer();
            List<int> engulfingPatternIndices = engulfingPatternRecognizer.Recognize(data);

            DragonflyDojiRecognizer dragonflyDojiRecognizer = new DragonflyDojiRecognizer();
            List<int> dragonflyDojiIndices = dragonflyDojiRecognizer.Recognize(data);

            DojiRecognizer recognizerDoji = new DojiRecognizer();
            List<int> recognizerDojiIndices = recognizerDoji.Recognize(data);

            GravestoneDojiRecognizer gravestoneDojiRecognizer = new GravestoneDojiRecognizer();
            List<int> gravestoneDojiIndices = gravestoneDojiRecognizer.Recognize(data);

            HammerRecognizer hammerRecognizer = new HammerRecognizer();
            List<int> hammerIndices = hammerRecognizer.Recognize(data);

            InvertedHammerRecognizer invertedHammerRecognizer = new InvertedHammerRecognizer();
            List<int> invertedHammerIndices = invertedHammerRecognizer.Recognize(data);

            LongLeggedDojiRecognizer longleggedDojiRecognizer = new LongLeggedDojiRecognizer();
            List<int> longleggedDojiIndices = longleggedDojiRecognizer.Recognize(data);

            MarubozuRecognizer marubozuRecognizer = new MarubozuRecognizer();
            List<int> marubozuIndices = marubozuRecognizer.Recognize(data);

            NeutralDojiRecognizer neutralDojiRecognizer = new NeutralDojiRecognizer();
            List<int> neutralDojiIndices = neutralDojiRecognizer.Recognize(data);

            HaramiPatternRecognizer haramiPatternRecognizer = new HaramiPatternRecognizer();
            List<int> haramiPatternIndices = haramiPatternRecognizer.Recognize(data);

            var candlestickSeries = new Series { ChartType = SeriesChartType.Candlestick };

            // Retrieve the selected pattern recognizer from the ComboBox
            var selectedPattern = patternComboBox.SelectedItem as PatternRecognizers;

            for (int i = 0; i < data.Count; i++)
            {
                var record = data[i];
                var dataPoint = new DataPoint();
                dataPoint.SetValueXY(record.Date.Date, (double)record.High, (double)record.Low, (double)record.Open, (double)record.Close);

                // Check if the current index is an engulfing pattern and the ComboBox selected it
                if (selectedPattern is EngulfingPatternRecognizer && engulfingPatternIndices.Contains(i))
                {
                    dataPoint.Color = Color.Red;
                    dataPoint.Label = "Engulfing Pattern"; // Remove the label from here
                }
                // Check if the current index is a dragonfly doji pattern and the ComboBox selected it
                else if (selectedPattern is DragonflyDojiRecognizer && dragonflyDojiIndices.Contains(i))
                {
                    dataPoint.Color = Color.Green;
                    dataPoint.Label = "Dragonfly Doji"; // Remove the label from here

                }
                else if (selectedPattern is DojiRecognizer && recognizerDojiIndices.Contains(i))
                {
                    dataPoint.Color = Color.Orange;
                    dataPoint.Label = "Doji";
                }
                else if (selectedPattern is GravestoneDojiRecognizer && gravestoneDojiIndices.Contains(i))
                {
                    dataPoint.Color = Color.Purple;
                    dataPoint.Label = "Gravestone Doji";
                }
                else if (selectedPattern is HammerRecognizer && hammerIndices.Contains(i))
                {
                    dataPoint.Color = Color.Blue;
                    dataPoint.Label = "Hammer";
                }
                else if (selectedPattern is InvertedHammerRecognizer && invertedHammerIndices.Contains(i))
                {
                    dataPoint.Color = Color.Magenta;
                    dataPoint.Label = "Inverted Hammer";
                }
                else if (selectedPattern is LongLeggedDojiRecognizer && longleggedDojiIndices.Contains(i))
                {
                    dataPoint.Color = Color.Brown;
                    dataPoint.Label = "Long-legged Doji";
                }
                else if (selectedPattern is MarubozuRecognizer && marubozuIndices.Contains(i))
                {
                    dataPoint.Color = Color.DarkCyan;
                    dataPoint.Label = "Marubozu";
                }
                else if (selectedPattern is NeutralDojiRecognizer && neutralDojiIndices.Contains(i))
                {
                    dataPoint.Color = Color.DarkMagenta;
                    dataPoint.Label = "Neutral Doji";
                }
                else if (selectedPattern is HaramiPatternRecognizer && haramiPatternIndices.Contains(i))
                {
                    dataPoint.Color = Color.DarkBlue;
                    dataPoint.Label = "Harami Pattern";
                }
                else
                {
                    dataPoint.Color = (record.Open < record.Close) ? Color.Green : Color.Red;
                    dataPoint.BorderColor = (record.Open < record.Close) ? Color.DarkGreen : Color.DarkRed;
                }


                candlestickSeries.Points.Add(dataPoint);
            }
            //chart1.Titles.Add($"Candlestick Chart {periodName}");
            // Check if a legend with the name 'Legend' already exists
            if (chart1.Legends.FindByName("Legend") == null)
            {
                chart1.Legends.Add("Legend");
            }
            candlestickSeries["PriceUpColor"] = "Green";
            candlestickSeries["PriceDownColor"] = "Red";
            // Set the x-axis to display date values
            chart1.ChartAreas[0].AxisX.LabelStyle.Format = "yyyy-MM-dd";
            chart1.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Days;
            chart1.ChartAreas[0].AxisX.Interval = 10;
            chart1.ChartAreas[0].AxisX.Minimum = data.First().Date.AddDays(-1).Date.ToOADate();
            chart1.ChartAreas[0].AxisX.Maximum = data.Last().Date.AddDays(1).Date.ToOADate();
            chart1.ChartAreas[0].AxisX.LabelStyle.Angle = 90;

            decimal minValue = data.Min(d => d.Low);
            decimal maxValue = data.Max(d => d.High);

            // Optionally, add some padding to the min and max values
            decimal padding = (maxValue - minValue) * 0.1m;
            minValue -= padding;
            maxValue += padding;

            // Set the Y-axis Minimum and Maximum properties
            chart1.ChartAreas[0].AxisY.Minimum = (double)minValue;
            chart1.ChartAreas[0].AxisY.Maximum = (double)maxValue;

            //sets the Y-axis label to 2 decimal places
            chart1.ChartAreas[0].AxisY.LabelStyle.Format = "N2";

            chart1.Series.Clear();
            chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chart1.Series.Add(candlestickSeries);

            // Add the pattern labels conditionally
            if (selectedPattern != null)
            {
                var patternLabel = new CustomLabel();
                patternLabel.FromPosition = 0;
                patternLabel.ToPosition = data.Count;
                patternLabel.Text = selectedPattern.GetPatternName();
                patternLabel.ForeColor = Color.DarkBlue;
                patternLabel.RowIndex = 1;
                chart1.ChartAreas[0].AxisY.CustomLabels.Add(patternLabel);
            }
        }


        // AddTextAnnotation() method adds a text and line annotation to the chart
        // for a specific candlestick pattern, date, and price range.
        private void AddTextAnnotation(Chart chart, string dojiType, DateTime date, double low, double high)
        // Create and add a TextAnnotation to the chart
        // Create and add a LineAnnotation to the chart
        {
            string textAnnotationName = $"Text_{dojiType}_{date}";

            // Remove the existing TextAnnotation if it already exists
            var existingTextAnnotation = chart.Annotations.FindByName(textAnnotationName);
            if (existingTextAnnotation != null)
            {
                chart.Annotations.Remove(existingTextAnnotation);
            }

            TextAnnotation textAnnotation = new TextAnnotation();
            textAnnotation.Name = textAnnotationName;
            textAnnotation.Text = dojiType;
            textAnnotation.AxisX = chart.ChartAreas[0].AxisX;
            textAnnotation.AxisY = chart.ChartAreas[0].AxisY;
            textAnnotation.X = date.ToOADate();
            textAnnotation.Y = high * 1.05;
            textAnnotation.ForeColor = Color.Blue;
            textAnnotation.Font = new Font("Arial", 8);
            textAnnotation.ToolTip = $"{dojiType} on {date:yyyy-MM-dd}";
            chart.Annotations.Add(textAnnotation);

            // Do the same for the LineAnnotation
            string lineAnnotationName = $"Line_{dojiType}_{date}";

            var existingLineAnnotation = chart.Annotations.FindByName(lineAnnotationName);
            if (existingLineAnnotation != null)
            {
                chart.Annotations.Remove(existingLineAnnotation);
            }

            LineAnnotation lineAnnotation = new LineAnnotation();
            lineAnnotation.Name = lineAnnotationName;
            lineAnnotation.AxisX = chart.ChartAreas[0].AxisX;
            lineAnnotation.AxisY = chart.ChartAreas[0].AxisY;
            lineAnnotation.AnchorX = date.ToOADate();
            lineAnnotation.AnchorY = high;
            lineAnnotation.X = date.ToOADate();
            lineAnnotation.Y = high * 1.03;
            lineAnnotation.StartCap = LineAnchorCapStyle.None;
            lineAnnotation.EndCap = LineAnchorCapStyle.Arrow;
            lineAnnotation.LineWidth = 1;
            lineAnnotation.LineColor = Color.Blue;
            chart.Annotations.Add(lineAnnotation);
        }

    }
}