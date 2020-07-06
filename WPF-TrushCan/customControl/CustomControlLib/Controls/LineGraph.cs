using System.Windows;
using System.Windows.Controls;

namespace CustomControlLib.Controls
{
    public class LineGraph : Control
    {
        static LineGraph()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(LineGraph), new FrameworkPropertyMetadata(typeof(LineGraph)));
        }

        public LineGraph()
        {
        }
    }
}
