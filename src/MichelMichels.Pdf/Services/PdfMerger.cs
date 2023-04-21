using PdfSharp.Pdf.IO;
using PdfSharp.Pdf;
using System.Collections.Generic;

namespace MichelMichels.Pdf.Services;

public class PdfMerger : IPdfMerger
{
    public void Merge(string outputFilePath, List<string> inputFilePaths)
    {
        using (PdfDocument targetDoc = new PdfDocument())
        {
            foreach (string pdf in inputFilePaths)
            {
                try
                {
                    using (PdfDocument pdfDoc = PdfReader.Open(pdf, PdfDocumentOpenMode.Import))
                    {
                        for (int i = 0; i < pdfDoc.PageCount; i++)
                        {
                            targetDoc.AddPage(pdfDoc.Pages[i]);
                        }
                    }
                }
                catch
                {
                }
            }
            targetDoc.Save(outputFilePath);
        }
    }
}
