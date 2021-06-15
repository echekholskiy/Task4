using System.Collections.Generic;
using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;
using Task4.Extensions;
using Task4.Models;

namespace Task4.Pages
{
    public class ActionPage : Form
    {
        private IButton TopSellersTab =>
            ElementFactory.GetButton(By.XPath("//*[@id='tab_select_TopSellers']"), nameof(TopSellersTab));

        private ITextBox TopSellersTable =>
            ElementFactory.GetTextBox(By.XPath("//*[@id='tab_content_TopSellers']"), nameof(TopSellersTable));

        public IList<ITextBox> GameWithDiscountTextBoxes => ElementFactory.FindElements<ITextBox>(
            By.XPath("//*[@id='TopSellersTable']//a[.//div[contains(@class, 'discount_pct')]]"),
            nameof(GameWithDiscountTextBoxes));

        public ActionPage() : base(By.XPath("//*[@class='pageheader' and contains(text(), 'Экшен')]"),
            nameof(ActionPage))
        {
        }

        public void ClickTopSellersTab()
        {
            TopSellersTab.Click();
        }

        public bool TopSellersTableIsSelected()
        {
            return TopSellersTable.State.WaitForDisplayed();
        }

        public ITextBox GetGameWithLowestDiscount()
        {
            return ElementFactory.GetTextBox(
                By.XPath($"//*[@id='TopSellersTable']//a[.//div[contains(text(), '{this.GetLowestDiscount()}')]]"), "LowestDiscount");
        }

        public string GetNameOfGameWithLowestDiscount()
        {
            var game = GetGameWithLowestDiscount();
            return game.FindChildElement<ITextBox>(By.XPath("//div[@class='tab_item_name']")).Text;
        }

        public void ClickGameWithLowestDiscount()
        {
            GetGameWithLowestDiscount().Click();
        }

        public Game GetGame()
        {
            var game = GetGameWithLowestDiscount();
            var discount = game.FindChildElement<ITextBox>(By.XPath("//div[@class='discount_pct']")).Text;
            var originalPrice = game.FindChildElement<ITextBox>(By.XPath("//div[@class='discount_original_price']")).Text;
            var finalPrice = game.FindChildElement<ITextBox>(By.XPath("//div[@class='discount_final_price']")).Text;

            return new Game(discount, originalPrice, finalPrice);
        }
    }
}
