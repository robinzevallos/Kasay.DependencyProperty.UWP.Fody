namespace Kasay.Custom.UWP
{
    using System;

    public class DependencyProperty
    {
        public static Windows.UI.Xaml.DependencyProperty Register(String name, Type propertyType, Type ownerType)
        {
            return Windows.UI.Xaml.DependencyProperty.Register(name, propertyType, ownerType, null);
        }
    }
}
