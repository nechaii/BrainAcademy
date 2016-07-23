namespace Task1_Square
{
    using System;

    class Square
    {
        public static int startLeft;
        public static int startTop;

        string printWord;

        int nextX;
        int nextY;

        Square()
        {
        }

        public Square(string str, int x, int y)
        {
            printWord = str;
            nextX = x;
            nextY = y;
        }

        public void WriteString()
        {
            for (int j=0; j <= nextY; j++)
            {
                if (j == nextY / 2)
                {
                    Console.SetCursorPosition(startLeft + (nextX / 2)-((printWord.Length)/2), startTop + j);
                    Console.Write(printWord);
                }

                if (j == 0 || j== nextY)
                {
                    for (int i = 0; i <= nextX; i++)
                    {
                        Console.SetCursorPosition(startLeft + i, startTop+j);
                        if (i == 0)
                            Console.Write("+");
                        else if (i == nextX)
                            Console.Write("+");
                        else
                            Console.Write("_");
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
        }
    }
}
