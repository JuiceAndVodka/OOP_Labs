using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using PluginInterface;

namespace Base32
{
    public class Base32Encoder : IPlugin
    {
        public string Name { get { return "Base32"; } }
        public string Expansion { get { return ".base32"; } }

        private const string Base32AllowedCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ234567";
        public string ToBase32String(byte[] input, bool addPadding = true)
        {
            if (input == null || input.Length == 0)
            {
                return string.Empty;
            }

            var bits = input.Select(b => Convert.ToString(b, 2).PadLeft(8, '0')).Aggregate((a, b) => a + b).PadRight((int)(Math.Ceiling((input.Length * 8) / 5d) * 5), '0');
            var result = Enumerable.Range(0, bits.Length / 5).Select(i => Base32AllowedCharacters.Substring(Convert.ToInt32(bits.Substring(i * 5, 5), 2), 1)).Aggregate((a, b) => a + b);
            if (addPadding)
            {
                result = result.PadRight((int)(Math.Ceiling(result.Length / 8d) * 8), '=');
            }
            return result;
        }

        public void Encode(Stream getStream, byte[] TextBytes)
        {
            bool addPadding = true;

            var result = ToBase32String(TextBytes, addPadding);

            using (StreamWriter WriteStream = new StreamWriter(getStream))
            {
                WriteStream.Write(result);
            }
        }

        public byte[] Decode(Stream getStream)
        {
            string Text;

            using (StreamReader ReadStream = new StreamReader(getStream))
            {
                Text = ReadStream.ReadToEnd();
            }

            byte[] TextBytes = ToByteArray(Text);
            return TextBytes;
        }
        public byte[] ToByteArray(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return new byte[0];
            }

            var bits = input.TrimEnd('=').ToUpper().ToCharArray().Select(c => Convert.ToString(Base32AllowedCharacters.IndexOf(c), 2).PadLeft(5, '0')).Aggregate((a, b) => a + b);
            var result = Enumerable.Range(0, bits.Length / 8).Select(i => Convert.ToByte(bits.Substring(i * 8, 8), 2)).ToArray();
            return result;
        }
    }
}
