using System.Collections.Generic;

namespace Sakktabla.ChessPieces
{
    public class Bishop : PiecesBase
    {
        public Bishop(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void Lepesek(string[,] matrix, int x, int y, List<string> lehetsegeslepesek, char BorW, char BorW2)
        {
            Diagonal_Move(matrix, x, y, lehetsegeslepesek, BorW, BorW2);
        }
    }
}
