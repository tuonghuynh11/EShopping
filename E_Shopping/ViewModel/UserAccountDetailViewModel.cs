using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace E_Shopping.ViewModel
{
    public class UserAccountDetailViewModel:BaseViewModel
    {
        public ICommand CloseCommand { get; set; }
        public UserAccountDetailViewModel()
        {
            CloseCommand = new RelayCommand<Window>((p) => { return true; }, (p) => { p.Close(); });
        }

    }
}
