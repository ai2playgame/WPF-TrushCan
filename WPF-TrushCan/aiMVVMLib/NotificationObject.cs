using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace aiMVVMLib
{
    public class NotificationObject : INotifyPropertyChanged
    {
        // ---------------------------------------------------------------- //
        //  インターフェース実装
        // ---------------------------------------------------------------- //
        public event PropertyChangedEventHandler PropertyChanged;

        // ---------------------------------------------------------------- //
        //  protectedメンバ変数
        // ---------------------------------------------------------------- //
        /// <summary>
        /// PropertyChangedイベント発行
        /// </summary>
        protected void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            var h = this.PropertyChanged;
            if (h != null) h(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// プロパティ値を変更する際に使用する関数
        /// </summary>
        protected bool SetProperty<T>(ref T target, T value, [CallerMemberName] string propertyName = null)
        {
            if (Equals(target, value))
            {
                return false;
            }
            target = value;
            RaisePropertyChanged(propertyName);
            return true;
        }
    }
}
