namespace FMD
{
    public static class IADif
    {
          public static List<Cards> SelectDeckByDif(List<Cards> AllCards)
        {
            if (Game.dif == 2)  //Hard
            {
                if (AllCards[0].Legion == "Celestials") 
                {
                    List<int> YesCards = new List<int>{0, 3, 5, 9, 13, 14, 16, 17, 20, 21, 22, 24, 30}; //Dragones y Spell
                    
                    List<int> Dragons = new List<int>{31, 32, 33, 34};
                    List<int> Magics = new List<int>{36, 37, 38, 39, 42, 44, 46};

                    return RefillDeck(AllCards, AddDragonsAndMagics(YesCards, Dragons, Magics));
                }
                else    //Underwolrd
                {
                    List<int> YesCards = new List<int>{0, 4, 5, 6, 11, 12, 13, 16, 20, 21, 22, 24, 25, 28, 29}; //Dragones y Spell

                    List<int> Dragons = new List<int>{34, 35, 36, 37};
                    List<int> Magics = new List<int>{41, 42, 43, 44, 48, 49, 50};

                    return RefillDeck(AllCards, AddDragonsAndMagics(YesCards, Dragons, Magics));
                }
            }
            else if (Game.dif == 0) //Easy
            {
                if (AllCards[0].Legion == "Celestials") 
                {
                    List<int> YesCards = new List<int>{1, 2, 4, 6, 7, 8, 10, 11, 12, 15, 18, 19, 23, 25, 26, 27, 28, 29}; //Dragones y Spell

                    List<int> Dragons = new List<int>{35};
                    List<int> Magics = new List<int>{40, 41, 43, 45};

                    return RefillDeck(AllCards, AddDragonsAndMagics(YesCards, Dragons, Magics));
                }
                else    //Underworld
                {
                    List<int> YesCards = new List<int>{1, 2, 3, 7, 8, 9, 10, 14, 15, 17, 18, 19, 23, 26, 27, 30, 31, 32, 33}; //Dragones y Spell

                    List<int> Dragons = new List<int>{38};
                    List<int> Magics = new List<int>{39, 40, 45, 46, 47};

                    return RefillDeck(AllCards, AddDragonsAndMagics(YesCards, Dragons, Magics));
                }
            }
            else
            {
                if (AllCards[0].Legion == "Celestials") return Cards.SelectDeck(Cards.Celestial(), 100);
                else return Cards.SelectDeck(Cards.Underworld(), 100);
            }
        }

        private static List<Cards> RefillDeck(List<Cards> AllCards, List<int> YesCards)
        {
            List<Cards> FinalDeck = new List<Cards>();
            List<int> SelectedNumbers = new List<int>();
            Random m = new Random();
            Random n = new Random();
            int count = 1;
            for (int i = 0; i < 30; i+= count)
            {
                count = m.Next(2, 5);
                int num = n.Next(0, AllCards.Count);
                if (SelectedNumbers.Contains(num) || !(YesCards.Contains(num)))
                {
                    count = 0;
                    continue;
                }
                else
                {
                    for (int j = 0; j < count; j++)
                    {
                        FinalDeck.Add(AllCards[num]);
                    }
                    SelectedNumbers.Add(num);
                }
            }
            return FinalDeck;
        }

        private static List<int> AddDragonsAndMagics(List<int> FinalList, List<int> Dragons, List<int> Magics)
        {
            //Dragons
            for (int i = 0; i < 2; i++)
            {
                Random k = new Random();
                int posDragons = k.Next(Dragons.Count);
                FinalList.Add(Dragons[posDragons]);
                Dragons.Remove(Dragons[posDragons]);
            }

            //Magics
            for (int i = 0; i < 2; i++)
            {
                Random k = new Random();
                int posMagics = k.Next(Magics.Count);
                FinalList.Add(Magics[posMagics]);
                Magics.Remove(Magics[posMagics]);
            }
            return FinalList;
        }
    }
}