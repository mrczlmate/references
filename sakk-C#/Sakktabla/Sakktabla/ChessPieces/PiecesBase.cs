using System.Collections.Generic;

namespace Sakktabla.ChessPieces
{
    public class PiecesBase
    {
        public int X { get; protected set; }
        public int Y { get; protected set; }

        public List<string> Hor_Ver_Move(string[,] matrix, int x, int y, List<string> lehetsegeslepesek, char BorW, char BorW2)
        {
            if (x != 7) //jobbra
            {
                for (int i = 1; i < (8 - x); i++)
                {
                    if (!matrix[x + i, y].Contains(BorW2))
                    {
                        if (matrix[x + i, y] == "[   ]")
                        {
                            lehetsegeslepesek.Add((x + i + 1).ToString() + (y + 1).ToString());
                        }
                        else if (matrix[x + i, y][2] == BorW || matrix[x + i, y][3] == BorW)
                        {
                            lehetsegeslepesek.Add((x + i + 1).ToString() + (y + 1).ToString());
                            break;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }

            if (x != 0) //balra
            {
                for (int i = 1; i < (8 - (7 - x)); i++)
                {
                    if (!matrix[x - i, y].Contains(BorW2))
                    {
                        if (matrix[x - i, y] == "[   ]")
                        {
                            lehetsegeslepesek.Add((x - i + 1).ToString() + (y + 1).ToString());
                        }
                        else if (matrix[x - i, y][2] == BorW || matrix[x - i, y][3] == BorW)
                        {
                            lehetsegeslepesek.Add((x - i + 1).ToString() + (y + 1).ToString());
                            break;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }

            if (y != 0) //fel
            {
                for (int i = 1; i < (8 - (7 - y)); i++)
                {
                    if (!matrix[x, y - i].Contains(BorW2))
                    {
                        if (matrix[x, y - i] == "[   ]")
                        {
                            lehetsegeslepesek.Add((x + 1).ToString() + (y - i + 1).ToString());
                        }
                        else if (matrix[x, y - i][2] == BorW || matrix[x, y - i][3] == BorW)
                        {
                            lehetsegeslepesek.Add((x + 1).ToString() + (y - i + 1).ToString());
                            break;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }

            if (y != 7) //le
            {
                for (int i = 1; i < (8 - y); i++)
                {
                    if (!matrix[x, y + i].Contains(BorW2))
                    {
                        if (matrix[x, y + i] == "[   ]")
                        {
                            lehetsegeslepesek.Add((x + 1).ToString() + (y + i + 1).ToString());
                        }
                        else if (matrix[x, y + i][2] == BorW || matrix[x, y + i][3] == BorW)
                        {
                            lehetsegeslepesek.Add((x + 1).ToString() + (y + i + 1).ToString());
                            break;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }

            return lehetsegeslepesek;
        }

        public List<string> Diagonal_Move(string[,] matrix, int x, int y, List<string> lehetsegeslepesek, char BorW, char BorW2)
        {
            if (x != 7 && y != 7) //jobbra le
            {
                for (int i = 1; i < 8; i++)
                {
                    if (!matrix[x + i, y + i].Contains(BorW2))
                    {
                        if (matrix[x + i, y + i] == "[   ]")
                        {
                            lehetsegeslepesek.Add((x + i + 1).ToString() + (y + i + 1).ToString());
                        }
                        else if (matrix[x + i, y + i][2] == BorW || matrix[x + i, y + i][3] == BorW)
                        {
                            lehetsegeslepesek.Add((x + i + 1).ToString() + (y + i + 1).ToString());
                            break;
                        }
                    }
                    else
                    {
                        break;
                    }
                    if (x + i == 7 || y + i == 7)
                    {
                        break;
                    }
                }
            }

            if (x != 0 && y != 0) //balra fel
            {
                for (int i = 1; i < 8; i++)
                {
                    if (!matrix[x - i, y - i].Contains(BorW2))
                    {
                        if (matrix[x - i, y - i] == "[   ]")
                        {
                            lehetsegeslepesek.Add((x - i + 1).ToString() + (y - i + 1).ToString());
                        }
                        else if (matrix[x - i, y - i][2] == BorW || matrix[x - i, y - i][3] == BorW)
                        {
                            lehetsegeslepesek.Add((x - i + 1).ToString() + (y - i + 1).ToString());
                            break;
                        }
                    }
                    else
                    {
                        break;
                    }
                    if (x - i == 0 || y - i == 0)
                    {
                        break;
                    }
                }
            }

            if (y != 0 && x != 7) //balra le
            {
                for (int i = 1; i < 8; i++)
                {
                    if (!matrix[x + i, y - i].Contains(BorW2))
                    {
                        if (matrix[x + i, y - i] == "[   ]")
                        {
                            lehetsegeslepesek.Add((x + i + 1).ToString() + (y - i + 1).ToString());
                        }
                        else if (matrix[x + i, y - i][2] == BorW || matrix[x + i, y - i][3] == BorW)
                        {
                            lehetsegeslepesek.Add((x + i + 1).ToString() + (y - i + 1).ToString());
                            break;
                        }
                    }
                    else
                    {
                        break;
                    }
                    if (x + i == 7 || y - i == 0)
                    {
                        break;
                    }
                }
            }

            if (y != 7 && x != 0) //jobbra fel
            {
                for (int i = 1; i < 8; i++)
                {
                    if (!matrix[x - i, y + i].Contains(BorW2))
                    {
                        if (matrix[x - i, y + i] == "[   ]")
                        {
                            lehetsegeslepesek.Add((x - i + 1).ToString() + (y + i + 1).ToString());
                        }
                        else if (matrix[x - i, y + i][2] == BorW || matrix[x - i, y + i][3] == BorW)
                        {
                            lehetsegeslepesek.Add((x - i + 1).ToString() + (y + i + 1).ToString());
                            break;
                        }
                    }
                    else
                    {
                        break;
                    }
                    if (x - i == 0 || y + i == 7)
                    {
                        break;
                    }
                }
            }

            return lehetsegeslepesek;
        }
    }
}
