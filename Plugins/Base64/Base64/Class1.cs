using System.IO;
using PluginInterface;

namespace Base64
{
    public class Base64 : IPlugin
    {
        public string Name { get { return "Base64"; } }
        public string Expansion { get { return ".base64"; } }
        public void Encode(Stream getStream, byte[] TextBytes)
        {
            //var TextBytes = System.Text.Encoding.UTF8.GetBytes(Text);

            using (StreamWriter WriteStream = new StreamWriter(getStream))
            {
                WriteStream.Write(System.Convert.ToBase64String(TextBytes));
            }
        }

        public byte[] Decode(Stream getStream)
        {
            string Text;

            using (StreamReader ReadStream = new StreamReader(getStream))
            {
                Text = ReadStream.ReadToEnd();
            }

            var base64EncodedBytes = System.Convert.FromBase64String(Text);
            //return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
            return base64EncodedBytes;
        }
    }
}
