namespace FMD
{
    public class Actions
    {
        public void Attack(Cards card1, Cards card2)
        {
            card2.Attack = card2.Attack - card1.Attack;
            card1.Attack = card1.Attack - card2.Attack;
        }
        public List<Cards> DestroyCard(Player player, Player Oplayer, List<Cards> CopyField, Cards[,] Field)
        {
            for (int i = 0; i < 3; i++)
            {
                if (Field[player.Index, i] == null) return CopyField;
                if (!CopyField.Contains(Field[player.Index, i])) CopyField.Add(Field[player.Index, i]);
                if (Field[player.Index, i].Attack <= 0)
                {
                    string name = Field[player.Index, i].Name;
                    foreach (Cards card in CopyField)
                    {
                        if (card.Name == name)
                        {
                            player.Deck.Add(card);
                            CopyField.Remove(card);
                            Field[player.Index, i] = null;
                        }
                    }
                }
            }

            for (int i = 0; i < 3; i++)
            {
                if (Field[Oplayer.Index, i] == null) return CopyField;
                if (!CopyField.Contains(Field[Oplayer.Index, i])) CopyField.Add(Field[Oplayer.Index, i]);
                if (Field[Oplayer.Index, i].Attack <= 0)
                {
                    string name = Field[Oplayer.Index, i].Name;
                    foreach (Cards card in CopyField)
                    {
                        if (card.Name == name)
                        {
                            Oplayer.Deck.Add(card);
                            CopyField.Remove(card);
                            Field[Oplayer.Index, i] = null;
                        }
                    }
                }
            }

            return CopyField;
            
        }

        public void NormalSummon(List<Cards> Hand, Cards[,] Field, Player player, Cards card,int pos)
        {
            if(player.Manna >= card.Mana)
            {
                if (card.Type == "Spell") pos = 3;
                if (card.Type == "Course") pos = 0;
                for (int i = 0; i < 3; i++)
                {
                    if(Field[pos, i] == null)
                    {
                        Field[pos, i] = card;
                        Hand.Remove(card);
                        player.Manna = player.Manna - card.Cost;
                        return;
                    }
                }
                System.Console.WriteLine("No hay espacio");
            }
            else System.Console.WriteLine("Calcula bien");
        }

        public void DrawperTurn(List<Cards> Hand, List<Cards> Deck)
        {
            Hand.Add(Deck[0]);
            Deck.Remove(Deck[0]);
        }
        public List<Cards> Select(List<Cards> DryCards)
        {
            List<Cards> ToReturn = new List<Cards>();
            for (int i = 0; i < DryCards.Count; i++)
            {
                if (DryCards[i].Legion=="Celestial")
                {
                    for (int j = 0; j < 4; j++)
                    {
                        ToReturn.Add(DryCards[i]);
                    }
                }
                if (DryCards[i].Legion=="Underworld")
                {
                    for (int j = 0; j < 4; j++)
                    {
                        ToReturn.Add(DryCards[i]);
                    }
                }
            }
            return ToReturn;
        }
    } 
}