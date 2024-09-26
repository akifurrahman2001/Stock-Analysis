using System;
using System.Collections.Generic;
using StockAnalyzerProject2;

namespace StockAnalyzerProject2
{
    // The DojiRecognizer  is a derived class of the PatternRecognizers abstract class.
    // It is responsible for recognizing the Doji candlestick pattern in the CandleStickData list.
    public class DojiRecognizer : PatternRecognizers
    {
        // Returns the candlestick pattern name as : "Doji"
        public string GetPatternName()
        {
            return "Doji";
        }

        //This Recognize() method below scans the CandleStickData list and returns the candles indices that makes Doji pattern.
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

        // The IsPatternPresent() method looks for a  Doji pattern at a specific index in the given CandleStickData list.
        public bool IsPatternPresent(List<CandleStickData> data, int index)
        {
            double open = (double)data[index].Open;
            double close = (double)data[index].Close;
            double high = (double)data[index].High;
            double low = (double)data[index].Low;

            // Calculation criteria to identify a doji
            bool isDoji = Math.Abs(open - close) <= (Math.Abs(high - low) * 0.1);

            return isDoji;
        }


        // Overrides the ToString() method to return pattern name : "Doji"
        public override string ToString()
        {
            return "Doji";
        }


    }
}