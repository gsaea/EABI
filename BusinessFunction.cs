using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EABI
{
    public class BusinessFunction
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ParentFunction { get; set; }
        public string BRMMapping { get; set; }
        public string ElemBusProcess { get; set; }
        public string Data { get; set; }
        public string ElementType { get; set; }
        public string FctID { get; set; }
        public string Organizations { get; set; }
    }
}