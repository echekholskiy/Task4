using Aquality.Selenium.Browsers;
using FluentAssertions;
using Task4.Configuration;
using Task4.Pages;
using Task4.Utils;
using TechTalk.SpecFlow;

namespace Tests.StepDefinitions
{
    [Binding]
    public class MainPageSteps
    {
        private readonly MainPage mainPage;

        public MainPageSteps(MainPage mainPage)
        {
            this.mainPage = mainPage;
        }

        [When(@"I open Main page")]
        public void WhenIOpenMainPage()
        {
            AqualityServices.Browser.GoTo(Configuration.BaseUri);
        }

        [Then(@"Main page is opened")]
        public void MainPageIsOpened()
        {
            var isOpened = mainPage.State.WaitForDisplayed();
            isOpened
                .Should()
                .BeTrue("Main page is opened");
        }

        [When(@"I navigate categories in the top menu")]
        public void WhenNavigateCategoriesInTopMenu()
        {
            mainPage.HoverMouseOverCategories();
        }

        [Given(@"Click Action games")]
        public void ClickActionGames()
        {
            mainPage.ClickActionGenre();
        }
    }
}
