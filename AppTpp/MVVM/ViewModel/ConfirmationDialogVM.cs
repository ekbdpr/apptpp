using AppTpp.Core;
using AppTpp.Services;

namespace AppTpp.MVVM.ViewModel
{
    internal class ConfirmationDialogVM : ViewModelBase
    {
        private string? _message;
        public string? Message
        {
            get { return _message; }
            set { _message = value; OnPropertyChanged(nameof(Message)); }
        }
        public RelayCommand YesButtonCommand { get; set; }
        public RelayCommand NoButtonCommand { get; set; }

        public ConfirmationDialogVM()
        {
            Message = DataDialogService.Instance.ConfirmationDialogMessage;

            YesButtonCommand = new RelayCommand(YesButton);
            NoButtonCommand = new RelayCommand(NoButton);
        }

        private void YesButton(object obj)
        {
            DataDialogService.Instance.ConfirmationDialogState = true;
        }

        private void NoButton(object obj)
        {
            DataDialogService.Instance.ConfirmationDialogState = false;
        }
    }
}