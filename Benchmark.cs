using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EABI
{
    public class Benchmark
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Format { get; set; }
        public string FY13Perf { get; set; }
        public string FY13GovtMed { get; set; }
        public string FY13Source { get; set; }
        public string FY14Perf { get; set; }
        public string FY14GovtMed { get; set; }
        public string FY14Source { get; set; }
    }
}