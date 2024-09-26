// Import required namespaces
using System;
using System.Collections.Generic;
using StockAnalyzerProject2;

// Define the namespace for the current project
namespace StockAnalyzerProject2
{
    // Define the PatternRecognizers interface
    public interface PatternRecognizers
    {
        // GetPatternName method returns the name of the pattern as a string
        string GetPatternName();

        // Recognize method takes a list of CandleStickData objects as input
        // and returns a list of integers containing the indices where the pattern is found
        List<int> Recognize(List<CandleStickData> data);
    }
}
