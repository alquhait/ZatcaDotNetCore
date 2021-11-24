using System;
using ZatcaDotNetCore;
using ZatcaDotNetCore.Tags;

namespace ZatcaCore
{
    class Program
    {
        static void Main(string[] args)
        {
            Tag[] tags =  {
                new Seller("Test"),
                new TaxNumber("3234567892"),
                new InvoiceDate("2021-11-12T14:25:09Z"),
                new InvoiceTotalAmount("200.00"),
                new InvoiceTaxAmount("30.00")
            };

            var qr = GenerateQrCode.FromArray(tags).Render();

            Console.WriteLine(qr);
        }
    }
}
