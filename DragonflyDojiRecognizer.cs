using System;
using System.Collections.Generic;
using StockAnalyzerProject2;

namespace StockAnalyzerProject2
{


    // The DragonflyDojiRecognizer is a derived class of the PatternRecognizers abstract  class.
    // and responsible for recognizing the Dragonfly Doji candlestick pattern in a CandleStickData list
    public class DragonflyDojiRecognizer : PatternRecognizers
    {

        // Returns the name of the pattern: "Dragonfly Doji"
        public string GetPatternName()
        {
            return "Dragonfly Doji";
        }



        // Recognize() method checks in the list of CandleStickData 
        // returns the indices of candles that form a Dragonfly Doji pattern.
        public List<int> Recognize(List<CandleStickData> data)
        {
            List<int> indices = new List<int>();

            for (int i = 0; i < data.Count; i++)
            {
                if (IsPatternPresent(data, i))
                {
                    indices.Add(i);
                }
            }

            return indices;
        }

        // IsPatternPresent() method checks if a Dragonfly Doji pattern is
        // present at a specific index in the given CandleStickData.
        public bool IsPatternPresent(List<CandleStickData> data, int index)
        {
            double open = (double)data[index].Open;
            double close = (double)data[index].Close;
            double high = (double)data[index].High;
            double low = (double)data[index].Low;
            double range = high - low;
            double body = Math.Abs(open - close);
            double upperTail = high - Math.Max(open, close);
            double lowerTail = Math.Min(open, close) - low;
            //calculation to identify the pattern
            bool isDragonflyDoji = body <= 0.2 * range && lowerTail >= 2 * upperTail && upperTail <= 0.2 * range;
            return isDragonflyDoji;
        }

        // Overrides the method below to return the name of the pattern: "Dragonfly Doji"
        public override string ToString()
        {
            return "Dragonfly Doji";
        }
    }
}