using System;
using System.Collections.Generic;
using StockAnalyzerProject2;

namespace StockAnalyzerProject2
{
    public class MarubozuRecognizer : PatternRecognizers
    {

        // The MarubozuRecognizer class is a derived class of the PatternRecognizers abstract base class.
        // It is responsible for recognizing the Marubozu candlestick pattern in a given list of CandleStickData.
        public string GetPatternName()
        {   // Returns the name of the candlestick pattern: "Marubozu"
            return "Marubozu";
        }


        // Recognize() method scans the list of CandleStickData and
        // returns the indices of candles that form a Marubozu pattern.
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
        // IsPatternPresent() method checks if a Marubozu pattern is present at a
        // specific index in the given list of CandleStickData.
        public bool IsPatternPresent(List<CandleStickData> data, int index)
        {
            double open = (double)data[index].Open;
            double close = (double)data[index].Close;
            double high = (double)data[index].High;
            double low = (double)data[index].Low;
            double range = high - low;
            double body = Math.Max(open, close) - Math.Min(open, close);

            bool isMarubozu = body > 0.80*range;
            return isMarubozu;
        }

        public override string ToString()
        {
            return "Marubozu";
        }



    }
}
