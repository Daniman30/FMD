using System.Runtime.CompilerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FMD
{
    public abstract class Effects
    {
         public string description{  get; set;}
        public Effects(string description)
        {
            this.description = description;
          
        }
        public abstract void Action(Cards card);
        public abstract void Action(Player player);
        public abstract void Action(List<Cards> Deck, Player player);
        public abstract void Action(Cards card, int decrease);
        public abstract void Action(Cards cards, Cards[,] Field);
        public  abstract void Action(List<Cards> Hand, List<Cards> Deck);
        public abstract void Action(Cards card, Cards card1,Cards card2);
        
        
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
        public override void Action(List<Cards> Deck, Player player){}
        public override void Action(Cards card, int decrease){}
        public override void Action(Cards cards, Cards[,] Field){}
        public  override void Action(List<Cards> Hand, List<Cards> Deck){}
        public override void Action(Cards card, Cards card1,Cards card2){}
        
        
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
        public override void Action(List<Cards> Deck, Player player){}
        public override void Action(Cards card, int decrease){}
        public override void Action(Cards cards, Cards[,] Field){}
        public  override void Action(List<Cards> Hand, List<Cards> Deck){}
        public override void Action(Cards card, Cards card1,Cards card2){}

    }
    public class DecreaseCost:Effects
    {
        public DecreaseCost(string description):base(description){}
        public override void Action(Cards card)
        {
            if (card.Cost>0)
            {
                card.Cost = card.Cost-1;
            }
        }
        public override void Action(Player player){}
        public override void Action(List<Cards> Deck, Player player){}
        public override void Action(Cards card, int decrease){}
        public override void Action(Cards cards, Cards[,] Field){}
        public  override void Action(List<Cards> Hand, List<Cards> Deck){}
        public override void Action(Cards card, Cards card1,Cards card2){}
    }
    public class IncreaseCost:Effects
    {
        public IncreaseCost(string description):base(description){}
        public override void Action(Cards card)
        {
            if (card.Cost<4)
            {
                card.Cost = card.Cost+1;
            }
        }
        public override void Action(Player player){}
        public override void Action(List<Cards> Deck, Player player){}
        public override void Action(Cards card, int decrease){}
        public override void Action(Cards cards, Cards[,] Field){}
        public  override void Action(List<Cards> Hand, List<Cards> Deck){}
        public override void Action(Cards card, Cards card1,Cards card2){}
    }
    public class MaidControl:Effects 
    {
        public MaidControl(string description):base(description){}
        public override void Action(Cards card)
        {
            if(card.Legion=="Celestial")
            {
                card.Legion ="Underworld";
            }
            if(card.Legion=="Underworld")
            {
                card.Legion ="Celestial";
            }
        }
        public override void Action(Player player){}
        public override void Action(List<Cards> Deck, Player player){}
        public override void Action(Cards card, int decrease){}
        public override void Action(Cards cards, Cards[,] Field){}
        public  override void Action(List<Cards> Hand, List<Cards> Deck){}
        public override void Action(Cards card, Cards card1,Cards card2){}
    }
    public class DestroyMonsters:Effects
    {
        public DestroyMonsters(string description):base (description){}
        public override void Action(Cards card)
        {
            card.Attack = 0;
        }
        public override void Action(Player player){}
        public override void Action(List<Cards> Deck, Player player){}
        public override void Action(Cards card, int decrease){}
        public override void Action(Cards cards, Cards[,] Field){}
        public  override void Action(List<Cards> Hand, List<Cards> Deck){}
        public override void Action(Cards card, Cards card1,Cards card2){}

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
            else if (player.Manna == 6)
            {
                return;
            }
            else player.Manna = player.Manna + 1;
        }
        public override void Action(List<Cards> Deck, Player player){}
        public override void Action(Cards card, int decrease){}
        public override void Action(Cards cards, Cards[,] Field){}
        public  override void Action(List<Cards> Hand, List<Cards> Deck){}
        public override void Action(Cards card, Cards card1,Cards card2){}
            
        
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
        public override void Action(List<Cards> Deck, Player player){}
        public override void Action(Cards card, int decrease){}
        public override void Action(Cards cards, Cards[,] Field){}
        public  override void Action(List<Cards> Hand, List<Cards> Deck){}
        public override void Action(Cards card, Cards card1,Cards card2){}
            
        
    }
    public class DrawCards:Effects
    {
        public DrawCards(string description):base(description){}
        public override void Action(Cards card, int decrease){}
        public override void Action(Cards cards, Cards[,] Field){}
        public  override void Action(List<Cards> Hand, List<Cards> Deck){}
        public override void Action(Cards card, Cards card1,Cards card2){}
        public override void Action(Cards card){}
        public override void Action(Player player){}
        public override void Action(List<Cards> Deck, Player player)
        {
            if (player.Hand.Count < 3)
            {
                player.Hand.Add(Deck[0]);
                Deck.Remove(Deck[0]);

                player.Hand.Add(Deck[0]);
                Deck.Remove(Deck[0]);
            }
            else
            {
                player.Hand.Add(Deck[0]);
                Deck.Remove(Deck[0]);                      
            }
        }
    }
  public class  SpecialSummon:Effects
  {
    public SpecialSummon(string description):base(description){}
    public override void Action(Cards card, int decrease){}
        public override void Action(Cards cards, Cards[,] Field)
        {
            for (int i = 0; i < 2; i++)
            {
                if (Field[2,i]==null)
                {
                    Field[2,i] = cards;
                }
                if (Field[1,i]==null)
                {
                    Field[1,i] = cards;
                }
            }
        }
        public  override void Action(List<Cards> Hand, List<Cards> Deck){}
        public override void Action(Cards card, Cards card1,Cards card2){}
        public override void Action(Cards card){}
        public override void Action(Player player){}
        public override void Action(List<Cards> Deck, Player player){}
  }
  public class  DestroyedHand:Effects
  {
    public DestroyedHand(string description):base(description){}
    public override void Action(Cards card, int decrease){}
        public override void Action(Cards cards, Cards[,] Field){}
        public  override void Action(List<Cards> Hand, List<Cards> Deck)
        {
             for (int i = 0; i < Hand.Count; i++)
            {
                Deck.Add(Hand[i]);
                Hand.Remove(Hand[i]);
            }
        }
        public override void Action(Cards card, Cards card1,Cards card2){}
        public override void Action(Cards card){}
        public override void Action(Player player){}
        public override void Action(List<Cards> Deck, Player player){}
  }
  public class MultiAtk:Effects
  {
    public MultiAtk(string description):base(description){}
        public override void Action(Cards card, Cards card1, Cards card2)
        {
            new Actions().Attack(card, card1);
            new Actions().Attack(card, card2);
        }
        public override void Action(Cards card, int decrease){}
        public override void Action(Cards cards, Cards[,] Field){}
        public  override void Action(List<Cards> Hand, List<Cards> Deck){}
        public override void Action(Cards card){}
        public override void Action(Player player){}
        public override void Action(List<Cards> Deck, Player player){}

  }
  public class DecreaseAtkPerTurn:Effects
  {
    public override void Action(Cards card, int decrease)
    {
         card.Attack = card.Attack - decrease;
    }
        public DecreaseAtkPerTurn(string description):base (description){}
        public override void Action(Cards cards, Cards[,] Field){}
        public  override void Action(List<Cards> Hand, List<Cards> Deck){}
        public override void Action(Cards card, Cards card1,Cards card2){}
        public override void Action(Cards card){}
        public override void Action(Player player){}
        public override void Action(List<Cards> Deck, Player player){}
  }
   
   
        
}