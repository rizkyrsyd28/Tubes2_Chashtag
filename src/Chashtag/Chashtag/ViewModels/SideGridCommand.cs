using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Chashtag.ViewModels
{
    class OpenFileCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private MainViewModel _sideGridViewModel;

        public OpenFileCommand(MainViewModel sideGridViewModel)
        {
            _sideGridViewModel = sideGridViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

            if (dialog.ShowDialog() == true)
            {
                // Lakukan sesuatu dengan file yang dipilih
                string path = dialog.FileName;
                _sideGridViewModel.FilePath = path;
                string[] pathParsed = path.Split('\\');

                _sideGridViewModel.FileName = pathParsed[pathParsed.Length-1];
            }
        }
    }
}
