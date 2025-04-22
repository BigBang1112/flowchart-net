using FlowchartNET.Components.Symbols.Data;
using System.Text;

namespace FlowchartNET.Components.CodeGenerators;

internal abstract class CodeGenerator
{
    public string Generate(StartSymbolData startSymbol, IDictionary<Guid, SymbolData> allSymbols)
    {
        var sb = new StringBuilder();
        GenerateSymbolCode(sb, startSymbol, allSymbols);
        return sb.ToString();
    }

    protected abstract void GenerateSymbolCode(StringBuilder sb, StartSymbolData startSymbol, IDictionary<Guid, SymbolData> allSymbols);
}
