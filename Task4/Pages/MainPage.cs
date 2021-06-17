using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace Task4.Pages
{
    public class MainPage : Form
    {
        private IButton CategoriesButton =>
            ElementFactory.GetButton(By.XPath("//*[@id='genre_tab']"), nameof(CategoriesButton));

        public MainPage() : base(By.XPath("//*[@class='home_ctn']"), "MainPage")
        {
        }

        public void HoverMouseOverCategories()
        {
            CategoriesButton.MouseActions.MoveToElement();
        }

        public void ClickGenre(string genre)
        {
            ElementFactory.GetButton(
                By.XPath($"//div[contains(@class, 'popup_menu_subheader')]//a[contains(text(), '{genre}')]"),
                "GenreButton").Click();
        }
    }
}
