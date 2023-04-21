using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MichelMichels.Pdf.Services;

public interface IPdfMerger
{
    void Merge(string outputFilePath, List<string> inputFilePaths);
}
