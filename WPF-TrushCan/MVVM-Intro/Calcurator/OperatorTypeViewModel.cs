using System;
using System.Collections.Generic;
using System.Text;

namespace Calcurator
{
    public class OperatorTypeViewModel
    {
        public OperatorType OperatorType { get; private set; }
        public string Label { get; set; }
        public OperatorTypeViewModel(string label, OperatorType operatorType)
        {
            this.Label = label;
            this.OperatorType = operatorType;
        }
        public static OperatorTypeViewModel[] OperatorTypes = new[]
        {
            new OperatorTypeViewModel("plus", OperatorType.Add),
            new OperatorTypeViewModel("minus", OperatorType.Sub),
            new OperatorTypeViewModel("mul", OperatorType.Mul),
            new OperatorTypeViewModel("div", OperatorType.Div),
        };
    }
}
