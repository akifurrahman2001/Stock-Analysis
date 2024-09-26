using System.Collections.Generic;

public abstract class Recognizer
{
    // A method to get the name of the pattern that the derived class recognizes.
    public abstract string GetPatternName();

    // The Recognize method takes a List of CandleStickData and returns a list of integers,
    // which are the indices of the candlesticks where the pattern is recognized.
    public abstract List<int> Recognize(List<CandleStickData> data);
}