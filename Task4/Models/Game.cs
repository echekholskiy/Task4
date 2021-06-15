namespace Task4.Models
{
    public class Game
    {
        private string _gameDiscount;
        private string _originalPrice;
        private string _finalPrice;

        public Game(string gameDiscount, string originalPrice, string finalPrice)
        {
            this._gameDiscount = gameDiscount;
            this._originalPrice = originalPrice;
            this._finalPrice = finalPrice;
        }
    }
}
