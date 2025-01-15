namespace Sakktabla
{
    class Program
    {
        static void Main(string[] args)
        {
            Table m = new Table();
            string[,] matrix =  m.Tabla();
            Description D = new Description();
            D.leiras();
            m.General(matrix);
            string parancs = "";
            int globallepesek = 0;
            bool voltlepes = false;
            char BorW;
            char BorW2;

            while (parancs != "vege")
            {
                if (globallepesek % 2 == 0)
                {
                    BorW = 'B';
                    BorW2 = 'W';
                    while (voltlepes != true)
                    {
                        Steps ws = new Steps();
                        ws.Step(globallepesek, matrix, parancs, m, BorW, BorW2);
                        voltlepes = ws.megtortentlepes();
                    }
                    voltlepes = false;
                }
                else if (globallepesek % 2 == 1)
                {
                    BorW = 'W';
                    BorW2 = 'B';
                    while (voltlepes != true)
                    {
                        Steps bs = new Steps();
                        bs.Step(globallepesek, matrix, parancs, m, BorW, BorW2);
                        voltlepes = bs.megtortentlepes();
                    }
                    voltlepes = false;
                }
                globallepesek++;
            }
        }
    }
}