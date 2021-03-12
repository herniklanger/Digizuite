using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigizuiteApi.Models
{
    public class Message : IMessage
    {
        public Guid guid { get; set; }
        public string FilType { get ; set ; }
        public string Location { get ; set ; }
        public List<string> Fromats { get ; set ; }
        public long Length { get ; set ; }
    }
}
