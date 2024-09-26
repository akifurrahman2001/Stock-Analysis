using System;
using System.Collections.Generic;
using StockAnalyzerProject2;

namespace StockAnalyzerProject2
{
    public class GravestoneDojiRecognizer : PatternRecognizers
    {

        // The GravestoneDojiRecognizer class is a derived class from the PatternRecognizers.
        // It is responsible for recognizing the Gravestone Doji candlestick pattern in a given CandleStickData list
        public string GetPatternName()
        {
            return "Gravestone Doji";
            // Returns the candlestick pattern name: "Gravestone Doji"
        }


        // Recognize() method scans the CandleStickData list which returns the indices of candles that form a Gravestone Doji pattern.
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


        // IsPatternPresent() method checks if a Gravestone Doji pattern is present at a specific index
        // in the given list of CandleStickData.
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

            // Check if the candle at the given index satisfies the conditions for a Gravestone Doji pattern.
            bool isGravestoneDoji = body <= 0.2 * range && upperTail >= 2 * lowerTail && lowerTail <= 0.2 * range;
            return isGravestoneDoji;
        }


        //gives the name as Gravestone Doji in combobox
        public override string ToString()
        {
            return "Gravestone Doji";
        }
    }
}