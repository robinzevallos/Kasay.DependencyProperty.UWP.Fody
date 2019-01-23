using Kasay.FodyHelpers;
using Mono.Cecil;
using Mono.Cecil.Cil;
using Mono.Cecil.Rocks;
using System;
using System.Linq;

internal class ConstructorImplementer
{
    readonly AssemblyFactory uwpAssembly;
    readonly TypeDefinition typeDefinition;

    ModuleDefinition moduleDefinition;

    public ConstructorImplementer(
        AssemblyFactory uwpAssembly,
        TypeDefinition typeDefinition,
        Boolean isTest)
    {
        this.uwpAssembly = uwpAssembly;
        this.typeDefinition = typeDefinition;

        moduleDefinition = typeDefinition.Module;

        if (!isTest)
            EqualDataContext();

        AddStaticConstructor();
    }

    void EqualDataContext()
    {
        var method = typeDefinition.GetConstructors().First();

        var callPut_DataContext = uwpAssembly.GetMethodReference("Windows.UI.Xaml.FrameworkElement", "put_DataContext");

        method.Body.Instructions.RemoveAt(method.Body.Instructions.Count - 1);

        var processor = method.Body.GetILProcessor();
        processor.Emit(OpCodes.Nop);
        processor.Emit(OpCodes.Ldarg_0);
        processor.Emit(OpCodes.Ldarg_0);
        processor.Emit(OpCodes.Call, callPut_DataContext);
        processor.Emit(OpCodes.Nop);
        processor.Emit(OpCodes.Ret);
    }

    void AddStaticConstructor()
    {
        var method = typeDefinition.GetStaticConstructor();

        if (method is null)
        {
            method = new MethodDefinition(
                ".cctor",
                MethodAttributes.Private | MethodAttributes.HideBySig | MethodAttributes.SpecialName |
                MethodAttributes.RTSpecialName | MethodAttributes.Static,
                moduleDefinition.TypeSystem.Void);

            var processor = method.Body.GetILProcessor();
            processor.Emit(OpCodes.Ret);

            typeDefinition.Methods.Add(method);
        }
    }
}
