using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Windows;

namespace MichelMichels.Pdf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenSaveFileDialog_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dialog = new()
            {
                Filter = "PDF file | *.pdf",
                CheckPathExists = true,
                AddExtension = true,
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            };

            bool isSucceeded = dialog.ShowDialog() ?? false;
            if(isSucceeded)
            {
                MainViewModel viewModel = (MainViewModel)DataContext;
                viewModel.OutputFilePath = dialog.FileName;
            }            
        }
    }
}
