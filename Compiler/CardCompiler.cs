using System;
namespace FMD
{
    public class CardCompiler
    {
        public static List<char> Signers = new List<char>() {'(',')','[',']','{','}',',','.',':',';'};
        public static List<string> EfectID = Names();
        public static List<(string,string)> EfectRute = EffectActivate.Names();
        public static List<string>ReservedWords = new List<string>(){"Name","Effects","Type","Legion","Attack","Cost","Energy"};
        public static Cards TryCompiler(string path)
        {
            bool compiler = ChekSemantic(path);

            if (compiler)
            {
                return CraeteNewCard(path);
            }
            else{return new Cards("A",new IncreaseAtk(""),"","",0,0,0);}
        }
        public static bool ChekSemantic(string code)
        {
            int linecounter = 1;
            (int,int,int) openclose = (0,0,0) ; //item1 {}, item2 [], item3 ()
            List<string> Programing = File.ReadLines(code).ToList();

            foreach (string line in Programing)
            {
                string newline = string.Join(' ', line.Split(' ', StringSplitOptions.RemoveEmptyEntries));
                string[] spliter = newline.Split(' ',';');
                bool sem = false;

                if (Programing[0]=="Create Card" && linecounter==1)
                {
                    linecounter++; 
                    continue;
                }

                for (int i = 0; i < newline.Length; i++)
                {
                    if (!char.IsLetterOrDigit(newline[i]))
                    {
                        if(Signers.Contains(newline[i]))
                        {
                            if(newline[i]=='{'){openclose.Item1 +=1 ;}
                            if(newline[i]=='['){openclose.Item2 +=1 ;}
                            if(newline[i]=='('){openclose.Item3 +=1 ;}
                            if(newline[i]=='}'){openclose.Item1 -=1 ;}
                            if(newline[i]==']'){openclose.Item2 -=1 ;}
                            if(newline[i]==')'){openclose.Item3 -=1 ;}
                        }
                        else {return false;}
                    }
                    else
                    {
                        if (ReservedWords.Contains(spliter[0]))
                        {
                            sem = Rectificater(spliter[0],spliter);
                            break;
                        }
                        else{return false;}
                    }
                }
                
                if (sem && newline.Length != 1)
                {
                    if (newline[newline.Length-2]=='#' && newline[newline.Length-1]==';')
                    {
                        linecounter++;
                        continue;
                    }
                    else if(newline[newline.Length-1]==';')
                    {
                        linecounter++;
                        continue;
                    }
                    else {return false;}
                }
            }  
            if(openclose==(0,0,0)){return true;}
            return false;
        }
        public static bool RealEffect(string nameEffect)
        {
            List<Effects> Effectskey = new List<Effects> 
            {
                new IncreaseAtk(""), new IncreaseCost(""), new IncreaseManna(""),
                new DrawCards(""), new DecreaseAtk(""), new DecreaseCost(""),
                new MaidControl(""), new DestroyMonsters(""), new DecreaseAtkPerTurn(""),
                new DestroyAllMonster(""), new DestroyedHand(""), new SpecialSummon(""),
                new DecreaseManna(""), new MultiAtk("")
            };
            for (int i = 0; i < Effectskey.Count; i++)
            {
                if (nameEffect==Effectskey[i].GetType().Name)
                {
                    return true;
                }
            }
            if (EfectID.Contains(nameEffect))
            {
                return true;
            }
            return false;
        }
        public static bool Rectificater(string keyword, string[] text)
        {
            List<string> textkey = new List<string> {"Name","Effects","Type"};
            List<string> numkey = new List<string> {"Attack","Cost","Energy"};

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i]=="~" && textkey.Contains(keyword))
                {
                    if (keyword=="Effects")
                    {
                        if(RealEffect(text[i+1]))
                        {
                            return true;
                        }
                    }
                    if (text[i+1][0]=='#') {return true;}
                }
                if (text[i]=="~" && numkey.Contains(keyword))
                {
                    int num = int.Parse(text[i+1]);
                    if (num >= 0)
                    {
                        return true;
                    }
                }
                if (text[i]=="~" && keyword=="Legion")
                {
                    if(text[i+1]=="Underworld"||text[i+1]=="Celestial"){return true;}
                }
            }
            return false;
        }
        public static Effects AsignEffect(string nameEffect)
        {
            List<Effects> Effectskey = new List<Effects> 
            {
                new IncreaseAtk(""), new IncreaseCost(""), new IncreaseManna(""),
                new DrawCards(""), new DecreaseAtk(""), new DecreaseCost(""),
                new MaidControl(""), new DestroyMonsters(""), new DecreaseAtkPerTurn(""),
                new DestroyAllMonster(""), new DestroyedHand(""), new SpecialSummon(""),
                new DecreaseManna(""), new MultiAtk("")
            };
            for (int i = 0; i < Effectskey.Count; i++)
            {
                if (nameEffect==Effectskey[i].GetType().Name)
                {
                    return Effectskey[i];
                }
            }
            for (int i = 0; i < EfectRute.Count; i++)
            {
                if(EfectRute[i].Item2==nameEffect)
                {return EffectCompiler.CheckEffect(EfectRute[i].Item1);}
            }
            return new Effects("","");
        }
        public static Cards CraeteNewCard(string code)
        {
            List<string> Programing = File.ReadLines(code).ToList();
            string nameCard = CreateCard.TextProperties("Name",Programing);
            Effects effects = AsignEffect(CreateCard.TextProperties("Effects",Programing));
            string typeCard = CreateCard.TextProperties("Type",Programing);
            string legionCard = CreateCard.TextProperties("Legion",Programing);
            int attackcard = CreateCard.NumProperties("Attack",Programing);
            int costCard = CreateCard.NumProperties("Cost",Programing);
            int energyCard = CreateCard.NumProperties("Energy",Programing);

            return new Cards(nameCard,effects,typeCard,legionCard,attackcard,costCard,energyCard);
        }
        public static List <string> Names()
        {
            List <string> ID = new List<string>();
            string[] files = Directory.GetFiles(@"C:/Miguel/Proyecto/Efectos/");
            for (int i = 0; i < files.Length; i++)
            {
                string[] split = files[i].Split('/','.');
                ID.Add(split[split.Length-2]);
            }
            return ID;
        }
    }
    public class CreateCard
    {
        public static string TextProperties(string propertie, List<string> Params)
        {
            char[] delimitors = {' ','~','#',';'};
            string result = "";

            foreach (string s in Params)
            {
                string[] spliter = s.Split(delimitors);
                for (int j = 0; j < spliter.Length; j++)
                {
                    if (propertie==spliter[j])
                    {
                        for (int i = j; i < spliter.Length; i++)
                        {
                            if (spliter[i]!="" && spliter[i]!=propertie)
                            {
                                result += spliter[i] + " ";
                            }
                        }
                        break;
                    }
                }
            }
            return result.Trim(' ');
        }
        public static int NumProperties(string propertie, List<string> Params)
        {
            char[] delimitors = {' ','~','#',';'};
            int result = 0;

            foreach (string s in Params)
            {
                string[] spliter = s.Split(delimitors);
                for (int j = 0; j < spliter.Length; j++)
                {
                    if (propertie==spliter[j])
                    {
                        for (int i = j; i < spliter.Length; i++)
                        {
                            result = int.Parse(spliter[spliter.Length-2]);
                        }
                    }
                }
            }
            return result;
        }
    }
}