using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EABI
{
    public class OpenDataset
    {
        public string accessLevel { get; set; }
        public string accrualPeriodicity { get; set; }
        public List<string> bureauCode { get; set; }
       // public string conformsTo { get; set; }
        public DatasetContactPoint contactPoint { get; set; }
        public string describedBy { get; set; }
        public bool dataQuality { get; set; }
        public string description { get; set; }
        public List<string> distribution { get; set; }
        public string identifier { get; set; }
        public string issued { get; set; }
        public List<string> keyword { get; set; }
        public string landingPage { get; set; }
        public List<string> language { get; set; }
        public string license { get; set; }
        public string modified { get; set; }
        public List<string> programCode { get; set; }
        public DatasetPublisher publisher { get; set; }
        public List<string> references { get; set; }
        public string rights { get; set; }
        public string spatial { get; set; }
        public List<string> theme { get; set; }
        public string title { get; set; }
    }

}