using System;
using System.Collections.Generic;
using Sakktabla.ChessPieces;

namespace Sakktabla
{
    public class Steps
    {
        private bool voltlepes = false;

        public void Step(int globallepesek, string[,] matrix, string parancs, Table m, char BorW, char BorW2)
        {
            ChangePosition cp = new ChangePosition();
            if (globallepesek == 0)
            {
                Console.Write("\n" + "A fehér kezd: ");
                parancs = Console.ReadLine();
            }
            else if(globallepesek % 2 == 1)
            {
                Console.Write("\n" + "A fekete következik: ");
                parancs = Console.ReadLine();
            }
            else
            {
                Console.Write("\n" + "A fehér következik: ");
                parancs = Console.ReadLine();
            }
            if (parancs.Length != 3)
            {
                Console.WriteLine("Helyesen adja meg a bábut amivel lépni kíván!");
            }
            else
            {
                Pieces(parancs, matrix, m, cp, BorW, BorW2);
            }
        }

        private void Pieces(string parancs, string[,] matrix, Table m, ChangePosition cp, char BorW, char BorW2)
        {
            List<string> lehetsegeslepes = new List<string>();
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (parancs.Contains("P" + BorW2) && matrix[i, j].Contains(parancs))
                    {
                        Pawn paraszt = new Pawn(i, j);
                        if (BorW2 == 'B') paraszt.LepesekBlack(matrix, i, j, lehetsegeslepes);
                        else if (BorW2 == 'W') paraszt.LepesekWhite(matrix, i, j, lehetsegeslepes);
                        PiecesStep(i, j, parancs, matrix, m, lehetsegeslepes, cp);
                        parancs = "";
                    }
                    else if (parancs.Contains("Ki" + BorW2) && matrix[i, j].Contains(parancs))
                    {
                        King Kiraly = new King(i, j); 
                        Kiraly.Lepesek(matrix, i, j, lehetsegeslepes, BorW);
                        PiecesStep(i, j, parancs, matrix, m, lehetsegeslepes, cp);
                        parancs = "";
                    }
                    else if (parancs.Contains("Qu" + BorW2) && matrix[i, j].Contains(parancs))
                    {
                        Queen Kiralyno = new Queen(i, j);
                        Kiralyno.Lepesek(matrix, i, j, lehetsegeslepes, BorW, BorW2);
                        PiecesStep(i, j, parancs, matrix, m, lehetsegeslepes, cp);
                        parancs = "";
                    }
                    else if (parancs.Contains("C" + BorW2) && matrix[i, j].Contains(parancs))
                    {
                        Castle Bastya = new Castle(i, j);
                        Bastya.Lepesek(matrix, i, j, lehetsegeslepes, BorW, BorW2);
                        PiecesStep(i, j, parancs, matrix, m, lehetsegeslepes, cp);
                        parancs = "";
                    }
                    else if (parancs.Contains("H" + BorW2) && matrix[i, j].Contains(parancs))
                    {
                        Horse Lo = new Horse(i, j);
                        Lo.Lepesek(matrix, i, j, lehetsegeslepes, BorW);
                        PiecesStep(i, j, parancs, matrix, m, lehetsegeslepes, cp);
                        parancs = "";
                    }
                    else if (parancs.Contains("B" + BorW2) && matrix[i, j].Contains(parancs))
                    {
                        Bishop Futo = new Bishop(i, j);
                        Futo.Lepesek(matrix, i, j, lehetsegeslepes, BorW, BorW2);
                        PiecesStep(i, j, parancs, matrix, m, lehetsegeslepes, cp);
                        parancs = "";
                    }
                }
            } 
        }

        private void PiecesStep(int i, int j, string parancs, string[,] matrix, Table m,
                        List<string> lehetsegeslepes, ChangePosition cp)
        {
            Kiir(lehetsegeslepes, cp);
            if (lehetsegeslepes.Count != 0)
            {
                Console.Write("Add meg hova akarsz lépni: ");
                string lepes = cp.BetuSzam(Console.ReadLine());
                string lepesparancs = lepes;
                for (int z = 0; z < lehetsegeslepes.Count; z++)
                {
                    if (lehetsegeslepes[z] == lepesparancs)
                    {
                        string[] adat = { lepesparancs[0].ToString(), lepesparancs[1].ToString() };
                        matrix[int.Parse(adat[0]) - 1, int.Parse(adat[1]) - 1] = "[" + parancs + "]";
                        matrix[i, j] = "[   ]";
                    }
                }
                m.General(matrix);
                voltlepes = true;
            }
            else if (lehetsegeslepes.Count == 0)
            {
                Console.WriteLine("Nincs lehetséges lépés!");
            }
        }

        private void Kiir(List<string> lehetsegeslepes, ChangePosition cp)
        {
            Console.WriteLine("\n" + "Lehetséges lépések:");
            int lepesszamlalo = 0;
            for (int x = 0; x < lehetsegeslepes.Count; x++)
            {
                string lehetlepes = cp.SzamBetu(lehetsegeslepes[x]);
                Console.Write("\t" + lehetlepes);
                lepesszamlalo++;
                if (lepesszamlalo % 4 == 0)
                {
                    Console.WriteLine();
                }
            }
            Console.WriteLine("\n");
        }

        public bool megtortentlepes()
        {
            return voltlepes;
        }
    }
}