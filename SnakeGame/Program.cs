using SnakeGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

class Program
{
    static void Main()
    {
        Console.WindowHeight = 18;
        Console.WindowWidth = 32;

        int screenwidth = Console.WindowWidth;
        int screenheight = 16;

        Random randomnummer = new Random();

        Pixel hoofd = new Pixel();
        hoofd.xPos = screenwidth / 2;
        hoofd.yPos = screenheight / 2;
        hoofd.schermKleur = ConsoleColor.Red;

        string movement = "RIGHT";
        int score = 0;

        List<int> telje = new List<int>();

        DateTime tijd = DateTime.Now;
        string obstacle = "*";
        int obstacleXpos = randomnummer.Next(1, screenwidth - 1);
        int obstacleYpos = randomnummer.Next(1, screenheight - 1);

        while (true)
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(obstacleXpos, obstacleYpos);
            Console.Write(obstacle);

            Console.ForegroundColor = ConsoleColor.White;
            for (int i = 0; i < screenwidth; i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.Write("■");
                Console.SetCursorPosition(i, screenheight - 1);
                Console.Write("■");
            }
            for (int i = 0; i < screenheight; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write("■");
                Console.SetCursorPosition(screenwidth - 1, i);
                Console.Write("■");
            }

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(2, screenheight);
            Console.WriteLine("Score: " + score);

            Console.ForegroundColor = ConsoleColor.Green;
            for (int i = 0; i < telje.Count; i += 2)
            {
                Console.SetCursorPosition(telje[i], telje[i + 1]);
                Console.Write("■");
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(hoofd.xPos, hoofd.yPos);
            Console.Write("■");

            Console.SetCursorPosition(hoofd.xPos, hoofd.yPos);

            Console.Write("■");

            Console.SetCursorPosition(hoofd.xPos, hoofd.yPos);

            Console.Write("■");

            Console.SetCursorPosition(hoofd.xPos, hoofd.yPos);

            Console.Write("■");

            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo info = Console.ReadKey(true);
                switch (info.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (movement != "DOWN") movement = "UP";
                        break;
                    case ConsoleKey.DownArrow:
                        if (movement != "UP") movement = "DOWN";
                        break;
                    case ConsoleKey.LeftArrow:
                        if (movement != "RIGHT") movement = "LEFT";
                        break;
                    case ConsoleKey.RightArrow:
                        if (movement != "LEFT") movement = "RIGHT";
                        break;
                }
            }

            telje.Insert(0, hoofd.xPos);
            telje.Insert(1, hoofd.yPos);

            if (movement == "UP") hoofd.yPos--;
            if (movement == "DOWN") hoofd.yPos++;
            if (movement == "LEFT") hoofd.xPos--;
            if (movement == "RIGHT") hoofd.xPos++;

            if (hoofd.xPos == obstacleXpos && hoofd.yPos == obstacleYpos)
            {
                score++;
                obstacleXpos = randomnummer.Next(1, screenwidth - 1);
                obstacleYpos = randomnummer.Next(1, screenheight - 1);
            }
            else
            {
                if (telje.Count > 0)
                {
                    telje.RemoveAt(telje.Count - 1);
                    telje.RemoveAt(telje.Count - 1);
                }
            }

            if (hoofd.xPos <= 0  hoofd.xPos >= screenwidth - 1  hoofd.yPos <= 0 || hoofd.yPos >= screenheight - 1)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(screenwidth / 5, screenheight / 2);
                Console.WriteLine("Game Over");
                Console.SetCursorPosition(screenwidth / 5, screenheight / 2 + 1);
                Console.WriteLine("Twój wynik: " + score);
                Console.SetCursorPosition(screenwidth / 5, screenheight / 2 + 2);
                Environment.Exit(0);
            }

            for (int i = 0; i < telje.Count; i += 2)
            {
                if (hoofd.xPos == telje[i] && hoofd.yPos == telje[i + 1])
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(screenwidth / 5, screenheight / 2);
                    Console.WriteLine("Game Over");
                    Console.SetCursorPosition(screenwidth / 5, screenheight / 2 + 1);
                    Console.WriteLine("Twój wynik: " + score);
                    Console.SetCursorPosition(screenwidth / 5, screenheight / 2 + 2);
                    Environment.Exit(0);
                }
            }

            Thread.Sleep(100);
        }
    }

    static void GameOver(int score, int width, int height)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.SetCursorPosition(width / 5, height / 2);
        Console.WriteLine("Game Over");
        Console.SetCursorPosition(width / 5, height / 2 + 1);
        Console.WriteLine("Twój wynik: " + score);
        Console.SetCursorPosition(width / 5, height / 2 + 2);
        Environment.Exit(0);
    }
}
