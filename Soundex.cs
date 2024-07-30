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
        // Append soundex codes based on the name
        foreach (char character in name.Substring(1))
        {
           
            AppendSoundexCode(character, soundex, ref prevCode);
        }
         
        return soundex.ToString().PadRight(4, '0').Substring(0, 4);  
    }

    private static void AppendSoundexCode(char character, StringBuilder soundex, ref char prevCode)
    {
           if(char.IsLetter(character))
            {
               char code = GetSoundexCode(character);
        		if (AppendCode(code, prevCode))
        		{
        			soundex.Append(code);
        			prevCode = code;
        		} 
            }
    }
    
    private static bool AppendCode(char code, char prevCode) => code != '0' && code != prevCode;
    
    private static char GetSoundexCode(char character)
    {
        character = char.ToUpper(character);
        return character switch
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
