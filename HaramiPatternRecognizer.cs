using System;
using System.Collections.Generic;
using StockAnalyzerProject2;

namespace StockAnalyzerProject2
{


    // This is a derived class of the PatternRecognizers abstract base class.
    // which is responsible for recognizing the Harami candlestick pattern in a given list of CandleStickData.

    public partial class HaramiPatternRecognizer : PatternRecognizers
    {

        // Returns the name of the candlestick pattern: "Harami Pattern"
        public string GetPatternName()
        {
            return "Harami Pattern";
        }


        // Recognize() method scans the list of CandleStickData and
        // returns the indices of candles that form a Harami pattern.
        public List<int> Recognize(List<CandleStickData> data)
        {
            List<int> indices = new List<int>();

            for (int i = 1; i < data.Count; i++)
            {
                if (IsPatternPresent(data, i))
                {
                    indices.Add(i);
                }
            }

            return indices;
        }


        // IsPatternPresent() method checks if the pattern exists at a specific index
        // in the given list of CandleStickData.
        public bool IsPatternPresent(List<CandleStickData> data, int index)
        {
            if (index < 1)
            {
                return false;
            }

            double currentOpen = (double)data[index].Open;
            double currentClose = (double)data[index].Close;
            double currentHigh = (double)data[index].High;
            double currentLow = (double)data[index].Low;
            double currentUpperBody = Math.Max(currentOpen, currentClose);
            double currentLowerBody = Math.Min(currentOpen, currentClose);

            double previousOpen = (double)data[index - 1].Open;
            double previousClose = (double)data[index - 1].Close;
            double previousHigh = (double)data[index - 1].High;
            double previousLow = (double)data[index - 1].Low;
            double previousUpperBody = Math.Max(previousOpen, previousClose);
            double previousLowerBody = Math.Min(previousOpen, previousClose);

            bool isOpposite = (currentClose > currentOpen && previousOpen > previousClose) || (currentOpen > currentClose && previousClose > previousOpen);

            bool isHarami = isOpposite && currentHigh < previousHigh && currentLow > previousLow && currentUpperBody < previousUpperBody && currentLowerBody > previousLowerBody;

            return isHarami;
        }

        //returns the name as Harami Pattern in the combobox
        public override string ToString()
        {
            return "Harami Pattern";
        }
    }
}