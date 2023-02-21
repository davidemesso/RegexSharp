using System.Text.RegularExpressions;
using RegexSharp.Builders;

namespace RegexSharp.Test;

public class UnitTestRepeat
{
    [Theory]
    [InlineData("abcabc")]
    [InlineData("abcabcabc")]
    public void MatchRange_ShouldMatch_AGivenStringRepeatedRangeTimes(string input)
    {
        var regex = new RegexBuilder()
            .Exact("abc")[2..3]
            .At.LineStartEnd()
            .Build();

        var match = regex.Match(input);

        Assert.True(match.Success);
    }

    [Theory]
    [InlineData("abc")]
    [InlineData("abcabcabcabc")]
    public void MatchRange_ShouldNotMatch_AGivenStringRepeatedRangeTimes(string input)
    {
        var regex = new RegexBuilder()
            .Exact("abc")[2..3]
            .At.LineStartEnd()
            .Build();

        var match = regex.Match(input);

        Assert.False(match.Success);
    }

    [Theory]
    [InlineData("abcd")]
    [InlineData("abc")]
    public void MatchRange_ShouldMatch_AGivenStringOptionally(string input)
    {
        var regex = (new RegexBuilder()
            .Exact("abc")
            .And(RegexBuilder.FromString("d").Optionally()))
            .At.LineStartEnd()
            .Build();

        var match = regex.Match(input);

        Assert.True(match.Success);
    }

    [Theory]
    [InlineData("abcd")]
    [InlineData("abcb")]
    [InlineData("abc")]
    public void MatchRange_ShouldMatch_AGivenStringInOrOptionally(string input)
    {
        var regex = (new RegexBuilder()
            .Exact("abc")
            .And(RegexBuilder.FromString("d").Or("b").Optionally()))
            .At.LineStartEnd()
            .Build();

        var match = regex.Match(input);

        Assert.True(match.Success);
    }
    
    [Theory]
    [InlineData("ciao@google.com")]
    [InlineData("ciaone@yahoo.studenti.it")]
    [InlineData("lol@libero.it")]
    public void Test_ShouldMatch_EmailAdresses(string input)
    {
        var regex = (RegexBuilder
            .FromString(".*") + "@" +
            RegexBuilder.FromString("google").Or("yahoo").Or("libero") +
            RegexBuilder.FromString("\\.studenti").Optionally() +
            RegexBuilder.FromString("\\.it").Or("\\.com"))
            .At.LineStartEnd()
            .Build();

        var match = regex.Match(input);

        Assert.True(match.Success);
    }

    // [Theory]
    // [InlineData("abc")]
    // [InlineData("abcabcabcabc")]
    // public void MatchRange_ShouldNotMatch_AGivenStringOptionally(string input)
    // {
    //     var regex = new RegexBuilder()
    //         .Exact("abc")[2..3]
    //         .At.LineStartEnd()
    //         .Build();

    //     var match = regex.Match(input);

    //     Assert.False(match.Success);
    // }
}