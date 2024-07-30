using System;
using System.Text;

public class Soundex
{
    public static string GenerateSoundex(string name)
    {
        if (string.IsNullOrEmpty(name)) return string.Empty; // 1 decision point

        var soundex = new StringBuilder();
        soundex.Append(char.ToUpper(name[0]));

        char prevCode = GetSoundexCode(name[0]);

        AppendSoundexCharacters(name.Substring(1), soundex, ref prevCode);

        return soundex.ToString().PadRight(4, '0').Substring(0, 4); // No new decision points
    }

    private static void AppendSoundexCharacters(string name, StringBuilder soundex, ref char prevCode)
    {
        foreach (char character in name) // 1 decision point for loop
        {
            if (char.IsLetter(character)) // 1 decision point
            {
                AppendCodeIfNeeded(character, soundex, ref prevCode);
            }

            if (soundex.Length >= 4) // 1 decision point
            {
                break; // Exits the loop
            }
        }
    }

    private static void AppendCodeIfNeeded(char character, StringBuilder soundex, ref char prevCode)
    {
        char code = GetSoundexCode(character);
        if (code != '0' && code != prevCode) // 1 decision point
        {
            soundex.Append(code);
            prevCode = code;
        }
    }

    private static char GetSoundexCode(char character) =>
        character switch // 1 decision point
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
