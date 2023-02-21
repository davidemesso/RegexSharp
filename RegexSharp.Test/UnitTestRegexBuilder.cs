using System.Text.RegularExpressions;
using RegexSharp.Builders;

namespace RegexSharp.Test;

public class UnitTestRegexBuilder
{
    [Theory]
    [InlineData("aabcc")]
    [InlineData("abc")]
    public void Match_ShouldMatch_AGivenString(string input)
    {
        // Arrange
        var regex = new RegexBuilder()
            .Exact("abc")
            .Build();
        
        // Act
        var match = regex.Match(input); 

        // Assert
        Assert.True(match.Success);
    }

    [Theory]
    [InlineData("cba")]
    [InlineData("abbc")]
    public void Match_ShouldNotMatch_AGivenString(string input)
    {
        // Arrange
        var regex = new RegexBuilder()
            .Exact("abc")
            .Build();
        
        // Act
        var match = regex.Match(input); 

        // Assert
        Assert.False(match.Success);
    }

    [Theory]
    [InlineData("abc")]
    [InlineData("abcc")]
    public void Match_ShouldMatch_AGivenStringStarting(string input)
    {
        var regex = new RegexBuilder()
            .Exact("abc")
            .At.LineStart()
            .Build();

        // Act
        var match = regex.Match(input); 

        // Assert
        Assert.True(match.Success);
    }

    [Theory]
    [InlineData("aabc")]
    [InlineData("abbc")]
    public void Match_ShouldNotMatch_AGivenStringStarting(string input)
    {
        var regex = new RegexBuilder()
            .Exact("abc")
            .At.LineStart()
            .Build();

        // Act
        var match = regex.Match(input); 

        // Assert
        Assert.False(match.Success);
    }

    [Theory]
    [InlineData("abc")]
    [InlineData("aabc")]
    public void Match_ShouldMatch_AGivenStringEnding(string input)
    {
        var regex = new RegexBuilder()
            .Exact("abc")
            .At.LineEnd()
            .Build();

        // Act
        var match = regex.Match(input); 

        // Assert
        Assert.True(match.Success);
    }

    [Theory]
    [InlineData("abcc")]
    [InlineData("abbc")]
    public void Match_ShouldNotMatch_AGivenStringEnding(string input)
    {
        var regex = new RegexBuilder()
            .Exact("abc")
            .At.LineEnd()
            .Build();

        // Act
        var match = regex.Match(input); 

        // Assert
        Assert.False(match.Success);
    }

    [Fact]
    public void Match_ShouldMatch_AGivenStringOnlyStartingAndEnding()
    {
        var regex = new RegexBuilder()
            .Exact("abc")
            .At.LineEnd()
            .Build();

        // Act
        var match = regex.Match("abc"); 
        var notMatch = regex.Match("cba"); 

        // Assert
        Assert.True(match.Success);
        Assert.False(notMatch.Success);
    }
}