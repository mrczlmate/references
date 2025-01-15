using System;

namespace Sakktabla
{
    public class Table
    {
        public string[,] Tabla()
        {
            var matrix = new string[,]
            {
                     //    A        B        C        D        E        F        G        H
                /*1*/ { "[CW1]", "[HW1]", "[BW1]", "[KiW]", "[QuW]", "[BW2]", "[HW2]", "[CW2]" },
                /*2*/ { "[PW1]", "[PW2]", "[PW3]", "[PW4]", "[PW5]", "[PW6]", "[PW7]", "[PW8]" },
                /*3*/ { "[   ]", "[   ]", "[   ]", "[   ]", "[   ]", "[   ]", "[   ]", "[   ]" },
                /*4*/ { "[   ]", "[   ]", "[   ]", "[   ]", "[   ]", "[   ]", "[   ]", "[   ]" },
                /*5*/ { "[   ]", "[   ]", "[   ]", "[   ]", "[   ]", "[   ]", "[   ]", "[   ]" },
                /*6*/ { "[   ]", "[   ]", "[   ]", "[   ]", "[   ]", "[   ]", "[   ]", "[   ]" },
                /*7*/ { "[PB1]", "[PB2]", "[PB3]", "[PB4]", "[PB5]", "[PB6]", "[PB7]", "[PB8]" },
                /*8*/ { "[CB1]", "[HB1]", "[BB1]", "[QuB]", "[KiB]", "[BB2]", "[HB2]", "[CB2]" },
            };
            return matrix;
        }

        public void General(string[,] matrix)
        {
            Console.WriteLine();
            Console.WriteLine("##|   A     B     C     D     E     F     G     H");
            Console.WriteLine("---------------------------------------------------");
            for (int i = 0; i < 8; i++)
            {
                Console.Write((i + 1) + " |");
                for (int j = 0; j < 8; j++)
                {
                    Console.Write("{0,6}", matrix[i, j]);
                }
                Console.WriteLine();
                Console.WriteLine("  |");
            }
        }
    }
}