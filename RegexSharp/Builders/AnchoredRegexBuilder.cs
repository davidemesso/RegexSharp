using System.Text;
using System.Text.RegularExpressions;

namespace RegexSharp.Builders;

public class AnchoredRegexBuilder : BaseRegexBuilder
{
    public AnchoredRegexBuilder(StringBuilder builder) : base(builder) {}

    public BaseRegexBuilder LineStart()
    {
        _builder.Insert(0, "^");
        return new BaseRegexBuilder(_builder);
    }

    public BaseRegexBuilder LineEnd()
    {
        _builder.Append("$");
        return new BaseRegexBuilder(_builder);
    }

    public BaseRegexBuilder LineStartEnd()
    {
        _builder.Insert(0, "^");
        _builder.Append("$");
        return new BaseRegexBuilder(_builder);
    }
}