using System.Collections.Generic;

namespace Sakktabla.ChessPieces
{
    public class King : PiecesBase
    {
        public King(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void Lepesek(string[,] matrix, int x, int y, List<string> lehetsegeslepesek, char BorW)
        {
            if (x != 7)
            {
                if (matrix[x + 1, y] == "[   ]" || 
                    matrix[x + 1, y][2] == BorW || 
                    matrix[x + 1, y][3] == BorW)
                {
                    lehetsegeslepesek.Add((x + 2).ToString() + (y + 1).ToString());
                }
            }

            if (x != 7 && y != 7)
            {
                if (matrix[x + 1, y + 1] == "[   ]" ||
                    matrix[x + 1, y + 1][2] == BorW ||
                    matrix[x + 1, y + 1][3] == BorW)
                {
                    lehetsegeslepesek.Add((x + 2).ToString() + (y + 2).ToString());
                }
            }

            if (y != 7)
            {
                if (matrix[x, y + 1] == "[   ]" || 
                    matrix[x, y + 1][2] == BorW || 
                    matrix[x, y + 1][3] == BorW)
                {
                    lehetsegeslepesek.Add((x + 1).ToString() + (y + 2).ToString());
                }
            }

            if (x != 0 && y != 0)
            {
                if (matrix[x - 1, y - 1] == "[   ]" ||
                    matrix[x - 1, y - 1][2] == BorW ||
                    matrix[x - 1, y - 1][3] == BorW)
                {
                    lehetsegeslepesek.Add((x).ToString() + (y).ToString());
                }
            }

            if (y != 0)
            {
                if (matrix[x, y - 1] == "[   ]" || 
                    matrix[x, y - 1][2] == BorW || 
                    matrix[x, y - 1][3] == BorW)
                {
                    lehetsegeslepesek.Add((x + 1).ToString() + (y).ToString());
                }
            }

            if (x != 0)
            {

                if (matrix[x - 1, y] == "[   ]" || 
                    matrix[x - 1, y][2] == BorW || 
                    matrix[x - 1, y][3] == BorW)
                {
                    lehetsegeslepesek.Add((x).ToString() + (y + 1).ToString());
                }
            }

            if (x != 7 && y != 0)
            {
                if (matrix[x + 1, y - 1] == "[   ]" ||
                    matrix[x + 1, y - 1][2] == BorW ||
                    matrix[x + 1, y - 1][3] == BorW)
                {
                    lehetsegeslepesek.Add((x + 2).ToString() + (y).ToString());
                }
            }
            if (x != 0 && y != 7)
            {
                if (matrix[x - 1, y + 1] == "[   ]" ||
                    matrix[x - 1, y + 1][2] == BorW ||
                    matrix[x - 1, y + 1][3] == BorW)
                {
                    lehetsegeslepesek.Add((x).ToString() + (y + 2).ToString());
                }
            }
           
        }
    }
}