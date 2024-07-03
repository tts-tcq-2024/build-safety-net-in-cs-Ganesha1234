using Xunit;

public class SoundexTests
{
    [Fact]
    public void HandlesEmptyString()
    {
        Assert.Equal(string.Empty, Soundex.GenerateSoundex(""));
    }

    [Fact]
    public void HandlesSingleCharacter()
    {
        Assert.Equal("A000", Soundex.GenerateSoundex("A"));
    }

    [Fact]
    public void HandlesSingleCharacter1()
    {
        Assert.Equal("R163", Soundex.GenerateSoundex("Robert"));
    }
    
 
    [Fact]
    public void HandlesSingleCharacter3()
    {
        Assert.Equal("J530", Soundex.GenerateSoundex("John-Doe"));
    }


    [Fact]
    public void HandlesSingleCharacter4()
    {
        Assert.Equal("A420", Soundex.GenerateSoundex("alice"));
    }

    [Fact]
    public void HandlesSingleCharacter5()
    {
        Assert.Equal("A350", Soundex.GenerateSoundex("Adam"));
    }

    [Fact]
    public void HandlesSingleCharacter6()
    {
        Assert.Equal("C623", Soundex.GenerateSoundex("Christopher"));
    }

    [Fact]
    public void HandlesSingleCharacter7()
    {
        Assert.Equal("A123", Soundex.GenerateSoundex("abcdefghijklmnopqrstuvwxyz"));
    }
    
     [Fact]
    public void HandlesSingleCharacter8()
    {
        Assert.Equal("J500", Soundex.GenerateSoundex("Jane123"));
    }   
    
}
