using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 **/
class Solution
{
    static void Main(string[] args)
    {

        string s = "F";
        Console.WriteLine(s.GetHashCode());
        //IntBinaryEx();

        //ExCodinGame();

    }

    private static void ExCodinGame()
    {
        string[] s = Console.ReadLine().Split(' ');
        if ((s.Length % 2) == 0)
        {
            Console.WriteLine(s[(s.Length / 2) - 1] + s[(s.Length / 2) + 1]);
        }
        else { Console.WriteLine(s[(s.Length / 2)]); }
    }

    private static void IntBinaryEx()
    {
        int b = 0;
        int n = int.Parse(Console.ReadLine());
        int m = -1;
        int k = 0;
        string binary = Convert.ToString(n, 2);
        Console.WriteLine(n);
        Console.WriteLine(binary);
        foreach (char c in binary)
            if (c == '1') b++;
        for (int i = n + 1; m != b; i++)
        {
            m = 0;
            binary = Convert.ToString(i, 2);
            foreach (char c in binary)
                if (c == '1') m++;
            k = i;
        }
        Console.WriteLine(k);
        Console.WriteLine(binary);
    }
}