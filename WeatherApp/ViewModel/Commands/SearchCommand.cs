using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WeatherApp.ViewModel.Commands
{
    public class SearchCommand : ICommand
    {
        public WeatherVM VM { get; set; }

        public event EventHandler CanExecuteChanged
        {
            // this block enable button when user write some thing
            add { CommandManager.RequerySuggested += value; }
            remove {  CommandManager.RequerySuggested -= value;}
        }

        public SearchCommand(WeatherVM vm)
        {
            VM = vm;
        }

        public bool CanExecute(object parameter)
        {
            string query = parameter as string;

            // this condition desable button when box is empty
            if (string.IsNullOrWhiteSpace(query))
                return false;

            return true;
        }

        public void Execute(object parameter)
        {
            VM.MakeQuery();
        }
    }
}
