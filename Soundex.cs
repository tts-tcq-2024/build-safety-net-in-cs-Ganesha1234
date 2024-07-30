using System;
using System.Text;

public class Soundex
{
    public static string GenerateSoundex(string name)
    {
        if (string.IsNullOrWhiteSpace(name)) // Check for null or empty input
        {
            return string.Empty;
        }

        var soundex = new StringBuilder();
        soundex.Append(char.ToUpper(name[0]));

        char previousCode = GetSoundexCodeForCharacter(name[0]);

        AddSoundexCharacters(name.Substring(1), soundex, ref previousCode);

        // Ensure the Soundex code is exactly 4 characters long
        int paddingLength = 4 - soundex.Length;
        if (paddingLength > 0)
        {
            soundex.Append('0', paddingLength);
        }

        return soundex.ToString();
    }

    private static void AddSoundexCharacters(string name, StringBuilder soundex, ref char previousCode)
    {
        foreach (char character in name) // Iterate over each character in the name
        {
            if (char.IsLetter(character)) // Process only letter characters
            {
                AddCodeIfRequired(character, soundex, ref previousCode);
            }
        }
    }

    private static void AddCodeIfRequired(char character, StringBuilder soundex, ref char previousCode)
    {
        char code = GetSoundexCodeForCharacter(character);
        if (code != '0' && code != previousCode) // Append code if it is different from the previous code
        {
            soundex.Append(code);
            previousCode = code;
        }
    }

    private static char GetSoundexCodeForCharacter(char character)
    {
        return char.ToUpper(character) switch // Determine Soundex code based on the character
        {
            'B' or 'F' or 'P' or 'V' => '1',
            'C' or 'G' or 'J' or 'K' or 'Q' or 'S' or 'X' or 'Z' => '2',
            'D' or 'T' => '3',
            'L' => '4',
            'M' or 'N' => '5',
            'R' => '6',
            _ => '0'
        };
    }
}
