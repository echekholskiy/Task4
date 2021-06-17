using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;
using Task4.Elements;
using Task4.Models;

namespace Task4.Pages
{
    public class ActionPage : Form
    {
        private ITextBox TopSellersTable =>
            ElementFactory.GetTextBox(By.XPath("//*[@id='tab_content_TopSellers']"), nameof(TopSellersTable));
        private readonly GameElement _gameElement = new();

        public ActionPage() : base(By.XPath("//*[@class='pageheader' and contains(text(), 'Action')]"),
            nameof(ActionPage))
        {
        }

        public void ClickTab(string tab)
        {
            ElementFactory.GetButton(By.XPath($"//*[@id='tab_select_{tab}']"), "Tab").Click();
        }

        public bool TopSellersTableIsSelected()
        {
            return TopSellersTable.State.WaitForDisplayed();
        }

        public void ClickGameWithLowestDiscount()
        {
            _gameElement.ClickElementWithLowestDiscount();
        }

        public string GetNameOfGameWithLowestDiscount()
        {
            return _gameElement.GetNameOfGameWithLowestDiscount();
        }

        public Game GetDiscountGame()
        {
            return _gameElement.GetDiscountModel();
        } 
    }
}
