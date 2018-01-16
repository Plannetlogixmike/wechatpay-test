using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WechatPayTest01
{
    class RelayCommand : ICommand
    {
        private Action<object> _action;

        public RelayCommand(Action<object> action) => _action = action;
        //{
        //    _action = action;
        //}

        public bool CanExecute(object parameter) 
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object para)
        {
            if (para != null)
            {
                _action(para);
            }
            else
            {
                _action("NULL Parameters");
            }
        }
    }
}
