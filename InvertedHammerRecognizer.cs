using System;
using System.Collections.Generic;
using StockAnalyzerProject2;

namespace StockAnalyzerProject2
{
    public class InvertedHammerRecognizer : PatternRecognizers
    {


        // The InvertedHammerRecognizer class is a derived class of the abstract base class called pattern recognizer.
        // Which is responsible for recognizing the Inverted Hammer candlestick pattern in a given list of CandleStickData.
        public string GetPatternName()
        {
            return "Inverted Hammer";
        }


        // This Recognize() method scans the list of CandleStickData and
        // returns the indices of candles that form an Inverted Hammer pattern.
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


        // This Method belowchecks if an Inverted Hammer pattern is present at a specific index in the given list of CandleStickData.
        public bool IsPatternPresent(List<CandleStickData> data, int index)
        {
            double open = (double)data[index].Open;
            double close = (double)data[index].Close;
            double high = (double)data[index].High;
            double low = (double)data[index].Low;
            double range = high - low;
            double body = Math.Abs(open - close);
            double uppertail = high - Math.Max(open, close);
            double lowertail = Math.Min(open, close) - low;

            bool isInvertedHammer = lowertail < 0.15 * range && body > 0.2 * range && body < 0.35 * range && uppertail > 2 * body;
            return isInvertedHammer;
        }


        // Overrides the ToString() method to return the name of the pattern: "Inverted Hammer"
        public override string ToString()
        {
            return "Inverted Hammer";
        }
    }
}
