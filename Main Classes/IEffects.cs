namespace FMD
{
    public interface IEffects
    {
        public abstract void Action(Cards card);
        public abstract void Action(Player player);
        public abstract void Action(Cards card, int decrease, (int,int) pos, Player player );
        public abstract void Action(Cards cards, Player player);
        public abstract void Action(Cards card, Cards card1,Cards card2, Player player, Player Oplayer);
        public string description{  get; set;}
        public string name{  get; set;}   
    }
}