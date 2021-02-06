using iTextSharp.text.pdf;
using System.IO;
using System.Linq;

namespace PdfFiller.Investigator
{
    public static class FileAnalyzer
    {
        /// <summary>
        /// Create a PDF file with fields stamped by its field name
        /// Run this tool first to identify names of individual fields
        /// We can use this information when we want to fill the fields programmatically by field name
        /// </summary>
        /// <param name="templatePath"></param>
        public static void MarkAllFields(string templatePath)
        {
            PdfReader reader = new PdfReader(templatePath);
            PdfStamper stamper = new PdfStamper(reader, new FileStream($"{templatePath}_stamped.pdf", FileMode.Create));
            AcroFields fieldStamper = stamper.AcroFields;

            var fieldNames = fieldStamper.Fields.Select(x => x.Key).ToList();
            foreach (var fieldName in fieldNames)
            {
                fieldStamper.SetField(fieldName, fieldName);
            }

            stamper.Close();
        }
    }
}
