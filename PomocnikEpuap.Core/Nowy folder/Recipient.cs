using System;
using System.Collections.Generic;
using System.Text;

namespace PomocnikEpuap.Core
{
    public class Recipient
    {
        public Recipient(string name) 
        {
            Name = name;
        }

        public string Name { get; private set; }
    }
}
