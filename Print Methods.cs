using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FMD
{
    public class Print
    {
        public void PrintMap()
        {
            for (int i = 0; i < Game.Field.GetLength(0); i++)
            {
                for (int j = 0; j < Game.Field.GetLength(1); j++)
                {
                    if (Game.Field[i, j] == null) System.Console.Write("| EMPTY |");
                    else System.Console.Write("| {0} |", Game.Field[i, j].Name);
                }
                System.Console.WriteLine();
            }
            return;
        }
        public void PrintCardInfo(Cards card)
        {
            System.Console.WriteLine("Name: {0}", card.Name);
            System.Console.WriteLine("Attack: {0}", card.Attack);
            System.Console.WriteLine("Energy: {0}", card.Energy);
            System.Console.WriteLine("Effect: {0}", card.Effects.description);
            System.Console.WriteLine("Cost: {0}", card.Cost);
            System.Console.WriteLine("Type: {0}", card.Type);
            System.Console.WriteLine("Legion: {0}", card.Legion);
        }
        public void PrintOptions(Player player)
        {
            System.Console.WriteLine("Turno #{0} {1}" , Game.turn, player.NamePlayer);
            System.Console.WriteLine("Press I to invoke");
            System.Console.WriteLine("Press A to attack");
            System.Console.WriteLine("Press E to effect");
            System.Console.WriteLine("Press C to consult");
            System.Console.WriteLine("Press S to surrender");
            System.Console.WriteLine("Press X to sacrifice");
            System.Console.WriteLine("Press Esc to finish turn");
        }
        public void PrintMenu()
        {
            Console.Clear();
            System.Console.WriteLine(@"______   _    _    ___");
            System.Console.WriteLine(@"|       | \  / |  |   \");
            System.Console.WriteLine(@"|____   |  \/  |  |    \");
            System.Console.WriteLine(@"|       |      |  |    / ");
            System.Console.WriteLine(@"|       |      |  |___/");
            System.Console.WriteLine();
            System.Console.WriteLine("Press [N] to create a new game");
            System.Console.WriteLine("Press [W] to create a new card");
            System.Console.WriteLine("Press [A] to create a new effect");
            System.Console.WriteLine("Press [C] to configurations");
            System.Console.WriteLine("Press [I] to read the instructions");
            System.Console.WriteLine("Press [ESC] to exit");
        }
        public void PrintHand(List<Cards> Hand)
        {
            int i=0;
            foreach (var card in Hand)
            {
                System.Console.WriteLine(@"_____________________________");
                System.Console.WriteLine(@"|Card " + i + ": "  + card.Name);
                System.Console.WriteLine(@"|Attack: " + card.Attack);
                System.Console.WriteLine(@"|Manna: " + card.Energy);
                System.Console.WriteLine(@"|Cost: " + card.Cost);
                System.Console.WriteLine(@"|Type: " + card.Type);
                System.Console.WriteLine(@"|Effects: " + card.Effects.description);
                System.Console.WriteLine(@"_____________________________");
                i++;
            }
        }
         public void Consult(Player Oplayer)
        {
            new Print().PrintMap();
            System.Console.WriteLine();
            System.Console.WriteLine( "{0} life: {1}", Oplayer.NamePlayer, Oplayer.Life);
            System.Console.WriteLine("{0} Manna: {1}", Oplayer.NamePlayer, Oplayer.Manna);
            System.Console.WriteLine("¿Que carta quieres consultar?");
            System.Console.WriteLine("| 1 | 2 | 3 |");
            System.Console.WriteLine("| Q | W | E |");
            System.Console.WriteLine("| A | S | D |");
            System.Console.WriteLine("| Z | X | C |");
        

            ConsoleKey key = Console.ReadKey(true).Key;
            switch (key)
            {
                case ConsoleKey.D1:
                    if(Game.Field[0, 0] == null) 
                    {
                        System.Console.WriteLine("This position is empty");
                        break;
                    }
                    new Print().PrintCardInfo(Game.Field[0, 0]);
                    break;
                case ConsoleKey.D2:
                    if(Game.Field[0, 1] == null) 
                    {
                        System.Console.WriteLine("This position is empty");
                        break;
                    }
                    new Print().PrintCardInfo(Game.Field[0, 1]);
                    break;
                case ConsoleKey.D3:
                    if(Game.Field[0, 2] == null) 
                    {
                        System.Console.WriteLine("This position is empty");
                        break;
                    }
                    new Print().PrintCardInfo(Game.Field[0, 2]);
                    break;
                case ConsoleKey.Q:
                    if(Game.Field[1, 0] == null) 
                    {
                        System.Console.WriteLine("This position is empty");
                        break;
                    }
                    new Print().PrintCardInfo(Game.Field[1, 0]);
                    break;
                case ConsoleKey.W:
                    if(Game.Field[1, 1] == null) 
                    {
                        System.Console.WriteLine("This position is empty");
                        break;
                    }
                    new Print().PrintCardInfo(Game.Field[1, 1]);
                    break;
                case ConsoleKey.E:
                    if(Game.Field[1, 2] == null) 
                    {
                        System.Console.WriteLine("This position is empty");
                        break;
                    }
                    new Print().PrintCardInfo(Game.Field[1, 2]);
                    break;
                case ConsoleKey.A:
                    if(Game.Field[2, 0] == null) 
                    {
                        System.Console.WriteLine("This position is empty");
                        break;
                    }
                    new Print().PrintCardInfo(Game.Field[2, 0]);
                    break;
                case ConsoleKey.S:
                    if(Game.Field[2, 1] == null) 
                    {
                        System.Console.WriteLine("This position is empty");
                        break;
                    }
                    new Print().PrintCardInfo(Game.Field[2, 1]);
                    break;
                case ConsoleKey.D:
                    if(Game.Field[2, 2] == null) 
                    {
                        System.Console.WriteLine("This position is empty");
                        break;
                    }
                    new Print().PrintCardInfo(Game.Field[2, 2]);
                    break;
                case ConsoleKey.Z:
                    if(Game.Field[3, 0] == null) 
                    {
                        System.Console.WriteLine("This position is empty");
                        break;
                    }
                    new Print().PrintCardInfo(Game.Field[3, 0]);
                    break;
                case ConsoleKey.X:
                    if(Game.Field[3, 1] == null) 
                    {
                        System.Console.WriteLine("This position is empty");
                        break;
                    }
                    new Print().PrintCardInfo(Game.Field[3, 1]);
                    break;
                case ConsoleKey.C:
                    if(Game.Field[3, 2] == null) 
                    {
                        System.Console.WriteLine("This position is empty");
                        break;
                    }
                    new Print().PrintCardInfo(Game.Field[3, 2]);
                    break;
                case ConsoleKey.Escape:
                    break;
                default:
                    break;
            }
            System.Console.WriteLine("Press ESC to left consult");
            ConsoleKey fake = Console.ReadKey(true).Key;
            if (fake == ConsoleKey.Escape) return;
            else Consult(Oplayer);
        }
    }
    
}