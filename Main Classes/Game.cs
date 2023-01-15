namespace FMD
{
    public class Game
    {
        public static Cards[,] Field = new Cards[4, 3];
        public static List<Cards> GenericCards = Cards.Create();
        public static List<Cards> CopyCards = new List<Cards>();
        public static List<Cards> Underworlds = Cards.Underworld();
        public static List<Cards> Celestials = Cards.Celestial();
        public static List<Cards> CelestialsHand = new List<Cards>();
        public static List<Cards> UnderworldsHand = new List<Cards>();
        public static Player Player1 = new Player(CelestialsHand, 2, Celestials, "");
        public static Player Player2 = new Player(UnderworldsHand, 1, Underworlds, "");
        public static List<Effects> Effectos = new List<Effects>();

        public static int turn;
        public static int dif = 2;
        public void Playing()
        {
            while (true)
            {
                
                new Print().PrintMenu();

                ConsoleKey key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.N:
                        NewGame();
                        break;
                    case ConsoleKey.C:
                        new Auxiliar().Configuration();
                        break;
                    case ConsoleKey.I:
                        new Auxiliar().Instructions();
                        break;
                    case ConsoleKey.A:
                        NewEffect(Effectos);
                        break;
                    case ConsoleKey.W:
                        NewCard(GenericCards);
                        break;
                    case ConsoleKey.Escape:
                        return;
                    default:
                        break;
                }
            }
        }
        public void NewGamePvP()
        {
            //Iniciar partida player vs player.
            System.Console.WriteLine("Write your name Player 1");
            string? Player1name = System.Console.ReadLine();
            Player1.NamePlayer = Player1name;
            System.Console.WriteLine("Write your name Player 2");
            string? Player2name = System.Console.ReadLine();
            Player2.NamePlayer = Player2name;
            (bool FinishTurn, bool ICanSummon, bool ICanDraw, bool Surrender) Test = (true, true, true, true);

            SelectLegion(Player1, Player2, (CelestialsHand, UnderworldsHand, Celestials, Underworlds));
            
            //Selecciona las primeras 4 cartas de la mano de cada jugador
            for (int i = 0; i < 4; i++) 
            {
                Player1.Hand.Add(Player1.Deck[0]);
                Player1.Deck.Remove(Player1.Deck[0]);
            }
            for (int i = 0; i < 4; i++) 
            {
                Player2.Hand.Add(Player2.Deck[0]);
                Player2.Deck.Remove(Player2.Deck[0]);
            }

            Field = new Cards[4, 3];
            List<Cards> CopyField = new List<Cards>();

            turn = 1;
            bool ICanSummon = true;
            bool ICanDraw = true;
            bool[,] MaskAtk = new bool[4, 3];
            bool[,] MaskEffect = new bool[4, 3];

            while (true)
            {
                //Variables globales de turno
                //PrintMap(Field);
                if (turn % 2 != 0) //juega el player 1
                {   
                    Test = Play(Player1, Player2, ICanDraw, ICanSummon, MaskAtk, MaskEffect);
                    if (Test.Item4) return;
                    ICanSummon = Test.Item2;
                    ICanDraw = Test.Item3;
                    if (Test.Item1) 
                    {
                        turn++;
                        ICanSummon = true;
                        ICanDraw = true;
                        Reset(MaskAtk);
                    }
                }
                else    //juega el player 2
                {
                    Test = Play(Player2, Player1, ICanDraw, ICanSummon, MaskAtk, MaskEffect);
                    if (Test.Item4) return;
                    ICanSummon = Test.Item2;
                    ICanDraw = Test.Item3;
                    if (Test.Item1) 
                    {
                        turn++;
                        ICanSummon = true;
                        ICanDraw = true;
                        Reset(MaskAtk);
                    }
                }
            }
        }
        public void NewGamePvCPU()
        {
            //Iniciar partida player vs IA
            List<Cards> CelestialsHand = new List<Cards>();
            List<Cards> UnderworldsHand = new List<Cards>();

            System.Console.WriteLine("Write your name Player 1");
            string? Player1name = System.Console.ReadLine();
            (bool FinishTurn, bool ICanSummon, bool ICanDraw, bool Surrender) Test = (true, true, true, true);
            Player Player1 = new Player(CelestialsHand, 2, Celestials, Player1name);
            Player Player2 = new Player(UnderworldsHand, 1, Underworlds, "CPU");
            SelectLegion(Player1, Player2, (CelestialsHand, UnderworldsHand, Celestials, Underworlds));
            for (int i = 0; i < 4; i++) 
            {
                Player1.Hand.Add(Player1.Deck[0]);
                Player1.Deck.Remove(Player1.Deck[0]);
            }
            
            for (int i = 0; i < 4; i++) 
            {
                Player2.Hand.Add(Player2.Deck[0]);
                Player2.Deck.Remove(Player2.Deck[0]);
            }

            Field = new Cards[4, 3];
            List<Cards> CopyField = new List<Cards>();

            turn = 1;
            bool ICanSummon = true;
            bool ICanDraw = true;
            bool[,] MaskAtk = new bool[4, 3];
            bool[,] MaskEffect = new bool[4, 3];

            while (true)
            {
                bool finishTurn;
                if (turn % 2 != 0) //juega el player 1
                {   
                    Test = Play(Player1, Player2, ICanDraw, ICanSummon, MaskAtk, MaskEffect);
                    if (Test.Item4) return;
                    ICanSummon = Test.Item2;
                    ICanDraw = Test.Item3;
                    if (Test.Item1) 
                    {
                        turn++;
                        ICanSummon = true;
                        ICanDraw = true;
                        Reset(MaskAtk);
                    }
                }
                else    //juega la CPU
                {
                    Player2.Manna ++;
                    if(ICanDraw) new Actions().DrawperTurn(Player2.Hand, Player2.Deck);
                    ICanDraw = false;
                    finishTurn = new IA().PlayIA(Player2, Player1, ICanSummon, MaskAtk, MaskEffect);
                    if (finishTurn)
                    {
                        turn++;
                        ICanSummon = true;
                        ICanDraw = true;
                        Reset(MaskAtk);
                    }
                }
                if(GameOver(Player1, Player2)) return;
            }
        }
        public void NewGame()
        {
            Console.Clear();
            System.Console.WriteLine("Select play mode");
            System.Console.WriteLine("Player vs Player [1]");
            System.Console.WriteLine("Player vs CPU [2]");
            System.Console.WriteLine("Press any key to back");
            //System.Console.WriteLine("CPU vs CPU [3]");
            ConsoleKey key = Console.ReadKey(true).Key;
            switch (key)
            {
                case ConsoleKey.D1:
                    NewGamePvP();
                    return;
                case ConsoleKey.D2:
                    NewGamePvCPU();
                    return;
                // case ConsoleKey.D3:
                //     NewGameCPUvsCPU;
                //     break;
                default:
                    return;
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
        
        public bool Summon(Player Player, Player Oplayer, bool ICanSummon, bool[,] MaskAtk, bool[,] MaskEffect)    //Invocar
        {
            System.Console.WriteLine("Select a card");
            ConsoleKey key = Console.ReadKey(true).Key;
            
            switch (key)
            {
                case ConsoleKey.D0:
                    return miniSummon(Player, Oplayer, 0, ICanSummon, MaskAtk, MaskEffect);
                case ConsoleKey.D1:
                    return miniSummon(Player, Oplayer, 1, ICanSummon, MaskAtk, MaskEffect);
                case ConsoleKey.D2:
                    return miniSummon(Player, Oplayer, 2, ICanSummon, MaskAtk, MaskEffect);
                case ConsoleKey.D3:
                    return miniSummon(Player, Oplayer,  3, ICanSummon, MaskAtk, MaskEffect);
                case ConsoleKey.D4:
                    return miniSummon(Player, Oplayer,  4, ICanSummon, MaskAtk, MaskEffect);
                case ConsoleKey.D5:
                    return miniSummon(Player, Oplayer,  5, ICanSummon, MaskAtk, MaskEffect);
                case ConsoleKey.D6:
                    return miniSummon(Player, Oplayer,  6, ICanSummon, MaskAtk, MaskEffect);
                case ConsoleKey.D7:
                    return miniSummon(Player, Oplayer,  7, ICanSummon, MaskAtk, MaskEffect);
                case ConsoleKey.D8:
                    return miniSummon(Player, Oplayer,  8, ICanSummon, MaskAtk, MaskEffect);
                case ConsoleKey.D9:
                    return miniSummon(Player,Oplayer,  9, ICanSummon, MaskAtk, MaskEffect);
                case ConsoleKey.Escape:
                    return true;
                default: 
                    break;
            }
            return false;
        }
        public bool miniSummon(Player Player, Player Oplayer, int number, bool ICanSummon, bool[,] MaskAtk, bool[,] MaskEffect)
        {
            bool yes = false;
            if (Player.Hand.Count <= number) 
            {
                System.Console.WriteLine("You do not have so much cards on your hand");    
                Thread.Sleep(1000);
                return ICanSummon;
            }
            if (Player.Manna - Player.Hand[number].Cost < 0) 
            {
                System.Console.WriteLine("You do not have manna enough");   
                Thread.Sleep(1000);
                return ICanSummon;
            }
            if (Player.Hand[number].Type == "Spell" || Player.Hand[number].Type == "Course") yes = true;
            else if (!ICanSummon)
            {
                System.Console.WriteLine("You have invoked a card already");
                Thread.Sleep(1000);
                return ICanSummon;
            }
            if (!yes)
            {
                for (int i = 0; i < 3; i++) 
                {
                    if (Field[Player.Index, i] == null) 
                    {
                        MaskAtk[Player.Index, i] = false;
                        MaskEffect[Player.Index, i] = false;
                        break;
                    }
                }
            }   
            new Actions().NormalSummon(Player, Oplayer,Player.Hand[number], CopyCards);
            
            if (yes) return ICanSummon;
            return false;
        }
       
     
        
        public void Attacker(Player Oplayer, Player player, bool[,] MaskAtk)
        {   
            if (turn == 1)
            {
                System.Console.WriteLine("Is first turn you can not attack");
                Thread.Sleep(1000);
                return;
            }
            System.Console.WriteLine("Select the attacker");
            ConsoleKey key = Console.ReadKey(true).Key;
            if (key == ConsoleKey.Escape) return;
            if (Field[player.Index, new Select().SelectNumber(key)] == null) 
            {
                System.Console.WriteLine("This position is empty"); 
                Thread.Sleep(1000);
                return;
            }
            var mycard = new Select().SelectCard(key, player.Index);
            Attacked(Oplayer, player, mycard, MaskAtk, new Select().SelectNumber(key)); 
        }
        public void Attacked(Player Oplayer, Player player, Cards Attacker, bool[,] MaskAtk, int posKey)
        {
            if (MaskAtk[player.Index, posKey]) 
            {
                System.Console.WriteLine("This card has been used to attack already");
                Thread.Sleep(1000);
                return;
            }
            System.Console.WriteLine("Select who you want to attack");
            ConsoleKey key = Console.ReadKey(true).Key;
            
            if (key == ConsoleKey.Escape) return;
            else if(key == ConsoleKey.D)
            {
                if (Field[Oplayer.Index, 0] == null && Field[Oplayer.Index, 1] == null && Field[Oplayer.Index, 2] == null) 
                {
                    Oplayer.Life--;
                    MaskAtk[player.Index, posKey] = true;
                    return;
                }
                else 
                {
                    System.Console.WriteLine("Your enemy stills having monsters alive");
                    Thread.Sleep(1000);
                    return;
                }
            }
            else if (Field[Oplayer.Index, new Select().SelectNumber(key)] == null) 
            {
                System.Console.WriteLine("This position is empty");
                Thread.Sleep(1000);
                return;
            }
            else
            {
                MaskAtk[player.Index, posKey] = true;
                new Actions().Attack(Attacker, new Select().SelectCard(key, Oplayer.Index), Oplayer, player, CopyCards);
            }
        }
        
       
       
        public int ParseInt(int index)
        {
            while (true)
            {
                string aux = "" + Console.ReadLine();
                try
                {
                    index = int.Parse(aux);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Ivalid Format");
                    continue;
                }
                break;
            }
            return index;
        }
        public (bool, bool, bool, bool) Play (Player Player, Player Oplayer, bool ICanDraw, bool ICanSummon, bool[,]MaskAtk, bool[,]MaskEffect) 
        {
            if (ICanDraw) 
            {
                Player.Manna += 1;
                new Actions().DrawperTurn(Player.Hand, Player.Deck);
                ICanDraw = false;
            }
            new Print().PrintHand(Player.Hand);
            new Print().PrintMap();
            System.Console.WriteLine("Life: " + Player.Life);
            System.Console.WriteLine("Manna: " + Player.Manna);
            new Print().PrintOptions(Player);
            ConsoleKey key = Console.ReadKey(true).Key;
                    
            switch (key)
            {
                case ConsoleKey.I:
                    ICanSummon = Summon(Player, Oplayer, ICanSummon, MaskAtk, MaskEffect);
                    break;
                case ConsoleKey.A:
                    Attacker(Oplayer, Player, MaskAtk);
                    if (GameOver(Player, Oplayer)) return (true, true, true, true);
                    break;
                case ConsoleKey.E: //Activar efecto
                    System.Console.WriteLine("Select a card to use it's effect");
                    key =  Console.ReadKey(true).Key;  
                    Cards myCard = new Select().SelectCard(key, Player.Index);
                    if (myCard == null) new Print().PrintOptions(Player);
                    else if (!MaskEffect[Player.Index, new Select().SelectNumber(key)])
                    {
                        if (Effects(Player, Oplayer, myCard, MaskEffect, MaskAtk)) MaskEffect[Player.Index, new Select().SelectNumber(key)] = true;
                    }
                    else 
                    {
                        System.Console.WriteLine("You have used this card's effect already");
                        Thread.Sleep(1000);
                    }
                    break;
                case ConsoleKey.X:
                    System.Console.WriteLine("Select a card to sacrifice it");
                    key = Console.ReadKey(true).Key;
                    if (key == ConsoleKey.Escape) break;
                    var Scard = new Select().SelectCard(key,Player.Index);
                    if (Scard == null) break;
                    new Actions().Sacrfice(Scard, Player);
                    new Actions().DestroyCard(Scard, Player, CopyCards);
                    break;
                case ConsoleKey.C:
                    new Print().Consult(Oplayer);
                    break;
                case ConsoleKey.S:
                    if (Surrender()) return (true, true, true, true);
                    break;
                case ConsoleKey.Escape:
                    EndTurnCheck(Player);
                    return (true, ICanSummon, ICanDraw, false);
            }
            return (false, ICanSummon, ICanDraw, false);
                //se acaba el turno

        }
        public bool GameOver (Player player, Player Oplayer)
        {
            if (Oplayer.Life <= 0)
            {
                System.Console.WriteLine("Player " + player.NamePlayer + " Win");
                System.Console.WriteLine("Game Over");
                System.Console.WriteLine("Press any Key, for back to menu");
                System.Console.ReadKey();
                return true;
            }
            else if (player.Life <= 0)
            {
                System.Console.WriteLine("Player " + Oplayer.NamePlayer + " Win");
                System.Console.WriteLine("Game Over");
                System.Console.WriteLine("Press any Key, for back to menu");
                Console.ReadKey();
                return true;
            }
            return false;

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
        
        public Cards CopyCard(Cards card)
        {
            Cards NewCard = new Cards(card.Name, card.Effects, card.Type, card.Legion, card.Attack, card.Cost, card.Energy);
            return NewCard;
        }
        public bool Effects (Player Player, Player Oplayer, Cards myCard, bool[,] MaskEffect, bool[,] MaskAtk)
        {
            //Segun la carta que se escoja se lee el efecto que tengan y segun el efecto se trabaja de distinta manera
            //En los tipo A se elige un monstruo rival, en los tipo B se elige un monstruo propio, en el tipo C no se escoge nada mas,
            //en el tipo D se elige una carta de la mano y en el tipo E se eligen dos monstruos rivales.
            //En cualquiera de estas si se escoge mal se da la opcion de volver a elegir
            ConsoleKey key;
            var type = myCard.Effects.GetType();
            if(type != null)
            {
                switch (type.Name)
                {
                    case "IncreaseAtk":
                        System.Console.WriteLine("Select a card to apply your effect");
                        key =  Console.ReadKey(true).Key;
                        var myCard1 = new Select().SelectCard(key, Player.Index);
                        if (myCard1 == null)
                        {
                            System.Console.WriteLine("Not valid card");
                            Thread.Sleep(1000);
                            return false;
                        }
                        else myCard.Effects.Action(myCard1);
                        break;
                    case "DecreaseAtk":
                        System.Console.WriteLine("Select a card to apply your effect");
                        key =  Console.ReadKey(true).Key;
                        var oponentCard = new Select().SelectCard(key, Oplayer.Index);
                        if (oponentCard == null)
                        {
                            System.Console.WriteLine("Not valid card");
                            Thread.Sleep(1000);
                            return false;
                        }
                        else
                        {
                            myCard.Effects.Action(oponentCard);
                            new Actions().DestroyCard(oponentCard, Oplayer, CopyCards);
                        }    
                        break;
                    case "IncreaseManna":
                        myCard.Effects.Action(Player);
                        break;
                    case "DecreaseManna":
                        myCard.Effects.Action(Oplayer);
                        break;
                    case "IncreaseCost":
                        System.Console.WriteLine("Select a card to apply your effect");
                        key =  Console.ReadKey(true).Key;
                        myCard1 = new Select().SelectCard(key, Player.Index);
                        if (myCard1 == null) 
                        {
                            System.Console.WriteLine("Not valid card");
                            Thread.Sleep(1000);
                            return false;
                        }
                        else myCard.Effects.Action(myCard1);
                        break;
                    case "DecreaseCost":
                        System.Console.WriteLine("Select a card to apply your effect");
                        key =  Console.ReadKey(true).Key;
                        oponentCard = new Select().SelectCard(key, Oplayer.Index);
                        if (oponentCard == null) 
                        {
                            System.Console.WriteLine("Not valid card");
                            Thread.Sleep(1000);
                            return false;
                        }
                        else
                        myCard.Effects.Action(oponentCard);
                        break;
                    case "DecreaseAtkPerTurn":
                        System.Console.WriteLine("Select a card to apply your effect");
                        key =  Console.ReadKey(true).Key;
                        oponentCard = new Select().SelectCard(key, Oplayer.Index);
                        if (oponentCard == null) 
                        {
                            System.Console.WriteLine("Not valid card");
                            Thread.Sleep(1000);
                            return false;
                        }
                        else
                        {
                            myCard.Effects.Action(oponentCard,oponentCard.Attack/4, (0,0), Player);
                            new Actions().DestroyCard(oponentCard, Oplayer, CopyCards);
                        }
                        break;
                    case"DestroyedHand":
                        myCard.Effects.Action(Oplayer);
                        break;
                    case "DestroyMonsters":
                        System.Console.WriteLine("Select a card to apply your effect");
                        key =  Console.ReadKey(true).Key;
                        oponentCard = new Select().SelectCard(key, Oplayer.Index);
                        if (oponentCard == null) 
                        {
                            System.Console.WriteLine("Not valid card");
                            Thread.Sleep(1000);
                            return false;
                        }
                        else
                        {
                            myCard.Effects.Action(oponentCard);
                            new Actions().DestroyCard(oponentCard, Oplayer, CopyCards);
                        }
                        break;
                    case "MultiAtk":
                        System.Console.WriteLine("Select a card to apply your effect");
                        key =  Console.ReadKey(true).Key;
                        var monster1 = new Select().SelectCard(key,Oplayer.Index);
                        if (monster1 == null)
                        {
                            System.Console.WriteLine("Not valid card");
                            Thread.Sleep(1000);
                            return false;
                        }
                        System.Console.WriteLine("Select a card to apply your effect");
                        key =  Console.ReadKey(true).Key;
                        var monster2 = new Select().SelectCard(key,Oplayer.Index);
                        if (monster2 == null) 
                        {
                            System.Console.WriteLine("Only can attack one card");
                            Thread.Sleep(1000);
                            new Actions().Attack(myCard, monster1, Oplayer, Player, Game.CopyCards);
                        }
                        else myCard.Effects.Action(myCard, monster1, monster2, Player, Oplayer);
                        break;
                    case "MaidControl":
                        System.Console.WriteLine("Select a card to apply your effect");
                        key =  Console.ReadKey(true).Key;
                        oponentCard = new Select().SelectCard(key, Oplayer.Index);
                        if (oponentCard == null || oponentCard.Attack == 0) 
                        {
                            System.Console.WriteLine("Not valid card");
                            Thread.Sleep(1000);
                            return false;
                        }
                        else
                        {
                            var pos = (Oplayer.Index, new Select().SelectNumber(key));
                            for (int i = 0; i < 3; i++)
                            {
                                if (Field[Player.Index, i] != null) 
                                {
                                    MaskAtk[Player.Index, i] = false;
                                    MaskEffect[Player.Index, i] = MaskEffect[Oplayer.Index, new Select().SelectNumber(key)];
                                }
                            }
                            myCard.Effects.Action(oponentCard, 0, pos, Player);
                        }
                        break;
                    case "SpecialSummon":
                        System.Console.WriteLine("Select a card to apply your effect");
                        key =  Console.ReadKey(true).Key;
                        int aux = new Select().SelectNumber(key);
                        if (aux >= Player.Hand.Count)
                        {
                            System.Console.WriteLine("Not valid card");
                            Thread.Sleep(1000);
                            return false;
                        }
                        myCard.Effects.Action(Player.Hand[new Select().SelectNumber(key)], Player);
                        break;
                    case "DrawCards":
                        myCard.Effects.Action(Player);
                        break;
                    case "DestroyAllMonster":
                        myCard.Effects.Action(Oplayer);
                        break;
                    case "Effects":
                        EffectActivate.IcanActive(myCard.Effects,Player,Oplayer);
                        break;
                }
            }
            return true;
        }
        public bool[,] Reset(bool[,] Mask, bool aux = false)
        {
            for (int i = 0; i < Mask.GetLength(0); i++)
            {
                for (int j = 0; j < Mask.GetLength(1); j++)
                {
                    Mask[i, j] = aux;
                }
            }
            return Mask;
        }
        public void EndTurnCheck(Player player)
        {
            if(player.Manna>6){player.Manna=5;}
            if (player.Hand.Count>6)
            {
                System.Console.WriteLine("You have more than six cards in your hand, discard");
                Thread.Sleep(1000);
                while (player.Hand.Count>6)
                {
                    new Print().PrintHand(player.Hand);
                    ConsoleKey key = Console.ReadKey(true).Key;
                    player.Deck.Add(player.Hand[new Select().SelectNumber(key)]);
                    player.Hand.Remove(player.Hand[new Select().SelectNumber(key)]);
                }
            }
        }
        public void SelectLegion(Player player1, Player player2, (List<Cards>, List<Cards>, List<Cards>, List<Cards>)Tuplex)
        {
            System.Console.WriteLine("Please select your legion");
            System.Console.WriteLine("Press [1] for Underworlds");
            System.Console.WriteLine("Press [2] for Celestials");
            ConsoleKey key = Console.ReadKey(true).Key;
            switch (key)
            {
                case ConsoleKey.D1:
                    Tuplex.Item4 = Shuffle(Cards.SelectDeck(Cards.Underworld()));
                    System.Console.WriteLine("Now is {0} turn", player2.NamePlayer);
                    Thread.Sleep(2000);
                    if(player2.NamePlayer == "CPU")
                    {
                        System.Console.WriteLine("CPU is selecting their cards");
                        Thread.Sleep(1000);
                        Tuplex.Item3 = Shuffle(IADif.SelectDeckByDif(Cards.Celestial()));
                    }
                    else 
                    Tuplex.Item3 = Shuffle(Cards.SelectDeck(Cards.Celestial()));
                    player2.Hand = Tuplex.Item1;
                    player1.Hand = Tuplex.Item2;
                    player2.Deck = Tuplex.Item3;
                    player1.Deck = Tuplex.Item4;
                    break;
                case ConsoleKey.D2:
                    Tuplex.Item3 = Shuffle(Cards.SelectDeck(Cards.Celestial()));
                    System.Console.WriteLine("Now is {0} turn", player2.NamePlayer);
                    Thread.Sleep(2000);
                    if(player2.NamePlayer == "CPU")
                    {
                        System.Console.WriteLine("CPU is selecting their cards");
                        Thread.Sleep(1000);
                        Tuplex.Item4 = Shuffle(IADif.SelectDeckByDif(Cards.Underworld()));
                    }
                    else Tuplex.Item4 = Shuffle(Cards.SelectDeck(Cards.Underworld()));
                    player1.Hand = Tuplex.Item1;
                    player2.Hand = Tuplex.Item2;
                    player1.Deck = Tuplex.Item3;
                    player2.Deck = Tuplex.Item4;
                    break;
                default:
                    System.Console.WriteLine("Select a valid option");
                    Thread.Sleep(1000);
                    SelectLegion(player1, player2, Tuplex);
                    break;
            }
            
        }
        
        public void NewCard(List<Cards> Generic)
        {
            string[] NamesCards = Directory.GetFiles(@"C:\Miguel\Proyecto\Cartas\");
            for (int i = 0; i < NamesCards.Length; i++)
            {
                Cards NEW = CardCompiler.CraeteNewCard(NamesCards[i]);
                Generic.Add(NEW);
            }
            System.Console.WriteLine("Las Cartas se cargaron");
            Console.ReadKey();
            new Print().PrintMenu();
        }
        public void NewEffect(List<Effects> Effectos)
        {
            string[] NamesEffects = Directory.GetFiles(@"C:\Miguel\Proyecto\Efectos\");
            for (int i = 0; i < NamesEffects.Length; i++)
            {
                Effects NEW  = EffectCompiler.CheckEffect(NamesEffects[i]);
                Effectos.Add(NEW);
            }
            System.Console.WriteLine("Los Efectos nuevos se cargaron");
            Console.ReadKey();
            new Print().PrintMenu();
        }
   }
}