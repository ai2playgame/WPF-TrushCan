using System.Windows;
using System.Windows.Controls;

namespace CustomControlLib.Controls
{
    public class LineGraph : Control
    {
        static LineGraph()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(LineGraph),
                new FrameworkPropertyMetadata(typeof(LineGraph)));
        }
        public LineGraph()
        {
        }

        // ---------------------------------------------------------------- //
        //  依存関係プロパティ
        // ---------------------------------------------------------------- //
        public string SubText
        {
            get => (string)GetValue(SubTextProperty);
            set => SetValue(SubTextProperty, value);
        }
        public static readonly DependencyProperty SubTextProperty =
            DependencyProperty.Register(
                nameof(SubText),
                typeof(string),
                typeof(LineGraph),
                new UIPropertyMetadata(null));
    }
}
