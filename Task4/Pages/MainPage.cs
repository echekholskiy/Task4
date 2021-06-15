using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace Task4.Pages
{
    public class MainPage : Form
    {
        private IButton CategoriesButton =>
            ElementFactory.GetButton(By.XPath("//*[@id='genre_tab']"), nameof(CategoriesButton));
        private IButton ActionButton => ElementFactory.GetButton(
            By.XPath("//*[@data-genre-group='action' and contains(@class, 'subheader')]//a"), nameof(ActionButton));

        public MainPage() : base(By.XPath("//*[@class='home_ctn']"), "MainPage")
        {
        }

        public void HoverMouseOverCategories()
        {
            CategoriesButton.MouseActions.MoveToElement();
        }

        public void ClickActionGenre()
        {
            ActionButton.Click();
        }
    }
}
