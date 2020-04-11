public class Solution 
{
    // public static void Main(string[] args)
    // {
    //     IsMatch("aab", "c*a*b");
    // }

    public bool IsMatch(string s, string p) 
    {
        if (s == null || p == null) 
        {
            return false;
        }

        bool [,] dp = new bool[s.Length + 1, p.Length + 1];
        dp[0, 0] = true;

        for(int x = 1; x <= s.Length; x++) 
        {
            dp[x, 0] = false;
        }

        Print(dp, s, p);

        for(int y = 0; y < p.Length; y++) 
        {
            if (p[y] == '*' && dp[0, y-1]) {
                dp[0, y+1] = true;
            }
        }

        Print(dp, s, p);


//         for (int i = 0 ; i < s.Length; i++) 
//         {
//             for (int j = 0; j < p.Length; j++) 
//             {

//                // Console.WriteLine("Matching {0} with {1}", s[i], p[j]);

//                 dp[i+1, j+1] = CanMatch(s[i], p[j]) && dp[i,j];

//                 if (p[j] == '*') 
//                 {
//                     //if (p[j-1] != s[i] && p[j-1] != '.') 
//                     //{
//                         dp[i+1, j+1] = dp[i+1, j-1];
//                     //
//                     if(CanMatch(s[i], p[j-1])) 
//                     {
//                         dp[i+1, j+1] = dp[i+1, j] || dp[i, j+1] || dp[i+1, j-1];
//                     }
//                 }
//             }
//         }

        for(int x = 0; x < s.Length; x++)
        {
            for(int y = 0; y < p.Length; y++)
            {   
                Console.WriteLine("Matching {0} with {1}", s[x], p[y]);

                dp[x+1, y+1] =  CanMatch(s[x], p[y]) && dp[x, y];
                //Console.WriteLine("here1");

                if(p[y] == '*')
                {
                    dp[x+1, y+1] = dp[x+1, y-1]; // if we ignore the element before *

                    if((CanMatch(s[x], p[y-1])))
                    {
                        dp[x+1, y+1] |=     dp[x+1, y]     // one occurence of element before *one occurence of element before *
                                        ||  dp[x, y+1]     // multiple occurences of element before *
                                        ;//|| dp[x+1, y-1]; // not needed
                    }

                    //Console.WriteLine("here2");
                }
            }

            //Print(dp, s, p);
        }

        return dp[s.Length, p.Length];

    }

    private bool CanMatch(char x, char y)
    {
        return x == y || y == '.';
    }

    private void Print(bool[,] dp, string s, string p)
    {
        Console.Write("  \" ");
        for(int x = 0; x < s.Length; x++)
        {
            Console.Write(s[x] + " ");
        }

        Console.WriteLine();

        for(int y = 0 ; y <= p.Length; y++)
        {
            for(int x = 0; x <= s.Length; x++)
            {
                if(x == 0)
                {
                    if(y == 0) Console.Write("\" ");
                    else if(y <= p.Length) Console.Write(p[y-1] + " ");
                }

                Console.Write((dp[x, y] == true ? "T" : "F")  + " ");
            }

            Console.WriteLine();
        }

        Console.WriteLine();
    }
}

