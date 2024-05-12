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
            var methodArguments = string.Join(", ", clrMethodInfo.Parameters.Select(parameter => $"{parameter.ParameterType.CSharpName} {parameter.Name}"));
            var methodReturnType = nameof(ValueTask);
            if (clrMethodInfo.Return.HasReturnType)
            {
                var returnTypeName = clrMethodInfo.Return.ReturnType?.CSharpName;
                methodReturnType = $"ValueTask<{returnTypeName}>";
            }
            return (methodArguments, methodReturnType);
        }

        protected (string MethodArguments, string MethodReturnType, string ClientMethodInvokeArguments, string ClientMethodInvoke) GetMethodMetadata()
        {
            var signature = GetMethodSignature();
            var clientMethodInvokeArguments = string.Join("", clrMethodInfo.Parameters.Select(parameter => $", {parameter.Name}"));
            var clientMethodInvoke = signature.MethodReturnType == nameof(ValueTask) ? "InvokeVoidAsync" : signature.MethodReturnType.Replace(nameof(ValueTask), "InvokeAsync");
            return (signature.MethodArguments, signature.MethodReturnType, clientMethodInvokeArguments, clientMethodInvoke);
        }
    }
}
