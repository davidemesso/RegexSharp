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

    public RegexBuilder(string s) : base(new StringBuilder(s)) {}

    public RegexBuilder Exact(string s)
    {
        _builder.Append(s);
        return this;
    }

    public RegexBuilder And(RegexBuilder rb)
    {
        _builder.Append(rb._builder);
        return this;
    }

    public RegexBuilder Or(RegexBuilder rb)
    {
        SurroundGroup();
        rb.SurroundGroup();

        _builder.Append($"|{rb._builder}");
        return this;
    }

    public static RegexBuilder FromString(string s) => new RegexBuilder(s);

    public RegexBuilder Optionally()
    {
        SurroundGroup();
        _builder.Append("?");
        return this;
    }

    public RegexBuilder OneOrMore()
    {
        SurroundGroup();
        _builder.Append("+");
        return this;
    }

    public RegexBuilder AnyTimes()
    {
        SurroundGroup();
        _builder.Append("*");
        return this;
    }

    public static implicit operator string(RegexBuilder rb)
    {
        return rb._builder.ToString() ?? "";
    }

    public static implicit operator RegexBuilder(string str)
    {
        var builder = new RegexBuilder();
        return builder.Exact(str);
    }

    public static RegexBuilder operator +(RegexBuilder a, RegexBuilder b)
    {
        a._builder.Append(b._builder);
        return a;
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

    public RegexBuilder this[int times]
    {
        get
        {
            SurroundGroup();
            _builder.Append($"{{{times}}}");
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