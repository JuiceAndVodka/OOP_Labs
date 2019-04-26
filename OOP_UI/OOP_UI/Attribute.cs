using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOP_UI
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Field, AllowMultiple = true)]
    public class InfoAttribute : System.Attribute
    {
        public string Name;

        public InfoAttribute(string name)
        {
            Name = name;
        }
    }
}
