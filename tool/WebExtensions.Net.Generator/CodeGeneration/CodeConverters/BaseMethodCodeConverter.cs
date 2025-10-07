﻿using System.Linq;
using System.Threading.Tasks;
using WebExtensions.Net.Generator.Extensions;
using WebExtensions.Net.Generator.Models.ClrTypes;

namespace WebExtensions.Net.Generator.CodeGeneration.CodeConverters
{
    public abstract class BaseMethodCodeConverter(ClrMethodInfo clrMethodInfo)
    {
        protected readonly ClrMethodInfo clrMethodInfo = clrMethodInfo;

        protected (string MethodArguments, string MethodReturnType) GetMethodSignature()
        {
            var methodArguments = string.Join(", ", clrMethodInfo.Parameters.Select(parameter =>
                parameter.IsOptional
                    ? $"{parameter.ParameterType.CSharpName} {parameter.Name.ToCSharpName()} = null"
                    : $"{parameter.ParameterType.CSharpName} {parameter.Name.ToCSharpName()}"));
            var methodReturnType = clrMethodInfo.IsAsync ? nameof(ValueTask) : "void";
            if (clrMethodInfo.Return.HasReturnType)
            {
                var returnTypeName = clrMethodInfo.Return.ReturnType!.CSharpName;
                methodReturnType = clrMethodInfo.IsAsync ? $"{nameof(ValueTask)}<{returnTypeName}>" : returnTypeName;
            }
            return (methodArguments, methodReturnType);
        }

        protected (string MethodArguments, string MethodReturnType, string ClientMethodInvokeArguments, string ClientMethodInvoke) GetMethodMetadata()
        {
            var (MethodArguments, MethodReturnType) = GetMethodSignature();
            var clientMethodInvokeArguments = string.Join("", clrMethodInfo.Parameters.Select(parameter => $", {parameter.Name.ToCSharpName()}"));
            var clientMethodInvoke = clrMethodInfo.IsAsync ? "InvokeVoidAsync" : "InvokeVoid";
            if (clrMethodInfo.Return.HasReturnType)
            {
                clientMethodInvoke = clrMethodInfo.IsAsync ? MethodReturnType.Replace(nameof(ValueTask), "InvokeAsync") : $"Invoke<{MethodReturnType}>";
            }
            return (MethodArguments, MethodReturnType, clientMethodInvokeArguments, clientMethodInvoke);
        }
    }
}
