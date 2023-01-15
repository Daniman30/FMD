namespace FMD
{
    public class IA
    {
        public bool PlayIA(Player CPU, Player Human, bool ICanSummon, bool[,] MaskAtk, bool[,] MaskEffect)
        {
            if (CPU.Hand.Count >= 1)
            {
                ICanSummon = Invoke(CPU, Human, ICanSummon, MaskAtk, MaskEffect);
                Effect(CPU, Human, MaskEffect);
                Attack(CPU, Human, ICanSummon, MaskAtk, MaskEffect);
            }
            else if (CPU.Hand.Count == 0)
            {
                Effect(CPU, Human, MaskEffect);
                Attack(CPU, Human, ICanSummon, MaskAtk, MaskEffect);
            }
            return true;
        }
        public bool Invoke(Player CPU, Player Human, bool ICanSummon, bool[,] MaskAtk, bool[,] MaskEffect)
        {
            for (int i = 0; i < CPU.Hand.Count; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    
                    if ((CPU.Hand[i].Type == "Spell" || CPU.Hand[i].Type == "Course") && CPU.Hand[i].Cost <= CPU.Manna)
                    {
                        new Actions().NormalSummon(CPU, Human, CPU.Hand[i], Game.CopyCards, MaskEffect );
                    }
                    
                    if (IAM.numberCardsOnField(CPU) != 3) 
                    {    
                        Cards field = Game.Field[CPU.Index, j];
                        if (field == null)
                        { 
                            if ((CPU.Hand[i].Type != "Spell" && CPU.Hand[i].Type != "Course") && CPU.Hand[i].Cost <= CPU.Manna && ICanSummon) 
                            {
                                System.Console.WriteLine("CPU invoked " + CPU.Hand[i].Name);
                                new Game().miniSummon(CPU, Human, i, ICanSummon, MaskAtk, MaskEffect);
                                new Print().PrintMap();
                                Thread.Sleep(2000);
                                i = 0;
                                
                                ICanSummon = false;
                                //Effect(Game.Field[CPU.Index,j], CPU, Human, MaskEffect);
                            }
                        }
                    }
                }             
            }
            return ICanSummon;
        }
        private  void Attack(Player CPU, Player Human, bool ICanSummon, bool[,] MaskAtk, bool[,] MaskEffect)
        {
            bool sacrifice = true;
            for (int j = 0; j < 3; j++)
            {
                if(!MaskAtk[CPU.Index, j])
                {
                    var card = IAM.cardMaxAtk(Human, -1);
                    var card1 = Game.Field[CPU.Index,j];
                    if(card.Name != "" && card1 != null)
                    {
                        var result = card.Attack - card1.Attack;
                        MaskAtk[CPU.Index, j] = true;
                        if((card.Attack<= card1.Attack) || (IAM.numberCardsOnField(CPU)>1 && result < 1000))
                        {
                            System.Console.WriteLine(card1.Name + " is attacking " + card.Name);
                            Thread.Sleep(5000);
                            new Actions().Attack(card1, card, Human, CPU, Game.CopyCards);
                            
                        }
                        
                    }
                    else if (IAM.numberCardsOnField(Human) == 0 && card1 != null)
                    {
                        MaskAtk[CPU.Index, j] = true;
                        System.Console.WriteLine("CPU is attacking directly ");
                        Thread.Sleep(2000);
                        Human.Life -= 1;
                    }
                }
                if((ICanSummon && IAM.numberCardsOnField(CPU) == 3))
                {
                    Cards card = Game.Field[CPU.Index,j];
                    if( IAM.AnyLowerCard(card, Human) && card.Energy > 0 && sacrifice )
                    {
                        System.Console.WriteLine("CPU is sacrifying {0}", card.Name);
                        Thread.Sleep(2000);
                        new Actions().Sacrfice(card,CPU);
                        new Actions().DestroyCard(card, CPU, Game.CopyCards);
                        Invoke(CPU, Human, ICanSummon, MaskAtk, MaskEffect);
                        sacrifice = false;

                    }

                }
                
            }
            if(CPU.Manna>6)CPU.Manna = 6;
            while(CPU.Hand.Count > 6)
            {
                var card = IAM.handMaxAtk(CPU,-1);
                CPU.Deck.Add(card);
                CPU.Hand.Remove(card);
                System.Console.WriteLine("CPU is discarding");
                Thread.Sleep(1000);
            }
            

        }
    


        public void Effect(Player CPU, Player Human, bool[,] MaskEffect, bool IsMagic = false)
        {
            int pos = CPU.Index;
            if (IsMagic) pos = pos == 1 ? pos - 1 : pos + 1;
            for (int i = 0; i < 3; i++)
            {
                if ((Game.Field[pos, i] != null && IsMagic) || (Game.Field[pos, i] != null && !(MaskEffect[pos, i])))
                {
                    Cards card = Game.Field[pos, i];
                    Cards oponentCard = new Cards("", new IncreaseAtk(""), "", "", -1, -1, -1);
                    if (IAM.cardMaxAtk(Human).Name != "") 
                    {
                        oponentCard = IAM.cardMaxAtk(Human);
                    }
                    else if(card.Effects.GetType().Name == "DecreaseAtk" || card.Effects.GetType().Name == "DecreaseCost" || card.Effects.GetType().Name == "DecreaseAtkPerTurn" || card.Effects.GetType().Name == "DestroyMonsters" || card.Effects.GetType().Name == "MultiAtk" || card.Effects.GetType().Name == "MaidControl") continue;
                    
                    System.Console.WriteLine("{0} is activating effect {1}", card.Name, card.Effects.GetType().Name);
                    Thread.Sleep(2000);

                    switch (card.Effects.GetType().Name)
                    {
                        case "IncreaseAtk":
                            card.Effects.Action(IAM.cardMaxAtk(CPU));
                            break;
                        case "Decrease Atk":
                            card.Effects.Action(oponentCard);
                            new Actions().DestroyCard(oponentCard, Human, Game.CopyCards);
                            break;
                        case "IncreaseManna":
                            card.Effects.Action(CPU);
                            break;
                        case "DecreaseManna":
                            card.Effects.Action(Human);
                            break;
                        case "IncreaseCost":
                            card.Effects.Action(IAM.cardMaxAtk(CPU));
                            break;
                        case "DecreaseCost":
                            card.Effects.Action(oponentCard);
                            break;
                        case "DecreaseAtkPerTurn":   
                            card.Effects.Action(oponentCard, oponentCard.Attack/4, (0, 0), CPU);
                            new Actions().DestroyCard(oponentCard, Human, Game.CopyCards);
                            break;
                        case"DestroyedHand":
                            card.Effects.Action(Human);
                            break;
                        case "DestroyMonsters":
                            card.Effects.Action(oponentCard);
                            new Actions().DestroyCard(oponentCard, Human, Game.CopyCards);
                            break;
                        case "MultiAtk":
                            if (IAM.card2ndMaxAtk(Human, -1).Name == "") 
                            {
                                if (!IsMagic) MaskEffect[pos, IAM.posCard(card, CPU)] = false;
                                continue; //No hay 2 cartas enemigas en el campo
                            }
                            card.Effects.Action(card, IAM.cardMaxAtk(Human, -1), IAM.card2ndMaxAtk(Human, -1), CPU, Human);
                            break;
                        case "MaidControl":
                            card.Effects.Action(oponentCard, 0, (Human.Index, IAM.posCard(oponentCard, Human)), CPU);
                            break;
                        case "SpecialSummon":
                            if (IAM.handMaxAtk(CPU).Name != "") 
                            {
                                card.Effects.Action(IAM.handMaxAtk(CPU), CPU);
                            }
                            break;
                        case "DrawCards":
                            card.Effects.Action(CPU);
                            break;
                        case "DestroyAllMonster":
                            card.Effects.Action(Human);
                            break;
                    }
                    if (!IsMagic) MaskEffect[pos, i] = true;
                }
            }
        }
    }
}
                