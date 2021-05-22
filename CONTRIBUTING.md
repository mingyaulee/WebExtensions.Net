# Contributing to this repository

## We Develop with Github
We use GitHub to host code, to track issues and feature requests, as well as accept pull requests.

## Report bugs using Github's issues
We use GitHub issues to track bugs. Report a bug by opening a new issue.

## Write bug reports with detail, background, and sample code
Great Bug Reports tend to have:

- A quick summary and/or background
- Steps to reproduce
  - Be specific!
  - Give sample code if you can.
- What you expected would happen
- What actually happens
- Notes (possibly including why you think this might be happening, or what you have tried that didn't work)

## We Use Github Flow, So All Code Changes Happen Through Pull Requests
Pull requests are the best way to propose changes to the codebase. We actively welcome your pull requests:

1. Fork the repo and create your branch from main.
0. If you've added code that should be tested, add tests.
0. Ensure the test suite passes.
0. Create a pull request!

## Working in this repository
### Packages shipped by this repository
There is one package that is shipped from the repository:
1. WebExtension.Net

### Project Details
#### The terms used
1. Namespace Definition - the raw JSON definition retrieved from the source (Mozilla.org)
0. Class Entity - A registered entity containing the type (Api/ApiRoot/Type/etc), the namespace entity, the functions and the properties
0. Clr Type - An object reflecting the definition of a .Net type
0. Code Converter - A processor that defines how to write a Clr Type into C# code
0. Code File - An object representing a .cs file

#### The code generation process
The APIs in WebExtension.Net/Generated is generated from the WebExtension.Net.Generator project.
The code generation process is summarised as follows:
1. Namespace Definitions are retrieved by the NamespaceDefinitionsClient
0. The raw Namespace Definitions are then processed by the EntitiesRegistrationManager. In this stage:
    - The namespace is registered as an Namespace Entity
    - The namespace is registered as an Api Class Entity
    - The types in a namespace is registered as a Type Entity
    - The types are checked for reference/usage
    - The unused or unsupported types are filtered out
    - The non-constant properties in the namespace is registered as a property getter function definition
    - The events in the namespace is registered as property definitions
    - The root namespace is registered as an ApiRoot Class Entity
0. The Class Entities are translated into Clr Types by the ClrTypeManager. In this stage:
    - The class entity is converted to ClrTypeInfo
    - The methods in the class entity, their parameters and return type are converted
    - The properties in the class entities are converted
    - The namespaces required by the type is determined
    - The namespaces required to reference the type is determined
0. The code generator converts the Clr Types into Code Files. In this stage:
    - The Code Converters are determined and injected into the Code File based on the Class Type
    - The comments or attributes are defined in the Code Converters
0. The Code Files are then written by the CodeManager to physical file. In this stage:
    - The Generated folder is cleaned
    - The Code Files are written as .cs files
    - The Namespace definitions are written as .json files

#### Supporting missing/browser specific APIs
The APIs generated are only the ones that are defined by the WebExtensions Standards. A browser specific API can be added with extension methods.
The browser specific extensions and types should be defined in a directory under WebExtension.Net based on the browser name, i.e.
- WebExtension.Net/Chrome
- WebExtension.Net/Firefox
- WebExtension.Net/Edge
If the directory does not exist, you should create one.
Refer to WebExtension.Net/Chrome/INotificationsApiExtension.cs for example.

### In case of conflicts in the file generated.txt
It is best to do a rebase and run the generator again to make sure the changes in the generated files are not overwritten by your pull request.

### Use a Consistent Coding Style
- 4 spaces (C#) or 2 spaces (XML/JSON/JS) for indentation rather than tabs.
- Every `if`, `else`, `for`, `foreach`, `while` etc should have its own opening and closing bracket, even if it is a single line statement.
- Every code file changed should be formatted properly (CTRL+K, CTRL+D in VS or ALT+SHIFT+F in VS Code).

### Running the integration tests
1. Download the chrome driver from (here)[http://chromedriver.storage.googleapis.com/]
0. Extract the chrome driver to the directory C:\SeleniumWebDrivers\ChromeDriver
0. Run the tests using either the Test Explorer in VS or `dotnet test` command

## License
By contributing, you agree that your contributions will be licensed under its MIT License.