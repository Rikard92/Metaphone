using System;
using System.Text;

namespace Metaphone
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "";
            while (true) 
            {
                
                input = Console.ReadLine();

                if(input == "quit program")
                {
                    break;
                }

                // Capitalize all leters
                input = input.ToUpper();

                //Fix the start
                if (input.getTwoLeters(0).Contains("KN") || input.getTwoLeters(0).Contains("GN") || input.getTwoLeters(0).Contains("PN"))
                {
                    input = input.Remove(0, 1);
                }
                else if (input.getTwoLeters(0).Contains("AE"))
                {
                    input = input.Remove(1, 1);
                }
                else if (input.getTwoLeters(0).Contains("WR"))
                {
                    input = input.Remove(0, 1);
                }
                //Delete B in the end if its after a M
                if (input.getTwoLeters(input.Length - 2).Contains("MB"))
                {
                    input = input.Remove(input.Length - 1, 1);
                }

                // Adjust CIA, SCH, CH
                for (int i = 0; i < input.Length; i++)
                {
                    if (input.getThreeLeters(i).Contains("CIA"))
                    {
                        StringBuilder sb = new StringBuilder(input);
                        sb[i] = 'X';
                        input = sb.ToString();
                    }
                    else if (input.getThreeLeters(i).Contains("SCH"))
                    {
                        StringBuilder sb = new StringBuilder(input);
                        sb[i + 1] = 'K';
                        input = sb.ToString();
                    }
                    else if (input.getTwoLeters(i).Contains("CH"))
                    {
                        StringBuilder sb = new StringBuilder(input);
                        sb[i] = 'X';
                        input = sb.ToString();
                    }
                    if (input.getLeter(i).Contains("C"))
                    {
                        StringBuilder sb = new StringBuilder(input);
                        sb[i] = 'K';
                        input = sb.ToString();
                    }
                    //}
                    //// Adjust CI, CE, CY
                    //for (int i = 1; i < input.Length - 1; i++)
                    //{
                    if (input.getTwoLeters(i).Contains("CI") || input.getTwoLeters(i).Contains("CE") || input.getTwoLeters(i).Contains("CY"))
                    {
                        StringBuilder sb = new StringBuilder(input);
                        sb[i] = 'S';
                        input = sb.ToString();
                    }
                    //}
                    //// Adjust DGE, DGY, DGI, D
                    //for (int i = 1; i < input.Length - 1; i++)
                    //{
                    if (input.getThreeLeters(i).Contains("DGE") || input.getThreeLeters(i).Contains("DGY"))
                    {
                        StringBuilder sb = new StringBuilder(input);
                        sb[i] = 'J';
                        input = sb.ToString();
                    }
                    else if (input.getThreeLeters(i).Contains("DGE"))
                    {
                        StringBuilder sb = new StringBuilder(input);
                        sb[i + 2] = 'Y';
                        input = sb.ToString();
                    }
                    else if (input.getLeter(i).Contains("D"))
                    {
                        StringBuilder sb = new StringBuilder(input);
                        sb[i] = 'T';
                        input = sb.ToString();
                    }
                    //}
                    //// The G in GH is silent if there is no vowel before or after
                    //for (int i = 1; i < input.Length - 1; i++)
                    //{
                    if (input.getTwoLeters(i).Contains("GH") && (!(input.getLeter(i - 1).Contains("A") || input.getLeter(i + 2).Contains("A"))
                        || !(input.getLeter(i - 1).Contains("E") || input.getLeter(i + 2).Contains("E"))
                        || !(input.getLeter(i - 1).Contains("I") || input.getLeter(i + 2).Contains("I"))
                        || !(input.getLeter(i - 1).Contains("O") || input.getLeter(i + 2).Contains("O"))
                        || !(input.getLeter(i - 1).Contains("U") || input.getLeter(i + 2).Contains("U"))))
                    {
                        input = input.Remove(i, 1);
                        //i--;
                    }
                    //}
                    ////Change the ending of GN and GNED
                    //for (int i = 1; i < input.Length - 1; i++)
                    //{
                    if (input.getTwoLeters(i).Contains("GN") || input.getFourLeters(i).Contains("GNED"))
                    {
                        input = input.Remove(i, 1);
                        //i--;
                    }
                    //}
                    //// Adjust GI, GE, GY and G
                    //for (int i = 1; i < input.Length - 1; i++)
                    //{
                    if ((input.getTwoLeters(i).Contains("GI") || input.getTwoLeters(i).Contains("GE") || input.getTwoLeters(i).Contains("GY")) && !(input.getLeter(i - 1).Contains("D")))
                    {
                        StringBuilder sb = new StringBuilder(input);
                        sb[i] = 'J';
                        input = sb.ToString();
                    }
                    else if (input.getLeter(i).Contains("G"))
                    {
                        StringBuilder sb = new StringBuilder(input);
                        sb[i] = 'K';
                        input = sb.ToString();
                    }
                    //}
                    //// Delete H if its after a vowel, but not before
                    //for (int i = 1; i < input.Length - 1; i++)
                    //{
                    if (input.getLeter(i).Contains("H") &&
                        (input.getLeter(i - 1).Contains("A")
                        || input.getLeter(i - 1).Contains("E")
                        || input.getLeter(i - 1).Contains("I")
                        || input.getLeter(i - 1).Contains("O")
                        || input.getLeter(i - 1).Contains("U")))
                    {
                        input = input.Remove(i, 1);
                    }
                    //}
                    ////Adjust CK, Q, PH, V and Z
                    //for (int i = 1; i < input.Length - 1; i++)
                    //{
                    if (input.getTwoLeters(i).Contains("CK"))
                    {
                        input = input.Remove(i, 1);
                    }
                    else if (input.getLeter(i).Contains("Q"))
                    {
                        StringBuilder sb = new StringBuilder(input);
                        sb[i] = 'K';
                        input = sb.ToString();
                    }
                    else if (input.getTwoLeters(i).Contains("PH"))
                    {
                        input = input.Remove(i, 1);
                        StringBuilder sb = new StringBuilder(input);
                        sb[i] = 'F';
                        input = sb.ToString();
                    }
                    else if (input.getLeter(i).Contains("V"))
                    {
                        StringBuilder sb = new StringBuilder(input);
                        sb[i] = 'F';
                        input = sb.ToString();
                    }
                    else if (input.getLeter(i).Contains("Z"))
                    {
                        StringBuilder sb = new StringBuilder(input);
                        sb[i] = 'S';
                        input = sb.ToString();
                    }
                    //}
                    ////Adjust SH, SIO, TIO, SIA, TIA and TH
                    //for (int i = 1; i < input.Length - 1; i++)
                    //{
                    if (input.getTwoLeters(i).Contains("SH") || input.getThreeLeters(i).Contains("SIO") || input.getThreeLeters(i).Contains("TIO") || input.getThreeLeters(i).Contains("SIA") || input.getThreeLeters(i).Contains("TIA"))
                    {
                        StringBuilder sb = new StringBuilder(input);
                        sb[i] = 'X';
                        input = sb.ToString();
                    }
                    else if (input.getTwoLeters(i).Contains("TH"))
                    {
                        StringBuilder sb = new StringBuilder(input);
                        sb[i] = 'O';
                        input = sb.ToString();
                        input = input.Remove(i + 1, 1);
                    }
                    //}
                    ////Adjust TCH, WH and remove W if there is no vowel after
                    //for (int i = 1; i < input.Length - 1; i++)
                    //{
                    if (input.getThreeLeters(i).Contains("TCH"))
                    {
                        input = input.Remove(i, 1);
                    }
                    else if (input.getTwoLeters(i).Contains("WH"))
                    {
                        input = input.Remove(i + 1, 1);
                    }
                    if (input.getLeter(i).Contains("W") &&
                        !(input.getLeter(i + 1).Contains("A")
                        || input.getLeter(i + 1).Contains("E")
                        || input.getLeter(i + 1).Contains("I")
                        || input.getLeter(i + 1).Contains("O")
                        || input.getLeter(i + 1).Contains("U")))
                    {
                        input = input.Remove(i, 1);

                    }
                    //}
                    ////Adjust X to S
                    //for (int i = 1; i < input.Length - 1; i++)
                    //{
                    if (input.getLeter(i).Contains("X") && i==0)
                    {
                        StringBuilder sb = new StringBuilder(input);
                        sb[i] = 'S';
                        input = sb.ToString();
                    }else if (input.getLeter(i).Contains("X"))
                    {
                        StringBuilder sb = new StringBuilder(input);
                        sb[i] = 'K';
                        input = sb.ToString();
                        input = input.Insert(i + 1, "S");
                    }
                }


                //Delete all Y that arn't before vowels
                for (int i = 1; i < input.Length ; i++)
                {
                    if (input.getLeter(i).Contains("Y") &&
                        !(input.getLeter(i + 1).Contains("A")
                        || input.getLeter(i + 1).Contains("E")
                        || input.getLeter(i + 1).Contains("I")
                        || input.getLeter(i + 1).Contains("O")
                        || input.getLeter(i + 1).Contains("U")))
                    {

                        input = input.Remove(i, 1);
                    }
                }
                //Delete all vowels
                for (int i = 1; i < input.Length ; i++)
                {
                    if (input.getLeter(i).Contains("A")
                        || input.getLeter(i ).Contains("E")
                        || input.getLeter(i).Contains("I")
                        || input.getLeter(i).Contains("O")
                        || input.getLeter(i).Contains("U"))
                    {

                        input = input.Remove(i, 1);
                        i--;
                    }
                }
                Console.WriteLine("");
                Console.WriteLine(input);
                Console.WriteLine("");
            }
            
        }

        
        
    }
    public static class StringExtensions
    {
        public static string getLeter(this string s, int i)
        {
            if (i > s.Length || i < 0)
            {
                return "";
            }
            else
            {
                return s.Substring(i, 1);
            }
        }
        public static string getTwoLeters(this string s, int i)
        {
            if (i + 2 > s.Length)
            {
                return s.getLeter(i);
            }
            else
            {
                return s.Substring(i, 2);
            }
        }
        public static string getThreeLeters(this string s, int i)
        {
            if (i + 3 > s.Length)
            {
                return s.getTwoLeters(i);
            }
            else
            {
                return s.Substring(i, 3);
            }
        }
        public static string getFourLeters(this string s, int i)
        {
           
            if(i + 4 > s.Length)
            {
                return s.getThreeLeters(i);
            }
            else
            {
                return s.Substring(i, 4);
            }
            
        }
    }
}
