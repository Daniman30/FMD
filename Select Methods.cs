using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FMD
{
    public class Select 
    {
        public Cards SelectCard(ConsoleKey key, int pos)
        {  
            switch (key)
            {
                case ConsoleKey.D0:
                    if (Game.Field[pos, 0] == null) { System.Console.WriteLine("this position is empty"); return null;}
                    return Game.Field[pos,0];
                    
                case ConsoleKey.D1:
                    if (Game.Field[pos, 1] == null) { System.Console.WriteLine("this position is empty"); return null;}
                    return Game.Field[pos,1];
                   
                case ConsoleKey.D2:
                    if (Game.Field[pos, 2] == null) { System.Console.WriteLine("this position is empty"); return null;}
                    return Game.Field[pos, 2];
               
            }
            System.Console.WriteLine("Select a valid card");
            key =Console.ReadKey(true).Key;
            return SelectCard(key, pos);
            
        }
        public int SelectNumber(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.D0:
                    return 0;
                case ConsoleKey.D1:
                    return 1;
                case ConsoleKey.D2:
                    return 2;
                case ConsoleKey.D3:
                    return 3;   
                case ConsoleKey.D4:
                    return 4;
                case ConsoleKey.D5:
                    return 5;
                case ConsoleKey.D6:
                    return 6;
                case ConsoleKey.D7:
                    return 7;           
                default:
                    break;
            }
            System.Console.WriteLine("Select a valid card");
            Thread.Sleep(1000);
            key = Console.ReadKey(true).Key;
            return SelectNumber(key);
        }
    }
}