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

        Pixel waz1 = new Pixel();
        waz1.xPos = screenwidth / 2;
        waz1.yPos = screenheight / 2;
        waz1.schermKleur = ConsoleColor.Red;
        string movement1 = "RIGHT";
        List<int> ogon1 = new List<int>();
        int score1 = 0;

        Pixel waz2 = new Pixel();
        waz2.xPos = screenwidth / 3;
        waz2.yPos = screenheight / 3;
        waz2.schermKleur = ConsoleColor.Yellow;
        string movement2 = "D";
        List<int> ogon2 = new List<int>();
        int score2 = 0;

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
                Console.SetCursorPosition(i, 0); Console.Write("■");
                Console.SetCursorPosition(i, screenheight - 1); Console.Write("■");
            }
            for (int i = 0; i < screenheight; i++)
            {
                Console.SetCursorPosition(0, i); Console.Write("■");
                Console.SetCursorPosition(screenwidth - 1, i); Console.Write("■");
            }

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(1, screenheight);
            Console.WriteLine($"P1: {score1} | P2: {score2}");

            Console.ForegroundColor = ConsoleColor.Green;
            for (int i = 0; i < ogon1.Count; i += 2)
            {
                Console.SetCursorPosition(ogon1[i], ogon1[i + 1]);
                Console.Write("■");
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(waz1.xPos, waz1.yPos);
            Console.Write("■");

            Console.ForegroundColor = ConsoleColor.Magenta;
            for (int i = 0; i < ogon2.Count; i += 2)
            {
                Console.SetCursorPosition(ogon2[i], ogon2[i + 1]);
                Console.Write("■");
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(waz2.xPos, waz2.yPos);
            Console.Write("■");

            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo info = Console.ReadKey(true);
                switch (info.Key)
                {
                    case ConsoleKey.UpArrow: if (movement1 != "DOWN") movement1 = "UP"; break;
                    case ConsoleKey.DownArrow: if (movement1 != "UP") movement1 = "DOWN"; break;
                    case ConsoleKey.LeftArrow: if (movement1 != "RIGHT") movement1 = "LEFT"; break;
                    case ConsoleKey.RightArrow: if (movement1 != "LEFT") movement1 = "RIGHT"; break;

                    case ConsoleKey.W: if (movement2 != "S") movement2 = "W"; break;
                    case ConsoleKey.S: if (movement2 != "W") movement2 = "S"; break;
                    case ConsoleKey.A: if (movement2 != "D") movement2 = "A"; break;
                    case ConsoleKey.D: if (movement2 != "A") movement2 = "D"; break;
                }
            }

            ogon1.Insert(0, waz1.xPos);
            ogon1.Insert(1, waz1.yPos);
            if (movement1 == "UP") waz1.yPos--;
            if (movement1 == "DOWN") waz1.yPos++;
            if (movement1 == "LEFT") waz1.xPos--;
            if (movement1 == "RIGHT") waz1.xPos++;

            ogon2.Insert(0, waz2.xPos);
            ogon2.Insert(1, waz2.yPos);
            if (movement2 == "W") waz2.yPos--;
            if (movement2 == "S") waz2.yPos++;
            if (movement2 == "A") waz2.xPos--;
            if (movement2 == "D") waz2.xPos++;

            if (waz1.xPos == obstacleXpos && waz1.yPos == obstacleYpos)
            {
                score1++;
                obstacleXpos = randomnummer.Next(1, screenwidth - 1);
                obstacleYpos = randomnummer.Next(1, screenheight - 1);
            }
            else if (ogon1.Count > 0) { ogon1.RemoveAt(ogon1.Count - 1); ogon1.RemoveAt(ogon1.Count - 1); }

            if (waz2.xPos == obstacleXpos && waz2.yPos == obstacleYpos)
            {
                score2++;
                obstacleXpos = randomnummer.Next(1, screenwidth - 1);
                obstacleYpos = randomnummer.Next(1, screenheight - 1);
            }
            else if (ogon2.Count > 0) { ogon2.RemoveAt(ogon2.Count - 1); ogon2.RemoveAt(ogon2.Count - 1); }

            if (waz1.xPos <= 0 || waz1.xPos >= screenwidth - 1 || waz1.yPos <= 0 || waz1.yPos >= screenheight - 1)
                GameOver("Gracz 1 uderzył w ścianę! Wygrał Gracz 2.");
            if (waz2.xPos <= 0 || waz2.xPos >= screenwidth - 1 || waz2.yPos <= 0 || waz2.yPos >= screenheight - 1)
                GameOver("Gracz 2 uderzył w ścianę! Wygrał Gracz 1.");

            for (int i = 0; i < ogon1.Count; i += 2)
                if (waz1.xPos == ogon1[i] && waz1.yPos == ogon1[i + 1]) GameOver("Gracz 1 zjadł ogon! Wygrał Gracz 2.");
            for (int i = 0; i < ogon2.Count; i += 2)
                if (waz2.xPos == ogon2[i] && waz2.yPos == ogon2[i + 1]) GameOver("Gracz 2 zjadł ogon! Wygrał Gracz 1.");

            if (waz1.xPos == waz2.xPos && waz1.yPos == waz2.yPos) GameOver("Remis! Zderzenie czołowe.");

            for (int i = 0; i < ogon2.Count; i += 2)
                if (waz1.xPos == ogon2[i] && waz1.yPos == ogon2[i + 1]) GameOver("Gracz 1 wjechał w Gracza 2! Wygrał Gracz 2.");

            for (int i = 0; i < ogon1.Count; i += 2)
                if (waz2.xPos == ogon1[i] && waz2.yPos == ogon1[i + 1]) GameOver("Gracz 2 wjechał w Gracza 1! Wygrał Gracz 1.");

            Thread.Sleep(100);
        }
    }

    static void GameOver(string info)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("KONIEC GRY");
        Console.WriteLine(info);
        Console.WriteLine("Naciśnij ENTER aby wyjść...");
        Console.ReadLine();
        Environment.Exit(0);
    }
}