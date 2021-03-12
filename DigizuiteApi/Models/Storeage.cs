using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Interfaces;
namespace DigizuiteApi.Models
{
    public class Storeage : IStoreage<Metadata, Message>
    {
        public Message Message { get; set; }
        public Metadata Metadata { get; set; }
    }
}
