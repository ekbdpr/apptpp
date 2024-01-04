using AppTpp.Core;
using System.Windows.Controls;

namespace AppTpp.MVVM.ViewModel
{
    internal class InputDataBatchVM : ViewModelBase
    {
        public RelayCommand ChooseFileCommand { get; set; }

        public InputDataBatchVM()
        {
            ChooseFileCommand = new RelayCommand(ChooseFile);
        }

        private void ChooseFile(object obj)
        {
            
        }
    }
}
