namespace AssemblyProcessed
{
    using System;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;

    public class ExpectedControl : UserControl
    {
        public static readonly DependencyProperty SomeNameProperty 
            = DependencyProperty.Register(
                "SomeName",
                typeof(String), 
                typeof(ExpectedControl),
                null);

        public String SomeName
        {
            get => (String)GetValue(SomeNameProperty);
            set => SetValue(SomeNameProperty, value);
        }

        public static readonly DependencyProperty SomeNumberProperty 
            = DependencyProperty.Register(
                "SomeNumber", 
                typeof(Int32), 
                typeof(ExpectedControl),
                null);

        public Int32 SomeNumber
        {
            get => (Int32)GetValue(SomeNumberProperty);
            set => SetValue(SomeNumberProperty, value);
        }

        public static readonly DependencyProperty SomeConditionProperty 
            = DependencyProperty.Register(
                "SomeCondition", 
                typeof(Boolean),
                typeof(ExpectedControl),
                null);

        public Boolean SomeCondition
        {
            get => (Boolean)GetValue(SomeConditionProperty);
            set => SetValue(SomeConditionProperty, value);
        }

        public ExpectedControl()
        {
            DataContext = this;
        }
    }
}
