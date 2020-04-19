using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cw6.Models
{
    public class Logs
    {
        public string Path { get; set; }
        public string MethodType { get; set; }
        public string Query { get; set; }
        public string Body { get; set; }
        
        public override string ToString()
        {
            return "Path: " + Path + ", Method: " + MethodType + ", Query: " + Query + ", Body: " + Body;
        }
    }
}
