using System;
using System.Text;

public class Soundex
{
    public static string GenerateSoundex(string name)
    {
        if (string.IsNullOrWhiteSpace(name)) // Decision point
        {
            return string.Empty;
        }

        var soundex = new StringBuilder();
        soundex.Append(char.ToUpper(name[0]));

        char previousCode = GetSoundexCodeForCharacter(name[0]);

        AddSoundexCharacters(name.Substring(1), soundex, ref previousCode);

        soundex.Append('0', 4 - soundex.Length); // Padding to ensure length

        return soundex.ToString();
    }

    private static void AddSoundexCharacters(string name, StringBuilder soundex, ref char previousCode)
    {
        foreach (char character in name) // Iterates over each character
        {
            if (char.IsLetter(character)) // Decision point
            {
                AddCodeIfRequired(character, soundex, ref previousCode);
            }
        }
    }

    private static void AddCodeIfRequired(char character, StringBuilder soundex, ref char previousCode)
    {
        char code = GetSoundexCodeForCharacter(character);
        if (code != '0' && code != previousCode) // Decision point
        {
            soundex.Append(code);
            previousCode = code;
        }
    }

    private static char GetSoundexCodeForCharacter(char character)
    {
        return char.ToUpper(character) switch // Decision point
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
