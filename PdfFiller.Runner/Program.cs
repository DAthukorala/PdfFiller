using PdfFiller.Investigator;
using System;
using System.Collections.Generic;

namespace PdfFiller.Runner
{
    class Program
    {
        static void Main(string[] args)
        {
            var templatePath = @"D:\Projects\UpWork\Kumar\PdfFiller\PdfFiller.Runner\Templates\Monthly_Treatment_Report.pdf";
            var outputPath= @"D:\Projects\UpWork\Kumar\PdfFiller\PdfFiller.Runner\Filled\";

            //Run this method to identify the field names in the PDF
            //FileAnalyzer.MarkAllFields(templatePath);
            var data = GetDummyData();
            //Run this method to fill the PDF with given data
            FieldHandler.SetFieldValues(data, templatePath, outputPath);
            //Run this method if you want to get data from a drop down
            //var fieldData = FieldHandler.GetDropDownValues("Phase", templatePath);

            Console.WriteLine("Fin");
            Console.ReadLine();
        }

        private static Dictionary<string, string> GetDummyData()
        {
            var data = new Dictionary<string, string> {
                { "Provider Name", "Demo provider name" },
                { "Date34_af_date", "02/06/2021" },
                { "3 CLIENT NAME", "Danny" },
                { "3a PACTS NUMBER", "012525220" },
                { "Date32_af_date", "Feb 2018 to March 2021" },
                { "Phase", "Action" },
                { "Time in Phase", "1 Month" },
                { "Check Box57", "Yes" },
                { "Check Box58", "Yes" },
                { "Date11_af_date", "01/01/2021" },
                { "Dropdown20", "Individual" },
                { "Length 1", "30 Minutes" },
                { "d Comments No Shows Tardiness Issues AddressedRow1", "Bla bla bla bla bla" },
                { "Dropdown47", "$35" },
                { "A 1", "Get well" },
                { "B1", "Dieting" },
                { "Date67_af_date", "02/06/2021" }
            };

            return data;
        }
    }
}
