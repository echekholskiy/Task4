using System;
using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;
using Task4.Elements;
using Task4.Models;

namespace Task4.Pages
{
    public class ActionPage : Form
    {
        private IButton TopSellersTab =>
            ElementFactory.GetButton(By.XPath("//*[@id='tab_select_TopSellers']"), nameof(TopSellersTab));
        private ITextBox TopSellersTable =>
            ElementFactory.GetTextBox(By.XPath("//*[@id='tab_content_TopSellers']"), nameof(TopSellersTable));
        private readonly Lazy<GameElement> _gameElement = new();

        public ActionPage() : base(By.XPath("//*[@class='pageheader' and contains(text(), 'Action')]"),
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

        public void ClickGameWithLowestDiscount()
        {
            _gameElement.Value.ClickElementWithLowestDiscount();
        }

        public string GetNameOfGameWithLowestDiscount()
        {
            return _gameElement.Value.GetNameOfGameWithLowestDiscount();
        }

        public Game GetDiscountGame()
        {
            return _gameElement.Value.GetDiscountModel();
        } 
    }
}
