namespace FMD
{
    public class Effects:IEffects
    {
        public string description{  get; set;}
        public string name{  get; set;}
        public Effects(string description, string? name = null)
        {
            this.description = description;
            this.name ="" + name;
        }
        public virtual void Action(Cards card){}
        public virtual void Action(Player player){}
        public virtual void Action(Cards card, int decrease, (int,int) pos, Player player ){}
        public virtual void Action(Cards cards, Player player){}
        public virtual void Action(Cards card, Cards card1,Cards card2, Player player, Player Oplayer){}  
    }
    public class IncreaseAtk:Effects
    {
        public IncreaseAtk(string description):base(description){}
        public override void Action(Cards card)
        {
            if (card.Attack >= 1500)
            {
                card.Attack = card.Attack + (card.Attack / 2);
            }
            else card.Attack = card.Attack + 1000;
        }
        public override void Action(Player player){}
        
        public override void Action(Cards card, int decrease, (int,int) pos, Player player ){}
        public override void Action(Cards cards,  Player player){}
        
        public override void Action(Cards card, Cards card1,Cards card2, Player player, Player Oplayer){}        
    }
    public class DecreaseAtk:Effects
    {
        public DecreaseAtk(string description):base(description){}
        public override void Action(Cards card)
        {
            if (card.Attack >= 1500)
            {
                card.Attack = card.Attack - 1000;
            }
            else card.Attack = card.Attack - (card.Attack / 2);
        }
        public override void Action(Player player){}
        
        public override void Action(Cards card, int decrease, (int,int) pos, Player player ){}
        public override void Action(Cards cards,  Player player){}
        
        public override void Action(Cards card, Cards card1,Cards card2, Player player, Player Oplayer){}
    }
    public class DecreaseCost:Effects
    {
        public DecreaseCost(string description):base(description){}
        public override void Action(Cards card)
        {
            if (card.Energy>0)
            {
                card.Energy = card.Energy - 1;
            }
        }
        public override void Action(Player player){}
        
        public override void Action(Cards card, int decrease, (int,int) pos, Player player ){}
        public override void Action(Cards cards,  Player player){}
        
        public override void Action(Cards card, Cards card1,Cards card2, Player player, Player Oplayer){}
    }
    public class IncreaseCost:Effects
    {
        public IncreaseCost(string description):base(description){}
        public override void Action(Cards card)
        {
            if (card.Energy<4)
            {
                card.Energy = card.Energy+1;
            }
        }
        public override void Action(Player player){}
        
        public override void Action(Cards card, int decrease, (int,int) pos, Player player ){}
        public override void Action(Cards cards,  Player player){}
        
        public override void Action(Cards card, Cards card1,Cards card2, Player player, Player Oplayer){}
    }
    public class MaidControl:Effects 
    {
        public MaidControl(string description):base(description){}
        public override void Action(Cards card){}
        public override void Action(Player player){}
        
        public override void Action(Cards card, int decrease, (int,int) pos, Player player )
        {
            bool a = true;
            for (int i = 0; i < 3; i++)
            {
                if(Game.Field[player.Index, i] == null)
                {
                    Game.Field[pos.Item1,pos.Item2] = null;
                    if (card.Legion =="Underworld") card.Legion = "Celestial";
                    else if (card.Legion =="Celestial") card.Legion = "Underworld";
                    a = false;
                    Game.Field[player.Index, i]= card;
                    return;
                }
            }
            System.Console.WriteLine(card.Name + " has been stolen");
            Thread.Sleep(2000);
            if(a)
            {
                System.Console.WriteLine(" Your field is full");
                Thread.Sleep(1000);
                System.Console.WriteLine("Please do not be ambicious");
                Thread.Sleep(1000);
                new Print().PrintOptions(player);
            }
        }
        public override void Action(Cards cards,  Player player){}
        
        public override void Action(Cards card, Cards card1,Cards card2, Player player, Player Oplayer){}
    }
    public class DestroyMonsters:Effects
    {
        public DestroyMonsters(string description):base (description){}
        public override void Action(Cards card)
        {
            card.Attack = 0;
        }
        public override void Action(Player player){}
        
        public override void Action(Cards card, int decrease, (int,int) pos, Player player ){}
        public override void Action(Cards cards,  Player player){}
        
        public override void Action(Cards card, Cards card1,Cards card2, Player player, Player Oplayer){}
    }
    public class IncreaseManna:Effects
    {
        public IncreaseManna(string description):base (description){}
        public override void Action(Cards card){}
        public override void Action(Player player )
        {
            if (player.Manna <= 3)
            {
                player.Manna = player.Manna + 2;
            }
            else if (player.Manna == 5)
            {
                return;
            }
            else player.Manna = player.Manna + 1;
        }
        
