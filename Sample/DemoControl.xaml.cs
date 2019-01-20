namespace Sample
{
    using Kasay.DependencyProperty.UWP;
    using System;
    using Windows.UI.Xaml.Controls;

    [AutoDependencyProperty]
    public sealed partial class DemoControl : UserControl
    {
        public String TextButton { get; set; }

        public Int32 FontSizeButton { get; set; }

        [NotAuto] public String Any { get; set; }

        public DemoControl()
        {
            InitializeComponent();
        }
    }
}
