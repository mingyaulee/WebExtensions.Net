$url = "https://chromium.googlesource.com/chromium/+/refs/heads/trunk/third_party/cld/languages/internal/languages.cc?format=TEXT"
$relativeLanguageCodePath = "../src/WebExtensions.Net/Extensions/I18n"
$languageCodeFileName = "GeneratedLanguageCode.cs"

$scriptPath = Split-Path -Parent $MyInvocation.MyCommand.Definition
$languageCodePath = Resolve-Path "$scriptPath/$relativeLanguageCodePath"
$languageCodeFilePath = Join-Path $languageCodePath -ChildPath $languageCodeFileName

$base64SourceCode = Invoke-RestMethod -Uri $url
$sourceCode = [System.Text.Encoding]::UTF8.GetString([System.Convert]::FromBase64String($base64SourceCode)) -split "`n"
$isLanguageTable = $false
$languageCodesJson = "["
$sourceCode | ForEach-Object {
    $line = $_
    If (!$isLanguageTable) {
        If ($line.Contains("kLanguageInfoTable[]")) {
            $isLanguageTable = $true
        }
    } Else {
        If ($line.Contains("};")) {
            $isLanguageTable = $false
            Return
        }
        $lineJson = $line.Replace('{', '[').Replace('}', ']').Replace("NULL", "null")
        If ($lineJson.Contains("//")) {
            $lineJson = $lineJson.Substring(0, $lineJson.IndexOf("//"))
        }
        $languageCodesJson += "`n$lineJson"
    }
}
$languageCodesJson += "`n]"
$languageCodes = ConvertFrom-Json $languageCodesJson

$languageCodeFile = @()
$languagePropertiesDefinition = @()
$languageDictionaryDefinition = @()

Function ToStringFormat {
    param (
        $value
    )

    If ($value) {
        Return "`"$value`""
    }
    Return "null"
}

Function NormalizePropertyName {
    param (
        $value
    )

    $lastCharIsLowerCase = $false
    $newValue = $value.ToCharArray() | ForEach-Object {
        $character = $_
        $returnCharacter = $character.ToString()
        If ($lastCharIsLowerCase) {
            If ([char]::IsUpper($character)) {
                $returnCharacter = "_$returnCharacter"
            }
        }
        $lastCharIsLowerCase = [char]::IsLower($character)
        Return $returnCharacter.ToUpper()
    }
    Return [string]::Join("", $newValue)
}

$languageCodes | ForEach-Object {
    $languageCode = $_
    $languageName = $languageCode[0]
    $languageCode1 = ToStringFormat($languageCode[1])
    $languageCode2 = ToStringFormat($languageCode[2])
    $languageCodeOther = ToStringFormat($languageCode[3])
    $languagePropertyName = NormalizePropertyName($languageName)

    $languageDictionaryDefinition += "{ `"$languageName`", new LanguageCode($languageCode1, $languageCode2, $languageCodeOther, `"$languageName`") }"
    $languagePropertiesDefinition += "/// <summary>Gets the language code that represents $languageName. Code1: $languageCode1, Code2: $languageCode2, CodeOther: $languageCodeOther</summary>"
    $languagePropertiesDefinition += "public static LanguageCode $languagePropertyName => LanguageDictionary[`"$languageName`"];"
}

$LF = "`r`n"
$languageCodeFile += "using System.Collections.Generic;"
$languageCodeFile += ""
$languageCodeFile += "namespace WebExtensions.Net.I18n"
$languageCodeFile += "{"
$languageCodeFile += "    public partial class LanguageCode"
$languageCodeFile += "    {"
$languageCodeFile += "        private static readonly IDictionary<string, LanguageCode> LanguageDictionary = new Dictionary<string, LanguageCode>()"
$languageCodeFile += "        {"
$languageCodeFile += "            " + ($languageDictionaryDefinition -join ",$LF            ")
$languageCodeFile += "        };"
$languageCodeFile += ""
$languageCodeFile += "        " + ($languagePropertiesDefinition -join "$LF        ")
$languageCodeFile += "    }"
$languageCodeFile += "}"

$languageCodeFile | Set-Content $languageCodeFilePath