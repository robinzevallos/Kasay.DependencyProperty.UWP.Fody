using Fody;
using Mono.Cecil;
using System;
using System.Collections.Generic;
using System.Linq;

public class ModuleWeaver : BaseModuleWeaver
{
    readonly Boolean isModeTest;

    AssemblyFactory uwpAssembly;
    AssemblyFactory kasayUwpAssembly;

    public ModuleWeaver()
    {
    }

    public ModuleWeaver(Boolean isModeTest) : this()
    {
        this.isModeTest = isModeTest;
    }

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
            var isTargetType = type.CustomAttributes
                .Any(_ => _.AttributeType.Name == "AutoDependencyPropertyAttribute");

            if (isTargetType)
            {
                new ConstructorImplementer(uwpAssembly, type, isModeTest);

                foreach (var prop in type.Properties)
                {
                    new DependencyPropertyFactory(uwpAssembly, kasayUwpAssembly,  prop);
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
