namespace FMD
{
    public class Actions
    {
        public void Attack(Cards attacker, Cards attacked, Player Oplayer, Player player, List<Cards> CopyCard)
        {
            int aux = attacker.Attack;
            attacker.Attack = attacker.Attack - attacked.Attack;
            attacked.Attack = attacked.Attack - aux;
            DestroyCard(attacked, player, CopyCard);
            DestroyCard(attacker, Oplayer, CopyCard);
        }
        public void DestroyCard(Cards attacked, Player player, List<Cards> CopyCard)
        {
            int pos = player.Index;
            
            if (attacked.Type == "Spell" || attacked.Type == "Course") {pos = pos == 1 ? pos - 1 : pos + 1;}
            for (int i = 0; i < 3; i++)
            {
                if (Game.Field[pos, i] == null) continue;
                if (Game.Field[pos, i].Attack <= 0 ) 
                {
                    if (attacked.Type == "Course" || attacked.Type == "Spell") System.Console.WriteLine("{0} finish his job", Game.Field[pos, i].Name);
                    else System.Console.WriteLine( Game.Field [pos,i].Name + " is dead x_x");
                    Thread.Sleep(2000);
                    Game.Field[pos, i] = null;
                    for (int j = 0; j < CopyCard.Count; j++)
                    {   
                        if (attacked.Name == CopyCard[j].Name) 
                        {
                            player.Deck.Add(CopyCard[j]); 
                            CopyCard.Remove(CopyCard[j]);
                        }
                    }
                }
            }
        }

        public void NormalSummon(Player player, Player Oplayer, Cards card, List<Cards> CopyCards, bool[,] MaskEffect = null, bool[,] MaskAtk = null)
        {
            bool a = true;
            bool b = true;
            int pos = player.Index;
            if(player.Manna >= card.Energy)
            {
                
                if (card.Type == "Course" || card.Type == "Spell" ) { pos = pos == 1 ? pos -1 : pos +1 ;}
                
                
                for (int i = 0; i < 3; i++)
                { 
                    if((pos == 3 || pos == 0) && MagicSummon(player))
                    {
                        //System.Console.WriteLine(MagicSummon(player, Game.Field));
                        if(Game.Field[pos, i] == null)
                        {
                            Game.Field[pos, i] = new Game().CopyCard(card);
                            CopyCards.Add(card);
                            player.Hand.Remove(card);
                            if (player.NamePlayer != "CPU") new Print().PrintHand(player.Hand);
                            player.Manna = player.Manna - card.Cost;
                            if (player.NamePlayer == "CPU")
                            {
                                System.Console.WriteLine("CPU invoked " + player.Hand[i].Name);
                                Thread.Sleep(2000);
                            }
                            new Print().PrintMap();
                            Thread.Sleep(1000);
                            System.Console.WriteLine("Card's effect is being activated");
                            Thread.Sleep(1000);
                            System.Console.WriteLine(Game.Field[pos,i].Name + " is ready to use it's effect");
                            Thread.Sleep(1000);
                            b = false;
                            if (player.NamePlayer == "CPU") new IA().Effect(player, Oplayer, MaskEffect, true);
                            else new Game().Effects(player, Oplayer, Game.Field[pos,i], MaskEffect, MaskAtk);
                            DestroyCard(card, player, CopyCards);
                            return;
                        }
                    }
                    else 
                    {
                        if(Game.Field[pos, i] == null && ( pos == 2 || pos == 1))
                        {
                            Game.Field[pos, i] = new Game().CopyCard(card);
                            CopyCards.Add(card);
                            player.Hand.Remove(card);
                            player.Manna = player.Manna - card.Cost;
                            a = false;
                            return;  
                        }
                    }    
                }
                if (b && player.NamePlayer != "CPU") 
                {    
                    System.Console.WriteLine("Sorry, you must have a Wizard to invoke a magic card");
                    Thread.Sleep(1000);   
                }

                if (a && player.NamePlayer != "CPU")
                {
                    System.Console.WriteLine("Field is full");
                    Thread.Sleep(1000);
                }
            }
            else System.Console.WriteLine("Manna is not enough");
        } 
        public bool MagicSummon(Player player)
        {
            for (int j = 0; j < 3; j++)
            {
                if (Game.Field[player.Index, j]!= null)
                {
                    if ((Game.Field[player.Index, j].Type == "Wizard") || (Game.Field[player.Index, j].Type == "Shaman") || (Game.Field[player.Index, j].Type == "Evil")) return true;
                    else continue;
                }
            }
            return false;
        }
        public void DrawperTurn(List<Cards> Hand, List<Cards> Deck)
        {
            Hand.Add(Deck[0]);
            Deck.Remove(Deck[0]);
        }
                                
                                
   
        public void Sacrfice(Cards card, Player player)
        {
            player.Manna += card.Energy;
            card.Attack=0;
        }
    }
}