namespace Kasay.Helpers
{
    using System;
    using Windows.UI.Xaml;

    internal class LocalDependencyProperty
    {
        public static DependencyProperty Register(String name, Type propertyType, Type ownerType)
        {
            return DependencyProperty.Register(name, propertyType, ownerType, null);
        }
    }
}
