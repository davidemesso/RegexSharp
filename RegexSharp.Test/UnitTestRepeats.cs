using System.Text.RegularExpressions;
using RegexSharp.Builders;

namespace RegexSharp.Test;

public class UnitTestRepeat
{
    [Fact]
    public void MatchRange()
    {
        var regex = new RegexBuilder()
            .Exact("abc")[1..3]
            .At.LineStartEnd()
            .Build();

        Assert.False(regex.Match("cba").Success);
        Assert.True(regex.Match("abc").Success);
        Assert.True(regex.Match("abcabc").Success);
        Assert.True(regex.Match("abcabcabc").Success);
        Assert.False(regex.Match("abcabcabcabc").Success);
    }
}