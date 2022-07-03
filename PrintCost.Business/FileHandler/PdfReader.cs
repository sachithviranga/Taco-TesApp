using PrintCost.Entities;
using Spire.Pdf;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PrintCost.Common.Constant;

namespace PrintCost.Business.FileHandler
{
    public class PdfReader
    {
        public static List<PrintOutCount> ReadPdfByByte(byte[] pdf)
        {
            List<PrintOutCount> printOutCounts = new();
            PdfDocument pdfDoc = new(pdf);
            int pages = pdfDoc.Pages.Count;
            int colorCount = 0;
            for (int i = 0; i < pages; i++)
            {
                Image image = pdfDoc.SaveAsImage(i);

                if (!IsGrayScale(new Bitmap(image)))
                {
                    colorCount++;
                }
            }

            printOutCounts.Add(new() { PrintTypeId = (int)PrintType.BW, Count = pages - colorCount });
            printOutCounts.Add(new() { PrintTypeId = (int)PrintType.C, Count = colorCount });

            return printOutCounts;
        }

        public static List<PrintOutCount> ReadPdfFromPath(string path)
        {
            List<PrintOutCount> printOutCounts = new();
            PdfDocument pdfDoc = new(path);
            int pages = pdfDoc.Pages.Count;
            int colorCount = 0;
            for (int i = 0; i < pages; i++)
            {
                Image image = pdfDoc.SaveAsImage(i);

                if (!IsGrayScale(new Bitmap(image)))
                {
                    colorCount++;
                }
            }

            printOutCounts.Add(new() { PrintTypeId = (int)PrintType.BW, Count = pages - colorCount });
            printOutCounts.Add(new() { PrintTypeId = (int)PrintType.C, Count = colorCount });

            File.Delete(path);

            return printOutCounts;
        }

        private static Boolean IsGrayScale(Bitmap img)
        {
            Boolean result = true;
            for (Int32 h = 53; h < img.Height; h++)
                for (Int32 w = 0; w < img.Width; w++)
                {
                    Color color = img.GetPixel(w, h);
                    if ((color.R != color.G || color.G != color.B || color.R != color.B) && color.A != 0)
                    {
                        result = false;
                        return result;
                    }
                }
            return result;
        }
    }
}
