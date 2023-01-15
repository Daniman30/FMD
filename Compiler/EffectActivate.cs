namespace FMD
{
    public class EffectActivate
    {
        public static List<(string,string)> Effectos = Names();
        public static List<string> SuperProp = new List<string>(){"Player","MyCard","Oplayer","Ocard"};

        public static void IcanActive(Effects created, Player player, Player oplayer)
        {
           for (int i = 0; i < Effectos.Count; i++)
           {
              if(Effectos[i].Item2==created.name)
              {
                Activate(Effectos[i].Item1, player, oplayer);
                return;
              }
           }  
        }

        public static List <(string,string)> Names()
        {
            List <(string,string)> ID = new List<(string,string)>();
            string[] files = Directory.GetFiles(@"C:/Miguel/Proyecto/Efectos/");
            for (int i = 0; i < files.Length; i++)
            {
                string[] split = files[i].Split('/','.');
                ID.Add((files[i],split[split.Length-2]));
            }
            return ID;
        }
        public static void Activate(string code, Player player, Player oplayer)
        {
            List<string> CODEX = File.ReadAllLines(code).ToList();
            foreach (string line in CODEX)
            {
                string newline = string.Join(' ', line.Split(' ', StringSplitOptions.RemoveEmptyEntries));
                string[] spliter = newline.Split(' ',';');

                for (int i = 0; i < spliter.Length; i++)
                {
                    if(!SuperProp.Contains(spliter[0])){break;}
                    if(SuperProp.Contains(spliter[0]))
                    {
                        if(spliter[0]=="Player"){PlayerModifiquer(player,spliter); break;}
                        if(spliter[0]=="Oplayer"){PlayerModifiquer(oplayer,spliter); break;}

                        if(spliter[0]=="MyCard")
                        {
                            Cards myCard1 = new Cards("", new Effects(""), "", "", 0, 0, 0);
                            if (myCard1.Name != "") {}
                            else
                            {
                                ConsoleKey key;
                                System.Console.WriteLine("Select you card to apply your effect");
                                key =  Console.ReadKey(true).Key;
                                myCard1 = new Select().SelectCard(key, player.Index);
                            }
                            CardModifiquer(myCard1,spliter);
                            break;
                        }
                        if (spliter[0]=="Ocard")
                        {
                            Cards myCard1 = new Cards("", new Effects(""), "", "", 0, 0, 0);
                            if (myCard1.Name != "") {}
                            else
                            {
                                ConsoleKey key;
                                System.Console.WriteLine("Select a oponent card to apply your effect");
                                key =  Console.ReadKey(true).Key;
                                myCard1 = new Select().SelectCard(key, oplayer.Index);
                            }
                            CardModifiquer(myCard1,spliter);
                            break;
                        }
                    }
                }
            }
        }
        //Acciones sobre el player
        public static void PlayerModifiquer(Player player, string[]line)
        {
            string modifiquer = "";
            for (int i = 0; i < line.Length; i++)
            {
                if(line[i]=="Player"|| line[i]=="<" || line[i]==">" || line[i]=="Oplayer"){continue;}
                else
                {
                    if (modifiquer=="Manna")
                    {
                        int Mnum = int.Parse(line[i+1]);
                        if(line[i]=="+"){player.Manna = player.Manna + Mnum; break;}
                        if(line[i]=="-"){player.Manna = player.Manna - Mnum; break;}
                        if(line[i]=="*"){player.Manna = player.Manna * Mnum; break;}
                        if(line[i]=="/"){player.Manna = player.Manna / Mnum; break;}
                        if(line[i]=="~"){player.Manna = Mnum; break;}
                    }
                    if (modifiquer=="Life")
                    {
                        int Lnum = int.Parse(line[i+1]);
                        if(line[i]=="+"){player.Life = player.Life + Lnum; break;}
                        if(line[i]=="-"){player.Life = player.Life - Lnum; break;}
                        if(line[i]=="*"){player.Life = player.Life * Lnum; break;}
                        if(line[i]=="/"){player.Life = player.Life / Lnum; break;}
                        if(line[i]=="~"){player.Life = Lnum; break;}
                    }
                    if (modifiquer=="Hand")
                    {
                        int Hnum = int.Parse(line[i+1]);
                        //int mano = player.Hand.Count;
                        // if (line[i]=="~")
                        // {
                        //     while (mano != Hnum)
                        //     {
                        //         if(mano > Hnum)
                        //         {
                        //             player.Deck.Add(player.Hand[0]);
                        //             player.Hand.Remove(player.Hand[0]);
                        //             Hnum -= 1;
                        //         }
                        //         else if(mano < Hnum)
                        //         {
                        //             player.Hand.Add(player.Deck[0]);
                        //             player.Deck.Remove(player.Deck[0]);
                        //             Hnum -= 1;
                        //         }
                        //         mano = player.Hand.Count;
                        //     }
                        //     break;
                        // }
                        while (Hnum!=0)
                        {
                            if(line[i]=="+")
                            {
                                if(player.Deck.Count==0){break;}
                                player.Hand.Add(player.Deck[0]);
                                player.Deck.Remove(player.Deck[0]);
                                Hnum -= 1;
                            }
                            if (line[i]=="-")
                            {
                                if(player.Hand.Count==0){break;}
                                player.Deck.Add(player.Hand[0]);
                                player.Hand.Remove(player.Hand[0]);
                                Hnum -= 1;
                            }
                        }
                    }
                    modifiquer = line[i];
                }
            }
        }
        public static void CardModifiquer(Cards card, string[] line)
        {
            string modifiquer = "";
            for (int i = 0; i < line.Length; i++)
            {
                if(line[i]=="Card"|| line[i]=="<" || line[i]==">"){continue;}
                else
                {
                    if(modifiquer=="Attack")
                    {
                        int Anum = int.Parse(line[i+1]);
                        if(line[i]=="+"){card.Attack = card.Attack + Anum; break;}
                        if(line[i]=="-"){card.Attack = card.Attack - Anum; break;}
                        if(line[i]=="*"){card.Attack = card.Attack * Anum; break;}
                        if(line[i]=="/"){card.Attack = card.Attack / Anum; break;}
                        if(line[i]=="~"){card.Attack = Anum; break;}
                    }
                    if (modifiquer=="Cost")
                    {
                        int Cnum = int.Parse(line[i+1]);
                        if(line[i]=="+"){card.Cost = card.Cost + Cnum; break;}
                        if(line[i]=="-"){card.Cost = card.Cost - Cnum; break;}
                        if(line[i]=="*"){card.Cost = card.Cost * Cnum; break;}
                        if(line[i]=="/"){card.Cost = card.Cost / Cnum; break;}
                        if(line[i]=="~"){card.Cost = Cnum; break;}
                    }
                    if (modifiquer=="Energy")
                    {
                        int Enum = int.Parse(line[i+1]);
                        if(line[i]=="+"){card.Energy = card.Energy + Enum; break;}
                        if(line[i]=="-"){card.Energy = card.Energy - Enum; break;}
                        if(line[i]=="*"){card.Energy = card.Energy * Enum; break;}
                        if(line[i]=="/"){card.Energy = card.Energy / Enum; break;}
                        if(line[i]=="~"){card.Energy = Enum; break;}
                    }
                    modifiquer = line[i];
                }
            }
        }
    }
}