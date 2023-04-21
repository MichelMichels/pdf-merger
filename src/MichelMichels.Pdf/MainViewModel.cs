using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MichelMichels.Pdf.Services;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace MichelMichels.Pdf
{
    public partial class MainViewModel : ObservableObject
    {
        private readonly IPdfMerger pdfMerger;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(MergeAllCommand))]
        private string outputFilePath = string.Empty;

        [ObservableProperty]
        private string? currentDirectoryPath;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(MergeAllCommand))]
        private bool isMerging;

        public MainViewModel(IPdfMerger pdfMerger)
        {            
            this.pdfMerger = pdfMerger ?? throw new ArgumentNullException(nameof(pdfMerger));

            CurrentDirectoryPath = Directory.GetCurrentDirectory();
            OutputFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "output.pdf");
        }

        [RelayCommand(CanExecute = nameof(CanMergeAll))]
        private void MergeAll()
        {
            if(IsMerging)
            {
                return;
            }

            IsMerging = true;

            try
            {
                string[] inputFilePaths = Directory.GetFiles(CurrentDirectoryPath!, "*.pdf");
                pdfMerger.Merge(OutputFilePath, inputFilePaths.ToList());
            } catch(Exception ex)
            {
                Debugger.Break();
            } finally
            {
                IsMerging = false;
            }
        }        

        private bool CanMergeAll()
        {
            return !string.IsNullOrEmpty(OutputFilePath) && !string.IsNullOrEmpty(CurrentDirectoryPath) && !IsMerging;
        }
    }
}
