using FluentAssertions;
using Task4.Pages;
using TechTalk.SpecFlow;

namespace Test.StepDefinitions
{
    [Binding]
    public class ActionPageSteps
    {
        private readonly ActionPage _actionPage;
        private readonly ScenarioContext _scenarioContext;

        public ActionPageSteps(ActionPage actionPage, ScenarioContext scenarioContext)
        {
            this._actionPage = actionPage;
            _scenarioContext = scenarioContext;
        }

        [Then(@"Action page is opened")]
        public void ThenActionPageIsOpened()
        {
            var isOpened = _actionPage.State.WaitForDisplayed();
            isOpened
                .Should()
                .BeTrue("Action page is opened");
        }

        [Given(@"The game with the lowest discount")]
        public void WhenIGetGameWithLowestDiscount()
        {
            _scenarioContext.Add("GameName", _actionPage.GetNameOfGameWithLowestDiscount());
            _scenarioContext.Add("Game", _actionPage.GetDiscountGame());
        }

        [When(@"I Click the game with the lowest discount")]
        public void WhenClickGameWithLowestDiscount()
        {
            _actionPage.ClickGameWithLowestDiscount();
        }

        [When(@"I click (.*) tab")]
        public void WhenIClickTopSellingTab(string tab)
        {
            _actionPage.ClickTab(tab);
        }

        [Then(@"Top selling tab is opened")]
        public void ThenTopSellingTabOpened()
        {
            var isSelected = _actionPage.TopSellersTableIsSelected();
            isSelected
                .Should()
                .BeTrue("Top selling tab is opened");
        }
    }
}
