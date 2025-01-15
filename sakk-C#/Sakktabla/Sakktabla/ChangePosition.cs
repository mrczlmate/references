using System;

namespace Sakktabla
{
     public class ChangePosition
    {
        public string BetuSzam(string parancs)
        {
            char X = parancs[0];
            char Y = parancs[1];
            switch (Y)
            {
                case 'A':
                    Y = '1';
                    break;
                case 'B':
                    Y = '2';
                    break;
                case 'C':
                    Y = '3';
                    break;
                case 'D':
                    Y = '4';
                    break;
                case 'E':
                    Y = '5';
                    break;
                case 'F':
                    Y = '6';
                    break;
                case 'G':
                    Y = '7';
                    break;
                case 'H':
                    Y = '8';
                    break;
                default:
                    break;
            }
            return String.Concat(X, Y);
        }

        public string SzamBetu(string parancs)
        {
            char X = parancs[0];
            char Y = parancs[1];
            switch (Y)
            {
                case '1':
                    Y = 'A';
                    break;
                case '2':
                    Y = 'B';
                    break;
                case '3':
                    Y = 'C';
                    break;
                case '4':
                    Y = 'D';
                    break;
                case '5':
                    Y = 'E';
                    break;
                case '6':
                    Y = 'F';
                    break;
                case '7':
                    Y = 'G';
                    break;
                case '8':
                    Y = 'H';
                    break;
                default:
                    break;
            }
            return String.Concat(X, Y);
        }
    }
}