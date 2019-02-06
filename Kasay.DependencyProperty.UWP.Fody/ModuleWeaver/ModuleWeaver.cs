using Fody;
using Kasay.FodyHelpers;
using Mono.Cecil;
using System.Collections.Generic;

public class ModuleWeaver : BaseModuleWeaver
{
    AssemblyFactory uwpAssembly;
    AssemblyFactory kasayUwpAssembly;

    public override void Execute()
    {
        SetAssemblies();
        SetDependencyPropertyToTypes();
    }

    void SetAssemblies()
    {
        uwpAssembly = new AssemblyFactory("Windows.Foundation.UniversalApiContract", ModuleDefinition);
        kasayUwpAssembly = new AssemblyFactory("Kasay.DependencyProperty.UWP", ModuleDefinition);
    }

    void SetDependencyPropertyToTypes()
    {
        foreach (var type in ModuleDefinition.GetTypes())
        {
            if (type.InheritFrom("Windows.UI.Xaml.FrameworkElement"))
            {
                new ConstructorImplementer(uwpAssembly, type);

                foreach (var prop in type.Properties)
                {
                    if (prop.ExistAttribute("BindAttribute"))
                        new DependencyPropertyFactory(uwpAssembly, kasayUwpAssembly, prop);
                }
            }
        }
    }

    public override IEnumerable<string> GetAssembliesForScanning()
    {
        yield return "netstandard";
        yield return "mscorlib";
    }
}