        public override void Action(Cards card, int decrease, (int,int) pos, Player player ){}
        public override void Action(Cards cards,  Player player){}
        
        public override void Action(Cards card, Cards card1,Cards card2, Player player, Player Oplayer){}
    }
    public class DecreaseManna:Effects
    {
        public DecreaseManna(string description):base (description){}
        public override void Action(Cards card){}
        public override void Action(Player player )
        {
            if (player.Manna <= 3)
            {
                player.Manna = player.Manna - 1;
            }
            else if (player.Manna == 0)
            {
                return;
            }
            else player.Manna = player.Manna - 2;
        }
        
        public override void Action(Cards card, int decrease, (int,int) pos, Player player ){}
        public override void Action(Cards cards,  Player player){}
        
        public override void Action(Cards card, Cards card1,Cards card2, Player player, Player Oplayer){}
    }
    public class DrawCards:Effects
    {
        public DrawCards(string description):base(description){}
        public override void Action(Cards card, int decrease, (int,int) pos, Player player ){}
        public override void Action(Cards cards,  Player player){}
        
        public override void Action(Cards card, Cards card1,Cards card2, Player player, Player Oplayer){}
        public override void Action(Cards card){}
        public override void Action(Player player)
        {
            if (player.Hand.Count < 3)
            {
                player.Hand.Add(player.Deck[0]);
                player.Deck.Remove(player.Deck[0]);

                player.Hand.Add(player.Deck[0]);
                player.Deck.Remove(player.Deck[0]);
            }
            else
            {
                player.Hand.Add(player.Deck[0]);
                player.Deck.Remove(player.Deck[0]);                      
            }
        }
        
    }
    public class SpecialSummon:Effects
    {
        public SpecialSummon(string description):base(description){}
        public override void Action(Cards card, int decrease, (int,int) pos, Player player ){}
        public override void Action(Cards card,  Player player)
        {
            for (int i = 0; i < 3; i++)
            {
                if(Game.Field[player.Index, i] == null)
                {
                    Game.Field[player.Index, i] = new Game().CopyCard(card);
                    Game.CopyCards.Add(card);
                    player.Hand.Remove(card);
                    return;  
                }
            }
            
        }
        
        public override void Action(Cards card, Cards card1,Cards card2, Player player, Player Oplayer){}
        public override void Action(Cards card){}
        public override void Action(Player player){}
        
    }
    public class DestroyedHand:Effects
    {
        public DestroyedHand(string description):base(description){}
        public override void Action(Cards card, int decrease, (int,int) pos, Player player ){}
        public override void Action(Cards cards,  Player player){}
        
        public override void Action(Cards card, Cards card1,Cards card2, Player player, Player Oplayer){}
        public override void Action(Cards card){}
        public override void Action(Player player)
        {
            for (int i = 0; i < player.Hand.Count; i++)
            {
                player.Deck.Add(player.Hand[i]);
                player.Hand.Remove(player.Hand[i]);
            }
        }
        
  }
    public class MultiAtk:Effects
    {
        public MultiAtk(string description):base(description){}
        public override void Action(Cards card, Cards card1, Cards card2, Player player, Player Oplayer)
        {
            new Actions().Attack(card, card1, player, Oplayer, Game.CopyCards);
            new Actions().Attack(card, card2, player, Oplayer, Game.CopyCards);
        }
        public override void Action(Cards card, int decrease, (int,int) pos, Player player ){}
        public override void Action(Cards cards,  Player player){}
        
        public override void Action(Cards card){}
        public override void Action(Player player){}
        
    }
    public class DecreaseAtkPerTurn:Effects
    {
        public override void Action(Cards card, int decrease, (int,int) pos, Player player )
        {
            card.Attack = card.Attack - decrease;
        }
        public DecreaseAtkPerTurn(string description):base (description){}
        public override void Action(Cards cards,  Player player){}
        
        public override void Action(Cards card, Cards card1,Cards card2, Player player, Player Oplayer){}
        public override void Action(Cards card){}
        public override void Action(Player player){}
        
    }
    public class DestroyAllMonster : Effects
    {
        public DestroyAllMonster(string description) :base(description){}
        public override void Action(Cards card, int decrease, (int,int) pos, Player player ) {}
        public override void Action(Cards cards,  Player player){}
        
        public override void Action(Cards card, Cards card1,Cards card2, Player player, Player Oplayer){}
        public override void Action(Cards card){}
        public override void Action(Player player)
        {
            for (int i = 0; i < 3; i++)
            {
                if (Game.Field[player.Index,i]!=null)
                {
                    new DestroyMonsters("").Action(Game.Field[player.Index,i]);
                    new Actions().DestroyCard(Game.Field[player.Index,i], player, Game.CopyCards);
                }
            }
        }
    }
}