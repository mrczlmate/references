using System;

namespace Sakktabla
{
    public class Description
    {
        public void leiras()
        {
            Console.WriteLine("Üdvözöl a sakkjáték!");
            Console.WriteLine("A játék menete:");
            Console.WriteLine("\tA sakk szabályai érvényesek");
            Console.WriteLine("\tA bábúkat azonosító megadásával mozgathatod.");
            Console.WriteLine("\tPéldául: BW1");
            Console.WriteLine("\tEzután pedig a kiválasztott koordinátát kell megadni.");
            Console.WriteLine("\tPéldául: 3A\n" );

            Console.WriteLine("PW = fehér paraszt(Pawn)" + "\t" + "PB = fekete paraszt(Pawn)");
            Console.WriteLine("CW = fehér bástya(Castle)" + "\t" + "CB = fekete bástya(Castle)");
            Console.WriteLine("HW = fehér ló(Horse)" + "\t" + "\t" + "HB = fekete ló(Horse)");
            Console.WriteLine("BW = fehér futó(Bishop)" + "\t" + "\t" + "BB = fekete futó(Bishop)");
            Console.WriteLine("KW = fehér király(King)" + "\t" + "\t" + "KB = fekete király(King)");
            Console.WriteLine("QW = fehér királynő(Queen)" + "\t" + "QB = fekete királynő(Queen)");
        }
    }
}