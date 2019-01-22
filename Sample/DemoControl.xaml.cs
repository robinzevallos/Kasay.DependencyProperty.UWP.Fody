namespace Sample
{
    using Kasay.DependencyProperty;
    using System;
    using Windows.UI.Xaml.Controls;

    public sealed partial class DemoControl : UserControl
    {
        public String TextButton { get; set; }

        public Int32 FontSizeButton { get; set; }

        [Bind] public String Any { get; set; }

        public DemoControl()
        {
            InitializeComponent();
        }
    }
}
