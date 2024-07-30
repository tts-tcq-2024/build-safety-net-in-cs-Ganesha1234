using System;
using System.Text;
using System.Collections.Generic;
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
    
    private static char GetSoundexCode(char c)
    {
        c = char.ToUpper(c);
        Dictionary<char, char> mapping = new Dictionary<char, char>
        {
            {'B', '1'}, {'F', '1'}, {'P', '1'}, {'V', '1'},
            {'C', '2'}, {'G', '2'}, {'J', '2'}, {'K', '2'}, {'Q', '2'}, {'S', '2'}, {'X', '2'}, {'Z', '2'},
            {'D', '3'}, {'T', '3'},
            {'L', '4'},
            {'M', '5'}, {'N', '5'},
            {'R', '6'}
        };
    
        return mapping.ContainsKey(c) ? mapping[c] : '0';
    }
}
