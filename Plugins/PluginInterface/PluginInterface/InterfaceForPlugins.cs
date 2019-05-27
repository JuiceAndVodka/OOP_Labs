using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PluginInterface
{
    public interface IPlugin
    {
        string Name { get; }
        string Expansion { get; }
        void Encode(Stream getStream, byte[] TextBytes);
        byte[] Decode(Stream getStrea);
    }
}
