using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigizuiteApi.Models
{
    public class Metadata : IMetadata
    {
        public Guid MessageId { get ; set ; }
        public string data { get ; set ; }
    }
}
