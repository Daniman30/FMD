namespace FMD
{
    public class Game
    {
        Cards[,] Field;
        public void Playing()
        {
            while (true)
            {
                
                PrintMenu();

                ConsoleKey key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.N:
                        NewGame();
                        break;
                    case ConsoleKey.C:
                        Configuration();
                        break;
                    case ConsoleKey.Escape:
                        return;
                    default:
                        break;
                }
            }
        }
        public void NewGame()
        {
            (bool FinishTurn, bool ICanSummon, bool ICanDraw, bool Surrender) Test = (true, true, true, true);
           
            List<Cards> Underworlds = Shuffle(Cards.SelectDeck(Cards.Underworld()));
            List<Cards> Celestials = Shuffle(Cards.SelectDeck(Cards.Celestial()));
            
            List<Cards> CelestialsHand = new List<Cards>();
            List<Cards> UnderworldsHand = new List<Cards>();

            for (int i = 0; i < 4; i++) 
            {
                CelestialsHand.Add(Celestials[0]);
                Celestials.Remove(Celestials[0]);
            }
            
            for (int i = 0; i < 4; i++) 
            {
                UnderworldsHand.Add(Underworlds[0]);
                Underworlds.Remove(Underworlds[0]);
            }

            Field = new Cards[4, 3];
            List<Cards> CopyField = new List<Cards>();

            int turn = 1;
            Player Player1 = new Player(CelestialsHand, 2, Celestials);
            Player Player2 = new Player(UnderworldsHand, 1, Underworlds);
            bool ICanAttack = false;
            bool ICanSummon = true;
            bool ICanDraw = true;

            while (true)
            {
                
                //Variables globales de turno
                PrintMap(Field);
                if (turn % 2 != 0) //juega el player 1
                {   
                    Test = Play(Player1, Player2, turn, ICanAttack, ICanDraw, ICanSummon, CopyField);
                    if (Test.Item4) return;
                    ICanSummon = Test.Item2;
                    ICanDraw = Test.Item3;
                    if (Test.Item1) 
                    {
                        turn++;
                        ICanAttack = true;
                        ICanSummon = true;
                        ICanDraw = true;
                    }
                }
                else    //juega el player 2
                {
                    Test = Play(Player2, Player1, turn, ICanAttack, ICanDraw, ICanSummon, CopyField);
                    if (Test.Item4) return;
                    ICanSummon = Test.Item2;
                    ICanDraw = Test.Item3;
                    if (Test.Item1) 
                    {
                        turn++;
                        ICanAttack = true;
                        ICanSummon = true;
                        ICanDraw = true;
                    }
                }
            }
        }
        public void PrintMap(Cards[,] Field)
        {
            for (int i = 0; i < Field.GetLength(0); i++)
            {
                for (int j = 0; j < Field.GetLength(1); j++)
                {
                    if (Field[i, j] == null) System.Console.Write("| VACIO |");
                    else System.Console.Write("| {0} |", Field[i, j].Name);
                }
                System.Console.WriteLine();
            }
            return;
        }
        public void PrintOptions(int turn)
        {
            
            System.Console.WriteLine("Turno #{0}", turn);
            System.Console.WriteLine("Press I to invoke");
            System.Console.WriteLine("Press A to attack");
            System.Console.WriteLine("Press E to effect");
            System.Console.WriteLine("Press C to consult");
            System.Console.WriteLine("Press S to surrender");
            System.Console.WriteLine("Press Esc to finish turn");
        }
        public int Turn(int Turn, bool ICanAttack, bool ICanDraw, bool ICanSummon) 
        {
            return Turn++;
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
            System.Console.WriteLine("Para crear una nueva partida presione [N]");
            System.Console.WriteLine("Para configuracion presione [C]");
            System.Console.WriteLine("Para leer las instrucciones presione [I]");
            System.Console.WriteLine("Para abandonar el juego presiona [ESC]");
        }
        public bool Summon(Player Player, Cards[,] Field, List<Cards> Hand, bool ICanSummon, int pos)    //Invocar
        {
            if (!ICanSummon)
            {
                System.Console.WriteLine("You can't summon");
                Thread.Sleep(1000);
                return false;
            }
            System.Console.WriteLine("Elige la carta");
            ConsoleKey key = Console.ReadKey(true).Key;
            bool yes = false;
            
            switch (key)
            {
                case ConsoleKey.D0:
                    if (Hand.Count <= 0) return true;
                    if (Player.Manna - Hand[0].Cost < 0) return true;
                    if (Hand[0].Type == "Spell" || Hand[0].Type == "Course") yes = true;
                    new Actions().NormalSummon(Hand, Field, Player, Hand[0], pos);
                    if (yes) return true;
                    break;
                case ConsoleKey.D1:
                    if (Hand.Count <= 1) return true;
                    if (Player.Manna - Hand[1].Cost < 0) return true;
                    if (Hand[1].Type == "Spell" || Hand[1].Type == "Course") yes = true;
                    new Actions().NormalSummon(Hand, Field, Player, Hand[1], pos);
                    if (yes) return true;
                    break;
                case ConsoleKey.D2:
                    if (Hand.Count <= 2) return true;
                    if (Player.Manna - Hand[2].Cost < 0) return true;
                    if (Hand[2].Type == "Spell" || Hand[2].Type == "Course") yes = true;
                    new Actions().NormalSummon(Hand, Field, Player, Hand[2], pos);
                    if (yes) return true;
                    break;
                case ConsoleKey.D3:
                    if (Hand.Count <= 3) return true;
                    if (Player.Manna - Hand[3].Cost < 0) return true;
                    if (Hand[3].Type == "Spell" || Hand[3].Type == "Course") yes = true;
                    new Actions().NormalSummon(Hand, Field, Player, Hand[3], pos);
                    if (yes) return true;
                    break;
                case ConsoleKey.D4:
                    if (Hand.Count <= 4) return true;
                    if (Player.Manna - Hand[4].Cost < 0) return true;
                    if (Hand[4].Type == "Spell" || Hand[4].Type == "Course") yes = true;
                    new Actions().NormalSummon(Hand, Field, Player, Hand[4], pos);
                    if (yes) return true;
                    break;
                case ConsoleKey.D5:
                    if (Hand.Count <= 5) return true;
                    if (Player.Manna - Hand[5].Cost < 0) return true;
                    if (Hand[5].Type == "Spell" || Hand[5].Type == "Course") yes = true;
                    new Actions().NormalSummon(Hand, Field, Player, Hand[5], pos);
                    if (yes) return true;
                    break;
                case ConsoleKey.Escape:
                    return true;
                default: 
                    break;
            }
            return false;
        }
        public void Attacker(Cards[,] Field, Player Oplayer, bool ICanAttack, int pos, int pos1)
        {
            System.Console.WriteLine("Elige el atacante");
            ConsoleKey key = Console.ReadKey(true).Key;
            var mycard = SelectCard(key, pos);
            Attacked(Field, Oplayer,mycard, ICanAttack,pos1); 
        }
        public void Attacked(Cards[,] Field, Player Oplayer, Cards Attacker, bool ICanAttack,int pos)
        {
            if (!ICanAttack) return;
            System.Console.WriteLine("Elige a quien atacas");
            ConsoleKey key = Console.ReadKey(true).Key;
                        
            if(key == ConsoleKey.D)
            {
                if (Field[1, 0] == null && Field[1, 1] == null && Field[1, 2] == null) 
                {
                    Oplayer.Life--;
                    ICanAttack = false;
                }
            }
            else 
            {
                var opponentCard = SelectCard(key, pos);
                new Actions().Attack(Attacker, opponentCard);  
                ICanAttack = false;       
            }
        }
        public void Configuration()
        {
            int dif = 0;

            while (true)
            {
                
                System.Console.WriteLine("Fondo [F]");
                System.Console.WriteLine("Letras [L]");
                System.Console.WriteLine("Dificultad CPU [D]");
                System.Console.WriteLine("Volver atras [ESC]");


                ConsoleKey key = Console.ReadKey(true).Key;
                
                switch (key)
                {
                    case ConsoleKey.F:
                        Background();
                        break;
                    case ConsoleKey.L:
                        Letters();
                        break;
                    case ConsoleKey.D:
                        dif = Difficulty(dif);
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
                
                System.Console.WriteLine("No se puede cambiar el color de las letras si el fondo no es negro");
                System.Console.WriteLine("Presiona cualquier tecla para abandonar");
                Console.ReadLine();
            }

            while (true)
            {
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
        public List<Cards> Shuffle(List<Cards> Deck)
        {
            List<Cards> FakeDeck = new List<Cards>();
            for (int i = 0; i < Deck.Count; i++)
            {
                FakeDeck.Add(Deck[i]);
            }
            bool[] Mask = new bool[Deck.Count];
            Random r = new Random();
            int n = 0;

            for (int i = 0; i < Deck.Count; i++)
            {
                n = r.Next(0, Deck.Count);
                if (Mask[n]) i--;
                else
                {
                    FakeDeck[n] = Deck[i];
                    Mask[n] = true;
                }
            }
            return FakeDeck;
        }
        public Cards SelectCard( ConsoleKey key, int pos)
        {  
            switch (key)
            {
                case ConsoleKey.D0:
                    if (Field[pos, 0] == null) break;
                    return Field[pos,0];
                    
                case ConsoleKey.D1:
                    if (Field[pos, 1] == null) break;
                    return Field[pos,1];
                   
                case ConsoleKey.D2:
                    if (Field[pos, 2] == null) break;
                    return Field[pos, 2];
                default: 
                    break;
            }
            System.Console.WriteLine("Select a card");
            SelectCard(key, pos);
            return Field[pos, 0];
        }
        public void PrintHand(List<Cards> Hand)
        {
            int i=0;
            foreach (var card in Hand)
            {
                System.Console.WriteLine(@"_____________________________");
                System.Console.WriteLine(@"|Carta " + i + ": "  + card.Name);
                System.Console.WriteLine(@"|Attack: " + card.Attack);
                System.Console.WriteLine(@"|Manna: " + card.Mana);
                System.Console.WriteLine(@"|Cost: " + card.Cost);
                System.Console.WriteLine(@"|Effects: " + card.Effects.description);
                System.Console.WriteLine(@"_____________________________");
                i++;
            }
        }
        public void Consult(Cards[,] Field)
        {
            PrintMap(Field);
            System.Console.WriteLine();
            System.Console.WriteLine("¿Que carta quieres consultar?");
            System.Console.WriteLine("| 1 | 2 | 3 |");
            System.Console.WriteLine("| Q | W | E |");
            System.Console.WriteLine("| A | S | D |");
            System.Console.WriteLine("| Z | X | C |");

            ConsoleKey key = Console.ReadKey(true).Key;
            switch (key)
            {
                case ConsoleKey.D1:
                    if(Field[0, 0] == null) 
                    {
                        System.Console.WriteLine("No hay carta en ese espacio");
                        break;
                    }
                    PrintCardInfo(Field[0, 0]);
                    break;
                case ConsoleKey.D2:
                    if(Field[0, 1] == null) 
                    {
                        System.Console.WriteLine("No hay carta en ese espacio");
                        break;
                    }
                    PrintCardInfo(Field[0, 1]);
                    break;
                case ConsoleKey.D3:
                    if(Field[0, 2] == null) 
                    {
                        System.Console.WriteLine("No hay carta en ese espacio");
                        break;
                    }
                    PrintCardInfo(Field[0, 2]);
                    break;
                case ConsoleKey.Q:
                    if(Field[1, 0] == null) 
                    {
                        System.Console.WriteLine("No hay carta en ese espacio");
                        break;
                    }
                    PrintCardInfo(Field[1, 0]);
                    break;
                case ConsoleKey.W:
                    if(Field[1, 1] == null) 
                    {
                        System.Console.WriteLine("No hay carta en ese espacio");
                        break;
                    }
                    PrintCardInfo(Field[1, 1]);
                    break;
                case ConsoleKey.E:
                    if(Field[1, 2] == null) 
                    {
                        System.Console.WriteLine("No hay carta en ese espacio");
                        break;
                    }
                    PrintCardInfo(Field[1, 2]);
                    break;
                case ConsoleKey.A:
                    if(Field[2, 0] == null) 
                    {
                        System.Console.WriteLine("No hay carta en ese espacio");
                        break;
                    }
                    PrintCardInfo(Field[2, 0]);
                    break;
                case ConsoleKey.S:
                    if(Field[2, 1] == null) 
                    {
                        System.Console.WriteLine("No hay carta en ese espacio");
                        break;
                    }
                    PrintCardInfo(Field[2, 1]);
                    break;
                case ConsoleKey.D:
                    if(Field[2, 2] == null) 
                    {
                        System.Console.WriteLine("No hay carta en ese espacio");
                        break;
                    }
                    PrintCardInfo(Field[2, 2]);
                    break;
                case ConsoleKey.Z:
                    if(Field[3, 0] == null) 
                    {
                        System.Console.WriteLine("No hay carta en ese espacio");
                        break;
                    }
                    PrintCardInfo(Field[3, 0]);
                    break;
                case ConsoleKey.X:
                    if(Field[3, 1] == null) 
                    {
                        System.Console.WriteLine("No hay carta en ese espacio");
                        break;
                    }
                    PrintCardInfo(Field[3, 1]);
                    break;
                case ConsoleKey.C:
                    if(Field[3, 2] == null) 
                    {
                        System.Console.WriteLine("No hay carta en ese espacio");
                        break;
                    }
                    PrintCardInfo(Field[3, 2]);
                    break;
                case ConsoleKey.Escape:
                    break;
                default:
                    break;
            }
            System.Console.WriteLine("Press ESC to left consult");
            ConsoleKey fake = Console.ReadKey(true).Key;
            if (fake == ConsoleKey.Escape) return;
            else Consult(Field);
        }
        public void PrintCardInfo(Cards card)
        {
            System.Console.WriteLine("Name: {0}", card.Name);
            System.Console.WriteLine("Attack: {0}", card.Attack);
            System.Console.WriteLine("Mana: {0}", card.Mana);
            System.Console.WriteLine("Effect: {0}", card.Effects.description);
            System.Console.WriteLine("Cost: {0}", card.Cost);
            System.Console.WriteLine("Legion: {0}", card.Legion);
        }
        public int ParseInt(int index)
        {
            while (true)
            {
                var aux = Console.ReadLine();
                try
                {
                    index = int.Parse(aux);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Formato no válido");
                    continue;
                }
                break;
            }
            return index;
        }
        public (bool NextTurn, bool ICanSummon, bool ICanDraw, bool Surrender) Play(Player Player, Player Oplayer, int turn, bool ICanAttack, bool ICanDraw, bool ICanSummon, List<Cards> CopyField)

        {
            if (ICanDraw) 
            {
                new Actions().DrawperTurn(Player.Hand, Player.Deck);
                ICanDraw = false;
            }
            PrintHand(Player.Hand);
            System.Console.WriteLine("Life: " + Player.Life);
            System.Console.WriteLine("Manna: " + Player.Manna);
            PrintOptions(turn);
            ConsoleKey key = Console.ReadKey(true).Key;
                    
            switch (key)
            {
                case ConsoleKey.S:
                    if (Surrender()) return (true, true, true, true);
                    break;
                case ConsoleKey.I:
                    ICanSummon = Summon(Player, Field, Player.Hand, ICanSummon,Player.Index);
                    CopyField = new Actions().DestroyCard(Player, Oplayer, CopyField, Field);
                    break;
                case ConsoleKey.A:
                    Attacker(Field, Oplayer, ICanAttack,Player.Index, Oplayer.Index);
                    CopyField = new Actions().DestroyCard(Player, Oplayer, CopyField, Field);
                    break;
                case ConsoleKey.C:
                    Consult(Field);
                    break;
                case ConsoleKey.Escape:
                    return (true, ICanSummon, ICanDraw, false);
                case ConsoleKey.E: //Activar efecto
                    System.Console.WriteLine("Elige la carta de la que quieras activar el efecto");
                    key =  Console.ReadKey(true).Key;
                    var myCard = SelectCard(key, Player.Index);
                    var type = Player.Hand.First().Effects.GetType();
                    if(type != null)
                    {
                        switch (type.Name)
                        {
                            case "IncreaseAtk":
                                System.Console.WriteLine("Elige la carta para aplicar tu efecto");
                                key =  Console.ReadKey(true).Key;
                                var myCard1 = SelectCard(key, Player.Index);
                                myCard.Effects.Action(myCard1);
                                break;
                            case "DecreaseAtk":
                                System.Console.WriteLine("Elige la carta para aplicar tu efecto");
                                key =  Console.ReadKey(true).Key;
                                var oponentCard = SelectCard(key, Oplayer.Index);
                                myCard.Effects.Action(oponentCard);
                                CopyField = new Actions().DestroyCard(Player, Oplayer, CopyField, Field);
                                break;
                            case "DecreaseCost":
                                System.Console.WriteLine("Elige la carta para aplicar tu efecto");
                                key =  Console.ReadKey(true).Key;
                                oponentCard = SelectCard(key, Oplayer.Index);
                                myCard.Effects.Action(oponentCard);
                                break;
                            case "MaidControl":
                                System.Console.WriteLine("Elige la carta para aplicar tu efecto");
                                key =  Console.ReadKey(true).Key;
                                oponentCard = SelectCard(key, Oplayer.Index);
                                myCard.Effects.Action(oponentCard);
                                break;
                            case "DestroyMonsters":
                                System.Console.WriteLine("Elige la carta para aplicar tu efecto");
                                key =  Console.ReadKey(true).Key;
                                oponentCard = SelectCard(key, Oplayer.Index);
                                myCard.Effects.Action(oponentCard);
                                CopyField = new Actions().DestroyCard(Player, Oplayer, CopyField, Field);
                                break;
                            case "DecreaseMana":
                                System.Console.WriteLine("Elige la carta para aplicar tu efecto");
                                key =  Console.ReadKey(true).Key;
                                oponentCard = SelectCard(key, Oplayer.Index);
                                myCard.Effects.Action(oponentCard);
                                break;
                            case "IncreaseMana":
                                System.Console.WriteLine("Elige la carta para aplicar tu efecto");
                                key =  Console.ReadKey(true).Key;
                                myCard1 = SelectCard(key, Player.Index);
                                myCard.Effects.Action(myCard1);
                                break;
                            case "IncreaseCost":
                                System.Console.WriteLine("Elige la carta para aplicar tu efecto");
                                key =  Console.ReadKey(true).Key;
                                myCard1= SelectCard(key, 1);
                                myCard.Effects.Action(myCard1);
                                break;
                            case "DrawCards":
                                myCard.Effects.Action(Player.Hand,Player);
                                break;
                            case "SpecialSummon":
                                System.Console.WriteLine("Elige la carta para aplicar tu efecto");
                                key =  Console.ReadKey(true).Key;
                                myCard.Effects.Action(SelectCard(key,Player.Index),Field);
                                break;
                            case "MultiAtk":
                                System.Console.WriteLine("Elige la carta para aplicar tu efecto");
                                key =  Console.ReadKey(true).Key;
                                var monster1 = SelectCard(key,Oplayer.Index);
                                System.Console.WriteLine("Elige la carta para aplicar tu efecto");
                                key =  Console.ReadKey(true).Key;
                                var monster2 = SelectCard(key,Oplayer.Index);
                                myCard.Effects.Action(myCard, monster1, monster2);
                                CopyField = new Actions().DestroyCard(Player, Oplayer, CopyField, Field);
                                break;
                            case"DestroyedHand":
                                myCard.Effects.Action(Oplayer.Hand,Oplayer.Deck);
                                break;
                            case "Decrease":
                                System.Console.WriteLine("Elige la carta para aplicar tu efecto");
                                key =  Console.ReadKey(true).Key;
                                oponentCard = SelectCard(key, Oplayer.Index);
                                myCard.Effects.Action(oponentCard,100);
                                CopyField = new Actions().DestroyCard(Player, Oplayer, CopyField, Field);
                                break;
                        }
                    }
                    break;
            }
            return (false, ICanSummon, ICanDraw, false);
                //se acaba el turno

        }
        public bool IsDead(Player player)
        {
            if (player.Life <= 0) return true;
            return false;
        }
        public void GameOver (int turn, bool IsDead)
        {
            if (IsDead)
            {
                if (turn % 2 == 0) System.Console.WriteLine("GAME OVER. PLAYER 2 WINS");
                else System.Console.WriteLine("GAME OVER. PLAYER 1 WINS");
            }
            return;
        }
        public bool Surrender()
        {
            System.Console.WriteLine("Press Y for YES, N for NO");
            ConsoleKey key = Console.ReadKey(true).Key;
            switch (key)
            {
                case ConsoleKey.Y:
                    return true;
                case ConsoleKey.N:
                    return false;
                default:
                    return false;
            }
            
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
                default:
                    break;
            }
            return 0;
        }
    }
}









                        
                    
