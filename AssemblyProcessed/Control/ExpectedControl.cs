namespace AssemblyProcessed
{
    using System;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;

    public class ExpectedControl : UserControl
    {
        public static readonly DependencyProperty SomeNameProperty =
           Kasay.DependencyProperty.Helpers.DependencyProperty.Register(
               "SomeName",
               typeof(String), 
               typeof(ExpectedControl));

        public String SomeName
        {
            get => (String)GetValue(SomeNameProperty);
            set => SetValue(SomeNameProperty, value);
        }

        public static readonly DependencyProperty SomeNumberProperty =
           Kasay.DependencyProperty.Helpers.DependencyProperty.Register(
              "SomeNumber", 
              typeof(Int32), 
              typeof(ExpectedControl));

        public Int32 SomeNumber
        {
            get => (Int32)GetValue(SomeNumberProperty);
            set => SetValue(SomeNumberProperty, value);
        }

        public static readonly DependencyProperty SomeConditionProperty =
           Kasay.DependencyProperty.Helpers.DependencyProperty.Register(
              "SomeCondition", 
              typeof(Boolean),
              typeof(ExpectedControl));

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
