using System.Text;

namespace RegexSharp.Builders;

public class AnchoredRegexBuilder
{
    private readonly StringBuilder _builder;

    public AnchoredRegexBuilder(StringBuilder builder)
    {
        _builder = builder;
    }

    public string LineStart()
    {
        _builder.Insert(0, "^");
        return _builder.ToString();
    }

    public string LineEnd()
    {
        _builder.Append("$");
        return _builder.ToString();
    }

    public string LineStartEnd()
    {
        _builder.Insert(0, "^");
        _builder.Append("$");
        return _builder.ToString();
    }
}