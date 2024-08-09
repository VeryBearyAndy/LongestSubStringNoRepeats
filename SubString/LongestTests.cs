namespace SubString;
public class LongestTests
{
    [Fact]
    public void basicCase()
    {
        var result = longest.longestSubString("abc");
        Assert.Equal("abc", result);
    }

    [Theory]
    [InlineData("abcabcdeabc", "abcde")]
    [InlineData("crispycripsy", "crispy")]
    [InlineData("efghe", "efgh")]
    [InlineData("dvdf", "vdf")]

    public void extendedCases(string input, string expected)
    {
        var result = longest.longestSubString(input);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("abcabcdeabc", 5)]
    [InlineData("crispycripsy", 6)]
    [InlineData("efghe", 4)]
    [InlineData("dvdf", 3)]
    public void getLengthOfLongest(string input, int expected)
    {
        var result = longest.longestSubStringLength(input);
        Assert.Equal(expected, result);
    }
}
