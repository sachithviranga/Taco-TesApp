using Syncfusion.DocIO.DLS;
using Syncfusion.DocIORenderer;
using Syncfusion.Pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintCost.Business.FileHandler
{
    public class WordReader
    {
        public static string ConverToPdf(Stream memoryStream, string originalFileName)
        {
            WordDocument wordDocument = new(memoryStream, Syncfusion.DocIO.FormatType.Docx);

            var path = AppDomain.CurrentDomain.BaseDirectory + "TemDocToPdf";

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            var fileName = originalFileName + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".pdf";
            var filePath = path + "\\" + fileName;

            DocIORenderer render = new();

            PdfDocument pdfDocument = render.ConvertToPDF(wordDocument);

            render.Dispose();

            wordDocument.Dispose();

            FileStream outputStream = new(filePath, FileMode.CreateNew, FileAccess.Write);

            pdfDocument.Save(outputStream);

            pdfDocument.Close();

            outputStream.Dispose();

            return filePath;
        }
    }
}
