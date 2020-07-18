using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calcurator
{
    public class Calc : BindableBase
    {
        // ---------------------------------------------------------------- //
        //  プロパティ
        // ---------------------------------------------------------------- //
        private double lhs;
        public double Lhs
        {
            get => this.lhs;
            set => this.SetProperty(ref this.lhs, value);
        }
        private double rhs;
        public double Rhs
        {
            get => this.rhs;
            set => this.SetProperty(ref this.rhs, value);
        }

        private OperatorType operatorType;
        public OperatorType OperatorType
        {
            get => this.operatorType;
            set => this.SetProperty(ref this.operatorType, value);
        }

        private double answer;
        public double Answer
        {
            get => this.answer;
            set => this.SetProperty(ref this.answer, value);
        }

        // ---------------------------------------------------------------- //
        //  コンストラクタ
        // ---------------------------------------------------------------- //
        public Calc(AppContext app)
        {
            this.appContext = app;
        }

        // ---------------------------------------------------------------- //
        //  privateメンバ
        // ---------------------------------------------------------------- //
        private AppContext appContext;

        // ---------------------------------------------------------------- //
        //  メソッド
        // ---------------------------------------------------------------- //
        public void Execute()
        {
            switch (this.OperatorType)
            {
                case OperatorType.Add:
                    this.Answer = this.Lhs + this.Rhs;
                    break;
                case OperatorType.Sub:
                    this.Answer = this.Lhs - this.Rhs;
                    break;
                case OperatorType.Mul:
                    this.Answer = this.Lhs * this.Rhs;
                    break;
                case OperatorType.Div:
                    // zero-dividedを防ぐ
                    if (this.Rhs == 0)
                    {
                        this.appContext.Message = "zero divided";
                        return;
                    }
                    this.Answer = this.Lhs / this.Rhs;
                    break;
                default:
                    throw new InvalidOperationException();
            }
        }
    }

    public enum OperatorType
    {
        Add, Sub, Mul, Div,
    }
}
