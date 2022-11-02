namespace FMD
{
    public class Field
    {
        public static Cards[,] FieldStart()
        {
            Cards[,] StartField = new Cards[4,3];
            return StartField;
        }
        static void Main(string[] args)
        {
            Cards[,] Start = FieldStart();
            List<Cards> Deck = Cards.Create();

            Start[0,1] = Deck[Deck.Count-1];
            System.Console.WriteLine(Start[0,1].Name);
        }
    }
}