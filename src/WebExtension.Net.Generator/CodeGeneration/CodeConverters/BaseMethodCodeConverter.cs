using System.Collections.Generic;
using System.Linq;
using WebExtension.Net.Generator.Extensions;
using WebExtension.Net.Generator.Helpers;
using WebExtension.Net.Generator.Models.Schema;

namespace WebExtension.Net.Generator.CodeGeneration.CodeConverters
{
    public abstract class BaseMethodCodeConverter : ICodeConverter
    {
        protected IEnumerable<string> UsingNamespaces { get; }
        protected IEnumerable<ParameterDefinition> ParameterDefinitions { get; }
        protected FunctionReturnDefinition? ReturnDefinition { get; }
        protected string MethodReturnType { get; }
        protected string MethodArguments { get; }
        protected string ClientMethodInvoke { get; }
        protected string ClientMethodInvokeArguments { get; }

        public BaseMethodCodeConverter(FunctionDefinition functionDefinition)
        {
            var usingNamespaces = new HashSet<string>()
            {
                "System.Threading.Tasks"
            };
            var parameterDefinitions = functionDefinition.FunctionParameters?.ToList() ?? new List<ParameterDefinition>();
            var returnDefinition = functionDefinition.FunctionReturns;
            if (returnDefinition is null && !string.IsNullOrEmpty(functionDefinition.Async))
            {
                var callbackParameter = parameterDefinitions.Find(parameter => functionDefinition.Async.Equals(parameter.Name) && parameter.Type == ObjectType.Function);
                if (callbackParameter is not null)
                {
                    if (callbackParameter.FunctionParameters is null || !callbackParameter.FunctionParameters.Any())
                    {
                        parameterDefinitions.Remove(callbackParameter);
                    }
                    else if (callbackParameter.FunctionParameters.Count() == 1)
                    {
                        parameterDefinitions.Remove(callbackParameter);
                        var callbackParameterType = callbackParameter.FunctionParameters.Single();
                        returnDefinition = SerializationHelper.DeserializeTo<FunctionReturnDefinition>(callbackParameterType);
                    }
                    else
                    {
                        // multiple callback result is not supported yet
                    }
                }
            }
            var methodReturnType = "ValueTask";
            var clientMethodInvoke = "InvokeVoidAsync";
            if (returnDefinition is not null)
            {
                var returnTypeName = returnDefinition.ToTypeName(usingNamespaces);
                if (returnTypeName == "object")
                {
                    usingNamespaces.Add("System.Text.Json");
                    returnTypeName = "JsonElement";
                }

                methodReturnType = $"ValueTask<{returnTypeName}>";
                if (functionDefinition.Type == ObjectType.PropertyGetterFunction)
                {
                    clientMethodInvoke = $"GetPropertyAsync<{returnTypeName}>";
                }
                else
                {
                    clientMethodInvoke = $"InvokeAsync<{returnTypeName}>";
                }
            }

            UsingNamespaces = usingNamespaces;
            ParameterDefinitions = parameterDefinitions;
            ReturnDefinition = returnDefinition;
            MethodReturnType = methodReturnType;
            MethodArguments = string.Join(", ", parameterDefinitions.Select(parameterDefinition => $"{parameterDefinition.ToTypeName(usingNamespaces)} {parameterDefinition.Name}"));
            ClientMethodInvoke = clientMethodInvoke;
            ClientMethodInvokeArguments = string.Join(string.Empty, parameterDefinitions.Select(parameterDefinition => $", {parameterDefinition.Name}"));
        }

        public abstract void WriteTo(CodeWriter codeWriter, CodeWriterOptions options);
    }
}
