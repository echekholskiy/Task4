using Aquality.Selenium.Browsers;
using FluentAssertions;
using Task4.Configuration;
using Task4.Pages;
using TechTalk.SpecFlow;

namespace Test.StepDefinitions
{
    [Binding]
    public class MainPageSteps
    {
        private readonly MainPage _mainPage;

        public MainPageSteps(MainPage mainPage)
        {
            this._mainPage = mainPage;
        }

        [When(@"I open Main page")]
        public void WhenIOpenMainPage()
        {
            AqualityServices.Browser.GoTo(Configuration.BaseUri);
        }

        [Then(@"Main page is opened")]
        public void MainPageIsOpened()
        {
            var isOpened = _mainPage.State.WaitForDisplayed();
            isOpened
                .Should()
                .BeTrue("Main page is opened");
        }

        [When(@"I navigate categories in the top menu")]
        public void WhenNavigateCategoriesInTopMenu()
        {
            _mainPage.HoverMouseOverCategories();
        }

        [When(@"Click (.*) games")]
        public void ClickActionGames(string genre)
        {
            _mainPage.ClickGenre(genre);
        }
    }
}
