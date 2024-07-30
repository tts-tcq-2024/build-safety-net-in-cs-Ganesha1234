using Xunit;

public class SoundexTests
{
    [Theory]
    [InlineData("", "")]
    [InlineData("A", "A000")]
    [InlineData("Robert", "R163")]
    [InlineData("John-Doe", "J530")]
    [InlineData("alice", "A420")]
    [InlineData("Adam", "A350")]
    [InlineData("Christopher", "C623")]
    [InlineData("abcdefghijklmnopqrstuvwxyz", "A123")]
    [InlineData("Jane123", "J500")]
    public void GenerateSoundexTests(string input, string expected)
    {
        Assert.Equal(expected, Soundex.GenerateSoundex(input));
    }
} 
