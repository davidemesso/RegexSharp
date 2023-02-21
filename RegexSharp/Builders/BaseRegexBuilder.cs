using System.Text;
using System.Text.RegularExpressions;

namespace RegexSharp.Builders;

public class BaseRegexBuilder
{
    protected StringBuilder _builder;

    public BaseRegexBuilder(StringBuilder builder)
    {
        _builder = builder;
    }

    public Regex Build() => new Regex(_builder.ToString());
}