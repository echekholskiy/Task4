using FluentAssertions;
using Task4.Models;
using Task4.Pages;
using TechTalk.SpecFlow;

namespace Test.StepDefinitions
{
    [Binding]
    public class GamePageSteps
    {
        private readonly GamePage _gamePage;

        public GamePageSteps(GamePage gamePage)
        {
            this._gamePage = gamePage;
        }

        [When(@"Enter the correct age on the Rated content if it's shown")]
        public void WhenEnterCorrectAge(Birth birth)
        {
            _gamePage.PassAgeGate(birth.Day, birth.Month, birth.Year);
        }

        [When(@"I check discount of the game")]
        public void WhenCheckGameDiscount()
        {
           ScenarioContext.Current.Add("InnerGame", _gamePage.GetGameModel());
        }

        [Then(@"Then discount rate, initial and discounted prices equals to corresponding values")]
        public void ThenDiscountIsEqual()
        {
            var expectedDiscount = ScenarioContext.Current["InnerGame"];
            var actualDiscount = ScenarioContext.Current["Game"];
            actualDiscount.Should().BeEquivalentTo(expectedDiscount, "Discount and prices are equal");
        }

        [Then(@"Game page is opened")]
        public void ThenGamePageOpened()
        {
            _gamePage.PageIsOpened(ScenarioContext.Current["GameName"].ToString());
        }
    }
}
