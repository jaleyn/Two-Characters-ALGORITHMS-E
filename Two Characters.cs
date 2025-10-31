using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Result
{

    /*
     * Complete the 'alternate' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts STRING s as parameter.
     */

    public static int alternate(string s)
    {
        
        HashSet<char> uniqueChars = new HashSet<char>(s);
        int maxLength = 0;

        List<char> chars = new List<char>(uniqueChars);
        for (int i = 0; i < chars.Count; i++)
        {
            for (int j = i + 1; j < chars.Count; j++)
            {
                char first = chars[i];
                char second = chars[j];

             
                string filtered = "";
                foreach (char c in s)
                {
                    if (c == first || c == second)
                        filtered += c;
                }

                bool valid = true;
                for (int k = 1; k < filtered.Length; k++)
                {
                    if (filtered[k] == filtered[k - 1])
                    {
                        valid = false;
                        break;
                    }
                }

                if (valid)
                    maxLength = Math.Max(maxLength, filtered.Length);
            }
        }

        return maxLength;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int l = Convert.ToInt32(Console.ReadLine().Trim());

        string s = Console.ReadLine();

        int result = Result.alternate(s);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
