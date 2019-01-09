using Fody;
using Kasay.DependencyProperty.UWP.Fody;
using Mono.Cecil;
using Mono.Cecil.Cil;
using Mono.Cecil.Rocks;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class ModuleWeaver : BaseModuleWeaver
{
    private FieldDefinition dependencyPropertyField;
    private PropertyDefinition targetPropertyDefinition;

    AssemblyFactory uwpAssembly, customAssembly;

    public override void Execute()
    {
        SetAssembly();

        var types = ModuleDefinition.GetTypes().Where(_ => _.Name.EndsWith("PUTO"));

        foreach (var type in types)
        {
            //AddField(type);
            //AddEqualField(type);

            //GetProperty(type);

            //ModifyGetMethod();
            //ModifySetMethod();

            //ModifyCtor(type);
        }
    }

    void SetAssembly()
    {
        uwpAssembly = new AssemblyFactory("Windows.Foundation.UniversalApiContract", ModuleDefinition);
        customAssembly = new AssemblyFactory("Kasay.DependencyProperty.UWP", ModuleDefinition);
    }

    public override IEnumerable<string> GetAssembliesForScanning()
    {
        yield return "netstandard";
        yield return "mscorlib";
    }
}
