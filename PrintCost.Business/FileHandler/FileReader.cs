using Microsoft.AspNetCore.Http;
using PrintCost.Contracts.FileHandler;
using PrintCost.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintCost.Business.FileHandler
{
    public class FileReader : IFileReader
    {
        public List<PrintOutCount> GetPrintOutCounts(CostCalculate costCalculate)
        {
            var file = costCalculate.File;
            using var ms = new MemoryStream();
            costCalculate.File.CopyTo(ms);
            
            PdfReader pdfReader = new();
            
            if (file.ContentType == "application/pdf")
            {
                var fileBytes = ms.ToArray();
                return PdfReader.ReadPdfByByte(fileBytes);
            }
            else if (file.ContentType == "application/vnd.openxmlformats-officedocument.wordprocessingml.document")
            {

                WordReader wordReader = new();
                return PdfReader.ReadPdfFromPath(WordReader.ConverToPdf(ms, file.FileName.Split('.').First()));
            }

            return new();
        }
    }
}
