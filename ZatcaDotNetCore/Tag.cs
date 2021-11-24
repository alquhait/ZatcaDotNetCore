using System;
using System.Text;

namespace ZatcaDotNetCore
{
    public class Tag
    {
        protected long tag;

        protected string value;

        public Tag(long tag, string value)
        {
            this.tag = tag;
            this.value = value;
        }

        public long GetTag()
        {
            return tag;
        }

        public string GetValue()
        {
            return value;
        }

        public long GetLength()
        {
            return value.Length;
        }

        public override string ToString()
        {
            return ToHex(GetTag()) + ToHex(GetLength()) + GetValue();
        }

        protected string ToHex(long value)
        {
            return PackH(value.ToString("X2"));
        }

        protected string PackH(string hexString)
        {
            var bytes = new byte[hexString.Length / 2];
            for (var i = 0; i < bytes.Length; i++)
            {
                bytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            }
            return Encoding.Default.GetString(bytes);
        }

    }
}
