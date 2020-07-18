using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Text;

namespace MVVMIntro01
{
    // NOTE: PrismのBindableBaseを利用
    class MainWindowViewModel : BindableBase
    {
        // ---------------------------------------------------------------- //
        //  コマンド関連
        // ---------------------------------------------------------------- //
        public DelegateCommand ConvertCommand { get; private set; }

        // ---------------------------------------------------------------- //
        //  プロパティ
        // ---------------------------------------------------------------- //
        private string input;
        public string Input
        {
            get => this.input;
            set
            {
                SetProperty(ref this.input, value);
                // Inputに変更があるたびにコマンドのCanExecuteの状態が変わったことを通知する
                this.ConvertCommand.RaiseCanExecuteChanged();
            }
        }
        private string output;
        public string Output
        {
            get => this.output;
            set => this.SetProperty(ref this.output, value);
        }

        // ---------------------------------------------------------------- //
        //  メソッド
        // ---------------------------------------------------------------- //
        private void ConvertExecute()
        {
            Debug.Print("Input: {0}, Output:{1}", this.Input, this.Input.ToUpper());
            this.Output = this.Input.ToUpper();
            Debug.Print("Output:{0}", this.Output);
        }

        private bool CanConvertExecute()
        {
            return !string.IsNullOrWhiteSpace(this.Input);
        }

        // ---------------------------------------------------------------- //
        //  コンストラクタ
        // ---------------------------------------------------------------- //
        public MainWindowViewModel()
        {
            this.ConvertCommand = new DelegateCommand(this.ConvertExecute, this.CanConvertExecute);
        }

    }
}
