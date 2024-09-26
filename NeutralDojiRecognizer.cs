using System;
using System.Collections.Generic;
using StockAnalyzerProject2;

namespace StockAnalyzerProject2
{



    // This class is a derived class of the PatternRecognizersclass.
    // It is responsible for recognizing the Neutral Doji candlestick pattern in a given list of CandleStickData.
    public class NeutralDojiRecognizer : PatternRecognizers
    {
        public string GetPatternName()
        {
            return "Neutral Doji";
            // Return name of the candlestick pattern: "Neutral Doji"
        }

        
        
        public List<int> Recognize(List<CandleStickData> data)
        // Recognize() method scans the list of CandleStickData and
        // returns the indices of candles that form a Neutral Doji pattern.
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


        // IsPatternPresent() method checks if
        // a Neutral Doji pattern is present at a specific index in the given list of CandleStickData.
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

            // Check if the candle at the given index satisfies the conditions for a Neutral Doji pattern.
            bool isNeutralDoji = body <= 0.1 * range && upperTail >= 0.4 * range && lowerTail >= 0.4 * range && Math.Abs(upperTail - lowerTail) <= 0.1 * range;
            return isNeutralDoji;
        }

        
        public override string ToString()
        // Overrides the ToString() method to return the name of the pattern: "Neutral Doji"
        {
            return "Neutral Doji";
        }
    }
}
