using System;
using System.Text;

public class Soundex
{
    public static string GenerateSoundex(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            return string.Empty;
        }

        var soundex = new StringBuilder();
        soundex.Append(char.ToUpper(name[0]));

        char prevCode = GetSoundexCode(name[0]);

        AppendSoundexCharacters(name.Substring(1), soundex, ref prevCode);

        return soundex.ToString().PadRight(4, '0').Substring(0, 4); // Ensures length of 4
    }

    private static void AppendSoundexCharacters(string name, StringBuilder soundex, ref char prevCode)
    {
        foreach (char character in name)
        {
            if (char.IsLetter(character))
            {
                AppendCodeIfNeeded(character, soundex, ref prevCode);
            }

            if (soundex.Length >= 4) // Exit loop if length is already 4
            {
                break;
            }
        }
    }

    private static void AppendCodeIfNeeded(char character, StringBuilder soundex, ref char prevCode)
    {
        char code = GetSoundexCode(character);
        if (code != '0' && code != prevCode)
        {
            soundex.Append(code);
            prevCode = code;
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
