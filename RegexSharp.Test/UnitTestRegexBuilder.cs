using System.Text.RegularExpressions;
using RegexSharp.Builders;

namespace RegexSharp.Test;

public class UnitTestRegexBuilder
{
    [Fact]
    public void MatchExact()
    {
        var builder = new RegexBuilder()
            .Exact("abc");
        
        var regex = new Regex(builder);

        Assert.True(regex.Match("aabcc").Success);
        Assert.True(regex.Match("abc").Success);
        Assert.False(regex.Match("cba").Success);
    }

    [Fact]
    public void MatchStartLine()
    {
        var builder = new RegexBuilder()
            .Exact("abc")
            .At
                .LineStart();
        
        var regex = new Regex(builder);

        Assert.True(regex.Match("abc").Success);
        Assert.True(regex.Match("abcc").Success);
        Assert.False(regex.Match("aabc").Success);
    }

    [Fact]
    public void MatchEndLine()
    {
        var builder = new RegexBuilder()
            .Exact("abc")
            .At
                .LineEnd();
        
        var regex = new Regex(builder);

        Assert.True(regex.Match("abc").Success);
        Assert.False(regex.Match("abcc").Success);
        Assert.True(regex.Match("aabc").Success);
    }

    [Fact]
    public void MatchStartEndLine()
    {
        var builder = new RegexBuilder()
            .Exact("abc")
            .At
                .LineStartEnd();
        
        var regex = new Regex(builder);

        Assert.True(regex.Match("abc").Success);
        Assert.False(regex.Match("abcc").Success);
        Assert.False(regex.Match("aabc").Success);
    }
}