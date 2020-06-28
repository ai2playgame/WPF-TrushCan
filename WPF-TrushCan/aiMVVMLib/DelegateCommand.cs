using System;

namespace aiMVVMLib
{
    public class DelegateCommand
    {
        // ---------------------------------------------------------------- //
        //  public メンバメソッド
        // ---------------------------------------------------------------- //
        public DelegateCommand(Action<object> execute)
            : this(execute, null)
        {
        }
        public DelegateCommand(Action<object> execute, Predicate<object> canExecute)
        {
            this._execute = execute;
            this._canExecute = canExecute;
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        // ---------------------------------------------------------------- //
        //  privateメンバ
        // ---------------------------------------------------------------- //
        /// <summary>
        /// コマンド実行時の処理
        /// </summary>
        private Action<object> _execute;

        /// <summary>
        /// コマンド実行可否判定処理
        /// </summary>
        private Predicate<object> _canExecute;

        // ---------------------------------------------------------------- //
        //  ICommandインターフェース実装
        // ---------------------------------------------------------------- //
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return (_canExecute != null) ? _canExecute(parameter) : true;
        }

        public void Execute(object parameter)
        {
            _execute?.Invoke(parameter);
        }
    }
}
