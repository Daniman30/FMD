namespace FMD
{
    public class Player
    {
        public Player ( List<Cards> Hand )
        {
            Life = 6;
            Manna = 6;
            this.Hand = Hand;

        }
        public int Life { get;   set;}
        public int Manna { get; set;}
        public List<Cards> Hand = new List<Cards>();
        public Player player1 = new Player(new List<Cards>());
        public Player player2 = new Player(new List<Cards>());
        
    }
}
