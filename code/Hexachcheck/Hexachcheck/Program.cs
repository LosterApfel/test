﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hexachcheck
{
    class Program
    {
        static bool Hexacheck(char Hex)
        {
            switch (Hex)
            {
                case '1':
                    return true;
                case '2':
                    return true;
                case '3':
                    return true;
                case '4':
                    return true;
                case '5':
                    return true;
                case '6':
                    return true;
                case '7':
                    return true;
                case '8':
                    return true;
                case '9':
                    return true;
                case 'A':
                    return true;
                case 'B':
                    return true;
                case 'C':
                    return true;
                case 'D':
                    return true;
                case 'E':
                    return true;
                case 'F':
                    return true;

                default:
                    return false;
            }



        }

        static int ConvertHex(char HexHex)
        {
            switch (HexHex)
            {
                case '1':
                    return 1;
                case '2':
                    return 2;
                case '3':
                    return 3;
                case '4':
                    return 4;
                case '5':
                    return 5;
                case '6':
                    return 6;
                case '7':
                    return 7;
                case '8':
                    return 8;
                case '9':
                    return 9;
                case 'A':
                    return 10;
                case 'B':
                    return 11;
                case 'C':
                    return 12;
                case 'D':
                    return 13;
                case 'E':
                    return 14;
                case 'F':
                    return 15;

                default:
                    return 404;

            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Geb eine Zahl von 1 bis 9 ein oder einen Buchstaben A bis F");
            char input = char.Parse(Console.ReadLine());
            Console.WriteLine(Hexacheck(input));

            Console.WriteLine(ConvertHex(input));
            Console.ReadKey();
        }
    }
}