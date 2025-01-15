using System.Collections.Generic;

namespace Sakktabla.ChessPieces
{
    public class Horse : PiecesBase
    {
        public Horse(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void Lepesek(string[,] matrix, int x, int y, List<string> lehetsegeslepesek, char BorW)
        {
            if (x != 7)
            {
                if (y != 0)
                {
                    if (y != 1)
                    {
                        if (matrix[x + 1, y - 2] == "[   ]" ||
                            matrix[x + 1, y - 2][2] == BorW ||
                            matrix[x - 1, y - 2][3] == BorW)
                        {
                            lehetsegeslepesek.Add((x + 2).ToString() + (y - 1).ToString());
                        }
                    }
                    if (x != 6)
                    {
                        if (matrix[x + 2, y - 1] == "[   ]" ||
                            matrix[x + 2, y - 1][2] == BorW ||
                            matrix[x + 2, y - 1][3] == BorW)
                        {
                            lehetsegeslepesek.Add((x + 3).ToString() + (y).ToString());
                        }
                    }
                }

                if (y != 7)
                {
                    if (x != 6)
                    {
                        if (matrix[x + 2, y + 1] == "[   ]" ||
                            matrix[x + 2, y + 1][2] == BorW ||
                            matrix[x + 2, y + 1][3] == BorW)
                        {
                            lehetsegeslepesek.Add((x + 3).ToString() + (y + 2).ToString());
                        }
                    }
                    if (y != 6)
                    {
                        if (matrix[x + 1, y + 2] == "[   ]" ||
                            matrix[x + 1, y + 2][2] == BorW ||
                            matrix[x + 1, y + 2][3] == BorW)
                        {
                            lehetsegeslepesek.Add((x + 2).ToString() + (y + 3).ToString());
                        }
                    }
                }
            }

            if (x != 0)
            {
                if (y != 0)
                {
                    if (y != 1)
                    {
                        if (matrix[x - 1, y - 2] == "[   ]" ||
                            matrix[x - 1, y - 2][2] == BorW ||
                            matrix[x - 1, y - 2][3] == BorW)
                        {
                            lehetsegeslepesek.Add((x).ToString() + (y - 1).ToString());
                        }
                    }
                    if (x != 1)
                    {
                        if (matrix[x - 2, y - 1] == "[   ]" ||
                            matrix[x - 2, y - 1][2] == BorW ||
                            matrix[x - 2, y - 1][3] == BorW)
                        {
                            lehetsegeslepesek.Add((x - 1).ToString() + (y).ToString());
                        }
                    }
                }

                if (y != 7)
                {
                    if (y != 6)
                    {
                        if (matrix[x - 1, y + 2] == "[   ]" ||
                            matrix[x - 1, y + 2][2] == BorW ||
                            matrix[x - 1, y + 2][3] == BorW)
                        {
                            lehetsegeslepesek.Add((x).ToString() + (y + 3).ToString());
                        }
                    }
                    if (x != 1)
                    {
                        if (matrix[x - 2, y + 1] == "[   ]" ||
                            matrix[x - 2, y + 1][2] == BorW ||
                            matrix[x - 2, y + 1][3] == BorW)
                        {
                            lehetsegeslepesek.Add((x - 1).ToString() + (y + 2).ToString());
                        }
                    }
                }
            }
        }
    }
}
