using System;

namespace ArrayException
{
    static class DisplayMenu
    {
        public const int startLeft = 0;
        public const int startTop = 0;

        static string headerMenuText;
        static string mainMenuText;

        static int nextX=40;
        static int nextY=6;

        static DisplayMenu()
        {
            headerMenuText = Model.GetHeaderMenuText();
            mainMenuText = Model.GetMainMenuText();
        }

        public static void PrintHeaderMenuText()
        {
            for (int j = 0; j <= nextY; j++)
            {
                if (j == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.SetCursorPosition(startLeft + (nextX / 2) - ((headerMenuText.Length) / 2), startTop + j);
                    Console.Write(headerMenuText+"\n");

                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    var str = mainMenuText.Split('\n');
                    foreach (var p in str)
                    {
                        Console.SetCursorPosition(3, Console.CursorTop);
                        Console.WriteLine(p);
                    }
                }
                Console.ForegroundColor = ConsoleColor.Yellow;

                if (j == 0 || j == nextY)
                {

                    for (int i = 0; i <= nextX; i++)
                    {
                        Console.SetCursorPosition(startLeft + i, startTop + j);
                        if (i == 0)
                            Console.Write("+");
                        else if (i == nextX)
                            Console.Write("+");
                        else
                            Console.Write("-");
                    }
                }
                else
                {
                    Console.SetCursorPosition(startLeft, startTop + j);
                    Console.Write("|");
                    Console.SetCursorPosition(startLeft + nextX, startTop + j);
                    Console.Write("|");
                }
            }
            Console.WriteLine();
        }

        public static void PrintSeparator()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n\n" + new string('-', 10) + "Exception" + new string('-', 10));
        }

        public static void ClearSector()
        {
            int x = Console.CursorLeft;
            int y = Console.CursorTop;

            Console.SetCursorPosition(x, y);
            for (int i=0; i<=Console.WindowHeight;i++ )
                Console.Write(new string(' ', Console.WindowWidth));

            Console.SetCursorPosition(x, y);
        }


    }
}
