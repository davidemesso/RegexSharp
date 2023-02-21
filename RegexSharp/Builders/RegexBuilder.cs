using System.Text;
using System.Text.RegularExpressions;

namespace RegexSharp.Builders;

public class RegexBuilder : BaseRegexBuilder
{
    public AnchoredRegexBuilder At => new AnchoredRegexBuilder(_builder);

    public RegexBuilder()
        : base(new())
    {
        _builder = new StringBuilder();
    }

    public RegexBuilder Exact(string s)
    {
        _builder.Append(s);
        return this;
    }

    public static implicit operator string(RegexBuilder rb)
    {
        return rb._builder.ToString() ?? "";
    }  

    public RegexBuilder this[Range range]
    {
        get
        {
            SurroundGroup();
            _builder.Append($"{{{range.Start.Value},{range.End.Value}}}");
            return this;
        }
    }

    private RegexBuilder SurroundGroup()
    {
        _builder.Insert(0, "(");
        _builder.Append(")");
        return this;
    }
}