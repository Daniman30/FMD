namespace FMD
{
    public class EffectCompiler
    {
        public static List<string> SuperProp = new List<string>(){"Player","MyCard","Oplayer","Ocard"};
        public static List<string> PlayerPP = new List<string>(){"Life","Manna","Hand"};
        public static List<string> CardPP = new List<string>(){"Attack","Cost","Energy"};
        public static List<char> Signers = new List<char> (){'+','-','*','/','~'};
        public static List<char> OpenClose = new List<char>(){'{','}','[',']','(',')','<','>'};
        
        public static Effects CheckEffect(string code)
        {
            List<string> CODEX = File.ReadAllLines(code).ToList();
            (int,int,int,int) openclose = (0,0,0,0);
            List<string> Temp = new List<string>();
            string nameeffect = " ";
            string effectdescription = " ";
            int linecounter = 1;

            foreach (string line in CODEX)
            {
                string newline = string.Join(' ', line.Split(' ', StringSplitOptions.RemoveEmptyEntries));
                string[] spliter = newline.Split(' ',';',',');
                int WordC = 0;

                if (linecounter==1)
                {
                    if(spliter[0]==""){System.Console.WriteLine("Se esperaba nombre del efecto"); return new Effects("","");}
                    nameeffect = spliter[0];
                    linecounter++;
                    continue;
                }
                for (int i = 0; i < newline.Length; i++)
                {
                    if(newline[i]==' '){continue;}
                    if (!char.IsLetter(newline[i]))
                    {
                        if (OpenClose.Contains(newline[i]))
                        {
                            if(newline[i]==','){WordC++; continue;}
                            //OPEN
                            if(newline[i]=='{')
                            {
                                openclose.Item1 += 1;
                                if(newline.Length==1){continue;}
                                else{return new Effects("","");}//No se pueden poner mas caracteres en una linea donde este { o }
                            }
                            if(newline[i]=='['){openclose.Item2 += 1; continue;}
                            if(newline[i]=='('){WordC++; openclose.Item3 += 1; continue;}
                            if(newline[i]=='<'){WordC++; openclose.Item4 += 1; continue;}
                            
                            //CLOSE
                            if(newline[i]=='}')
                            {
                                openclose.Item1 -= 1;
                                if(newline.Length==1){continue;}
                                else{return new Effects("","");}
                            }
                            if(newline[i]==']' && openclose.Item2!=0){openclose.Item2 -= 1; continue;}
                            if(newline[i]==')' && openclose.Item3!=0){WordC++; openclose.Item3 -= 1; continue;}
                            if(newline[i]=='>' && openclose.Item4!=0){WordC++; openclose.Item4 -= 1; continue;}

                            else{return new Effects("","");}
                        }
                        else
                        {
                            if(Signers.Contains(newline[i]) || newline[i]==';')
                            {
                                continue;
                            }
                        }
                    }
                    else
                    {
                        if(spliter[0]=="Description")
                        {
                            if (spliter[1][0]=='#' && newline[newline.Length-2]=='#' && newline[newline.Length-1]==';')
                            {
                               effectdescription = GetDescription(newline);   
                               break;
                            }
                            else{return new Effects("","");}
                        }
                        if (spliter[0]=="Action")
                        {
                            if(spliter[WordC]==""){WordC++; continue;}
                            if (SuperProp.Contains(spliter[WordC]))
                            {
                                Temp.Add(spliter[WordC]);
                                i += spliter[WordC].Length - 1;
                                WordC++;
                                continue;
                            }
                            i += "Action".Length;
                            WordC++;
                        }
                        if (Temp.Contains(spliter[0]))
                        {
                            if (IsValid(spliter[0],newline))
                            {
                                i += spliter[WordC].Length;
                                continue;
                            }
                            i+=spliter[0].Length;
                            WordC++;
                        }
                    }
                }
            }
            if(openclose==(0,0,0,0)){return new Effects(effectdescription,nameeffect);}
            return new Effects("","");
        }
        public static string GetDescription(string text)
        {
            string description = "";
            for (int i = 0; i < text.Length; i++)
            {
                if(text[i]=='#')
                {
                    for (int j = i + 1; j < text.Length; j++)
                    {
                        if(text[j]=='#' && text[j+1]==';'){break;}
                        description = description + text[j];
                    }
                    break;
                }
            }
            return description;
        }
        public static bool IsValid(string Sprop, string line)
        {
            string[] spliLine = line.Split(' ',';');

            if (Sprop=="Player" || Sprop=="Oplayer")
            {
                for (int i = 0; i < spliLine.Length; i++)
                {
                    if(spliLine[i]==Sprop || spliLine[i]=="<" || spliLine[i]==">"){continue;}
                    if(PlayerPP.Contains(spliLine[i]))
                    {
                        return true;
                    }
                }
            }
            if (Sprop=="MyCard" || Sprop=="Ocard")
            {
                for (int i = 0; i < spliLine.Length; i++)
                {
                    if(spliLine[i]==Sprop || spliLine[i]=="<" || spliLine[i]==">"){continue;}
                    if(CardPP.Contains(spliLine[i]))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}