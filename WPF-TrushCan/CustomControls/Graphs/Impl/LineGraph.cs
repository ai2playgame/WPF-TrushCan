using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace CustomControls
{
    class LineGraph : Control
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
