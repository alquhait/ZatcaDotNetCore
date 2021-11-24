using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZatcaDotNetCore
{
    public class GenerateQrCode
    {
        public Tag[] Data;

        private GenerateQrCode(Tag[] data)
        {
            Data = data;

            if (Data.Length == 0)
            {
                throw new ArgumentException("Malformed data structure");
            }
        }

        public static GenerateQrCode FromArray(Tag[] data)
        {
            return new GenerateQrCode(data);
        }

        public string ToTLV()
        {
            return string.Join("", Data.Select(tag => tag));
        }

        public string ToBase64()
        {
            return Convert.ToBase64String(Encoding.Default.GetBytes(ToTLV()));
        }

        public string Render()
        {
            var qrGenerator = new QRCodeGenerator();
            var qrCodeData = qrGenerator.CreateQrCode(ToBase64(), QRCodeGenerator.ECCLevel.Q);
            var qrCode = new Base64QRCode(qrCodeData);
            return "data:image/png;base64," + qrCode.GetGraphic(20);
        }

    }
}
