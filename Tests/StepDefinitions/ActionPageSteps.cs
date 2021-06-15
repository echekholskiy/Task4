using FluentAssertions;
using Task4.Pages;
using TechTalk.SpecFlow;

namespace Test.StepDefinitions
{
    [Binding]
    public class ActionPageSteps
    {
        private readonly ActionPage _actionPage;

        public ActionPageSteps(ActionPage actionPage)
        {
            this._actionPage = actionPage;
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
            ScenarioContext.Current.Add("GameName", _actionPage.GetNameOfGameWithLowestDiscount());
            ScenarioContext.Current.Add("Game", _actionPage.GetDiscountGame()); 
        }

        [When(@"I Click the game with the lowest discount")]
        public void WhenClickGameWithLowestDiscount()
        {
            _actionPage.ClickGameWithLowestDiscount();
        }

        [When(@"I click Top Selling tab")]
        public void WhenIClickTopSellingTab()
        {
            _actionPage.ClickTopSellersTab();
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
