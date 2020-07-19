using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Calcurator
{
    class MainWindowViewModel : BindableBase
    {
        private string lhs;
        public string Lhs
        {
            get => this.lhs;
            set
            {
                this.SetProperty(ref this.lhs, value);
                this.ExecuteCommand.RaiseCanExecuteChanged();
            }
        }
        private string rhs;
        public string Rhs
        {
            get => this.rhs;
            set
            {
                this.SetProperty(ref this.rhs, value);
                this.ExecuteCommand.RaiseCanExecuteChanged();
            }
        }

        private double answer;
        public double Answer
        {
            get => this.answer;
            set => this.SetProperty(ref this.answer, value);
        }

        private string message;
        public string Message
        {
            get => this.message;
            set => this.SetProperty(ref this.message, value);
        }

        public OperatorTypeViewModel[] OperatorTypes { get; private set; }
        private OperatorTypeViewModel selectedOperatorType;
        public OperatorTypeViewModel SelectedOperatorType
        {
            get => this.selectedOperatorType;
            set
            {
                this.SetProperty(ref this.selectedOperatorType, value);
                this.ExecuteCommand.RaiseCanExecuteChanged();
            }
        }

        private AppContext appContext = new AppContext();

        public MainWindowViewModel()
        {
            this.OperatorTypes = OperatorTypeViewModel.OperatorTypes;
            this.ExecuteCommand = new DelegateCommand(this.Execute, this.CanExecute);

            // Modelの監視
            this.appContext.PropertyChanged += this.AppContextPropertyChanged;
            this.appContext.Calc.PropertyChanged += this.CalcPropertyChaged;

        }

        private void Execute()
        {
            this.appContext.Calc.Lhs = double.Parse(this.Lhs);
            this.appContext.Calc.Rhs = double.Parse(this.Rhs);
            this.appContext.Calc.OperatorType = this.SelectedOperatorType.OperatorType;
            this.appContext.Calc.Execute();
        }

        private bool CanExecute()
        {
            double dummy;
            if (!double.TryParse(this.Lhs, out dummy))
            {
                return false;
            }
            if (!double.TryParse(this.Rhs, out dummy))
            {
                return false;
            }
            if (this.SelectedOperatorType == null)
            {
                return false;
            }
            return true;
        }

        private void CalcPropertyChaged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Answer")
            {
                this.Answer = this.appContext.Calc.Answer;
            }
        }

        private void AppContextPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Name")
            {
                this.Message = this.appContext.Message;
            }
        }

        public DelegateCommand ExecuteCommand { get; private set; }
    }
}
