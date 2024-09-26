using System;
using System.Collections.Generic;
using System.Windows.Forms;
using StockAnalyzerProject2;

namespace StockAnalyzerProject2
{

    // The HammerRecognizer class is a derived class from the PatternRecognizers abstract class.
    // Which recognizes the Hammer candlestick pattern in a given list of CandleStickData.
    public class HammerRecognizer : PatternRecognizers
    {

        public string GetPatternName()
        {
            return "Hammer";
            // Returns the name of the candlestick pattern: "Hammer"
        }



        //scans the list of CandleStickData and returns the indices of candles that form a Hammer pattern
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






        //checks if a Hammer pattern is present at a specific index in the given list of CandleStickData.
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


            bool isHammer = uppertail < 0.15 * range && body > 0.2 * range && body < 0.35 * range;
            return isHammer;

        }


        public override string ToString()
        {
            return "Hammer";
        }


    }
}
