using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionApp1.Model
{
    internal class Request
    {
        public string Operation { get; set; }
        public string Path { get; set; }
        public string From { get; set; }   
        public object Value { get; set; }
        public string Comment { get; set; }     
    }
}
