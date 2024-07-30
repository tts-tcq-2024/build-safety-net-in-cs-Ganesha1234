using System;
using System.Text;

public class Soundex
{
    public static string GenerateSoundex(string name)
    {
        if (string.IsNullOrEmpty(name)) return string.Empty;

        var soundex = new StringBuilder();
        soundex.Append(char.ToUpper(name[0]));

        char prevCode = GetSoundexCode(name[0]);

        // Append characters and get soundex code
        AppendSoundexCharacters(name, soundex, ref prevCode);

        // Pad to ensure length of 4
        soundex.Append('0', 4 - soundex.Length);

        return soundex.ToString();
    }

    private static void AppendSoundexCharacters(string name, StringBuilder soundex, ref char prevCode)
    {
        foreach (char character in name.Substring(1))
        {
            if (!char.IsLetter(character)) continue;

            char code = GetSoundexCode(character);
            if (code != '0' && code != prevCode)
            {
                soundex.Append(code);
                prevCode = code;
            }
        }
    }

    private static char GetSoundexCode(char character) =>
        character switch
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
