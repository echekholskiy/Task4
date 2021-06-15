using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;
using Task4.Models;

namespace Task4.Pages
{
    public class GamePage : Form
    {
        private IComboBox AgeDay => ElementFactory.GetComboBox(By.XPath("//*[@id='ageDay']"), nameof(AgeDay));
        private IComboBox AgeMonth => ElementFactory.GetComboBox(By.XPath("//*[@id='ageMonth']"), nameof(AgeMonth));
        private IComboBox AgeYear => ElementFactory.GetComboBox(By.XPath("//*[@id='ageYear']"), nameof(AgeYear));
        private IButton OpenPageButton =>
            ElementFactory.GetButton(By.XPath("//*[@href='#' and contains(@class, 'btn_medium')]"),
                nameof(OpenPageButton));
        private ITextBox Discount =>
            ElementFactory.GetTextBox(By.XPath("//div[@class='discount_pct']"), nameof(Discount));
        private ITextBox OriginalPrice => ElementFactory.GetTextBox(By.XPath("//div[@class='discount_original_price']"),
            nameof(OriginalPrice));
        private ITextBox FinalPrice => ElementFactory.GetTextBox(
            By.XPath("//div[@class='game_purchase_action_bg']//div[@class='discount_final_price']"),
            nameof(FinalPrice));
        private const string Day = "11";
        private const string Month = "January";
        private const string Year = "1994";
   
        public GamePage() 
            : base(By.XPath("//div[@id='appHubAppName']"), nameof(GamePage))
        {
            if (AgeDay.State.IsDisplayed)
            {
                PassAgeGate();
            }
        }

        public Game GetGameModel()
        {
            var discount = Discount.Text;
            var originalPrice = OriginalPrice.Text;
            var finalPrice = FinalPrice.Text.Replace(" USD", "");
            return new Game(discount, originalPrice, finalPrice);
        }

        public void PageIsOpened(string gameName)
        {
            ElementFactory.GetTextBox(By.XPath($"//*[@id='appHubAppName' and contains(text(), '{gameName}')]"),
                gameName);
        }

        private void SelectAgeDay(string day)
        {
            AgeDay.SelectByValue(day);
        }

        private void SelectAgeMonth(string month)
        {
            AgeMonth.SelectByValue(month);
        }

        private void SelectAgeYear(string year)
        {
            AgeYear.SelectByValue(year);
        }

        private void ClickOpenPageButton()
        {
            OpenPageButton.Click();
        }

        private void PassAgeGate()
        {
            SelectAgeDay(Day);
            SelectAgeMonth(Month);
            SelectAgeYear(Year);
            ClickOpenPageButton();
        }
    }
}
