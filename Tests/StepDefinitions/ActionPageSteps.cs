using FluentAssertions;
using Task4.Models;
using Task4.Pages;
using TechTalk.SpecFlow;

namespace Tests.StepDefinitions
{
    [Binding]
    public class ActionPageSteps
    {
        private readonly ActionPage actionPage;

        public ActionPageSteps(ActionPage actionPage)
        {
            this.actionPage = actionPage;
        }

        [Then(@"Action page is opened")]
        public void ThenActionPageIsOpened()
        {
            var isOpened = actionPage.State.WaitForDisplayed();
            isOpened
                .Should()
                .BeTrue("Action page is opened");
        }

        [When(@"I get the game with the lowest discount")]
        public Game WhenIGetGameWithLowestDiscount()
        {
            return actionPage.GetGame();
        }

        [When(@"I Click the game with the lowest discount")]
        public void WhenClickGameWithLowestDiscount()
        {
            actionPage.ClickGameWithLowestDiscount();
        }


    }
}
