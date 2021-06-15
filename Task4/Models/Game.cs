namespace Task4.Models
{
    public class Game
    {
        public string GameDiscount;
        public string OriginalPrice;
        public string FinalPrice;

        public Game(string gameDiscount, string originalPrice, string finalPrice)
        {
            this.GameDiscount = gameDiscount;
            this.OriginalPrice = originalPrice;
            this.FinalPrice = finalPrice;
        }
    }
}
