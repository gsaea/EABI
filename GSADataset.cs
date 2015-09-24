using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EABI
{
    public class GSADataset
    {
        public string conformsTo { get; set; }
        public string describedBy { get; set; }
        public List<OpenDataset> dataset { get; set; }
    }

}