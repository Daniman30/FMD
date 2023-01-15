namespace FMD
{
    public class Cards
    {
        public  Cards(string Name, Effects Effects, string Type, string Legion, int Attack, int Cost, int Energy )
        {
            this.Name = Name;
            this.Effects = Effects;
            this.Type = Type;
            this.Legion = Legion;
            this.Attack = Attack;
            this.Cost = Cost;
            this.Energy = Energy;
        }
        public string Name { get ; set;}
        public Effects Effects { get ; set;}
        public string Type { get ; set;}
        public string Legion { get ; set;}
        public int Attack { get ; set;}
        public int Cost { get ; set;}
        public int Energy { get ; set;}
        
        public static List<Cards> Create()
        {
            //Cartas predeterminadas del juego
            List<Cards> Test = new List<Cards>();

            //Monster Cards Celestial
            //Humans(Warriors, Wizards)
            {Test.Add(new Cards("Anton, the brave warrior", new IncreaseAtk("Pay two Manna Units, and then increase the Attack of this card"), "Warrior", "Celestial", 1500, 0, 1));
            Test.Add(new Cards("Winter Hunter",new DecreaseAtk("Select a adversary monster on the field, decrease his attack, until to End's turn"),"Warrior","Celestial",2300,2,1));
            Test.Add(new Cards("Big Hal",new MultiAtk ("While this card is face up on the field. This card can do two attack during each Battle"),"Warrior","Celestial",3200,4,1));
            Test.Add(new Cards("Light Archer",new DestroyMonsters ("Select a monster of your adversary, destroy it"),"Warrior","Celestial",1500,0,1));
            Test.Add(new Cards("Brave Warrior",new DecreaseCost("Select a monster on the field, decrease his energy"),"Warrior","Celestial",2000,1,2));
            Test.Add(new Cards("Assassin Dragons", new IncreaseAtk("Duplicate the attack of this card"),"Warrior","Celestial",2000,1,1));
            Test.Add(new Cards("Warriors Group",new MultiAtk("This card can do two attack on this battle"),"Warrior","Celestial",2300,2,1));
            Test.Add(new Cards("Element Mannager", new IncreaseManna("You can increase your Manna"),"Wizard","Celestial",1900,0,1));
            Test.Add(new Cards("Light Queen", new DecreaseAtkPerTurn("Select a monster, once time per turn decrease his attack"),"Wizard","Celestial",3000,3,2));
            Test.Add(new Cards("Overlord", new SpecialSummon("You can special summon a monster from your hand"),"Wizard","Celestial",2500,2,1));
            Test.Add(new Cards("Graveyard Keeper", new DecreaseManna("Your opponet lose a Manna Units"),"Wizard","Celestial",2000,2,2));
            Test.Add(new Cards("Time Sage",new IncreaseManna ("Once time per turn, you can increase your Manna Units"),"Wizard","Celestial",2000,2,2));
            Test.Add(new Cards("Elements Wizard",new DestroyedHand ("Pay two Manna Units and send all cards of your adversary to the bottom's deck"),"Wizard","Celestial",2500,3,1));
            Test.Add(new Cards("Master of God Pieces",new SpecialSummon ("Once time per turn you can pay three Manna Units and you can Special Summon a monster of your hand"),"Wizard","Celestial",2800,3,2));
            Test.Add(new Cards("Ultimate Galaxy Wizard",new DestroyMonsters("You can destroy all monster of your adversary"),"Wizard","Celestial",3800,4,2));}
            
            //Beast(Beast Warriors, Shaman)
            {Test.Add(new Cards("Tiger-Man of the Ancient Forest",new MultiAtk ("This card can Attack two monster for each battle"),"Beast Warrior","Celestial",2000,2,1));
            Test.Add(new Cards("Guardian of the Mountains",new IncreaseAtk ("Increase the Attack of this Card"),"Beast-Warrior","Celestial",2800,3,2));
            Test.Add(new Cards("The Lion King",new MaidControl("Select a monster on the field, take the control"),"Beast-Warrior","Celestial",3000,2,1));
            Test.Add(new Cards("Beatiful Mermaid",new DrawCards ("You can draw extra card"),"Beast-Warrior","Celestial",1500,0,1));
            Test.Add(new Cards("Electric Rhino", new MultiAtk ("This card can Attack all monster of the adversary field"), "Beast-Warrior", "Celestial", 3000, 4, 2));
            Test.Add(new Cards("Centaur of the Cursed Roads", new IncreaseAtk ("Select other monster on the field, increase his attack"), "Beast Warrior", "Celestial", 3500, 4, 3));
            Test.Add(new Cards("Lizzard-Man of the Oceans", new MaidControl("Select and hipnotyze a monster of you opponent"),"Beast-Warrior","Celestial",2400,2,1));
            Test.Add(new Cards("The Animal's Emperor", new SpecialSummon("You can special summon a monster from your hand"),"Beast-Warrior","Celestial",1600,0,1));
            Test.Add(new Cards("Witch Doctor", new DecreaseCost("Select a monster on the field, decrease your Energy"),"Shaman","Celestial",1000,0,2));
            Test.Add(new Cards("Trees Demon", new DestroyMonsters("Select a monster on the field, destroy him"),"Shaman","Celestial",3000,3,1));
            Test.Add(new Cards("Insect charming", new MultiAtk("Select a monster on the field, this monster can do two attacks during this battle"),"Shaman","Celestial",2000,1,1));
            Test.Add(new Cards("Ursula, the Dark Ocean Woman", new DrawCards ("Draw extra cards"), "Shaman", "Celestial", 1800, 2, 1));
            Test.Add(new Cards("Idania's Shaman",new DecreaseAtkPerTurn("Select a monster on the field, once time per turn decrease his attack"),"Shaman","Celestial",4000,4,2));
            Test.Add(new Cards("Little Shaman",new IncreaseManna ("Your Manna will increased"),"Shaman","Celestial",1200,0,1));
            Test.Add(new Cards("Supreme Lord of Mountains",new DestroyedHand ("Your opponent should discard cards"),"Shaman","Celestial",2000,2,1));
            Test.Add(new Cards("Blessed Witch Doctor",new DestroyMonsters ("Select a monster on the field and destroy it"),"Shaman","Celestial",2500,3,1));}
            
            //Monster Cards UnderWorld
            //Humans(Warrior, Wizard)
            {Test.Add(new Cards("Dark Hunter",new IncreaseAtk ("Increase the attack of this card"),"Warrior","Underworld",1800,1,1));
            Test.Add(new Cards("Silent Assassin",new DecreaseAtk ("Select a Celestial monster and Decrease his attack"),"Warrior","Underworld",2300,2,1));
            Test.Add(new Cards("Dark Archer",new DestroyedHand ("Your opponent discard his hands's cards"),"Warrior","Underworld",2000,1,1));
            Test.Add(new Cards("Magic Warrior",new MultiAtk ("This card can attack two monster"),"Warrior","Underworld",2600,3,1));
            Test.Add(new Cards("Coursed Warrior", new IncreaseAtk("Increase the attack of this card"),"Warrior","Underworld",2000,1,1));
            Test.Add(new Cards("Tumb Raider", new SpecialSummon ("You can do a special summon of a monster of your hand"),"Warrior","Underworld",1700,1,1));
            Test.Add(new Cards("Napoleon, the Destruction Warrior", new DestroyMonsters("Select a monster on the field, destroy him"),"Warrior","Underworld",3000,3,1));
            Test.Add(new Cards("Ancient Shogun", new DrawCards("You can draw cards"),"Warrior","Underworld",2500,2,1));
            Test.Add(new Cards("Shadow Wizard",new MultiAtk("You can attack two monsters of your adversary"),"Wizard","Underworld",3000,2,1));
            Test.Add(new Cards("Timegaezer Controller", new DrawCards("You can draw cards"),"Wizard","Underworld",1800,1,1));
            Test.Add(new Cards("The Dark King", new DecreaseAtkPerTurn("Select a monster on the field and decrease his attack"),"Wizard","Underworld",3000,3,2));
            Test.Add(new Cards("Space Invader", new SpecialSummon("You can do Special Summon in this turn"),"Wizard","Underworld",2000,2,1));
            Test.Add(new Cards("Dragon Killer", new DestroyMonsters("You can destroy a monster on the field"),"Wizard","Underworld",4000,4,1));
            Test.Add(new Cards("Mysterious Tramp",new MaidControl ("Select a monster of your advesary and take the control"),"Wizard","Underworld",1000,0,1));
            Test.Add(new Cards("Supreme Dark Wither",new DecreaseAtkPerTurn ("Select a monster of your adversary. Once time per turn the attack of this monster is decreased"),"Wizard","Underworld",3000,3,2));
            Test.Add(new Cards("Darkness Guardian",new IncreaseCost ("Select a monster on the field and Increase his Manna"),"Wizard","Underworld",2500,2,1));
            Test.Add(new Cards("Rose, the Snakes Queen", new DestroyMonsters ("Destroy a monster on the field"), "Wizard", "Underworld", 2500, 3, 3));}

            //Demons(Dark Demon, Evil)
            {Test.Add(new Cards("Supreme Dark Valkyrie",new DecreaseCost ("You can select a monster of your adversary and decrease his Manna"),"Dark Demon","Underworld",2800,3,0));
            Test.Add(new Cards("Golden Armor Demon",new IncreaseManna ("Your player manna will be increased"),"Dark Demon","Underworld",2500,2,1));
            Test.Add(new Cards("God Killer",new MultiAtk ("This card can do two attacks on this battle"),"Dark Demon","Underworld",2600,3,2));
            Test.Add(new Cards("Little Demon",new IncreaseAtk ("Select a monster on the field and increase his attack"),"Dark Demon","Underworld",1000,0,1));
            Test.Add(new Cards("Dark Creator", new SpecialSummon("Summon a monster from your hand and no pay manna"),"Dark Demon","Underworld",1500,0,1));
            Test.Add(new Cards("Little Pony", new IncreaseAtk("Increase the attack of one card"),"Dark Demon","Underworld",1600,2,1));
            Test.Add(new Cards("Warrior Killer",new MultiAtk("This card can attack two monsters of your adversary"),"Dark Demon","Underworld",3000,3,1));
            Test.Add(new Cards("Cerbero Man", new DestroyMonsters("You can destroy a monster of your adversary"),"Dark Demon","Underworld",2000,2,2));
            Test.Add(new Cards("Witcher's Creator", new SpecialSummon("You can do a special summon for a new monster"),"Evil","Underworld",2700,3,1));
            Test.Add(new Cards("Diabolic Demon", new DestroyedHand("You opponet send all cards of your hand to the button of his deck"),"Evil","Underworld",1800,2,1));
            Test.Add(new Cards("Emperor's Hell", new DecreaseCost("Select a monster on the field and decrease his manna"),"Evil","Underworld",2000,1,1));
            Test.Add(new Cards("Shadow art Dominate", new SpecialSummon("Special Summon a monster from your hand"),"Evil","Underworld",1900,1,1));
            Test.Add(new Cards("Lucifer",new DestroyMonsters("Destroy a monster of your adversary"),"Evil","Underworld",3000,3,1));
            Test.Add(new Cards("Mad Demon",new DecreaseAtkPerTurn ("Select a monster on the field and decrease his attack"),"Evil","Underworld",1500,1,1));
            Test.Add(new Cards("Bad Dreams Invader",new DrawCards ("You can draw extra cards"),"Evil","Underworld",2000,2,1));
            Test.Add(new Cards("Embezzler of Knowledge",new IncreaseCost ("Increase the manna of a card on the field"),"Evil","Underworld",1800,0,1));
            Test.Add(new Cards("Enchanting Witch",new DecreaseManna ("Decrease your adversary Manna"),"Evil","Underworld",3000,4,1));}

            //Dragons
            Test.Add(new Cards("Storm Dragon", new DestroyAllMonster ("Destroy all monster of your opponent"), "Dragon", "", 5000, 7, 0));
            Test.Add(new Cards("God Hydro Dragon",new DestroyAllMonster ("Destroy all monster of your opponent"),"Dragon","",5000,7,0));
            Test.Add(new Cards("Gaia Dragon",new DestroyAllMonster ("Destroy all monster of your opponent"),"Dragon", "",5000,7,0));
            Test.Add(new Cards("Destruction Dragon",new DestroyAllMonster ("Destroy all monster of your opponent"),"Dragon", "",5000,7,0));
            Test.Add(new Cards("Zork, the Darkness God", new IncreaseAtk("Increase the attack of one card"),"Game God","Underworld",5000,7,1));
            Test.Add(new Cards("Zemilka, the Light God", new IncreaseAtk("Increase attack"),"Game God","Celestial",5000,7,1));
            
            //SpellCards
            Test.Add(new Cards("The Light Born",new DestroyMonsters ("Destroy a underworld monster on the field"),"Spell","Celestial",0,3,0));
            Test.Add(new Cards("End of the Road", new DestroyMonsters("Select a monster of your adversary, destroy"),"Spell","Celestial",0,3,0));
            Test.Add(new Cards("Sky Arc", new IncreaseAtk("Increase the attack of a monster on your field"),"Spell","Celestial",0,2,0));
            Test.Add(new Cards("Excalibur's Sword",new IncreaseAtk ("Select a Warrior Monster on your Field. Increase his Attack"),"Spell","Celestial",0,2,0));
            Test.Add(new Cards("Soul Exchange", new DecreaseAtk("Select a monster of you adversary, his attack decrease"),"Spell","Celestial",0,1,0));
            Test.Add(new Cards("Blue Rune", new DecreaseAtk("Select a adversary monster. Decrease selected monster's Attack."),"Spell","Celestial",0,2,0));
            Test.Add(new Cards("Spiritual Change",new MaidControl("Select a underworld monster, take the control until end of his life"),"Spell","Celestial",0,4,0));
            Test.Add(new Cards("Green Rune", new IncreaseManna("When you activate this card, you can increase your player manna"),"Spell","Celestial",0,1,0));
            Test.Add(new Cards("Out of Time",new SpecialSummon("Select a monster of your hand, special summon this"),"Spell","Celestial",0,4,0));
            Test.Add(new Cards("Time Magic", new DrawCards("You can draw extra cards"),"Spell","Celestial",0,0,0));
            Test.Add(new Cards("Call of Dragon", new SpecialSummon("Special Summon a monster of your hand"),"Spell","Celestial",0,4,0));
            Test.Add(new Cards("Super Sword", new MultiAtk("Select a Monster of your field. This monster will have two attack in this turn"),"Spell","Celestial",0,1,0));

            //Course
            Test.Add(new Cards("The Forest's Course", new DecreaseAtkPerTurn("Select a Monster of you adversary, for the rest of the Game, this monster will lose Attack per turn"),"Course","Underworld",0,1,0));
            Test.Add(new Cards("Anti-Materia Book",new DestroyedHand("Send all cards of you oponent hand to the buttom of his deck"),"Course","Underworld",0,1,0));
            Test.Add(new Cards("Call of Death", new DestroyMonsters("Destroy a monster of your Adversary"),"Course","Underworld",0,3,0));
            Test.Add(new Cards("The End of the Storm", new DestroyMonsters("Destroy a celestial monster on the field"),"Course","Underworld",0,3,0));
            Test.Add(new Cards("Coursed Sword", new IncreaseAtk("Select a underworld monster, increase his attack"),"Course","Underworld",0,2,0));
            Test.Add(new Cards("Dark Dimmension Gate", new SpecialSummon("Special a underworld monster of your hand"),"Course","Underworld",0,4,0));
            Test.Add(new Cards("Purple Rune", new IncreaseManna("Increase your player manna"),"Course","Underworld",0,1,0));
            Test.Add(new Cards("Venom Hand", new DecreaseManna("The player manna of your opponent decrease"),"Course","Underworld",0,1,0));
            Test.Add(new Cards("Black Lost Sword", new MultiAtk("Select a monster. This monster can do two attack during the next battle"),"Course","Underworld",0,1,0));
            Test.Add(new Cards("Love Poison",new MaidControl("Select a monster of your adversary, take the control"),"Course","Underworld",0,4,0));
            Test.Add(new Cards("The Dark Hole", new DestroyMonsters("Destroy all monster on the field"),"Course","Underworld",0,3,0));
            Test.Add(new Cards("Call of Dragon", new SpecialSummon("Special summon a monster of your hand"),"Course","Underworld",0,4,0));
            return Test;
        }

        //Cartas Celestiales
        public static List<Cards> Celestial() //Recibe Todas las cartas
        {
            List<Cards> CelestialCards = new List<Cards>();
            
            for (int i = 0; i < Game.GenericCards.Count; i++)
            {
                if (Game.GenericCards[i].Legion=="Celestial")
                {
                    CelestialCards.Add(Game.GenericCards[i]);
                }
                 if (Game.GenericCards[i].Legion=="") //DragonCards
                {
                    CelestialCards.Add(Game.GenericCards[i]);
                }
            }

            return CelestialCards;
        }
        //Cartas Underworld
        public static List<Cards> Underworld()
        {
            List<Cards> UnderworldCards = new List<Cards>();
            
            for (int i = 0; i < Game.GenericCards.Count; i++)
            {
                if (Game.GenericCards[i].Legion=="Underworld")
                {
                    UnderworldCards.Add(Game.GenericCards[i]);
                }
                if (Game.GenericCards[i].Legion=="")
                {
                    UnderworldCards.Add(Game.GenericCards[i]);
                }
            }
            return UnderworldCards;
        }
        public static List<Cards> SelectDeck(List<Cards> MostCards, int index = 0)
        {
            List<Cards> DeckC30 = new List<Cards>();
            int cardcount = 0;
            

            for (int i = 0; i < MostCards.Count; i++)
            {
                System.Console.WriteLine("[" + i + "]" + " " + MostCards[i].Name /*+ "          Attack: "  + MostCards[i].Attack + "          Type: " + MostCards[i].Type + "          Effect: "   +  MostCards[i].Effects.GetType().Name*/ );
            }

            int count = 0;

            for (int j = 1; j < 31; j += count)
            {
                System.Console.WriteLine("You have {0} card on deck", cardcount);
                System.Console.WriteLine("Please select your card writing its number, select 100 for random");
                int Controller = 0;
                
                
                if (index != 100) index = new Game().ParseInt(index);
                if (index == 100)
                {
                    DeckC30 = SelectDeckRandom(MostCards, DeckC30);
                    return DeckC30;
                }

                System.Console.WriteLine("Select how many cards would you like to add");
                count = 0;
                count = new Game().ParseInt(count);
                if (count > 4) 
                {
                    System.Console.WriteLine("You only can add 4 cards of the same type");
                    j-=count;
                }
                else if (DeckC30.Count + count > 30)
                {
                    System.Console.WriteLine("Deck is almost full you can only add " + (30-DeckC30.Count)+ " more cards");
                    j-= count;
                }
                else
                {
                    for (int i = 0; i < count; i++)
                    {
                        DeckC30.Add(MostCards[index]);    
                    }
                    cardcount+= count;
                    for (int k = 0; k < DeckC30.Count-1; k++)
                    {
                        if(DeckC30[k]==DeckC30[DeckC30.Count-1])
                        {
                            Controller++;
                        }
                    }
                    
                    for (int i = 0; i < MostCards.Count; i++)
                    {
                        System.Console.WriteLine("[" + i + "]" + " " + MostCards[i].Name);
                    }
                    System.Console.WriteLine();
                    
                    if(Controller>=4)
                    {
                        System.Console.WriteLine("You can't add this card"); 
                        for (int i = 0; i < count; i++)
                        {
                            DeckC30.Remove(DeckC30[DeckC30.Count-1]); 
                            j--;
                        }
                        cardcount-= count;
                    }
                }
                System.Console.WriteLine("Your cards are:");
                for (int i = 0; i < DeckC30.Count; i++)
                {
                    if(DeckC30[i].Effects.GetType().Name=="Effects")
                    {
                        System.Console.WriteLine( "Name: " + DeckC30[i].Name + " Attack: " + DeckC30[i].Attack + " Type: " + DeckC30[i].Type + "Effect: "   +  DeckC30[i].Effects.name);
                        continue;
                    }
                    System.Console.WriteLine( "Name: " + DeckC30[i].Name + " Attack: " + DeckC30[i].Attack + " Type: " + DeckC30[i].Type + "Effect: "   +  DeckC30[i].Effects.GetType().Name );
                }   
            }
            return DeckC30;
        }

        public static List<Cards> SelectDeckRandom(List<Cards> MostCards, List<Cards> FinalDeck)
        {
            List<int> SelectedNumbers = new List<int>();
            for (int i = FinalDeck.Count; i < 30; i++)
            {
                Random n = new Random();
                int num = n.Next(0, MostCards.Count);
                if(SelectedNumbers.Contains(num) || FinalDeck.Contains(MostCards[num]))
                {
                    i--;
                    continue;
                }
                SelectedNumbers.Add(num);
                FinalDeck.Add(MostCards[num]);
            }
            return FinalDeck;
        }
      
    }
}