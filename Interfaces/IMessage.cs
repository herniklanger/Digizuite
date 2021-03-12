using System;
using System.Collections.Generic;

namespace Interfaces
{
    public interface IMessage
    {
        public Guid guid { get; set; }
        public long Length {get;set;}
        string FilType { get; set; }
        string Location { get; set; }
        public List<string> Fromats { get; set; }
    }
}
