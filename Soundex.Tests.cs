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
    public void HandlesMultipleConsonantsAndVowels()
    {
        Assert.Equal("R163", Soundex.GenerateSoundex("Robert"));
    }
    
 
    [Fact]
    public void HandlesSpecialCharacters()
    {
        Assert.Equal("J530", Soundex.GenerateSoundex("John-Doe"));
    }


    [Fact]
    public void HandlesWithlowercaseCharacters.()
    {
        Assert.Equal("A420", Soundex.GenerateSoundex("alice"));
    }

    [Fact]
    public void HandlesWithExactly_4_Characters()
    {
        Assert.Equal("A350", Soundex.GenerateSoundex("Adam"));
    }

    [Fact]
    public void HandlesWithMoreThan_4_Characters6()
    {
        Assert.Equal("C623", Soundex.GenerateSoundex("Christopher"));
    }

    [Fact]
    public void HandlesLongString()
    {
        Assert.Equal("A123", Soundex.GenerateSoundex("abcdefghijklmnopqrstuvwxyz"));
    }
    
     [Fact]
    public void HandlesBothCharAndDigit()
    {
        Assert.Equal("J500", Soundex.GenerateSoundex("Jane123"));
    }   
    
}
