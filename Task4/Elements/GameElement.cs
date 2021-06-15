using System.Collections.Generic;
using System.Linq;
using Aquality.Selenium.Browsers;
using Aquality.Selenium.Core.Elements;
using Aquality.Selenium.Elements.Interfaces;
using OpenQA.Selenium;
using Task4.Models;

namespace Task4.Elements
{
    public class GameElement
    {
        public IList<ITextBox> GameWithDiscountTextBoxes => ElementFactory.FindElements<ITextBox>(
            By.XPath("//*[@id='TopSellersTable']//a[.//div[contains(@class, 'discount_pct')]]"),
            nameof(GameWithDiscountTextBoxes), expectedCount: ElementsCount.MoreThenZero);
        private static IElementFactory ElementFactory => AqualityServices.Get<IElementFactory>();
        private readonly ITextBox _gameWithLowestDiscount;

        public GameElement()
        {
            _gameWithLowestDiscount = GetGameWithLowestDiscount();
        }

        public string GetNameOfGameWithLowestDiscount()
        {
            ElementFactory.GetButton(By.XPath("//*[@id='TopSellers_links']//span[text()= '5 ']"), "dsf").Click();
            return _gameWithLowestDiscount.FindChildElement<ITextBox>(By.XPath("//div[@class='tab_item_name']")).Text;
        }

        public Game GetDiscountModel()
        {
            var discount = _gameWithLowestDiscount
                .FindChildElement<ITextBox>(By.XPath("//div[@class='discount_pct']")).Text;
            var originalPrice = _gameWithLowestDiscount
                .FindChildElement<ITextBox>(By.XPath("//div[@class='discount_original_price']")).Text;
            var finalPrice = _gameWithLowestDiscount
                .FindChildElement<ITextBox>(By.XPath("//div[@class='discount_final_price']")).Text;

            return new Game(discount, originalPrice, finalPrice);
        }

        public void ClickElementWithLowestDiscount()
        {
            _gameWithLowestDiscount.Click();
        }

        private string GetMinDiscount()
        {
            var listOfDiscountPct = GameWithDiscountTextBoxes
                .Select(a => a.FindChildElement<ITextBox>(By.XPath("//*[@class='discount_pct']"))).ToList();
            var discountList = listOfDiscountPct.Select(a => a.Text);
            return discountList.Min();
        }

        private ITextBox GetGameWithLowestDiscount()
        {
            return ElementFactory.GetTextBox(
                By.XPath($"//*[@id='TopSellersTable']//a[.//div[contains(text(), '{GetMinDiscount()}')]]"),
                "LowestDiscount");
        }
    }
}
