using System;
using System.Collections.Generic;
using System.Windows.Forms;
using StockAnalyzerProject2;

namespace StockAnalyzerProject2
{


    // The LongLeggedDojiRecognizer class is a derived class of the PatternRecognizers abstract base class.
    // It is responsible for recognizing the Long Legged Doji candlestick pattern in a given list of CandleStickData.
    public class LongLeggedDojiRecognizer : PatternRecognizers
    {


        public string GetPatternName()
        {
            return "Long Legged Doji";
        }


        //scans the list of CandleStickData and returns the indices of candles that form a Long Legged Doji pattern.
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


        // this IsPatternPresent() method checks if a Long Legged Doji pattern is present at a specific index in
        // the given list of CandleStickData.
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

            bool isLongLeggedDoji = body <= 0.2 * range && upperTail >= 0.4 * range && lowerTail >= 0.4 * range;
            return isLongLeggedDoji;
        }

        //return name of pattern as: Long Legged Doji
        public override string ToString()
        {
            return "Long Legged Doji";
        }
    }
}