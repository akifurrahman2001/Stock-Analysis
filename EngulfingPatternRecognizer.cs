using System;
using System.Collections.Generic;
using StockAnalyzerProject2;



namespace StockAnalyzerProject2
{


    // The EngulfingPatternRecognizer is a derived class of the PatternRecognizers abstract base class.
    // which is responsible for recognizing the Engulfing candlestick pattern in a given CandleStickData list
    public partial class EngulfingPatternRecognizer : PatternRecognizers
    {
        // Returns the name of the pattern: "Engulfing Pattern"
        public string GetPatternName()
        {
            return "Engulfing Pattern";
        }


        // Recognize() method scans the CandleStickData list and returns the indices of candles that becomes an Engulfing pattern.
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


        // IsPatternPresent() method checks for an Engulfing pattern at a specific index in the given list of CandleStickData.
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
            double Upperbody = Math.Max(currentOpen, currentClose);
            double lowerbody = Math.Min(currentOpen, currentClose);



            double previousOpen = (double)data[index - 1].Open;
            double previousClose = (double)data[index - 1].Close;
            double previousHigh = (double)data[index - 1].High;
            double previousLow = (double)data[index - 1].Low;


            // Check if the candles at the current index and the previous index have opposite colors.
            bool isOpposite = (currentClose > currentOpen && previousOpen > previousClose) || (currentOpen > currentClose && previousClose > previousOpen);

            // Check if the current candle engulfs the previous candle.
            bool isEngulfing = isOpposite && previousHigh < Upperbody && previousLow > lowerbody;


            return isEngulfing;


        }

        //Makes the name of the pattern appear as 'Engulfing Pattern' in the combobox
        public override string ToString()
        {
            return "Engulfing Pattern";
        }



    }
}