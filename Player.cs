namespace FMD
{
    public class Player
    {
        public Player ( List<Cards> Hand, int Index, List<Cards> Deck)
        {
            Life = 6;
            Manna = 6;
            this.Hand = Hand;
            this.Index = Index;
            this.Deck = Deck;
        }
        public int Life { get;   set;}
        public int Manna { get; set;}
        public int Index { get; set;}
        public List<Cards> Hand = new List<Cards>();
        public List<Cards> Deck = new List<Cards>();
    }
   
    

    
}