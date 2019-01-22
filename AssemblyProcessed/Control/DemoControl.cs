﻿namespace AssemblyProcessed
{
    using Kasay.DependencyProperty;
    using System;
    using Windows.UI.Xaml.Controls;

    public class DemoControl : UserControl
    {
        [Bind] public String SomeName { get; set; }

        [Bind] public Int32 SomeNumber { get; set; }

        [Bind] public Boolean SomeCondition { get; set; }
    }
}
