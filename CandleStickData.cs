using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockAnalyzerProject2
{
    public class CandleStickData
    {
        public DateTime Date { get; set; }
        public decimal Open { get; set; }
        public decimal High { get; set; }
        public decimal Low { get; set; }
        public decimal Close { get; set; }

        public decimal Body { get; private set; }   

        public decimal Range { get; private set; }

        public decimal Uppertail { get;private set; }

        public decimal Lowertail { get; private set; }

        public decimal Upperbody { get; private set; }

        public decimal Lowerbody { get; private set; }



    }




}
