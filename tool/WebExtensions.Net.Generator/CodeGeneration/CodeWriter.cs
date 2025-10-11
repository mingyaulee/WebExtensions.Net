using System.Collections.Generic;

namespace WebExtensions.Net.Generator.CodeGeneration;

public abstract class CodeWriter
{
    protected abstract ISet<string> UsingNamespaces { get; }

    protected CodeSection DeclarationSection { get; }
    protected CodeSection ConstructorsSection { get; }
    protected CodeSection PropertiesSection { get; }
    protected CodeSection PublicPropertiesSection { get; }
    protected CodeSection MethodsSection { get; }
    protected CodeSection PublicMethodsSection { get; }

    private readonly DeclarationCodeSectionWriter declarationSectionWriter;
    private readonly CodeSectionWriter constructorsSectionWriter;
    private readonly CodeSectionWriter propertiesSectionWriter;
    private readonly CodeSectionWriter publicPropertiesSectionWriter;
    private readonly CodeSectionWriter methodsSectionWriter;
    private readonly CodeSectionWriter publicMethodsSectionWriter;

    protected CodeWriter(CodeWriterOptions codeWriterOptions)
    {
        DeclarationSection = new CodeSection();
        ConstructorsSection = new CodeSection();
        PropertiesSection = new CodeSection();
        PublicPropertiesSection = new CodeSection();
        MethodsSection = new CodeSection();
        PublicMethodsSection = new CodeSection();

        declarationSectionWriter = new DeclarationCodeSectionWriter(DeclarationSection, codeWriterOptions, this);
        constructorsSectionWriter = new CodeSectionWriter(ConstructorsSection, codeWriterOptions, this);
        propertiesSectionWriter = new CodeSectionWriter(PropertiesSection, codeWriterOptions, this);
        publicPropertiesSectionWriter = new CodeSectionWriter(PublicPropertiesSection, codeWriterOptions, this);
        methodsSectionWriter = new CodeSectionWriter(MethodsSection, codeWriterOptions, this);
        publicMethodsSectionWriter = new CodeSectionWriter(PublicMethodsSection, codeWriterOptions, this);
    }

    public DeclarationCodeSectionWriter Declaration => declarationSectionWriter;
    public CodeSectionWriter Constructors => constructorsSectionWriter.WriteNewLine();
    public CodeSectionWriter Properties => propertiesSectionWriter.WriteNewLine();
    public CodeSectionWriter PublicProperties => publicPropertiesSectionWriter.WriteNewLine();
    public CodeSectionWriter Methods => methodsSectionWriter.WriteNewLine();
    public CodeSectionWriter PublicMethods => publicMethodsSectionWriter.WriteNewLine();

    public void WriteUsingStatement(string @namespace) => UsingNamespaces.Add(@namespace);

    public void WriteUsingStatement(IEnumerable<string> namespaces)
    {
        foreach (var @namespace in namespaces)
        {
            WriteUsingStatement(@namespace);
        }
    }
}
