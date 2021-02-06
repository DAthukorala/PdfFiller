using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;

namespace PdfFiller.Investigator
{
    public static class FieldHandler
    {
        /// <summary>
        /// use this method if you want to read values listed in the drop down
        /// e.g. if you want to match data retrieved from the data base against the values in a drop down before stamping the field
        /// </summary>
        /// <param name="fieldName">drop down field name</param>
        /// <param name="templatePath">file path</param>
        /// <returns>values listed in the mentioned drop down</returns>
        public static string[] GetDropDownValues(string fieldName, string templatePath)
        {
            var reader = new PdfReader(templatePath);
            var fields = reader.AcroFields;
            var values = fields.GetListOptionDisplay(fieldName);
            return values;
        }

        public static void SetFieldValues(Dictionary<string, string> fieldData, string templatePath, string outputPath)
        {
            PdfReader reader = new PdfReader(templatePath);
            var outputFilePath = Path.Combine(outputPath, $"{DateTime.Now.ToString("MMddyyyy_hhmmss_fff_tt")}.pdf").ToString();
            PdfStamper stamper = new PdfStamper(reader, new FileStream(outputFilePath, FileMode.OpenOrCreate, FileAccess.ReadWrite));
            AcroFields fieldStamper = stamper.AcroFields;

            foreach (var data in fieldData)
            {
                fieldStamper.SetField(data.Key, data.Value);
            }
            //mark the output as read only
            stamper.FormFlattening = true;
            stamper.Close();
        }
    }
}
