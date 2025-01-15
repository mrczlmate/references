using System.Collections.Generic;

namespace Sakktabla.ChessPieces
{
    public class Pawn : PiecesBase
    {
        public Pawn (int x, int y)
        {
            X = x;
            Y = y;
        }

        public void LepesekWhite(string[,] matrix,int x, int y, List<string> lehetsegeslepesek)
        {
            if (x != 7)
            {
                if (x == 1)
                {
                    lehetsegeslepesek.Add((x + 2).ToString() + (y + 1).ToString());
                    if (matrix[x + 2, y].Contains(" "))
                    {
                        lehetsegeslepesek.Add((x + 3).ToString() + (y + 1).ToString());
                    }
                }
                else if (x > 1)
                {
                    if (matrix[x + 1, y].Contains(" "))
                    {
                        lehetsegeslepesek.Add((x + 2).ToString() + (y + 1).ToString());
                    }
                }

                if (y != 7)
                {
                    if (matrix[x + 1, y + 1][2] == 'B' || matrix[x + 1, y + 1][3] == 'B')
                    {
                        lehetsegeslepesek.Add((x + 2).ToString() + (y + 2).ToString());
                    }
                }

                if (y != 0)
                {
                    if (matrix[x + 1, y - 1][2] == 'B' || matrix[x + 1, y - 1][3] == 'B')
                    {
                        lehetsegeslepesek.Add((x + 2).ToString() + (y).ToString());
                    }
                }
            }
        }

        public void LepesekBlack(string[,] matrix,int x, int y, List<string> lehetsegeslepesek)
        {
            if (x != 0)
            {
                if (x == 6)
                {
                    lehetsegeslepesek.Add(x.ToString() + (y + 1).ToString());
                    if (matrix[x - 2, y].Contains(" "))
                    {
                        lehetsegeslepesek.Add((x - 1).ToString() + (y + 1).ToString());
                    }
                }
                else if (x < 6)
                {
                    if (matrix[x - 1, y].Contains(" "))
                    {
                        lehetsegeslepesek.Add(x.ToString() + (y + 1).ToString());
                    }
                }

                if (y != 7)
                {
                    if (matrix[x - 1, y + 1].Contains("W"))
                    {
                        lehetsegeslepesek.Add((x).ToString() + (y + 2).ToString());
                    }
                }

                if (y != 0)
                {
                    if (matrix[x - 1, y - 1].Contains("W"))
                    {
                        lehetsegeslepesek.Add((x).ToString() + (y).ToString());
                    }
                }
            }
        }
    }
}