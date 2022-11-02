namespace FMD
{
    public class Cards
    {
        public  Cards(string Name, string Effects, string Type, string Legion, int Attack, int Cost, int Mana )
        {
            this.Name = Name;
            this.Effects = Effects;
            this.Type = Type;
            this.Legion = Legion;
            this.Attack = Attack;
            this.Cost = Cost;
            this.Mana = Mana;
        }
        public string Name { get ; set;}
        public string Effects { get ; set;}
        public string Type { get ; set;}
        public string Legion { get ; set;}
        public int Attack { get ; set;}
        public int Cost { get ; set;}
        public int Mana { get ; set;}

        public static List<Cards> Create()
        {
            List<Cards> Test = new List<Cards>();

            //Monster Cards Celestial
            //Humans(Warriors, Magicians)
            {Test.Add(new Cards("Anton, the brave warrior", "", "Warrior", "Celestial", 1500, 0, 1));
            Test.Add(new Cards("Winter Hunter","","Warrior","Celestial",2300,2,1));
            Test.Add(new Cards("Big Hal","","Warrior","Celestial",3200,4,1));
            Test.Add(new Cards("Light Archer","","Warrior","Celestial",1500,0,1));
            Test.Add(new Cards("Time Sage","","Magician","Celestial",2000,2,2));
            Test.Add(new Cards("Elements Magician","","Magician","Celestial",2500,3,1));
            Test.Add(new Cards("Master of ","","Magician","Celestial",2800,3,2));}
            
            //Beast(Beast Warriors, Shaman)
            {Test.Add(new Cards("Tiger-Man of the Ancient Forest","","Beast Warrior","Celestial",2000,2,1));
            Test.Add(new Cards("Guardian of the Mountains","","Beast-Warrior","Celestial",2800,3,2));
            Test.Add(new Cards("Beatiful Mermaid","","Beast-Warrior","Celestial",1500,0,1));
            Test.Add(new Cards("Little Shaman","","Shaman","Celestial",1200,0,1));
            Test.Add(new Cards("Supreme Lord of Mountains","","Shaman","Celestial",2000,2,1));
            Test.Add(new Cards("Blessed Witch Doctor","","Shaman","Celestial",2500,3,1));}
            Test.Add(new Cards("Electric Rhino", "", "Demon", "Celestial", 3000, 4, 2));

            //Monster Cards UnderWorld
            //Humans(Warrior, Magician)
            {Test.Add(new Cards("Dark Hunter","","Warrior","Underworld",1800,1,1));
            Test.Add(new Cards("Silent Assassin","","Warrior","Underworld",2300,2,1));
            Test.Add(new Cards("Dark Archer","","Warrior","Underworld",2000,1,1));
            Test.Add(new Cards("Magic Warrior","","Warrior","Underwrold",2600,3,1));
            Test.Add(new Cards("Mysterious Tramp","","Magician","Underworld",1000,0,1));
            Test.Add(new Cards("Supreme Dark Wither","","Magican","Underworld",3000,3,2));
            Test.Add(new Cards("Darkness Guardian","","Magician","Underworld",2500,2,1));
            Test.Add(new Cards("Rose, the Snakes Queen", "", "Magician", "Underworld", 2500, 3, 3));}

            //Demons(Dark Demon, Evil)
            {Test.Add(new Cards("Supreme Dark Valkyrie","","Dark Demon","Underworld",2800,3,0));
            Test.Add(new Cards("Golden Armor Demon","","Dark Demon","Underworld",2500,2,1));
            Test.Add(new Cards("God Killer","","Dark Demon","Underworld",2600,3,2));
            Test.Add(new Cards("Little Demon","","Dark Demon","Underworld",1000,0,1));
            Test.Add(new Cards("Mad Demon","","Evil","Underworld",1500,1,1));
            Test.Add(new Cards("Bad Dreams Invader","","Evil","Underworld",2000,2,1));
            Test.Add(new Cards("Embezzler of Knowledge","","Evil","Underworld",1800,0,1));
            Test.Add(new Cards("Enchanting Witch","","Evil","Underworld",3000,4,1));}


            Test.Add(new Cards("Centaur of the Cursed Roads", "", "Beast Warrior", "Underworld", 3500, 4, 3));
            Test.Add(new Cards("Ursula, the Dark Ocean Woman", "", "Shaman", "Underworld", 1800, 2, 1));

            Test.Add(new Cards("Storm Dragon", "", "Dragon", "", 5000, 7, 0));
            Test.Add(new Cards("God Hydro Dragon","","Dragon","",5000,7,0));
            Test.Add(new Cards("Gaia Dragon","","Dragon","",5000,7,0));
            Test.Add(new Cards("Destruction Dragon","","Dragon","",5000,7,0));

            
            //SpeelCards
            Test.Add(new Cards("The End of Storm","","Spell","Celestial",0,5,0));
            Test.Add(new Cards("Excalibur's Sword","","Spell","Celestial",0,3,0));

            return Test;
        }

        //Cartas Celestiales
        public static List<Cards> Celestial(List<Cards> ReadyCards)
        {
            List<Cards> CelestialCards = new List<Cards>();
            ReadyCards = Create();
            for (int i = 0; i < ReadyCards.Count; i++)
            {
                if (ReadyCards[i].Legion=="Celestial")
                {
                    CelestialCards.Add(ReadyCards[i]);
                }
                 if (ReadyCards[i].Legion=="")
                {
                    CelestialCards.Add(ReadyCards[i]);
                }
            }
            return CelestialCards;
        }
        //Cartas Underworld
        public static List<Cards> Underworld(List<Cards> ReadyCards)
        {
            List<Cards> UnderworldCards = new List<Cards>();
            ReadyCards = Create();
            for (int i = 0; i < ReadyCards.Count; i++)
            {
                if (ReadyCards[i].Legion=="Underworld")
                {
                    UnderworldCards.Add(ReadyCards[i]);
                }
                if (ReadyCards[i].Legion=="")
                {
                    UnderworldCards.Add(ReadyCards[i]);
                }
            }
            return UnderworldCards;
        }
    }

    //Clase para definir los efectos de las cartas
    public class Effects
    {
        #region Actions
            public void Attack(Cards card1, Cards card2)
            {
                card2.Attack = card2.Attack - card1.Attack;
                card1.Attack = card1.Attack - card2.Attack;
            }

            public void DestroyCard(Cards card, List<Cards> DeckCelestial, List<Cards> DeckUnderworld, Cards[,] Field)
            {
                for (int i = 0; i < 3; i++)
                {
                    if(Field[1,i].Attack<=0)
                    {
                        if(Field[1,i].Legion=="Celestial")DeckCelestial.Add(Field[1,i]);
                        else if(Field[1,i].Legion=="Underworld")DeckCelestial.Add(Field[1,i]);
                        
                        Field[1,i] = null;
                    }
                    if(Field[2,i].Attack<=0)
                    {
                        if(Field[2,i].Legion=="Underworld")DeckUnderworld.Add(Field[2,i]);
                        else if(Field[2,i].Legion=="Celestial")DeckCelestial.Add(Field[2,i]);
                        
                        Field[2,i] = null;
                    }
                }
            }

            public void NormalSummon(List<Cards> Hand, Cards[,] Field, Player player, Cards card)
            {
                for (int i = 0; i < 3; i++)
                {
                    if(player.Manna >= card.Mana)
                    {
                        if(Field[2, i] == null)
                        {
                            Field[2, i] = card;
                            Hand.Remove(card);
                        }
                        else System.Console.WriteLine("No hay espacio");
                    }
                    else System.Console.WriteLine("Calcula bien");
                }
            }

            public void DrawperTurn(List<Cards> Hand, List<Cards> Deck)
            {
                Hand.Add(Deck[0]);
                Deck.Remove(Deck[0]);
            }

        #endregion

        //Region de Efectos
        public void IncreaseAtk(Cards card)
        {
            if (card.Attack >= 1500)
            {
                card.Attack = card.Attack + (card.Attack / 2);
            }
            else card.Attack = card.Attack + 1000;
        }
        public void DecreaseAtk(Cards card)
        {
            if (card.Attack >= 1500)
            {
                card.Attack = card.Attack - 1000;
            }
            else card.Attack = card.Attack - (card.Attack / 2);
        }

        public void IncreaseManna(Player player1)
        {
            if (player1.Manna <= 3)
            {
                player1.Manna = player1.Manna + 2;
            }
            else if (player1.Manna == 6)
            {
                return;
            }
            else player1.Manna = player1.Manna + 1;
        }
        public void DecreaseManna(Player player1)
        {
            if (player1.Manna <= 3)
            {
                player1.Manna = player1.Manna - 1;
            }
            else if (player1.Manna == 0)
            {
                return;
            }
            else player1.Manna = player1.Manna - 2;
        }

        public void DecreaseAtkPerTurn(Cards card, int decrease)
        {
            card.Attack = card.Attack - decrease;
        }

        public void DestroyMonsters(Cards card)
        {
            card.Attack = 0;
        }

        public void DrawCards(List<Cards> Deck, Player player)
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
        public void SpecialSummon(Cards cards, Cards[,] Field)
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

        public void DestroyHand(List<Cards> Hand, List<Cards> Deck)
        {
            for (int i = 0; i < Hand.Count; i++)
            {
                Deck.Add(Hand[i]);
                Hand.Remove(Hand[i]);
            }
        }
        public void MaidControl(Cards card)
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
        public void NextTurn()
        {

        }

        public void MultiAtk(Cards[,] Field,Cards card1, int position1, int position2)
        {
            Attack(card1, Field[1, position1]);
            Attack(card1, Field[1, position2]);
        }
        
        public void DecreaseCost(Cards card)
        {
            if (card.Cost>0)
            {
                card.Cost = card.Cost-1;
            }
        }
        public void IncreaseCost(Cards card)
        {
            if (card.Cost<4)
            {
                card.Cost = card.Cost+1;
            }
        }
    }   
}