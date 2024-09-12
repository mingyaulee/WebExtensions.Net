using System.Linq;
using System.Threading.Tasks;
using WebExtensions.Net.Generator.Models.ClrTypes;

namespace WebExtensions.Net.Generator.CodeGeneration.CodeConverters
{
    public abstract class BaseMethodCodeConverter
    {
        protected readonly ClrMethodInfo clrMethodInfo;

        protected BaseMethodCodeConverter(ClrMethodInfo clrMethodInfo)
        {
            this.clrMethodInfo = clrMethodInfo;
        }

        protected (string MethodArguments, string MethodReturnType) GetMethodSignature()
        {
            var methodArguments = string.Join(", ", clrMethodInfo.Parameters.Select(parameter =>
            {
                if (parameter.IsOptional)
                {
                    return $"{parameter.ParameterType.CSharpName} {parameter.Name} = null";
                }
                return $"{parameter.ParameterType.CSharpName} {parameter.Name}";
            }));
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
            var signature = GetMethodSignature();
            var clientMethodInvokeArguments = string.Join("", clrMethodInfo.Parameters.Select(parameter => $", {parameter.Name}"));
            var clientMethodInvoke = clrMethodInfo.IsAsync ? "InvokeVoidAsync" : "InvokeVoid";
            if (clrMethodInfo.Return.HasReturnType)
            {
                clientMethodInvoke = clrMethodInfo.IsAsync ? signature.MethodReturnType.Replace(nameof(ValueTask), "InvokeAsync") : $"Invoke<{signature.MethodReturnType}>";
            }
            return (signature.MethodArguments, signature.MethodReturnType, clientMethodInvokeArguments, clientMethodInvoke);
        }
    }
}
