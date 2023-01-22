using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FMD
{
    public class Auxiliar 
    {
        public void Configuration()
        {
            while (true)
            {
                Console.Clear();
                System.Console.WriteLine("Background [B]");
                System.Console.WriteLine("Letters [L]");
                System.Console.WriteLine("Dificulty CPU [D]");
                System.Console.WriteLine("Back [ESC]");


                ConsoleKey key = Console.ReadKey(true).Key;
                
                switch (key)
                {
                    case ConsoleKey.B:
                        Background();
                        break;
                    case ConsoleKey.L:
                        Letters();
                        break;
                    case ConsoleKey.D:
                        Game.dif = Difficulty(Game.dif);
                        break;
                    case ConsoleKey.Escape:
                        return;
                    default:
                        break;
                }
            }
        }
        public void Letters()
        {
            int color = 0;
            if (Console.BackgroundColor != 0) 
            {
                
                System.Console.WriteLine("letter's color can't be changed if background isn't black ");
                System.Console.WriteLine("Press any key to abandone");
                Console.ReadLine();
            }

            while (true)
            {
                Console.Clear();
                if (color < 0) color = 15;
                else if (color > 15) color = 0;
                Console.ForegroundColor = (ConsoleColor)color;
                
                System.Console.WriteLine("↑");
                System.Console.WriteLine((ConsoleColor)color);
                System.Console.WriteLine("↓");
                ConsoleKey key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        color++;
                        break;
                    case ConsoleKey.DownArrow:
                        color--;
                        break;
                    case ConsoleKey.Escape:
                        return;
                    default:
                        break;
                }
            }
        }
        public void Background()
        {
            int color = 0;
            
            while (true)
            {
                
                if (color < 0) color = 15;
                else if (color > 15) color = 0;

                Console.BackgroundColor = (ConsoleColor)color;
                Console.Clear();
                
                System.Console.WriteLine("↑");
                System.Console.WriteLine(color);
                System.Console.WriteLine((ConsoleColor)color);
                System.Console.WriteLine("↓");

                ConsoleKey key = Console.ReadKey(true).Key;
                

                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        color++;
                        break;
                    case ConsoleKey.DownArrow:
                        color--;
                        break;
                    case ConsoleKey.Escape:
                        return;
                    default:
                        break;
                }
            }
        }
        public int Difficulty(int dif)
        {
            while (true)
            {
                Console.Clear();
                if (dif < 0) dif = 2;
                else if (dif > 2) dif = 0;
                
                System.Console.WriteLine("↑");
                if (dif == 0) System.Console.WriteLine("Easy");
                else if (dif == 1) System.Console.WriteLine("Medium");
                else System.Console.WriteLine("Hard");
                System.Console.WriteLine("↓");

                ConsoleKey key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        dif++;
                        break;
                    case ConsoleKey.DownArrow:
                        dif--;
                        break;
                    case ConsoleKey.Escape:
                        return dif;
                    default:
                        break;
                }
            }
        }
        public void Instructions()
        {
            StreamReader sr = new StreamReader(@"Instrucciones.txt");
            string Help = sr.ReadToEnd();
            System.Console.Write(Help);
            Console.ReadKey();
            new Print().PrintMenu();
        }
    }
}
